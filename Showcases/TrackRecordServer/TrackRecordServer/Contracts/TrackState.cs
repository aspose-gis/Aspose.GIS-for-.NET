namespace TrackRecordServer.Contracts
{
    public class TrackState
    {
        public Location Location { get; set; }
        public double DistanceTraveled { get; set; }
        public TrackStateSegment Segment { get; set; }
    }
}
