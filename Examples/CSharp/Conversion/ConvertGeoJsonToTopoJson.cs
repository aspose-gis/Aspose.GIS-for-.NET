using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Conversion
{
    class ConvertGeoJsonToTopoJson
    {
        public static void Run()
        {
            //ExStart: ConvertGeoJsonToTopoJson
            string sampleGeoJsonPath = RunExamples.GetDataDir() + "sample.geojson";
            var outputFilePath = RunExamples.GetDataDir() + "convertedSample_out.topojson";
            VectorLayer.Convert(sampleGeoJsonPath, Drivers.GeoJson, outputFilePath, Drivers.TopoJson);
            //ExEnd: ConvertGeoJsonToTopoJson
        }
    }
}
