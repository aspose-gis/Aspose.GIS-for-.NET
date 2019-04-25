using Aspose.Gis;
using Aspose.Gis.Formats.FileGdb;
using Aspose.Gis.Geometries;
using System;
using Aspose.Gis.SpatialReferencing;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class SpecifyNamesOfObjectIdAndGeometryFields
    {
        public static void Run()
        {
            //ExStart: SpecifyNamesOfObjectIdAndGeometryFields
            var path = RunExamples.GetDataDir() + "NamesOfObjectIdAndGeometryFields_out.gdb";
            using (var dataset = Dataset.Create(path, Drivers.FileGdb))
            {
                var options = new FileGdbOptions
                {
                    // name object ID field 'OID' rather than the default 'OBJECTID'.
                    ObjectIdFieldName = "OID",

                    // name geometry field 'POINT' rather than the default 'SHAPE'.
                    GeometryFieldName = "POINT",
                };

                using (var layer = dataset.CreateLayer("layer_name", options, SpatialReferenceSystem.Wgs84))
                {
                    var feature = layer.ConstructFeature();
                    feature.Geometry = new Point(12.32, 34.21);
                    layer.Add(feature);
                }

                using (var layer = dataset.OpenLayer("layer_name"))
                {
                    var feature = layer[0];
                    Console.WriteLine(feature.GetValue<int>("OID")); // 1
                }
            }
            //ExEnd: SpecifyNamesOfObjectIdAndGeometryFields
        }
    }
}
