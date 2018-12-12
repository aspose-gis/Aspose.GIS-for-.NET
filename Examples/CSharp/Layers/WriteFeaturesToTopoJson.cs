using Aspose.Gis;
using Aspose.Gis.Geometries;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class WriteFeaturesToTopoJson
    {
        public static void Run()
        {
            //ExStart: WriteFeaturesToTopoJson
            var outputPath = RunExamples.GetDataDir() + "sample.topojson";

            using (VectorLayer layer = VectorLayer.Create(outputPath, Drivers.TopoJson))
            {
                // add attributes that we are going to set
                layer.Attributes.Add(new FeatureAttribute("name", AttributeDataType.String));
                layer.Attributes.Add(new FeatureAttribute("measurement", AttributeDataType.Double));
                layer.Attributes.Add(new FeatureAttribute("id", AttributeDataType.Integer));

                var feature0 = layer.ConstructFeature();
                feature0.SetValue("name", "name_0");
                feature0.SetValue("measurement", 1.03);
                feature0.SetValue("id", 0);
                feature0.Geometry = new Point(1.3, 2.3);
                layer.Add(feature0);

                var feature1 = layer.ConstructFeature();
                feature1.SetValue("name", "name_1");
                feature1.SetValue("measurement", 10.03);
                feature1.SetValue("id", 1);
                feature1.Geometry = new Point(241.32, 23.2);
                layer.Add(feature1);
            }
            //ExEnd: WriteFeaturesToTopoJson
        }
    }
}
