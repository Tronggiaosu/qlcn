namespace QLCongNo.HoaDon
{
    partial class frQLHuyHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frQLHuyHoaDon));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DatepdateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dotColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FkeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachButton,
            this.btnDelete,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(872, 25);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seachButton
            // 
            this.seachButton.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.seachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seachButton.Name = "seachButton";
            this.seachButton.Size = new System.Drawing.Size(108, 22);
            this.seachButton.Text = "Lấy danh sách";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::QLCongNo.Properties.Resources.cancel_billing;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 22);
            this.btnDelete.Text = "Hủy hóa đơn";
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
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
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
            this.groupBox1.Size = new System.Drawing.Size(872, 123);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // cboNV
            // 
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(542, 84);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(210, 24);
            this.cboNV.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(539, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 51;
            this.label8.Text = "Nhân viên hủy";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(172, 86);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(338, 23);
            this.txtTim.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 49;
            this.label7.Text = "Tìm kiềm";
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(354, 26);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(71, 24);
            this.cboNam.TabIndex = 48;
            // 
            // cboKy
            // 
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(262, 26);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(78, 24);
            this.cboKy.TabIndex = 47;
            // 
            // cboDot
            // 
            this.cboDot.FormattingEnabled = true;
            this.cboDot.Location = new System.Drawing.Point(172, 26);
            this.cboDot.Name = "cboDot";
            this.cboDot.Size = new System.Drawing.Size(70, 24);
            this.cboDot.TabIndex = 46;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(385, 54);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(126, 23);
            this.dateTimePicker2.TabIndex = 45;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 23);
            this.dateTimePicker1.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 43;
            this.label6.Text = "Đến ngày";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(101, 58);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 20);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.Text = "Từ ngày";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 41;
            this.label5.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Kỳ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "Đợt";
            // 
            // cboMauHD
            // 
            this.cboMauHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMauHD.FormattingEnabled = true;
            this.cboMauHD.Location = new System.Drawing.Point(443, 26);
            this.cboMauHD.Name = "cboMauHD";
            this.cboMauHD.Size = new System.Drawing.Size(109, 24);
            this.cboMauHD.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "Chọn mẫu HĐ";
            // 
            // cboKH
            // 
            this.cboKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKH.FormattingEnabled = true;
            this.cboKH.Location = new System.Drawing.Point(588, 26);
            this.cboKH.Name = "cboKH";
            this.cboKH.Size = new System.Drawing.Size(109, 24);
            this.cboKH.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Chọn Ký hiệu HĐ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(872, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 291);
            this.panel1.TabIndex = 29;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatepdateColumn,
            this.namColumn,
            this.kyColumn,
            this.dotColumn,
            this.soHDColumn,
            this.DanhBoColumn,
            this.MaLT,
            this.HotenColumn,
            this.FkeyColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(872, 291);
            this.dataGridView1.TabIndex = 2;
            // 
            // DatepdateColumn
            // 
            this.DatepdateColumn.DataPropertyName = "date_update";
            this.DatepdateColumn.HeaderText = "Ngày hủy";
            this.DatepdateColumn.Name = "DatepdateColumn";
            this.DatepdateColumn.ReadOnly = true;
            // 
            // namColumn
            // 
            this.namColumn.DataPropertyName = "nam";
            this.namColumn.HeaderText = "Năm";
            this.namColumn.Name = "namColumn";
            this.namColumn.ReadOnly = true;
            // 
            // kyColumn
            // 
            this.kyColumn.DataPropertyName = "kyghi";
            this.kyColumn.HeaderText = "Kỳ";
            this.kyColumn.Name = "kyColumn";
            this.kyColumn.ReadOnly = true;
            // 
            // dotColumn
            // 
            this.dotColumn.DataPropertyName = "tendot";
            this.dotColumn.HeaderText = "Đợt";
            this.dotColumn.Name = "dotColumn";
            this.dotColumn.ReadOnly = true;
            // 
            // soHDColumn
            // 
            this.soHDColumn.DataPropertyName = "SO_HD";
            this.soHDColumn.HeaderText = "Số HĐ";
            this.soHDColumn.Name = "soHDColumn";
            this.soHDColumn.ReadOnly = true;
            // 
            // DanhBoColumn
            // 
            this.DanhBoColumn.DataPropertyName = "DANHBO";
            this.DanhBoColumn.HeaderText = "Danh bộ";
            this.DanhBoColumn.Name = "DanhBoColumn";
            this.DanhBoColumn.ReadOnly = true;
            // 
            // MaLT
            // 
            this.MaLT.DataPropertyName = "MaLT";
            this.MaLT.HeaderText = "MaLT";
            this.MaLT.Name = "MaLT";
            this.MaLT.ReadOnly = true;
            // 
            // HotenColumn
            // 
            this.HotenColumn.DataPropertyName = "hoten";
            this.HotenColumn.HeaderText = "Họ tên";
            this.HotenColumn.Name = "HotenColumn";
            this.HotenColumn.ReadOnly = true;
            // 
            // FkeyColumn
            // 
            this.FkeyColumn.DataPropertyName = "ID_HD";
            this.FkeyColumn.HeaderText = "Fkey";
            this.FkeyColumn.Name = "FkeyColumn";
            this.FkeyColumn.ReadOnly = true;
            this.FkeyColumn.Visible = false;
            // 
            // frQLHuyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frQLHuyHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH SÁCH HÓA ĐƠN HỦY";
            this.Load += new System.EventHandler(this.frQLHuyHoaDon_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton seachButton;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton excelButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.ComboBox cboDot;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMauHD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatepdateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dotColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FkeyColumn;
    }
}