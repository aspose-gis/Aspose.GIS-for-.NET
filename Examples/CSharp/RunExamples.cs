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

            lic.SetLicense("D:\\DotNet Projects\\Aspose\\2018\\Aspose.Total.lic");

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
            //DetermineIfGeometriesTouchEachOther.Run();
            //DetermineIfGeometriesCrossEachOther.Run();
            //DetermineIfGeometriesOverlap.Run();
            //FindOverlaysOfGeometries.Run();
            //ReducePrecisionOfAGeometry.Run();
            //LimitPrecisionWhenWritingGeometries.Run();
            //LimitPrecisionWhenReadingGeometries.Run();
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
            #endregion

            #region Conversion
            //ConvertShapeFileToGeoJSON.Run();
            //ConvertGeoJSONToShapeFileWithAttributeAdjustment.Run();
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
    }
}
