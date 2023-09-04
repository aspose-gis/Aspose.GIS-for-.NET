using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Aspose.Gis;
using Aspose.Gis.Geometries;
using Aspose.Gis.GeoTools;
using Geo.Map.Rendering;

namespace Geo.Map.Rendering
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

        ProjectPresenter _projectPresenter = new();
       
        private void SelfColors_Click(object sender, RoutedEventArgs e)
        {
            var filaname = _projectPresenter.RenderGeometrySelfColor();
            ShowMap(filaname);
        }

        private void ShowMap(string filaname)
        {
            if (filaname == null)
                return;
            Image finalImage = pOutput;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(new FileInfo(filaname).FullName);
            logo.EndInit();
            finalImage.Source = logo;
        }

    }
}
