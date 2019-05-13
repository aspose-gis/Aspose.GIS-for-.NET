using Aspose.Gis.SpatialReferencing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.SpatialReferencingSystem
{
    public class CreateFromEpsgCode
    {
        public static void Run()
        {
            //ExStart: CreateFromEpsgCode
            var srs = SpatialReferenceSystem.CreateFromEpsg(26918);

            Console.WriteLine("SRS Name: {0}", srs.Name); // NAD83 / UTM zone 18N
            Console.WriteLine("SRS EPSG code: {0}", srs.EpsgCode); // 26918
            Console.WriteLine("Datum name: {0}", srs.GeographicDatum.Name); // North_American_Datum_1983
            Console.WriteLine("Datum EPSG code: {0}", srs.GeographicDatum.EpsgCode); // 6269
            Console.WriteLine("Ellipsoid name: {0}", srs.GeographicDatum.Ellipsoid.Name); // GRS 1980
            Console.WriteLine("Ellipsoid EPSG code: {0}", srs.GeographicDatum.EpsgCode); // 6269

            Console.WriteLine("Type: {0}", srs.Type); // Projected
            Console.WriteLine("Dimensions count: {0}", srs.DimensionsCount); // 2

            Console.WriteLine("First dimension name: {0}", srs.GetAxis(0).Name); // X
            Console.WriteLine("First dimension direction: {0}", srs.GetAxis(0).Direction); // East

            Console.WriteLine("Second dimension name: {0}", srs.GetAxis(1).Name); // Y
            Console.WriteLine("Second dimension direction: {0}", srs.GetAxis(1).Direction); // North

            Console.WriteLine("First dimension unit: {0}, {1}", srs.GetUnit(0).Name, srs.GetUnit(0).Factor); // metre, 1
            Console.WriteLine("Second dimension unit: {0}, {1}", srs.GetUnit(1).Name, srs.GetUnit(1).Factor); // metre, 1
            //ExEnd: CreateFromEpsgCode
        }
    }
}
