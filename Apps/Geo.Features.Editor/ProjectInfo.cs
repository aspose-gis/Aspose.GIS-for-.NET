using System.IO;
using System.Reflection;

namespace Geo.Features.Editor{ 
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Features.Editor.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Features Editor";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
