using Aspose.Gis;
using Aspose.Gis.Formats.Shapefile;
using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    public class CreateVectorLayerWithSpatialReferenceSystem
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();

            //ExStart: CreateVectorLayerWithSpatialReferenceSystem
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

            using (var layer = Drivers.Shapefile.Create(dataDir + "filepath_out.shp", new ShapefileOptions(), projectedSrs))
            {
                var feature = layer.ConstructFeature();
                feature.Geometry = new Point(1, 2);
                layer.Add(feature);

                feature = layer.ConstructFeature();
                feature.Geometry = new Point(1, 2) { SpatialReferenceSystem = SpatialReferenceSystem.Nad83 };
                try
                {
                    layer.Add(feature); // geometry of feature has different SRS - exception is thrown
                }
                catch (GisException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            using (var layer = Drivers.Shapefile.Open(dataDir + "filepath_out.shp"))
            {
                var srsName = layer.SpatialReferenceSystem.Name; // "WGS 84 / World Mercator"
                layer.SpatialReferenceSystem.IsEquivalent(projectedSrs); // true
            }
            //ExEnd: CreateVectorLayerWithSpatialReferenceSystem
        }

    }
}
