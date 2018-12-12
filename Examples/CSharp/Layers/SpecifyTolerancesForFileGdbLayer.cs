using Aspose.Gis;
using Aspose.Gis.Formats.FileGdb;
using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using System;
using System.Text;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class SpecifyTolerancesForFileGdbLayer
    {
        public static void Run()
        {
            //ExStart: SpecifyTolerancesForFileGdbLayer
            var path = RunExamples.GetDataDir() + "TolerancesForFileGdbLayer.gdb";
            using (var dataset = Dataset.Create(path, Drivers.FileGdb))
            {
                var options = new FileGdbOptions
                {
                    XYTolerance = 0.001,
                    ZTolerance = 0.1,
                    MTolerance = 0.1,
                };

                using (var layer = dataset.CreateLayer("layer_name", options))
                {
                    // layer is created with the provided tolerances and some ArcGIS features/tools will use it
                }
            }
            //ExEnd: SpecifyTolerancesForFileGdbLayer
        }
    }
}
