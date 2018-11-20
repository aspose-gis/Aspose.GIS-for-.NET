using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class TranslateGeometryFromWkb
    {
        public static void Run()
        {
            //ExStart: TranslateGeometryFromWkb
            string path = Path.Combine(RunExamples.GetDataDir(), "WkbFile.wkb");
            byte[] wkb = File.ReadAllBytes(path);
            IGeometry geometry = Geometry.FromBinary(wkb);
            Console.WriteLine(geometry.AsText()); // LINESTRING (1.2 3.4, 5.6 7.8)
            //ExEnd: TranslateGeometryFromWkb
        }
    }
}
