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
        public MainWindow()
        {
            InitializeComponent();
            button_cancel.IsEnabled = false;

        }
        private void ButtonOpenClick(object sender, RoutedEventArgs e)
        {
            button_cancel.IsEnabled = true;
            var urlTagCounter = new UrlTagCounter();
            urlTagCounter.ProcessFile(textBlock, highestValueTextblock);
        }
        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                textBlock.Text = string.Empty;
            }
        }
    }
}
