namespace TrackRecordServer.Contracts
{
    public class TrackRequest
    {
        public Guid TrackId { get; set; }
        public LocationRequest Location { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }

    public class LocationRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
