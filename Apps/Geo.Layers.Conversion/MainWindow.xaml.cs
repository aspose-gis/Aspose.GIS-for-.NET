using Aspose.Gis;
using System.IO;
using System.Text;
using System.Windows;

namespace Geo.Layers.Conversion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var output = new StringBuilder();
            output.AppendLine("START");
            output.AppendLine("Convert from Geo JSON to KML");

            VectorLayer.Convert("data/sample.geojson", Drivers.GeoJson, "output.kml", Drivers.Kml);

            output.AppendLine("Result KML:");
            output.AppendLine(File.ReadAllText("output.kml"));


            output.AppendLine();
            output.AppendLine("OK");
            pOutput.Text = output.ToString();
        }
    }
}
