using Aspose.Gis;
using Aspose.Gis.GeoTools.Extensions;
using Geo.Features.Editor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
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

namespace Geo.Features.Editor
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

        VectorLayer Layer = Drivers.InMemory.CreateLayer();
        List<ExampleModel> featuresList = new List<ExampleModel>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string report = _projectPresenter.AddAndReport(featureValue.Text);
            pOutput.Text = report;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string report = _projectPresenter.ReadAddReport();
            pOutput.Text = report;
        }
    }
}
