using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Models;
using BLL;
using Utility;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace WindowsFormsApp1
{

    public partial class MainMain : Form
    {
        //主界面的初始化，先隐藏主界面，调用login界面
        notice_tableBll notice_TableBll_ = new notice_tableBll(); // 初始化BLL中notice_tableBll类对象
        notice_table notice_Table_ = new notice_table(); // 初始化Models中notice_table类对象
        doc_tableBll _doc_tableBll = new doc_tableBll(); // 初始化BLL中doc_tableBll类对象
        doc_table doc_table_ = new doc_table();   //初始化Models中doc_table表全局对象
        meeting_tableBll meeting_tableBll_ = new meeting_tableBll();   ////
        string cur_idTostring;   //当前登录人的id string
        int index_picture_index;
        Bitmap bmpt;


        public MainMain()
        {

            InitializeComponent();
            timer1.Start();
            #region 主窗体隐藏先登录
            login form1_login1 = new login();   // 初始化login界面 对象
            DialogResult dialogResult = form1_login1.ShowDialog(this);
            this.Hide();


            int cur_id = form1_login1.cur_doctor_id;
            string cur_doctor_id_str = Convert.ToString(cur_id);  // 吧登录成功的id转化为字符串
            if (cur_doctor_id_str != null)
            {
                this.Show();
                Program.cur_LoginId = cur_id;   //把登录成功的id作为整个项目全局对象。


            }
            #endregion 主窗体隐藏先登录
            // MessageBox.Show(string.Format("成功{0}", cur_id));

            #region 绑定notice_table表数据
            // 初始化绑定notice_table表数据
            this.dgvNotice.AutoGenerateColumns = false;  //控制DataGriView只显示需要的列
            this.dgvNotice.DataSource = notice_TableBll_.Getnotice_TableList();
            #endregion 绑定notice_table表数据


            //初始化当前登录人的信息
            cur_idTostring = Convert.ToString(cur_id);


            doc_table_ = get_cur_doc_table(cur_id);  // 当前登录人的对象
            labName1.Text = doc_table_.doc_name.ToString();
            labName2.Text = doc_table_.doc_name.ToString();
            // MessageBox.Show(string.Format("成功{0}", cur_doc.doc_name.ToString()));
            //string cur_idTostring2 = Regex.Replace(cur_idTostring, @"(?<=.{3}.*)", "");  // 正则取前三位
            string cur_idTostring2 = cur_idTostring.Substring(0, 3);
            #region 用户权限约束
            //if (cur_idTostring2 == "303")    // 护士
            //{
            //    this.pictureBox6.Enabled = false;
            //    this.pictureBox4.Enabled = true;
            //    this.pictureBox5.Enabled = true;
            //}
            //else if(cur_idTostring2 == "102")   // 访视用户就进不去手术申请和排班
            //{
            //    this.pictureBox6.Enabled = true;
            //    this.pictureBox4.Enabled = false;
            //    this.pictureBox5.Enabled = false;


            //}
            //else if (cur_idTostring2 == "202")     //医师
            //{
            //    this.pictureBox6.Enabled = false;
            //    this.pictureBox4.Enabled = true;
            //    this.pictureBox5.Enabled = true;
            //}
            #endregion 用户权限约束
        }








        #region 星期几输出
        private string GetWeek()
        {
            string week = string.Empty;
            switch ((int)DateTime.Now.DayOfWeek)
            {
                case 0:
                    week = "星期日";
                    break;
                case 1:
                    week = "星期一";
                    break;
                case 2:
                    week = "星期二";
                    break;
                case 3:
                    week = "星期三";
                    break;
                case 4:
                    week = "星期四";
                    break;
                case 5:
                    week = "星期五";
                    break;
                case 6:
                    week = "星期六";
                    break;

            }
            return week;
        }
        #endregion 星期几输出

        #region 根据当前登录人的id放回对象
        private doc_table get_cur_doc_table(int id)
        {
            doc_table cur_doc_table = _doc_tableBll.getCurDoc_table(id);
            return cur_doc_table;
        }
        #endregion 根据当前登录人的id放回对象

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainMain_MouseEnter(object sender, EventArgs e)
        {

        }

        private void MainMain_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            //退出登录，打开登录窗口
            //Application.Run(new MainMain());

            new MainMain();
        }
        // 点击进入访视系统界面
        private void pictureBox6_Click(object sender, EventArgs e)
        {

            // 打开访视系统界面
            Form_visit form_visit = new Form_visit(doc_table_, bmpt);
            this.Hide();
            //form_visit.ShowDialog(this);
            if (form_visit.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }

            // 还是要把当前登录对象传过去、当前时间  ——》后期考虑放在tools中
        }

        private void dgvNotice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #region 双击一行 进去新窗口
        private void dgvNotice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int cur_notice_id = Convert.ToInt32(this.dgvNotice.CurrentRow.Cells[0].Value.ToString());
            Form_notice Form_notice_ = new Form_notice(cur_notice_id);
            Form_notice_.ShowDialog();
        }
        #endregion 双击一行 进去新窗口

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region  初始化时间
            labDate1.Text = DateTime.Now.ToLongDateString().ToString();
            labDate2.Text = GetWeek().ToString();
            labDate3.Text = DateTime.Now.ToLongTimeString().ToString();
            #endregion 初始化时间
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // 打开访手术申请统界面
            //Form_apply1 Form_apply1_ = new Form_apply1();
            Form_apply0 Form_apply0_ = new Form_apply0();
            this.Hide();
            //Form_apply1_.ShowDialog(this);
            if (Form_apply0_.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }

            // 还是要把当前登录对象传过去、当前时间  ——》后期考虑放在tools中
        }

        private void MainMain_Load(object sender, EventArgs e)
        {
            #region 
            FillPieChart();
            #region 随机化头像
            Random rd = new Random();
            index_picture_index = rd.Next(1,4);
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            byte[] picturebytes;
            string ImagePath;
            
            if (index_picture_index == 1)
            {
                ImagePath = @"C:\Users\1\Desktop\SQLHelper\WindowsFormsApp1\Images\728452215511895916.jpg";                               
                FileStream fs = new FileStream(ImagePath, FileMode.Open);
                picturebytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                picturebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                MemoryStream ms = new MemoryStream(picturebytes);
                bmpt = new Bitmap(ms);
                this.pictureBox3.Visible = true;
                //this.pictureBox6.Image = bmpt;
                this.pictureBox3.BackgroundImage = bmpt;
                this.pictureBox13.BackgroundImage = bmpt;



            }
            else if (index_picture_index == 2)
            {
                ImagePath = @"C:\Users\1\Desktop\SQLHelper\WindowsFormsApp1\Images\728452215511895916.jpg";
                FileStream fs = new FileStream(ImagePath, FileMode.Open);
                picturebytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                picturebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                MemoryStream ms = new MemoryStream(picturebytes);
                bmpt = new Bitmap(ms);
                this.pictureBox3.Visible = true;
                //this.pictureBox6.Image = bmpt;
                this.pictureBox3.BackgroundImage = bmpt;
                this.pictureBox13.BackgroundImage = bmpt;

            }
            else
            {
                ImagePath = @"C:\Users\1\Desktop\SQLHelper\WindowsFormsApp1\Images\728452215511895916.jpg";
                FileStream fs = new FileStream(ImagePath, FileMode.Open);
                picturebytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                picturebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                MemoryStream ms = new MemoryStream(picturebytes);
                bmpt = new Bitmap(ms);
                this.pictureBox3.Visible = true;
                //this.pictureBox6.Image = bmpt;
                this.pictureBox3.BackgroundImage = bmpt;
                this.pictureBox13.BackgroundImage = bmpt;

            }
            #endregion 随机化头像

            #endregion
        }


        private void FillPieChart()
        {
            #region 
            string[] x = new string[] { "访视医生", "诊断医生", "护士" };//将饼图分为3块分别代表三块不同的油田
            int[] y = new int[] { 30, 78, 30 };//代表三块不同的油田的数值
            //实习3D画面
            //this.chartpie.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.chartpie.Series[0].ChartType = SeriesChartType.Doughnut;//选择图的类型为饼图
            //this.chartpie.Series[0].MarkerSize = 5;
            //this.chartpie.Series[0].MarkerStyle = MarkerStyle.Circle;
            //this.chartpie.Series[0]["PieLineColor"] = "Black";
            this.chartpie.Series[0]["PieLabelStyle"] = "Outside";
            
            //this.chartpie.Series[0].CustomProperties = "DoughnutRadius = 20";

            this.chartpie.Series[0].Points.DataBindXY(x, y);//绑定xy数据
            #endregion


            string[] x1 = new string[] { "访视医生", "诊断医生", "护士" };//将饼图分为3块分别代表三块不同的油田
            int[] y1 = new int[] { 90, 78, 30 };//代表三块不同的油田的数值
            //实习3D画面
            //this.chartpie.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.chart1.Series[0].ChartType = SeriesChartType.Doughnut;//选择图的类型为饼图
            //this.chartpie.Series[0].MarkerSize = 5;
            //this.chartpie.Series[0].MarkerStyle = MarkerStyle.Circle;
            //this.chartpie.Series[0]["PieLineColor"] = "Black";
            this.chart1.Series[0]["PieLabelStyle"] = "Outside";

            //this.chartpie.Series[0].CustomProperties = "DoughnutRadius = 20";

            this.chart1.Series[0].Points.DataBindXY(x1, y1);//绑定xy数据
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // 打开访手术申请统界面
            Form_arrage1 Form_arrage1_ = new Form_arrage1();
            this.Hide();
            //Form_arrage1_.ShowDialog(this);
            if (Form_arrage1_.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }

            // 还是要把当前登录对象传过去、当前时间  ——》后期考虑放在tools中
        }

        #region 分页控件
        // 首页
        private void btnFirst_Click(object sender, EventArgs e)
        {

        }
        // 上一页
        private void btnPrev_Click(object sender, EventArgs e)
        {


        }
        // 下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
;

        }
        // 尾页
        private void btnLast_Click(object sender, EventArgs e)
        {


        }
        #endregion
        /// <summary>
        /// 每隔几秒钟去查一下会议表，看是否有小于或等于5分钟的，if有则提示。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metting_timer_Tick(object sender, EventArgs e)
        {
           

            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            // 打开访视系统界面
            Form_middle form_visit = new Form_middle();
            this.Hide();
            form_visit.ShowDialog(this);
            if (form_visit.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
