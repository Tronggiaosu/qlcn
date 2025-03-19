namespace QLCongNo.HoaDon
{
    partial class frQLHoaDonDieuChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frQLHoaDonDieuChinh));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.excelButton = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.cboDot = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMauHD = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboKH = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.soHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chitietColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FkeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDC = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDC_Column = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FkeyDCColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDC)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachButton,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(962, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seachButton
            // 
            this.seachButton.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.seachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seachButton.Name = "seachButton";
            this.seachButton.Size = new System.Drawing.Size(49, 22);
            this.seachButton.Text = "Tìm";
            // 
            // excelButton
            // 
            this.excelButton.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.excelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(86, 22);
            this.excelButton.Text = "Xuất Excel";
            // 
            // quitButton
            // 
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(60, 22);
            this.quitButton.Text = "Thoát";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cboNV);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboNam);
            this.groupBox1.Controls.Add(this.cboKy);
            this.groupBox1.Controls.Add(this.cboDot);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboMauHD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboKH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 102);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // cboNV
            // 
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(300, 34);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(328, 24);
            this.cboNV.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(298, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "Nhân viên điều chỉnh";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(66, 66);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(338, 23);
            this.txtTim.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Tìm kiềm";
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(224, 34);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(71, 24);
            this.cboNam.TabIndex = 30;
            // 
            // cboKy
            // 
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(141, 34);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(78, 24);
            this.cboKy.TabIndex = 29;
            // 
            // cboDot
            // 
            this.cboDot.FormattingEnabled = true;
            this.cboDot.Location = new System.Drawing.Point(66, 34);
            this.cboDot.Name = "cboDot";
            this.cboDot.Size = new System.Drawing.Size(70, 24);
            this.cboDot.TabIndex = 28;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(717, 66);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(142, 23);
            this.dateTimePicker2.TabIndex = 27;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(488, 66);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 23);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(653, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Đến ngày";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(416, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 20);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Từ ngày";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Kỳ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Đợt";
            // 
            // cboMauHD
            // 
            this.cboMauHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMauHD.FormattingEnabled = true;
            this.cboMauHD.Location = new System.Drawing.Point(636, 34);
            this.cboMauHD.Name = "cboMauHD";
            this.cboMauHD.Size = new System.Drawing.Size(109, 24);
            this.cboMauHD.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(636, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Chọn mẫu HĐ";
            // 
            // cboKH
            // 
            this.cboKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKH.FormattingEnabled = true;
            this.cboKH.Location = new System.Drawing.Point(750, 34);
            this.cboKH.Name = "cboKH";
            this.cboKH.Size = new System.Drawing.Size(109, 24);
            this.cboKH.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(750, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Chọn Ký hiệu HĐ";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Location = new System.Drawing.Point(0, 528);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(962, 25);
            this.toolStrip2.TabIndex = 26;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 401);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn bị điều chỉnh";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.soHDColumn,
            this.DanhBoColumn,
            this.HotenColumn,
            this.MaLT,
            this.chitietColumn,
            this.FkeyColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(504, 379);
            this.dataGridView1.TabIndex = 0;
            // 
            // soHDColumn
            // 
            this.soHDColumn.DataPropertyName = "SO_HD";
            this.soHDColumn.HeaderText = "Số HĐ";
            this.soHDColumn.Name = "soHDColumn";
            this.soHDColumn.ReadOnly = true;
            this.soHDColumn.Width = 68;
            // 
            // DanhBoColumn
            // 
            this.DanhBoColumn.DataPropertyName = "DANHBO";
            this.DanhBoColumn.HeaderText = "Danh bộ";
            this.DanhBoColumn.Name = "DanhBoColumn";
            this.DanhBoColumn.ReadOnly = true;
            this.DanhBoColumn.Width = 79;
            // 
            // HotenColumn
            // 
            this.HotenColumn.DataPropertyName = "Hoten";
            this.HotenColumn.HeaderText = "Họ tên";
            this.HotenColumn.Name = "HotenColumn";
            this.HotenColumn.ReadOnly = true;
            this.HotenColumn.Width = 69;
            // 
            // MaLT
            // 
            this.MaLT.DataPropertyName = "malt";
            this.MaLT.HeaderText = "MaLT";
            this.MaLT.Name = "MaLT";
            this.MaLT.ReadOnly = true;
            this.MaLT.Width = 63;
            // 
            // chitietColumn
            // 
            this.chitietColumn.DataPropertyName = "chitiet";
            this.chitietColumn.HeaderText = "Chi tiết";
            this.chitietColumn.Name = "chitietColumn";
            this.chitietColumn.ReadOnly = true;
            this.chitietColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chitietColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chitietColumn.Width = 72;
            // 
            // FkeyColumn
            // 
            this.FkeyColumn.DataPropertyName = "ID_HD";
            this.FkeyColumn.HeaderText = "Fkey";
            this.FkeyColumn.Name = "FkeyColumn";
            this.FkeyColumn.ReadOnly = true;
            this.FkeyColumn.Visible = false;
            this.FkeyColumn.Width = 63;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewDC);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(510, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 401);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hóa đơn điều chỉnh";
            // 
            // dataGridViewDC
            // 
            this.dataGridViewDC.AllowUserToAddRows = false;
            this.dataGridViewDC.AllowUserToDeleteRows = false;
            this.dataGridViewDC.AllowUserToOrderColumns = true;
            this.dataGridViewDC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewDC.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.IDDC_Column,
            this.FkeyDCColumn});
            this.dataGridViewDC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDC.Location = new System.Drawing.Point(3, 19);
            this.dataGridViewDC.Name = "dataGridViewDC";
            this.dataGridViewDC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDC.Size = new System.Drawing.Size(446, 379);
            this.dataGridViewDC.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SO_HD";
            this.dataGridViewTextBoxColumn1.HeaderText = "Số HĐ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 68;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DANHBO";
            this.dataGridViewTextBoxColumn2.HeaderText = "Danh bộ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 79;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "HOTEN";
            this.dataGridViewTextBoxColumn3.HeaderText = "Họ tên";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 69;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MALT";
            this.dataGridViewTextBoxColumn4.HeaderText = "MaLT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 63;
            // 
            // IDDC_Column
            // 
            this.IDDC_Column.DataPropertyName = "chitiet";
            this.IDDC_Column.HeaderText = "Chi tiết";
            this.IDDC_Column.Name = "IDDC_Column";
            this.IDDC_Column.ReadOnly = true;
            this.IDDC_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IDDC_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IDDC_Column.Width = 72;
            // 
            // FkeyDCColumn
            // 
            this.FkeyDCColumn.DataPropertyName = "ID_HD";
            this.FkeyDCColumn.HeaderText = "FkeyDC";
            this.FkeyDCColumn.Name = "FkeyDCColumn";
            this.FkeyDCColumn.ReadOnly = true;
            this.FkeyDCColumn.Visible = false;
            this.FkeyDCColumn.Width = 82;
            // 
            // frQLHoaDonDieuChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 553);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frQLHoaDonDieuChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH SÁCH HÓA ĐƠN ĐIỀU CHỈNH";
            this.Load += new System.EventHandler(this.frQLHoaDonDieuChinh_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton seachButton;
        private System.Windows.Forms.ToolStripButton excelButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboMauHD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.ComboBox cboDot;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewDC;
        private System.Windows.Forms.DataGridViewTextBoxColumn soHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLT;
        private System.Windows.Forms.DataGridViewButtonColumn chitietColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FkeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewButtonColumn IDDC_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn FkeyDCColumn;
    }
}