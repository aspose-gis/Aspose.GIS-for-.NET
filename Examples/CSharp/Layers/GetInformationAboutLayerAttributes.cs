using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class GetInformationAboutLayerAttributes
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();

            //ExStart: GetInformationAboutLayerAttributes
            using (VectorLayer layer = VectorLayer.Open(dataDir + "InputShapeFile.shp", Drivers.Shapefile))
            {
                Console.WriteLine("The layer has {0} attributes defined.\n", layer.Attributes.Count);
                foreach (FeatureAttribute attribute in layer.Attributes)
                {
                    Console.WriteLine("Name: {0}", attribute.Name);
                    Console.WriteLine("Data type: {0}", attribute.DataType);
                    Console.WriteLine("Can be null: {0}", attribute.CanBeNull);
                }
            }
            //ExEnd: GetInformationAboutLayerAttributes
        }
    }
}
