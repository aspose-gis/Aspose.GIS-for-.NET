using System;
using System.IO;
using System.Linq;
using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using Aspose.Gis.Formats.XyzTile;
using Aspose.Gis.Rendering;
using Aspose.Gis.SpatialReferencing;

namespace Aspose.GIS_for.NET.Rendering
{
    public static class ReadTilesFromXyzFormat
    {
        public static void Run()
        {
            // Note: a license is required to run this example. 
            // You can request a 30-day temporary license here: https://purchase.aspose.com/temporary-license
            var pathToLicenseFile = @""; // <- change this to the path to your license file
            if (!string.IsNullOrEmpty(pathToLicenseFile))
            {
                var license = new License();
                license.SetLicense(pathToLicenseFile);
            }

            Console.WriteLine($"Example: {nameof(OpenStreetXyzTile)}");
            OpenStreetXyzTile();

            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(OpenStreetXyzTiles)}");
            OpenStreetXyzTiles();

            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(OpenTileFromFolder)}");
            OpenTileFromFolder();
        }

        private static void OpenStreetXyzTile()
        {
            // ExStart: OpenStreetXyzTile
            var mapPath = Path.Combine(RunExamples.GetDataDir(), "out_osm_tile.png");

            // we use the osm tile server
            string url = "http://tile.openstreetmap.org/{z}/{x}/{y}.png";
            using (var layer = Drivers.XyzTiles.OpenLayer(new XyzConnection(url)))
            {
                // print tile info
                var tile = layer.GetTile(2, 3, 1);
                Console.WriteLine($"CellX: {tile.CellX}, CellY: {tile.CellY}" );
                Console.WriteLine($"Path: {tile.AsPath()}");

                // render tile
                var resampling = new RasterMapResampling() { Height = 256, Width = 256 };
                using (var map = new Map(800, 800))
                {
                    var raster = tile.AsRaster();
                    map.Add(new RasterMapLayer(raster){Resampling = resampling});
                    map.Render(mapPath, Renderers.Png);
                }
                Console.WriteLine($"Rendered Map: {mapPath}");
            }
            // ExEnd: OpenStreetXyzTile
        }

        private static void OpenStreetXyzTiles()
        {
            // ExStart: OpenStreetXyzTiles
            var mapPath = Path.Combine(RunExamples.GetDataDir(), "out_osm_tiles.png");

            // we use the osm tile server
            string url = "http://tile.openstreetmap.org/{z}/{x}/{y}.png";
            using (var layer = Drivers.XyzTiles.OpenLayer(new XyzConnection(url)))
            {
                // print tiles info
                var extent = new Extent(-90, -40, 90, 40) {SpatialReferenceSystem = SpatialReferenceSystem.Wgs84};
                var tiles = layer.GetTiles(2, extent).ToList();

                // render tiles
                var resampling = new RasterMapResampling() { Height = 800, Width = 800 };
                using (var map = new Map(800, 800))
                {
                    foreach (var tile in tiles)
                    {
                        var raster = tile.AsRaster();
                        map.Add(new RasterMapLayer(raster) { Resampling = resampling });
                    }
                    map.Render(mapPath, Renderers.Png);
                }
                Console.WriteLine($"Rendered Map: {mapPath}");
            }
            // ExEnd: OpenStreetXyzTiles
        }
        private static void OpenTileFromFolder()
        {
            // ExStart: OpenTileFromFolder
            string url = "C://tiles/{z}/{x}/{y}.png";
            using (var layer = Drivers.XyzTiles.OpenLayer(new XyzConnection(url)))
            {
                // print tile info
                var tile = layer.GetTile(0, 0, 0);
                Console.WriteLine($"CellX: {tile.CellX}, CellY: {tile.CellY}");
                Console.WriteLine($"Path: {tile.AsPath()}");
            }
            // ExEnd: OpenTileFromFolder
        }
    }
}