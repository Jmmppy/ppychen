using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Models;
using BLL;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class IsForm2 : Form
    {
        public IsForm2()
        {
            InitializeComponent();
        }
        private bool whether_right_click;
        private bool whether_left_click;
        private int data_index;
        ss_visitTableBll ss_visitTableBll_;
        List<cur_ss_visitTable> cur_ss_visitTable_;
        cur_ss_visitTable[] table_list;
        Create_Meeting1 Form_Create_Meeting1;              // 窗体对象
        Create_Meeting2 Form_Create_Meeting2;                 // 窗体对象
        int table_length;
        //
        string patient_name_;
        string operation_name_;
        bool is_visit;
        int page = 0;   //标记左右键的翻页
        List<int> panl_click_indexList = new List<int>();
        #region panl控件是否点击
        private bool panl1_double_Click;
        private bool panl2_double_Click;
        private bool panl3_double_Click;
        private bool panl4_double_Click;
        private bool panl5_double_Click;
        private bool panl6_double_Click;
        private bool panl7_double_Click;
        private bool panl8_double_Click;


        #endregion panl控件是否点击
        private void IsForm2_Load(object sender, EventArgs e)
        {
            ss_visitTableBll_ = new ss_visitTableBll();  //Bll对象
            is_visit = this.chk_isvisit.Checked; ////////////////////
            #region 默认是有选择的
            patient_name_ = this.txtname1.Text.Trim();
            operation_name_ = this.txtname2.Text.Trim();
            is_visit = this.chk_isvisit.Checked;
            //MessageBox.Show(string.Format("成功{0}", is_visit));
            cur_ss_visitTable_ = ss_visitTableBll_.GetSs_visitTableList1().FindAll(m => m.patient_name.Contains(patient_name_) && m.operation_name.Contains(operation_name_) && m.is_bool1==true&&m.is_bool2==false);

            // 是否被悬着过
            //cur_ss_visitTable_ = ss_visitTableBll_.GetSs_visitTableList1().FindAll(m => m.patient_name.Contains(patient_name_) && m.operation_name.Contains(operation_name_) && m.isSelect == is_visit);
            cur_ss_visitTable_.Sort((x, y) => x.narcosis_time.CompareTo(y.narcosis_time));   // narcosis_time时间排序
            table_list = cur_ss_visitTable_.ToArray();
            table_length = table_list.Length; // 数据表对象长度;
            data_index = 0;
            data_card(table_list, table_length);///////////////
            #endregion 默认是有选择的
        }

        private void data_card(cur_ss_visitTable[] table_list, int table_length)
        {
            for (int i = data_index; i < table_length;)                                                       //i 绑定数据库的表数据的索引
            {
               
                int j = 0;                                                                           //j 用于记录8个panel框的哪一个
                //int x = this.Controls.Count;                                                      // this.Controls.Count; 改控件的子控件，计数
                for (int _ = this.Controls.Count - 1; _ >= 0; _--)                                  // 循环this窗体的索引子控件
                {
                    Control panel_cc = this.Controls[_];

                    if (panel_cc is Panel)
                    {
                        // int x = this.Controls.GetChildIndex(panel_cc);
                        panel_cc.Controls[4].Text = table_list[i].narcosis_time.ToString(); //
                        panel_cc.Controls[5].Text = table_list[i].patient_name.ToString();   // 
                        panel_cc.Controls[6].Text = table_list[i].operation_room.ToString(); //
                        panel_cc.Controls[7].Text = table_list[i].operation_name.ToString();
                        //panel_cc.Controls[7].Text = table_list[i].sickroom.ToString();   //   证明可以拿到sickroom
                        i++; j++; data_index++;
                        if (i >= table_length || j > 7)                                             // 数据显示完，或者框体超过8
                        {
                            j = this.Controls.GetChildIndex(panel_cc);                              // 
                            break;
                        }
                    }

                }


                #region 窗体显示
                if (whether_left_click == true)
                {
                    for (int _ = 0; _ < this.Controls.Count; _++)
                    {
                        if (this.Controls[_] is Panel)
                        {
                            this.Controls[_].Show();

                        }
                    }
                    whether_left_click = false;
                }
                #endregion 窗体显示


                #region 窗体隐藏
                for (int _ = 0; _ < this.Controls.Count && _ < j; _++)
                {
                    if (this.Controls[_] is Panel)
                    {
                        this.Controls[_].Hide();

                    }
                }
                break;
                #endregion 窗体隐藏


            }
        }

        #region 左右键的翻页
        private void pBx_right_Click(object sender, EventArgs e)
        {
            if (page >= table_length / 8)
            {
                return;
            }
            else
            {
                page++;
                whether_right_click = true;
                //窗体背景恢复
                Form_panel_refaind();
                ///  data_card方法中有data_index的++ 所以不用加减8
                data_card(table_list, table_length);
            }




        }

        private void pBx_left_Click(object sender, EventArgs e)
        {
           
            
            if (page == 0 || data_index < 8)/////////////
            {
                //this.pBx_left.Enabled = false;
                return;
            }
            else
            {
                page--;
                whether_left_click = true;
                //窗体背景恢复
                Form_panel_refaind();
                data_index = (data_index - 8) / 8;         /// data_index 必须是8的整数被
                data_card(table_list, table_length);
            }


        }
        #endregion 左右键的翻页



        #region 筛选按钮
        private void btnSelect_Click(object sender, EventArgs e)
        {
            getdata();

            //MessageBox.Show(string.Format("成功{0}", data_index));
        }
        /// <summary>
        /// 获取筛选数据的方法，把符合条件的数据放在列表中
        /// </summary>
        private void getdata()
        {
            patient_name_ = this.txtname1.Text.Trim();
            operation_name_ = this.txtname2.Text.Trim();
            is_visit = this.chk_isvisit.Checked;
            //MessageBox.Show(string.Format("成功{0}", is_visit));
            cur_ss_visitTable_ = ss_visitTableBll_.GetSs_visitTableList1().FindAll(m => m.patient_name.Contains(patient_name_) && m.operation_name.Contains(operation_name_) && m.is_bool1 == true && m.is_bool2 == false);

            // 是否被悬着过
            //cur_ss_visitTable_ = ss_visitTableBll_.GetSs_visitTableList1().FindAll(m => m.patient_name.Contains(patient_name_) && m.operation_name.Contains(operation_name_) && m.isSelect == is_visit);
            cur_ss_visitTable_.Sort((x, y) => x.narcosis_time.CompareTo(y.narcosis_time));   // narcosis_time时间排序
            table_list = cur_ss_visitTable_.ToArray();
            table_length = table_list.Length; // 数据表对象长度;
            data_index = 0;
            whether_left_click = true;
            if (table_length == 0)
            {
                MessageBox.Show(string.Format("没有数据"));

            }
            data_card(table_list, table_length);
        }
        #endregion  筛选按钮

        #region 8个panl双击事件
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            
            int idx = 0;
            panl1_double_Click = true;
            int listIndex = idx + page * 8;
            //List<int> panel_DoubleClick_;
            //panel_DoubleClick_.Add(listIndex);        //// 有什么问题？？？
            //Console.WriteLine(table_list[listIndex].patient_name.ToString());
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
            #region 实现把患者id存储到列表，传到创建会议界面上
            string illnessId = table_list[listIndex].illness_id.ToString();
            List<string> illnessId_list = new List<string>();
            illnessId_list.Add(illnessId);
            Form_Create_Meeting1 = new Create_Meeting1( illnessId_list);
            Form_Create_Meeting1.ShowDialog();

            #endregion 实现把患者id存储到列表，传到创建会议界面上
            //if (Form_Create_Meeting1.ShowDialog() == DialogResult.OK)
            //{
            //    //窗体背景恢复
            //    Form_panel_refaind();
            //}
            //下两句只会在点击关闭窗口才会执行
            //窗体背景恢复
            Form_panel_refaind();
            //列表清空
            panl_click_indexList.Clear();

        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            int idx = 1;
            panl1_double_Click = true;
            int listIndex = idx + page * 8;
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
            #region 实现把患者id存储到列表，传到创建会议界面上
            string illnessId = table_list[listIndex].illness_id.ToString();
            List<string> illnessId_list = new List<string>();
            illnessId_list.Add(illnessId);
            Form_Create_Meeting1 = new Create_Meeting1(illnessId_list);
            Form_Create_Meeting1.ShowDialog();
            #endregion 实现把患者id存储到列表，传到创建会议界面上
            //下两句只会在点击关闭窗口才会执行
            //窗体背景恢复
            Form_panel_refaind();
            //列表清空
            panl_click_indexList.Clear();
        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            int idx = 2;
            panl1_double_Click = true;
            int listIndex = idx + page * 8;
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
            #region 实现把患者id存储到列表，传到创建会议界面上
            string illnessId = table_list[listIndex].illness_id.ToString();
            List<string> illnessId_list = new List<string>();
            illnessId_list.Add(illnessId);
            Form_Create_Meeting1 = new Create_Meeting1(illnessId_list);
            Form_Create_Meeting1.ShowDialog();
            #endregion 实现把患者id存储到列表，传到创建会议界面上
            //下两句只会在点击关闭窗口才会执行
            //窗体背景恢复
            Form_panel_refaind();
            //列表清空
            panl_click_indexList.Clear();
        }

        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            int idx = 3;
            panl1_double_Click = true;
            int listIndex = idx + page * 8;
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
            #region 实现把患者id存储到列表，传到创建会议界面上
            string illnessId = table_list[listIndex].illness_id.ToString();
            List<string> illnessId_list = new List<string>();
            illnessId_list.Add(illnessId);
            Form_Create_Meeting1 = new Create_Meeting1(illnessId_list);
            Form_Create_Meeting1.ShowDialog();
            #endregion 实现把患者id存储到列表，传到创建会议界面上
            //下两句只会在点击关闭窗口才会执行
            //窗体背景恢复
            Form_panel_refaind();
            //列表清空
            panl_click_indexList.Clear();
            // openDetails(listIndex);
        }

        private void panel5_DoubleClick(object sender, EventArgs e)
        {
            int idx = 4;
            panl1_double_Click = true;
            int listIndex = idx + page * 8;
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
            #region 实现把患者id存储到列表，传到创建会议界面上
            string illnessId = table_list[listIndex].illness_id.ToString();
            List<string> illnessId_list = new List<string>();
            illnessId_list.Add(illnessId);
            Form_Create_Meeting1 = new Create_Meeting1(illnessId_list);
            Form_Create_Meeting1.ShowDialog();
            #endregion 实现把患者id存储到列表，传到创建会议界面上
            //下两句只会在点击关闭窗口才会执行
            //窗体背景恢复
            Form_panel_refaind();
            //列表清空
            panl_click_indexList.Clear();
        }

        private void panel6_DoubleClick(object sender, EventArgs e)
        {
            int idx = 5;
            panl1_double_Click = true;
            int listIndex = idx + page * 8;
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
            #region 实现把患者id存储到列表，传到创建会议界面上
            string illnessId = table_list[listIndex].illness_id.ToString();
            List<string> illnessId_list = new List<string>();
            illnessId_list.Add(illnessId);
            Form_Create_Meeting1 = new Create_Meeting1(illnessId_list);
            Form_Create_Meeting1.ShowDialog();
            #endregion 实现把患者id存储到列表，传到创建会议界面上
            //下两句只会在点击关闭窗口才会执行
            //窗体背景恢复
            Form_panel_refaind();
            //列表清空
            panl_click_indexList.Clear();
        }

        private void panel7_DoubleClick(object sender, EventArgs e)
        {
            int idx = 6;
            panl1_double_Click = true;
            int listIndex = idx + page * 8;
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
            #region 实现把患者id存储到列表，传到创建会议界面上
            string illnessId = table_list[listIndex].illness_id.ToString();
            List<string> illnessId_list = new List<string>();
            illnessId_list.Add(illnessId);
            Form_Create_Meeting1 = new Create_Meeting1(illnessId_list);
            Form_Create_Meeting1.ShowDialog();
            #endregion 实现把患者id存储到列表，传到创建会议界面上
            //下两句只会在点击关闭窗口才会执行
            //窗体背景恢复
            Form_panel_refaind();
            //列表清空
            panl_click_indexList.Clear();
        }

        private void panel8_DoubleClick(object sender, EventArgs e)
        {
            int idx = 7;
            panl1_double_Click = true;
            int listIndex = idx + page * 8;
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
            //List<int> index_list = new List<int>();
            //index_list.Add(listIndex);
            //Form_Create_Meeting1 = new Create_Meeting1(table_list, index_list);
            //Form_Create_Meeting1.ShowDialog();
            #region 实现把患者id存储到列表，传到创建会议界面上
            string illnessId = table_list[listIndex].illness_id.ToString();
            List<string> illnessId_list = new List<string>();
            illnessId_list.Add(illnessId);
            Form_Create_Meeting1 = new Create_Meeting1(illnessId_list);
            Form_Create_Meeting1.ShowDialog();
            #endregion 实现把患者id存储到列表，传到创建会议界面上
            //下两句只会在点击关闭窗口才会执行
            //窗体背景恢复
            Form_panel_refaind();
            //列表清空
            panl_click_indexList.Clear();
        }


        #endregion 8个panl双击事件
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        #region 8个panl单击,不能再双击
        private void panel1_Click(object sender, EventArgs e)
        {
            int idx = 0;                         // 局部变量记录8个panl中的哪一个
            this.panel1.BackColor = Color.FromArgb(222, 222, 222);
            int listIndex = idx + page * 8;     // 局部变量记录点击后的，该背后的数据index
            panl_click_indexList.Add(listIndex);  // 列表增加一个元素      ????????有问题
            Console.WriteLine(table_list[listIndex].patient_name.ToString());

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            int idx = 1;
            this.panel2.BackColor = Color.FromArgb(222, 222, 222);
            int listIndex = idx + page * 8;
            panl_click_indexList.Add(listIndex);
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            int idx = 2;
            this.panel3.BackColor = Color.FromArgb(222, 222, 222);
            int listIndex = idx + page * 8;
            panl_click_indexList.Add(listIndex);
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            int idx = 3;
            this.panel4.BackColor = Color.FromArgb(222, 222, 222);
            int listIndex = idx + page * 8;
            panl_click_indexList.Add(listIndex);
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            int idx = 4;
            this.panel5.BackColor = Color.FromArgb(222, 222, 222);
            int listIndex = idx + page * 8;
            panl_click_indexList.Add(listIndex);
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            int idx = 5;
            this.panel6.BackColor = Color.FromArgb(222, 222, 222);
            int listIndex = idx + page * 8;
            panl_click_indexList.Add(listIndex);
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            int idx = 6;
            this.panel7.BackColor = Color.FromArgb(222, 222, 222);
            int listIndex = idx + page * 8;
            panl_click_indexList.Add(listIndex);
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            int idx = 7;
            this.panel8.BackColor = Color.FromArgb(222, 222, 222);
            int listIndex = idx + page * 8;
            panl_click_indexList.Add(listIndex);
            Console.WriteLine(table_list[listIndex].patient_name.ToString());
        }

        #endregion  8个panl单击

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (panl_click_indexList.ToArray().Length > 3)
            {
                MessageBox.Show(string.Format("最多只能选择三个！！"));
            }
            else
            {
                Form_Create_Meeting2 = new Create_Meeting2(table_list, panl_click_indexList);
                Form_Create_Meeting2.ShowDialog();
                //窗体背景恢复
                Form_panel_refaind();

                //如果那边点击确定创建
                //这边对应的id要设置为true；
                //……

                //列表清空
                panl_click_indexList.Clear();
                //更新8个panl
                //
            }

        }

        //窗体背景恢复
        private void Form_panel_refaind()
        {
            for (int _ = this.Controls.Count - 1; _ >= 0; _--)                                  // 循环this窗体的索引子控件
            {
                Control panel_cc = this.Controls[_];

                if (panel_cc is Panel)
                {
                    panel_cc.BackColor = Color.FromArgb(253, 253, 253);

                }

            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            //窗体背景恢复
            Form_panel_refaind();
            //列表清空
            panl_click_indexList.Clear();
            
        }
    }
}
