using Aspose.Gis.SpatialReferencing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.SpatialReferencingSystem
{
    public class CreateFromWkt
    {
        public static void Run()
        {
            //ExStart: CreateFromWkt
            string wkt = @"
GEOGCS[""WGS 84"",
    DATUM[""WGS_1984"",
        SPHEROID[""WGS 84"",6378137,298.257223563,
            AUTHORITY[""EPSG"",""7030""]],
        AUTHORITY[""EPSG"",""6326""]],
    PRIMEM[""Greenwich"",0,
        AUTHORITY[""EPSG"",""8901""]],
    UNIT[""degree"",0.01745329251994328,
        AUTHORITY[""EPSG"",""9122""]],
    AUTHORITY[""EPSG"",""4326""]]
";
            var srs = SpatialReferenceSystem.CreateFromWkt(wkt);
            Console.WriteLine("SRS Name: {0}", srs.Name); // WGS 84
            Console.WriteLine("SRS EPSG code: {0}", srs.EpsgCode); // 4326
            Console.WriteLine("Datum name: {0}", srs.GeographicDatum.Name); // WGS_1984
            Console.WriteLine("Datum EPSG code: {0}", srs.GeographicDatum.EpsgCode); // 6326
            Console.WriteLine("Ellipsoid name: {0}", srs.GeographicDatum.Ellipsoid.Name); // WGS 84
            Console.WriteLine("Ellipsoid EPSG code: {0}", srs.GeographicDatum.EpsgCode); // 7030

            Console.WriteLine("Type: {0}", srs.Type); // Geographic
            Console.WriteLine("Dimensions count: {0}", srs.DimensionsCount); // 2

            Console.WriteLine("First dimension name: {0}", srs.GetAxis(0).Name); // Longitude
            Console.WriteLine("First dimension direction: {0}", srs.GetAxis(0).Direction); // EAST

            Console.WriteLine("Second dimension name: {0}", srs.GetAxis(1).Name); // Latitude
            Console.WriteLine("Second dimension direction: {0}", srs.GetAxis(1).Direction); // NORTH

            Console.WriteLine("First dimension unit: {0}, {1}", srs.GetUnit(0).Name, srs.GetUnit(0).Factor); // degree, 0.01745...
            Console.WriteLine("Second dimension unit: {0}, {1}", srs.GetUnit(1).Name, srs.GetUnit(1).Factor); // degree, 0.01745...

            var geogSrs = srs.AsGeographic;
            Console.WriteLine("Angular unit: {0}, {1}", geogSrs.AngularUnit.Name, geogSrs.AngularUnit.Factor); // degree, 0.01745...
            Console.WriteLine("Prime meridian: {0}, {1}", geogSrs.PrimeMeridian.Name, geogSrs.PrimeMeridian.Longitude); // Greenwich, 0
            //ExEnd: CreateFromWkt
        }
    }
}
