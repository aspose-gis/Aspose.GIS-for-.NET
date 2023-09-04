using Aspose.Gis.SpatialReferencing;
using System.Text;

namespace Geo.Coordinates.Transformation
{
    internal class ProjectPresenter
    {
        public string TransformAndReport()
        {
            var output = new StringBuilder();
            output.AppendLine("START").AppendLine();

            // Source and destination SRS
            var utm32N = SpatialReferenceSystem.CreateFromEpsg(32632);
            var latLong = SpatialReferenceSystem.CreateFromEpsg(4326);
            var transformation = utm32N.CreateTransformationTo(latLong);

            // Transform geometry
            var utmPoint = new Aspose.Gis.Geometries.Point(510000, 7042000);
            var geoPoint = transformation.Transform(utmPoint) as Aspose.Gis.Geometries.Point;

            // Write result
            output.AppendLine("UTM Easting: " + utmPoint.X);
            output.AppendLine("UTM Northing: " + utmPoint.Y);
            output.AppendLine("Longitude: " + geoPoint.X);
            output.AppendLine("Latitude: " + geoPoint.Y);

            output.AppendLine().AppendLine("OK");

            return output.ToString();
        }
    }
}
