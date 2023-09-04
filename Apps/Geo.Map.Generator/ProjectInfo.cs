using System.IO;
using System.Reflection;

namespace Geo.Map.Generator
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Map.Generator.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Map Generator";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
