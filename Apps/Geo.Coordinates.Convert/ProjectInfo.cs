namespace Geo.Coordinates.Convert
{
    public class ProjectInfo
    {
        public string Description { get; } = "The application demonstrates the conversion of coordinates";

        public string Title { get; } = "Coordinates Conversion";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Show();
        }
    }
}
