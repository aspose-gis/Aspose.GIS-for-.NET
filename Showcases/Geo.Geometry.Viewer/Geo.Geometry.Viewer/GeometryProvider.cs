using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Gis;
using Aspose.Gis.Geometries;

namespace Geo.Geometry.Viewer
{
    /// <summary>
    /// Creates geometry presets based on WKT strings and additional parameters
    /// </summary>
    class GeometryProvider
    {
	/// <summary>
	/// Returns a geometry object of Polygon type made with a WKT string, formed according to the given parameters
	/// </summary>
	public IGeometry CreatePolygon(double length, double width)
        {
            //feature.Geometry = Geometry.FromText("POLYGON((0 0, 35 50, 70 0, 35 -50, 0 0))");
            return Aspose.Gis.Geometries.Geometry.FromText(string.Format("POLYGON((0 0, {0} {1}, {2} 0, {0} {3}, 0 0))", length / 2, width / 2, length, -width / 2));
        }
	    
	/// <summary>
	/// Returns a geometry object of CircularString type made using points, formed according to the given parameters
	/// </summary>
	public IGeometry CreateCircularString(double radius)
	{
	    var circularString = new CircularString();
	    circularString.AddPoint(0, 0);
	    circularString.AddPoint(radius, radius);
	    circularString.AddPoint(radius * 2, 0);
	    circularString.AddPoint(radius, -radius);
	    circularString.AddPoint(0, 0)
		
	    return circularString;
	}
    }
}
