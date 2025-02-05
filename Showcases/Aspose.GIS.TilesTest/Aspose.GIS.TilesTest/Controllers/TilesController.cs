using Aspose.Gis;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Aspose.Gis.Rendering;
using System.Globalization;
using Aspose.Gis.SpatialReferencing;
using Aspose.Gis.Rendering.Labelings;
using Aspose.Gis.Rendering.Symbolizers;
using System.Drawing;
using Aspose.GIS.TilesTest.Options;
using Microsoft.Extensions.Options;
using Aspose.Gis.Geometries;

namespace Aspose.GIS.TilesTest.Controllers
{
    public class TilesController : Controller
    {
        private readonly string _dbConnectionString;
        private const double _halfOfWorld = 20037508.34;

        public TilesController(IOptions<ConnectionStrings> options)
        {
            _dbConnectionString = options.Value.Db;
        }

        public async Task<ActionResult> Index(int z, int x, int y)
        {
            double worldSize = _halfOfWorld * 2;
            double tileSize = worldSize / Math.Pow(2, z);

            double min_x = x * tileSize - _halfOfWorld;
            double max_x = (x + 1) * tileSize - _halfOfWorld;
            double min_y = _halfOfWorld - (y + 1) * tileSize;
            double max_y = _halfOfWorld - y * tileSize;

            min_x = Math.Round(min_x, 10);
            max_x = Math.Round(max_x, 10);
            min_y = Math.Round(min_y, 10);
            max_y = Math.Round(max_y, 10);

            double ext_min_x = min_x - (max_x - min_x) * 0.05;
            double ext_max_x = max_x + (max_x - min_x) * 0.05;
            double ext_min_y = min_y - (max_y - min_y) * 0.05;
            double ext_max_y = max_y + (max_y - min_y) * 0.05;

            var cult = CultureInfo.InvariantCulture; // for dot decimal separator
            string query = $@"WITH envelope (box) AS (
                            VALUES(ST_MakeEnvelope({ext_min_x.ToString(cult)}, {ext_min_y.ToString(cult)}, {ext_max_x.ToString(cult)}, {ext_max_y.ToString(cult)}, 3857))
                        )
                        SELECT osm_id, ""addr:housename"", ""addr:housenumber"", 'polygon' as ""source"", building, admin_level, place, landuse, water, name, ST_AsEWKB(ST_ClipByBox2D(way, envelope.box)) as way, ST_AsText(ST_Centroid(way)) as centroid
                        FROM public.planet_osm_polygon CROSS JOIN envelope
                        WHERE ST_Intersects(way, envelope.box) AND ({z} < 15 AND ST_Area(way) > 5000 OR {z} >= 15)
                        UNION ALL
                        SELECT osm_id, ""addr:housename"", ""addr:housenumber"", 'roads' as ""source"", building, admin_level, place, landuse, water, name, ST_AsEWKB(ST_ClipByBox2D(way, envelope.box)) as way, ST_AsText(ST_Centroid(way)) as centroid
                        FROM public.planet_osm_roads CROSS JOIN envelope
                        WHERE ST_Intersects(way, envelope.box)
                        UNION ALL
                        SELECT osm_id, ""addr:housename"", ""addr:housenumber"", 'point' as ""source"", building, admin_level, place, landuse, water, name, ST_AsEWKB(ST_ClipByBox2D(way, envelope.box)) as way, ST_AsText(ST_Centroid(way)) as centroid
                        FROM public.planet_osm_point CROSS JOIN envelope
                        WHERE ST_Intersects(way, envelope.box) AND {z} >= 15
                        UNION ALL
                        SELECT osm_id, ""addr:housename"", ""addr:housenumber"", 'line' as ""source"", building, admin_level, place, landuse, water, name, ST_AsEWKB(ST_ClipByBox2D(way, envelope.box)) as way, ST_AsText(ST_Centroid(way)) as centroid
                        FROM public.planet_osm_line CROSS JOIN envelope
                        WHERE ST_Intersects(way, envelope.box)";

            VectorLayer inputLayer;

            using (var conn = new NpgsqlConnection(_dbConnectionString))
            {
                var dataSource = Drivers.PostGis
                    .FromQuery(query)
                    .GeometryField("way")
                    .AddAttribute("osm_id", AttributeDataType.Long)
                    .AddAttribute("addr:housenumber", AttributeDataType.String)
                    .AddAttribute("building", AttributeDataType.String)
                    .AddAttribute("name", AttributeDataType.String)
                    .AddAttribute("source", AttributeDataType.String)
                    .AddAttribute("admin_level", AttributeDataType.Integer)
                    .AddAttribute("place", AttributeDataType.String)
                    .AddAttribute("landuse", AttributeDataType.String)
                    .AddAttribute("water", AttributeDataType.String)
                    .AddAttribute("centroid", AttributeDataType.String)
                    .Build();

                conn.Open();

                inputLayer = await dataSource.ReadAsync(conn);
            }

            var adminAreas = inputLayer.WhereLinq(x => x.GetValue<string>("source") == "polygon" && !x.IsValueNull("admin_level"));
            var adminLayer8 = adminAreas.WhereLinq(x => x.GetValue<int>("admin_level") == 8);
            var adminLayer10 = adminAreas.WhereLinq(x => x.GetValue<int>("admin_level") == 10);
            var citiesLayer = inputLayer.WhereLinq(x => x.GetValue<string>("place") == "city");
            var forestLayer = inputLayer.WhereLinq(x => x.GetValue<string>("landuse") == "forest");
            var waterLayer = inputLayer.WhereLinq(x => !x.IsValueNull("water"));
            var pointsAndLinesLayer = inputLayer.WhereLinq(x =>
            {
                var src = x.GetValue<string>("source");
                return src == "roads" || src == "point" || src == "line";
            });
            var buildingsLayer = inputLayer.WhereLinq(x => x.GetValue<string>("source") == "polygon" && !x.IsValueNull("building"));

            var extent = new Extent(min_x, min_y, max_x, max_y, SpatialReferenceSystem.WebMercator);

            var polygonFilter = (Feature x) =>
            {
                var centroid = Geometry.FromText(x.GetValue<string>("centroid"), SpatialReferenceSystem.WebMercator);
                return x.GetValue<string>("source") == "polygon" && extent.Contains(centroid);
            };

            var polygonLabeling = new RuleBasedLabeling();
            polygonLabeling.Add(polygonFilter, new SimpleLabeling("addr:housenumber"));
            polygonLabeling.Add(polygonFilter, new SimpleLabeling("name"));

            using var map = new Map(256, 256);
            var pngStream = new MemoryStream();

            map.SpatialReferenceSystem = SpatialReferenceSystem.WebMercator;
            map.Extent = extent;
            map.Add(adminLayer8, new SimpleFill { FillColor = Color.WhiteSmoke }, polygonLabeling);
            map.Add(adminLayer10, new SimpleFill { FillColor = Color.PapayaWhip }, polygonLabeling);
            map.Add(citiesLayer, new SimpleFill { FillColor = Color.PeachPuff }, polygonLabeling);
            map.Add(forestLayer, new SimpleFill { FillColor = Color.PaleGreen }, polygonLabeling);
            map.Add(waterLayer, new SimpleFill { FillColor = Color.SkyBlue }, polygonLabeling);
            map.Add(pointsAndLinesLayer, null, new SimpleLabeling("name"));
            map.Add(buildingsLayer, new SimpleFill { FillColor = Color.SandyBrown }, polygonLabeling);
            map.Render(AbstractPath.FromStream(pngStream), Renderers.Png);
            pngStream.Seek(0, SeekOrigin.Begin);

            return File(pngStream, "image/png");
        }
    }
}
