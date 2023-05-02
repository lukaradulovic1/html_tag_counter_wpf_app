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
            displayTextBlock.Dispatcher.Invoke(() =>
            {
                displayTextBlock.Text = text;
            });
        }
    }
}