using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_html_tag_counting_app
{
    public class UrlTagCounter
    {

        public void ProcessFile()
        {
            OpenFileDialog openFileDialog;
            InitiateDialogWindow(out openFileDialog, out bool? result);

            if (result == true)
            {
                List<string> fileContents = ReadTextContents(openFileDialog);

                Dictionary<string, int> urlTagCountDictionary = new Dictionary<string, int>();
                Dictionary<string, string> failedDownloads = new Dictionary<string, string>();

                ProcessPair(fileContents, urlTagCountDictionary, failedDownloads);
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
        private void ProcessPair(List<string> fileContents, Dictionary<string, int> urlTagCountDictionary, Dictionary<string, string> failedDownloads)
        {
            HtmlParser htmlParser = new HtmlParser();
            foreach (var item in fileContents)
            {
                try
                {
                    var htmlContent = htmlParser.DownloadUrlHtmlToString(item);
                    var numATags = htmlParser.CountTagsInHtmlString(htmlContent);

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
                var concatenatedStringSuccess = urlTagCountDictionary.Select(kv => $"{kv.Key}: {kv.Value}");
                var concatenatedStringFailed = failedDownloads.Select(kv => $"{kv.Key}: {kv.Value}");

            }
        }

    }
}
