using System.IO;
using System.Reflection;

namespace Geo.Epsg.Viewer
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Epsg.Viewer.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Epsg Viewer";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
