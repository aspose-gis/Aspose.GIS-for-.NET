using System.IO;
using System.Reflection;

namespace Geo.Rasters.Viewer
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Rasters.Viewer.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Raster Viewer";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
