using Aspose.Gis;
using Aspose.Gis.Formats.Shapefile;
using Aspose.GIS.Examples.CSharp;
using System.IO;

namespace Aspose.GIS_for.NET.Layers
{
    class ModifyFeatures
    {
        private static string dataDir;

        public static void Run()
        {
            dataDir = RunExamples.GetDataDir();

            ModifyFeaturesInSingleLayer();
            ModifyFeaturesInDataset();
        }

        private static void ModifyFeaturesInSingleLayer()
        {
            //ExStart: ModifyFeaturesInSingleLayer
            string sourcePath = Path.Combine(dataDir, "InputShapeFile.shp");
            string resultPath = Path.Combine(dataDir, "modified.shp");

            using (var source = VectorLayer.Open(sourcePath, Drivers.Shapefile))
            using (var result = VectorLayer.Create(resultPath,
                                                   Drivers.Shapefile,
                                                   new ShapefileOptions(),
                                                   source.SpatialReferenceSystem))
            {
                result.CopyAttributes(source);

                foreach (var feature in source)
                {
                    // modify the geometry
                    var modifiedGeometry = feature.Geometry.GetBuffer(2.0);
                    feature.Geometry = modifiedGeometry;

                    // modify a feature attribute
                    var attributeValue = feature.GetValue<string>("name");
                    var modifiedAttributeValue = attributeValue.ToUpper();
                    feature.SetValue("name", modifiedAttributeValue);

                    result.Add(feature);
                }
            }

            //ExEnd: ModifyFeaturesInSingleLayer
        }

        private static void ModifyFeaturesInDataset()
        {
            //ExStart: ModifyFeaturesInDataset
            string path = Path.Combine(dataDir, "ThreeLayers.gdb");

            using (Dataset dataset = Dataset.Open(path, Drivers.FileGdb))
            {
                using (var source = dataset.OpenLayer("layer2"))
                using (var result = dataset.CreateLayer("modified", source.SpatialReferenceSystem))
                {
                    result.CopyAttributes(source);

                    foreach (var feature in source)
                    {
                        // modify the geometry
                        var modifiedGeometry = feature.Geometry.GetBuffer(2.0);
                        feature.Geometry = modifiedGeometry;

                        // modify a feature attribute
                        var attributeValue = feature.GetValue<double>("Value");
                        var modifiedAttributeValue = attributeValue * 2;
                        feature.SetValue("Value", modifiedAttributeValue);

                        result.Add(feature);
                    }
                }

                // optional: remove the source layer from the dataset
                dataset.RemoveLayer("layer2");
            }
            //ExEnd: ModifyFeaturesInDataset
        }
    }
}
