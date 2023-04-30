using System.Windows.Controls;

namespace wpf_html_tag_counting_app
{

    public class TextBlockUpdater
    {
        private readonly TextBlock displayTextBlock;
        public TextBlockUpdater(TextBlock textBlock)
        {
            displayTextBlock = textBlock;
        }
        public void UpdateText(string text)
        {
            // Use the Dispatcher to update the TextBlock on the UI thread
            displayTextBlock.Dispatcher.Invoke(() =>
            {
                displayTextBlock.Text = text;
            });
        }
        public void ResetApp()
        {
            displayTextBlock.Text = "";
        }
    }
}