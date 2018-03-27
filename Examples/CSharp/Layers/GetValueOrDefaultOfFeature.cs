using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    public class GetValueOrDefaultOfFeature
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();

            File.Delete(dataDir + "data1_out.json");
            File.Delete(dataDir + "data2_out.json");

            //ExStart: GetValueOrDefaultOfFeature
            //You can set default value for a feature of attribute in a layer
            using (var layer = Drivers.GeoJson.Create(dataDir + "data1_out.json"))
            {
                var attribute = new FeatureAttribute("attribute", AttributeDataType.Integer);
                attribute.CanBeNull = true;
                attribute.CanBeUnset = true;

                layer.Attributes.Add(attribute);

                Feature feature = layer.ConstructFeature();
                int? value = feature.GetValueOrDefault<int?>("attribute"); // value == null
                value = feature.GetValueOrDefault<int?>("attribute", 10); // value == 10
                Console.WriteLine(value);
            }

            //Another example where we set the default value to 100
            using (var layer = Drivers.GeoJson.Create(dataDir + "data2_out.json"))
            {
                var attribute = new FeatureAttribute("attribute", AttributeDataType.Double);
                attribute.CanBeNull = false;
                attribute.CanBeUnset = false;
                attribute.DefaultValue = 100;

                layer.Attributes.Add(attribute);

                Feature feature = layer.ConstructFeature();
                double value = feature.GetValueOrDefault<double>("attribute"); // value == 100
                feature.SetValue("attribute", 50);
                value = feature.GetValueOrDefault<double>("attribute"); // value == 50
            }
            //ExEnd: GetValueOrDefaultOfFeature
        }
    }
}
