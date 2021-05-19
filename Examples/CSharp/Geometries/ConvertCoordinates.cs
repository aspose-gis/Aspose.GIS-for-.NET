using System;
using Aspose.Gis;

namespace Aspose.GIS_for.NET.Geometries
{
    public class ConvertCoordinates
    {
        public static void Run()
        {
            ConvertCoordinate();
            ParseCoordinate();
        }

        public static void ConvertCoordinate()
        {
            Console.WriteLine($"\n== Start: {nameof(ConvertCoordinate)}");

            //ExStart: ConvertToDegreeBased
            var decimalDegrees = GeoConvert.AsPointText(25.5, 45.5, PointFormats.DecimalDegrees);
            Console.WriteLine(decimalDegrees);

            var degreeDecimalMinutes = GeoConvert.AsPointText(25.5, 45.5, PointFormats.DegreeDecimalMinutes);
            Console.WriteLine(degreeDecimalMinutes);

            var degreeMinutesSeconds = GeoConvert.AsPointText(25.5, 45.5, PointFormats.DegreeMinutesSeconds);
            Console.WriteLine(degreeMinutesSeconds);

            var geoRef = GeoConvert.AsPointText(25.5, 45.5, PointFormats.GeoRef);
            Console.WriteLine(geoRef);

            //ExEnd: ConvertToDegreeBased
        }

        public static void ParseCoordinate()
        {
            Console.WriteLine($"\n== Start: {nameof(ParseCoordinate)}");

            //ExStart: ParseCoordinate
            if (GeoConvert.TryParsePointText("25.5°, 45.5°", out var point1))
            {
                Console.WriteLine("25.5°, 45.5° parsed as" + point1);
            }

            if (GeoConvert.TryParsePointText("25°30.00000', 045°30.00000'", out var point2))
            {
                Console.WriteLine("25°30.00000', 045°30.00000' parsed as" + point2);
            }

            if (GeoConvert.TryParsePointText("25°30'00.3000\", 045°30'00.3000\"", out var point3))
            {
                Console.WriteLine("25°30'00.3000\", 045°30'00.3000\" parsed as" + point3);
            }

            if (GeoConvert.TryParsePointText("RHAL30003000", out var point4))
            {
                Console.WriteLine("RHAL30003000 parsed as" + point4);
            }
            //ExEnd: ParseCoordinate
        }
    }
}