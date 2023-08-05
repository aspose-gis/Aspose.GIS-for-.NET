namespace Geo.Rasters.Viewer
{
    public class ProjectInfo
    {
        public string Description { get; } = "This code reads values from a raster layer of an asc format and outputs them as a map and an array of text attributes.";

        public string Title { get; } = "Raster Viewer";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Show();
        }
    }
}
