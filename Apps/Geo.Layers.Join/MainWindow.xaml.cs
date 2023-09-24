using Aspose.Gis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            var (layerA, layerB, joinedLaeyr) = _projectPresenter.JoinByIndex();

            var listBox1 = CreateGrid(layerA);
            var listBox2 = CreateGrid(layerB);
            var listBox3 = CreateGrid(joinedLaeyr);

            Grid.SetRow(listBox1, 1);
            Grid.SetColumn(listBox1, 0);

            Grid.SetRow(listBox2, 1);
            Grid.SetColumn(listBox2, 1);

            Grid.SetRow(listBox2, 1);
            Grid.SetColumn(listBox2, 1);

            Grid.SetRow(listBox3, 1);
            Grid.SetColumn(listBox3, 2);

            myGrid.Children.Add(listBox1);
            myGrid.Children.Add(listBox2);
            myGrid.Children.Add(listBox3);

            Content = myGrid;
        }

        private void Show2_Click(object sender, RoutedEventArgs e)
        {
            var (layerA, layerB, joinedLaeyr) = _projectPresenter.JoinByCoords();

            var listBox1 = CreateGrid(layerA);
            var listBox2 = CreateGrid(layerB);
            var listBox3 = CreateGrid(joinedLaeyr);

            Grid.SetRow(listBox1, 1);
            Grid.SetColumn(listBox1, 0);

            Grid.SetRow(listBox2, 1);
            Grid.SetColumn(listBox2, 1);

            Grid.SetRow(listBox2, 1);
            Grid.SetColumn(listBox2, 1);

            Grid.SetRow(listBox3, 1);
            Grid.SetColumn(listBox3, 2);

            myGrid.Children.Add(listBox1);
            myGrid.Children.Add(listBox2);
            myGrid.Children.Add(listBox3);

            Content = myGrid;
        }

        private DataGrid CreateGrid(VectorLayer layer)
        {
            
            var data = layer.Select(t => t.GetValuesDump()).ToList();
            var grid = new DataGrid();
            grid.AutoGenerateColumns = false;
            var i = 0;
            foreach (var item in layer.Attributes)
            {
                var col = new DataGridTextColumn();
                col.Header = item .Name;
                col.Binding = new Binding(string.Format("[{0}]", i));
                grid.Columns.Add(col);
                i++;
            }
            grid.ItemsSource = data;
            return grid;
        }
    }
}
