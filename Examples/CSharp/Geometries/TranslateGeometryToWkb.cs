using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class TranslateGeometryToWkb
    {
        public static void Run()
        {
            //ExStart: TranslateGeometryToWkb
            IGeometry geometry = Geometry.FromText("LINESTRING (1.2 3.4, 5.6 7.8)");
            byte[] wkb = geometry.AsBinary();
            //File.WriteAllBytes(Path.Combine(TestConfiguration.TestOutputPath, "file.wkb"), wkb);
            File.WriteAllBytes(Path.Combine(RunExamples.GetDataDir(), "WkbFile.wkb"), wkb);
            //ExEnd: TranslateGeometryToWkb
        }
    }
}
