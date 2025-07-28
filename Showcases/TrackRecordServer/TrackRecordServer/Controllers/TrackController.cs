using Aspose.Gis.Geometries;
using Aspose.Gis.SpatialReferencing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TrackRecordServer.Contracts;
using TrackRecordServer.Model;
using TrackRecordServer.SignalR;

namespace TrackRecordServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly Model.Route _route;
        private readonly IHubContext<CoordinatesHub> _hubContext;

        public TrackController(Model.Route route, IHubContext<CoordinatesHub> hubContext)
        {
            _route = route ?? throw new ArgumentNullException(nameof(route));
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TrackRequest request)
        {
            var originLocation = new Point(request.Location.Longitude, request.Location.Latitude)
            { 
                SpatialReferenceSystem = SpatialReferenceSystem.Wgs84 
            };

            var transformationTo = SpatialReferenceSystem.Wgs84.CreateTransformationTo(SpatialReferenceSystem.CreateFromEpsg(32635));
            var transformationFrom = SpatialReferenceSystem.CreateFromEpsg(32635).CreateTransformationTo(SpatialReferenceSystem.Wgs84);

            var transformedLocation = (Point)transformationTo.Transform(originLocation);

            var distanceTraveled = _route.DistanceTraveled(transformedLocation, out var segment);

            if (segment is null) throw new Exception();

            var transformedSegment = (LineString)transformationFrom.Transform(segment.Line);
            var transformedProjection = (Point)transformationFrom.Transform(segment.Projection);

            // Send coordinates only to clients in the Home/Index group
            await _hubContext.Clients.Group(CoordinatesHub.HomeIndexGroup)
                .SendAsync("TrackState", new TrackState 
                { 
                    Location = new Location 
                    { 
                        Latitude = originLocation.Y,
                        Longitude = originLocation.X 
                    },
                    DistanceTraveled = distanceTraveled,
                    Segment = new TrackStateSegment 
                    { 
                        Index = segment.Index,
                        Line = [[transformedSegment[0].Y, transformedSegment[0].X], [transformedSegment[1].Y, transformedSegment[1].X]],
                        Projection = [transformedProjection.Y, transformedProjection.X],
                        LateralDeviation = segment.LateralDeviation
                    }
                });

            return Ok();
        }
    }
}
