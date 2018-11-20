using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class TranslateGeometryFromWkt
    {
        public static void Run()
        {
            //ExStart: TranslateGeometryFromWkt
            ILineString line = (ILineString)Geometry.FromText("LINESTRING Z (0.1 0.2 0.3, 1 2 1, 12 23 2)");
            Console.WriteLine(line.Count); // 3
            //ExEnd: TranslateGeometryFromWkt
        }
    }
}
