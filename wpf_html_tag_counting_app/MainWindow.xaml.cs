using System;
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
        private readonly UrlTagCounter urlTagCounter;
        public MainWindow()
        {
            InitializeComponent();
            button_cancel.IsEnabled = false;
            button_clear.IsEnabled = false;
            ClearState();
            urlTagCounter = new UrlTagCounter(textBlock, highestValueTextblock, progressBar);
        }
        private void ButtonOpenClick(object sender, RoutedEventArgs e)
        {
            ClearState();
            button_cancel.IsEnabled = true;
            urlTagCounter.ProcessFile();
        }
        private void ButtonClearClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                ClearState();
                button_clear.IsEnabled = false;
            }
        }

        private void ClearState()
        {
            textBlock.Text = string.Empty;
            highestValueTextblock.Text = string.Empty;
            progressBar.Value = 0;
        }

        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                button_cancel.IsEnabled = false;
                button_clear.IsEnabled = true;
                urlTagCounter.Cancel();
            }
        }
    }
}


