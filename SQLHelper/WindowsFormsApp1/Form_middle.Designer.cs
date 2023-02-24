
namespace WindowsFormsApp1
{
    partial class Form_middle
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
            this.illness_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation_room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narcosis_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narcosis_doc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nurse_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.illness_id,
            this.patient_name,
            this.operation_date,
            this.operation_room,
            this.narcosis_time,
            this.operation_name,
            this.doc_name,
            this.narcosis_doc_name,
            this.nurse_name});
            this.dgvss_visit.GridColor = System.Drawing.SystemColors.Control;
            this.dgvss_visit.Location = new System.Drawing.Point(12, 12);
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
            this.dgvss_visit.Size = new System.Drawing.Size(845, 458);
            this.dgvss_visit.TabIndex = 2;
            this.dgvss_visit.DoubleClick += new System.EventHandler(this.dgvss_visit_DoubleClick);
            // 
            // illness_id
            // 
            this.illness_id.DataPropertyName = "illness_id";
            this.illness_id.HeaderText = "患者id";
            this.illness_id.Name = "illness_id";
            this.illness_id.ReadOnly = true;
            this.illness_id.Width = 80;
            // 
            // patient_name
            // 
            this.patient_name.DataPropertyName = "patient_name";
            this.patient_name.HeaderText = "患者名";
            this.patient_name.Name = "patient_name";
            this.patient_name.ReadOnly = true;
            this.patient_name.Width = 90;
            // 
            // operation_date
            // 
            this.operation_date.DataPropertyName = "operation_date";
            this.operation_date.HeaderText = "手术日期";
            this.operation_date.Name = "operation_date";
            this.operation_date.ReadOnly = true;
            this.operation_date.Width = 110;
            // 
            // operation_room
            // 
            this.operation_room.DataPropertyName = "operation_room";
            this.operation_room.HeaderText = "手术室";
            this.operation_room.Name = "operation_room";
            this.operation_room.ReadOnly = true;
            this.operation_room.Width = 20;
            // 
            // narcosis_time
            // 
            this.narcosis_time.DataPropertyName = "narcosis_time";
            this.narcosis_time.HeaderText = "访视时间";
            this.narcosis_time.Name = "narcosis_time";
            this.narcosis_time.ReadOnly = true;
            this.narcosis_time.Width = 110;
            // 
            // operation_name
            // 
            this.operation_name.DataPropertyName = "operation_name";
            this.operation_name.HeaderText = "手术名称";
            this.operation_name.Name = "operation_name";
            this.operation_name.ReadOnly = true;
            this.operation_name.Width = 145;
            // 
            // doc_name
            // 
            this.doc_name.DataPropertyName = "doc_name";
            this.doc_name.HeaderText = "手术医师";
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
            this.narcosis_doc_name.Width = 95;
            // 
            // nurse_name
            // 
            this.nurse_name.DataPropertyName = "nurse_name";
            this.nurse_name.HeaderText = "护理医师";
            this.nurse_name.Name = "nurse_name";
            this.nurse_name.ReadOnly = true;
            this.nurse_name.Width = 95;
            // 
            // Form_middle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 558);
            this.Controls.Add(this.dgvss_visit);
            this.Name = "Form_middle";
            this.Text = "Form_middle";
            this.Load += new System.EventHandler(this.Form_middle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvss_visit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvss_visit;
        private System.Windows.Forms.DataGridViewTextBoxColumn illness_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn operation_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn operation_room;
        private System.Windows.Forms.DataGridViewTextBoxColumn narcosis_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn operation_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn narcosis_doc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn nurse_name;
    }
}