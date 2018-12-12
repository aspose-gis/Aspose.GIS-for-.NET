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
            string SampleTopoJsonPath = RunExamples.GetDataDir() + "sample.topojson";
            var outputFilePath = RunExamples.GetDataDir() + "convertedSample5.geojson";
            VectorLayer.Convert(SampleTopoJsonPath, Drivers.TopoJson, outputFilePath, Drivers.GeoJson);
            //ExEnd: ConvertTopoJsonToGeoJson
        }
    }
}
