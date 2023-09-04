using System.IO;
using System.Reflection;

namespace Geo.Map.Rendering
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Map.Rendering.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Map Rendering";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
