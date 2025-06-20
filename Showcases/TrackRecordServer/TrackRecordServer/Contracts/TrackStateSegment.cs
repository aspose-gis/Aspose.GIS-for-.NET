namespace TrackRecordServer.Contracts
{
    public class TrackStateSegment
    {
        public int Index { get; set; }
        public double[][] Line { get; set; }
        public double[] Projection { get; set; }
        public double LateralDeviation { get; set; }
    }
}
