
namespace WindowsFormsApp1
{
    partial class IsForm4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsForm4));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_input = new System.Windows.Forms.CheckBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtname2 = new System.Windows.Forms.TextBox();
            this.txtname1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvss_visit = new System.Windows.Forms.DataGridView();
            this.patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narcosis_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operation_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narcosis_doc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nurse_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.illness_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visit_result_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.labPageIndex = new System.Windows.Forms.Label();
            this.labRecordCount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvss_visit)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chk_input);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.txtname2);
            this.groupBox1.Controls.Add(this.txtname1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(4, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 59);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选";
            // 
            // chk_input
            // 
            this.chk_input.AutoSize = true;
            this.chk_input.Location = new System.Drawing.Point(449, 22);
            this.chk_input.Name = "chk_input";
            this.chk_input.Size = new System.Drawing.Size(75, 21);
            this.chk_input.TabIndex = 12;
            this.chk_input.Text = "是否录入";
            this.chk_input.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(119)))), ((int)(((byte)(198)))));
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSelect.Location = new System.Drawing.Point(708, 20);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 29);
            this.btnSelect.TabIndex = 11;
            this.btnSelect.Text = "查  找";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtname2
            // 
            this.txtname2.Location = new System.Drawing.Point(247, 22);
            this.txtname2.Name = "txtname2";
            this.txtname2.Size = new System.Drawing.Size(120, 23);
            this.txtname2.TabIndex = 1;
            // 
            // txtname1
            // 
            this.txtname1.Location = new System.Drawing.Point(54, 21);
            this.txtname1.Name = "txtname1";
            this.txtname1.Size = new System.Drawing.Size(79, 23);
            this.txtname1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "手术名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
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
            this.operation_date,
            this.narcosis_time,
            this.operation_name,
            this.doc_name,
            this.narcosis_doc_name,
            this.nurse_name,
            this.isSelect,
            this.illness_id,
            this.visit_result_id});
            this.dgvss_visit.GridColor = System.Drawing.SystemColors.Control;
            this.dgvss_visit.Location = new System.Drawing.Point(2, 57);
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
            this.dgvss_visit.Size = new System.Drawing.Size(843, 453);
            this.dgvss_visit.TabIndex = 5;
            this.dgvss_visit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvss_visit_CellDoubleClick);
            this.dgvss_visit.DoubleClick += new System.EventHandler(this.dgvss_visit_DoubleClick);
            // 
            // patient_name
            // 
            this.patient_name.DataPropertyName = "patient_name";
            this.patient_name.HeaderText = "患者名";
            this.patient_name.MinimumWidth = 10;
            this.patient_name.Name = "patient_name";
            this.patient_name.ReadOnly = true;
            this.patient_name.Width = 86;
            // 
            // operation_date
            // 
            this.operation_date.DataPropertyName = "operation_date";
            this.operation_date.HeaderText = "手术日期";
            this.operation_date.Name = "operation_date";
            this.operation_date.ReadOnly = true;
            this.operation_date.Width = 130;
            // 
            // narcosis_time
            // 
            this.narcosis_time.DataPropertyName = "narcosis_time";
            this.narcosis_time.HeaderText = "访视时间";
            this.narcosis_time.Name = "narcosis_time";
            this.narcosis_time.ReadOnly = true;
            this.narcosis_time.Width = 130;
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
            // isSelect
            // 
            this.isSelect.DataPropertyName = "isSelect";
            this.isSelect.HeaderText = "是否录入";
            this.isSelect.Name = "isSelect";
            this.isSelect.ReadOnly = true;
            this.isSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isSelect.Width = 60;
            // 
            // illness_id
            // 
            this.illness_id.DataPropertyName = "illness_id";
            this.illness_id.HeaderText = "患者id";
            this.illness_id.MinimumWidth = 2;
            this.illness_id.Name = "illness_id";
            this.illness_id.ReadOnly = true;
            this.illness_id.Width = 2;
            // 
            // visit_result_id
            // 
            this.visit_result_id.DataPropertyName = "visit_result_id";
            this.visit_result_id.HeaderText = "访视结果名";
            this.visit_result_id.MinimumWidth = 2;
            this.visit_result_id.Name = "visit_result_id";
            this.visit_result_id.ReadOnly = true;
            this.visit_result_id.Width = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel5.Controls.Add(this.pictureBox12);
            this.panel5.Controls.Add(this.btnLast);
            this.panel5.Controls.Add(this.btnNext);
            this.panel5.Controls.Add(this.btnPrev);
            this.panel5.Controls.Add(this.btnFirst);
            this.panel5.Controls.Add(this.labPageIndex);
            this.panel5.Controls.Add(this.labRecordCount);
            this.panel5.Location = new System.Drawing.Point(2, 512);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(843, 43);
            this.panel5.TabIndex = 6;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox12.BackgroundImage")));
            this.pictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox12.Location = new System.Drawing.Point(0, -2);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(15, 45);
            this.pictureBox12.TabIndex = 5;
            this.pictureBox12.TabStop = false;
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(119)))), ((int)(((byte)(198)))));
            this.btnLast.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLast.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLast.Location = new System.Drawing.Point(706, 4);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(53, 24);
            this.btnLast.TabIndex = 15;
            this.btnLast.Text = "尾页";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(119)))), ((int)(((byte)(198)))));
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNext.Location = new System.Drawing.Point(584, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(69, 24);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(119)))), ((int)(((byte)(198)))));
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrev.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPrev.Location = new System.Drawing.Point(443, 4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(70, 24);
            this.btnPrev.TabIndex = 15;
            this.btnPrev.Text = "上一页";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(119)))), ((int)(((byte)(198)))));
            this.btnFirst.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFirst.ForeColor = System.Drawing.SystemColors.Window;
            this.btnFirst.Location = new System.Drawing.Point(343, 4);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(44, 24);
            this.btnFirst.TabIndex = 15;
            this.btnFirst.Text = "首页";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // labPageIndex
            // 
            this.labPageIndex.AutoSize = true;
            this.labPageIndex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPageIndex.Location = new System.Drawing.Point(186, 8);
            this.labPageIndex.Name = "labPageIndex";
            this.labPageIndex.Size = new System.Drawing.Size(42, 17);
            this.labPageIndex.TabIndex = 2;
            this.labPageIndex.Text = "统/ 计";
            // 
            // labRecordCount
            // 
            this.labRecordCount.AutoSize = true;
            this.labRecordCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRecordCount.Location = new System.Drawing.Point(51, 8);
            this.labRecordCount.Name = "labRecordCount";
            this.labRecordCount.Size = new System.Drawing.Size(36, 17);
            this.labRecordCount.TabIndex = 2;
            this.labRecordCount.Text = "统 计";
            // 
            // IsForm4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 555);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.dgvss_visit);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IsForm4";
            this.Text = "IsForm4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IsForm4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvss_visit)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_input;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtname2;
        private System.Windows.Forms.TextBox txtname1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvss_visit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label labPageIndex;
        private System.Windows.Forms.Label labRecordCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn operation_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn narcosis_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn operation_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn narcosis_doc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn nurse_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn illness_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn visit_result_id;
    }
}