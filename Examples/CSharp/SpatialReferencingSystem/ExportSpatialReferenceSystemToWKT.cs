using Aspose.Gis.SpatialReferencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.SpatialReferencingSystem
{
    public class ExportSpatialReferenceSystemToWKT
    {
        public static void Run()
        {
            //ExStart: ExportSpatialReferenceSystemToWKT
            var parameters = new ProjectedSpatialReferenceSystemParameters
            {
                Name = "WGS 84 / World Mercator",
                Base = SpatialReferenceSystem.Wgs84,
                ProjectionMethodName = "Mercator_1SP",
                LinearUnit = Unit.Meter,
                XAxis = new Axis("Easting", AxisDirection.East),
                YAxis = new Axis("Northing", AxisDirection.North),
                AxisesOrder = ProjectedAxisesOrder.XY,
            };
            parameters.AddProjectionParameter("central_meridian", 0);
            parameters.AddProjectionParameter("scale_factor", 1);
            parameters.AddProjectionParameter("false_easting", 0);
            parameters.AddProjectionParameter("false_northing", 0);

            var projectedSrs = SpatialReferenceSystem.CreateProjected(parameters, Identifier.Epsg(3395));

            string wkt = projectedSrs.ExportToWkt();
            Console.WriteLine(wkt);
            //ExEnd: ExportSpatialReferenceSystemToWKT
        }
    }
}
