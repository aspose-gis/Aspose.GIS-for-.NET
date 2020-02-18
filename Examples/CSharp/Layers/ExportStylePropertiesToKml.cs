using System.Collections.Generic;
using System.Drawing;
using Aspose.Gis;
using Aspose.GIS.Examples.CSharp;
using Aspose.Gis.Formats.Kml.Styles;
using Aspose.Gis.Geometries;
using Point = Aspose.Gis.Geometries.Point;

namespace Aspose.GIS_for.NET.Layers
{
    class ExportStylePropertiesToKml
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir();

            //ExStart: ExportStylePropertiesToKml
            using (var layer = Drivers.Kml.CreateLayer(dataDir + "Kml_Styles_out.kml"))
            {
                var style = new KmlFeatureStyle
                {
                    Line = new KmlLineStyle() { Width = 2.0 },
                    Polygon = new KmlPolygonStyle() { Outline = false },
                    Icon = new KmlIconStyle() {Resource = new KmlIconResource() {Href = "url"}},
                    Label = new KmlLabelStyle() {Color = Color.Green},
                    Balloon = new KmlBalloonStyle() { BackgroundColor = Color.Aqua, Text = "Example" },
                    List = new KmlListStyle() { ItemType = KmlItemTypes.RadioFolder },
                };

                Feature feature = layer.ConstructFeature();
                feature.Geometry = new LineString(new[] { new Point(0, 0), new Point(1, 1) });
                layer.Add(feature, style);

                Feature feature2 = layer.ConstructFeature();
                feature2.Geometry = new Point(5, 5);

                layer.Add(feature2, style);
            }
            //ExEnd: ExportStylePropertiesToKml
        }
    }
}