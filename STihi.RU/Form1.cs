using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string[] ArgOsnLocal;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string[] ArgOsn)
        {
            ArgOsnLocal = ArgOsn;
            InitializeComponent();
            textBox1.Text = ArgOsn[0];
            textBox2.Text = ArgOsn[1];
            textBox3.Text = ArgOsn[2];
        }

 
        private void button1_Click(object sender, EventArgs e)
        {
            ArgOsnLocal[0] = textBox1.Text;
            ArgOsnLocal[1] = textBox2.Text;
            ArgOsnLocal[2] = textBox3.Text;
            Close();
        }


        private void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | Char.IsControl( e.KeyChar))
            {
            }

            else
            {
                e.Handled = true;
            }
        }
    }
}
