using System.IO;
using System.Reflection;

namespace Geo.Coordinates.Transformation
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("Geo.Coordinates.Transformation.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Coordinates Transformation";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
