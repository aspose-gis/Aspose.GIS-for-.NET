using Aspose.Gis;
using Aspose.Gis.Formats.GeoJson;
using Aspose.Gis.Geometries;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class LimitPrecisionWhenWritingGeometries
    {
        public static void Run()
        {
            //ExStart: LimitPrecisionWhenWritingGeometries
            var options = new GeoJsonOptions
            {
                // write only 3 fractional digits of X and Y coordinates.
                XYPrecisionModel = PrecisionModel.Rounding(3),

                // write all fractional digits of Z coordinate (the default, you don't have to specify it)
                ZPrecisionModel = PrecisionModel.Exact
            };

            var path = RunExamples.GetDataDir() + "LimitPrecisionWhenWritingGeometries.json";
            using (VectorLayer layer = VectorLayer.Create(path, Drivers.GeoJson, options))
            {
                var point = new Point();
                point.X = 1.8888888;
                point.Y = 1.00123;
                point.Z = 1.123456789;

                Feature feature = layer.ConstructFeature();
                feature.Geometry = point;
                layer.Add(feature);
            }

            using (VectorLayer layer = VectorLayer.Open(path, Drivers.GeoJson))
            {
                var point = (IPoint)layer[0].Geometry;

                // 1.889, 1.001, 1.123456789
                Console.WriteLine("{0}, {1}, {2}", point.X, point.Y, point.Z);
            }
            //ExEnd: LimitPrecisionWhenWritingGeometries
        }
    }
}
