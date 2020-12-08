using System;
using System.IO;
using Aspose.Gis;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    public static class AbstractPathDemo
    {
        public static void Run()
        {
            Console.WriteLine($"Example: {nameof(ReadZipFiles)}");
            ReadZipFiles();
        }

        private static void ReadZipFiles()
        {
            var filesFolder = RunExamples.GetDataDir();
            var zipFilename = Path.Combine(filesFolder, "land_shp.zip");

            using (FileStream stream = new FileStream(zipFilename, FileMode.Open))
            {
                using (var zipPath = new ZipPath("land.shp", stream))
                {
                    using (var layer = Drivers.Shapefile.OpenLayer(zipPath))
                    {
                        Console.WriteLine(layer.SpatialReferenceSystem);
                        foreach (var feature in layer)
                        {
                            Console.WriteLine(feature.Geometry.AsText());
                        }
                    }
                }
            }
        }
    }
}