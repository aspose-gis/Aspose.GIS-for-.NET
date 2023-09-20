using Aspose.Gis;
using Aspose.Gis.Geometries;
using Geo.Layers.Join.Models;
using System.Collections.Generic;
using System.IO;

namespace Geo.Layers.Join
{
    internal class ProjectPresenter
    {
        public VectorLayer JoinByIndex()
        {
            var layerConstructor = new LayerConstructor();
            List<LayerData> geometries = new List<LayerData>
            {
            new LayerData(){Id=1, Summary="3483 Burke Street", Geometry=Geometry.FromText("POINT(2 3)"), Price="99.64K/m2"},
            new LayerData(){Id=2, Summary="865 Archwood Avenue", Geometry=Geometry.FromText("POINT(1 1)"), Price="105.31K/m2"},
            new LayerData(){Id=3, Summary="528 Milford Street", Geometry=Geometry.FromText("POINT(2 6)"), Price="130.56K/m2"}
            };

            layerConstructor.CreateDateBuildLayer();
            var geoLayer = layerConstructor.CreateGeometryLayer(geometries);

            var resLayer = layerConstructor.JoinLayersById(geoLayer);

            return resLayer;
        }

        public VectorLayer JoinByCoords()
        {
            var layerConstructor = new LayerConstructor();
            List<LayerData> geometries1 = new List<LayerData>
            {
            new LayerData(){Id=1, Summary="3483 Burke Street", Geometry=Geometry.FromText("POINT(2 3)"), Price="99.64K/m2"},
            new LayerData(){Id=2, Summary="865 Archwood Avenue", Geometry=Geometry.FromText("POINT(1 1)"), Price="105.31K/m2"},
            new LayerData(){Id=3, Summary="528 Milford Street", Geometry=Geometry.FromText("POINT(2 6)"), Price="130.56K/m2"}
            };

            List<LayerData> geometries2 = new List<LayerData>
            {
            new LayerData(){Id=4, Summary="3483 Burke Street", Geometry=Geometry.FromText("POINT(2.002 3.002)"), Price="99.64K/m2"},
            new LayerData(){Id=5, Summary="768 Woodland Terrace", Geometry=Geometry.FromText("POINT(7 4)"), Price="105.31K/m2"},
            new LayerData(){Id=7, Summary="2559 Fire Access Road", Geometry=Geometry.FromText("POINT(9 1)"), Price="130.56K/m2"}
            };

            var layer1 = layerConstructor.CreateGeometryLayer(geometries1);
            var layer2 = layerConstructor.CreateGeometryLayer(geometries2);

            var resLayer = layerConstructor.JoinLayersByCoords(layer1, layer2, "Geometry");

            return resLayer;
        }
    }

    public class RunExamples
    {
        public static string? GetFolderDir(string folderName = "Data")
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return startDirectory != null ? Path.Combine(startDirectory, folderName + "\\") : null;
        }
    }
}
