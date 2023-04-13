using Aspose.Gis;
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

namespace Geo.Coordinates.Convert
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

            var decimalDegrees = GeoConvert.AsPointText(25.5, 45.5, PointFormats.DecimalDegrees);
            output.Append("DG: ").AppendLine(decimalDegrees);

            var degreeDecimalMinutes = GeoConvert.AsPointText(25.5, 45.5, PointFormats.DegreeDecimalMinutes);
            output.Append("DDM: ").AppendLine(degreeDecimalMinutes);

            var degreeMinutesSeconds = GeoConvert.AsPointText(25.5, 45.5, PointFormats.DegreeMinutesSeconds);
            output.Append("DMS: ").AppendLine(degreeMinutesSeconds);

            var geoRef = GeoConvert.AsPointText(25.5, 45.5, PointFormats.GeoRef);
            output.Append("GeoRef: ").AppendLine(geoRef);

            var mgrs = GeoConvert.AsPointText(25.5, 45.5, PointFormats.Mgrs);
            output.Append("Mgrs: ").AppendLine(mgrs);

            var usng = GeoConvert.AsPointText(25.5, 45.5, PointFormats.Usng);
            output.Append("Usng: ").AppendLine(usng);

            output.AppendLine();
            output.AppendLine("OK");
            pOutput.Text = output.ToString();
        }
    }
}
