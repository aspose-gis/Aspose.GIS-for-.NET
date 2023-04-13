using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Geo.Advanced.Viewer.Maps;
using Geo.Advanced.Viewer.DataAccess;
using Aspose.Gis;
using System.Linq;

namespace Geo.Advanced.Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Show_Click(null!, null!);
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            var storage = new PhotoStorage();
            var photoList = storage.LoadPhotos();

            var currentLayer = new LayerConstructor();
            var placeLayer = currentLayer.CreatePlacesLayer(photoList);
            var wayLayer = currentLayer.CreateWayLayer(photoList);
            string mapFileName = MapConstructor.CreateMap(placeLayer, wayLayer);

            DrawAttributes(placeLayer);
            DrawMap(mapFileName);
        }

        private void DrawMap(string mapFileName)
        {
            Image finalImage = (Image) myGrid.FindName("LayerContainer");
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(new FileInfo(mapFileName).FullName);
            logo.EndInit();
            finalImage.Source = logo;           
        }

        private void DrawAttributes(VectorLayer placeLayer)
        {
            ListBox listBox = new ListBox();
            listBox.SelectionMode = SelectionMode.Single;

            var headers = placeLayer.Attributes.Select(t => t.Name);

            listBox.Items.Add(new ListBoxItem()
            {
                Content = string.Join(", ", headers),
                Background = new SolidColorBrush(Color.FromRgb((byte)217, (byte)217, (byte)214))
            });

            foreach (var feature in placeLayer)
            {
                var dump = feature.GetValuesDump();
                listBox.Items.Add(new ListBoxItem()
                {
                    Content = string.Join(", ", dump),
                    Background = new SolidColorBrush(Color.FromRgb((byte)217, (byte)217, (byte)214))
                });
            }

            Grid.SetRow(listBox, 1);
            Grid.SetColumn(listBox, 1);

            myGrid.Children.Add(listBox);
            Content = myGrid;
        }
    }
}
