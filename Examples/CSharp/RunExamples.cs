using Aspose.GIS_for.NET.Rendering;
using System;
using System.IO;
using Aspose.GIS.Examples.CSharp.Layers;
using Aspose.GIS_for.NET.Layers;


namespace Aspose.GIS.Examples.CSharp
{
    class RunExamples
    {
        static void Main(string[] args)
        {
            // Remove output files from the previous run
            CleanOutput();

            // Set the license to avoid the evaluation limitations.
            // Uncomment this lines if you have a license
            //License license = new License();
            //license.SetLicense(Path.Combine(GetDataDir(), "Aspose.GIS.lic"));

            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            // Uncomment the one you want to try out

            #region Working with Geometries
            //CreatePoint.Run();
            //CreateMultiPoint.Run();
            //CreateLineString.Run();
            //CreateMultiLineString.Run();
            //CreatePolygon.Run();
            //CreatePolygonWithHole.Run();
            //CreateMultiPolygon.Run();
            //GetGeometryType.Run();
            //CreateGeometryCollection.Run();
            //CountGeometriesInGeometry.Run();
            //CountPointsInGeometry.Run();
            //IterateOverPointsInGeometry.Run();
            //IterateOverGeometriesInGeometry.Run();
            //GeometryValidation.Run();
            //GIS_for.NET.Geometries.ConvertCoordinates.Run();

            //DetermineIfGeometriesAreSpatiallyEqual.Run();
            //DetermineIfGeometriesIntersect.Run();
            //DetermineIfOneGeometryContainsAnother.Run();
            //DetermineIfGeometriesTouchEachOther.Run();
            //DetermineIfGeometriesCrossEachOther.Run();
            //DetermineIfGeometriesOverlap.Run();
            //DetermineSpatialRelationViaRelateMethod.Run();
            //FindOverlaysOfGeometries.Run();
            //ReducePrecisionOfAGeometry.Run();
            //LimitPrecisionWhenWritingGeometries.Run();
            //LimitPrecisionWhenReadingGeometries.Run();

            //GetGeometryBuffer.Run();
            //GetDistanceBetweenGeometries.Run();
            //GetConvexHullOfGometry.Run();
            //GetAreaOfGeometry.Run();
            //GetLengthOfGeometry.Run();
            //GetCentroid.Run();
            //GetPointOnSurface.Run();
            //DetermineIfOneGeometryCoversAnother.Run();

            //TranslateGeometryFromWkt.Run();
            //TranslateGeometryToWkt.Run();
            //SpecifyWktVariantOnTranslation.Run();
            //TranslateGeometryToWkb.Run();
            //TranslateGeometryFromWkb.Run();
            //SpecifyWkbVariantOnTranslation.Run();
            //ConvertGeometryToEditable.Run();

            //CreateCircularString.Run();
            //CreateCompoundCurve.Run();
            //CreateCurvePolygon.Run();
            //CreateMultiCurve.Run();
            //CreateMultiSurface.Run();
            //DetermineIfGeometryHasCurves.Run();
            //LinearizeGeometry.Run();
            //Geometries.ReplacePolygonsByLines.Run();
            //SpecifyLinearizationTolerance.Run();
            #endregion

            #region Working with Layers
            //CreateNewShapeFile.Run();
            //CreateVectorLayerWithSpatialReferenceSystem.Run();
            //GetFeatureCountInLayer.Run();
            //GetInformationAboutLayerAttributes.Run();
            //IterateOverFeaturesInLayer.Run();
            //GetValueOfAFeatureAttribute.Run();
            //GetValuesOfAFeatureAttribute.Run();
            //FilterFeaturesByAttributeValue.Run();
            //ExtractFeaturesFromShapeFileToGeoJSON.Run();
            //SpecifyAttributeValueLength.Run();
            //SpecifyLayerSpatialReference.Run();
            //GetValueOfNullFeatureAttribute.Run();
            //ModifyFeatures.Run();
            //ConvertPolygonShapeFileToLineStringShapeFile.Run();

            //GIS_for.NET.Layers.KmlLayer.Run();

            //ReadFeaturesFromGML.Run();
            //GIS_for.NET.Layers.GpxLayer.Run();
            //GIS_for.NET.Layers.CsvLayer.Run();
            //ReadFeaturesFromOSMXML.Run();
            //GetValueOrDefaultOfFeature.Run();
            //ReadingESRIFileGeoDatabaseFileGDB.Run();
            //InteractWithRasterFormats.Run();
            //WarpRasterFormats.Run();
            //CropLayer.Run();
            //JoinedLayer.Run();
            //EditLayer.Run();

            //AddLayerToFileGdbDataset.Run();
            //RemoveLayersFromFileGdbDataset.Run();
            //CreateFileGdbDataset.Run();
            //CreateFileGdbDatasetWithSingleLayer.Run();
            //ConvertGeoJsonLayerToLayerInFileGdbDataset.Run();

            //ReadObjectIdFromFileGdbLayer.Run();

            //AccessFeaturesInTopoJson.Run();
            //WriteFeaturesToTopoJson.Run();
            //SpecifyPrecisionGridForFileGdbLayer.Run();
            //SpecifyTolerancesForFileGdbLayer.Run();
            //SpecifyNamesOfObjectIdAndGeometryFields.Run();

            //ReadFeaturesFromMapInfoTab.Run();
            //ReadFeaturesFromMapInfoInterchange.Run();

            //WriteGeoJsonToStream.Run();
            //ReadGeoJsonFromStream.Run();
            //FilteringAndIndexing.Run();

            //InteractWithPostGisDatabase.Run();
            //InteractWithSqlServerDatabase.Run();

            //ReadTilesFromXyzFormat.Run();

            #endregion

            #region Conversion
            //ConvertShapeFileToGeoJSON.Run();
            //ConvertGeoJSONToShapeFileWithAttributeAdjustment.Run();

            //ConvertGeoJsonToTopoJson.Run();
            //ConvertGeoJsonToTopoJsonAndSpecifyObjectName.Run();
            //ConvertGeoJsonToTopoJsonWithQuantization.Run();
            //ConvertGeoJsonToTopoJsonWithGroupingIntoObjects.Run();
            //ConvertTopoJsonToGeoJson.Run();
            #endregion

            #region Rendering
            //RenderMap.Run();
            //ImportSld.Run();
            //LabelMap.Run();
            //RenderRasterFormats.Run();
            #endregion

            #region Spatial Reference System
            //CheckDriverForSpatialReferenceSystemSupport.Run();
            //CompareSpatialReferenceSystems.Run();
            //CreateFromWkt.Run();
            //CreateFromEpsgCode.Run();
            //CreateSpatialReferenceSystemWithCustomParams.Run();
            //ExportSpatialReferenceSystemToWKT.Run();
            //SetSpatialReferenceSystemForGeometry.Run();

            #endregion

            #region AbstractPath
            //AbstractPathDemo.Run();
            #endregion

            Console.WriteLine("=====================================================");
            Console.WriteLine("Done with the execution of example. Press key to exit.");
            Console.ReadKey();
        }

        private static void CleanOutput()
        {
            // remove all files with '_out' suffix
            var dataDir = GetDataDir();
            foreach (var outputEntry in Directory.EnumerateFileSystemEntries(dataDir, "*_out.*"))
            {
                if (File.Exists(outputEntry))
                {
                    File.Delete(outputEntry);
                }

                if (Directory.Exists(outputEntry))
                {
                    Directory.Delete(outputEntry, recursive: true);
                }
            }
        }

        public static string GetDataDir()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return startDirectory != null ? Path.Combine(startDirectory, "Data\\") : null;
        }

        public static void CopyDirectory(string sourcePath, string destinationPath)
        {
            var sourceDirectory = new DirectoryInfo(sourcePath);

            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            foreach (var file in sourceDirectory.EnumerateFiles())
            {
                string path = Path.Combine(destinationPath, file.Name);
                file.CopyTo(path, false);
            }

            foreach (var directory in sourceDirectory.GetDirectories())
            {
                string path = Path.Combine(destinationPath, directory.Name);
                CopyDirectory(directory.FullName, path);
            }
        }
    }
}
