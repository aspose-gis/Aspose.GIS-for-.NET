using System;
using System.IO;
using Aspose.Gis;
using Aspose.Gis.Raster;
using Aspose.Gis.SpatialReferencing;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    public static class WarpRasterFormats
    {
        public static void Run()
        {
            Console.WriteLine($"Example: {nameof(ResizeToWgs84RasterLayer)}");
            ResizeToWgs84RasterLayer();

            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(RescaleCellsInSpecifiedExtent)}");
            RescaleCellsInSpecifiedExtent();
        }

        private static void ResizeToWgs84RasterLayer()
        {
            // ExStart: ResizeToWgs84RasterLayer
            string filesPath = RunExamples.GetDataDir();
            using (var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster_float32.tif")))
            using (var warped = layer.Warp(new WarpOptions(){Height = 40, Width = 40, TargetSpatialReferenceSystem = SpatialReferenceSystem.Wgs84}))
            {
                // read and print raster
                var cellSize = warped.CellSize;
                var extent = warped.GetExtent();
                var spatialRefSys = warped.SpatialReferenceSystem;
                var code = spatialRefSys == null ? "'no srs'" : spatialRefSys.EpsgCode.ToString();
                var bounds = warped.Bounds;
                var bandCount = warped.BandCount;

                Console.WriteLine($"cellSize: {cellSize}");
                Console.WriteLine($"extent: {extent}");
                Console.WriteLine($"spatialRefSys: {code}");
                Console.WriteLine($"bounds: {bounds}");
                Console.WriteLine($"bandCount: {bandCount}");

                // read and print bands
                for (int i = 0; i < warped.BandCount; i++)
                {
                    var dataType = warped.GetBand(i).DataType;
                    var hasNoData = !warped.NoDataValues.IsNull();
                    var statistics = warped.GetStatistics(i);

                    Console.WriteLine();
                    Console.WriteLine($"Band: {i}");
                    Console.WriteLine($"dataType: {dataType}");
                    Console.WriteLine($"statistics: {statistics}");
                    Console.WriteLine($"hasNoData: {hasNoData}");
                    if (hasNoData)
                        Console.WriteLine($"noData: {warped.NoDataValues[i]}");
                }
            }
            // ExEnd: ResizeToWgs84RasterLayer
        }

        private static void RescaleCellsInSpecifiedExtent()
        {
            // ExStart: RescaleCellsInSpecifiedExtent
            string filesPath = RunExamples.GetDataDir();
            using (var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster_float32.tif")))
            {
                Extent sourceExtent = layer.GetExtent();
                var newExtent = new Extent(
                    sourceExtent.XMin,
                    sourceExtent.YMin,
                    sourceExtent.XMin + sourceExtent.Width * 0.5,
                    sourceExtent.YMax + sourceExtent.Height * 0.5,
                    layer.SpatialReferenceSystem);
                using (var warped = layer.Warp(new WarpOptions() { CellWidth = 120, CellHeight = 120, TargetExtent = newExtent }))
                {
                    // read and print raster
                    var cellSize = warped.CellSize;
                    var extent = warped.GetExtent();
                    var spatialRefSys = warped.SpatialReferenceSystem;
                    var code = spatialRefSys == null ? "'no srs'" : spatialRefSys.EpsgCode.ToString();
                    var bounds = warped.Bounds;

                    Console.WriteLine($"cellSize: {cellSize}");
                    Console.WriteLine($"source extent: {sourceExtent}");
                    Console.WriteLine($"target extent: {extent}");
                    Console.WriteLine($"spatialRefSys: {code}");
                    Console.WriteLine($"bounds: {bounds}");
                }
            }
            // ExEnd: RescaleCellsInSpecifiedExtent
        }
    }
}