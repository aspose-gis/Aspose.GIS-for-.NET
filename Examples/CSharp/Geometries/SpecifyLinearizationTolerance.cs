using Aspose.Gis;
using Aspose.Gis.Formats.GeoJson;
using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class SpecifyLinearizationTolerance
    {
        public static void Run()
        {
            //ExStart: SpecifyLinearizationTolerance
            // If file format does not support curve geometries, we linearize them on write.
            // This example shows how to specify tolerance of the linearization.

            var options = new GeoJsonOptions
            {
                // linearized geometry must be within 1e-4 from curve geometry
                LinearizationTolerance = 1e-4,
            };

            string path = RunExamples.GetDataDir() + "SpecifyLinearizationTolerance_out.json";
            using (VectorLayer layer = VectorLayer.Create(path, Drivers.GeoJson, options))
            {
                var curveGeometry = Geometry.FromText("CircularString (0 0, 1 1, 2 0)");
                var feature = layer.ConstructFeature();
                feature.Geometry = curveGeometry;
                // geometry is linearized with tolerance 1e-4
                layer.Add(feature);
            }
            //ExEnd: SpecifyLinearizationTolerance
        }
    }
}
