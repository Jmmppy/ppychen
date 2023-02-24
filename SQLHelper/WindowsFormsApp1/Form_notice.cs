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
    public partial class Form_notice : Form
    {
        int cur_notice_id;//定义全局的id
        notice_tableBll notice_tableBll_ = new notice_tableBll();
        
        public Form_notice(int notice_id)
        {
            InitializeComponent();
            cur_notice_id = notice_id;
            // this.txbtime.Text = Convert.ToString(cur_notice_id); 这里证明cur_notice_id正确
            notice_table notice_table_ = notice_tableBll_.getCurNoticeObject(cur_notice_id);
            //notice_table notice_table_ = notice_tableBll_.getCurNotice_table(cur_notice_id);
            this.txbtime.Text = Convert.ToString(notice_table_.notice_date);
            this.txbman.Text = Convert.ToString(notice_table_.notice_man);
            this.txb_title.Text = Convert.ToString(notice_table_.title);
            this.txbmessage.Text = Convert.ToString(notice_table_.message);

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
