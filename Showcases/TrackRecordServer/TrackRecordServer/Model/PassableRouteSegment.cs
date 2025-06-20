using Aspose.Gis.Geometries;

namespace TrackRecordServer.Model
{
    public class PassableRouteSegment
    {
        public PassableRouteSegment(int index, LineString line, Point projection, double lateralDeviation)
        {
            Index = index;
            Line = line;
            Projection = projection;
            LateralDeviation = lateralDeviation;
        }

        public int Index { get; }
        public LineString Line { get; }
        public Point Projection { get; }
        public double LateralDeviation { get; }
    }
}
