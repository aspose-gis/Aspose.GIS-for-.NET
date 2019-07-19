using Aspose.Gis;
using Aspose.Gis.Rendering;
using Aspose.Gis.Rendering.Symbolizers;
using Aspose.Gis.SpatialReferencing;
using Aspose.GIS.Examples.CSharp;
using System;
using System.Drawing;

namespace Aspose.GIS_for.NET.Rendering
{
    public class RenderMap
    {
        private static string dataDir = RunExamples.GetDataDir();

        public static void Run()
        {
            // Note: a license is required to run this example. 
            // You can request a 30-day temporary license here: https://purchase.aspose.com/temporary-license
            var pathToLicenseFile = ""; // <- change this to the path to your license file
            if (!string.IsNullOrEmpty(pathToLicenseFile))
            {
                var license = new License();
                license.SetLicense(pathToLicenseFile);
            }

            RenderWithDefaultSettings();
            RenderToSpecificProjection();
            AddMapLayersAndStyles();

            DefaultMarkerStyle();
            ChangeMarkerStyle();
            ChangeMarkerStyleTriangles();
            ChangeMarkerStyleFeatureBased();

            DefaultLineStyle();
            ChangeLineStyle();
            ChangeLineStyleComplex();
            MarkerLineSymbolizer();

            DefaultFillStyle();
            ChangeFillStyle();
            MarkerFillSymbolizer();

            MixedGeometryRendering();
            DrawLayeredSymbolizersByFeatures();
            DrawLayeredSymbolizersByLayers();
            RuleBasedRendering();

        }

        public static void RenderWithDefaultSettings()
        {
            //ExStart: RenderWithDefaultSettings
            using (var map = new Map(800, 400))
            {
                map.Add(VectorLayer.Open(dataDir + "land.shp", Drivers.Shapefile));
                map.Render(dataDir + "land_out.svg", Renderers.Svg);
            }
            //ExEnd: RenderWithDefaultSettings
        }

        public static void RenderToSpecificProjection()
        {
            //ExStart: RenderToSpecificProjection
            using (var map = new Map(800, 400))
            {
                map.Add(VectorLayer.Open(dataDir + "land.shp", Drivers.Shapefile));
                map.SpatialReferenceSystem = SpatialReferenceSystem.CreateFromEpsg(54024); // World Bonne
                map.Render(dataDir + "land_out.svg", Renderers.Svg);
            }
            //ExEnd: RenderToSpecificProjection
        }

        public static void AddMapLayersAndStyles()
        {
            //ExStart: AddMapLayersAndStyles
            using (var map = new Map(800, 476))
            {
                var baseMapSymbolizer = new SimpleFill { FillColor = Color.Salmon, StrokeWidth = 0.75 };
                map.Add(VectorLayer.Open(dataDir + "basemap.shp", Drivers.Shapefile), baseMapSymbolizer);

                var citiesSymbolizer = new SimpleMarker() { FillColor = Color.LightBlue };
                citiesSymbolizer.FeatureBasedConfiguration = (feature, symbolizer) =>
                {
                    var population = feature.GetValue<int>("population");
                    symbolizer.Size = 10 * population / 1000;
                    if (population < 2500)
                    {
                        symbolizer.FillColor = Color.GreenYellow;
                    }
                };
                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), citiesSymbolizer);

                map.Render(dataDir + "cities_out.svg", Renderers.Svg);
            }
            //ExEnd: AddMapLayersAndStyles
        }

        #region Marker

        public static void DefaultMarkerStyle()
        {
            //ExStart: DefaultMarkerStyle
            using (var map = new Map(500, 200))
            {
                var symbol = new SimpleMarker();

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbol);
                map.Padding = 20;
                map.Render(dataDir + "points_out.svg", Renderers.Svg);
            }
            //ExEnd: DefaultMarkerStyle
        }

        public static void ChangeMarkerStyle()
        {
            //ExStart: ChangeMarkerStyle
            using (var map = new Map(500, 200))
            {
                var symbol = new SimpleMarker() { Size = 7, StrokeWidth = 1, FillColor = Color.Red };

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbol);
                map.Padding = 20;
                map.Render(dataDir + "points_out.svg", Renderers.Svg);
            }
            //ExEnd: ChangeMarkerStyle
        }

        public static void ChangeMarkerStyleTriangles()
        {
            //ExStart: ChangeMarkerStyleTriangles
            using (var map = new Map(500, 200))
            {
                var symbol = new SimpleMarker()
                {
                    Size = 15,
                    FillColor = Color.DarkMagenta,
                    StrokeStyle = StrokeStyle.None,
                    ShapeType = MarkerShapeType.Triangle,
                    Rotation = 90
                };

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbol);
                map.Padding = 20;
                map.Render(dataDir + "points_out.svg", Renderers.Svg);
            }
            //ExEnd: ChangeMarkerStyleTriangles
        }

        public static void ChangeMarkerStyleFeatureBased()
        {
            //ExStart: ChangeMarkerStyleFeatureBased
            using (var map = new Map(500, 200))
            {
                var symbol = new SimpleMarker() { FillColor = Color.LightBlue };
                symbol.FeatureBasedConfiguration = (feature, symbolizer) =>
                {
                    // retirieve city population (in thousands) from a feature attribute
                    var population = feature.GetValue<int>("population");

                    // let's increase circle radius by 5 pixels for each million people
                    symbolizer.Size = 5 * population / 1000;

                    // and let's draw cities with less than 2.5M people in green
                    if (population < 2500)
                    {
                        symbolizer.FillColor = Color.GreenYellow;
                    }
                };

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbol);
                map.Padding = 20;
                map.Render(dataDir + "points_out.svg", Renderers.Svg);
            }
            //ExEnd: ChangeMarkerStyleFeatureBased
        }

        #endregion

        #region Line

        public static void DefaultLineStyle()
        {
            //ExStart: DefaultLineStyle
            using (var map = new Map(500, 317))
            {
                var symbolizer = new SimpleLine();

                map.Add(VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson), symbolizer);
                map.Render(dataDir + "lines_out.svg", Renderers.Svg);
            }
            //ExEnd: DefaultLineStyle
        }

        public static void ChangeLineStyle()
        {
            //ExStart: ChangeLineStyle
            using (var map = new Map(500, 317))
            {
                var symbolizer = new SimpleLine { Width = 1.5, Color = Color.FromArgb(0xAE, 0xD9, 0xFD) };

                map.Add(VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson), symbolizer);
                map.Render(dataDir + "lines_out.svg", Renderers.Svg);
            }
            //ExEnd: ChangeLineStyle
        }

        public static void ChangeLineStyleComplex()
        {
            //ExStart: ChangeLineStyleComplex
            using (var map = new Map(500, 317))
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

                map.Add(VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson), lineSymbolizer);
                map.Render(dataDir + "lines_out.svg", Renderers.Svg);
            }
            //ExEnd: ChangeLineStyleComplex
        }

        public static void MarkerLineSymbolizer()
        {
            //ExStart: MarkerLineSymbolizer
            using (var map = new Map(500, 317))
            {
                var symbolizer = new MarkerLine
                {
                    Marker = new SimpleMarker
                    {
                        ShapeType = MarkerShapeType.Circle,
                        FillColor = Color.Coral,
                        Size = 4
                    },
                    Interval = 10
                };

                map.Add(VectorLayer.Open(dataDir + "lines.geojson", Drivers.GeoJson), symbolizer);
                map.Render(dataDir + "marker_line_out.png", Renderers.Png);
            }
            //ExEnd: MarkerLineSymbolizer
        }

        #endregion

        #region Polygons

        public static void DefaultFillStyle()
        {
            //ExStart: DefaultFillStyle
            using (var map = new Map(500, 450))
            {
                var symbolizer = new SimpleFill();

                map.Add(VectorLayer.Open(dataDir + "polygons.geojson", Drivers.GeoJson), symbolizer);
                map.Render(dataDir + "polygons_out.svg", Renderers.Svg);
            }
            //ExEnd: DefaultFillStyle
        }

        public static void ChangeFillStyle()
        {
            //ExStart: ChangeFillStyle
            using (var map = new Map(500, 450))
            {
                var symbolizer = new SimpleFill { FillColor = Color.Azure, StrokeColor = Color.Brown };

                map.Add(VectorLayer.Open(dataDir + "polygons.geojson", Drivers.GeoJson), symbolizer);
                map.Render(dataDir + "polygons_out.svg", Renderers.Svg);
            }
            //ExEnd: ChangeFillStyle
        }

        public static void MarkerFillSymbolizer()
        {
            //ExStart: MarkerFillSymbolizer
            using (var map = new Map(500, 450))
            {
                var symbolizer = new MarkerPatternFill
                {
                    Marker = new SimpleMarker
                    {
                        ShapeType = MarkerShapeType.Triangle,
                        FillColor = Color.Red,
                        Size = 5
                    },
                    HorizontalInterval = 10,
                    VerticalInterval = 10
                };

                map.Add(VectorLayer.Open(dataDir + "polygons.geojson", Drivers.GeoJson), symbolizer);
                map.Render(dataDir + "polygons_marker_fill_out.png", Renderers.Png);
            }
            //ExEnd: MarkerFillSymbolizer
        }

        #endregion

        #region Mixed Geometry Symbolizer

        public static void MixedGeometryRendering()
        {
            //ExStart: MixedGeometryRendering
            using (var map = new Map(500, 210))
            {
                var symbolizer = new MixedGeometrySymbolizer();
                symbolizer.PointSymbolizer = new SimpleMarker { FillColor = Color.Red, Size = 10 };
                symbolizer.LineSymbolizer = new SimpleLine { Color = Color.Blue };
                symbolizer.PolygonSymbolizer = new SimpleFill { FillColor = Color.Green };

                map.Add(VectorLayer.Open(dataDir + "mixed.geojson", Drivers.GeoJson), symbolizer);
                map.Render(dataDir + "mixed_out.svg", Renderers.Svg);
            }
            //ExEnd: MixedGeometryRendering
        }

        #endregion

        #region Layered Symbolizer

        public static void DrawLayeredSymbolizersByFeatures()
        {
            //ExStart: DrawLayeredSymbolizersByFeatures
            using (var map = new Map(200, 200))
            {
                var symbolizer = new LayeredSymbolizer(RenderingOrder.ByFeatures);
                symbolizer.Add(new SimpleLine { Width = 10, Color = Color.Black });
                symbolizer.Add(new SimpleLine { Width = 8, Color = Color.White });

                map.Add(VectorLayer.Open(dataDir + "intersection.geojson", Drivers.GeoJson), symbolizer);
                map.Render(dataDir + "intersection_out.svg", Renderers.Svg);
            }
            //ExEnd: DrawLayeredSymbolizersByFeatures
        }

        public static void DrawLayeredSymbolizersByLayers()
        {
            //ExStart: DrawLayeredSymbolizersByLayers
            using (var map = new Map(200, 200))
            {
                var symbolizer = new LayeredSymbolizer(RenderingOrder.ByLayers);
                symbolizer.Add(new SimpleLine { Width = 10, Color = Color.Black });
                symbolizer.Add(new SimpleLine { Width = 8, Color = Color.White });

                map.Add(VectorLayer.Open(dataDir + "intersection.geojson", Drivers.GeoJson), symbolizer);
                map.Render(dataDir + "intersection_out.svg", Renderers.Svg);
            }
            //ExEnd: DrawLayeredSymbolizersByLayers
        }

        #endregion

        #region Rule-based Symbolizer

        public static void RuleBasedRendering()
        {
            //ExStart: RuleBasedRendering
            using (var map = new Map(600, 400))
            {
                var symbolizer = new RuleBasedSymbolizer();
                symbolizer.Add(f => f.GetValue<string>("sov_a3") == "CAN", new SimpleLine { Color = Color.FromArgb(213, 43, 30) });
                symbolizer.Add(f => f.GetValue<string>("sov_a3") == "USA", new SimpleLine { Color = Color.FromArgb(15, 71, 175) });
                symbolizer.Add(f => f.GetValue<string>("sov_a3") == "MEX", new SimpleLine { Color = Color.FromArgb(0, 104, 71) });
                symbolizer.Add(f => f.GetValue<string>("sov_a3") == "CUB", new SimpleLine { Color = Color.FromArgb(255, 215, 0) });

                map.Add(VectorLayer.Open(dataDir + "railroads.shp", Drivers.Shapefile), symbolizer);
                map.Render(dataDir + "railroads_out.svg", Renderers.Svg);
            }
            //ExEnd: RuleBasedRendering
        }

        #endregion
    }
}
