using System;
using System.IO;
using System.Linq;
using Aspose.Gis;
using Aspose.Gis.Raster;

namespace Aspose.GIS.Examples.CSharp.Layers
{
    public static class InteractWithRasterFormats
    {
        public static void Run()
        {
            Console.WriteLine($"Example: {nameof(ReadGeneralDataInGeoTiff)}");
            ReadGeneralDataInGeoTiff();

            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(ReadValuesByLine)}");
            ReadValuesByLine();

            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(ReadValuesWithSpecifiedType)}");
            ReadValuesWithSpecifiedType();
            
            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(AnalyzeValuesInGeoTiff)}");
            AnalyzeValuesInGeoTiff();

            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(ReadRawBytesInGeoTiff)}");
            ReadRawBytesInGeoTiff();

            Console.WriteLine("");
            Console.WriteLine($"Example: {nameof(ReadSingleBandEsriAscii)}");
            ReadSingleBandEsriAscii();
        }

        public static void ReadGeneralDataInGeoTiff()
        {
            // ExStart: ReadGeneralDataInGeoTiff
            string filesPath = RunExamples.GetDataDir();
            using (var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster50x50.tif")))
            {
                // read and print raster
                var cellSize = layer.CellSize;
                var extent = layer.GetExtent();
                var spatialRefSys = layer.SpatialReferenceSystem;
                var code = spatialRefSys == null ? "'no srs'" : spatialRefSys.EpsgCode.ToString();
                var bounds = layer.Bounds;
                var bandCount = layer.BandCount;

                Console.WriteLine($"cellSize: {cellSize}");
                Console.WriteLine($"extent: {extent}");
                Console.WriteLine($"spatialRefSys: {code}");
                Console.WriteLine($"bounds: {bounds}");
                Console.WriteLine($"bandCount: {bandCount}");

                // read and print bands
                for (int i = 0; i < layer.BandCount; i++)
                {
                    var dataType = layer.GetBand(i).DataType;
                    var hasNoData = !layer.NoDataValues.IsNull();
                    var statistics = layer.GetStatistics(i);

                    Console.WriteLine();
                    Console.WriteLine($"Band: {i}");
                    Console.WriteLine($"dataType: {dataType}");
                    Console.WriteLine($"statistics: {statistics}");
                    Console.WriteLine($"hasNoData: {hasNoData}");
                    if (hasNoData)
                        Console.WriteLine($"noData: {layer.NoDataValues[i]}");

                }
            }
            // ExEnd: ReadGeneralDataInGeoTiff
        }

        public static void ReadValuesWithSpecifiedType()
        {
            // ExStart: ReadValuesWithSpecifiedType
            string filesPath = RunExamples.GetDataDir();
            using (var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster_float32.tif")))
            {
                // get band values in corner cell.
                var bandValues = layer.GetValues(0, 0);

                // we read data from the same strip with type float32, but all values are integers less than 255
                // so the next auto-cast is correct.
                Console.WriteLine($"byte: {bandValues.AsByte()}");
                Console.WriteLine($"integer: {bandValues.AsInteger()}");
                Console.WriteLine($"float: {bandValues.AsFloat()}");
                // the next two lines are equivalent
                Console.WriteLine($"double: {bandValues.AsDouble()}");
                Console.WriteLine($"double with []: {bandValues[0]}");
            }
            // ExStart: ReadValuesWithSpecifiedType
        }

        public static void ReadValuesByLine()
        {
            // ExStart: ReadValuesByLine
            string filesPath = RunExamples.GetDataDir();
            using (var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster_float32.tif")))
            {
                var count = 0;
                for (int i = 0; i < layer.Height; i++)
                {
                    var lineRect = new RasterRect(0, i, layer.Width, 1);
                    var lineDump = layer.GetValuesDump(lineRect);
                    count += lineDump.Length;
                }
                Console.WriteLine($"total read values: {count}");
            }
            // ExStart: ReadValuesByLine
        }

        public static void AnalyzeValuesInGeoTiff()
        {
            // ExStart: AnalyzeValuesInGeoTiff
            string filesPath = RunExamples.GetDataDir();
            using (var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster50x50.tif")))
            {
                // get all values
                var dump = layer.GetValuesDump(layer.Bounds);

                // use LINQ
                // we compute cells count where values in all bands are 'no data'
                var nodataCount = dump.Count(t => t.EqualsNoData(0) && t.EqualsNoData(1) && t.EqualsNoData(2));
                // we compute cells count where values like a blue color (<35, <35, >235)
                var likeBlueCount = dump.Count(t => t[0] < 35 && t[1] < 35 && t[2] > 235);
                Console.WriteLine("");
                Console.WriteLine("we use LINQ ");
                Console.WriteLine($"no data count: {nodataCount}");
                Console.WriteLine($"like blue color count: {likeBlueCount}");

                // we use the 'GetValuesOnExpression' method to avoid additional memory allocation.
                var nodata = 0;
                var likeBlue = 0;
                layer.GetValuesOnExpression(layer.Bounds, (context, values) =>
                {
                    if (values.EqualsNoData(0) && values.EqualsNoData(1) && values.EqualsNoData(2))
                        nodata++;

                    if (values[0] < 35 && values[1] < 35 && values[2] > 235)
                        likeBlue++;
                });
                Console.WriteLine("");
                Console.WriteLine("we use the 'GetValuesOnExpression' ");
                Console.WriteLine($"no data counter: {nodata}");
                Console.WriteLine($"like blue color counter: {likeBlue}");
            }
            // ExStart: AnalyzeValuesInGeoTiff
        }

        public static void ReadRawBytesInGeoTiff()
        {
            // ExStart: ReadRawBytesInGeoTiff
            string filesPath = RunExamples.GetDataDir();
            using (var layer = Drivers.GeoTiff.OpenLayer(Path.Combine(filesPath, "raster_int10.tif")))
            {
                var dump = layer.GetValuesDump(layer.Bounds);
                foreach (var values in dump)
                {
                    var bits = values.AsRawBits();
                }
                Console.WriteLine("raw bits is read");
            }
            // ExStart: ReadRawBytesInGeoTiff
        }

        public static void ReadSingleBandEsriAscii()
        {
            // ExStart: ReadSingleBandEsriAscii
            string filesPath = RunExamples.GetDataDir();
            using (var layer = Drivers.EsriAscii.OpenLayer(Path.Combine(filesPath, "raster_single.asc")))
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

                Console.WriteLine($"cellSize: {cellSize}");
                Console.WriteLine($"extent: {extent}");
                Console.WriteLine($"spatialRefSys: {code}");
                Console.WriteLine($"bounds: {bounds}");
                Console.WriteLine($"bandCount: {bandCount}");
                Console.WriteLine($"nodata: {nodata}");
                Console.WriteLine($"dataType: {dataType}");
                Console.WriteLine($"statistics: {statistics}");

                layer.GetValuesOnExpression(layer.Bounds, (context, values) =>
                {
                    Console.WriteLine($"x: {context.CellX}; y: {context.CellY}; v: {values[0]}; e: {values.EqualsNoData()}");
                });
            }
            // ExStart: ReadSingleBandEsriAscii
        }
    }
}