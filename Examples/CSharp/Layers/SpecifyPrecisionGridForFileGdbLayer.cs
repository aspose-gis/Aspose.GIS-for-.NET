using Aspose.Gis;
using Aspose.Gis.Formats.FileGdb;
using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using System;
using System.Text;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class SpecifyPrecisionGridForFileGdbLayer
    {
        public static void Run()
        {
            //ExStart: SpecifyPrecisionGridForFileGdbLayer
            var path = RunExamples.GetDataDir() + "PrecisionGrid_out.gdb";
            using (var dataset = Dataset.Create(path, Drivers.FileGdb))
            {
                var options = new FileGdbOptions
                {
                    // specify coordinate precision grid parameters (origins and scales for coordinates)
                    CoordinatePrecisionGrid = new FileGdbCoordinatePrecisionGrid
                    {
                        // all our coordinates must be more than (-400, -400) point
                        XOrigin = -400,
                        YOrigin = -400,

                        // the write precision is 10 digits after the decimal point
                        XYScale = 1e10,

                        // M values are started at 0 and precision is 4 digits after the decimal point
                        MOrigin = 0,
                        MScale = 1e4,
                    },

                    // throw whenever an attempt to write coordinate that does not fit precision grid is detected
                    EnsureValidCoordinatesRange = true,
                };

                using (var layer = dataset.CreateLayer("layer_name", options, SpatialReferenceSystem.Wgs84))
                {
                    var feature = layer.ConstructFeature();
                    feature.Geometry = new Point(10, 20) { M = 10.1282 };
                    layer.Add(feature);

                    feature = layer.ConstructFeature();
                    // X == -410 is less than XOrigin, so an exception is thrown
                    feature.Geometry = new Point(-410, 0) { M = 20.2343 };
                    try
                    {
                        layer.Add(feature);
                    }
                    catch (GisException e)
                    {
                        Console.WriteLine(e.Message); // X value -410 is out of valid range.
                    }
                }
            }
            //ExEnd: SpecifyPrecisionGridForFileGdbLayer
        }
    }
}
