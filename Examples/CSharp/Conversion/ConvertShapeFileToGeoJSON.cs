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
            string dataDir = RunExamples.GetDataDir();
            string shapefilePath = dataDir + "InputShapeFile.shp";
            string jsonPath = dataDir + "output_out.json";

            //ExStart: ConvertShapeFileToGeoJSON
            VectorLayer.Convert(shapefilePath, Drivers.Shapefile, jsonPath, Drivers.GeoJson);
            //ExEnd: ConvertShapeFileToGeoJSON
        }
    }
}
