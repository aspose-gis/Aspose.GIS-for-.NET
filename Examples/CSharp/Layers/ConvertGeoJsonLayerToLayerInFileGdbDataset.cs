using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    class ConvertGeoJsonLayerToLayerInFileGdbDataset
    {
        public static void Run()
        {
            //ExStart: ConvertGeoJsonLayerToLayerInFileGdbDataset
            var geoJsonPath = RunExamples.GetDataDir() + "ConvertGeoJsonLayerToLayerInFileGdbDataset_out.json";
            using (VectorLayer layer = VectorLayer.Create(geoJsonPath, Drivers.GeoJson))
            {
                layer.Attributes.Add(new FeatureAttribute("name", AttributeDataType.String));
                layer.Attributes.Add(new FeatureAttribute("age", AttributeDataType.Integer));

                Feature firstFeature = layer.ConstructFeature();
                firstFeature.Geometry = new Point(33.97, -118.25);
                firstFeature.SetValue("name", "John");
                firstFeature.SetValue("age", 23);
                layer.Add(firstFeature);

                Feature secondFeature = layer.ConstructFeature();
                secondFeature.Geometry = new Point(35.81, -96.28);
                secondFeature.SetValue("name", "Mary");
                secondFeature.SetValue("age", 54);
                layer.Add(secondFeature);
            }

            // --

            // -- copy test dataset, to avoid modification of test data.
            
            var sourceFile = RunExamples.GetDataDir() + "ThreeLayers.gdb";
            var destinationFile = RunExamples.GetDataDir() + "ThreeLayersCopy_out.gdb";
            RunExamples.CopyDirectory(sourceFile, destinationFile);

            // --

            using (var geoJsonLayer = VectorLayer.Open(geoJsonPath, Drivers.GeoJson))
            {
                using (var fileGdbDataset = Dataset.Open(destinationFile, Drivers.FileGdb))
                using (var fileGdbLayer = fileGdbDataset.CreateLayer("new_layer", SpatialReferenceSystem.Wgs84))
                {
                    fileGdbLayer.CopyAttributes(geoJsonLayer);
                    foreach (var feature in geoJsonLayer)
                    {
                        fileGdbLayer.Add(feature);
                    }
                }
            }
            //ExEnd: ConvertGeoJsonLayerToLayerInFileGdbDataset
        }
    }
}
