namespace Geo.Advanced.Viewer
{
    public class ProjectInfo
    {
        public string Description { get; } =
            @"
This code loads a list of geographic photos (GeoPhoto) from a specific directory ""Photos"".
It goes through each file in the directory and extracts data about the date the photo was taken and GPS coordinates.
If geographic latitude and longitude coordinates are available, they are converted to decimal degrees and stored in the GeoPhoto object as a point with the Wgs84 coordinate reference system.

The list of received coordinates is displayed on the map.

The program also loads tiles as a substrate for the map.
";

        public string Title { get; } = "Advanced Viewer";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Show();
        }
    }
}
