using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace wpf_html_tag_counting_app
{
    public class UrlTagCounter
    {
        public void ProcessFile(TextBlock textBlock, TextBlock highestValueTextblock)
        {
            OpenFileDialog openFileDialog;
            InitiateDialogWindow(out openFileDialog, out bool? result);

            if (result == true)
            {
                List<string> fileContents = ReadTextContents(openFileDialog);

                Dictionary<string, int> urlTagCountDictionary = new Dictionary<string, int>();
                Dictionary<string, string> failedDownloads = new Dictionary<string, string>();

                ProcessPair(fileContents, urlTagCountDictionary, failedDownloads, textBlock, highestValueTextblock);
            }
        }
        private static void InitiateDialogWindow(out OpenFileDialog openFileDialog, out bool? result)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.DefaultExt = ".txt";

            result = openFileDialog.ShowDialog();
        }
        private List<string> ReadTextContents(OpenFileDialog openFileDialog)
        {
            string filePath = openFileDialog.FileName;
            List<string> fileContents = ReadTextFile(filePath);
            return fileContents;
        }
        private static List<string> ReadTextFile(string filePath)
        {
            List<string> fileContentsList = File.ReadAllLines(filePath).ToList();
            return fileContentsList;
        }
        private void ProcessPair(List<string> fileContents, Dictionary<string, int> urlTagCountDictionary, Dictionary<string, string> failedDownloads, TextBlock textBlock, TextBlock highestValueTextblock)
        {
            HtmlParser htmlPageParser = new HtmlParser();
            foreach (var item in fileContents)
            {
                AddHtmlOutputToDictionary(urlTagCountDictionary, failedDownloads, htmlPageParser, item, highestValueTextblock);
                DisplayDictionariesOnTextBlock(urlTagCountDictionary, failedDownloads, textBlock);
            }
        }
        private static void AddHtmlOutputToDictionary(Dictionary<string, int> urlTagCountDictionary, Dictionary<string, string> failedDownloads, HtmlParser htmlPageParser, string item, TextBlock highestValueTextblock)
        {
            try
            {
                var htmlContent = htmlPageParser.DownloadUrlHtmlToString(item);
                var numATags = htmlPageParser.CountTagsInHtmlString(htmlContent);

                if (htmlContent != null)
                {
                    if (numATags > 0)
                    {
                        urlTagCountDictionary.Add(item, numATags);
                    }
                    else
                    {
                        failedDownloads.Add(item, "Tag count is 0 due to HTML file not providing tags");
                    }
                }
            }
            catch (Exception ex)
            {
                failedDownloads.Add(item, ex.Message);
            }
            HighestValueInUrlTagCount(urlTagCountDictionary, highestValueTextblock);
        }
        private static void HighestValueInUrlTagCount(Dictionary<string, int> urlTagCountDictionary, TextBlock highestValueTextblock)
        {
            var highestValue = urlTagCountDictionary.OrderByDescending(d => d.Value).FirstOrDefault();
            if (highestValue.Key != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"The URL with the highest number of <a> tags is: {highestValue.Key} with a count of {highestValue.Value}");
                TextBlockUpdater textBlockUpdater = new TextBlockUpdater(highestValueTextblock);
                textBlockUpdater.UpdateText(sb.ToString());
            }
        }
        private static void DisplayDictionariesOnTextBlock(Dictionary<string, int> urlTagCountDictionary, Dictionary<string, string> failedDownloads, TextBlock textBlock)
        {
            if (textBlock != null)
            {
                TextBlockUpdater textBlockUpdater = new TextBlockUpdater(textBlock);
                StringBuilder sb = new StringBuilder();

                foreach (var kvp in urlTagCountDictionary)
                {
                    sb.AppendLine($"{kvp.Key}: {kvp.Value}");
                }

                foreach (var kvp in failedDownloads)
                {
                    sb.AppendLine($"{kvp.Key}: {kvp.Value}");
                }
                textBlockUpdater.UpdateText(sb.ToString());
                Application.Current.Dispatcher.Invoke(() => { }, System.Windows.Threading.DispatcherPriority.Background);
            }
        }
    }
}

