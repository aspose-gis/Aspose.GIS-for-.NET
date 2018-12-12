using Aspose.Gis;
using Aspose.Gis.Formats.TopoJson;

namespace Aspose.GIS.Examples.CSharp.Conversion
{
    class ConvertGeoJsonToTopoJsonWithGroupingIntoObjects
    {
        public static void Run()
        {
            //ExStart: ConvertGeoJsonToTopoJsonWithGroupingIntoObjects
            string SampleGeoJsonPath = RunExamples.GetDataDir() + "sample.geojson";
            var outputFilePath = RunExamples.GetDataDir() + "convertedSample.topojson";

            var options = new ConversionOptions
            {
                DestinationDriverOptions = new TopoJsonOptions
                {
                    // we set the attribute in GeoJSON layer by which we are going to group into objects
                    ObjectNameAttribute = "group",
                    // if value of "group" is unknown for some feature it should be placed into object with name "unnamed".
                    DefaultObjectName = "unnamed",
                }
            };

            VectorLayer.Convert(SampleGeoJsonPath, Drivers.GeoJson, outputFilePath, Drivers.TopoJson, options);
            //ExEnd: ConvertGeoJsonToTopoJsonWithGroupingIntoObjects
        }
    }
}
