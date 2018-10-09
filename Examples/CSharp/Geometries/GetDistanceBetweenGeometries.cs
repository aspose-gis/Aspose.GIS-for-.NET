using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class GetDistanceBetweenGeometries
    {
        public static void Run()
        {
            //ExStart: GetDistanceBetweenGeometries
            var polygon = new Polygon();
            polygon.ExteriorRing = new LinearRing(new[]
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(1, 1),
                new Point(1, 0),
                new Point(0, 0),
            });

            var line = new LineString();
            line.AddPoint(2, 0);
            line.AddPoint(1, 3);

            double distance = polygon.GetDistanceTo(line);
            Console.WriteLine(distance.ToString("F")); // 0.63
            //ExEnd: GetDistanceBetweenGeometries
        }
    }
}
