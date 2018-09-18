using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class DetermineIfOneGeometryContainsAnother
    {
        public static void Run()
        {
            //ExStart: DetermineIfOneGeometryContainsAnother
            var geometry1 = new Polygon();
            geometry1.ExteriorRing = new LinearRing(new[]
            {
                new Point(0, 0),
                new Point(0, 4),
                new Point(4, 4),
                new Point(4, 0),
                new Point(0, 0),
            });
            geometry1.AddInteriorRing(new LinearRing(new[]
            {
                new Point(1, 1),
                new Point(1, 3),
                new Point(3, 3),
                new Point(3, 1),
                new Point(1, 1),
            }));

            var geometry2 = new Point(2, 2);

            Console.WriteLine(geometry1.SpatiallyContains(geometry2)); // False

            var geometry3 = new Point(0.5, 0.5);
            Console.WriteLine(geometry1.SpatiallyContains(geometry3)); // True

            // 'a.SpatiallyContains(b)' equals to 'b.Within(a)'
            Console.WriteLine(geometry3.Within(geometry1)); // True
            //ExEnd: DetermineIfOneGeometryContainsAnother
        }
    }
}
