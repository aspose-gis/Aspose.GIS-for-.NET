using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class GetFeatureCountInLayer
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir() ;

            //ExStart: GetFeatureCountInLayer
            using (VectorLayer layer = VectorLayer.Open(dataDir + "InputShapeFile.shp", Drivers.Shapefile))
            {
                Console.WriteLine("Total Features in this file: " + layer.Count);
            }
            //ExEnd: GetFeatureCountInLayer
        }
    }
}
