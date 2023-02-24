using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AForge;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Runtime.InteropServices;
using System.Speech;
using System.Speech.Recognition;
using Models;
using BLL;
using Utility;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        meeting_table cur_meeting_Table;
        ss_visitTableBll ss_visitTableBll_ = new ss_visitTableBll();
        operation_tableBll operation_tableBll_ = new operation_tableBll();

        FilterInfoCollection videoDevices;//摄像头设备集合
        VideoCaptureDevice videoSource;//捕获设备源
        Bitmap img;//拍照处理图片
        Bitmap img22;//线程处理图片
        bool flag_time1 = false; //控制线程处理图片的原子性
        int num1 = 0;           // 记录语音违规次数
        int num2 = 0;           // 记录图片违规次数
        private SRecognition sr;   //语音识别
        ClassCheck check;    //语音检测类
        string vodice_txt;   //语音文本
        Cheak_isOk Cheak_isOk_ = new Cheak_isOk();    //语音文字检测类

        public Form1(meeting_table meeting_tab)
        {
            //meeting_table meeting_tab  /////////////////////
            InitializeComponent();
            ////实例爬虫类，配置网址
            check = new ClassCheck();
            check.webBrowser = webBrowser1;
            check.SetUrl("https://www.book118.com/tool/sqjc/");

            //this.labName2.Text = Program.cur_LoginId
            cur_meeting_Table = meeting_tab;
            #region 患者框
            int count = cur_meeting_Table.illness_id_count;                     //////////////////
            if (count == 1)
            {
                ss_visitTable ss_visitTable_ = ss_visitTableBll_.getss_visitTableObject(cur_meeting_Table.illness_id1);
                operation_table operation_table_ = operation_tableBll_.getOperation_tableObject(ss_visitTable_.operate_id);
                string ss = ss_visitTable_.patient_name.ToString();
                char myChar = ss[0];
                this.label1.Text = Convert.ToString(myChar);
                this.label5.Text = ss;
                this.label6.Text = operation_table_.operation_name.ToString();
                this.label7.Text = Convert.ToString(ss_visitTable_.start_time);
                this.panel3.Hide();
                this.panel4.Hide();
            }
            else if (count == 2)
            {
                ss_visitTable ss_visitTable_ = ss_visitTableBll_.getss_visitTableObject(cur_meeting_Table.illness_id1);
                operation_table operation_table_ = operation_tableBll_.getOperation_tableObject(ss_visitTable_.operate_id);
                string ss = ss_visitTable_.patient_name.ToString();
                char myChar = ss[0];
                this.label1.Text = Convert.ToString(myChar);
                this.label5.Text = ss;
                this.label6.Text = operation_table_.operation_name.ToString();
                this.label7.Text = Convert.ToString(ss_visitTable_.start_time);


                ss_visitTable ss_visitTable_2 = ss_visitTableBll_.getss_visitTableObject(cur_meeting_Table.illness_id2);
                operation_table operation_table_2 = operation_tableBll_.getOperation_tableObject(ss_visitTable_2.operate_id);
                string ss2 = ss_visitTable_2.patient_name.ToString();
                char myChar2 = ss2[0];
                this.label14.Text = Convert.ToString(myChar2);
                this.label12.Text = ss2;
                this.label11.Text = operation_table_2.operation_name.ToString();
                this.label10.Text = Convert.ToString(ss_visitTable_2.start_time);

                this.panel4.Hide();
            }
            else if (count == 3)
            {
                ss_visitTable ss_visitTable_ = ss_visitTableBll_.getss_visitTableObject(cur_meeting_Table.illness_id1);
                operation_table operation_table_ = operation_tableBll_.getOperation_tableObject(ss_visitTable_.operate_id);
                string ss = ss_visitTable_.patient_name.ToString();
                char myChar = ss[0];
                this.label1.Text = Convert.ToString(myChar);
                this.label5.Text = ss;
                this.label6.Text = operation_table_.operation_name.ToString();
                this.label7.Text = Convert.ToString(ss_visitTable_.start_time);


                ss_visitTable ss_visitTable_2 = ss_visitTableBll_.getss_visitTableObject(cur_meeting_Table.illness_id2);
                operation_table operation_table_2 = operation_tableBll_.getOperation_tableObject(ss_visitTable_2.operate_id);
                string ss2 = ss_visitTable_2.patient_name.ToString();
                char myChar2 = ss2[0];
                this.label14.Text = Convert.ToString(myChar2);
                this.label12.Text = ss2;
                this.label11.Text = operation_table_2.operation_name.ToString();
                this.label10.Text = Convert.ToString(ss_visitTable_2.start_time);

                ss_visitTable ss_visitTable_3 = ss_visitTableBll_.getss_visitTableObject(cur_meeting_Table.illness_id3);
                operation_table operation_table_3 = operation_tableBll_.getOperation_tableObject(ss_visitTable_3.operate_id);
                string ss3 = ss_visitTable_3.patient_name.ToString();
                char myChar3 = ss3[0];
                this.label21.Text = Convert.ToString(myChar3);

                this.label19.Text = ss3;
                this.label18.Text = operation_table_3.operation_name.ToString();
                this.label17.Text = Convert.ToString(ss_visitTable_3.start_time);

            }
            #endregion 
        }


        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(
         string lpstrCommand,
         string lpstrReturnString,
         int uReturnLength,
         int hwndCallback
        );

        private void Form1_Load(object sender, EventArgs e)
        {
            //先检测电脑所有的摄像头
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            MessageBox.Show("检测到了" + videoDevices.Count.ToString() + "个摄像头！");
            //默认打开
            comboBox1.SelectedItem = "摄像头1";
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            //语音识别
            string[] fg = { "东方", "西方", "南方", "北方" ,"风骚","诱人","打开声音","这里","我","又设置了",
            "每5秒","进行","一次","可以","完成","实时的语音识别","语音","文字检测","的"};
            sr = new SRecognition(fg);
            //button3.Enabled = false;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShutCamera();
            if (comboBox1.Text == "摄像头1" && videoDevices.Count > 0)
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            else if (comboBox1.Text == "摄像头2" && videoDevices.Count > 1)
                videoSource = new VideoCaptureDevice(videoDevices[1].MonikerString);
            else
            {
                MessageBox.Show("选择的摄像头不存在！！！");
                return;
            }
            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();

            button1.Enabled = true;//开启“拍摄功能”

        }

        /// <summary>
        /// // 关闭并释放摄像头
        /// </summary>
        public void ShutCamera()
        {
            if (videoSourcePlayer1.VideoSource != null)
            {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
                videoSourcePlayer1.VideoSource = null;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShutCamera();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            img = videoSourcePlayer1.GetCurrentVideoFrame();//拍摄
            pictureBox1.Image = img;
            //图片处理--二维码识别
            Cheak_QRcode cheak_QRcode = new Cheak_QRcode();
            bool ss = cheak_QRcode.Cheak_IF_QRcode(img);
            if (ss)
            {
                MessageBox.Show(string.Format("存在二维码违规成功"));
                this.txbmessage2.Text = "存在二维码违规!!";
                //有二维码的图片显示
                this.pictureBox4.Visible = true;
                pictureBox4.Image = img;
                this.pictureBox4_panel9.BackColor = Color.Red;   //////////////
                //保存图片：不做了
            }
            



            button2.Enabled = true;//开启“保存”功能
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //以当前时间为文件名，保存为jpg格式
                //图片路径在程序bin目录下的Debug下
                TimeSpan tss = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                long a = Convert.ToInt64(tss.TotalMilliseconds) / 1000;  //以秒为单位
                img.Save(string.Format("{0}.jpg", a.ToString()));
                MessageBox.Show("保存成功！");
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ShutCamera();
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            mciSendString("set wave bitpersample 8", "", 0, 0);

            mciSendString("set wave samplespersec 20000", "", 0, 0);
            mciSendString("set wave channels 2", "", 0, 0);
            mciSendString("set wave format tag pcm", "", 0, 0);
            mciSendString("open new type WAVEAudio alias movie", "", 0, 0);
            mciSendString("record movie", "", 0, 0);
            //语音识别为文字
            sr.BeginRec(textBox1);
            btnOn.Enabled = false;
            btnSpouse.Enabled = true;
            this.timer2.Enabled = true;
        }

        private void btnSpouse_Click(object sender, EventArgs e)
        {


            this.timer2.Enabled = false;
            //先删除之前的
            //再保存 
            mciSendString("stop movie", "", 0, 0);
            mciSendString("save movie 1.wav", "", 0, 0);
            mciSendString("close movie", "", 0, 0);
            SpeechRecognition(@"C:\Users\1\Desktop\SQLHelper\WindowsFormsApp1\bin\Debug\1.wav");
            // this.txbmessage.Text = str;
            sr.over();

            #region 语音内容检测
            //string void_string = this.textBox1.Text;   //拿到需要检测得语音文本

           
            ////语音检测
            //if (this.textBox1.Text == "")
            //{
            //    return;
            //}
            //check.sta = 0;
            ////使用check处理文件取得处理结果
            //if (check.CheckStr(this.textBox1.Text))
            //{
            //    check.sta = 1;


            //    Thread thread = new Thread(() =>
            //    {
            //        while (check.CheckStr(textBox1.Text) == true)
            //        {
            //        }
            //        if (check.CheckStr("") == true)
            //        {
            //            txbmessage.Invoke(new Action(() => { txbmessage.Text = "通过"; webBrowser1.Document.ExecCommand("Refresh", false, null); }));
                        

            //        }

            //        else
            //        {
            //            txbmessage.Invoke(new Action(() => { txbmessage.Text = "语音涉黄，违规！！！"; webBrowser1.Document.ExecCommand("Refresh", false, null); num1++; this.lab_num1.Text = num1.ToString(); }));
                        
            //            //webBrowser1.Select();
            //            //check.SetClose();
            //        }
            //    });
            //    thread.Start();

            //}
            //else
            //    txbmessage.Text = "提交失败,请检查网页状态，排除网络登录等情况";
            
            #endregion 语音检测
            btnOn.Enabled = true;
            btnSpouse.Enabled = false;
            //webBrowser1.Document.ExecCommand("Refresh", false, null);
        }

        public string SpeechRecognition(string wavPath)
        {
            try
            {
                System.Speech.Recognition.SpeechRecognitionEngine sre = new System.Speech.Recognition.SpeechRecognitionEngine();
                sre.LoadGrammar(new System.Speech.Recognition.DictationGrammar());
                sre.SetInputToWaveFile(wavPath);
                string res = null;
                StringBuilder sb = new StringBuilder();
                do
                {
                    try
                    {
                        RecognitionResult result = sre.Recognize();
                        if (result != null)
                        {
                             res = result.Text;
                        }
                        else
                        {
                            Console.WriteLine("No recognition result available.");
                        }
                       
                    }
                    catch (Exception)
                    {
                        res = null;
                    }
                    sb.Append(res);
                } while (res != null);
                sre.Dispose();
                return (sb.ToString());
            }
            catch (Exception e)
            {
                return (e.Message);
            }
           






        }

        private void button4_Click(object sender, EventArgs e)
        {

            //sr.BeginRec(textBox1);
            //button4.Enabled = false;
            //button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //sr.over();
            //button4.Enabled = true;
            //button3.Enabled = false;
        }

        /// <summary>
        /// 类线程，每一秒执行一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //拿图
            //判断是否存在二维码
            //if 存在 提醒
            //if not pass
            
            img22 = videoSourcePlayer1.GetCurrentVideoFrame();//拍摄
            
           
            //图片处理--二维码识别
            Cheak_QRcode cheak_QRcode = new Cheak_QRcode();
            bool ss = cheak_QRcode.Cheak_IF_QRcode(img22);
            if (ss)
            {
                num2++;
                //MessageBox.Show(string.Format("存在二维码违规成功"));
                this.txbmessage2.Text = "存在二维码违规!!";
                //有二维码的图片显示
                this.pictureBox4.Visible = true;
                pictureBox4.Image = img22;
                this.pictureBox4_panel9.BackColor = Color.Red;   //////////////
                this.lab_num2.Text = num2.ToString();
                //保存图片：不做了
            }
           

        }
        /// <summary>
        /// 语音检测线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            #region 语音内容检测
            //vodice_txt = this.textBox1.Text;   //拿到需要检测得语音文本


            //if (vodice_txt!="")
            //{
            //    //语音检测
            //    if (this.textBox1.Text == "")
            //    {
            //        return;
            //    }
            //    check.sta = 0;
            //    //使用check处理文件取得处理结果
            //    if (check.CheckStr(this.textBox1.Text))
            //    {
            //        check.sta = 1;


            //        Thread thread = new Thread(() =>
            //        {
            //            while (check.CheckStr(textBox1.Text) == true)
            //            {
            //            }
            //            if (check.CheckStr("") == true)
            //            {
            //                txbmessage.Invoke(new Action(() => { txbmessage.Text = "通过"; webBrowser1.Document.ExecCommand("Refresh", false, null); this.textBox1.Text = ""; }));


            //            }

            //            else
            //            {
            //                txbmessage.Invoke(new Action(() => { txbmessage.Text = "语音涉黄，违规！！！"; webBrowser1.Document.ExecCommand("Refresh", false, null); num1++; this.lab_num1.Text = num1.ToString(); this.textBox1.Text = ""; }));

            //                //webBrowser1.Select();
            //                //check.SetClose();
            //            }
            //        });
            //        thread.Start();

            //    }
            //    else
            //        txbmessage.Text = "提交失败,请检查网页状态，排除网络登录等情况";
            //}

            #endregion 语音检测

            vodice_txt = this.textBox1.Text;   //拿到需要检测得语音文本
            if (vodice_txt != "")
            {
                if (this.textBox1.Text != "")
                {
                    if (Cheak_isOk_.Word_Cheak_is_OK(vodice_txt))
                    {//真 ，有涉黄字：
                        txbmessage.Text = "语音涉黄，违规！！！";
                        num1++;
                        this.lab_num1.Text = num1.ToString();
                        this.textBox1.Text = "";
                    }
                    else
                    {
                        txbmessage.Text = "通过";
                        this.textBox1.Text = "";
                    }
                }
                
                


            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            labDate3.Text = DateTime.Now.ToLongTimeString().ToString();
        }

        private void btn_change_Click(object sender, EventArgs e)
        {

        }
    }
}
