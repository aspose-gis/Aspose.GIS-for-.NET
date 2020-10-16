using Aspose.Gis;
using Aspose.Gis.Formats.Shapefile;
using Aspose.GIS.Examples.CSharp;
using System.IO;
using Aspose.Gis.Geometries;

namespace Aspose.GIS_for.NET.Layers
{
    class ModifyFeatures
    {
        private static string dataDir;

        public static void Run()
        {
            dataDir = RunExamples.GetDataDir();

            AddFeaturesInExistShapeFile();
            ModifyFeaturesInSingleLayer();
            ModifyFeaturesInDataset();
        }

        private static void AddFeaturesInExistShapeFile()
        {
            // -- copy test files, to avoid modification of test data.
            var fromPath = Path.Combine(RunExamples.GetDataDir(), "point_xyz");
            var toPath = RunExamples.GetDataDir() + "point_xyz_out";
            RunExamples.CopyDirectory(fromPath, toPath);
            // --

            //ExStart: AddFeaturesInExistShapeFile
            string path = Path.Combine(dataDir, "point_xyz_out", "point_xyz.shp");

            using (var layer = Drivers.Shapefile.EditLayer(path))
            {
                var feature = layer.ConstructFeature();
                feature.SetValue<int>("ID", 5);
                feature.Geometry = new Point(-5, 5) {Z = 2};
                layer.Add(feature);
            }

            //ExEnd: AddFeaturesInExistShapeFile
        }

        private static void ModifyFeaturesInSingleLayer()
        {
            //ExStart: ModifyFeaturesInSingleLayer
            string sourcePath = Path.Combine(dataDir, "InputShapeFile.shp");
            string resultPath = Path.Combine(dataDir, "modified_out.shp");

            using (var source = VectorLayer.Open(sourcePath, Drivers.Shapefile))
            using (var result = VectorLayer.Create(resultPath,
                                                   Drivers.Shapefile,
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
            // -- copy test dataset, to avoid modification of test data.
            var path = Path.Combine(RunExamples.GetDataDir(), "ThreeLayers.gdb");
            var datasetPath = RunExamples.GetDataDir() + "ModifyFeaturesInDataset_out.gdb";
            RunExamples.CopyDirectory(path, datasetPath);
            // --

            //ExStart: ModifyFeaturesInDataset
            using (Dataset dataset = Dataset.Open(datasetPath, Drivers.FileGdb))
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
