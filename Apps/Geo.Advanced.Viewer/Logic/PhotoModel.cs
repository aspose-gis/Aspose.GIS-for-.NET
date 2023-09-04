using System;
using Aspose.Gis.Geometries;


namespace Geo.Advanced.Viewer.Logic
{
    public class PhotoModel
    {
        public const string Regular = "Regular";
        public const string Marked = "Marked";
        public DateTime? Created { get; set; }
        public IPoint? Coordinate { get; set; }
        public string Mark { get; set; }
    }
}
