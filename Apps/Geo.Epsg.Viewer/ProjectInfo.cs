namespace Geo.Epsg.Viewer
{
    public class ProjectInfo
    {
        public string Description { get; } = "This app is designed for quickly getting all available information about an SRS by entering the appropriate EPSG code.";

        public string Title { get; } = "Epsg Viewer";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Show();
        }
    }
}
