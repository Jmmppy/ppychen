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
using System.IO;

namespace WindowsFormsApp1
{
    
    public partial class Form_apply2 : Form
    {
        //
        cur_patient_table cur_visit;
        private bool cur_isInput = false;
        partment_tableBll partment_tableBll_ = new partment_tableBll();
        ss_tableBll ss_tableBll_ = new ss_tableBll();
        patient_tableBll patient_tableBll_ = new patient_tableBll();
        patient_table patient_table_;

        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        byte[] picturebytes;
        int index_i = 0;
        public Form_apply2(cur_patient_table visit)
        {
            InitializeComponent();
            cur_visit = visit;
            #region 显示信息
            this.lbname.Text = cur_visit.patient_name.ToString();
            this.lb_ilnessid.Text = cur_visit.illness_id.ToString();
            this.lbsickroom.Text = cur_visit.sickroom.ToString();
            //没写完……
            #endregion 显示信息
            
        }

        private void Form_apply2_Load(object sender, EventArgs e)
        {
            #region 显示下拉框
            List<operation_table> operation_tableList = new List<operation_table>();
            operation_tableBll operation_tableBll_ = new operation_tableBll();
            operation_tableList = operation_tableBll_.GetOperation_tableList1();
            this.cmb_operation.DataSource = operation_tableList;
            this.cmb_operation.DisplayMember = "operation_name";
            this.cmb_operation.ValueMember = "operation_id";
            #endregion

            //判断是否已经录入
            if (cur_visit.Isinput == true)
            {
                
                cur_isInput = true;
                //ss_id 去查找
                ss_table ss_table_ = ss_tableBll_.getss_tableObject2(cur_visit.ss_id);   //
                string a = Convert.ToString(ss_table_.ss_date);
                //显示已经选择的数据
                this.dateTimePicker1.Text = Convert.ToString(ss_table_.ss_date) ;///
                this.cmb_ss_type.Text = ss_table_.ss_type;
                this.cmb_ss_grade.Text = ss_table_.ss_grade;

                this.cmb_operation.Text = ss_table_.operation_id;////
                this.cmb_position.Text = ss_table_.position;
                this.cmb_body_position.Text = ss_table_.body_position;
                this.cmb_cut_grade.Text = ss_table_.cut_grade;

                this.cmb_narcosis_way.Text = ss_table_.narcosis_way;

                this.cmb_hepatitisB.Text = ss_table_.hepatitisB;
                this.cmb_hepatitisC.Text = ss_table_.hepatitisC;
                this.cmb_syphilis.Text = ss_table_.syphilis;
                this.cmb_HIV.Text = ss_table_.HIV;
                this.cmb_tuberculosis.Text = ss_table_.tuberculosis;

                this.cmb_BH_blood.Text = ss_table_.BH_blood;
                this.txb_special_infection.Text = ss_table_.special_infection;
                this.txt_remarks.Text = ss_table_.remarks;

                //btn命名为“修改”
                this.btnOK.Text = "修 改";
                //跟新表
            }
            else
            {
                cur_isInput = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(string.Format("成功{0}", this.cmb_ss_grade.Text));

            DateTime _ss_date = this.dateTimePicker1.Value;
            string _ss_type = this.cmb_ss_type.Text;
            string _ss_grade = this.cmb_ss_grade.Text;

            string  _operation_id = (string)this.cmb_operation.SelectedValue;/////////////////
            string _position = this.cmb_position.Text;
            string _body_position = this.cmb_body_position.Text;
            string _cut_grade = this.cmb_cut_grade.Text;

            string _narcosis_way = this.cmb_narcosis_way.Text;

            string _hepatitisB = this.cmb_hepatitisB.Text;
            string _hepatitisC = this.cmb_hepatitisC.Text;
            string _syphilis = this.cmb_syphilis.Text;
            string _HIV = this.cmb_HIV.Text;
            string _tuberculosis = this.cmb_tuberculosis.Text;

            string _BH_blood = this.cmb_BH_blood.Text;
            string _special_infection = this.txb_special_infection.Text;
            string _remarks = this.txt_remarks.Text;


            if (cur_isInput == true)
            {//已经录入 “修改”
                //跟新到visit_result_table表
                ss_table ss_table_2 = new ss_table()
                {
                    //s_id = 
                    BH_blood = _BH_blood,
                    body_position = _body_position,
                    cut_grade = _cut_grade,
                    hepatitisB = _hepatitisB,
                    hepatitisC = _hepatitisC,
                    HIV = _HIV,
                    operation_id = _operation_id,///
                    special_infection = _special_infection,
                    narcosis_way = _narcosis_way,
                    ss_date = _ss_date,
                    position = _position,
                    ss_grade = _ss_grade,
                    ss_type = _ss_type,
                    syphilis = _syphilis,
                    tuberculosis = _tuberculosis,
                    remarks = _remarks,
                    illness_id = cur_visit.illness_id
                };
                int row = ss_tableBll_.update_ss_table(ss_table_2);

            }
            else
            {

                //对象初始化器
                ss_table ss_table_ = new ss_table()
                {
                    BH_blood = _BH_blood,
                    body_position = _body_position,
                    cut_grade = _cut_grade,
                    hepatitisB = _hepatitisB,
                    hepatitisC = _hepatitisC,
                    HIV = _HIV,
                    operation_id = _operation_id,///
                    special_infection = _special_infection,
                    narcosis_way = _narcosis_way,
                    ss_date = _ss_date,
                    position = _position,
                    ss_grade = _ss_grade,
                    ss_type = _ss_type,
                    syphilis = _syphilis,
                    tuberculosis = _tuberculosis,
                    remarks = _remarks,
                    illness_id = cur_visit.illness_id
                };

                int row = ss_tableBll_.insert_ss_table(ss_table_);//插入visit_result_table
                if (row > 0)
                {// 插入成功
                    //根据illness_id查询返回一个记录

                    ss_table_ = ss_tableBll_.getss_tableObject( cur_visit.illness_id);

                    //返回visit_result_id  为  visit_result_table_.visit_result_id
                    //跟新到主表 patien_table
                    patient_table_ = new patient_table()
                    {
                        illness_id = cur_visit.illness_id,
                        ss_id = ss_table_.ss_id,
                        isInput = true
        

                    };

                    //跟新ss_visitTable  visit_result_id、isSelect
                    int row2 = patient_tableBll_.update_patient_table(patient_table_);
                    this.Close();
                }

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (index_i ==0)
            {
                string ImagePath;
                openFileDialog1.Filter = "JPEG文件|*.jpg|BMP文件|*.bmp*|PNG文件|*.png*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ImagePath = openFileDialog1.FileName;
                    bool bool_t = IsPicture(ImagePath);   //判断上传的图片是否有病毒
                    if (bool_t)
                    {
                        FileStream fs = new FileStream(ImagePath, FileMode.Open);
                        picturebytes = new byte[fs.Length];
                        BinaryReader br = new BinaryReader(fs);
                        picturebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                        MemoryStream ms = new MemoryStream(picturebytes);
                        Bitmap bmpt = new Bitmap(ms);
                        this.pictureBox6.Visible = true;
                        //this.pictureBox6.Image = bmpt;
                        this.pictureBox6.BackgroundImage = bmpt;
                        index_i++;
                    }
                    else { MessageBox.Show(string.Format("上传的图片有病毒")); }
                    
                }
            }
            else if (index_i == 1)
            {
                string ImagePath;
                openFileDialog1.Filter = "JPEG文件|*.jpg|BMP文件|*.bmp*|PNG文件|*.png*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ImagePath = openFileDialog1.FileName;
                    bool bool_t = IsPicture(ImagePath);   //判断上传的图片是否有病毒
                    if (bool_t)
                    {
                        FileStream fs = new FileStream(ImagePath, FileMode.Open);
                        picturebytes = new byte[fs.Length];
                        BinaryReader br = new BinaryReader(fs);
                        picturebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                        MemoryStream ms = new MemoryStream(picturebytes);
                        Bitmap bmpt = new Bitmap(ms);
                        this.pictureBox2.Visible = true;
                        //this.pictureBox6.Image = bmpt;
                        this.pictureBox2.BackgroundImage = bmpt;
                    }
                    else { MessageBox.Show(string.Format("上传的图片有病毒")); }


                }
            }
           

        }

        private bool IsPicture(string filePath)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(fs);
                string fileClass;
                byte buffer;
                buffer = reader.ReadByte();
                fileClass = buffer.ToString();
                buffer = reader.ReadByte();
                fileClass += buffer.ToString();
                reader.Close();
                fs.Close();
                if (fileClass == "255216" || fileClass == "7173" || fileClass == "13780" || fileClass == "6677")
                //255216是jpg;7173是gif;6677是BMP,13780是PNG;7790是exe,8297是rar 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
