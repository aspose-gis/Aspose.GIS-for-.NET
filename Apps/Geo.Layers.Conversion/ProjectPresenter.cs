using Aspose.Gis;
using System.IO;
using System.Text;

namespace Geo.Layers.Conversion
{
    internal class ProjectPresenter
    {
        public string ConvertAndReport()
        {
            var output = new StringBuilder();
            output.AppendLine("START");
            output.AppendLine("Convert from Geo JSON to KML");

            VectorLayer.Convert("data/sample.geojson", Drivers.GeoJson, "output.kml", Drivers.Kml);

            output.AppendLine("Result KML:");
            output.AppendLine(File.ReadAllText("output.kml"));


            output.AppendLine();
            output.AppendLine("OK");

            return output.ToString();
        }
    }
}
