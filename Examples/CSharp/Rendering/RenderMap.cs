using Aspose.Gis;
using Aspose.Gis.Rendering;
using Aspose.Gis.Rendering.Symbolizers;
using Aspose.Gis.SpatialReferencing;
using Aspose.GIS.Examples.CSharp;
#if USE_ASPOSE_DRAWING
using Aspose.Drawing;
using Aspose.Drawing.Drawing2D;
using Aspose.Drawing.Text;
using Aspose.Drawing.Imaging;
#else
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;
#endif

using System.IO;
using System.Linq;

namespace Aspose.GIS_for.NET.Rendering
{
    public class RenderMap
    {
        private static string dataDir = RunExamples.GetDataDir();

        public static void Run()
        {
            // Note: a license is required to run this example. 
            // You can request a 30-day temporary license here: https://purchase.aspose.com/temporary-license
            var pathToLicenseFile = @""; // <- change this to the path to your license file
            if (!string.IsNullOrEmpty(pathToLicenseFile))
            {
                var license = new Aspose.Gis.License();
                license.SetLicense(pathToLicenseFile);
            }

            RenderWithDefaultSettings();
            RenderToSpecificProjection();
            AddMapLayersAndStyles();

            DefaultMarkerStyle();
            ChangeMarkerStyle();
            ChangeMarkerStyleTriangles();
            ChangeMarkerStyleFeatureBased();
            RasterImageMarkerSymbolizer();

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

            GeometryGenerator();

            ClusterMarkerSymbolizer();
            ClusterTextSymbolizer();
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

        public static void RasterImageMarkerSymbolizer()
        {
            //ExStart: RasterImageMarkerSymbolizer
            using (var map = new Map(500, 200))
            {
                var symbol = new RasterImageMarker(imagePath: dataDir + "cross.png")
                {
                    Width = 30,
                    Height = 30,
                    Rotation = 45,
                };

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbol);
                map.Padding = 20;
                map.Render(dataDir + "raster_marker_out.svg", Renderers.Svg);
            }
            //ExEnd: RasterImageMarkerSymbolizer
        }

        public static void ClusterMarkerSymbolizer()
        {
            //ExStart: ClusterMarkerSymbolizer
            using (var map = new Map(500, 300))
            {
                // take only part of the word
                map.Extent = new Extent(-100, -60, 100, 60){SpatialReferenceSystem = SpatialReferenceSystem.Wgs84};

                // use difference colors for nested cluster points.
                Color[] colors = new Color[] { Color.Green, Color.Aquamarine, Color.Gold, Color.Fuchsia, Color.Red, Color.Blue, Color.Brown, Color.Thistle, Color.Cyan, };
                var count = 0;

                // create a cluster symbolizer and setup a cluster size
                var symbolizer = new MarkerCluster(Measurement.Pixels(15))
                {
                    // use own a style for each a cluster
                    FeaturesBasedConfiguration = (features, cluster) =>
                    {
                        // use more size for more points 
                        var itemsInCluster = features.Count();
                        cluster.Marker = new SimpleMarker() {FillColor = Color.Red, Size = 3 + itemsInCluster % 10};

                        // allow draw inner cluster points (by default is none)
                        cluster.NestedMarker = new SimpleMarker() {FillColor = colors[count % colors.Length], Size = 3, StrokeStyle = StrokeStyle.None };
                        count++;
                    },
                };

                map.Add(VectorLayer.Open(dataDir + "land.shp", Drivers.Shapefile));
                map.Add(VectorLayer.Open(dataDir + "places.shp", Drivers.Shapefile), symbolizer);
                map.Padding = 20;
                map.Render(dataDir + "out_cluster_countries.svg", Renderers.Svg);
            }
            //ExEnd: ClusterMarkerSymbolizer
        }

        public static void ClusterTextSymbolizer()
        {
            //ExStart: ClusterTextSymbolizer
            using (var map = new Map(500, 300))
            {
                // take only part of the word
                map.Extent = new Extent(-100, -60, 100, 60) { SpatialReferenceSystem = SpatialReferenceSystem.Wgs84 };

                // create a cluster symbolizer and setup a cluster size
                var clusterSymbolizer = new MarkerCluster(Measurement.Pixels(25))
                {
                    // Use own a style for each a cluster
                    FeaturesBasedConfiguration = (features, cluster) =>
                    {
                        var itemsInCluster = features.Count();

                        // First, we create an image with a drawn number for the cluster. This code not optimized of memory using.
                        // It is better to load prepare pictures from your file system.
                        var digitText = itemsInCluster.ToString();
                        Stream memoryStream;
                      using (Bitmap digitBitmap = new Bitmap(40, 40))
                        {
                            using (Graphics graphics = Graphics.FromImage(digitBitmap))
                            {
                                // increase text quality
                                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                                if (digitText.Length == 1)
                                {
#if USE_ASPOSE_DRAWING
         graphics.DrawString(digitText, new Aspose.Drawing.Font("Arial", 30, GraphicsUnit.Pixel),
                                                                 new Aspose.Drawing.SolidBrush(Aspose.Drawing.Color.Black), 5, 3);

#else
                                    graphics.DrawString(digitText, new System.Drawing.Font("Arial", 30, GraphicsUnit.Pixel),
                                                                          new SolidBrush(Color.Black), 5, 3);
#endif
                                }
                                else
                                {
#if USE_ASPOSE_DRAWING
                                 graphics.DrawString(digitText, new Aspose.Drawing.Font("Arial", 30, GraphicsUnit.Pixel),
                                      new Aspose.Drawing.SolidBrush(Color.Black), -4, 3);
                                  
#else
                                    graphics.DrawString(digitText, new System.Drawing.Font("Arial", 30, GraphicsUnit.Pixel),
                                      new SolidBrush(Color.Black), -4, 3);
#endif

                                }

                                graphics.Flush();
                            }
                            // store the bitmap to a stream
                            memoryStream = new MemoryStream();
                            digitBitmap.Save(memoryStream, ImageFormat.Png);
                        }

                        var pathToDigit = AbstractPath.FromStream(memoryStream);

                        // Secondly, we use RasterImageMarker which renders our image (bitmap). 
                        var symbolizer = new RasterImageMarker(pathToDigit)
                        {
                            Width = Measurement.Pixels(12),
                            Height = Measurement.Pixels(12),
                            VerticalAnchorPoint = VerticalAnchor.Center,
                            HorizontalAnchorPoint = HorizontalAnchor.Center
                        };

                        // As result, we create a complex symbolizer to join a background circle and the drawn digit.
                        var complexMarker = new LayeredSymbolizer();
                        complexMarker.Add(new SimpleMarker() {Size = Measurement.Pixels(16), FillColor = Color.Azure});
                        complexMarker.Add(symbolizer);
                        cluster.Marker = complexMarker;
                    },
                };

                // add layers with symbolizers
                map.Padding = 20;
                map.Add(VectorLayer.Open(dataDir + "land.shp", Drivers.Shapefile), new SimpleLine(){Width = 0.5 });
                map.Add(VectorLayer.Open(dataDir + "places.shp", Drivers.Shapefile), clusterSymbolizer);
                // complete our map creation 
                map.Render(dataDir + "out_cluster_texts.svg", Renderers.Svg);
                      
        }
            //ExEnd: ClusterTextSymbolizer
              
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

        #region Geometry Generator
        public static void GeometryGenerator()
        {
            //ExStart: GeometryGenerator
            using (var map = new Map(500, 200))
            {
                var symbol = new GeometryGenerator
                {
                    Expression = f =>
                    {
                        return f.Geometry.GetBuffer(30_000);
                    },

                    Symbolizer = new SimpleFill
                    {
                        FillColor = Color.LightBlue,
                        StrokeColor = Color.Blue,
                    },
                };

                map.Add(VectorLayer.Open(dataDir + "points.geojson", Drivers.GeoJson), symbol);
                map.Padding = 20;
                map.SpatialReferenceSystem = SpatialReferenceSystem.WebMercator;
                map.Render(dataDir + "geometry_generator_out.svg", Renderers.Svg);
            }
            //ExEnd: GeometryGenerator
        }

        #endregion
    }
}
