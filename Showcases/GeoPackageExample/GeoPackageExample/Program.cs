using Aspose.Gis;
using Aspose.Gis.Formats.GeoPackage;
using Aspose.Gis.Rendering;
using Aspose.Gis.SpatialReferencing;
using System.Drawing;

using (var dataset = (GeoPackageDataset)Dataset.Open("ianFlooding.gpkg", Drivers.GeoPackage))
{
    Console.WriteLine($"Feature layers count: {dataset.LayersCount}");

    for (int i = 0; i < dataset.LayersCount; ++i)
    {
        using (var layer = dataset.OpenLayerAt(i))
        {
            Console.WriteLine($"Feature layer {i}: {dataset.GetLayerName(i)}:");
            var features = layer.ToDictionary(
                feature => feature, 
                feature => layer.Attributes.Select(x => $"{x.Name}: {feature.GetValue(x.Name)}").ToList());

            foreach (var feature in features)
            {
                feature.Value.Add($"Geometry: {feature.Key.Geometry}");
            }

            foreach (var feature in features.Values)
            {
                Console.WriteLine(string.Join(", ", feature));
            }
        }
    }


    var extent = new Extent(-20037508.3427892, -20037508.3427892, 20037508.3427892, 20037508.3427892)
    {
        SpatialReferenceSystem = SpatialReferenceSystem.WebMercator
    };

    using (var map = new Map(800, 800))
    {
        map.BackgroundColor = Color.Fuchsia;
        map.SpatialReferenceSystem = extent.SpatialReferenceSystem;
        map.Extent = extent;

        for (int i = 0; i < dataset.TileLayersCount; i++)
        {
            using (var layer = dataset.OpenTileLayerAt(i))
            {
                var tiles = layer.GetTiles(10, extent);

                foreach (var tile in tiles)
                {
                    var raster = tile.AsRaster();
                    map.Add(raster);
                }
            }
        }

        map.Render("map.png", Renderers.Png);
    }
}