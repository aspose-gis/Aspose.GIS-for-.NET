using Aspose.Gis;
using Aspose.Gis.SpatialReferencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.SpatialReferencingSystem
{
    public class CheckDriverForSpatialReferenceSystemSupport
    {
        public static void Run()
        {
            //ExStart: CheckDriverForSpatialReferenceSystemSupport
            Drivers.Shapefile.SupportsSpatialReferenceSystem(SpatialReferenceSystem.Wgs72); // true
            Drivers.GeoJson.SupportsSpatialReferenceSystem(SpatialReferenceSystem.Wgs84); // true
            Drivers.GeoJson.SupportsSpatialReferenceSystem(SpatialReferenceSystem.Wgs72); // false
            //ExEnd: CheckDriverForSpatialReferenceSystemSupport
        }
    }
}
