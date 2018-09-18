using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class DetermineIfGeometriesOverlap
    {
        public static void Run()
        {
            //ExStart: DetermineIfGeometriesOverlap
            var geometry1 = new LineString();
            geometry1.AddPoint(0, 0);
            geometry1.AddPoint(0, 2);

            var geometry2 = new LineString();
            geometry2.AddPoint(0, 2);
            geometry2.AddPoint(0, 3);

            Console.WriteLine(geometry1.Overlaps(geometry2)); // False

            var geometry3 = new LineString();
            geometry3.AddPoint(0, 1);
            geometry3.AddPoint(0, 3);

            Console.WriteLine(geometry1.Overlaps(geometry3)); // True
            //ExEnd: DetermineIfGeometriesOverlap
        }
    }
}
