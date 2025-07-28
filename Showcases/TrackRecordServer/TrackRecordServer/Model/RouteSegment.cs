using Aspose.Gis.Geometries;

namespace TrackRecordServer.Model
{
    internal class RouteSegment
    {
        public RouteSegment(int index, LineString line)
        {
            Index = index;
            Line = line;
        }

        public int Index { get; }

        public LineString Line { get; }
    }
}
