using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using BLL;

namespace WindowsFormsApp1
{

    public partial class Create_Meeting1 : Form
    {
        //List<int> cur_index = new List<int>();
        //ss_visitTableBll ss_visitTableBll_;
        //List<cur_ss_visitTable> cur_ss_visitTable_;
        //cur_ss_visitTable[] cur_table_list;
        //int table_length;
        meeting_tableBll meeting_tableBll_ = new meeting_tableBll();
        List<string> cur_illnessId_list = new List<string>();
        private bool isSelect = false;
        private string txb_title_;
        private DateTime metting_start;
        private DateTime metting_end;
        private string metting_pwd;
        private int list_len;
        private int t;

        

        /// <summary>
        /// 初始化函数，
        /// </summary>
        /// <param name="记录"></param>
        /// <param name="index_list"></param>
        public Create_Meeting1(List<string>illnessId_list)
        {
            InitializeComponent();
            illnessId_list.ForEach(i => cur_illnessId_list.Add(i));   //列表复制
            //头参数cur_ss_visitTable[] table_list, List< int > index_list
            //index_list.ForEach(i => cur_index.Add(i));   //列表复制
            //cur_table_list = table_list;



        }

        private void Create_Meeting1_Load(object sender, EventArgs e)
        {
            this.timer3.Enabled = false;
            /*
            #region 来源于isForm2
            ss_visitTableBll_ = new ss_visitTableBll();  //Bll对象
            cur_ss_visitTable_ = ss_visitTableBll_.GetSs_visitTableList1();

            cur_ss_visitTable_.Sort((x, y) => x.narcosis_time.CompareTo(y.narcosis_time));   // narcosis_time时间排序
            table_list = cur_ss_visitTable_.ToArray(); // list转化为数组
                                                       
            table_length = table_list.Length; // 数据表对象长度;
            #endregion 来源于isForm2
            */




            //this.label1.Text = cur_table_list[cur_index[0]].patient_name.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.txb_title.Text = "";
        }
        //当鼠标在会议密码上的操作
        private void ckB_mettingPwd_MouseEnter(object sender, EventArgs e)
        {
            isSelect = this.ckB_mettingPwd.Checked;
            if (isSelect)
            {
                this.txb_pwd.Show();
                this.pictureBox2.Show();


            }
            else
            {
                this.txb_pwd.Hide();
                this.pictureBox2.Hide();

            }
        }

        private void ckB_mettingPwd_MouseDown(object sender, MouseEventArgs e)
        {

        }
        #region 密码的可见与隐藏
        private void pictureBox2_Click(object sender, EventArgs e)
        {           
            this.txb_pwd.PasswordChar = '\0';
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.txb_pwd.PasswordChar = '*';
        }
        #endregion 密码的可见与隐藏

        #region 控制是否输入密码
        private void timer2_Tick(object sender, EventArgs e)
        {
            isSelect = this.ckB_mettingPwd.Checked;
            if (isSelect)
            {
                this.txb_pwd.Show();
                this.pictureBox2.Show();


            }
            else
            {
                this.txb_pwd.Hide();
                this.pictureBox2.Hide();

            }
        }
        #endregion 控制是否输入密码

        private void btnOK_Click(object sender, EventArgs e)
        {
            meeting_table meeting_table_ = new meeting_table();
            txb_title_ = this.txb_title.Text.Trim();
            metting_start = Convert.ToDateTime(this.dateTimePicker_start.Value);
            metting_end = Convert.ToDateTime(this.dateTimePicker_end.Value);
            metting_pwd = this.txb_pwd.Text.Trim();
            list_len = cur_illnessId_list.ToArray().Length; list_len = cur_illnessId_list.ToArray().Length;
            if (txb_title_ == "")
            {
                txb_title_ = "0";
            }
            
            if (metting_pwd == "")
            {
                metting_pwd = "0";
            }
            if (DateTime.Compare(metting_start, metting_end) >= 0)
            {
                MessageBox.Show(string.Format("设置的时间不对！"));
            }
            else
            {
                if (list_len == 1)
                {
                    meeting_table_ = new meeting_table()
                    {
                        meeting_name = txb_title_,
                        start_time = metting_start,
                        end_time = metting_end,
                        meeting_Key = metting_pwd,
                        illness_id_count = list_len,
                        illness_id1 = (string)cur_illnessId_list[0],
                        illness_id2 = (string)"0",
                        illness_id3 = (string)"0",
                        Belong_doc = Program.cur_LoginId


                    };
                }
                if (list_len == 2)
                {
                    meeting_table_ = new meeting_table()
                    {
                        meeting_name = txb_title_,
                        start_time = metting_start,
                        end_time = metting_end,
                        meeting_Key = metting_pwd,
                        illness_id_count = list_len,
                        illness_id1 = (string)cur_illnessId_list[0],
                        illness_id2 = (string)cur_illnessId_list[1],
                        illness_id3 = (string)"0",
                        Belong_doc = Program.cur_LoginId
                    };
                }
                if (list_len == 3)
                {
                    meeting_table_ = new meeting_table()
                    {
                        meeting_name = txb_title_,
                        start_time = metting_start,
                        end_time = metting_end,
                        meeting_Key = metting_pwd,
                        illness_id_count = list_len,
                        illness_id1 = (string)cur_illnessId_list[0],
                        illness_id2 = (string)cur_illnessId_list[1],
                        illness_id3 = (string)cur_illnessId_list[2],
                        Belong_doc = Program.cur_LoginId
                    };
                }

                int row = meeting_tableBll_.insert_meeting_table(meeting_table_);
                if (row == 1)
                {//插入成功
                    this.timer3.Enabled = true;
                    int t = 2;
                    //MessageBox.Show("插入成功", $"提示!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //t = t - 1;
            //if (t == 0)
            //{
            //    timer3.Enabled = false;

            //}
            //MessageBox.Show("插入成功", $"提示！{t}秒后关闭");
            
            
        

        }
    }
}
