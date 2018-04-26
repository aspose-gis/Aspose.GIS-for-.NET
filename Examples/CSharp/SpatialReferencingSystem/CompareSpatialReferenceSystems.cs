using Aspose.Gis.SpatialReferencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.SpatialReferencingSystem
{
    public class CompareSpatialReferenceSystems
    {
        public static void Run()
        {
            //ExStart: CompareSpatialReferenceSystems
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
            srs.IsEquivalent(SpatialReferenceSystem.Wgs84); // true
            //ExEnd: CompareSpatialReferenceSystems
        }
    }
}
