using Aspose.Gis.Rendering;
using Aspose.Gis.SpatialReferencing;
using Aspose.Gis;
using System;

namespace Geo.Advanced.Viewer.Maps
{
    /// <summary>
    /// Manages operations required to display layers in different forms and styles.
    /// </summary>
    internal class MapConstructor
    {
        /// <summary>
        /// Puts the passed layer in a file
        /// </summary>
        public static string CreateMap(VectorLayer placesLayer, VectorLayer wayLayer, float mapSize = 512)
        {
            string availableFileName = $"map_{Guid.NewGuid().ToString("D")}.png";

            using (var map = new Map(mapSize, mapSize))
            {
                map.SpatialReferenceSystem = SpatialReferenceSystem.WebMercator;

                var tiler = new TileHelper();
                tiler.AddTiles(map, placesLayer.GetExtent(), mapSize);

                map.Add(wayLayer, StyleBuilder.CreateWayStyle());
                map.Add(placesLayer, StyleBuilder.CreatePlaceStyle());

                map.Render(availableFileName, Renderers.Png);
            }


            return availableFileName;
        }
    }
}
