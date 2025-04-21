using System;
#if USE_ASPOSE_DRAWING
using Aspose.Drawing;
#else
using System.Drawing;
#endif
using System.IO;
using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.Gis.Rendering;
using Aspose.Gis.Rendering.Symbolizers;
using Aspose.GIS.Examples.CSharp;
using Point = Aspose.Gis.Geometries.Point;

namespace Aspose.GIS_for.NET.Layers
{
    public class FilteringAndIndexing
    {
        private static readonly string DataDir = RunExamples.GetDataDir();

        public static void Run()
        {
            IterateFilteredFeatures();
            SaveFilteredFeaturesToLayer();
            FindFeatureNearestToPoint();
            FindFeaturesWithinExtent();
            RenderFilteredFeatures();
        }

        public static void FilterLayerByAttributeValue()
        {
            var citiesPath = DataDir + "points.geojson";

            //ExStart: FilterLayerByAttributeValue
            using (var layer = VectorLayer.Open(citiesPath, Drivers.GeoJson))
            {
                // Select features based on values of the attribute. This code enumerates all features in the layer
                // and selects all features that match a condition.
                var features = layer.WhereGreaterOrEqual("population", 2000).WhereSmaller("population", 5000);

                // Print results.
                Console.WriteLine("Cities where population >= 2000 and population < 5000:");
                foreach (var feature in features)
                {
                    var name = feature.GetValue<string>("name");
                    var population = feature.GetValue<int>("population");
                    Console.WriteLine(name + ", " + population);
                }
                Console.WriteLine();
            }
            //ExEnd: FilterLayerByAttributeValue
        }


        public static void IterateFilteredFeatures()
        {
            var citiesPath = DataDir + "points.geojson";

            //ExStart: IterateFilteredFeatures
            using (var layer = VectorLayer.Open(citiesPath, Drivers.GeoJson))
            {
                // Use attribute index to speed up search by 'population' attribute.
                // Aspose.GIS builds a new index if it doesn't exist, otherwise existing index is reused.
                // Any path can be used.
                var attributeIndexPath = Path.ChangeExtension(citiesPath, "population_out.ix");
                layer.UseAttributesIndex(attributeIndexPath, "population");

                // Select features based on values of the attribute. Since we use attribute index it is not necessary to
                // test all features of the layer and filtering time is reduced significantly.
                var towns = layer.WhereGreaterOrEqual("population", 2000).WhereSmaller("population", 5000);

                // Print results.
                Console.WriteLine("Cities where population >= 2000 and population < 5000:");
                foreach (var town in towns)
                {
                    var name = town.GetValue<string>("name");
                    var population = town.GetValue<int>("population");
                    Console.WriteLine(name + ", " + population);
                }
                Console.WriteLine();
            }
            //ExEnd: IterateFilteredFeatures
        }

        public static void SaveFilteredFeaturesToLayer()
        {
            var citiesPath = DataDir + "points.geojson";

            //ExStart: SaveFilteredFeaturesToLayer
            using (var layer = VectorLayer.Open(citiesPath, Drivers.GeoJson))
            {
                // Use attribute index to speed up search by 'population' attribute.
                var attributeIndexPath = Path.ChangeExtension(citiesPath, "population_out.ix");
                layer.UseAttributesIndex(attributeIndexPath, "population");

                // Save all features with population between 2000 and 5000 to the output file.
                layer.WhereGreaterOrEqual("population", 2000)
                    .WhereSmaller("population", 5000)
                    .SaveTo(DataDir + "towns_out.shp", Drivers.Shapefile);
            }
            //ExEnd: SaveFilteredFeaturesToLayer
        }

        public static void FindFeatureNearestToPoint()
        {
            var path = DataDir + "points.geojson";

            //ExStart: FindFeatureNearestToPoint
            using (var layer = VectorLayer.Open(path, Drivers.GeoJson))
            {
                // Use spatial index to speed up spatial queries.
                // Aspose.GIS builds a new index if it doesn't exist, otherwise existing index is reused.
                // Any path can be used.
                var spatialIndexPath = Path.ChangeExtension(path, ".spatial_out.ix");
                layer.UseSpatialIndex(spatialIndexPath);

                var point = new Point(12.30, 50.33);

                // Since we use spatial index, nearest-to finds the closest feature much faster.
                var nearest = layer.NearestTo(point);
                Console.WriteLine("City nearest to (12.30 50.33) is " + nearest.GetValue<string>("name"));
                Console.WriteLine();
            }
            //ExEnd: FindFeatureNearestToPoint
        }

        public static void FindFeaturesWithinExtent()
        {
            var path = DataDir + "points.geojson";

            //ExStart: FindFeaturesWithinExtent
            using (var layer = VectorLayer.Open(path, Drivers.GeoJson))
            {
                // Use spatial index to speed up 'WhereIntersects'.
                var spatialIndexPath = Path.ChangeExtension(path, ".spatial_out.ix");
                layer.UseSpatialIndex(spatialIndexPath);

                var polygon = Geometry.FromText("Polygon((12.30 50.33, 22.49 54.87, 21.92 42.53, 12.30 50.33))");
                var intersecting = layer.WhereIntersects(polygon);

                Console.WriteLine("Cities within " + polygon.AsText() + ":");
                foreach (var feature in intersecting)
                {
                    var name = feature.GetValue<string>("name");
                    var location = (IPoint) feature.Geometry;
                    Console.WriteLine($"{name} at ({location.X}, {location.Y})");
                }
                Console.WriteLine();
            }
            //ExEnd: FindFeaturesWithinExtent
        }

        public static void RenderFilteredFeatures()
        {
            var citiesPath = DataDir + "points.geojson";
            var outputPath = DataDir + "large_cities_out.svg";

            //ExStart: RenderFilteredFeatures
            using (var map = new Map(600, 400))
            using (var cities = VectorLayer.Open(citiesPath, Drivers.GeoJson))
            {
                map.Padding = 20;

                // Use attribute index to speed up search by 'population' attribute.
                var attributeIndexPath = Path.ChangeExtension(citiesPath, "population_out.ix");
                cities.UseAttributesIndex(attributeIndexPath, "population");

                // Render all cities with population greater than 2000.
                map.Add(cities.WhereGreater("population", 2000), new SimpleMarker { FillColor = Color.Red });
                map.Render(outputPath, Renderers.Svg);
            }
            //ExEnd: RenderFilteredFeatures
        }
    }
}
