using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Drawing;
using System.Threading;
using Aspose.Gis.Formats.Kml;
using Aspose.Gis.Formats.Kml.Styles;
using Aspose.Gis.Geometries;
using Point = Aspose.Gis.Geometries.Point;

namespace Aspose.GIS_for.NET.Layers
{
    class KmlLayer
    {
        public static void Run()
        {
            CreateKmlFile();
            ReadFeaturesFromKml();
            ReadFeaturesFromInvalidKml();
            ExportStylePropertiesToKml();
        }

        public static void CreateKmlFile()
        {
            Console.WriteLine($"== Start Demo: {nameof(CreateKmlFile)}");
            string dataDir = RunExamples.GetDataDir();

            //ExStart: CreateKmlFile
            using (var layer = Drivers.Kml.CreateLayer(dataDir + "Kml_File_out.kml"))
            {
                layer.Attributes.Add(new FeatureAttribute("string_data", AttributeDataType.String));
                layer.Attributes.Add(new FeatureAttribute("int_data", AttributeDataType.Integer));
                layer.Attributes.Add(new FeatureAttribute("bool_data", AttributeDataType.Boolean));
                layer.Attributes.Add(new FeatureAttribute("float_data", AttributeDataType.Double));

                Feature feature = layer.ConstructFeature();
                feature.SetValue("string_data", "string value");
                feature.SetValue("int_data", 10);
                feature.SetValue("bool_data", true);
                feature.SetValue("float_data", 3.14);
                feature.Geometry = new LineString(new[] { new Point(0, 0), new Point(1, 1) });

                layer.Add(feature);

                Feature feature2 = layer.ConstructFeature();
                feature2.SetValue("string_data", "string value2");
                feature2.SetValue("int_data", 100);
                feature2.SetValue("bool_data", false);
                feature2.SetValue("float_data", 3.1415);
                feature2.Geometry = Geometry.Null;

                layer.Add(feature2);
            }
            //ExEnd: CreateKmlFile
        }

        private static void ReadFeaturesFromKml()
        {
            Console.WriteLine($"== Start Demo: {nameof(ReadFeaturesFromKml)}");
            string dataDir = RunExamples.GetDataDir();

            //ExStart: ReadFeaturesFromKml
            using (var layer = Drivers.Kml.OpenLayer(dataDir + "kml_file.kml"))
            {
                // get feratures count
                int count = layer.Count;

                // get feature at index 1
                Feature featureAtIndex1 = layer[0];

                Console.WriteLine(featureAtIndex1.GetValue<string>("string_data"));

                Feature featureAtIndex2 = layer[1];

                Console.WriteLine(featureAtIndex2.GetValue<string>("string_data"));
            }

            //ExEnd: ReadFeaturesFromKml
        }

        private static void ReadFeaturesFromInvalidKml()
        {
            Console.WriteLine($"== Start Demo: {nameof(ReadFeaturesFromInvalidKml)}");

            string dataDir = RunExamples.GetDataDir();

            //ExStart: ReadFeaturesFromInvalidKml
            var path = dataDir + "kml_invalid_chars.kml";
            using (var layer = Drivers.Kml.OpenLayer(path, new KmlOptions() { SymbolToReplaceInvalidChars = '_' } ))
            {
                foreach (var feature in layer)
                {
                    Console.WriteLine(feature.GetValue("name"));
                    Console.WriteLine(feature.GetValue("description"));
                }
            }

            //ExEnd: ReadFeaturesFromInvalidKml
        }

        public static void ExportStylePropertiesToKml()
        {
            Console.WriteLine($"== Start Demo: {nameof(ExportStylePropertiesToKml)}");

            string dataDir = RunExamples.GetDataDir();

            //ExStart: ExportStylePropertiesToKml
            using (var layer = Drivers.Kml.CreateLayer(dataDir + "Kml_Styles_out.kml"))
            {
                var style = new KmlFeatureStyle
                {
                    Line = new KmlLineStyle() { Width = 2.0 },
                    Polygon = new KmlPolygonStyle() { Outline = false },
                    Icon = new KmlIconStyle() { Resource = new KmlIconResource() { Href = "url" } },
                    Label = new KmlLabelStyle() { Color = Color.Green },
                    Balloon = new KmlBalloonStyle() { BackgroundColor = Color.Aqua, Text = "Example" },
                    List = new KmlListStyle() { ItemType = KmlItemTypes.RadioFolder },
                };

                Feature feature = layer.ConstructFeature();
                feature.Geometry = new LineString(new[] { new Point(0, 0), new Point(1, 1) });
                layer.Add(feature, style);

                Feature feature2 = layer.ConstructFeature();
                feature2.Geometry = new Point(5, 5);

                layer.Add(feature2, style);
            }
            //ExEnd: ExportStylePropertiesToKml
        }
    }
}
