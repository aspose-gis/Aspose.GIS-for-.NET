using Aspose.GIS.Live.Demos.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspose.GIS.Live.Demos.UI.Controllers
{
	public class HomeController : BaseController
	{
	
		public override string Product => (string)RouteData.Values["productname"];
		

		

		public ActionResult Default()
		{
			ViewBag.PageTitle = "Read, write, Convert GIS files to Google Earth, GeoJSON &amp; ESRI Shapefiles";
			ViewBag.MetaDescription = "Read GPX, SHX, JSON, KML Formats and render to Google Earth, ESRI Shapefile, GeoJSON, FileGDB, KML &amp; OSM XML. Reproject Geometries, Compute Topological Relations.";
			var model = new LandingPageModel(this);

			return View(model);
		}
	}
}
