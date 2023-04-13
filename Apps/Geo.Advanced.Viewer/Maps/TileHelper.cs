using System.Linq;
using Aspose.Gis.Rendering;
using Aspose.Gis.Formats.XyzTile;
using Aspose.Gis.SpatialReferencing;
using Aspose.Gis;

namespace Geo.Advanced.Viewer.Maps
{
    public class TileHelper
    {
        public void AddTiles(Map map, Extent dataExtent, float mapSize)
        {
            string url = "https://tile.openstreetmap.org/{z}/{x}/{y}.png";
            using (var xyzLayer = Drivers.XyzTiles.OpenLayer(new XyzConnection(url)))
            {
                Extent extent = CalculateSquare(dataExtent, SpatialReferenceSystem.Wgs84);
                var tiles = xyzLayer.GetTiles(14, extent).ToList();

                var resampling = new RasterMapResampling() { Height = (int)mapSize * 2, Width = (int)mapSize };
                foreach (var tile in tiles)
                {
                    var raster = tile.AsRaster();
                    map.Add(new RasterMapLayer(raster)
                    {
                        Resampling = resampling
                    });
                }
            }
        }

        public static Extent CalculateSquare(Extent input, GeographicSpatialReferenceSystem referenceSystem)
        {
            var extent = input.Clone();
            if (extent.Height > extent.Width)
            {
                extent.YMax += (extent.Height - extent.Width) * 0.5;
                extent.YMin -= (extent.Height - extent.Width) * 0.5;
            }
            else if (extent.Width > extent.Height)
            {
                extent.XMax += (extent.Width - extent.Height) * 0.5;
                extent.XMin -= (extent.Width - extent.Height) * 0.5;
            }

            extent.SpatialReferenceSystem = referenceSystem;
            return extent;
        }
    }
}
