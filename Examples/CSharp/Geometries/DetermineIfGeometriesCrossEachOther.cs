using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class DetermineIfGeometriesCrossEachOther
    {
        public static void Run()
        {
            //ExStart: DetermineIfGeometriesCrossEachOther
            var geometry1 = new LineString();
            geometry1.AddPoint(0, 0);
            geometry1.AddPoint(2, 2);

            var geometry2 = new LineString();
            geometry2.AddPoint(1, 1);
            geometry2.AddPoint(3, 3);

            Console.WriteLine(geometry1.Crosses(geometry2)); // False

            var geometry3 = new LineString();
            geometry3.AddPoint(0, 2);
            geometry3.AddPoint(2, 0);

            Console.WriteLine(geometry1.Crosses(geometry3)); // True
            //ExEnd: DetermineIfGeometriesCrossEachOther
        }
    }
}
