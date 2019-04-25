using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class ReadObjectIdFromFileGdbLayer
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();
            string path = dataDir + "test.gdb";
            //ExStart: ReadObjectIdFromFileGdbLayer
            using (var dataset = Dataset.Open(path, Drivers.FileGdb))
            using (var layer = dataset.OpenLayer("layer"))
            {
                foreach (var feature in layer)
                {
                    Console.WriteLine(feature.GetValue<int>("OBJECTID"));
                }
            }
            //ExEnd: ReadObjectIdFromFileGdbLayer
        }
    }
}
