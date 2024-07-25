using Aspose.Gis.Formats.Database;
using Aspose.Gis;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Aspose.Gis.Rendering;
using System.Globalization;
using Aspose.Gis.SpatialReferencing;
using Aspose.Gis.Rendering.Labelings;
using Aspose.Gis.Rendering.Symbolizers;
using System.Drawing;

namespace Aspose.GIS.TilesTest.Controllers
{
    public class TilesController : Controller
    {
        private const double _halfOfWorld = 20037508.34;

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
                        SELECT osm_id, ""addr:housename"", ""addr:housenumber"", 'polygon' as ""source"", building, admin_level, place, landuse, water, name, ST_AsEWKB(ST_ClipByBox2D(way, envelope.box)) as way
                        FROM public.planet_osm_polygon CROSS JOIN envelope
                        WHERE ST_Intersects(way, envelope.box) AND ({z} < 15 AND ST_Area(way) > 5000 OR {z} >= 15)
                        UNION ALL
                        SELECT osm_id, ""addr:housename"", ""addr:housenumber"", 'roads' as ""source"", building, admin_level, place, landuse, water, name, ST_AsEWKB(ST_ClipByBox2D(way, envelope.box)) as way
                        FROM public.planet_osm_roads CROSS JOIN envelope
                        WHERE ST_Intersects(way, envelope.box)
                        UNION ALL
                        SELECT osm_id, ""addr:housename"", ""addr:housenumber"", 'point' as ""source"", building, admin_level, place, landuse, water, name, ST_AsEWKB(ST_ClipByBox2D(way, envelope.box)) as way
                        FROM public.planet_osm_point CROSS JOIN envelope
                        WHERE ST_Intersects(way, envelope.box) AND {z} >= 15
                        UNION ALL
                        SELECT osm_id, ""addr:housename"", ""addr:housenumber"", 'line' as ""source"", building, admin_level, place, landuse, water, name, ST_AsEWKB(ST_ClipByBox2D(way, envelope.box)) as way
                        FROM public.planet_osm_line CROSS JOIN envelope
                        WHERE ST_Intersects(way, envelope.box)";

            VectorLayer adminLayer8;
            VectorLayer adminLayer10;
            VectorLayer buildingsLayer;
            VectorLayer pointsAndLinesLayer;
            VectorLayer citiesLayer;
            VectorLayer forestLayer;
            VectorLayer waterLayer;

            using (var conn = new NpgsqlConnection("Host=127.0.0.1;Username=gis;Password=password;Database=Hungary"))
            {
                var builder = new DatabaseDataSourceBuilder();

                builder
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
                    .AddAttribute("water", AttributeDataType.String);

                conn.Open();

                var inputLayer = await builder.Build().ReadAsync(conn);

                var adminAreas = inputLayer.Where(x => x.GetValue<string>("source") == "polygon" && !x.IsValueNull("admin_level"));

                var adminAreas10 = adminAreas.Where(x => x.GetValue<int>("admin_level") == 10);
                adminLayer10 = CopyToNewLayer(adminAreas10, inputLayer);

                var adminAreas8 = adminAreas.Where(x => x.GetValue<int>("admin_level") == 8);
                adminLayer8 = CopyToNewLayer(adminAreas8, inputLayer);

                var buildings = inputLayer.Where(x => x.GetValue<string>("source") == "polygon" && !x.IsValueNull("building"));
                buildingsLayer = CopyToNewLayer(buildings, inputLayer);

                var cities = inputLayer.Where(x => x.GetValue<string>("place") == "city");
                citiesLayer = CopyToNewLayer(cities, inputLayer);

                var forest = inputLayer.Where(x => x.GetValue<string>("landuse") == "forest");
                forestLayer = CopyToNewLayer(forest, inputLayer);

                var water = inputLayer.Where(x => !x.IsValueNull("water"));
                waterLayer = CopyToNewLayer(water, inputLayer);

                var pointsAndLines = inputLayer.Where(x =>
                {
                    var src = x.GetValue<string>("source");
                    return src == "roads" || src == "point" || src == "line";
                });
                
                pointsAndLinesLayer = CopyToNewLayer(pointsAndLines, inputLayer);
            }

            using var map = new Map(256, 256);
            var pngStream = new MemoryStream();
            var labeling = new RuleBasedLabeling
            {
                { x => x.GetValue<string>("source") == "polygon",  new SimpleLabeling("addr:housenumber")},
                LabelingRule.CreateElseRule(new SimpleLabeling("name"))
            };

            map.SpatialReferenceSystem = SpatialReferenceSystem.WebMercator;
            map.Extent = new Extent(min_x, min_y, max_x, max_y, SpatialReferenceSystem.WebMercator);            
            map.Add(adminLayer8, new SimpleFill { FillColor = Color.WhiteSmoke }, labeling);
            map.Add(adminLayer10, new SimpleFill { FillColor = Color.PapayaWhip }, labeling);
            map.Add(citiesLayer, new SimpleFill { FillColor = Color.PeachPuff }, labeling);
            map.Add(forestLayer, new SimpleFill { FillColor = Color.PaleGreen }, labeling);
            map.Add(waterLayer, new SimpleFill { FillColor = Color.SkyBlue }, labeling);
            map.Add(pointsAndLinesLayer, null, labeling);
            map.Add(buildingsLayer, new SimpleFill { FillColor = Color.SandyBrown }, labeling);
            map.Render(AbstractPath.FromStream(pngStream), Renderers.Png);
            pngStream.Seek(0, SeekOrigin.Begin);

            return File(pngStream, "image/png");
        }

        private VectorLayer CopyToNewLayer(IEnumerable<Feature> features, VectorLayer originalLayer)
        {
            var outputLayer = Drivers.InMemory.CreateLayer();
            outputLayer.CopyAttributes(originalLayer);

            foreach (Feature feature in features)
            {
                var outputFeature = outputLayer.ConstructFeature();
                outputFeature.Geometry = feature.Geometry.Clone();
                outputFeature.CopyValues(feature);
                outputLayer.Add(outputFeature);
            };

            return outputLayer;
        }
    }
}
