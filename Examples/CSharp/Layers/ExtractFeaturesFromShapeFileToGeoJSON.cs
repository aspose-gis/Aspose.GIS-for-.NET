using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class ExtractFeaturesFromShapeFileToGeoJSON
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();

            //ExStart: ExtractFeaturesFromShapeFileToGeoJSON
            using (VectorLayer inputLayer = VectorLayer.Open(dataDir + "InputShapeFile.shp", Drivers.Shapefile))
            {
                using (VectorLayer outputLayer = VectorLayer.Create(dataDir + "ExtractFeaturesFromShapeFileToGeoJSON_out.json", Drivers.GeoJson))
                {
                    outputLayer.CopyAttributes(inputLayer);
                    foreach (Feature inputFeature in inputLayer)
                    {
                        DateTime? date = inputFeature.GetValue<DateTime?>("dob");
                        if (date == null || date < new DateTime(1982, 1, 1))
                        {
                            continue;
                        }

                        //Construct a new feature
                        Feature outputFeature = outputLayer.ConstructFeature();
                        outputFeature.Geometry = inputFeature.Geometry;
                        outputFeature.CopyValues(inputFeature);
                        outputLayer.Add(outputFeature);
                    }
                }
            }
            //ExEnd: ExtractFeaturesFromShapeFileToGeoJSON
        }
    }
}
