using System.IO;
using System.Reflection;

namespace Geo.Tools.Voronoi
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Tools.Voronoi.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Tools Voronoi Polygons";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
