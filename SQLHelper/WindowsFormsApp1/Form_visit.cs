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
using System.IO;

namespace WindowsFormsApp1
{
    
    public partial class Form_visit : Form
    {
        #region 窗体加载
        IsForm1 _IsForm1;
        IsForm2 _IsForm2;
        IsForm3 _IsForm3;
        IsForm4 _IsForm4;
        IsForm5 _IsForm5;
        #endregion 窗体加载
        doc_table doc_table_ = new doc_table(); //当前登录的doc_table对象
        partment_tableBll partment_tableBll_ = new partment_tableBll();
        public Form_visit(doc_table doc_tab, Bitmap bmpt)
        {
            InitializeComponent();
            timer1.Start();
            doc_table_ = doc_tab;
            #region 显示登录的人信息
            this.labName1.Text = doc_table_.doc_name.ToString();
            this.labName2.Text = doc_table_.doc_name.ToString();
            this.lab_profession.Text = doc_table_.profession.ToString();
            this.labpice_place.Text = doc_table_.pice_place.ToString();
            int part_id = Convert.ToInt32(doc_table_.partment_id);
            //this.labpartment.Text = Convert.ToString(part_id); 这里证明正确
            partment_table partment_table1_ = GetPartment_tableObject1(part_id);
            this.labpartment.Text = partment_table1_.partment_name.ToString();
            #endregion 显示登录的人信息
            #region 随机化头像
            //Random rd = new Random();
            //index_picture_index = rd.Next(1, 4);
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            byte[] picturebytes;
            string ImagePath;
            this.pictureBox3.BackgroundImage = bmpt;
            this.pictureBox4.BackgroundImage = bmpt;
            #endregion 随机化头像

        }
        /// <summary> 观察者和事件委托
        /// // 当我们选择了树形菜单是运行
        /// </summary>
        /// <param name="sender"></param>是树形菜单本身
        /// <param name="e"></param> 是事件参数对象
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                node.BackColor = Color.White;
                node.ForeColor = Color.Black;
            }
            e.Node.BackColor = SystemColors.ScrollBar;
            
            e.Node.ForeColor = Color.White;

            switch (e.Node.Index)
            {
                case 0:
                    if (_IsForm1==null)
                    {
                        _IsForm1 = new IsForm1(); // 创建子窗体
                        _IsForm1.MdiParent = this;  // 子窗体的父容器是当前窗体（this）
                        _IsForm1.Parent = this.panel2;  // 子窗体出现在最顶层
                    }
                    _IsForm2?.Hide();  //2窗体对象不为空 执行隐藏
                    _IsForm3?.Hide();  //3窗体对象不为空 执行隐藏
                    _IsForm4?.Hide();  //4窗体对象不为空 执行隐藏
                    _IsForm5?.Hide();  //5窗体对象不为空 执行隐藏
                    _IsForm1.Show();
                    

                    break;
                case 1:
                    if (_IsForm2==null)
                    {
                        _IsForm2 = new IsForm2(); // 创建子窗体
                        _IsForm2.MdiParent = this;  // 子窗体的父容器是当前窗体（this）
                        _IsForm2.Parent = this.panel2;  // 子窗体出现在最顶层
                    }

                    _IsForm1?.Hide();  //1窗体对象不为空  执行隐藏
                    _IsForm3?.Hide();  //3窗体对象不为空 执行隐藏
                    _IsForm4?.Hide();  //4窗体对象不为空 执行隐藏
                    _IsForm5?.Hide();  //5窗体对象不为空 执行隐藏
                    _IsForm2.Show();
                    break;
                case 2:
                    if (_IsForm3 == null)
                    {
                        _IsForm3 = new IsForm3(); // 创建子窗体
                        _IsForm3.MdiParent = this;  // 子窗体的父容器是当前窗体（this）
                        _IsForm3.Parent = this.panel2;  // 子窗体出现在最顶层
                    }
                    _IsForm1?.Hide();  //1窗体对象不为空  执行隐藏
                    _IsForm2?.Hide();  //2窗体对象不为空 执行隐藏
                    _IsForm4?.Hide();  //4窗体对象不为空 执行隐藏
                    _IsForm5?.Hide();  //5窗体对象不为空 执行隐藏
                    _IsForm3.Show();
                    break;

                case 3:
                    if (_IsForm4 == null)
                    {
                        _IsForm4 = new IsForm4(); // 创建子窗体
                        _IsForm4.MdiParent = this;  // 子窗体的父容器是当前窗体（this）
                        _IsForm4.Parent = this.panel2;  // 子窗体出现在最顶层
                    }
                    _IsForm1?.Hide();  //1窗体对象不为空  执行隐藏
                    _IsForm2?.Hide();  //2窗体对象不为空 执行隐藏
                    _IsForm3?.Hide();  //3窗体对象不为空 执行隐藏
                    _IsForm5?.Hide();  //5窗体对象不为空 执行隐藏
                    _IsForm4.Show();
                    break;

                case 4:
                    if (_IsForm5 == null)
                    {
                        _IsForm5 = new IsForm5(); // 创建子窗体
                        _IsForm5.MdiParent = this;  // 子窗体的父容器是当前窗体（this）
                        _IsForm5.Parent = this.panel2;  // 子窗体出现在最顶层
                    }
                    _IsForm1?.Hide();  //1窗体对象不为空  执行隐藏
                    _IsForm2?.Hide();  //2窗体对象不为空 执行隐藏
                    _IsForm3?.Hide();  //3窗体对象不为空 执行隐藏
                    _IsForm4?.Hide();  //4窗体对象不为空 执行隐藏
                    _IsForm5.Show();
                    break;

                case 5:
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    //Form_visit_FormClosed();
                    break;

            }
        }
        // 窗体的Load方法

        private partment_table GetPartment_tableObject1(int part_id)
        {
            return partment_tableBll_.getPartment_tableObject(part_id);
        }
        private void Form_visit_Load(object sender, EventArgs e)
        {
            _IsForm1 = new IsForm1(); // 创建子窗体
            _IsForm1.MdiParent = this;  // 子窗体的父容器是当前窗体（this）
            _IsForm1.Parent = this.panel2;  // 子窗体出现在最顶层
            _IsForm1.Show();
            if (_IsForm3 == null)
            {
                _IsForm3 = new IsForm3(); // 创建子窗体
                _IsForm3.MdiParent = this;  // 子窗体的父容器是当前窗体（this）
                _IsForm3.Parent = this.panel2;  // 子窗体出现在最顶层
                _IsForm3.Hide();
            }
            //IsForm2 _IsForm1 = new IsForm2(); // 创建子窗体
            //_IsForm1.MdiParent = this;  // 子窗体的父容器是当前窗体（this）
            //_IsForm1.Parent = this.panel2;  // 子窗体出现在最顶层
            //_IsForm1.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region  初始化时间
            
            labDate3.Text = DateTime.Now.ToLongTimeString().ToString();
            #endregion 初始化时间
        }
        /// <summary>
        /// // 当我们选择了树形菜单是运行
        /// </summary>
        /// <param name="sender"></param>是树形菜单本身
        /// <param name="e"></param> 是事件参数对象
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)  
        {

        }

        private void Form_visit_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {


        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {

        } 
    }
}
