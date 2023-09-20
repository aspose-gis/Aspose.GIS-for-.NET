using Aspose.Gis.Rendering;
using Aspose.Gis;


namespace Geo.Layers.Join
{
    internal class LayerOutput
    {
        /// <summary>
        /// Puts the passed layer in a file
        /// </summary>
        public static string SaveLayerAsMap(VectorLayer layer, string fileName = "test", float mapSize = 500)
        {
            string fileExtension = ".jpg";
            string availableFileName = fileName;
            int i = 0;
            while (System.IO.File.Exists(availableFileName + fileExtension))
            {
                availableFileName = fileName + i;
                i++;
            }

            ///The final layer is displayed and stored in the file of one of the supported format variants
            using (var map = new Map(mapSize, mapSize))
            {
                map.Add(layer);
                map.Render(availableFileName + fileExtension, Renderers.Jpeg);
            }

            return availableFileName + fileExtension;
        }
    }
}
