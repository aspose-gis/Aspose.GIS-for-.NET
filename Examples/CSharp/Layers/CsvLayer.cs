using System;
using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;

namespace Aspose.GIS_for.NET.Layers
{
    public class CsvLayer
    {
        public static void Run()
        {
            ReadCsvFeatures();
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
    }
}