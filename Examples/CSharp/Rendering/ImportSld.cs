using Aspose.Gis;
using Aspose.Gis.Rendering;
using Aspose.GIS.Examples.CSharp;

namespace Aspose.GIS_for.NET.Rendering
{
    public class ImportSld
    {
        private static readonly string dataDir = RunExamples.GetDataDir();

        public static void Run()
        {
            //ExStart: ImportSLD
            using (var map = new Map(500, 320))
            {
                // open a layer containing the data
                var layer = VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson);
                // create a map layer (a styled representation of the data)
                var mapLayer = new VectorMapLayer(layer);
                // import a style from an SLD document
                mapLayer.ImportSld(dataDir + "lines.sld");
                // add the styled layer to the map and render it
                map.Add(mapLayer);
                map.Render(dataDir + "lines_sld_style_out.png", Renderers.Png);
            }
            //ExEnd: ImportSLD
        }
    }
}
