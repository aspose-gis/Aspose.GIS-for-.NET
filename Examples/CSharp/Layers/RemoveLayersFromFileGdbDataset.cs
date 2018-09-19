using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    class RemoveLayersFromFileGdbDataset
    {
        public static void Run()
        {
            //ExStart: RemoveLayersFromFileGdbDataset
            // -- copy test dataset, to avoid modification of test data.

            //var datasetPath = GetOutputPath(".gdb");
            var path = RunExamples.GetDataDir() + "ThreeLayers.gdb";
            var datasetPath = RunExamples.GetDataDir() + "Working\\RemoveLayersFromFileGdbDataset.gdb";
            RunExamples.CopyDirectory(path, datasetPath);

            // --

            using (var dataset = Dataset.Open(datasetPath, Drivers.FileGdb))
            {
                Console.WriteLine(dataset.CanRemoveLayers); // True

                Console.WriteLine(dataset.LayersCount); // 3

                // remove layer by index
                dataset.RemoveLayerAt(2);
                Console.WriteLine(dataset.LayersCount); // 2

                // remove layer by name
                dataset.RemoveLayer("layer1");
                Console.WriteLine(dataset.LayersCount); // 1
            }
            //ExEnd: RemoveLayersFromFileGdbDataset
        }
    }
}
