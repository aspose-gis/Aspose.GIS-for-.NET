using System;
using System.Drawing;
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
            BuildAttributeIndexToSpeedUpFiltering();
            FindFeatureNearestToPoint();
            FindFeaturesWithinExtent();
            SaveFilteredFeaturesToLayer();
            RenderFilteredFeatures();
            FilterFeaturesByAttributeValue();
        }

        public static void FilterFeaturesByAttributeValue()
        {
            //ExStart: FilterFeaturesByAttributeValue
            var path = DataDir + "temp_out.shp";
            // -- generate sample data
            var values = new (string name, int age)[]
            {
                ("Anna", 12),
                ("John", 15),
                ("Mary", 20),
                ("James", 10),
                ("Bob", 19),
                ("Fred", 1),
                ("Alex", 14),
            };
            using (var layer = VectorLayer.Create(path, Drivers.Shapefile))
            {
                layer.Attributes.Add(new FeatureAttribute("name", AttributeDataType.String));
                layer.Attributes.Add(new FeatureAttribute("age", AttributeDataType.Integer));
                foreach (var (name, age) in values)
                {
                    var feature = layer.ConstructFeature();
                    feature.SetValue("name", name);
                    feature.SetValue("age", age);
                    layer.Add(feature);
                }
            }
            // --

            using (var layer = VectorLayer.Open(path, Drivers.Shapefile))
            {
                // Use index files to speed up filtering by attribute's value.
                // Index is automatically created if it doesn't exist. Any path can be used.
                var nameIndexPath = Path.ChangeExtension(path, "name_out.ux");
                var ageIndexPath = Path.ChangeExtension(path, "age_out.ix");
                layer.UseAttributesIndex(nameIndexPath, "name");
                layer.UseAttributesIndex(ageIndexPath, "age");

                // Select features with 'age' in range [13, 19]
                var teens = layer.WhereGreater("age", 12).WhereSmallerOrEqual("age", 19);
                foreach (var feature in teens)
                {
                    Console.WriteLine(feature.GetValue<string>("name"));
                }

                // Select features with 'name' that starts with 'A' and 'age' greater than '12'.
                var firstInAlphabet = layer.WhereGreaterOrEqual("name", "A")
                                           .WhereSmaller("name", "B")
                                           .WhereGreater("age", 12);
                foreach (var feature in firstInAlphabet)
                {
                    Console.WriteLine(feature.GetValue<string>("name"));
                }
            }
            //ExEnd: FilterFeaturesByAttributeValue
        }

        private static void BuildAttributeIndexToSpeedUpFiltering()
        {
            var path = DataDir + "railroads.shp";

            //ExStart: BuildAttributeIndexToSpeedUpFiltering
            using (var layer = VectorLayer.Open(path, Drivers.Shapefile))
            {
                // Use index files to speed up filtering by attribute's value or spatial extent.
                var attributeIndexPath = Path.ChangeExtension(path, "sov_a3_out.ix");
                layer.UseAttributesIndex(attributeIndexPath, "sov_a3");
                var spatialIndexPath = Path.ChangeExtension(path, ".spatial_out.ix");
                layer.UseSpatialIndex(spatialIndexPath);
            }

            //ExEnd: BuildAttributeIndexToSpeedUpFiltering
        }

        public static void FindFeatureNearestToPoint()
        {
            var path = DataDir + "railroads.shp";

            //ExStart: FindFeatureNearestToPoint
            using (var layer = VectorLayer.Open(path, Drivers.Shapefile))
            {
                var point = new Point(-67, 45);
                var nearest = layer.NearestTo(point);
                Console.WriteLine(nearest.Geometry.AsText());
            }
            //ExEnd: FindFeatureNearestToPoint
        }

        public static void FindFeaturesWithinExtent()
        {
            var path = DataDir + "railroads.shp";

            //ExStart: FindFeaturesWithinExtent
            using (var layer = VectorLayer.Open(path, Drivers.Shapefile))
            {
                var polygon = Geometry.FromText("Polygon((-67 45, -60 40, -50 50, -67 45))");
                var intersecting = layer.WhereIntersects(polygon);
                Console.WriteLine("Features intersecting with polygon " + polygon.AsText());
                foreach (var feature in intersecting)
                {
                    Console.WriteLine(feature.Geometry.AsText());
                }
            }
            //ExEnd: FindFeaturesWithinExtent
        }


        public static void SaveFilteredFeaturesToLayer()
        {
            var path = DataDir + "railroads.shp";

            //ExStart: SaveFilteredFeaturesToLayer
            using (var layer = VectorLayer.Open(path, Drivers.Shapefile))
            {
                layer.WhereEqual("sov_a3", "USA").SaveTo(DataDir + "USA_railroads_out.shp", Drivers.Shapefile);
                layer.WhereEqual("sov_a3", "MEX").SaveTo(DataDir + "Mexican_railroads_out.shp", Drivers.Shapefile);
                layer.WhereEqual("sov_a3", "CAN").SaveTo(DataDir + "Candian_railroads_out.shp", Drivers.Shapefile);
                layer.WhereEqual("sov_a3", "CUB").SaveTo(DataDir + "Cubaniese_railroads_out.shp", Drivers.Shapefile);
            }
            //ExEnd: SaveFilteredFeaturesToLayer
        }

        public static void RenderFilteredFeatures()
        {
            var railroadsPath = DataDir + "railroads.shp";
            var outputPath = DataDir + "railroads_out.svg";

            //ExStart: RenderFilteredFeatures
            using (var map = new Map(600, 400))
            using (var railroads = VectorLayer.Open(railroadsPath, Drivers.Shapefile))
            {
                map.Add(railroads.WhereEqual("sov_a3", "USA"), new SimpleLine { Color = Color.Blue });
                map.Render(outputPath, Renderers.Svg);
            }
            //ExEnd: RenderFilteredFeatures
        }
    }
}
