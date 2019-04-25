using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Conversion
{
    class ConvertTopoJsonToGeoJson
    {
        public static void Run()
        {
            //ExStart: ConvertTopoJsonToGeoJson
            var sampleTopoJsonPath = RunExamples.GetDataDir() + "sample.topojson";
            var outputFilePath = RunExamples.GetDataDir() + "convertedSample_out.geojson";
            VectorLayer.Convert(sampleTopoJsonPath, Drivers.TopoJson, outputFilePath, Drivers.GeoJson);
            //ExEnd: ConvertTopoJsonToGeoJson
        }
    }
}
