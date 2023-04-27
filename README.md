# html_tag_counter_wpf_app

**Introduction**

The WPF HTML Tag Counting App is a simple application that counts the number of tags in a list of URLs provided by the user in a .txt file. This text will provide information on how to run and use the application.

**How to Run**

To run the application, you can either download the Git repository and run it from a debugger, or navigate to the wpf_html_tag_counting_app\bin\Debug\net6.0-windows folder and run the .exe file.

**How to use:**

1. Choose a .txt file that contains a list of URLs via the dialog box opened by clicking the "Choose File" button.
2. Cancel the process at any time by pressing the "Cancel" button.

View the results in the output window, with the highest tag count page displayed at the top.

To search for other HTML tags, you can use different values such as "//href", "//html", "//div", "//p". 
To implement this through node search in HtmlNodeCollection, you can modify the line of code according to your requirements. 
For instance, to search for href, you can modify the code line to:
HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//a[@href]");

You can modify the code line similarly for other tags.

