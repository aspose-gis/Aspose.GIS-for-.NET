using Aspose.Gis;
using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class CreateCircularString
    {
        public static void Run()
        {
            //ExStart: CreateCircularString
            string path = RunExamples.GetDataDir() + "CreateCircularString_out.shp";
            using (VectorLayer layer = VectorLayer.Create(path, Drivers.Shapefile))
            {
                var feature = layer.ConstructFeature();
                // create a circle with center at (1,0) and radius 1.
                var circularString = new CircularString();
                circularString.AddPoint(0, 0);
                circularString.AddPoint(1, 1);
                circularString.AddPoint(2, 0);
                circularString.AddPoint(1, -1);
                circularString.AddPoint(0, 0);
                feature.Geometry = circularString;

                layer.Add(feature);
            }
            //ExEnd: CreateCircularString
        }
    }
}
