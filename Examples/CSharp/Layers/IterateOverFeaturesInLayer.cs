using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class IterateOverFeaturesInLayer
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir(); 

            //ExStart: IterateOverFeaturesInLayer
            using (VectorLayer layer = VectorLayer.Open(dataDir + "InputShapeFile.shp", Drivers.Shapefile))
            {
                foreach (Feature feature in layer)
                {
                    Console.WriteLine(feature.Geometry.AsText());
                }
            }
            //ExEnd: IterateOverFeaturesInLayer
        }
    }
}
