using System;
using System.IO;
using System.Text;
using Aspose.Gis.Rendering;
using Aspose.Gis;

namespace Geo.Rasters.Viewer
{
    internal class RasterOutput
    {
        public static string MapRaster(string mapName = "test", float mapSize = 500)
        {
            //get raster layer from file
            var layer = Drivers.EsriAscii.OpenLayer(RunExamples.GetFolderDir() + "sample.asc");

            var mapExtension = ".jpeg";
            var availableFileName = GetAvailableFileName(mapName, mapExtension) + mapExtension;

            ///The final layer is displayed and stored in the file of one of the supported format variants
            using (var map = new Map(mapSize, mapSize))
            {
                map.Add(layer);
                map.Render(availableFileName, Renderers.Jpeg);
            }

            return availableFileName;
        }

        public static string GetAvailableFileName(string fileName, string fileExtension)
        {
            string availableFileName = fileName;
            int i = 0;

            while (System.IO.File.Exists(availableFileName + fileExtension))
            {
                availableFileName = fileName + i;
                i++;
            }

            return availableFileName;
        }

        public static string ReadSingleBandEsriAscii()
        {
            var output = new StringBuilder();
            output.AppendLine("ReadSingleBandEsriAscii: sample.asc").AppendLine();
            using (var layer = Drivers.EsriAscii.OpenLayer(Path.Combine(RunExamples.GetFolderDir(), "sample.asc")))
            {
                // The EsriAscii format always has only one band.
                var cellSize = layer.CellSize;
                var extent = layer.GetExtent();
                var spatialRefSys = layer.SpatialReferenceSystem;
                var code = spatialRefSys == null ? "'no srs'" : spatialRefSys.EpsgCode.ToString();
                var bounds = layer.Bounds;
                var bandCount = layer.BandCount;
                var nodata = layer.NoDataValues[0];
                var dataType = layer.GetBand().DataType;
                var statistics = layer.GetStatistics();

                output.AppendLine($"cellSize: {cellSize}");
                output.AppendLine($"extent: {extent}");
                output.AppendLine($"spatialRefSys: {code}");
                output.AppendLine($"bounds: {bounds}");
                output.AppendLine($"bandCount: {bandCount}");
                output.AppendLine($"nodata: {nodata}");
                output.AppendLine($"dataType: {dataType}");
                output.AppendLine($"statistics: {statistics}");

                layer.GetValuesOnExpression(layer.Bounds, (context, values) =>
                {
                    output.AppendLine($"x: {context.CellX}; y: {context.CellY}; v: {values[0]}; e: {values.EqualsNoData()}");
                });
            }
            return output.ToString();
        }
    }
}
