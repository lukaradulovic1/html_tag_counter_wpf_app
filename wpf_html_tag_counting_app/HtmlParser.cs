using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace wpf_html_tag_counting_app
{
    public class HtmlParser
    {
        public string DownloadUrlHtmlToString(string txtUrlAdress)
        {
            using (WebClient webClient = new WebClient())
            {
                int maxRetries = 5;
                int retryCount = 0;
                int delayToRetry = 5000;

                while (retryCount < maxRetries)
                {
                    try
                    {
                        return webClient.DownloadString(txtUrlAdress);
                    }
                    catch (WebException e)
                    {
                        if (e.Status == WebExceptionStatus.Timeout)
                        {
                            Thread.Sleep(delayToRetry);
                            retryCount++;
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                throw new Exception($"Maximum retry count of {maxRetries} has been reached.");

            }
        }
        public int CountTagsInHtmlString(string htmlString)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlString);

            HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//a[text()] | //a[not(text())]");

            if (linkNodes != null)
            {
                return linkNodes.Count;
            }
            return 0;
        }
    }
}
