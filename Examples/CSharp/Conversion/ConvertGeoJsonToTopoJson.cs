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
            string SampleGeoJsonPath = RunExamples.GetDataDir() + "sample.geojson";
            var outputFilePath = RunExamples.GetDataDir() + "convertedSample.topojson";
            VectorLayer.Convert(SampleGeoJsonPath, Drivers.GeoJson, outputFilePath, Drivers.TopoJson);
            //ExEnd: ConvertGeoJsonToTopoJson
        }
    }
}
