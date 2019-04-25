using Aspose.Gis;
using System;
using System.Text;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class AccessFeaturesInTopoJson
    {
        public static void Run()
        {
            //ExStart: AccessFeaturesInTopoJson
            string sampleTopoJsonPath = RunExamples.GetDataDir() + "sample.topojson";
            StringBuilder builder = new StringBuilder();
            using (VectorLayer layer = VectorLayer.Open(sampleTopoJsonPath, Drivers.TopoJson))
            {
                foreach (Feature feature in layer)
                {
                    // get id property
                    int id = feature.GetValue<int>("id");

                    // get name of the object that contains this feature
                    string objectName = feature.GetValue<string>("topojson_object_name");

                    // get name attribute property, located inside 'properties' object
                    string name = feature.GetValue<string>("name");

                    // get geometry of the feature.
                    string geometry = feature.Geometry.AsText();

                    builder.AppendFormat("Feature with ID {0}:\n", id);
                    builder.AppendFormat("Object Name = {0}\n", objectName);
                    builder.AppendFormat("Name        = {0}\n", name);
                    builder.AppendFormat("Geometry    = {0}\n", geometry);
                }
            }

            Console.WriteLine("Output:");
            Console.WriteLine(builder.ToString());

            // Output:
            // Feature with ID 0:
            // Object Name = named_object_1
            // Name        = point_feature
            // Geometry    = POINT (102 0.5)
            // Feature with ID 1:
            // Object Name = named_object_1
            // Name        = line_feature
            // Geometry    = LINESTRING (102 0, 103 1, 104 0, 105 1)
            // Feature with ID 2:
            // Object Name = named_object_2
            // Name        = polygon_feature
            // Geometry    = POLYGON ((100 0, 100 1, 101 1, 101 0, 100 0))
            //ExEnd: AccessFeaturesInTopoJson
        }
    }
}
