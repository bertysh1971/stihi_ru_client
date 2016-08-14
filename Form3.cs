using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        static string[] ArgOsnLocal;
        static List<string> ListHTMLlocal;
        static List<string> ListTextlocal;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string[] ArgOsn, List<string> ListHTML, List<string> ListText)
        {
            InitializeComponent();
            ListHTMLlocal = ListHTML;
            ListTextlocal = ListText;
            //webBrowser1.Url=new Uri("https://www.stihi.ru/login/");
            //webBrowser1.Navigate(new Uri("https://www.stihi.ru/login/"));
            ArgOsnLocal=ArgOsn;
            foreach(string ElList1 in ListHTMLlocal)
            {
                if (ElList1 != null)
                {
                    listBox1.Items.Add(ElList1);
                }
            }
            foreach(string ElList2 in ListTextlocal)
            {
                if (ElList2 != null)
                {
                    listBox2.Items.Add(ElList2);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Стихи от "+ListTextlocal.IndexOf("восстановить удаленное").ToString()+" по "+ListTextlocal.IndexOf("Произведения, не вошедшие в сборники").ToString());
            MessageBox.Show("Сборники от " + ListTextlocal.IndexOf("Произведения, не вошедшие в сборники").ToString() + " по " + ListTextlocal.IndexOf("Добавить новый сборник").ToString());
            MessageBox.Show("Хвост от " + ListTextlocal.IndexOf("Добавить новый сборник").ToString() + " по " + ListTextlocal.Count.ToString());
            int StartBook=ListTextlocal.IndexOf("Произведения, не вошедшие в сборники");
            StartBook++;
            int EndBook=ListTextlocal.IndexOf("Добавить новый сборник");
            richTextBox1.Text = "";
            richTextBox1.Visible=false;
            for (int indextext = StartBook; indextext < EndBook; indextext++)
            {
                //MessageBox.Show(ListTextlocal.ElementAt(indextext));
                //richTextBox1.Lines.
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Font = new Font("Arial", 14);
                //richTextBox1.SelectionFont
                richTextBox1.AppendText(ListTextlocal.ElementAt(indextext) + Environment.NewLine);
                richTextBox1.ForeColor = Color.Blue;
                richTextBox1.Font = new Font("Arial", 14);
                //ListHTMLlocal.ElementAt(indextext).Substring(ListHTMLlocal.ElementAt(indextext).IndexOf("f=")+2, ListHTMLlocal.ElementAt(indextext).IndexOf(">"));   
                //richTextBox1.AppendText(string.Format(ListHTMLlocal.ElementAt(indextext) + Environment.NewLine));
                //ListHTMLlocal.ElementAt(indextext).Substring(
                string locStr=ListHTMLlocal.ElementAt(indextext);
                locStr=locStr.Replace("&amp;", "&");
                richTextBox1.AppendText("http://www.stihi.ru" + locStr.Substring(locStr.IndexOf("f=\"") + 3, locStr.IndexOf("\">") - locStr.IndexOf("f=") - 3) + Environment.NewLine);
                //richTextBox1.Text = richTextBox1.Text+ListTextlocal.ElementAt(indextext) + Environment.NewLine;
            }
            int StartPoetry = ListTextlocal.IndexOf("восстановить удаленное");
            int EndPoetry = ListTextlocal.IndexOf("Произведения, не вошедшие в сборники");
            StartPoetry++;
            richTextBox1.AppendText(Environment.NewLine + Environment.NewLine);
            for (int indextext = StartPoetry; indextext < EndPoetry; indextext++)
            {
                //MessageBox.Show(ListTextlocal.ElementAt(indextext));
                //richTextBox1.Lines.
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.Font = new Font("Arial", 10);
                richTextBox1.AppendText(ListTextlocal.ElementAt(indextext) + Environment.NewLine);
                richTextBox1.ForeColor = Color.Blue;
                richTextBox1.Font = new Font("Arial", 10);
                //richTextBox1.AppendText(string.Format(ListHTMLlocal.ElementAt(indextext) + Environment.NewLine));
                //richTextBox1.Text = richTextBox1.Text + ListTextlocal.ElementAt(indextext) + Environment.NewLine;
                string locStr = ListHTMLlocal.ElementAt(indextext);
                richTextBox1.AppendText(locStr.Substring(locStr.IndexOf("f=\"") + 3, locStr.IndexOf("\">") - locStr.IndexOf("f=") - 3) + Environment.NewLine);
            }
            richTextBox1.Visible=true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        
        }
    }
}

