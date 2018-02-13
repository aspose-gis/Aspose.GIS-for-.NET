using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class CreatePolygon
    {
        public static void Run()
        {
            //ExStart: CreatePolygon
            Polygon polygon = new Polygon();

            LinearRing ring = new LinearRing();
            ring.AddPoint(50.02, 36.22);
            ring.AddPoint(49.99, 36.26);
            ring.AddPoint(49.97, 36.23);
            ring.AddPoint(49.98, 36.17);
            ring.AddPoint(50.02, 36.22);

            polygon.ExteriorRing = ring;
            //ExEnd: CreatePolygon
        }
    }
}
