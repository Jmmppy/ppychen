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
    public partial class Form_middle3 : Form
    {
        patient_tableBll patient_tableBll_ = new patient_tableBll();
        ss_visitTableBll ss_visitTableBll_ = new ss_visitTableBll();
        doc_tableBll doc_tableBll_ = new doc_tableBll();
        narcosis_docTableBll narcosis_docTableBll_ = new narcosis_docTableBll();

        ss_tableBll ss_tableBll_ = new ss_tableBll();
        patient_table patient_table_;
        ss_table ss_table_;
        cur_ss_visitTable cur_ss_visitTable_;

        bool cheak_ok1 = false;
        bool cheak_ok2 = false;
        bool result = false;
        public Form_middle3(cur_ss_visitTable visit)
        {
            InitializeComponent();
            cur_ss_visitTable_ = visit;
        }

        private void Form_middle3_Load(object sender, EventArgs e)
        {
            string illness_id = cur_ss_visitTable_.illness_id;
            ss_visitTable ss_visitTable_ = ss_visitTableBll_.getss_visitTableObject(illness_id);
            int doc_id = ss_visitTable_.doc_id;
            int nacosis_id = ss_visitTable_.narcosis_doc_id;
            doc_table doc_ = doc_tableBll_.getCurDoc_table(doc_id);
            narcosis_docTable doc_2 = narcosis_docTableBll_.getCurNarcosis_docTable(nacosis_id);


            lbname.Text = doc_2.narcosis_doc_name.ToString();











            label14.Text = doc_.doc_name.ToString();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            cheak_ok1 = true;
            button1.BackColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (cheak_ok1)
            {
                MessageBox.Show(string.Format("都正确，可以开始手术"));
                this.Close();
            }
            else
            {
                MessageBox.Show(string.Format("存在错误，退回手术"));

            }
        }
    }
}
