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
    public partial class Form_arrage2 : Form
    {
        cur_patient_table cur_patient_table_ = new cur_patient_table();
        patient_table patient_table_ = new patient_table();
        patient_tableBll patient_tableBll_ = new patient_tableBll();
        public Form_arrage2(cur_patient_table patient_)
        {
            InitializeComponent();
            #region 显示信息
            this.lbname.Text = patient_.patient_name.ToString();
            this.lb_ilnessid.Text = patient_.illness_id.ToString();
            #endregion 显示信息
            cur_patient_table_ = patient_;
        }

        private void Form_arrage2_Load(object sender, EventArgs e)
        {
            patient_table_ = patient_tableBll_.getpatient_tableObject(cur_patient_table_.illness_id);
            this.txtnarcosis_name.Text = cur_patient_table_.narcosis_doc_name.ToString();
            this.txtnarcosis_id.Text = patient_table_.narcosis_doc_id.ToString();
            this.cmb_operationRoom.Text = patient_table_.operation_room.ToString();

            this.txtnurtion_name.Text = cur_patient_table_.nurse_name.ToString();
            this.txtnurtion_id.Text = patient_table_.nurse_id.ToString();

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int narcosis_doc_id_1 = Convert.ToInt32(this.txtnarcosis_id.Text.Trim());
            int nurse_id_ = Convert.ToInt32(this.txtnurtion_id.Text.Trim());
            string room = this.cmb_operationRoom.Text.Trim();
            patient_table patient_table_ = new patient_table()
            {
                illness_id = cur_patient_table_.illness_id,
                narcosis_doc_id = narcosis_doc_id_1,
                nurse_id = nurse_id_,
                operation_room = room
            };
            int row = patient_tableBll_.update_patient_table2(patient_table_);
            MessageBox.Show(string.Format("修改成功")); //检测成功
            this.Close();
        }
    }
}
