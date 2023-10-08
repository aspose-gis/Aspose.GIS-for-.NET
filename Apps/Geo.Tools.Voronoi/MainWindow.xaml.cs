using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Aspose.Gis.Geometries;

namespace Geo.Tools.Voronoi
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
       
        private void MapPoints_Click(object sender, RoutedEventArgs e)
        {
            var current = _projectPresenter.MapRegularPoints(CheckInput());

            ShowMap(current);
        }

        private void MapPolygons_Click(object sender, RoutedEventArgs e)
        {
            var current = _projectPresenter.MapRandomPoints(CheckInput());

            ShowMap(current);
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private int CheckInput()
        {
            try
            {
                if (!String.IsNullOrEmpty(objsCount.Text))
                    return int.Parse(objsCount.Text);
            }
            catch (Exception ex)
            {
                objsCount.Text = ex.Message;
            }
            return 5;

        }

        private void ShowMap(List<LineString> current)
        {
            if (current == null)
                return;
            Image finalImage = pOutput;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(new FileInfo(GeometryOutput.SaveGeometryAsMap(current, "map")).FullName);
            logo.EndInit();
            finalImage.Source = logo;
        }

    }
}
