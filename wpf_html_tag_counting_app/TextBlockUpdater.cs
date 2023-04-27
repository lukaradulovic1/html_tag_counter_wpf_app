using System.Windows.Controls;

namespace wpf_html_tag_counting_app
{

    public class TextBlockUpdater
    {
        private TextBlock _textBlock;
        public TextBlockUpdater(TextBlock textBlock)
        {
            _textBlock = textBlock;
        }
        public void UpdateText(string text)
        {
            // Use the Dispatcher to update the TextBlock on the UI thread
            _textBlock.Dispatcher.Invoke(() =>
            {
                _textBlock.Text = text;
            });
        }

        public void ResetApp()
        {
            _textBlock.Text = "";
        }
    }
}