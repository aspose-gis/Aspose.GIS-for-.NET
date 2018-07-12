using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    class CreateKMLFile
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();

            //ExStart: CreateKMLFile
            using (var layer = Drivers.Kml.CreateLayer(dataDir + "Kml_File.kml"))
            {
                layer.Attributes.Add(new FeatureAttribute("string_data", AttributeDataType.String));
                layer.Attributes.Add(new FeatureAttribute("int_data", AttributeDataType.Integer));
                layer.Attributes.Add(new FeatureAttribute("bool_data", AttributeDataType.Boolean));
                layer.Attributes.Add(new FeatureAttribute("float_data", AttributeDataType.Double));

                Feature feature = layer.ConstructFeature();
                feature.SetValue("string_data", "string value");
                feature.SetValue("int_data", 10);
                feature.SetValue("bool_data", true);
                feature.SetValue("float_data", 3.14);
                feature.Geometry = new LineString(new[] { new Point(0, 0), new Point(1, 1) });

                layer.Add(feature);

                Feature feature2 = layer.ConstructFeature();
                feature2.SetValue("string_data", "string value2");
                feature2.SetValue("int_data", 100);
                feature2.SetValue("bool_data", false);
                feature2.SetValue("float_data", 3.1415);
                feature2.Geometry = Geometry.Null;

                layer.Add(feature2);
            }
            //ExEnd: CreateKMLFile
        }
    }
}
