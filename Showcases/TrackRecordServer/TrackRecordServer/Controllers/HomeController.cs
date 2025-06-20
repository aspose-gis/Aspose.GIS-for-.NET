using Aspose.Gis;
using Aspose.Gis.Geometries;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace TrackRecordServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly Model.Route _route;

        public HomeController(Model.Route route)
        {
            _route = route ?? throw new ArgumentNullException(nameof(route));
        }

        public IActionResult Index()
        {
            
            ViewData["RouteGeoJson"] = ConvertGpxToGeoJson();
            ViewData["TotalLength"] = _route.GetTotalLength();

            return View();
        }

        private string ConvertGpxToGeoJson()
        {
            string filePath = "route.gpx";

            var memoryStream = new MemoryStream();
            using (var layer = Drivers.Gpx.OpenLayer(filePath))
            using (var jsonLayout = Drivers.GeoJson.CreateLayer(AbstractPath.FromStream(memoryStream)))
            {
                var routeLine = (LineString)((MultiLineString)layer[12].Geometry).First();

                var routeLineFeature = jsonLayout.ConstructFeature();
                routeLineFeature.Geometry = routeLine.Clone();
                jsonLayout.Add(routeLineFeature);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }
    }
}
