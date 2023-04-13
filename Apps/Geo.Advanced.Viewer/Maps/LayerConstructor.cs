using System;
using System.Collections.Generic;
using Aspose.Gis;
using Aspose.Gis.Geometries;
using Geo.Advanced.Viewer.DataAccess;

namespace Geo.Advanced.Viewer.Maps
{
    /// <summary>
    /// Manages operations required to store json data.
    /// </summary>
    public class LayerConstructor
    {
        public VectorLayer CreateWayLayer(List<GeoPhoto> photoList)
        {
            var way = new LineString();
            foreach (var item in photoList)
            {
                way.AddPoint(item.Coordinate);
            }

            var wayLayer = Drivers.InMemory.CreateLayer();
            {
                var feature = wayLayer.ConstructFeature();
                feature.Geometry = way;
                wayLayer.Add(feature);
            }

            return wayLayer;
        }

        public VectorLayer CreatePlacesLayer(List<GeoPhoto> photoList)
        {
            var placeLayer = Drivers.InMemory.CreateLayer();

            placeLayer.Attributes.Add(new FeatureAttribute("Created", AttributeDataType.DateTime));
            placeLayer.Attributes.Add(new FeatureAttribute("IsBest", AttributeDataType.Boolean));
            foreach (var item in photoList)
            {
                var feature = placeLayer.ConstructFeature();
                feature.SetValue("Created", item.Created);
                feature.SetValue("IsBest", item.IsBest);
                feature.Geometry = item.Coordinate;
                placeLayer.Add(feature);
            }

            return placeLayer;
        }
    }
}
