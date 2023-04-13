namespace Geo.Demo.Run
{
    public class DemoGeometryViewer
    {
        public string Description { get; private set; }
        public string Title {get; private set; }

        public DemoGeometryViewer()
        {
            Description = "Draws selected geometries and saves maps in .png files";
            Title = "Geometry Viewer";
        }

        public void Run()
        {
            var newForm = new Geo.Viewer.WPF.MainWindow();
            newForm.Show();
        }
    }
}
