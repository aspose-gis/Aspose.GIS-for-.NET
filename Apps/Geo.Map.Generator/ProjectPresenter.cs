using Aspose.Gis.Geometries;
using Aspose.Gis.GeoTools;
using Aspose.Gis;
using System.Collections.Generic;
using System.Linq;

namespace Geo.Map.Generator
{
    internal class ProjectPresenter
    {
        public List<IGeometry> MapPoints(int count)
        {
            IEnumerable<IGeometry> geometries = GeoGenerator.ProducePoints(new Extent(0, 0, 100, 100),
                        new PointGeneratorOptions()
                        {
                            Count = count,
                            Place = GeneratorPlaces.Random
                        });
            var current = geometries.ToList();

            return current;
        }

        public List<IGeometry> MapPolygons(int count)
        {
            IEnumerable<IGeometry> geometries = GeoGenerator.ProducePolygons(new Extent(0, 0, 100, 100),
                        new PolygonGeneratorOptions()
                        {
                            Count = count,
                            Place = GeneratorPlaces.Random
                        });
            var current = geometries.ToList();

            return current;
        }

        public List<IGeometry> MapLines(int count)
        {
            IEnumerable<IGeometry> geometries = GeoGenerator.ProduceLines(new Extent(0, 0, 100, 100),
            new LineGeneratorOptions()
            {
                Count = count,
                Place = GeneratorPlaces.Random
            });
            var current = geometries.ToList();

            return current;
        }
    }
}
