using Aspose.Gis.Rendering;
using Aspose.Gis.Rendering.Symbolizers;

namespace Geo.Advanced.Viewer.Logic
{
    public class StyleBuilder
    {
        public static SimpleLine CreateWayStyle()
        {
            return new SimpleLine()
            {
                Color = System.Drawing.Color.Peru,
                Style = StrokeStyle.Dash,
                Width = 3,
            };
        }

        public static SimpleMarker CreatePlaceStyle()
        {
            return new SimpleMarker()
            {
                Size = 10,
                StrokeWidth = 0,
                FillColor = System.Drawing.Color.Maroon,
                FeatureBasedConfiguration = (feature, symbolizer) =>
                {
                    var isMark = feature.GetValue<string>(nameof(PhotoModel.Mark));
                    if (isMark == PhotoModel.Marked)
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
