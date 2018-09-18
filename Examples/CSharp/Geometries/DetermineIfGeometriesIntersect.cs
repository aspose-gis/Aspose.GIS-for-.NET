using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class DetermineIfGeometriesIntersect
    {
        public static void Run()
        {
            //ExStart: DetermineIfGeometriesIntersect
            var geometry1 = new Polygon(new LinearRing(new[]
            {
                new Point(0, 0),
                new Point(0, 3),
                new Point(3, 3),
                new Point(3, 0),
                new Point(0, 0),
            }));

            var geometry2 = new Polygon(new LinearRing(new[]
            {
                new Point(1, 1),
                new Point(1, 4),
                new Point(4, 4),
                new Point(4, 1),
                new Point(1, 1),
            }));

            Console.WriteLine(geometry1.Intersects(geometry2)); // True
            Console.WriteLine(geometry2.Intersects(geometry1)); // True

            // 'Disjoint' is opposite to 'Intersects'
            Console.WriteLine(geometry1.Disjoint(geometry2)); // False
            //ExEnd: DetermineIfGeometriesIntersect
        }
    }
}
