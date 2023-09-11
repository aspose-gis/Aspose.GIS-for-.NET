using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Geo.Tools.Paths
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComplexFindWay_Click(object sender, RoutedEventArgs e)
        {
            var presenter = new ProjectPresenter();
            var mapFilename = presenter.ComplexFindWay();
            ShowMap(mapFilename);
        }
        private void ShowMap(string filePath)
        {
            Image finalImage = MyPanel.FindName("GeometryContainer") as Image;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(filePath);
            logo.EndInit();
            finalImage.Source = logo;
        }
    }
}
