using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class GetAreaOfGeometry
    {
        public static void Run()
        {
            //ExStart: GetAreaOfGeometry
            var triangleRing = new LinearRing();
            triangleRing.AddPoint(4, 6);
            triangleRing.AddPoint(1, 3);
            triangleRing.AddPoint(8, 7);
            triangleRing.AddPoint(4, 6);
            var triangle = new Polygon(triangleRing);

            var squareRing = new LinearRing();
            squareRing.AddPoint(0, 9);
            squareRing.AddPoint(0, 7);
            squareRing.AddPoint(2, 7);
            squareRing.AddPoint(2, 9);
            squareRing.AddPoint(0, 9);
            var square = new Polygon(squareRing);

            var multiPolygon = new MultiPolygon { triangle, square };

            Console.WriteLine("{0:F}", triangle.GetArea());     // 4.50
            Console.WriteLine("{0:F}", square.GetArea());       // 4.00
            Console.WriteLine("{0:F}", multiPolygon.GetArea()); // 8.50
            //ExEnd: GetAreaOfGeometry
        }
    }
}
