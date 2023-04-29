using System.Windows.Controls;

namespace wpf_html_tag_counting_app
{

    public class TextBlockUpdater
    {
        private TextBlock textBlock;
        public TextBlockUpdater(TextBlock textBlock)
        {
            textBlock = textBlock;
        }
        public void UpdateText(string text)
        {
            // Use the Dispatcher to update the TextBlock on the UI thread
            textBlock.Dispatcher.Invoke(() =>
            {
                textBlock.Text = text;
            });
        }
        public void ResetApp()
        {
            textBlock.Text = "";
        }
    }
}