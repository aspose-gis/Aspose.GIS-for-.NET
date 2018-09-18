using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class ReducePrecisionOfAGeometry
    {
        public static void Run()
        {
            //ExStart: ReducePrecisionOfAGeometry
            Point point = new Point(1.344, 2.345, 3.345, 4.345);
            point.RoundXY(digits: 2);

            // 1.34, 2.35, 3.345, 4.345
            Console.WriteLine("{0}, {1}, {2}, {3}", point.X, point.Y, point.Z, point.M);

            point.RoundZ(digits: 1);

            // 1.34, 2.35, 3.3, 4.345
            Console.WriteLine("{0}, {1}, {2}, {3}", point.X, point.Y, point.Z, point.M);

            LineString line = new LineString();
            line.AddPoint(1.2, 2.3);
            line.AddPoint(2.4, 3.1);
            line.RoundXY(digits: 0);

            // 1, 2
            Console.WriteLine("{0}, {1}", line[0].X, line[0].Y);
            // 2, 3
            Console.WriteLine("{0}, {1}", line[1].X, line[1].Y);
            //ExEnd: ReducePrecisionOfAGeometry
        }
    }
}
