using System;
using System.IO;
using Aspose.Gis;
using Aspose.Gis.Rendering;
using Aspose.Gis.SpatialReferencing;
using Aspose.Gis.GeoTools.LayersMap;
using Aspose.Gis.Rendering.Labelings;
using Aspose.Gis.Geometries;
using Aspose.Gis.GeoTools.Extensions;
using System.Collections.Generic;
using System.Linq;
using Geo.Advanced.Viewer.Logic;

namespace Geo.Advanced.Viewer
{
    /// <summary>
    /// Manages operations required to display layers in different forms and styles.
    /// </summary>
    internal class ProjectPresenter
    {
        public (VectorLayer placeLayer, MemoryStream mapFileName) CreateMap()
        {
            var storage = new PhotoStorage();
            var photoList = storage.LoadPhotos();

            var placeLayer = CreatePlacesLayer(photoList);
            var wayLayer = CreateWayLayer(photoList);
            var mapStream = CreateMap(placeLayer, wayLayer);

            return (placeLayer, mapStream);
        }

        private static MemoryStream CreateMap(VectorLayer placesLayer, VectorLayer wayLayer, int mapSize = 512)
        {
            string tilesUrl = "https://tile.openstreetmap.org/{z}/{x}/{y}.png";

            var opt = new MapOptions();
            opt.SpatialReference = SpatialReferenceSystem.WebMercator;
            opt.Renderer = Renderers.Png;
            opt.SizeMode = MapSizeModes.Auto;
            opt.Width = mapSize;
            opt.Height = mapSize;
            opt.Layers = new MapLayerOptions[]
            {
                new MapLayerOptions() { Layer = wayLayer, Symbolyzer = StyleBuilder.CreateWayStyle(), Labeling = Labeling.Null, LayerSpatialRefSys = SpatialReferenceSystem.Wgs84 },
                new MapLayerOptions() { Layer = placesLayer, Symbolyzer = StyleBuilder.CreatePlaceStyle(), Labeling = Labeling.Null, LayerSpatialRefSys = SpatialReferenceSystem.Wgs84 }
            };
            opt.Tiles = new MapTilesOptions() { Url = tilesUrl, Level = 13 };

            return LayersMapBuilder.CreateMap(opt);
        }

        private static VectorLayer CreateWayLayer(List<PhotoModel> photoList)
        {
            var way = new LineString(photoList.Select(t => t.Coordinate));
            var wayHolder = new List<GeoHolder>() { new GeoHolder() { Coordinate = way } };
            var wayLayer = Drivers.InMemory.CreateLayer();
            wayLayer.AddFeatures(wayHolder);

            return wayLayer;
        }

        private static VectorLayer CreatePlacesLayer(List<PhotoModel> photoList)
        {
            var placeLayer = Drivers.InMemory.CreateLayer();
            placeLayer.AddFeatures(photoList);

            return placeLayer;
        }

        private class GeoHolder
        {
            public Geometry Coordinate { get; set; }
        }
    }
}
