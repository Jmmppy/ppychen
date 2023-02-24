using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_apply0 : Form
    {
        public Form_apply0()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // 打开访手术申请统界面
            Form_apply1 Form_apply1_ = new Form_apply1();
            
            this.Hide();
            //Form_apply1_.ShowDialog(this);
            if (Form_apply1_.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // 打开访审批界面
            Form_apply3 Form_apply3_ = new Form_apply3();

            this.Hide();
            //Form_apply1_.ShowDialog(this);
            if (Form_apply3_.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void Form_apply0_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form_apply0_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
