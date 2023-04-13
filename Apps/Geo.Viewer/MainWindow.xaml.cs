using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Geometry = Aspose.Gis.Geometries.Geometry;

namespace Geo.Viewer.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GeometryPresenter presenter = new GeometryPresenter();
        GeometryOutput outputer = new GeometryOutput();
        public MainWindow()
        {
            InitializeComponent();

            ListBox listBox = new ListBox();
            listBox.SelectionMode = SelectionMode.Single;

            for(int i = 0; i < presenter.Titles.Length; i++)
                {
                presenter.SelectedIndex = i;
                listBox.Items.Add(new ListBoxItem() { Content = presenter.Titles[i], Background=new SolidColorBrush(Color.FromRgb((byte)217, (byte)217, (byte)214)) });
                }

            listBox.SelectionChanged += OnListSelectionChanged;

            Grid.SetRow(listBox, 1);
            Grid.SetColumn(listBox, 0);

            myGrid.Children.Add(listBox);
            Content = myGrid;
        }

        void OnListSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ListBox listBox = sender as ListBox;
            presenter.AssignGeometry(listBox.SelectedIndex);
            string filePath = "C:\\Users\\livol\\source\\repos\\Geo.Viewer.WPF\\Geo.Viewer.WPF\\Maps\\test";
            
            Image finalImage = myGrid.FindName("GeometryContainer") as Image;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(GeometryOutput.SaveGeometryAsMap(Geometry.FromText(presenter.SelectedWkt), filePath));
            logo.EndInit();
            finalImage.Source = logo;
        }
    }
}
