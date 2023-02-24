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
using Utility;

namespace WindowsFormsApp1
{
    public partial class Form_mettingUp : Form
    {
        meeting_tableBll meeting_tableBll_ = new meeting_tableBll();
        meeting_table cur_meeting_Table;
        DateTime t1;
        DateTime t2;
        public Form_mettingUp(meeting_table meeting_Table)
        {
            cur_meeting_Table = meeting_Table;
            InitializeComponent();
            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - this.Width;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - this.Height;
            Point p = new Point(x, y);
            this.PointToScreen(p);
            this.Location = p;


        }

        private void Form_mettingUp_Load(object sender, EventArgs e)
        {
            this.lab_title.Text = cur_meeting_Table.meeting_name.ToString();
            t1 = Convert.ToDateTime(cur_meeting_Table.start_time);
            t2 = Convert.ToDateTime(cur_meeting_Table.end_time);

            this.lab_start.Text = t1.Hour.ToString() + ":" + t1.Minute.ToString();
            this.lab_end.Text = t2.Hour.ToString() + ":" + t2.Minute.ToString();
            this.lab_count.Text = cur_meeting_Table.illness_id_count.ToString();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
           
            
            
        }
        /// <summary>
        /// 推迟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string laid_time = this.comboBox1.Text;
            DateTime start_time;
            int row = 0;
            if (laid_time.Length != 0)
            {//更新开始时间
                if (laid_time == "5分钟")
                {
                    start_time = t1.AddMinutes(5);
                    //跟新到数据库
                    row = meeting_tableBll_.update_isMeeting2(cur_meeting_Table.meeting_id, start_time);

                }
                else if (laid_time == "10分钟")
                {
                    start_time = t1.AddMinutes(10);
                    row = meeting_tableBll_.update_isMeeting2(cur_meeting_Table.meeting_id, start_time);
                }
                else
                {//laid_time == "15分钟"
                    start_time = t1.AddMinutes(15);
                    row = meeting_tableBll_.update_isMeeting2(cur_meeting_Table.meeting_id, start_time);
                }
            }
            if (row == 1)
            {
                MessageBox.Show(string.Format("成功推迟"));
                this.Close();
            }
            
        }

        private void picB_ok_Click(object sender, EventArgs e)
        {
            //加入会议

            Form1 Form1_ = new Form1(cur_meeting_Table);////////////////////////
            //Form1 Form1_ = new Form1();

            this.Close();
            this.DialogResult = DialogResult.OK;
            Form1_.Show();
        }

        private void picB_close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
