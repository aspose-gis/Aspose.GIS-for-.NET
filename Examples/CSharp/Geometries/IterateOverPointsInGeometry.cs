using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class IterateOverPointsInGeometry
    {
        public static void Run()
        {
            //ExStart: IterateOverPointsInGeometry
            LineString line = new LineString();
            line.AddPoint(78.65, -32.65);
            line.AddPoint(-98.65, 12.65);

            foreach (IPoint point in line)
            {
                Console.WriteLine(point.X + "," + point.Y);
            }
            //ExEnd: IterateOverPointsInGeometry
        }
    }
}
