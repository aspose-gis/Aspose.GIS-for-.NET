using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Geometries
{
    class SpecifyWktVariantOnTranslation
    {
        public static void Run()
        {
            //ExStart: SpecifyWktVariantOnTranslation
            Point point = new Point(23.5732, 25.3421) { M = 40.3 };
            point.SpatialReferenceSystem = SpatialReferenceSystem.Wgs84;

            Console.WriteLine(point.AsText(WktVariant.Iso)); // POINT M (23.5732, 25.3421, 40.3)
            Console.WriteLine(point.AsText(WktVariant.SimpleFeatureAccessOutdated)); // POINT (23.5732, 25.3421)
            Console.WriteLine(point.AsText(WktVariant.ExtendedPostGis)); // SRID=4326;POINTM (23.5732, 25.3421, 40.3)
            //ExEnd: SpecifyWktVariantOnTranslation
        }
    }
}
