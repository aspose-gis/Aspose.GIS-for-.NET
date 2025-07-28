using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.Gis.GeoTools;
using Aspose.Gis.SpatialReferencing;
using Newtonsoft.Json;

namespace FakeMovingObject
{
    public class Config
    {
        public const string ServerUrl = "http://localhost:5208/api/track";
    }

    internal class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting location sender... (Press Ctrl+C to stop)");

            string filePath = "track.gpx";

            Guid trackId = Guid.NewGuid();
            LineString track;

            using (var layer = Drivers.Gpx.OpenLayer(filePath))
            {
                track = (LineString)((MultiLineString)layer[12].Geometry).First();

                var tr = SpatialReferenceSystem.Wgs84.CreateTransformationTo(SpatialReferenceSystem.CreateFromEpsg(32635));
                var toCheckLength = tr.Transform(track);
                Console.WriteLine($"Track length: {toCheckLength.GetLength()}");

                track = (LineString)GeometryOperations.CreateMidpoints(track);
                track = (LineString)GeometryOperations.CreateMidpoints(track);
                track = (LineString)GeometryOperations.CreateMidpoints(track);
            }

            try
            {
                foreach (var point in track)
                {
                    await SendLocation(trackId, point);
                    await Task.Delay(267);
                }
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Stopped by user");
            }
        }

        private static async Task SendLocation(Guid trackId, IPoint point)
        {
            try
            {
                var payload = new RequestPayload(trackId, new LocationData(
                        Latitude: point.Y,
                        Longitude: point.X
                    ));

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(Config.ServerUrl, content);

                Console.WriteLine($"[{DateTime.Now:T}] Sent: {payload.Location.Latitude}, {payload.Location.Longitude} | Status: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
        }
    }

    public class RequestPayload
    {
        public RequestPayload(Guid trackId, LocationData location)
        {
            TrackId = trackId;
            Location = location;
            Timestamp = DateTimeOffset.Now;
        }

        public Guid TrackId { get; }
        public LocationData Location { get; }
        public DateTimeOffset Timestamp { get; }
    }

    public record LocationData(
        double Latitude,
        double Longitude
    );
}
