using System.IO;
using System.Reflection;

namespace Geo.Advanced.Viewer
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
             .GetManifestResourceStream("Geo.Advanced.Viewer.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Advanced Viewer";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
