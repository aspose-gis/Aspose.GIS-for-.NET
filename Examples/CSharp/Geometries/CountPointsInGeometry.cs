using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class CountPointsInGeometry
    {
        public static void Run()
        {
            //ExStart: CountPointsInGeometry
            LineString line = new LineString();
            line.AddPoint(78.65, -32.65);
            line.AddPoint(-98.65, 12.65);
            int pointsCount = line.Count;

            Console.WriteLine(pointsCount);  // 2
            //ExEnd: CountPointsInGeometry
        }
    }
}
