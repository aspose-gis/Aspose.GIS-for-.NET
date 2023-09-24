using System.Collections.Generic;
using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.Gis.GeoTools.Extensions;
using Aspose.Gis.Relationship.Joins;
using Geo.Layers.Join.Models;

namespace Geo.Layers.Join
{
    internal class ProjectPresenter
    {
        public (VectorLayer layerA, VectorLayer layerB, VectorLayer joinedLaeyr) JoinByIndex()
        {
            // create layer with main data
            List<LayerMainData> mainData = new List<LayerMainData>
            {
            new LayerMainData(){Id=1, Summary="3483 Burke Street", Geometry=Geometry.FromText("POINT(2 3)")},
            new LayerMainData(){Id=2, Summary="865 Archwood Avenue", Geometry=Geometry.FromText("POINT(1 1)")},
            new LayerMainData(){Id=3, Summary="528 Milford Street", Geometry=Geometry.FromText("POINT(2 6)")}
            };
            var mainLayer = Drivers.InMemory.CreateLayer();
            mainLayer.AddFeatures(mainData);            

            // create layer with append data
            List<LayerApendData> appendData = new List<LayerApendData>
            {
            new LayerApendData(){Idx=1, Summary="Burke Street", Price="132 000 $"},
            new LayerApendData(){Idx=3, Summary="Milford Street", Price="252 000 $"},
            };
            var appendLayer = Drivers.InMemory.CreateLayer();
            appendLayer.AddFeatures(appendData);

            // join layers using attribute field
            var joinOptions = new JoinOptions
            {
                TargetAttributeName = "Id",
                JoinAttributeName = "Idx",
            };
            var joined = mainLayer.Join(appendLayer, joinOptions);

            return (mainLayer, appendLayer, joined);
        }

        public (VectorLayer layerA, VectorLayer layerB, VectorLayer joinedLaeyr) JoinByCoords()
        {
            // create layer with main data
            var mainData = new List<LayerMainData>
            {
            new LayerMainData(){Id=1, Summary="3483 Burke Street", Geometry=Geometry.FromText("POINT(2 3)")},
            new LayerMainData(){Id=2, Summary="865 Archwood Avenue", Geometry=Geometry.FromText("POINT(1 1)")},
            new LayerMainData(){Id=3, Summary="528 Milford Street", Geometry=Geometry.FromText("POINT(2 6)")}
            };
            var mainLayer = Drivers.InMemory.CreateLayer();
            mainLayer.AddFeatures(mainData);

            // create layer with append data
            var appendData = new List<LayerMainData>
            {
            new LayerMainData(){Id=111, Summary="About Burke", Geometry=Geometry.FromText("POINT(2.01 3)")},
            new LayerMainData(){Id=222, Summary="About Archwood", Geometry=Geometry.FromText("POINT(1.01 1)")},
            new LayerMainData(){Id=333, Summary="About Milford", Geometry=Geometry.FromText("POINT(2.01 6)")}
            };
            var appendLayer = Drivers.InMemory.CreateLayer();
            appendLayer.AddFeatures(appendData);

            // join layers using geometry field
            var joinOptions = new JoinByGeometryOptions { Radius = 0.1f };
            var joined = mainLayer.JoinByGeometry(appendLayer, joinOptions);
            return (mainLayer, appendLayer, joined);
        }
    }
}
