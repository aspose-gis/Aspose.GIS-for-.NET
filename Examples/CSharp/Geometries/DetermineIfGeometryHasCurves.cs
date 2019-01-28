using Aspose.Gis;
using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class DetermineIfGeometryHasCurves
    {
        public static void Run()
        {
            //ExStart: DetermineIfGeometryHasCurves
            var geometryWithoutCurves = Geometry.FromText(@"GeometryCollection (LineString (0 0, 1 1, 2 0),CompoundCurve ((4 0, 5 1), (5 1, 6 2, 7 1)))");
            // geometry does not contain circular string, so HasCurveGeometry returns false.
            Console.WriteLine(geometryWithoutCurves.HasCurveGeometry); // False

            var geometry = Geometry.FromText(@"GeometryCollection (LineString (0 0, 1 1, 2 0),CompoundCurve ((4 0, 5 1), CircularString (5 1, 6 2, 7 1)))");
            // geometry contains circular string, so HasCurveGeometry returns true.
            Console.WriteLine(geometry.HasCurveGeometry); // True
            //ExEnd: DetermineIfGeometryHasCurves
        }
    }
}
