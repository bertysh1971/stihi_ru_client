using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] ArgsOSN = { "bertyshav", "2882420519", "5000" };
            List<string> ListHtml = new List<string> {};
            List<string> ListText = new List<string> {};
            Application.Run(new Form1(ArgsOSN));
            //MessageBox.Show("Автор " + ArgsOSN[0]);
            //MessageBox.Show("Пароль " + ArgsOSN[1]);
            //MessageBox.Show("Интервал " + ArgsOSN[2]);
            //MessageBox.Show(Application.StartupPath.ToString());
            Application.Run(new Form2(ArgsOSN, ListHtml,ListText));
            Application.Run(new Form3(ArgsOSN, ListHtml, ListText));

        }
    }
}
