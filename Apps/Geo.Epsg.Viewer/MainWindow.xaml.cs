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

namespace Geo.Epsg.Viewer
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

            if (!isTextFilled)
            {
                output.AppendLine("ERROR: NO VALUES PASSED");
                return;
            }

            var status = Aspose.Gis.SpatialReferencing.SpatialReferenceSystem.TryCreateFromEpsg(4326, out var referenceSystem);
            output.AppendLine("Is succesful: " + status.ToString());

            if (status)
            {
                output.AppendLine("WKT: " + referenceSystem.ExportToWkt());
                output.AppendLine("Datum: " + referenceSystem.GeographicDatum.ToString());
            }

            output.AppendLine().AppendLine("OK");
            pOutput.Text = output.ToString();
        }
        bool isTextFilled = false;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTextFilled = !string.IsNullOrEmpty(eWorkFolder.Text);
        }
    }
}
