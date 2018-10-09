using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class GetGeometryBuffer
    {
        public static void Run()
        {
            //ExStart: GetGeometryBuffer
            var line = new LineString();
            line.AddPoint(0, 0);
            line.AddPoint(3, 3);

            // buffer with positive distance contains all points whose distance to input geometry is less or equal to 'distance' argument.
            var lineBuffer = line.GetBuffer(distance: 1);

            Console.WriteLine(lineBuffer.SpatiallyContains(new Point(1, 2)));     // True
            Console.WriteLine(lineBuffer.SpatiallyContains(new Point(3.1, 3.1))); // True

            var polygon = new Polygon();
            polygon.ExteriorRing = new LinearRing(new[]
            {
                new Point(0, 0),
                new Point(0, 3),
                new Point(3, 3),
                new Point(3, 0),
                new Point(0, 0),
            });

            // buffer with negative distance 'shrinks' geometry.
            var polygonBuffer = (IPolygon)polygon.GetBuffer(distance: -1);

            // [0] = (1 1)
            // [1] = (1 2)
            // [2] = (2 2)
            // [3] = (2 1)
            // [4] = (1 1)
            var ring = polygonBuffer.ExteriorRing;
            for (int i = 0; i < ring.Count; ++i)
            {
                Console.WriteLine("[{0}] = ({1} {2})", i, ring[i].X, ring[i].Y);
            }
            //ExEnd: GetGeometryBuffer
        }
    }
}
