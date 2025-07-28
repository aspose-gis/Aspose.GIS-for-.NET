using Aspose.Gis.Common;
using Aspose.Gis.Geometries;
using Aspose.Gis.Indexing.RTree;

namespace TrackRecordServer.Model
{
    public class Route
    {
        private LineString[] _routeSegments;
        private RTree _tree;

        public Route(LineString route)
        {
            _routeSegments = SplitIntoSegments(route).ToArray();
            _tree = RTree.OpenInMemory(3);

            var segmentCount = _routeSegments.Count();

            for (int i = 0; i < segmentCount; i++)
            {
                var extent = _routeSegments[i].GetExtent();
                var bbox = new BoundingRectangle(extent.XMin, extent.YMin, extent.XMax, extent.YMax);
                _tree.Insert(bbox, i);
            }
        }

        public double GetTotalLength()
        {
            double traveledDistance = 0.0;

            // We sum up the lengths of all previous segments
            for (int i = 0; i < _routeSegments.Length; i++)
            {
                traveledDistance += _routeSegments[i].GetLength();
            }

            // Add part of the current segment to the projection
            return traveledDistance;
        }

        public double DistanceTraveled(Point location, out PassableRouteSegment? passableSegment)
        {
            RouteSegment? segment = GetNearestSegments(location)
                .OrderBy(s => s.Line.GetDistanceTo(location))
                .FirstOrDefault();

            if (segment == null)
            {
                passableSegment = null;

                return 0.0; // If there is no suitable segment, return 0
            }

            // Extract the start and end of the nearest segment
            IPoint start = segment.Line[0];
            IPoint end = segment.Line[1];

            // Zero Segment Length Protection
            double denominator = (end.X - start.X) * (end.X - start.X)
                              + (end.Y - start.Y) * (end.Y - start.Y);
            double r;

            if (denominator < 1e-10)
            {
                r = 0.0;
            }
            else
            {
                r = ((location.X - start.X) * (end.X - start.X)
                   + (location.Y - start.Y) * (end.Y - start.Y)) / denominator;
            }


            // We limit r within [0,1] (guarantee correct projection)
            r = Math.Max(0, Math.Min(1, r));

            // Calculate the projection coordinates
            double projX = start.X + r * (end.X - start.X);
            double projY = start.Y + r * (end.Y - start.Y);
            Point projection = new Point(projX, projY);

            // Calculate the deviation (distance to the projection)
            double dx = location.X - projX;
            double dy = location.Y - projY;
            double lateralDeviation = Math.Sqrt(dx * dx + dy * dy);

            // Calculate the distance from the start of the route to the projection
            double traveledDistance = 0.0;

            // We sum up the lengths of all previous segments
            for (int i = 0; i < segment.Index; i++)
            {
                traveledDistance += _routeSegments[i].GetLength();
            }

            // Add part of the current segment to the projection
            traveledDistance += r * segment.Line.GetLength();

            passableSegment = new PassableRouteSegment(segment.Index, segment.Line, projection, lateralDeviation);

            return traveledDistance;
        }

        private IEnumerable<RouteSegment> GetNearestSegments(Point location)
        {
            var ids = _tree.NearestCandidateTo(new Coordinate(location.X, location.Y));
            var nearestSegments = new RouteSegment[ids.Count];

            for (int i = 0; i < ids.Count; i++)
            {
                nearestSegments[i] = new RouteSegment(ids[i], _routeSegments[ids[i]]);
            }

            return nearestSegments;
        }

        private static IEnumerable<LineString> SplitIntoSegments(LineString lineString)
        {
            if (lineString == null)
                throw new ArgumentNullException(nameof(lineString));

            // LineString requires at least 2 points
            if (lineString.Count < 2)
                yield break;

            // We go through all the points, starting from the second one
            for (int i = 1; i < lineString.Count; i++)
            {
                // Create a new segment
                var segment = new LineString();

                // Add two points: previous and current
                segment.AddPoint(lineString[i - 1]); // Beginning of the segment
                segment.AddPoint(lineString[i]);     // End of the segment

                // Set the coordinate system (coincides with the original)
                segment.SpatialReferenceSystem = lineString.SpatialReferenceSystem;

                yield return segment;
            }
        }
    }
}
