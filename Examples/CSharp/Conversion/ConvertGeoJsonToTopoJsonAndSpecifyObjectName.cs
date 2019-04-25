using Aspose.Gis;
using Aspose.Gis.Formats.TopoJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Conversion
{
    class ConvertGeoJsonToTopoJsonAndSpecifyObjectName
    {
        public static void Run()
        {
            //ExStart: ConvertGeoJsonToTopoJsonAndSpecifyObjectName
            string sampleGeoJsonPath = RunExamples.GetDataDir() + "sample.geojson";
            var outputFilePath = RunExamples.GetDataDir() + "convertedSampleWithObjectName_out.topojson";

            var options = new ConversionOptions
            {
                DestinationDriverOptions = new TopoJsonOptions
                {
                    // specify the name of the object where features should be written
                    DefaultObjectName = "name_of_the_object",
                }
            };
            VectorLayer.Convert(sampleGeoJsonPath, Drivers.GeoJson, outputFilePath, Drivers.TopoJson, options);
            //ExEnd: ConvertGeoJsonToTopoJsonAndSpecifyObjectName
        }
    }
}
