using System;
using System.Drawing;
using System.IO;
using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using Aspose.Gis.Rendering;
using Aspose.Gis.Rendering.Colorizers;
using Aspose.Gis.SpatialReferencing;

namespace Aspose.GIS_for.NET.Rendering
{
    public static class RenderRasterFormats
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

            Console.WriteLine($"Example: {nameof(DrawRasterDefaultSettings)}");
            DrawRasterDefaultSettings();

            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(DrawSkewRaster)}");
            DrawSkewRaster();

            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(DrawPolarRasterExtent)}");
            DrawPolarRasterExtent();
        }

        private static void DrawRasterDefaultSettings()
        {
            // ExStart: DrawRasterDefaultSettings
            string filesPath = RunExamples.GetDataDir();
            
            using (var map = new Map(500, 500))
            {
                var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster_float32.tif"));
                // Conversion to colors is detected automatically.
                // The maximum and minimum values are calculated and linear interpolation is used.
                map.Add(layer);
                map.Render(filesPath + "raster_float32_out.svg", Renderers.Svg);
            }
            // ExEnd: DrawRasterDefaultSettings
        }

        private static void DrawSkewRaster()
        {
            // ExStart: DrawSkewRaster
            string filesPath = RunExamples.GetDataDir();

            using (var map = new Map(500, 500))
            {
                // use background color
                map.BackgroundColor = Color.Azure;

                var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster_skew.tif"));

                // Conversion to colors is detected automatically.
                // The maximum and minimum values are calculated and linear interpolation is used.
                map.Add(layer);

                map.Render(filesPath + "raster_skew_out.svg", Renderers.Svg);
            }
            // ExEnd: DrawSkewRaster
        }

        private static void DrawPolarRasterExtent()
        {
            // ExStart: DrawPolarRasterExtent
            string filesPath = RunExamples.GetDataDir();

            using (var map = new Map(500, 500))
            {
                // setup the polar extent and coordinate system (gnomonic spatial reference)
                map.SpatialReferenceSystem = SpatialReferenceSystem.CreateFromEpsg(102034);
                map.Extent = new Extent(-180, 60, 180, 90) { SpatialReferenceSystem = SpatialReferenceSystem.Wgs84 };
                map.BackgroundColor = Color.Azure;

                var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster_countries.tif"));

                // make gray colorizer
                var colorizer = new MultiBandColor()
                {
                    RedBand = new BandColor() { BandIndex = 0, Min = 0, Max = 255 },
                    GreenBand = new BandColor() { BandIndex = 0, Min = 0, Max = 255 },
                    BlueBand = new BandColor() {BandIndex = 0, Min = 0, Max = 255}
                };
                map.Add(layer, colorizer);
                map.Render(filesPath + "raster_countries_gnomonic_out.png", Renderers.Png);
            }
            // ExEnd: DrawPolarRasterExtent
        }
    }
}