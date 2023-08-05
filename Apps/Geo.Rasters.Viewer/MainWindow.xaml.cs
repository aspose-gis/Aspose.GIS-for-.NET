using Aspose.Gis;
using Aspose.Gis.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Path = System.IO.Path;

namespace Geo.Rasters.Viewer
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

        void LoadMap()
        {
            string filePath = RunExamples.GetFolderDir("Maps") + "test";

            Image finalImage = myGrid.FindName("GeometryContainer") as Image;
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(RasterOutput.MapRaster(filePath));
            logo.EndInit();
            finalImage.Source = logo;
        }

        void LoadInformation()
        {
            var output = new StringBuilder();
            output.AppendLine("START").AppendLine();
            output.Append(RasterOutput.ReadSingleBandEsriAscii());
            pOutput.Text = output.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadInformation();
            LoadMap();
        }
    }

    public class RunExamples
    {
        public static string GetFolderDir(string folderName = "Data")
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return startDirectory != null ? Path.Combine(startDirectory, folderName + "\\") : null;
        }
    }
}
