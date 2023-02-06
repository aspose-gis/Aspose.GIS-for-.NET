using Aspose.Gis.Geometries;
using Aspose.Gis.Rendering;
using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo.Geometry.Viewer
{
    /// <summary>
    /// Manages operations required to display geometry in different forms and styles.
    /// </summary>
    class GeometryOutput
    {
		/// <summary>
		/// Puts the passed geometry in a file
		/// </summary>
		public static void DisplayOnMap(IGeometry geometryObj, string fileName = "test", float mapSize = 500)
        {
            /// Creates an InMemory layer to store the geometry
            using (var layer = Drivers.InMemory.CreateLayer())
            {
                Feature feature = layer.ConstructFeature();
                feature.Geometry = geometryObj;
                layer.Add(feature);

		using (var map = new Map(mapSize, mapSize))
                {
                    map.Add(layer);
                    map.Render(pathString, Renderers.Svg);
                }

            }

        }
    }
}
