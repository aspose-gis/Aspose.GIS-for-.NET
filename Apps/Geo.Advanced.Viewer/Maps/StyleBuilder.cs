using Aspose.Gis.Rendering;
using Aspose.Gis.Rendering.Symbolizers;

namespace Geo.Advanced.Viewer.Maps
{
    public class StyleBuilder
    {
        public static SimpleLine CreateWayStyle()
        {
            return new SimpleLine()
            {
                Color = System.Drawing.Color.Peru,
                Style = StrokeStyle.Dash,
                Width = 3 * 1,
            };
        }

        public static SimpleMarker CreatePlaceStyle()
        {
            return new SimpleMarker()
            {
                Size = 7 * 1.5,
                StrokeWidth = 0,
                FillColor = System.Drawing.Color.Maroon,
                FeatureBasedConfiguration = (feature, symbolizer) =>
                {
                    var isBest = feature.GetValue<bool>("IsBest");
                    if (isBest)
                    {
                        symbolizer.FillColor = System.Drawing.Color.Red;
                        symbolizer.Size = symbolizer.Size * 2;
                        symbolizer.ShapeType = MarkerShapeType.Star;
                    }
                }
            };
        }
    }
}
