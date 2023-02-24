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
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace WindowsFormsApp1
{
    public partial class Form_visit_specific : Form
    {
        patient_tableBll patient_tableBll_ = new patient_tableBll();
        ss_tableBll ss_tableBll_ = new ss_tableBll();
        ss_visitTableBll ss_visitTableBll_ = new ss_visitTableBll();
        patient_table patient_table_;
        ss_table ss_table_;
        cur_ss_visitTable cur_ss_visitTable_;
        string cur_ilness_id;
        public Form_visit_specific(cur_ss_visitTable visit)
        {

            InitializeComponent();
            cur_ss_visitTable_ = visit;
            #region 显示信息
            this.lbname.Text = visit.patient_name.ToString();
            this.lb_ilnessid.Text = visit.illness_id.ToString();
            this.pictureBox6.BackgroundImage = GetBarcodeBitmap(cur_ss_visitTable_.illness_id);
            #endregion 显示信息
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txbmessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_visit_specific_Load(object sender, EventArgs e)
        {
            #region 患者信息
            patient_table_ = patient_tableBll_.getpatient_tableObject(cur_ss_visitTable_.illness_id);
            this.lb_sex.Text ="男";
            this.lb_department.Text = patient_table_.age.ToString();
            this.lb_sickroom.Text = patient_table_.sickroom.ToString();
            this.txbmessage.Text = patient_table_.diagnosis.ToString();

            #endregion
            #region 手术申请
            int ss_Id = Convert.ToInt32(patient_table_.ss_id);
            if (ss_Id != 0 )
            {
                ss_table_ = ss_tableBll_.getss_tableObject2(ss_Id);
                this.lb_ss_time.Text = Convert.ToString(ss_table_.ss_date);
                this.label42.Text = ss_table_.ss_type.ToString();
                this.label43.Text = ss_table_.ss_grade.ToString();
                this.label9.Text = ss_table_.operation_id.ToString();       //////
                this.label11.Text = ss_table_.position.ToString();
                this.label44.Text = ss_table_.body_position.ToString();
                this.label45.Text = ss_table_.cut_grade.ToString();
                this.label46.Text = ss_table_.narcosis_way.ToString();
                this.label47.Text = ss_table_.special_infection.ToString();
                this.label48.Text = ss_table_.remarks.ToString();
                this.label20.Text = ss_table_.hepatitisB.ToString();
                this.label21.Text = ss_table_.hepatitisC.ToString();
                this.label23.Text = ss_table_.syphilis.ToString();
                this.label25.Text = ss_table_.HIV.ToString();
                this.label27.Text = ss_table_.tuberculosis.ToString();
            }


            #endregion
            #region 手术排班
            this.label30.Text = "手术室A";
            this.label32.Text = patient_table_.operation_room.ToString();
            this.label33.Text = patient_table_.doc_id.ToString(); /////
            this.label35.Text = patient_table_.narcosis_doc_id.ToString();
            this.label37.Text = patient_table_.nurse_id.ToString();
            #endregion
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //// is_bool1 确保是否已经经过访视的确认
            ///更改is_bool1为true
            cur_ilness_id = cur_ss_visitTable_.illness_id;
            //bool cur_is_bool1 = true;
            ss_visitTable ss_Table = new ss_visitTable()
            {
                illness_id = cur_ilness_id,
                is_bool1 = true
            };
            int row = ss_visitTableBll_.update_ss_visitTable3(ss_Table);
            if (row == 1)
            {
                this.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// is_bool3 确保否已经经过访视的确认
            ///更改is_bool3为true
            cur_ilness_id = cur_ss_visitTable_.illness_id;
            //bool cur_is_bool1 = true;
            ss_visitTable ss_Table = new ss_visitTable()
            {
                illness_id = cur_ilness_id,
                is_bool3 = true
            };
            int row = ss_visitTableBll_.update_ss_visitTable4(ss_Table);
            if (row == 1)
            {
                this.Close();
            }
        }
        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="barcodeContent">需要生成条码的内容</param>
        /// <param name="barcodeWidth">条码宽度</param>
        /// <param name="barcodeHeight">条码长度</param>
        /// <returns>返回条码图形</returns>
        public static Bitmap GetBarcodeBitmap(string barcodeContent)
        {
            int barcodeWidth = 114; int barcodeHeight = 49;
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODE_39;//设置编码格式
            EncodingOptions encodingOptions = new EncodingOptions();
            encodingOptions.Width = barcodeWidth;//设置宽度
            encodingOptions.Height = barcodeHeight;//设置长度
            encodingOptions.Margin = 2;//设置边距
            barcodeWriter.Options = encodingOptions;
            Bitmap bitmap = barcodeWriter.Write(barcodeContent);
            return bitmap;
        }
    }
}
