using System.Collections.Generic;
using Aspose.Gis.Geometries;
using Aspose.Gis;
using Aspose.Gis.GeoTools.Extensions;
using Aspose.Gis.GeoTools.WayAnalyzer;
using Geo.Viewer.WPF;
using System.IO;

namespace Geo.Tools.Paths
{
    internal class ProjectPresenter
    {
        public string ComplexFindWay()
        {
            // prepare net of roads.
            var roads = new List<RoadInfo>
            {
                // add fast roads
                new RoadInfo() { Segment = new LineString(new[] { new Point(0, 20), new Point(0, 220) }), Velocity = 30 },
                new RoadInfo() { Segment = new LineString(new[] { new Point(20, 20), new Point(180, 180) }), Velocity = 30 },
                new RoadInfo() { Segment = new LineString(new[] { new Point(20, 0), new Point(220, 0) }), Velocity = 30 },
                new RoadInfo() { Segment = new LineString(new[] { new Point(0, -20), new Point(0, -220) }), Velocity = 30 },
                
                // add ring 1 of slow roads
                new RoadInfo() { Segment = new LineString(new[] { new Point(0, 100), new Point(100, 100) }), Velocity = 10 },
                new RoadInfo() { Segment = new LineString(new[] { new Point(100, 100), new Point(100, 0) }), Velocity = 10 },
                new RoadInfo() { Segment = new LineString(new[] { new Point(100, 0), new Point(100, -100) }), Velocity = 10 },
                new RoadInfo() { Segment = new LineString(new[] { new Point(100, -100), new Point(0, -100) }), Velocity = 10 },

                // add ring 2 of slow roads
                new RoadInfo() { Segment = new LineString(new[] { new Point(0, 150), new Point(150, 150) }), Velocity = 10 },
                new RoadInfo() { Segment = new LineString(new[] { new Point(150, 150), new Point(150, 0) }), Velocity = 10 },
                new RoadInfo() { Segment = new LineString(new[] { new Point(150, 0), new Point(150, -150) }), Velocity = 10 },
                new RoadInfo() { Segment = new LineString(new[] { new Point(150, -150), new Point(0, -150) }), Velocity = 10 }
            };

            // add roads in way detector.
            var mapGeneratorOptions = new WayOptions();
            var generator = new WayLayerGenerator(mapGeneratorOptions);
            foreach (var road in roads)
            {
                generator.AddRoad(road.Segment[0] as Point, road.Segment[1] as Point, road.Velocity);
            }

            // look for seversl ways from star to goal points
            var resultWays = new List<LineString>();
            var startPoint = new Point(0, 0);
            var radius = 500;

            var goalPoint01 = new Point(170, 200);
            var way01 = generator.FindTheWay(startPoint, goalPoint01, radius);
            resultWays.Add(way01);

            var goalPoint02 = new Point(170, 10);
            var way02 = generator.FindTheWay(startPoint, goalPoint02, radius);
            resultWays.Add(way02);

            var goalPoint03 = new Point(170, -200);
            var way03 = generator.FindTheWay(startPoint, goalPoint03, radius);
            resultWays.Add(way03);


            // prepare roads layer (need to draw in a map)
            var roadsLayer = Drivers.InMemory.CreateLayer();
            roadsLayer.AddFeatures(roads);

            // prepare way layer (need to draw in a map)
            var wayLayer = Drivers.InMemory.CreateLayer();
            foreach (var way in resultWays)
            {
                Feature feature = wayLayer.ConstructFeature();
                feature.Geometry = way;
                wayLayer.Add(feature);
            }

            // create a map and save to file
            string filePath = GeometryOutput.SaveGeometryAsMap(roadsLayer, wayLayer, Path.GetFullPath("temp.jpg"));
            return filePath;
        }

        public class RoadInfo
        {
            public LineString Segment { get; set; }
            public int Velocity { get; set; }
        }
    }
}
