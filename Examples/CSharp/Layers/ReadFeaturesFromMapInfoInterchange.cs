using Aspose.Gis;
using System;
using System.IO;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class ReadFeaturesFromMapInfoInterchange
    {
        public static void Run()
        {
            //ExStart: ReadFeaturesFromMapInfoInterchange
            string dataDir = RunExamples.GetDataDir();
            using (var layer = Drivers.MapInfoInterchange.OpenLayer(Path.Combine(dataDir, "data.mif")))
            {
                Console.WriteLine($"Number of features is {layer.Count}.");

                var lastGeometry = layer[layer.Count - 1].Geometry;
                Console.WriteLine($"Last geometry is {lastGeometry.AsText()}.");

                foreach (Feature feature in layer)
                {
                    Console.WriteLine(feature.Geometry.AsText());
                }
            }
            //ExEnd: ReadFeaturesFromMapInfoInterchange
        }
    }
}
