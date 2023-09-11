using Aspose.Gis.Rendering;
using Aspose.Gis;
using Aspose.Gis.Rendering.Symbolizers;


namespace Geo.Viewer.WPF
{
    /// <summary>
    /// Manages operations required to display geometry in different forms and styles.
    /// </summary>
    internal class GeometryOutput
    {
        /// <summary>
        /// Puts the passed geometry in a file
        /// </summary>
        public static string SaveGeometryAsMap(VectorLayer roadsLayer, VectorLayer wayLayer, string fileName = "test", float mapSize = 500)
        {
            string fileExtension = ".jpg";
            string availableFileName = fileName;
            ///The final layer is displayed and stored in the file of one of the supported format variants
            using (var map = new Map(mapSize, mapSize))
            {
                map.Add(roadsLayer, new SimpleLine() { Color = System.Drawing.Color.Coral});
                map.Add(wayLayer, new SimpleLine() { Width = 3 });
                map.Render(availableFileName + fileExtension, Renderers.Jpeg);
            }
            return availableFileName + fileExtension;
        }
    }
}
