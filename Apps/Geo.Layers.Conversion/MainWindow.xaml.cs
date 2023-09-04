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

        private ProjectPresenter _projectPresenter = new();

        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var report = _projectPresenter.ConvertAndReport();
            pOutput.Text = report.ToString();
        }
    }
}
