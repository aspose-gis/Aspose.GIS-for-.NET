using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo.Viewer.WPF
{
    internal class GeometryProvider
    {

        /// <summary>
        /// Returns a geometry object of a single point made using preset values
        /// </summary>
        public IGeometry PrimitivePoint()
        {
            return Aspose.Gis.Geometries.Geometry.FromText("POINT(30 10)");
        }
        /// <summary>
        /// Returns a geometry object of Linestring type made with a WKT string using preset values
        /// </summary>
        public IGeometry PrimitiveLinestring()
        {
            return Aspose.Gis.Geometries.Geometry.FromText("LINESTRING(30 10, 10 30, 40 40)");
        }
        /// <summary>
        /// Returns a geometry object of Polygon type made with a WKT string using preset values
        /// </summary>
        public IGeometry PrimitivePolygon()
        {
            return Aspose.Gis.Geometries.Geometry.FromText("POLYGON((30 10, 40 40, 20 40, 10 20, 30 10))");
        }
        /// <summary>
        /// Returns a geometry object of the Polygon type with an inner circle made using preset values
        /// </summary>
        public IGeometry PrimitivePolygonWithHole()
        {
            return Aspose.Gis.Geometries.Geometry.FromText("POLYGON((35 10, 45 45, 15 40, 10 20, 35 10),(20 30, 35 35, 30 20, 20 30))");
        }
        /// <summary>
        /// Returns a geometry object of multipul point made using preset values
        /// </summary>
        public IGeometry PrimitiveMultiPoint()
        {
            return Aspose.Gis.Geometries.Geometry.FromText("MULTIPOINT((10 40), (40 30), (20 20), (30 10))");
        }
        /// <summary>
        /// Returns a geometry object of Linestring multitype made with a WKT string using preset values
        /// </summary>
        public IGeometry PrimitiveMultiLineString()
        {
            return Aspose.Gis.Geometries.Geometry.FromText("MULTILINESTRING((10 10, 20 20, 10 40),(40 40, 30 30, 40 20, 30 10))");
        }
        /// <summary>
        /// Returns a geometry object of Polygon multitype made with a WKT string using preset values
        /// </summary>
        public IGeometry PrimitiveMultiPolygon()
        {
            return Aspose.Gis.Geometries.Geometry.FromText("MULTIPOLYGON (((30 20, 45 40, 10 40, 30 20)),((15 5, 40 10, 10 20, 5 10, 15 5)))");
        }
        /// <summary>
        /// Returns a geometry object of the Polygon multitype with an inner circle made using preset values
        /// </summary>
        public IGeometry PrimitiveMultiPolygonWithHole()
        {
            return Aspose.Gis.Geometries.Geometry.FromText("MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)),((20 35, 10 30, 10 10, 30 5, 45 20, 20 35),(30 20, 20 15, 20 25, 30 20)))");
        }
        /// <summary>
        /// Returns a geometry object of Polygon type made with a WKT string, formed according to the given parameters
        /// </summary>
        public IGeometry CreatePolygon(double length, double width)
        {
            //feature.Geometry = Geometry.FromText("POLYGON((0 0, 35 50, 70 0, 35 -50, 0 0))");
            return Geometry.FromText(string.Format("POLYGON((0 0, {0} {1}, {2} 0, {0} {3}, 0 0))", Math.Round(length / 2), Math.Round(width / 2), length, -Math.Round(width / 2)));
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
            for (int i = 0; i < count - 2; i++)
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
            foreach (var sub in coordinates.Split(','))
            {
                string[] items = sub.Split(',');
                try
                {
                    points.Add((Point)CreatePoint(double.Parse(items[0]), double.Parse(items[1])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + items.ToString());
                }
            }
            return points;
        }
    }
}
