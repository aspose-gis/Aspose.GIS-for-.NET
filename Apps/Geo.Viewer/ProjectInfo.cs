using System.IO;
using System.Reflection;

namespace Geo.Demo.Run
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Viewer.WPF.ReadMe.md")!).ReadToEnd();
        public string Title {get; private set; }

        public ProjectInfo()
        {
            Title = "Geometry Viewer";
        }

        public void Run()
        {
            var newForm = new Geo.Viewer.WPF.MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
