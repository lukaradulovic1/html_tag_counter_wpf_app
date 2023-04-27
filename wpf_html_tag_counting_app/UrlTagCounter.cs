using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;

namespace wpf_html_tag_counting_app
{
    public class UrlTagCounter
    {
        private readonly TextBlock textBlock;
        private readonly TextBlock highestValueTextblock;
        private readonly ProgressBar progressBar;
        private List<string>? fileContents;
        private Dictionary<string, int>? urlTagCountDictionary;
        private Dictionary<string, string>? failedDownloads;
        private bool shouldCancel;

        public UrlTagCounter(TextBlock textBlock, TextBlock highestValueTextblock, ProgressBar progressBar)
        {
            this.textBlock = textBlock;
            this.highestValueTextblock = highestValueTextblock;
            this.progressBar = progressBar;
        }

        public void ProcessFile()
        {
            OpenFileDialog openFileDialog;
            InitiateDialogWindow(out openFileDialog, out bool? result);

            if (result == true)
            {
                fileContents = ReadTextContents(openFileDialog);
                urlTagCountDictionary = new();
                failedDownloads = new();
                ProcessUrls();

            }
        }
        private void InitiateDialogWindow(out OpenFileDialog openFileDialog, out bool? result)
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
        private List<string> ReadTextFile(string filePath)
        {
            List<string> fileContentsList = File.ReadAllLines(filePath).ToList();
            return fileContentsList;
        }
        private void ProcessUrls()
        {
            HtmlParser htmlParser = new HtmlParser();
            foreach (var url in fileContents)
            {
                AddHtmlOutputToDictionary(htmlParser, url);
                DisplayTagDictionaryOnTextBlock();
                ProgressBarIncrement();

                if (shouldCancel)
                {
                    shouldCancel = false;
                    break;
                }
            }

        }
        private void AddHtmlOutputToDictionary(HtmlParser htmlPageParser, string url)
        {
            try
            {
                var htmlContent = htmlPageParser.DownloadUrlHtmlToString(url);
                var numATags = htmlPageParser.CountTagsInHtmlString(htmlContent);

                if (htmlContent != null)
                {
                    if (numATags > 0)
                    {
                        urlTagCountDictionary.Add(url, numATags);
                    }
                    else
                    {
                        failedDownloads.Add(url, "Tag count is 0 due to HTML file not providing tags");
                    }
                }
            }
            catch (Exception ex)
            {
                failedDownloads.Add(url, ex.Message);
            }
            HighestValueInUrlTagCount();
        }
        private void HighestValueInUrlTagCount()
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
        private void DisplayTagDictionaryOnTextBlock()
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
        private void ProgressBarIncrement()
        {
            int totalItems = fileContents.Count;
            int processedItems = urlTagCountDictionary.Count + failedDownloads.Count;

            double progressPercentage = (double)processedItems / (double)totalItems * 100.0;

            progressBar.Value = progressPercentage;
        }

        public void Cancel()
        {
            shouldCancel = true;
        }
    }
}

