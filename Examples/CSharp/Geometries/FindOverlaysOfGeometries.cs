using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class FindOverlaysOfGeometries
    {
        public static void Run()
        {
            //ExStart: FindOverlaysOfGeometries
            // find intersection, union, difference and symmetric difference of two geometries.

            var polygon1 = new Polygon();
            polygon1.ExteriorRing = new LinearRing(new[]
            {
                 new Point(0, 0),
                 new Point(0, 2),
                 new Point(2, 2),
                 new Point(2, 0),
                 new Point(0, 0),
             });

            var polygon2 = new Polygon();
            polygon2.ExteriorRing = new LinearRing(new[]
            {
                new Point(1, 1),
                new Point(1, 3),
                new Point(3, 3),
                new Point(3, 1),
                new Point(1, 1),
            });

            var intersection = polygon1.Intersection(polygon2);
            Console.WriteLine("Intersection type is {0}", intersection.GeometryType); // Polygon
            PrintRing(((IPolygon)intersection).ExteriorRing);
            // [0] - (1 1)
            // [1] - (1 2)
            // [2] - (2 2)
            // [3] - (2 1)
            // [4] - (1 1)

            var union = polygon1.Union(polygon2);
            Console.WriteLine("Union type is {0}", union.GeometryType); // Polygon
            PrintRing(((IPolygon)union).ExteriorRing);
            // [0] - (0 0)
            // [1] - (0 2)
            // [2] - (1 2)
            // [3] - (1 3)
            // [4] - (3 3)
            // [5] - (3 1)
            // [6] - (2 1)
            // [7] - (2 0)
            // [8] - (0 0)

            var difference = polygon1.Difference(polygon2);
            Console.WriteLine("Difference type is {0}", difference.GeometryType); // Polygon
            PrintRing(((IPolygon)difference).ExteriorRing);
            // [0] - (0 0)
            // [1] - (0 2)
            // [2] - (1 2)
            // [3] - (1 1)
            // [4] - (2 1)
            // [5] - (2 0)
            // [6] - (0 0)

            var symDifference = polygon1.SymDifference(polygon2);
            Console.WriteLine("Symmetric Difference type is {0}", symDifference.GeometryType); // MultiPolygon
            var multiPolygon = (IMultiPolygon)symDifference;
            Console.WriteLine("Polygons count is {0}", multiPolygon.Count); // 2
            PrintRing(((IPolygon)multiPolygon[0]).ExteriorRing);
            // [0] - (0 0)
            // [1] - (0 2)
            // [2] - (1 2)
            // [3] - (1 1)
            // [4] - (2 1)
            // [5] - (2 0)
            // [6] - (0 0)
            PrintRing(((IPolygon)multiPolygon[1]).ExteriorRing);
            // [0] - (1 2)
            // [1] - (1 3)
            // [2] - (3 3)
            // [3] - (3 1)
            // [4] - (2 1)
            // [5] - (2 2)
            // [6] - (1 2)
            //ExEnd: FindOverlaysOfGeometries
        }

        private static void PrintRing(ILinearRing ring)
        {
            for (int i = 0; i < ring.Count; ++i)
            {
                Console.WriteLine("[{0}] = ({1} {2})", i, ring[i].X, ring[i].Y);
            }
            Console.WriteLine("");
        }
    }
}
