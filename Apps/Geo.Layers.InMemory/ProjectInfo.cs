using Geo.MLayer.Editor;
using System.IO;
using System.Reflection;

namespace Geo.Layers.InMemory
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Layers.InMemory.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "InMemory Format";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
