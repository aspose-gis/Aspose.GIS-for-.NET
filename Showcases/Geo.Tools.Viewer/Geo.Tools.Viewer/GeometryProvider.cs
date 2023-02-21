using Aspose.Gis.Geometries;

namespace Geo.Tools.Viewer
{
    /// <summary>
    /// Creates geometry presets based on WKT strings and additional parameters
    /// </summary>
    public class GeometryProvider
    {
        /// <summary>
        /// Returns a geometry object of Polygon type made with a WKT string, formed according to the given parameters
        /// </summary>
        public IGeometry CreatePolygon(double length, double width)
        {
            //feature.Geometry = Geometry.FromText("POLYGON((0 0, 35 50, 70 0, 35 -50, 0 0))");
            return Aspose.Gis.Geometries.Geometry.FromText(string.Format("POLYGON((0 0, {0} {1}, {2} 0, {0} {3}, 0 0))", Math.Round(length / 2), Math.Round(width / 2), length, -Math.Round(width / 2)));
        }
        /// <summary>
        /// Returns a geometry object of the Polygon type with an inner circle located at the "offset" value from the border
        /// </summary>
        public IGeometry CreatePolygonWithHole(double length, double width, double offset)
        {
            Polygon polygon = new Polygon();

            LinearRing ring = new LinearRing();
            ring.AddPoint(0, 0);
            ring.AddPoint(length / 2, width / 2);
            ring.AddPoint(length, 0);
            ring.AddPoint(length / 2, -width / 2);
            ring.AddPoint(0, 0);

            LinearRing hole = new LinearRing();
            hole.AddPoint(offset, 0);
            hole.AddPoint(length / 2, width / 2 - offset);
            hole.AddPoint(length - offset, 0);
            hole.AddPoint(length / 2, -width / 2 + offset);
            hole.AddPoint(offset, 0);

            polygon.ExteriorRing = ring;
            polygon.AddInteriorRing(hole);
            return polygon;
        }
        /// <summary>
        /// Returns a geometry object of Polygon type formed as a diamond with one side missing as others equal to the passed parameters
        /// </summary>
        public IGeometry CreateUnclosedPolygon(double length, double width)
        {
            Polygon polygon = new Polygon();

            LinearRing ring = new LinearRing();
            ring.AddPoint(0, 0);
            ring.AddPoint(length / 2, width / 2);
            ring.AddPoint(length, 0);
            ring.AddPoint(length / 2, -width / 2);

            polygon.ExteriorRing = ring;
            return polygon;
        }
        /// <summary>
        /// Returns a geometry object of Polygon type formed as a hexagon with a side length equal to the passed value
        /// </summary>
        public IGeometry CreateHexagon(double length)
        {
            var hexagon = new Polygon();

            LinearRing ring = new LinearRing();
            var count = 8;
            for (int i = 0; i < count - 2; i++)
            {
                var angle = 2 * Math.PI * i / count;
                double y = length * Math.Sin(angle);
                double x = length * Math.Cos(angle);
                ring.AddPoint(x, y);
            }
            ring.AddPoint(length * Math.Cos(30 * (Math.PI / 180)), length * Math.Sin(30 * (Math.PI / 180)));
            hexagon.ExteriorRing = ring;
            return hexagon;
        }
        /// <summary>
        /// Returns a geometry object of Polygon type formed as a hexagon with one side missing as others equal to the passed value
        /// </summary>
        public IGeometry CreateUnclosedHexagon(double length)
        {
            var hexagon = new Polygon();

            LinearRing ring = new LinearRing();
            var count = 8;
            for(int i = 0; i < count - 2; i++)
            {
                var angle = 2 * Math.PI * i / count;
                double y = length * Math.Sin(angle);
                double x = length * Math.Cos(angle);
                ring.AddPoint(x, y);
            }
            hexagon.ExteriorRing = ring;
            return hexagon;
        }
        /// <summary>
        /// Returns a geometry object of a single point made using given coordinates and M value
        /// </summary>
        public IGeometry CreatePoint(double x, double y, double M = 40.3)
        {
            Point point = new Point(x, y) { M = M };
            return point;
        }
        /// <summary>
        /// Returns a geometry object of CircularString type made using points, formed according to the given parameters
        /// </summary>
        public IGeometry CreateCircularString(double radius)
        {
            var circularString = new CircularString();
            circularString.AddPoint(0, 0);
            circularString.AddPoint(radius, radius);
            circularString.AddPoint(radius * 2, 0);
            circularString.AddPoint(radius, -radius);
            circularString.AddPoint(0, 0);
            //return Aspose.Gis.Geometries.Geometry.FromText(string.Format("CIRCULARSTRING((0 0, {0} {0}, {1} 0, {0} {2}, 0 0))", radius, radius * 2, -radius));
            return circularString;
        }
        /// <summary>
        /// Returns a geometry object of LineString type being a line, connecting a given List of Points
        /// </summary>
        public IGeometry CreatePolyline(string coordinates)
        {
            List<Point> points = CreateListOfPoints(coordinates);
            LineString line = new LineString();
            foreach (var point in points)
                line.AddPoint(point);
            return line;
        }
        /// <summary>
        /// Forms a List of points using the correctly formatted string
        /// formating example:
        /// 0; 0, 30; 45, 30; 45, 60; 0, 60.001; 0.001, 60.001; 0, 60; 0.001, 90; 45
        /// General form:
        /// x; y, x1; y2,... xn; yn
        /// </summary>
        private List<Point> CreateListOfPoints(string coordinates)
        {
            var points = new List<Point>();
            foreach (var sub in coordinates.Split(", "))
            {
                string[] items = sub.Split("; ");
                try
                {
                    points.Add((Point)CreatePoint(double.Parse(items[0]), double.Parse(items[1])));
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message + items.ToString());
                }
            }
            return points;
        }
    }
}
