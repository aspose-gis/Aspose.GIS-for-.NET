using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using Aspose.Gis.Relationship.Joins;

namespace Aspose.GIS_for.NET.Layers
{
    public static class JoinedLayer
    {
        public static void Run()
        {
            JoinByName();
            JoinWithConditionComparer();
            JoinFewAttributes();
        }

        private static void JoinByName()
        {
            Console.WriteLine($"== Start Demo: {nameof(JoinByName)}");
            var workFolder = RunExamples.GetDataDir();

            // ExStart: JoinByName
            //one-to-one left join two layers by 'city' attribute
            var options = new JoinOptions
            {
                JoinAttributeName = "city",
                TargetAttributeName = "city"
            };

            using (var main = Drivers.Kml.OpenLayer(Path.Combine(workFolder, "main.kml")))
            using (var second = Drivers.Kml.OpenLayer(Path.Combine(workFolder, "second.kml")))
            using (var joined = main.Join(second, options))
            {
                // read and print joined
                var featuresCount = joined.Count;
                var attributesCount = joined.Attributes.Count;
                var spatialRefSys = joined.SpatialReferenceSystem;
                var code = spatialRefSys == null ? "'no srs'" : spatialRefSys.EpsgCode.ToString();
                var joinedTempValue = joined[0].GetValue("joined_temp");

                Console.WriteLine($"featuresCount: {featuresCount}");
                Console.WriteLine($"attributesCount: {attributesCount}");
                Console.WriteLine($"spatialRefSys: {code}");
                Console.WriteLine($"joinedTempValue: {joinedTempValue}");
            }
            // ExEnd: JoinByName
        }

        private static void JoinWithConditionComparer()
        {
            Console.WriteLine($"== Start Demo: {nameof(JoinWithConditionComparer)}");
            var workFolder = RunExamples.GetDataDir();

            // ExStart: JoinWithConditionComparer
            //one-to-one left join two layers by 'city' attribute
            var options = new JoinOptions
            {
                JoinAttributeName = "city",
                TargetAttributeName = "city",

                //use custom comparer
                ConditionComparer = new InsensitiveComparer()
            };

            using (var main = Drivers.Kml.OpenLayer(Path.Combine(workFolder, "main.kml")))
            using (var second = Drivers.Kml.OpenLayer(Path.Combine(workFolder, "second.kml")))
            using (var joined = main.Join(second, options))
            {
                // read and print joined
                var featuresCount = joined.Count;
                var attributesCount = joined.Attributes.Count;
                var spatialRefSys = joined.SpatialReferenceSystem;
                var code = spatialRefSys == null ? "'no srs'" : spatialRefSys.EpsgCode.ToString();
                var cityValue = joined[4].GetValue("city");
                var joinedCityValue = joined[4].GetValue("joined_city");

                Console.WriteLine($"featuresCount: {featuresCount}");
                Console.WriteLine($"attributesCount: {attributesCount}");
                Console.WriteLine($"spatialRefSys: {code}");
                Console.WriteLine($"cityValue: {cityValue}");
                Console.WriteLine($"joinedCityValue: {joinedCityValue}");
            }
            // ExEnd: JoinWithConditionComparer
        }

        private static void JoinFewAttributes()
        {
            Console.WriteLine($"== Start Demo: {nameof(JoinFewAttributes)}");
            var workFolder = RunExamples.GetDataDir();

            // ExStart: JoinFewAttributes
            //one-to-one left join two layers by 'city' attribute
            var options = new JoinOptions
            {
                JoinAttributeName = "city",
                TargetAttributeName = "city",

                //define attributes to join
                JoinAttributeNames = new List<string> { "temp", "date" }
            };

            using (var main = Drivers.Kml.OpenLayer(Path.Combine(workFolder, "main.kml")))
            using (var second = Drivers.Kml.OpenLayer(Path.Combine(workFolder, "second.kml")))
            using (var joined = main.Join(second, options))
            {
                // read and print joined
                var featuresCount = joined.Count;
                var attributesCount = joined.Attributes.Count;
                var spatialRefSys = joined.SpatialReferenceSystem;
                var code = spatialRefSys == null ? "'no srs'" : spatialRefSys.EpsgCode.ToString();

                Console.WriteLine($"featuresCount: {featuresCount}");
                Console.WriteLine($"attributesCount: {attributesCount}");
                Console.WriteLine($"spatialRefSys: {code}");
            }
            // ExEnd: JoinFewAttributes
        }

        // ExStart: InsensitiveComparer

        private class InsensitiveComparer : IEqualityComparer<object>
        {
            bool IEqualityComparer<object>.Equals(object x, object y)
            {
                if (x == null || y == null)
                {
                    return x == y;
                }

                var xString = x.ToString();
                var yString = y.ToString();
                return xString.Equals(yString, StringComparison.InvariantCultureIgnoreCase);

            }

            public int GetHashCode(object obj)
            {
                return obj.ToString().ToLower().GetHashCode();
            }
        }

        // ExEnd: InsensitiveComparer
    }
}