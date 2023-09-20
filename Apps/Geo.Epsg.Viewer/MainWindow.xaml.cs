﻿using System;
using System.Collections.Generic;
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

namespace Geo.Epsg.Viewer
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

        private ProjectPresenter _projectPresenter = new();

        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            var report = _projectPresenter.ReadAndReport(eWorkFolder.Text);
            pOutput.Text = report.ToString();
        }
    }
}