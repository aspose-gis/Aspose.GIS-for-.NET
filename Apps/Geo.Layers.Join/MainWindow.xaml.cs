using Aspose.Gis;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Geo.Layers.Join
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

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            var layer = _projectPresenter.JoinByIndex();
            ShowMap(layer);

            CreateList(layer);
        }

        private void Show2_Click(object sender, RoutedEventArgs e)
        {
            var layer = _projectPresenter.JoinByCoords();
            ShowMap(layer);

            CreateList(layer);
        }

        private void CreateList(VectorLayer layer)
        {
            ListBox listBox = new ListBox();
            listBox.SelectionMode = SelectionMode.Single;

            listBox.Items.Add(new ListBoxItem()
            {
                Content = layer.GeometryType
            });

            for (int i = 0; i < layer.Attributes.Count; i++)
            {
                listBox.Items.Add(new ListBoxItem() { Content = layer.Attributes[i].Name, Background = new SolidColorBrush(Color.FromRgb((byte)217, (byte)217, (byte)214)) });
                foreach (var feature in layer)
                {
                    var dump = feature.GetValuesDump();
                    listBox.Items.Add(new ListBoxItem() { Content = dump[i], Background = new SolidColorBrush(Color.FromRgb((byte)217, (byte)217, (byte)214)) });
                }
            }
            listBox.EndInit();

            Grid.SetRow(listBox, 1);
            Grid.SetColumn(listBox, 2);

            myGrid.Children.Add(listBox);
            Content = myGrid;
        }

        private void ShowMap(VectorLayer current)
        {
            if (current == null)
                return;
            Image finalImage = pOutput;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(new FileInfo(LayerOutput.SaveLayerAsMap(current, "map")).FullName);
            logo.EndInit();
            finalImage.Source = logo;
        }
    }
}
