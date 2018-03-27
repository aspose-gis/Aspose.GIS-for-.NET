using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    class ReadFeaturesFromKML
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();

            //ExStart: ReadFeaturesFromKML
            using (var layer = Drivers.Kml.Open(dataDir + "Kml_File.kml"))
            {
                // get feratures count
                int count = layer.Count;

                // get feature at index 1
                Feature featureAtIndex1 = layer[0];

                Console.WriteLine(featureAtIndex1.GetValue<string>("string_data"));

                Feature featureAtIndex2 = layer[1];

                Console.WriteLine(featureAtIndex2.GetValue<string>("string_data"));
            }
            //ExEnd: ReadFeaturesFromKML
        }
    }
}
