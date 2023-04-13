namespace Geo.Coordinates.Transformation
{
    public class ProjectInfo
    {
        public string Description { get; } = "The Coordinate Transformation is a demo for converting coordinates from one SRS (Spatial Reference System) to another SRS and display the result";

        public string Title { get; } = "Coordinates Transformation";

        public void Run()
        {
            var newForm = new MainWindow();
            newForm.Show();
        }
    }
}
