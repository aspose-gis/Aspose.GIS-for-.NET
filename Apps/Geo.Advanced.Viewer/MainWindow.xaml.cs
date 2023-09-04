using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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

        ProjectPresenter _projectPresenter = new();

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            var (placeLayer, mapStream) = _projectPresenter.CreateMap();

            DrawAttributes(placeLayer);
            DrawMap(mapStream);
        }
        private void DrawMap(Stream mapStream)
        {
            Image finalImage = (Image)myGrid.FindName("LayerContainer");
            BitmapImage logo = new BitmapImage();
            logo.BeginInit(); logo.StreamSource = mapStream;
            logo.EndInit(); finalImage.Source = logo;
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
