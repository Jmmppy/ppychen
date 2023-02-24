using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;


//using SeleniumUtil;

namespace WindowsFormsApp1
{
    public partial class test2 : Form
    {
        Cheak_isOk Cheak_isOk_ = new Cheak_isOk();
        public test2()
        {
            
            InitializeComponent();
        }


        private void test2_Load(object sender, EventArgs e)
        {

            string str = "时期后欧珀是完全解耦赔偿jqcJPOVKVKDkcKVPFPOJAV O[KJOCSDKA[WEKEL[采集的实际库存，操";
            if (str != "")
            {
                if (Cheak_isOk_.Word_Cheak_is_OK(str))
                {//真 ，有涉黄字：
                    //txbmessage.Text = "语音涉黄，违规！！！";
                    //num1++;
                    //this.lab_num1.Text = num1.ToString();
                    //this.textBox1.Text = "";
                    MessageBox.Show(string.Format("成功"));
                }
                else
                {
                    //txbmessage.Text = "通过";
                    //this.textBox1.Text = "";
                    MessageBox.Show(string.Format("失败"));
                }
            }


        }



    }
}
