using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Geo.Demo.Run
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LauncherPresneter projects = new LauncherPresneter();
        private IDemoProject current = null!;

        public MainWindow()
        {
            InitializeComponent();

            foreach (var item in projects.Projects)
            {
                DemoList.Items.Add(new ListBoxItem() { Content = item.Title });
            }
            DemoList.SelectionChanged += ChangeDescription;
        }

        void ChangeDescription(object sender, SelectionChangedEventArgs e)
        {
            current = projects.GetProjectByTitle((DemoList.SelectedItem as ListBoxItem).Content.ToString());
            myDescription.Text = current.Description;
        }

        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            current?.Run();
        }
    }
}
