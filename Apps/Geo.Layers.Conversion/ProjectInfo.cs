using System.IO;
using System.Reflection;

namespace Geo.Layers.Conversion
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Layers.Conversion.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Layer Conversion";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
