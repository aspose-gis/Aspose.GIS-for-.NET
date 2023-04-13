using Aspose.Gis.SpatialReferencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Geo.Coordinates.Transformation
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
            output.AppendLine("START").AppendLine();

            // Source and destination SRS
            var utm32N = SpatialReferenceSystem.CreateFromEpsg(32632);
            var latLong = SpatialReferenceSystem.CreateFromEpsg(4326);
            var transformation = utm32N.CreateTransformationTo(latLong);

            // Transform geometry
            var utmPoint = new Aspose.Gis.Geometries.Point(510000, 7042000);
            var geoPoint = transformation.Transform(utmPoint) as Aspose.Gis.Geometries.Point;

            // Write result
            output.AppendLine("UTM Easting: " + utmPoint.X);
            output.AppendLine("UTM Northing: " + utmPoint.Y);
            output.AppendLine("Longitude: " + geoPoint.X);
            output.AppendLine("Latitude: " + geoPoint.Y);

            output.AppendLine().AppendLine("OK");
            pOutput.Text = output.ToString();
        }
    }
}
