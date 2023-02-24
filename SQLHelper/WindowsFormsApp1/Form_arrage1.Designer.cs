
namespace WindowsFormsApp1
{
    partial class Form_arrage1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvss_visit = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weigth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sickroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pice_place_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partment_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narcosis_doc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nurse_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation_room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvss_visit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvss_visit
            // 
            this.dgvss_visit.AllowUserToAddRows = false;
            this.dgvss_visit.AllowUserToDeleteRows = false;
            this.dgvss_visit.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvss_visit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvss_visit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvss_visit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient_name,
            this.age,
            this.height,
            this.weigth,
            this.sickroom,
            this.pice_place_name,
            this.partment_name,
            this.diagnosis,
            this.doc_name,
            this.narcosis_doc_name,
            this.nurse_name,
            this.operation_room});
            this.dgvss_visit.GridColor = System.Drawing.SystemColors.Control;
            this.dgvss_visit.Location = new System.Drawing.Point(29, 75);
            this.dgvss_visit.MultiSelect = false;
            this.dgvss_visit.Name = "dgvss_visit";
            this.dgvss_visit.ReadOnly = true;
            this.dgvss_visit.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvss_visit.RowHeadersVisible = false;
            this.dgvss_visit.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvss_visit.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.dgvss_visit.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvss_visit.RowTemplate.Height = 23;
            this.dgvss_visit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvss_visit.Size = new System.Drawing.Size(1114, 546);
            this.dgvss_visit.TabIndex = 8;
            this.dgvss_visit.DoubleClick += new System.EventHandler(this.dgvss_visit_DoubleClick);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.SeaGreen;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOk.Location = new System.Drawing.Point(115, 636);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 29);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "自动分配";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // patient_name
            // 
            this.patient_name.DataPropertyName = "patient_name";
            this.patient_name.HeaderText = "患者名";
            this.patient_name.Name = "patient_name";
            this.patient_name.ReadOnly = true;
            this.patient_name.Width = 90;
            // 
            // age
            // 
            this.age.DataPropertyName = "age";
            this.age.HeaderText = "年龄";
            this.age.Name = "age";
            this.age.ReadOnly = true;
            this.age.Width = 30;
            // 
            // height
            // 
            this.height.DataPropertyName = "height";
            this.height.HeaderText = "身高";
            this.height.Name = "height";
            this.height.ReadOnly = true;
            this.height.Width = 30;
            // 
            // weigth
            // 
            this.weigth.DataPropertyName = "weigth";
            this.weigth.HeaderText = "体重";
            this.weigth.Name = "weigth";
            this.weigth.ReadOnly = true;
            this.weigth.Width = 50;
            // 
            // sickroom
            // 
            this.sickroom.DataPropertyName = "sickroom";
            this.sickroom.HeaderText = "病房";
            this.sickroom.Name = "sickroom";
            this.sickroom.ReadOnly = true;
            this.sickroom.Width = 80;
            // 
            // pice_place_name
            // 
            this.pice_place_name.DataPropertyName = "pice_place_name";
            this.pice_place_name.HeaderText = "片区";
            this.pice_place_name.Name = "pice_place_name";
            this.pice_place_name.ReadOnly = true;
            this.pice_place_name.Width = 125;
            // 
            // partment_name
            // 
            this.partment_name.DataPropertyName = "partment_name";
            this.partment_name.HeaderText = "科室";
            this.partment_name.Name = "partment_name";
            this.partment_name.ReadOnly = true;
            // 
            // diagnosis
            // 
            this.diagnosis.DataPropertyName = "diagnosis";
            this.diagnosis.HeaderText = "诊断";
            this.diagnosis.Name = "diagnosis";
            this.diagnosis.ReadOnly = true;
            this.diagnosis.Width = 200;
            // 
            // doc_name
            // 
            this.doc_name.DataPropertyName = "doc_name";
            this.doc_name.HeaderText = "医师";
            this.doc_name.Name = "doc_name";
            this.doc_name.ReadOnly = true;
            this.doc_name.Width = 95;
            // 
            // narcosis_doc_name
            // 
            this.narcosis_doc_name.DataPropertyName = "narcosis_doc_name";
            this.narcosis_doc_name.HeaderText = "麻醉医师";
            this.narcosis_doc_name.Name = "narcosis_doc_name";
            this.narcosis_doc_name.ReadOnly = true;
            // 
            // nurse_name
            // 
            this.nurse_name.DataPropertyName = "nurse_name";
            this.nurse_name.HeaderText = "护士";
            this.nurse_name.Name = "nurse_name";
            this.nurse_name.ReadOnly = true;
            // 
            // operation_room
            // 
            this.operation_room.DataPropertyName = "operation_room";
            this.operation_room.HeaderText = "手术台";
            this.operation_room.Name = "operation_room";
            this.operation_room.ReadOnly = true;
            // 
            // Form_arrage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1179, 689);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvss_visit);
            this.Name = "Form_arrage1";
            this.Text = "Form_arrage1";
            this.Load += new System.EventHandler(this.Form_arrage1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvss_visit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvss_visit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
        private System.Windows.Forms.DataGridViewTextBoxColumn weigth;
        private System.Windows.Forms.DataGridViewTextBoxColumn sickroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn pice_place_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn partment_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn diagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn narcosis_doc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn nurse_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn operation_room;
    }
}