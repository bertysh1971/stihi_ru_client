using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using System.String;

namespace WindowsFormsApplication1
{


    public partial class Form2 : Form
    {
        static string[] ArgOsnLocal;
        static List<string> ListHTMLlocal;
        static List<string> ListTextlocal;
        static Boolean asLogin, asPassword;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string[] ArgOsn, List<string> ListHTML, List<string> ListText)
        {
            InitializeComponent();
            ListHTMLlocal = ListHTML;
            ListTextlocal = ListText;
            webBrowser1.Navigate(new Uri("https://www.stihi.ru/login/"));
            ArgOsnLocal = ArgOsn;
        }

        private void MyDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {


            if (e.Url.AbsoluteUri == "https://www.stihi.ru/login/")
            {

                HtmlElementCollection elmCol;
                elmCol = webBrowser1.Document.GetElementsByTagName("input");
                asLogin = false;
                asPassword = false;
                foreach (HtmlElement elmBtn in elmCol)
                {

                    if (elmBtn.GetAttribute("name") == "login")
                    {
                        elmBtn.InnerText = ArgOsnLocal[0];
                        asLogin = true;
                    }

                    if (elmBtn.GetAttribute("name") == "password")
                    {
                        elmBtn.InnerText = ArgOsnLocal[1];
                        asPassword = true;
                    }

                    if (elmBtn.GetAttribute("value") == "Вход")
                    {

                        elmBtn.InvokeMember("Click");
                    }
                }

             
            }
            if (!asLogin && !asPassword && e.Url.AbsoluteUri != "https://www.stihi.ru/login/page.html?list")
            {
                webBrowser1.Navigate(new Uri("https://www.stihi.ru/login/page.html?list"));
            }
                if (e.Url.AbsoluteUri == "https://www.stihi.ru/login/page.html?list")
                {
                    HtmlElementCollection links = webBrowser1.Document.Links;

                    foreach (HtmlElement link in links)
                    {
                        if (link.OuterText != null)
                        {
                            if (link.OuterText != "")
                            {
                                ListHTMLlocal.Add(link.OuterHtml);
                                ListTextlocal.Add(link.OuterText);
                            }
                        }
                    }
                    //ListHTMLlocal.Add(e.Url.AbsoluteUri);
                    //ListTextlocal.Add(e.Url.AbsoluteUri);

                    this.Close();

                }
            }
        
    }
}

