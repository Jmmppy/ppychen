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
    public partial class Create_Meeting2 : Form
    {
        ss_visitTableBll ss_visitTableBll_;
        List<cur_ss_visitTable> cur_ss_visitTable_;
        cur_ss_visitTable[] cur_table_list;
        List<int> cur_panl_click_indexList = new List<int>();
        List<string> illnessIdList = new List<string>();//记录选中的患者id列表

        int table_length;
        Form_Route Form_Route_;
        Create_Meeting1 Create_Meeting1_;
        public Create_Meeting2(cur_ss_visitTable[] table_list, List<int> panl_click_indexList)
        {
            InitializeComponent();
            cur_table_list = table_list;
            cur_panl_click_indexList = panl_click_indexList;
        }

        private void Create_Meeting2_Load(object sender, EventArgs e)
        {
            this.labSum.Text = cur_panl_click_indexList.ToArray().Length.ToString();
            Console.WriteLine("---------------Create_Meeting2 : Form-------------------");
            // 拿到单击的index列表
            foreach (int i in cur_panl_click_indexList)
            {
                Console.WriteLine(cur_table_list[i].patient_name.ToString());
            }
            

        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            Form_Route_ = new Form_Route(cur_table_list, cur_panl_click_indexList);
            Form_Route_.ShowDialog();
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<string> str_illnessId = new List<string>();
            // 拿到单击的index列表
            foreach (int i in cur_panl_click_indexList)
            {
                str_illnessId.Add(cur_table_list[i].illness_id.ToString());
            }
            Create_Meeting1_ = new Create_Meeting1(str_illnessId);
            this.Hide();
            if (Create_Meeting1_.ShowDialog() == DialogResult.OK )
            {
                //MessageBox.Show(string.Format("成功"));
            }
        }
    }
}
