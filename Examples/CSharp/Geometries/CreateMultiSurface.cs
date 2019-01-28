using Aspose.Gis;
using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class CreateMultiSurface
    {
        public static void Run()
        {
            //ExStart: CreateMultiSurface
            string path = RunExamples.GetDataDir() + "CreateMultiSurface.json";
            using (VectorLayer layer = VectorLayer.Create(path, Drivers.GeoJson))
            {
                var feature = layer.ConstructFeature();
                var multiSurface = new MultiSurface();

                var polygon = Geometry.FromText("Polygon ((0 0, 0 1, 1 1, 1 0, 0 0))");
                multiSurface.Add(polygon);

                var curvePolygon = Geometry.FromText("CurvePolygon (CircularString (-2 0, 0 2, 2 0, 0 -2, -2 0))");
                multiSurface.Add(curvePolygon);
                feature.Geometry = multiSurface;

                layer.Add(feature);
            }
            //ExEnd: CreateMultiSurface
        }
    }
}
