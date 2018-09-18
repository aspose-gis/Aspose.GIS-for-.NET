using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class DetermineSpatialRelationViaRelateMethod
    {
        public static void Run()
        {
            //ExStart: DetermineSpatialRelationViaRelateMethod
            var geometry1 = new LineString();
            geometry1.AddPoint(0, 0);
            geometry1.AddPoint(0, 2);

            var geometry2 = new LineString();
            geometry2.AddPoint(0, 1);
            geometry2.AddPoint(0, 3);

            // Relate method takes a string representation of DE-9IM matrix
            // (Dimensionally Extended Nine-Intersection Model matrix).
            // see Simple Feature Access specification for more details on DE-9IM.

            // this is the equivalent of 'geometry1.SpatiallyEquals(geometry2)'
            Console.WriteLine(geometry1.Relate(geometry2, "T*F**FFF*")); // False

            // this is the equivalent of 'geometry1.Disjoint(geometry2)'
            Console.WriteLine(geometry1.Relate(geometry2, "FF*FF****")); // False

            // this is the equivalent of 'geometry1.Overlaps(geometry2)'
            Console.WriteLine(geometry1.Relate(geometry2, "1*T***T**")); // True
            //ExEnd: DetermineSpatialRelationViaRelateMethod
        }
    }
}
