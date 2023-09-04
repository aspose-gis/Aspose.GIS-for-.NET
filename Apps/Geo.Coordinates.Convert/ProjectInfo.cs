using System.IO;
using System.Reflection;

namespace Geo.Coordinates.Convert
{
    public class ProjectInfo
    {
        public string Description => new StreamReader(Assembly.GetExecutingAssembly()
             .GetManifestResourceStream("Geo.Coordinates.Convert.ReadMe.md")!).ReadToEnd();

        public string Title { get; } = "Coordinates Conversion";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Title = Title;
            newForm.Show();
        }
    }
}
