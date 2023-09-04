using System.Drawing;
using Aspose.Gis.Geometries;
using Aspose.Gis.Rendering;
using Aspose.Gis;
using Point = Aspose.Gis.Geometries.Point;
using Aspose.Gis.Rendering.Symbolizers;

namespace Geo.Map.Rendering
{
    internal class ProjectPresenter
    {
        public string RenderGeometrySelfColor()
        {
            // Get available file name
            var fileName = "output";
            var fileExtension = ".png";
            var availableFileName = fileName;
            int j = 0;
            while (System.IO.File.Exists(availableFileName + fileExtension))
            {
                availableFileName = fileName + j;
                j++;
            }

            // Create a geometry collection with different geometries
            var geometryCollection = new GeometryCollection
            {
                new Point(10, 20),
                new LineString(new[] {new Point(30, 40), new Point(50, 60)}),
                new Polygon(new LinearRing(new[] {new Point(70, 80), new Point(110, 120), new Point(100, 120), new Point(70, 80)}))
            };

            // Define colors for each geometry
            var colors = new[] { Color.Red, Color.Green, Color.Blue };

            // Create in memory layer to map each geometry with its respective color
            var layer = Drivers.InMemory.CreateLayer();
            layer.Attributes.Add(new FeatureAttribute("Color", AttributeDataType.Integer));
            for (int i = 0; i < geometryCollection.Count; i++)
            {
                // Create a feature and add it to the layer
                var feature = layer.ConstructFeature();
                feature.SetValue("Color", colors[i].ToArgb());
                feature.Geometry = geometryCollection[i];
                layer.Add(feature);
            }

            // Create a new map instance
            using (var map = new Aspose.Gis.Rendering.Map(200, 200))
            {
                map.Padding = 5;

                var pointSymbolizer = new SimpleMarker
                {
                    FeatureBasedConfiguration = (feature, symbolizer) =>
                {
                    int color = feature.GetValue<int>("Color");
                    symbolizer.FillColor = Color.FromArgb(color);
                }
                };

                var lineSymbolizer = new SimpleLine
                {
                    FeatureBasedConfiguration = (feature, symbolizer) =>
                    {
                        int color = feature.GetValue<int>("Color");
                        symbolizer.Color = Color.FromArgb(color);
                    }
                };

                var poligonSymbolizer = new SimpleFill
                {
                    FeatureBasedConfiguration = (feature, symbolizer) =>
                    {
                        int color = feature.GetValue<int>("Color");
                        symbolizer.FillColor = Color.FromArgb(color);
                    }
                };

                map.Add(layer, new MixedGeometrySymbolizer() { PointSymbolizer = pointSymbolizer, LineSymbolizer = lineSymbolizer, PolygonSymbolizer = poligonSymbolizer });
                map.Render(availableFileName + fileExtension, Renderers.Jpeg);
            }

            return availableFileName + fileExtension;
        }
    }
}
