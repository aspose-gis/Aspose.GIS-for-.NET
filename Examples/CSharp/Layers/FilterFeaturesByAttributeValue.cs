using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class FilterFeaturesByAttributeValue
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();
            //ExStart: FilterFeaturesByAttributeValue
            using (VectorLayer layer = VectorLayer.Open(dataDir + "InputShapeFile.shp", Drivers.Shapefile))
            {
                // all features with the date value in the attribute "dob" later than 1982-01-01.
                foreach (Feature feature in layer.WhereGreater("dob", new DateTime(1982, 1, 1, 0, 0, 0)))
                {
                    Console.WriteLine(feature.GetValue<DateTime>("dob").ToShortDateString());
                }
            }
            //ExEnd: FilterFeaturesByAttributeValue
        }
    }
}
