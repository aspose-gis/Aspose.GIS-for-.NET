using System.Text;

namespace Geo.Epsg.Viewer
{
    internal class ProjectPresenter
    {
        public string ReadAndReport(string epsgValue)
        {
            var output = new StringBuilder();
            output.AppendLine("START").AppendLine();

            if (!string.IsNullOrEmpty(epsgValue) && IsTextNumeric(epsgValue))
            {
                output.AppendLine("ERROR: INVALID ENTRY VALUE");
                return output.ToString();
            }

            var status = Aspose.Gis.SpatialReferencing.SpatialReferenceSystem.TryCreateFromEpsg(int.Parse(epsgValue), out var referenceSystem);
            output.AppendLine("Is succesful: " + status.ToString());

            if (status)
            {
                output.AppendLine("WKT: " + referenceSystem.ExportToWkt());
                output.AppendLine("Datum: " + referenceSystem.GeographicDatum.ToString());
            }

            output.AppendLine().AppendLine("OK");
            return output.ToString();
        }
        private bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }
    }
}
