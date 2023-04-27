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

namespace wpf_html_tag_counting_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProgressBar progressBar;
        public MainWindow()
        {
            InitializeComponent();
            button_cancel.IsEnabled = false;
            progressBar = myProgressBar;
        }
        private void ButtonOpenClick(object sender, RoutedEventArgs e)
        {
            button_cancel.IsEnabled = true;
            var urlTagCounter = new UrlTagCounter(textBlock, highestValueTextblock, progressBar);
            urlTagCounter.ProcessFile();
        }
        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                textBlock.Text = string.Empty;
                highestValueTextblock.Text = string.Empty;
                progressBar.Value = 0;
            }
        }
    }
}
