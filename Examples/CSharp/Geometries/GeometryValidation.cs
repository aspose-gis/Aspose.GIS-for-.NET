using Aspose.Gis;
using Aspose.Gis.Formats.GeoJson;
using Aspose.Gis.Geometries;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    public class GeometryValidation
    {
        static string dataDir = RunExamples.GetDataDir();

        public static void Run()
        {
            IsGeometryValid();

            IsGeometrySimple();

            ValidateOnWrite();

            ValidateOnWriteObeyingSpecifications();
        }

        public static void IsGeometryValid()
        {
            //ExStart: IsGeometryValid
            LinearRing linearRing = new LinearRing();
            linearRing.AddPoint(0, 0);
            linearRing.AddPoint(0, 1);
            linearRing.AddPoint(1, 0);
            bool valid = linearRing.IsValid; // valid == false
            linearRing.AddPoint(0, 0);
            valid = linearRing.IsValid; // valid == true
            //ExEnd: IsGeometryValid
        }

        public static void IsGeometrySimple()
        {
            //ExStart: IsGeometrySimple
            LineString lineString = new LineString();
            bool simple = lineString.IsSimple; // simple == true
            lineString.AddPoint(0, 0);
            lineString.AddPoint(1, 0);
            simple = lineString.IsSimple; // simple == true
            lineString.AddPoint(0.5, 0);
            simple = lineString.IsSimple; // simple == false (line string crosses itself)
            //ExEnd: IsGeometrySimple
        }

        public static void ValidateOnWrite()
        {
            //ExStart: ValidateGeometriesOnWrite
            var exteriorRing = new LinearRing();
            exteriorRing.AddPoint(0, 0);
            exteriorRing.AddPoint(0, 1);
            exteriorRing.AddPoint(1, 1);
            exteriorRing.AddPoint(1, 0);
            exteriorRing.AddPoint(0, 0);

            var interiorRing = new LinearRing();
            interiorRing.AddPoint(0.5, 0.5);
            interiorRing.AddPoint(1, 0.5);
            interiorRing.AddPoint(1, 1);
            interiorRing.AddPoint(0.5, 1);
            interiorRing.AddPoint(0.5, 0.5);

            var invalidPolygon = new Polygon();
            invalidPolygon.ExteriorRing = exteriorRing;
            invalidPolygon.AddInteriorRing(interiorRing);
            // invalidPolygon.IsValid == false, since polygon rings share segments (have infinite number of intersection points)

            GeoJsonOptions options = new GeoJsonOptions();
            options.ValidateGeometriesOnWrite = false; // false is default
            File.Delete(dataDir + "not_validated_data_out.shp");
            using (var nonValidatingLayer = Drivers.GeoJson.Create(dataDir + "not_validated_data_out.shp", options))
            {
                Feature feature = nonValidatingLayer.ConstructFeature();
                feature.Geometry = invalidPolygon;
                // no exception is thrown, since ValidateGeometriesOnWrite == false, and GeoJson specification doesn't say that rings of polygon can't share segments.
                nonValidatingLayer.Add(feature);
            }

            options.ValidateGeometriesOnWrite = true;
            File.Delete(dataDir + "validated_data_out.shp");
            using (var validatingLayer = Drivers.GeoJson.Create(dataDir + "validated_data_out.shp", options))
            {
                Feature feature = validatingLayer.ConstructFeature();
                feature.Geometry = invalidPolygon;
                try
                {
                    validatingLayer.Add(feature); // GisException is thrown, since polygon is not valid
                }
                catch (GisException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            //ExEnd: ValidateGeometriesOnWrite
        }

        public static void ValidateOnWriteObeyingSpecifications()
        {
            //ExStart: ValidateOnWriteObeyingSpecifications
            LineString lineStrinWithOnePoint = new LineString();
            lineStrinWithOnePoint.AddPoint(0, 0);

            GeoJsonOptions options = new GeoJsonOptions();
            options.ValidateGeometriesOnWrite = false;
            using (var layer = Drivers.GeoJson.Create(dataDir + "ValidateOnWriteObeyingSpecifications_out.json", options))
            {
                Feature feature = layer.ConstructFeature();
                // GeoJSON specification says that line string must have at least two coordinates.
                feature.Geometry = lineStrinWithOnePoint;

                try
                {
                    // Geometry of feature doesn't match data format specification, so exception is thrown
                    // regardless what ValidateGeometriesOnWrite option is.
                    layer.Add(feature);
                }
                catch (GisException e)
                {
                }
            }
            //ExEnd: ValidateOnWriteObeyingSpecifications
        }

    }
}
