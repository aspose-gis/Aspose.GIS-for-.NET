using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Gis.Formats.FileGdb;
using Aspose.Gis.SpatialReferencing;

namespace Aspose.GIS_for.NET.Layers
{
    class CreateFileGdbDatasetWithSingleLayer
    {
        public static void Run()
        {
            //ExStart: CreateFileGdbDatasetWithSingleLayer
            var path = RunExamples.GetDataDir() + "CreateFileGdbDatasetWithSingleLayer_out.gdb";
            var options = new FileGdbOptions();
            using (var layer = VectorLayer.Create(path, Drivers.FileGdb, options, SpatialReferenceSystem.Wgs84))
            // this 'using' is equivalent to
            // using (var dataset = Dataset.Create(path, Drivers.FileGdb))
            // using (var layer = Dataset.CreateLayer("layer"))
            {
                var feature = layer.ConstructFeature();
                feature.Geometry = new LineString(new[]
                {
                    new Point(1, 2),
                    new Point(3, 4),
                });
                layer.Add(feature);
            }

            using (var dataset = Dataset.Open(path, Drivers.FileGdb))
            using (var layer = dataset.OpenLayer("layer"))
            {
                Console.WriteLine("Features count: {0}", layer.Count); // 1
            }
            //ExEnd: CreateFileGdbDatasetWithSingleLayer
        }
    }
}
