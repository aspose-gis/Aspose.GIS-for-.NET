using Aspose.Gis;
using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class CreateCurvePolygon
    {
        public static void Run()
        {
            //ExStart: CreateCurvePolygon
            string path = RunExamples.GetDataDir() + "CreateCurvePolygon.shp";
            using (VectorLayer layer = VectorLayer.Create(path, Drivers.Shapefile))
            {
                var feature = layer.ConstructFeature();
                // create a torus with center at (0,0), radius equal to 2 and hole radius equal to 1
                var curvePolygon = new CurvePolygon();

                var exterior = new CircularString();
                exterior.AddPoint(-2, 0);
                exterior.AddPoint(0, 2);
                exterior.AddPoint(2, 0);
                exterior.AddPoint(0, -2);
                exterior.AddPoint(-2, 0);

                curvePolygon.ExteriorRing = exterior;

                var interior = new CircularString();
                interior.AddPoint(-1, 0);
                interior.AddPoint(0, 1);
                interior.AddPoint(1, 0);
                interior.AddPoint(0, -1);
                interior.AddPoint(-1, 0);

                curvePolygon.AddInteriorRing(interior);
                feature.Geometry = curvePolygon;

                layer.Add(feature);
            }
            //ExEnd: CreateCurvePolygon
        }
    }
}
