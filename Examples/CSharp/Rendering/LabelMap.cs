using System;
#if USE_ASPOSE_DRAWING
using Aspose.Drawing;
#else
using System.Drawing;
#endif
using Aspose.Gis;
using Aspose.Gis.Rendering;
using Aspose.Gis.Rendering.Labelings;
using Aspose.Gis.Rendering.Symbolizers;
using Aspose.GIS.Examples.CSharp;
using FontStyle = Aspose.Gis.Rendering.Labelings.FontStyle;

namespace Aspose.GIS_for.NET.Rendering
{
    public class LabelMap
    {
        private static string dataDir = RunExamples.GetDataDir();

        public static void Run()
        {
            // Note: a license is required to run this example. 
            // You can request a 30-day temporary license here: https://purchase.aspose.com/temporary-license
            var pathToLicenseFile = ""; // <- change this to the path to your license file
            if (!string.IsNullOrEmpty(pathToLicenseFile))
            {
                var license = new Aspose.Gis.License();
                license.SetLicense(pathToLicenseFile);
            }

            PointsLabeling();
            PointsLabelingStyled();
            PointsLabelingPlaced();
            PointsLabelingFeatureBased();

            LinesLabeling();
            LinesLabelingParallel();
            LinesLabelingCurved();
            LinesLabelingCurvedWithOffset();
            LinesLabelingFeatureBased();

            RuleBasedLabeling();
        }

        #region Points Labeling

        public static void PointsLabeling()
        {
            //ExStart: PointsLabeling
            using (var map = new Map(500, 200))
            {
                var symbol = new SimpleMarker
                {
                    FillColor = Color.LightGray,
                    StrokeStyle = StrokeStyle.None
                };

                var labeling = new SimpleLabeling(labelAttribute: "name");

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbol, labeling);
                map.Padding = 50;
                map.Render(dataDir + "points_labeling_out.svg", Renderers.Svg);
            }
            //ExEnd: PointsLabeling
        }

        public static void PointsLabelingStyled()
        {
            //ExStart: PointsLabelingStyled
            using (var map = new Map(500, 200))
            {
                var symbol = new SimpleMarker
                {
                    FillColor = Color.LightGray,
                    StrokeStyle = StrokeStyle.None
                };

                var labeling = new SimpleLabeling(labelAttribute: "name")
                {
                    HaloSize = 2,
                    HaloColor = Color.LightGray,
                    FontSize = 15,
                    FontStyle = FontStyle.Italic,
                };

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbol, labeling);
                map.Padding = 50;
                map.Render(dataDir + "points_labeling_styled_out.svg", Renderers.Svg);
            }
            //ExEnd: PointsLabelingStyled
        }

        public static void PointsLabelingPlaced()
        {
            //ExStart: PointsLabelingPlaced
            using (var map = new Map(500, 200))
            {
                var symbol = new SimpleMarker
                {
                    FillColor = Color.LightGray,
                    StrokeStyle = StrokeStyle.None
                };

                var labeling = new SimpleLabeling(labelAttribute: "name")
                {
                    HaloSize = 1,
                    Placement = new PointLabelPlacement
                    {
                        VerticalAnchorPoint = VerticalAnchor.Bottom,
                        HorizontalAnchorPoint = HorizontalAnchor.Left,
                        HorizontalOffset = 2,
                        VerticalOffset = 2,
                        Rotation = 10,
                    }
                };

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbol, labeling);
                map.Padding = 50;
                map.Render(dataDir + "points_labeling_placed_out.svg", Renderers.Svg);
            }
            //ExEnd: PointsLabelingPlaced
        }

        public static void PointsLabelingFeatureBased()
        {
            //ExStart: PointsLabelingFeatureBased
            using (var map = new Map(500, 200))
            {
                var pointLabeling = new SimpleLabeling("name")
                {
                    HaloSize = 1,

                    Placement = new PointLabelPlacement
                    {
                        VerticalAnchorPoint = VerticalAnchor.Bottom,
                        HorizontalAnchorPoint = HorizontalAnchor.Left,
                        VerticalOffset = 4,
                        HorizontalOffset = 4,
                    },

                    FeatureBasedConfiguration = (feature, labeling) =>
                    {
                        // Retrieve population from the feature.
                        var population = feature.GetValue<int>("population");
                        // Font size is computed and is based on the population.
                        labeling.FontSize = Math.Min(20, 5 * population / 1000);
                        // Priority of the label is also based on the population.
                        // The greater the priority is, the more likely label will appear on the output image.
                        labeling.Priority = population;
                    }
                };


                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), new SimpleMarker(), pointLabeling);
                map.Padding = 50;
                map.Render(dataDir + "points_labeling_feature_based_out.svg", Renderers.Svg);
            }
            //ExEnd: PointsLabelingFeatureBased
        }

        #endregion

        #region Lines Labeling

        public static void LinesLabeling()
        {
            //ExStart: LinesLabeling
            using (var map = new Map(1000, 634))
            {
                var symbolizer = new SimpleLine { Width = 1.5, Color = Color.FromArgb(0xAE, 0xD9, 0xFD) };

                var labeling = new SimpleLabeling(labelAttribute: "name");

                map.Add(VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson), symbolizer, labeling);
                map.Padding = 50;
                map.Render(dataDir + "lines_labeling_out.svg", Renderers.Svg);
            }
            //ExEnd: LinesLabeling
        }

        public static void LinesLabelingParallel()
        {
            //ExStart: LinesLabelingParallel
            using (var map = new Map(1000, 634))
            {
                var symbolizer = new SimpleLine { Width = 1.5, Color = Color.FromArgb(0xAE, 0xD9, 0xFD) };

                var labeling = new SimpleLabeling(labelAttribute: "name")
                {
                    HaloSize = 1,
                    Placement = new LineLabelPlacement
                    {
                        Alignment = LineLabelAlignment.Parallel,
                    }
                };

                map.Add(VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson), symbolizer, labeling);
                map.Padding = 50;
                map.Render(dataDir + "lines_labeling_parallel_out.svg", Renderers.Svg);
            }
            //ExEnd: LinesLabelingParallel
        }

        public static void LinesLabelingCurved()
        {
            //ExStart: LinesLabelingCurved
            using (var map = new Map(1000, 634))
            {
                var symbolizer = new SimpleLine { Width = 1.5, Color = Color.FromArgb(0xAE, 0xD9, 0xFD) };

                var labeling = new SimpleLabeling(labelAttribute: "name")
                {
                    HaloSize = 1,
                    Placement = new LineLabelPlacement
                    {
                        Alignment = LineLabelAlignment.Curved,
                    }
                };

                map.Add(VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson), symbolizer, labeling);
                map.Padding = 50;
                map.Render(dataDir + "lines_labeling_curved_out.svg", Renderers.Svg);
            }
            //ExEnd: LinesLabelingCurved
        }

        public static void LinesLabelingCurvedWithOffset()
        {
            //ExStart: LinesLabelingCurvedWithOffset
            using (var map = new Map(1000, 634))
            {
                var symbolizer = new SimpleLine { Width = 1.5, Color = Color.FromArgb(0xAE, 0xD9, 0xFD) };

                var labeling = new SimpleLabeling(labelAttribute: "name")
                {
                    HaloSize = 1,
                    Placement = new LineLabelPlacement
                    {
                        Alignment = LineLabelAlignment.Curved,
                        Offset = 5,
                    }
                };

                map.Add(VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson), symbolizer, labeling);
                map.Padding = 50;
                map.Render(dataDir + "lines_labeling_curved_offset_out.svg", Renderers.Svg);
            }
            //ExEnd: LinesLabelingCurvedWithOffset
        }

        public static void LinesLabelingFeatureBased()
        {
            //ExStart: LinesLabelingFeatureBased
            using (var map = new Map(1000, 634))
            {
                var lineSymbolizer = new SimpleLine { Width = 1.5, Color = Color.FromArgb(0xae, 0xd9, 0xfd) };
                lineSymbolizer.FeatureBasedConfiguration = (feature, symbolizer) =>
                {
                    if (feature.GetValue<string>("NAM") == "UNK")
                    {
                        symbolizer.Width = 1;
                        symbolizer.Style = StrokeStyle.Dash;
                    }
                };


                var lineLabeling = new SimpleLabeling(labelAttribute: "name")
                {
                    HaloSize = 1,
                    Placement = new LineLabelPlacement
                    {
                        Alignment = LineLabelAlignment.Parallel,
                    },
                    FontSize = 20,
                    FeatureBasedConfiguration = (feature, labeling) =>
                    {
                        if (feature.GetValue<string>("NAM") == "UNK")
                        {
                            // change labeling properties for some features.
                            labeling.FontStyle = FontStyle.Italic;
                            labeling.FontSize = 10;
                            labeling.Priority = -1;

                            var placement = (LineLabelPlacement) labeling.Placement;
                            placement.Alignment = LineLabelAlignment.Curved;
                            placement.Offset = 5;
                        }
                    }
                };

                map.Add(VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson), lineSymbolizer, lineLabeling);
                map.Padding = 50;
                map.Render(dataDir + "lines_labeling_feature_based_out.svg", Renderers.Svg);
            }
            //ExEnd: LinesLabelingFeatureBased
        }

        #endregion

        public static void RuleBasedLabeling()
        {
            //ExStart: RuleBasedLabeling
            using (var map = new Map(500, 200))
            {
                var symbolizer = new SimpleMarker {FillColor = Color.LightGray, StrokeStyle = StrokeStyle.None};

                var labeling = new RuleBasedLabeling();
                // Set labeling to be used for small cities.
                labeling.Add(f => f.GetValue<int>("population") <= 2500, new SimpleLabeling("name")
                {
                    FontStyle = FontStyle.Italic,
                    HaloSize = 1,
                    FontSize = 10,
                    FontColor = Color.Green,
                    Priority = 1,
                    Placement = new PointLabelPlacement
                    {
                        VerticalAnchorPoint = VerticalAnchor.Bottom,
                        HorizontalAnchorPoint = HorizontalAnchor.Center,
                    }
                });
                // Set labeling to be used for all other cities.
                labeling.AddElseRule(new SimpleLabeling("name")
                {
                    HaloSize = 1,
                    FontSize = 15,
                    FontColor = Color.Red,
                    Priority = 2,
                    Placement = new PointLabelPlacement
                    {
                        VerticalAnchorPoint = VerticalAnchor.Bottom,
                        HorizontalAnchorPoint = HorizontalAnchor.Center,
                    }
                });

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbolizer, labeling);
                map.Padding = 40;
                map.Render(dataDir + "rule_based_labeling_out.svg", Renderers.Svg);
            }
            //ExEnd: RuleBasedLabeling

        }
    }
}