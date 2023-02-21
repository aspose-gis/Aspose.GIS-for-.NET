using Aspose.Gis.Geometries;
using Aspose.Gis.Rendering;
using Aspose.Gis;

namespace Geo.Tools.Viewer
{
    /// <summary>
    /// Manages operations required to display geometry in different forms and styles.
    /// </summary>
    public class GeometryOutput
    {
        /// <summary>
        /// Puts the passed geometry in a file
        /// </summary>
        public static void SaveGeometryAsMap(IGeometry geometryObj, string fileName = "test.jpg", float mapSize = 500)
        {
            /// Creates an InMemory layer to store the geometry
            using (var layer = Drivers.InMemory.CreateLayer())
            {
                Feature feature = layer.ConstructFeature();
                feature.Geometry = geometryObj;
                layer.Add(feature);

                ///The final layer is displayed and stored in the file of one of the supported format variants
                using (var map = new Map(mapSize, mapSize))
                {
                    map.Add(layer);
                    map.Render(fileName, Renderers.Jpeg);
                }

            }
        }
    }
}
