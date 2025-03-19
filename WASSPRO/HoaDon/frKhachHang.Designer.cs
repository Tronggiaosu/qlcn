namespace QLCongNo.HoaDon
{
    partial class frKhachHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frKhachHang));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.excelButton = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.chkNV = new System.Windows.Forms.GroupBox();
            this.cboPhuong = new System.Windows.Forms.ComboBox();
            this.chkPhuong = new System.Windows.Forms.CheckBox();
            this.chkSDT = new System.Windows.Forms.CheckBox();
            this.cboQuan = new System.Windows.Forms.ComboBox();
            this.chkQuan = new System.Windows.Forms.CheckBox();
            this.chkNgay = new System.Windows.Forms.CheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chktrangthai = new System.Windows.Forms.CheckBox();
            this.cboTT = new System.Windows.Forms.ComboBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.lblsoluong = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.trangthaiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaycapnhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nguoitaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhichuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sokynoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtiennoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cackynoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sonhaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuongColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_KHColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.chkNV.SuspendLayout();
            this.toolStrip2.SuspendLayout();
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
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1088, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seachButton
            // 
            this.seachButton.Image = global::QLCongNo.Properties.Resources.lay_danh_sach;
            this.seachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seachButton.Name = "seachButton";
            this.seachButton.Size = new System.Drawing.Size(108, 22);
            this.seachButton.Text = "Lấy danh sách";
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
            // chkNV
            // 
            this.chkNV.Controls.Add(this.cboPhuong);
            this.chkNV.Controls.Add(this.chkPhuong);
            this.chkNV.Controls.Add(this.chkSDT);
            this.chkNV.Controls.Add(this.cboQuan);
            this.chkNV.Controls.Add(this.chkQuan);
            this.chkNV.Controls.Add(this.chkNgay);
            this.chkNV.Controls.Add(this.dateTimePicker2);
            this.chkNV.Controls.Add(this.dateTimePicker1);
            this.chkNV.Controls.Add(this.label2);
            this.chkNV.Controls.Add(this.chktrangthai);
            this.chkNV.Controls.Add(this.cboTT);
            this.chkNV.Controls.Add(this.txtTim);
            this.chkNV.Controls.Add(this.label6);
            this.chkNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkNV.Location = new System.Drawing.Point(0, 25);
            this.chkNV.Name = "chkNV";
            this.chkNV.Size = new System.Drawing.Size(1088, 93);
            this.chkNV.TabIndex = 25;
            this.chkNV.TabStop = false;
            // 
            // cboPhuong
            // 
            this.cboPhuong.FormattingEnabled = true;
            this.cboPhuong.Location = new System.Drawing.Point(894, 51);
            this.cboPhuong.Name = "cboPhuong";
            this.cboPhuong.Size = new System.Drawing.Size(182, 24);
            this.cboPhuong.TabIndex = 31;
            // 
            // chkPhuong
            // 
            this.chkPhuong.AutoSize = true;
            this.chkPhuong.Location = new System.Drawing.Point(819, 56);
            this.chkPhuong.Name = "chkPhuong";
            this.chkPhuong.Size = new System.Drawing.Size(69, 20);
            this.chkPhuong.TabIndex = 30;
            this.chkPhuong.Text = "Phường";
            this.chkPhuong.UseVisualStyleBackColor = true;
            // 
            // chkSDT
            // 
            this.chkSDT.AutoSize = true;
            this.chkSDT.Location = new System.Drawing.Point(819, 25);
            this.chkSDT.Name = "chkSDT";
            this.chkSDT.Size = new System.Drawing.Size(118, 20);
            this.chkSDT.TabIndex = 29;
            this.chkSDT.Text = "Có số điện thoại";
            this.chkSDT.UseVisualStyleBackColor = true;
            // 
            // cboQuan
            // 
            this.cboQuan.FormattingEnabled = true;
            this.cboQuan.Location = new System.Drawing.Point(600, 51);
            this.cboQuan.Name = "cboQuan";
            this.cboQuan.Size = new System.Drawing.Size(200, 24);
            this.cboQuan.TabIndex = 28;
            // 
            // chkQuan
            // 
            this.chkQuan.AutoSize = true;
            this.chkQuan.Location = new System.Drawing.Point(514, 55);
            this.chkQuan.Name = "chkQuan";
            this.chkQuan.Size = new System.Drawing.Size(56, 20);
            this.chkQuan.TabIndex = 27;
            this.chkQuan.Text = "Quận";
            this.chkQuan.UseVisualStyleBackColor = true;
            // 
            // chkNgay
            // 
            this.chkNgay.AutoSize = true;
            this.chkNgay.Location = new System.Drawing.Point(14, 25);
            this.chkNgay.Name = "chkNgay";
            this.chkNgay.Size = new System.Drawing.Size(73, 20);
            this.chkNgay.TabIndex = 26;
            this.chkNgay.Text = "Từ ngày";
            this.chkNgay.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(317, 23);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(185, 23);
            this.dateTimePicker2.TabIndex = 23;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(95, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(146, 23);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "đến ngày";
            // 
            // chktrangthai
            // 
            this.chktrangthai.AutoSize = true;
            this.chktrangthai.Location = new System.Drawing.Point(514, 25);
            this.chktrangthai.Name = "chktrangthai";
            this.chktrangthai.Size = new System.Drawing.Size(85, 20);
            this.chktrangthai.TabIndex = 19;
            this.chktrangthai.Text = "Trạng thái";
            this.chktrangthai.UseVisualStyleBackColor = true;
            // 
            // cboTT
            // 
            this.cboTT.FormattingEnabled = true;
            this.cboTT.Location = new System.Drawing.Point(600, 21);
            this.cboTT.Name = "cboTT";
            this.cboTT.Size = new System.Drawing.Size(200, 24);
            this.cboTT.TabIndex = 18;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(95, 53);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(406, 23);
            this.txtTim.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tìm kiếm";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblsoluong});
            this.toolStrip2.Location = new System.Drawing.Point(0, 483);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1088, 25);
            this.toolStrip2.TabIndex = 26;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // lblsoluong
            // 
            this.lblsoluong.ForeColor = System.Drawing.Color.Blue;
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(0, 22);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 365);
            this.panel1.TabIndex = 27;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trangthaiColumn,
            this.ngaycapnhat,
            this.nguoitaoColumn,
            this.danhboColumn,
            this.sdtColumn,
            this.GhichuColumn,
            this.hotenColumn,
            this.sokynoColumn,
            this.tongtiennoColumn,
            this.cackynoColumn,
            this.sonhaColumn,
            this.diachiColumn,
            this.phuongColumn,
            this.quanColumn,
            this.ID_KHColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1088, 365);
            this.dataGridView1.TabIndex = 1;
            // 
            // trangthaiColumn
            // 
            this.trangthaiColumn.DataPropertyName = "tenTT";
            this.trangthaiColumn.HeaderText = "Trạng thái";
            this.trangthaiColumn.Name = "trangthaiColumn";
            this.trangthaiColumn.ReadOnly = true;
            this.trangthaiColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.trangthaiColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.trangthaiColumn.Width = 72;
            // 
            // ngaycapnhat
            // 
            this.ngaycapnhat.DataPropertyName = "ngaycapnhat";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.ngaycapnhat.DefaultCellStyle = dataGridViewCellStyle1;
            this.ngaycapnhat.HeaderText = "Ngày cập nhật";
            this.ngaycapnhat.Name = "ngaycapnhat";
            this.ngaycapnhat.Width = 113;
            // 
            // nguoitaoColumn
            // 
            this.nguoitaoColumn.DataPropertyName = "nguoitao";
            this.nguoitaoColumn.HeaderText = "Người cập nhật";
            this.nguoitaoColumn.Name = "nguoitaoColumn";
            this.nguoitaoColumn.ReadOnly = true;
            this.nguoitaoColumn.Width = 118;
            // 
            // danhboColumn
            // 
            this.danhboColumn.DataPropertyName = "madanhbo";
            this.danhboColumn.HeaderText = "Danh bộ";
            this.danhboColumn.Name = "danhboColumn";
            this.danhboColumn.Width = 79;
            // 
            // sdtColumn
            // 
            this.sdtColumn.DataPropertyName = "SDT_KH";
            this.sdtColumn.HeaderText = "SĐT";
            this.sdtColumn.Name = "sdtColumn";
            this.sdtColumn.Width = 57;
            // 
            // GhichuColumn
            // 
            this.GhichuColumn.DataPropertyName = "ghichu";
            this.GhichuColumn.HeaderText = "Ghi chú";
            this.GhichuColumn.Name = "GhichuColumn";
            this.GhichuColumn.Width = 74;
            // 
            // hotenColumn
            // 
            this.hotenColumn.DataPropertyName = "hoten_KH";
            this.hotenColumn.HeaderText = "Họ tên";
            this.hotenColumn.Name = "hotenColumn";
            this.hotenColumn.Width = 69;
            // 
            // sokynoColumn
            // 
            this.sokynoColumn.DataPropertyName = "sokyno";
            this.sokynoColumn.HeaderText = "Số kỳ nợ";
            this.sokynoColumn.Name = "sokynoColumn";
            this.sokynoColumn.Width = 81;
            // 
            // tongtiennoColumn
            // 
            this.tongtiennoColumn.DataPropertyName = "tongtienno";
            dataGridViewCellStyle2.Format = "N0";
            this.tongtiennoColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.tongtiennoColumn.HeaderText = "Tổng tiền nợ";
            this.tongtiennoColumn.Name = "tongtiennoColumn";
            this.tongtiennoColumn.Width = 104;
            // 
            // cackynoColumn
            // 
            this.cackynoColumn.DataPropertyName = "ghichu2";
            this.cackynoColumn.HeaderText = "Các kỳ nợ";
            this.cackynoColumn.Name = "cackynoColumn";
            this.cackynoColumn.Width = 87;
            // 
            // sonhaColumn
            // 
            this.sonhaColumn.DataPropertyName = "sonha";
            this.sonhaColumn.HeaderText = "Số nhà";
            this.sonhaColumn.Name = "sonhaColumn";
            this.sonhaColumn.Width = 72;
            // 
            // diachiColumn
            // 
            this.diachiColumn.DataPropertyName = "diachi";
            this.diachiColumn.HeaderText = "Đường";
            this.diachiColumn.Name = "diachiColumn";
            this.diachiColumn.Width = 70;
            // 
            // phuongColumn
            // 
            this.phuongColumn.DataPropertyName = "tenphuong";
            this.phuongColumn.HeaderText = "Phường";
            this.phuongColumn.Name = "phuongColumn";
            this.phuongColumn.Width = 75;
            // 
            // quanColumn
            // 
            this.quanColumn.DataPropertyName = "tenquan";
            this.quanColumn.HeaderText = "Quận";
            this.quanColumn.Name = "quanColumn";
            this.quanColumn.Width = 62;
            // 
            // ID_KHColumn
            // 
            this.ID_KHColumn.DataPropertyName = "ID_KH";
            this.ID_KHColumn.HeaderText = "ID_KH";
            this.ID_KHColumn.Name = "ID_KHColumn";
            this.ID_KHColumn.Visible = false;
            this.ID_KHColumn.Width = 71;
            // 
            // frKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 508);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.chkNV);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ KHÁCH HÀNG";
            this.Load += new System.EventHandler(this.frKhachHang_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.chkNV.ResumeLayout(false);
            this.chkNV.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton seachButton;
        private System.Windows.Forms.ToolStripButton excelButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox chkNV;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel lblsoluong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboTT;
        private System.Windows.Forms.CheckBox chktrangthai;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkNgay;
        private System.Windows.Forms.ComboBox cboQuan;
        private System.Windows.Forms.CheckBox chkQuan;
        private System.Windows.Forms.CheckBox chkSDT;
        private System.Windows.Forms.ComboBox cboPhuong;
        private System.Windows.Forms.CheckBox chkPhuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthaiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaycapnhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn nguoitaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhichuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sokynoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtiennoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cackynoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sonhaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuongColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quanColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_KHColumn;
    }
}