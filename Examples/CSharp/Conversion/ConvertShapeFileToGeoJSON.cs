using Aspose.Gis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS.Examples.CSharp.Conversion
{
    class ConvertShapeFileToGeoJSON
    {
        public static void Run()
        {
            //ExStart: ConvertShapeFileToGeoJSON
            VectorLayer.Convert("input.shp", Drivers.Shapefile, "output_out.json", Drivers.GeoJson);
            //ExEnd: ConvertShapeFileToGeoJSON
        }
    }
}
