using Aspose.Gis;
using Aspose.GIS.Examples.CSharp.Conversion;
using Aspose.GIS.Examples.CSharp.Geometries;
using Aspose.GIS.Examples.CSharp.Layers;
using Aspose.GIS_for.NET.Geometries;
using Aspose.GIS_for.NET.Layers;
using Aspose.GIS_for.NET.SpatialReferencingSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp
{
    class RunExamples
    {
        static void Main(string[] args)
        {
            License lic = new License();

            lic.SetLicense("E:\\license\\Aspose.Total.lic");

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
            //SetSpatialReferenceSystemForGeometry.Run();

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
            #endregion

            #region Working with Layers
            //CreateNewShapeFile.Run();
            //CreateVectorLayerWithSpatialReferenceSystem.Run();
            //GetFeatureCountInLayer.Run();
            //GetInformationAboutLayerAttributes.Run();
            //IterateOverFeaturesInLayer.Run();
            //GetValueOfAFeatureAttribute.Run();      
            //FilterFeaturesByAttributeValue.Run();
            //ExtractFeaturesFromShapeFileToGeoJSON.Run();
            //SpecifyAttributeValueLength.Run();
            //GetValueOfNullFeatureAttribute.Run();
            //ConvertPolygonShapeFileToLineStringShapeFile.Run();
            //CreateKMLFile.Run();
            //ReadFeaturesFromGML.Run();
            //ReadFeaturesFromGPX.Run();
            //ReadFeaturesFromKML.Run();
            //ReadFeaturesFromOSMXML.Run();
            //GetValueOrDefaultOfFeature.Run();
            //ReadingESRIFileGeoDatabaseFileGDB.Run();

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

            #region Spatial Reference System
            //CheckDriverForSpatialReferenceSystemSupport.Run();

            //CompareSpatialReferenceSystems.Run();

            //CreateFromWkt.Run();

            //CreateSpatialReferenceSystemWithCustomParams.Run();

            //ExportSpatialReferenceSystemToWKT.Run();
            #endregion

            Console.WriteLine("=====================================================");

            Console.WriteLine("Done with the execution of example.");

            Console.ReadLine();
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
