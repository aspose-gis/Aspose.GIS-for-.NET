using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Geometries
{
    public class SetSpatialReferenceSystemForGeometry
    {
        public static void Run()
        {
            //ExStart: SetSpatialReferenceSystemForGeometry
            var point = new Point(2, 3);
            point.SpatialReferenceSystem = SpatialReferenceSystem.Wgs84;
            var srs = point.SpatialReferenceSystem; // WGS 84

            var line = new LineString();
            srs = line.SpatialReferenceSystem; // null

            line.AddPoint(point); // line takes SRS from point.
            srs = line.SpatialReferenceSystem; // WGS 84

            line.AddPoint(new Point(3, 4)); // point takes SRS of line.
            srs = line[1].SpatialReferenceSystem; // WGS84
            try
            {
                point = new Point(3, 4);
                point.SpatialReferenceSystem = SpatialReferenceSystem.Wgs72;
                line.AddPoint(point); // point has different non null SRS, exception is thrown
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            //ExEnd: SetSpatialReferenceSystemForGeometry
        }
    }
}
