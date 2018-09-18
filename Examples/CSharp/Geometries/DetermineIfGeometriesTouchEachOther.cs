using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class DetermineIfGeometriesTouchEachOther
    {
        public static void Run()
        {
            //ExStart: DetermineIfGeometriesTouchEachOther
            var geometry1 = new LineString();
            geometry1.AddPoint(0, 0);
            geometry1.AddPoint(2, 2);

            var geometry2 = new LineString();
            geometry2.AddPoint(2, 2);
            geometry2.AddPoint(3, 3);

            Console.WriteLine(geometry1.Touches(geometry2)); // True
            Console.WriteLine(geometry2.Touches(geometry1)); // True

            var geometry3 = new Point(2, 2);
            Console.WriteLine(geometry1.Touches(geometry3)); // True

            var geometry4 = new LineString();
            geometry4.AddPoint(1, 1);
            geometry4.AddPoint(4, 4);

            Console.WriteLine(geometry1.Touches(geometry4)); // False
            //ExEnd: DetermineIfGeometriesTouchEachOther
        }
    }
}
