using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using Aspose.GIS.TilesTest.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Globalization;
using System.Text;

namespace Aspose.GIS.TilesTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly string _dbConnectionString;

        public FeaturesController(IOptions<ConnectionStrings> options)
        {
            _dbConnectionString = options.Value.Db;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(double lat, double lng)
        {
            var latitude = lat.ToString(CultureInfo.InvariantCulture);
            var longitude = lng.ToString(CultureInfo.InvariantCulture);
            var query = $@"SELECT osm_id, building, name, ST_AsEWKB(way) as way
                        FROM public.planet_osm_polygon
                        WHERE ST_Intersects(way, ST_Transform(ST_SetSRID(ST_MakePoint({longitude}, {latitude}), 4326), 3857)) AND building IS NOT NULL";

            VectorLayer inputLayer;

            using (var conn = new NpgsqlConnection(_dbConnectionString))
            {
                var dataSource = Drivers.PostGis
                    .FromQuery(query)
                    .GeometryField("way")
                    .AddAttribute("osm_id", AttributeDataType.Long)
                    .AddAttribute("name", AttributeDataType.String)
                    .AddAttribute("building", AttributeDataType.String)
                    .Build();

                conn.Open();

                inputLayer = await dataSource.ReadAsync(conn);
            }

            var jsonStream = new MemoryStream();

            inputLayer.SaveTo(AbstractPath.FromStream(jsonStream), Drivers.GeoJson);

            var result = Encoding.UTF8.GetString(jsonStream.ToArray());

            return new ContentResult()
            {
                Content = result,
                ContentType = "application/geo+json"
            };
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {
            Request.EnableBuffering();

            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            
            // just buffer the body.
            await reader.ReadToEndAsync(); 
            Request.Body.Position = 0;

            using (var inputLayer = VectorLayer.Open(AbstractPath.FromStream(Request.Body), Drivers.GeoJson))
            {
                var ids = string.Join(", ", inputLayer.Select(x => x.GetValue<long>("osm_id")));

                var query = $@"SELECT osm_id, building, name, ST_AsEWKB(way) as way
                        FROM public.planet_osm_polygon
                        WHERE osm_id IN ({ids});";

                var dataSource = Drivers.PostGis
                    .FromQuery(query)
                    .GeometryField("way")
                    .AddAttribute("osm_id", AttributeDataType.Integer, System.Data.DbType.Int64)
                    .AddAttribute("name", AttributeDataType.String)
                    .AddAttribute("building", AttributeDataType.String)
                    .AsTrackableForChanges("public.planet_osm_polygon", "osm_id", true)
                    .Build();

                using var conn = new NpgsqlConnection(_dbConnectionString);
                await conn.OpenAsync();
                using var transaction = await conn.BeginTransactionAsync();

                using var editLayer = await dataSource.ReadAsync(conn, transaction);

                var transformer = SpatialReferenceSystem.Wgs84.CreateTransformationTo(SpatialReferenceSystem.WebMercator);

                foreach (var feature in inputLayer)
                {
                    // transformation
                    feature.Geometry = transformer.Transform(feature.Geometry);
                    ((Geometry)feature.Geometry).HasZ = false;

                    // replace on the edited layer
                    var replacingId = feature.GetValue<long>("osm_id");
                    var toReplaceIndex = editLayer.FindIndex(x => x.GetValue<long>("osm_id") == replacingId);
                    editLayer.ReplaceAt(toReplaceIndex, feature);
                }

                await dataSource.SubmitChangesAsync(editLayer, conn, transaction);

                transaction.Commit();
            }

            return Ok();
        }
    }
}
