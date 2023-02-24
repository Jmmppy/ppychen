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
    public partial class IsForm3 : Form
    {
        meeting_tableBll meeting_tableBll_ = new meeting_tableBll();
        DateTime Cur_time;
        DateTime Cur_time2;
        bool cheak_time = false;
        #region 完成分页的前提
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int pageSize = 8;

        /// <summary>
        /// 总记录数
        /// </summary>
        public int recordCount = 0;

        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount = 0;

        /// <summary>
        /// 当前页
        /// </summary>
        public int currentPage = 0;
        DataTable mettingTable;
        List_To_table List_To_table_ = new List_To_table();
        #endregion 
        public IsForm3()
        {
            InitializeComponent();
            Metting_Date_Show();
            cheak_time = true;
        }

        private void IsForm3_Load(object sender, EventArgs e)
        {

        }
        private void Metting_Date_Show()
        {
            #region 绑定 meeting_table表数据
            this.dgv_metting.AutoGenerateColumns = false;
            List<meeting_table> cur_smeeting_table_ = meeting_tableBll_.GetMeeting_tableList1();
            //列表的复制
            List<meeting_table> cur2_meeting_table_ = new List<meeting_table>();
            cur_smeeting_table_.FindAll(m => m.ismetting == false && m.Belong_doc == Program.cur_LoginId ).ForEach(i => cur2_meeting_table_.Add(i));
            ////this.dgv_metting.DataSource = meeting_tableBll_.GetMeeting_tableList1();
            if (cur2_meeting_table_.ToArray().Length != 0)
            {//如果登录对象所对应的他创建的会议记录bu 不空时
                this.btnFirst.Enabled = true;
                this.btnPrev.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
                mettingTable = List_To_table.ToDataTable(cur2_meeting_table_);           // 运用工具类把List对象转化为DataTable
                recordCount = mettingTable.Rows.Count;     //记录总行数
                pageCount = (recordCount / pageSize);
                if ((recordCount % pageSize) > 0)
                {
                    pageCount++;
                }

                //默认第一页
                currentPage = 1;
                LoadPage();//调用加载数据的方法

            }
            else
            {//如果登录对象所对应的他创建的会议记录为空时
                this.btnFirst.Enabled = false;
                this.btnPrev.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }

            #endregion 绑定 meeting_table表数据
        }
        private void LoadPage()
        {
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;    //开始指针
            int endRecord;      //结束指针
            DataTable dtTemp;
            dtTemp = mettingTable.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = recordCount;
            for (int i = beginRecord; i < endRecord; i++)
            {
                dtTemp.ImportRow(mettingTable.Rows[i]);
            }

            dgv_metting.Rows.Clear();

            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                dgv_metting.Rows.Add(new object[] { dtTemp.Rows[i][0], dtTemp.Rows[i][1], dtTemp.Rows[i][2], dtTemp.Rows[i][3], dtTemp.Rows[i][4] });
            }

            labPageIndex.Text = "当前页: " + currentPage.ToString() + " / " + pageCount.ToString();//当前页
            labRecordCount.Text = "总行数: " + recordCount.ToString() + " 行";//总记录数
        }

        /// <summary>
        /// 每隔几秒钟去查一下会议表，看是否有小于或等于5分钟的，if有则提示。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metting_timer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show(string.Format("成功"));
            Metting_Date_Show();
            meeting_table meeting_Table;
            if (cheak_time)
            {
                Cur_time = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                Cur_time2 = Cur_time.AddMinutes(5);
                meeting_Table = meeting_tableBll_.getmeeting_tableObject2(Cur_time, Cur_time2);
                if (meeting_Table.meeting_id != 0)
                {//查到了提示
                    this.metting_timer.Enabled = false;
                    Form_mettingUp Form_mettingUp_ = new Form_mettingUp(meeting_Table);
                    //Form_mettingUp_.ShowDialog();    多余！！！！！！
                    
                    if (Form_mettingUp_.ShowDialog() == DialogResult.OK)
                    {//加入了会议
                     //不是删除刚那一条记录而是增加是否有加入的bool变量。
                        int row = meeting_tableBll_.update_isMeeting(meeting_Table.meeting_id, true);
                        // 更新
                        //timer打开
                        Metting_Date_Show();
                        this.metting_timer.Enabled = true;

                    }
                    this.metting_timer.Enabled = true;
                    Metting_Date_Show();

                }
            }
        }
        #region 分页控件
        // 首页
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            { return; }
            currentPage = 1;
            LoadPage();
        }
        // 上一页
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            { return; }
            currentPage--;
            LoadPage();
        }
        // 下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage == pageCount)
            { return; }
            currentPage++;
            LoadPage();
        }
        // 尾页
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (currentPage == pageCount)
            { return; }
            currentPage = pageCount;
            LoadPage();
        }
        #endregion 分页控件

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string strPath = @"F:\毕业设计所用测试文件夹\访视所用表";
            System.Diagnostics.Process.Start("explorer.exe", strPath);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string strPath = @"F:\毕业设计所用测试文件夹\访视所用视频";
            System.Diagnostics.Process.Start("explorer.exe", strPath);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string strPath = @"F:\毕业设计所用测试文件夹\访视所用文件夹";
            System.Diagnostics.Process.Start("explorer.exe", strPath);
        }
    }
}
