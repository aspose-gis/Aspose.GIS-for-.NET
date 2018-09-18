using Aspose.Gis;
using Aspose.Gis.Formats.Shapefile;
using Aspose.Gis.Geometries;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    class LimitPrecisionWhenReadingGeometries
    {
        public static void Run()
        {
            //ExStart: LimitPrecisionWhenReadingGeometries
            string path = RunExamples.GetDataDir() + "LimitPrecisionWhenReadingGeometries.shp";
            using (VectorLayer layer = VectorLayer.Create(path, Drivers.Shapefile))
            {
                var feature = layer.ConstructFeature();
                feature.Geometry = new Point(1.10234, 2.09743);
                layer.Add(feature);
            }

            var options = new ShapefileOptions();
            // read data as-is.
            options.XYPrecisionModel = PrecisionModel.Exact;

            using (VectorLayer layer = VectorLayer.Open(path, Drivers.Shapefile, options))
            {
                var point = (IPoint)layer[0].Geometry;
                // 1.10234, 2.09743
                Console.WriteLine("{0}, {1}", point.X, point.Y);
            }

            // truncate all X and Y, so only two fractional digits are left.
            options.XYPrecisionModel = PrecisionModel.Rounding(2);

            using (VectorLayer layer = VectorLayer.Open(path, Drivers.Shapefile, options))
            {
                var point = (IPoint)layer[0].Geometry;
                // 1.1, 2.1
                Console.WriteLine("{0}, {1}", point.X, point.Y);
            }
            //ExEnd: LimitPrecisionWhenReadingGeometries
        }
    }
}
