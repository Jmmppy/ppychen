using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        public static int cur_LoginId = 0;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMain()); // 程序开始的窗体
            //Application.Run(new test2()); // 程序开始的窗体

            //List<string> srt_list = new List<string>();
            //srt_list.Add("il003");
            //Application.Run(new Create_Meeting1(srt_list));
            //Application.Run(new Form_apply1());
            //Application.Run(new Form_arrage1());
            //Application.Run(new Form1());
            //Application.Run(new IsForm3());
            //Application.Run(new Form_Route());
            //Applcation.Run(new Form_middle());

        }
    }
}
