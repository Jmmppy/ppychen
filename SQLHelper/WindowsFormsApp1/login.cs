using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  //线程
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using BLL;
using Models;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        string str;
        Doc_loginBLL LoginBLL = new Doc_loginBLL(); // 初始化BLL登录类对象
        public int cur_doctor_id ; //保存当前登录成功的id
        public login()//出生化界面类
        {
            InitializeComponent();
            YZM();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text !="" &&txtPsword.Text !="")
            {//初始化，doc_table表对象(有id， 密码)
                doc_table doc_Table = new doc_table()
                {
                    doctor_id = Convert.ToInt32(this.txtUser.Text.Trim()),
                    //doc_name     
                    pwd = this.txtPsword.Text.Trim()

                };
                bool res;
                res = LoginBLL.login(doc_Table);
                if (txtNumber.Text == str)
                {
                    if (res)
                    {
                        cur_doctor_id = doc_Table.doctor_id;
                        //MainMain MainForm = new MainMain();// 创建主窗体
                        //MainForm.Show();  //显示主页面
                        //this.Owner.Hide();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        MessageBox.Show(string.Format("成功{0}", cur_doctor_id));
                        Console.WriteLine("-------ok:{0}", cur_doctor_id);
                    }
                    else
                    {
                        MessageBox.Show("密码账号出错，请重新输入！");
                        YZM();   //同时更改验证码
                    }
                }
                else
                {
                    MessageBox.Show("验证码不正确请重新输入", "提示");
                    YZM();   //同时更改验证码
                }
            }
            else
            {
                MessageBox.Show("密码账号出错，请重新输入！");
            }
            //定义新表对象用来保存登录成功后的，

            












        }
        
        #region 验证码
        //产生随机数图片
        void YZM()  //方法
        {
            Random r = new Random();//产生随机数
            str = null;
            for (int i = 0; i < 5; i++)
            {
                int rNumber = r.Next(0, 10);
                str += rNumber;
            }//用循环产生所需循环的数量 

            //  label1.Text = str;

            Bitmap bmp = new Bitmap(90, 30);//创建一个位图

            Graphics g = Graphics.FromImage(bmp);



            for (int i = 0; i < 5; i++)
            {
                Point p = new Point(i * 15, 0);
                string[] fonts = { "宋体", "黑体", "仿宋", "隶书", "楷书" };
                Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Black, Color.Pink, };
                g.DrawString(str[i].ToString(), new Font(fonts[r.Next(0, 4)], 20, FontStyle.Bold), new SolidBrush(colors[r.Next(0, 4)]), p);

            }//画随机数

            //for (int i = 0; i < 10; i++)

            //{

            //    Point p1 =new Point(r.Next(0,bmp.Width),r.Next(0,bmp.Height));

            //     Point p2 =new Point(r.Next(0,bmp.Width),r.Next(0,bmp.Height));

            //   g.DrawLine(new Pen(Brushes.Green),p1,p2); 

            //}//随机数上横线

            for (int i = 0; i < 1500; i++)
            {
                Point p = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));

                bmp.SetPixel(p.X, p.Y, Color.Black);

            }//随机数背景加像素

            //将图片放到Picturebox中
            pictureBox2.Image = bmp;//把图片放到 位图上

        }
        #endregion 验证码
        //点击图片 换一个验证码
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            YZM();
        }
        //点击label，换一个验证码
        private void labelBtn_Click(object sender, EventArgs e)
        {
            YZM();
        }

        private void btnCancel_Click(object sender, EventArgs e) //取消按钮 退出程序
        {
            Environment.Exit(0);
        }
    }
}
