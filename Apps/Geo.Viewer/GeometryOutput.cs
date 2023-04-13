using Aspose.Gis.Geometries;
using Aspose.Gis.Rendering;
using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string SaveGeometryAsMap(IGeometry geometryObj, string fileName = "test", float mapSize = 500)
        {
            string fileExtension = ".jpg";
            string availableFileName = fileName;
            /// Creates an InMemory layer to store the geometry
            using (var layer = Drivers.InMemory.CreateLayer())
            {
                Feature feature = layer.ConstructFeature();
                feature.Geometry = geometryObj;
                layer.Add(feature);

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

            }
            return availableFileName + fileExtension;
        }
    }
}
