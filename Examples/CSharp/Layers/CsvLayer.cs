using System;
using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using Aspose.Gis.Formats.Csv;
using Aspose.Gis.Geometries;

namespace Aspose.GIS_for.NET.Layers
{
    public class CsvLayer
    {
        public static void Run()
        {
            ReadCsvFeatures();
            ReadCsvGeometryFromWkt();
            ReadCsvPoints();
            WriteCsvFeatures();
        }

        private static void ReadCsvFeatures()
        {
            Console.WriteLine($"== Start Demo: {nameof(ReadCsvFeatures)}");
            var dataDir = RunExamples.GetDataDir();

            //ExStart: ReadCsvFeatures
            using (var layer = Drivers.Csv.OpenLayer(dataDir + "sample.csv"))
            {
                // print attributes
                foreach (var attribute in layer.Attributes)
                {
                    Console.Write($"'{attribute.Name}' ");
                }
                Console.WriteLine();

                // print records
                foreach (var feature in layer)
                {
                    var dump = feature.GetValuesDump();
                    foreach (var item in dump)
                    {
                        Console.Write($"'{item}' ");
                    }
                    Console.WriteLine();
                }
            }
            //ExEnd: ReadCsvFeatures
        }

        private static void ReadCsvGeometryFromWkt()
        {
            Console.WriteLine($"== Start Demo: {nameof(ReadCsvGeometryFromWkt)}");
            var dataDir = RunExamples.GetDataDir();

            //ExStart: ReadCsvGeometryFromWkt
            using (var layer = Drivers.Csv.OpenLayer(dataDir + "geometries.csv",
                new CsvOptions()
                {
                    ColumnWkt = "geom_data"
                }))
            {
                // print geometry in wkt format
                foreach (var feature in layer)
                {
                    Console.Write($"'{feature.Geometry.AsText()}: ");
                    Console.WriteLine();
                }
            }
            //ExEnd: ReadCsvGeometryFromWkt
        }

        private static void ReadCsvPoints()
        {
            Console.WriteLine($"== Start Demo: {nameof(ReadCsvPoints)}");
            var dataDir = RunExamples.GetDataDir();

            //ExStart: ReadCsvPoints
            using (var layer = Drivers.Csv.OpenLayer(dataDir + "geometries.csv",
                new CsvOptions()
                {
                    ColumnX = "x" , 
                    ColumnY = "y",
                    ColumnZ = "z",
                    ColumnM = "m"
                }))
            {
                // print geometry in wkt format
                foreach (var feature in layer)
                {
                    Console.Write($"'{feature.Geometry.AsText()}: ");
                    Console.WriteLine();
                }
            }
            //ExEnd: ReadCsvPoints
        }

        private static void WriteCsvFeatures()
        {
            Console.WriteLine($"== Start Demo: {nameof(WriteCsvFeatures)}");
            var dataDir = RunExamples.GetDataDir();

            //ExStart: WriteCsvFeatures
            
            // apply a custom delimiter and a column for geometry.
            var options = new CsvOptions()
            {
                ColumnWkt = "geom_data", 
                Delimiter = ';'
            };

            // create a new CSV layer
            using (var layer = Drivers.Csv.CreateLayer(dataDir + "csv_out.csv", options))
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
            //ExEnd: WriteCsvFeatures
        }
    }
}