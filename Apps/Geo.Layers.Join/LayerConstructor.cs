using Aspose.Gis;
using Aspose.Gis.GeoTools.Extensions;
using Aspose.Gis.Relationship.Joins;
using Geo.Layers.Join.Models;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Geo.Layers.Join
{
    /// <summary>
    /// Manages operations required to store json data.
    /// </summary>
    class LayerConstructor
    {
        private VectorLayer dateBuildLayer;
        //private VectorLayer geometryLayer;

        public string CreateDateBuildLayer()
        {
            string jsonString = File.ReadAllText(Path.Combine(RunExamples.GetFolderDir("Data"), "test.json"));
            BuildingsInfo[] buildingsInfo = JsonSerializer.Deserialize<BuildingsInfo[]>(jsonString);

            dateBuildLayer = Drivers.InMemory.CreateLayer();
            dateBuildLayer.AddFeatures(buildingsInfo.ToList());

            return LayerToString(dateBuildLayer);
        }

        public VectorLayer CreateGeometryLayer(List<LayerData> geometries)
        {
            var geometryLayer = Drivers.InMemory.CreateLayer();
            geometryLayer.AddFeatures(geometries);

            return geometryLayer;
        }

        public VectorLayer JoinLayersById(VectorLayer geometryLayer, string? joinAttributeName = "Id")
        {
            if (dateBuildLayer == null || geometryLayer == null)
            {
                throw new Exception("One of the Geometry layers is missing. Please create them first.");
            }

            // Check if joinAttributeName exists in both layers
            if (!dateBuildLayer.Attributes.Contains(joinAttributeName) || !geometryLayer.Attributes.Contains(joinAttributeName))
            {
                throw new Exception($"Attribute '{joinAttributeName}' does not exist in one or both of the layers.");
            }

            var joinOptions = new JoinOptions
            {
                JoinAttributeName = joinAttributeName,
                TargetAttributeName = joinAttributeName
            };

            try
            {
                var joined = geometryLayer.Join(dateBuildLayer, joinOptions);
                return joined;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during join operation: {ex.Message}");
            }
        }

        public VectorLayer JoinLayersByCoords(VectorLayer geometryLayer1, VectorLayer geometryLayer, string? joinAttributeName = "Id")
        {
            if (geometryLayer1 == null || geometryLayer == null)
            {
                throw new Exception("One of the Geometry layers is missing. Please create them first.");
            }

            // Check if joinAttributeName exists in both layers
            if (!geometryLayer1.Attributes.Contains(joinAttributeName) || !geometryLayer.Attributes.Contains(joinAttributeName))
            {
                throw new Exception($"Attribute '{joinAttributeName}' does not exist in one or both of the layers.");
            }
            // join options should be different!
            var joinOptions = new JoinOptions
            {
                JoinAttributeName = joinAttributeName,
                TargetAttributeName = joinAttributeName
            };

            try
            {
                var joined = geometryLayer.Join(geometryLayer1, joinOptions);
                return joined;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during join operation: {ex.Message}");
            }
        }

        public string LayerToString(VectorLayer layer)
        {
            var featuresCount = layer.Count;
            var attributesCount = layer.Attributes.Count;
            var spatialRefSys = layer.SpatialReferenceSystem;
            var code = spatialRefSys == null ? "'no srs'" : spatialRefSys.EpsgCode.ToString();

            return $"featuresCount: {featuresCount}\nattributesCount: {attributesCount}\nspatialRefSys: {code}";
        }
    }
}
