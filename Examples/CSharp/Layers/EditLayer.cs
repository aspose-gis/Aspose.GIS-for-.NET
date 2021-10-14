using System;
using System.IO;
using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using Aspose.Gis.Geometries;

namespace Aspose.GIS_for.NET.Layers
{
    public static class EditLayer
    {
        public static void Run()
        {
            UpdateFeatures();
        }

        private static void UpdateFeatures()
        {
            Console.WriteLine($"== Start Demo: {nameof(UpdateFeatures)}");
            var workFolder = RunExamples.GetDataDir();

            // arrange temp file
            CreateTempLayer(workFolder, "edit_me_out.kml");

            // ExStart: UpdateFeatures
            using (var layer = Drivers.Kml.EditLayer(Path.Combine(workFolder, "edit_me_out.kml")))
            {
                // add
                Feature featureToAdd = layer.ConstructFeature();
                featureToAdd.SetValue("string_field", "new_value");
                featureToAdd.Geometry = new Point(5, 5);
                layer.Add(featureToAdd);

                // update
                Feature featureToReplace = layer.ConstructFeature();
                featureToReplace.SetValue("string_field", "updated_value");
                featureToReplace.Geometry = new Point(12, 12);
                layer.ReplaceAt(1, featureToReplace);

                // remove
                layer.RemoveAt(0);
            }
            // ExEnd: UpdateFeatures

        }

        private static void CreateTempLayer(string workFolder, string filename)
        {
            using (var layer = Drivers.Kml.CreateLayer(Path.Combine(workFolder, filename)))
            {
                layer.Attributes.Add(new FeatureAttribute("string_field", AttributeDataType.String));

                for (int i = 0; i < 3; i++)
                {
                    Feature feature = layer.ConstructFeature();
                    feature.SetValue("string_field", $"value_{i}");
                    feature.Geometry = new LineString(new[] { new Point(0, 0), new Point(i, i) });

                    layer.Add(feature);
                }
            }
        }
    }
}