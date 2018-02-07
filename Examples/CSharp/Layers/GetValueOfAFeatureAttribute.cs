using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class GetValueOfAFeatureAttribute
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();

            //ExStart: GetValueOfAFeatureAttribute
            using (VectorLayer layer = VectorLayer.Open(dataDir + "InputShapeFile.shp", Drivers.Shapefile))
            {
                for (int i = 0; i < layer.Count; i++)
                {
                    Feature feature = layer[i];
                    string nameValue = feature.GetValue<string>("name"); // attribute name is case-sensitive
                    int ageValue = feature.GetValue<int>("age");
                    string dobValue = feature.GetValue<DateTime>("dob").ToString();
                    Console.WriteLine("Entry {0} information\n ========================", i);
                    Console.WriteLine("Attribute value for feature #{0} is: {1}, {2}", nameValue, ageValue, dobValue);
                }
            }
            //ExEnd: GetValueOfAFeatureAttribute
        }
    }
}
