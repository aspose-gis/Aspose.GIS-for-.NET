namespace Geo.Layers.Conversion
{
    public class ProjectInfo
    {
        public string Description { get; } = "The application demonstrates the conversion of file formats";

        public string Title { get; } = "Layer Conversion";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Show();
        }
    }
}
