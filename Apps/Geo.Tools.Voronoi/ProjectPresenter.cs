using System.Collections.Generic;
using System.Linq;
using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.Gis.GeoTools;

namespace Geo.Tools.Voronoi
{
    internal class ProjectPresenter
    {
        public List<LineString> MapRegularPoints(int count)
        {
            var geometries = GeoGenerator.ProducePoints(new Extent(0, 0, 100, 100),
                new PointGeneratorOptions() { Count = count, Place = GeneratorPlaces.Regular });

            var points = geometries.Select(t => (IPoint)t).ToList();
            var result = GeometryOperations.MakeVoronoiGraph(points);

            return result;
        }

        public List<LineString> MapRandomPoints(int count)
        {
            var geometries = GeoGenerator.ProducePoints(new Extent(0, 0, 100, 100),
                new PointGeneratorOptions() { Count = count, Place = GeneratorPlaces.Random });

            var points = geometries.Select(t => (IPoint)t).ToList();
            var result = GeometryOperations.MakeVoronoiGraph(points);

            return result;
        }
    }
}
