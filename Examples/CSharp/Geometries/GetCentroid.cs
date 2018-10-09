using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class GetCentroid
    {
        public static void Run()
        {
            //ExStart: GetCentroid
            var polygon = new Polygon();
            polygon.ExteriorRing = new LinearRing(new[]
            {
                new Point(1, 0),
                new Point(2, 2),
                new Point(0, 4),
                new Point(5, 5),
                new Point(6, 1),
                new Point(1, 0),
            });

            IPoint centroid = polygon.GetCentroid();
            Console.WriteLine("{0:F} {1:F}", centroid.X, centroid.Y); // 3.33 2.58
            //ExEnd: GetCentroid
        }
    }
}
