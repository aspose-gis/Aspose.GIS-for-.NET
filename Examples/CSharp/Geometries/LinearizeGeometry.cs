using Aspose.Gis;
using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class LinearizeGeometry
    {
        public static void Run()
        {
            //ExStart: LinearizeGeometry
            string path = RunExamples.GetDataDir() + "LinearizeGeometry_out.kml";
            using (var layer = Drivers.Kml.CreateLayer(path))
            {
                var feature = layer.ConstructFeature();
                var geometry = Geometry.FromText(@"GeometryCollection (LineString (0 0, 1 1, 2 0),CompoundCurve ((4 0, 5 1), CircularString (5 1, 6 2, 7 1)))");
                // creates linear geometry that approximates input geometry
                var linear = geometry.ToLinearGeometry();
                feature.Geometry = linear;

                layer.Add(feature);
            }
            //ExEnd: LinearizeGeometry
        }
    }
}
