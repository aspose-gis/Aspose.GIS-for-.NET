using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.Gis.GeoTools.Extensions;
using Geo.Layers.InMemory;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Point = Aspose.Gis.Geometries.Point;

namespace Geo.MLayer.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectPresenter _projectPresenter = new ProjectPresenter();
        
        public MainWindow()
        {
            InitializeComponent();
            _projectPresenter.CreateLayer();
        }

        private void ReadInMemoryFeatures_Click(object sender, RoutedEventArgs e)
        {
            var report = _projectPresenter.ReadAddReport();
            pOutput.Text = report;            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var report = _projectPresenter.AddAndReport(eFeatureValue.Text);
            pOutput.Text = report;
        }
    }    
}
