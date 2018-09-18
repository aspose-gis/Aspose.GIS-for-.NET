using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class DetermineIfGeometriesAreSpatiallyEqual
    {
        public static void Run()
        {
            //ExStart: DetermineIfGeometriesAreSpatiallyEqual
            var geometry1 = new MultiLineString
            {
                new LineString(new [] { new Point(0, 0), new Point(1, 1) }),
                new LineString(new [] { new Point(1, 1), new Point(2, 2) }),
            };

            var geometry2 = new LineString(new[]
            {
                new Point(0, 0), new Point(2, 2),
            });

            Console.WriteLine(geometry1.SpatiallyEquals(geometry2)); // True

            geometry2.AddPoint(3, 3);
            Console.WriteLine(geometry1.SpatiallyEquals(geometry2)); // False
            //ExEnd: DetermineIfGeometriesAreSpatiallyEqual
        }
    }
}
