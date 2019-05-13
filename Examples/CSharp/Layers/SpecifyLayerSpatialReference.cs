using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using System;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    class SpecifyLayerSpatialReference
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();
            string path = dataDir + "SpecifyLayerSpatialReference_out.shp";

            //ExStart: SpecifyLayerSpatialReference
            var srs = SpatialReferenceSystem.CreateFromEpsg(26918);
            using (VectorLayer layer = VectorLayer.Create(path, Drivers.Shapefile, srs))
            {
                var feature = layer.ConstructFeature();
                feature.Geometry = new Point(60, 24);
                layer.Add(feature);
            }

            using (VectorLayer layer = VectorLayer.Open(path, Drivers.Shapefile))
            {
                Console.WriteLine(layer.SpatialReferenceSystem.EpsgCode); // 26918
                Console.WriteLine(layer.SpatialReferenceSystem.Name);     // NAD83_UTM_zone_18N
            }

            //ExEnd: SpecifyLayerSpatialReference
        }
    }
}
