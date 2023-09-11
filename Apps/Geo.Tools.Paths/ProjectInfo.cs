using System.IO;
using System.Reflection;

namespace Geo.Tools.Paths
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Tools.Paths.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Tools Roads";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
