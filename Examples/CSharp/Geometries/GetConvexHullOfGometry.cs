using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class GetConvexHullOfGometry
    {
        public static void Run()
        {
            //ExStart: GetConvexHullOfGometry
            var geometry = new MultiPoint
            {
                new Point(3, 2),
                new Point(0, 0),
                new Point(6, 5),
                new Point(5, 10),
                new Point(10, 0),
                new Point(8, 2),
                new Point(4, 3),
            };

            var convexHull = geometry.GetConvexHull();

            // [0] = (0 0)
            // [1] = (5 10)
            // [2] = (10 0)
            // [3] = (0 0)
            var ring = (ILinearRing)convexHull;
            for (int i = 0; i < ring.Count; ++i)
            {
                Console.WriteLine("[{0}] = ({1} {2})", i, ring[i].X, ring[i].Y);
            }
            //ExEnd: GetConvexHullOfGometry
        }
    }
}
