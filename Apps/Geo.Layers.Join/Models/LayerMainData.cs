﻿using Aspose.Gis.Geometries;

namespace Geo.Layers.Join.Models
{
    /// <summary>
    /// Class for storing information added to the layer attributes
    /// </summary>
    class LayerMainData
    {
        public int Id { get; set; }
        public string? Summary { get; set; }
        public IGeometry Geometry { get; set; }
    }
}
