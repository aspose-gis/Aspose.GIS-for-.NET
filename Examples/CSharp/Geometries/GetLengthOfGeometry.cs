using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class GetLengthOfGeometry
    {
        public static void Run()
        {
            //ExStart: GetLengthOfGeometry
            var line = new LineString();
            line.AddPoint(0, 0);
            line.AddPoint(2, 2);
            line.AddPoint(2, 0);

            Console.WriteLine("{0:F}", line.GetLength()); // 4.83

            var rectangle = new Polygon(new LinearRing(new[]
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(1, 1),
                new Point(1, 0),
                new Point(0, 0),

            }));

            // GetLength() returns perimeter for polygons
            Console.WriteLine("{0:F}", rectangle.GetLength()); // 4.00
            //ExEnd: GetLengthOfGeometry
        }
    }
}
