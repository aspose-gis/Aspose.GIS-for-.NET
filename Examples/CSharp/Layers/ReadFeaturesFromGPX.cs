using Aspose.Gis;
using Aspose.Gis.Formats.Gpx;
using Aspose.Gis.Geometries;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.GIS_for.NET.Layers
{
    public class ReadFeaturesFromGPX
    {
        static string dataDir = RunExamples.GetDataDir();

        public static void Run()
        {
            ReadGPXFeatures();

            //CalculateAverageSpeedOfRoute();

        }

        private static void ReadGPXFeatures()
        {
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

        private static void CalculateAverageSpeedOfRoute()
        {
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
