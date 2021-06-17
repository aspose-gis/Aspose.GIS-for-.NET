using Aspose.Gis;
using Aspose.Gis.Formats.Gpx;
using Aspose.Gis.Geometries;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Linq;

namespace Aspose.GIS_for.NET.Layers
{
    public class GpxLayer
    {
        public static void Run()
        {
            ReadGPXFeatures();
            WriteGpxPolygonsAsLines();
            //CalculateAverageSpeedOfRoute();
        }

        private static void ReadGPXFeatures()
        {
            Console.WriteLine($"== Start Demo: {nameof(ReadGPXFeatures)}");
            var dataDir = RunExamples.GetDataDir();

            //ExStart: ReadGPXFeatures
            using (var layer = Drivers.Gpx.OpenLayer(dataDir + "schiehallion.gpx"))
            {
                foreach (var feature in layer)
                {
                    switch (feature.Geometry.GeometryType)
                    {
                        // GPX waypoints are exported as features with point geometry.
                        case GeometryType.Point:


                            Console.WriteLine(feature.Geometry.Dimension);
                            //HandleGpxWaypoint(feature);
                            break;
                        
                        // GPX routes are exported as features with line string geometry.
                        case GeometryType.LineString:

                            //HandleGpxRoute(feature);
                            LineString ls = (LineString)feature.Geometry;

                            foreach (var point in ls)
                            {
                                Console.WriteLine(point.AsText());
                            }
                            break;
                        
                            // GPX tracks are exported as features with multi line string geometry.
                        // Every track segment is line string.
                        case GeometryType.MultiLineString:

                            //HandleGpxTrack(feature);
                            Console.WriteLine(feature.Geometry.AsText());
                            break;
                        default: break;
                    }
                }
            }
            //ExEnd: ReadGPXFeatures
        }

        private static void WriteGpxPolygonsAsLines()
        {
            Console.WriteLine($"== Start Demo: {nameof(WriteGpxPolygonsAsLines)}");
            var dataDir = RunExamples.GetDataDir();

            //ExStart: WriteGpxPolygonsAsLines
            using (var layer = Drivers.Gpx.CreateLayer(dataDir + "lines_out.gpx", new GpxOptions()
            {
                WritePolygonsAsLines = true
            }))
            {
                // The GPX format does not support polygons,
                // but we use the WritePolygonsAsLines options to resolve this issue.
                Feature feature = layer.ConstructFeature();
                feature.Geometry = Geometry.FromText("POLYGON((1 2, 1 4, 3 4, 3 2))");
                layer.Add(feature);
            }
            //ExEnd: WriteGpxPolygonsAsLines
        }

        private static void CalculateAverageSpeedOfRoute()
        {
            Console.WriteLine($"== Start Demo: {nameof(CalculateAverageSpeedOfRoute)}");
            var dataDir = RunExamples.GetDataDir();

            //ExStart: CalculateAverageSpeedOfRoute
            var options = new GpxOptions { MAttribute = "speed" };
            using (var layer = Drivers.Gpx.OpenLayer(dataDir + "schiehallion.gpx"))
            {
                var routeFeature = layer.Single(feature => feature.Geometry.GeometryType == GeometryType.LineString);
                var routeGeometry = (ILineString)routeFeature.Geometry;
                // some route points might miss "speed", we filter them out.
                var pointsWithSpeed = routeGeometry.Where(point => point.HasM);
                // since we specified MAttribute = "speed", M coordinate of points is set to "<speed>" GPX attribute.
                double averageSpeed = pointsWithSpeed.Average(point => point.M);

                Console.WriteLine("Average Speed: " + averageSpeed);
            }
            //ExEnd: CalculateAverageSpeedOfRoute
        }
    }
}
