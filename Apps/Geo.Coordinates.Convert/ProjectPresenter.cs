using Aspose.Gis;
using System.Text;

namespace Geo.Coordinates.Convert
{
    internal class ProjectPresenter
    {
        public string ConverAndReport()
        {
            var output = new StringBuilder();
            output.AppendLine("START").AppendLine();

            var decimalDegrees = GeoConvert.AsPointText(25.5, 45.5, PointFormats.DecimalDegrees);
            output.Append("DG: ").AppendLine(decimalDegrees);

            var degreeDecimalMinutes = GeoConvert.AsPointText(25.5, 45.5, PointFormats.DegreeDecimalMinutes);
            output.Append("DDM: ").AppendLine(degreeDecimalMinutes);

            var degreeMinutesSeconds = GeoConvert.AsPointText(25.5, 45.5, PointFormats.DegreeMinutesSeconds);
            output.Append("DMS: ").AppendLine(degreeMinutesSeconds);

            var geoRef = GeoConvert.AsPointText(25.5, 45.5, PointFormats.GeoRef);
            output.Append("GeoRef: ").AppendLine(geoRef);

            var mgrs = GeoConvert.AsPointText(25.5, 45.5, PointFormats.Mgrs);
            output.Append("Mgrs: ").AppendLine(mgrs);

            var usng = GeoConvert.AsPointText(25.5, 45.5, PointFormats.Usng);
            output.Append("Usng: ").AppendLine(usng);

            output.AppendLine();
            output.AppendLine("OK");

            return output.ToString();
        }
    }
}
