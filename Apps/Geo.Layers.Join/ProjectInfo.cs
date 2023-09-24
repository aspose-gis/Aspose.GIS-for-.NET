using System.IO;
using System.Reflection;

namespace Geo.Layers.Join
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Layers.Join.ReadMe.md")!).ReadToEnd();
        public string Title {get; private set; } = "Layers Join";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
