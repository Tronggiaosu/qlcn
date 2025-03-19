namespace QLCongNo.ReportViewer.BaoCao
{
    partial class frThongKeHDDaThu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frThongKeHDDaThu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboHTTT = new System.Windows.Forms.ComboBox();
            this.chkHTT = new System.Windows.Forms.CheckBox();
            this.cboThuNgan = new System.Windows.Forms.ComboBox();
            this.chkTN = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkNH = new System.Windows.Forms.CheckBox();
            this.cboNganhang = new System.Windows.Forms.ComboBox();
            this.chkisdangngan = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDenngay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTungay = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblsoluong = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbltongtien = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.seriColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaythuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayBKColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien0VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienvatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienBVMTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiNTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienThueNTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongcongColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nganhangColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maloaiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maLTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghichuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.btnExcel,
            this.btnQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1054, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::QLCongNo.Properties.Resources.lay_danh_sach;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 22);
            this.btnSearch.Text = "Lấy danh sách";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(86, 22);
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(60, 22);
            this.btnQuit.Text = "Thoát";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboHTTT);
            this.groupBox1.Controls.Add(this.chkHTT);
            this.groupBox1.Controls.Add(this.cboThuNgan);
            this.groupBox1.Controls.Add(this.chkTN);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.chkNH);
            this.groupBox1.Controls.Add(this.cboNganhang);
            this.groupBox1.Controls.Add(this.chkisdangngan);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpDenngay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpTungay);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1054, 132);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cboHTTT
            // 
            this.cboHTTT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboHTTT.FormattingEnabled = true;
            this.cboHTTT.Location = new System.Drawing.Point(634, 50);
            this.cboHTTT.Name = "cboHTTT";
            this.cboHTTT.Size = new System.Drawing.Size(339, 24);
            this.cboHTTT.TabIndex = 119;
            // 
            // chkHTT
            // 
            this.chkHTT.AutoSize = true;
            this.chkHTT.Location = new System.Drawing.Point(530, 54);
            this.chkHTT.Name = "chkHTT";
            this.chkHTT.Size = new System.Drawing.Size(102, 20);
            this.chkHTT.TabIndex = 118;
            this.chkHTT.Text = "Hình thức thu";
            this.chkHTT.UseVisualStyleBackColor = true;
            // 
            // cboThuNgan
            // 
            this.cboThuNgan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboThuNgan.FormattingEnabled = true;
            this.cboThuNgan.Location = new System.Drawing.Point(87, 50);
            this.cboThuNgan.Name = "cboThuNgan";
            this.cboThuNgan.Size = new System.Drawing.Size(426, 24);
            this.cboThuNgan.TabIndex = 117;
            // 
            // chkTN
            // 
            this.chkTN.AutoSize = true;
            this.chkTN.Location = new System.Drawing.Point(10, 54);
            this.chkTN.Name = "chkTN";
            this.chkTN.Size = new System.Drawing.Size(80, 20);
            this.chkTN.TabIndex = 116;
            this.chkTN.Text = "Thu ngân";
            this.chkTN.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 115;
            this.label3.Text = "Tìm";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(426, 23);
            this.textBox1.TabIndex = 114;
            // 
            // chkNH
            // 
            this.chkNH.AutoSize = true;
            this.chkNH.Location = new System.Drawing.Point(530, 23);
            this.chkNH.Name = "chkNH";
            this.chkNH.Size = new System.Drawing.Size(87, 20);
            this.chkNH.TabIndex = 113;
            this.chkNH.Text = "Ngân hàng";
            this.chkNH.UseVisualStyleBackColor = true;
            // 
            // cboNganhang
            // 
            this.cboNganhang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboNganhang.FormattingEnabled = true;
            this.cboNganhang.Location = new System.Drawing.Point(634, 19);
            this.cboNganhang.Name = "cboNganhang";
            this.cboNganhang.Size = new System.Drawing.Size(339, 24);
            this.cboNganhang.TabIndex = 112;
            // 
            // chkisdangngan
            // 
            this.chkisdangngan.AutoSize = true;
            this.chkisdangngan.Location = new System.Drawing.Point(530, 82);
            this.chkisdangngan.Name = "chkisdangngan";
            this.chkisdangngan.Size = new System.Drawing.Size(106, 20);
            this.chkisdangngan.TabIndex = 110;
            this.chkisdangngan.Text = "Đã đăng ngân";
            this.chkisdangngan.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 103;
            this.label6.Text = "Đến ngày";
            // 
            // dtpDenngay
            // 
            this.dtpDenngay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenngay.Location = new System.Drawing.Point(341, 21);
            this.dtpDenngay.Name = "dtpDenngay";
            this.dtpDenngay.Size = new System.Drawing.Size(171, 23);
            this.dtpDenngay.TabIndex = 102;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 101;
            this.label4.Text = "Từ ngày";
            // 
            // dtpTungay
            // 
            this.dtpTungay.CustomFormat = "dd/MM/yyyy";
            this.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTungay.Location = new System.Drawing.Point(87, 21);
            this.dtpTungay.Name = "dtpTungay";
            this.dtpTungay.Size = new System.Drawing.Size(175, 23);
            this.dtpTungay.TabIndex = 100;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblsoluong,
            this.lbltongtien});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1054, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblsoluong
            // 
            this.lblsoluong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(58, 17);
            this.lblsoluong.Text = "Số lượng";
            // 
            // lbltongtien
            // 
            this.lbltongtien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltongtien.Name = "lbltongtien";
            this.lbltongtien.Size = new System.Drawing.Size(61, 17);
            this.lbltongtien.Text = "Tổng tiền";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seriColumn,
            this.namColumn,
            this.kyHDColumn,
            this.soHDColumn,
            this.danhboColumn,
            this.ngaythuColumn,
            this.ngayBKColumn,
            this.tongtien0VAT,
            this.tienvatColumn,
            this.tienBVMTColumn,
            this.PhiNTColumn,
            this.TienThueNTColumn,
            this.tongcongColumn,
            this.nganhangColumn,
            this.maloaiColumn,
            this.hotenColumn,
            this.maLTColumn,
            this.ghichuColumn,
            this.IDHDColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1054, 235);
            this.dataGridView1.TabIndex = 82;
            // 
            // seriColumn
            // 
            this.seriColumn.DataPropertyName = "KY_HIEU_HD";
            this.seriColumn.HeaderText = "Seri";
            this.seriColumn.Name = "seriColumn";
            this.seriColumn.ReadOnly = true;
            this.seriColumn.Width = 55;
            // 
            // namColumn
            // 
            this.namColumn.DataPropertyName = "nam";
            this.namColumn.HeaderText = "Năm";
            this.namColumn.Name = "namColumn";
            this.namColumn.ReadOnly = true;
            this.namColumn.Visible = false;
            this.namColumn.Width = 62;
            // 
            // kyHDColumn
            // 
            this.kyHDColumn.DataPropertyName = "ten_kyghi";
            this.kyHDColumn.HeaderText = "Kỳ";
            this.kyHDColumn.Name = "kyHDColumn";
            this.kyHDColumn.Width = 45;
            // 
            // soHDColumn
            // 
            this.soHDColumn.DataPropertyName = "SO_HD";
            this.soHDColumn.HeaderText = "Số HĐ";
            this.soHDColumn.Name = "soHDColumn";
            this.soHDColumn.ReadOnly = true;
            this.soHDColumn.Width = 63;
            // 
            // danhboColumn
            // 
            this.danhboColumn.DataPropertyName = "danhbo";
            this.danhboColumn.HeaderText = "Danh bộ";
            this.danhboColumn.Name = "danhboColumn";
            this.danhboColumn.ReadOnly = true;
            this.danhboColumn.Width = 61;
            // 
            // ngaythuColumn
            // 
            this.ngaythuColumn.DataPropertyName = "ngaydangngan";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm:ss";
            dataGridViewCellStyle1.NullValue = null;
            this.ngaythuColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.ngaythuColumn.HeaderText = "Ngày đăng ngân";
            this.ngaythuColumn.Name = "ngaythuColumn";
            this.ngaythuColumn.ReadOnly = true;
            this.ngaythuColumn.Width = 114;
            // 
            // ngayBKColumn
            // 
            this.ngayBKColumn.DataPropertyName = "ngayBK";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy HH:mm:ss";
            dataGridViewCellStyle2.NullValue = null;
            this.ngayBKColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.ngayBKColumn.HeaderText = "Ngày BK";
            this.ngayBKColumn.Name = "ngayBKColumn";
            this.ngayBKColumn.Width = 60;
            // 
            // tongtien0VAT
            // 
            this.tongtien0VAT.DataPropertyName = "tongtien0VAT";
            this.tongtien0VAT.HeaderText = "Tiền nước";
            this.tongtien0VAT.Name = "tongtien0VAT";
            this.tongtien0VAT.Width = 82;
            // 
            // tienvatColumn
            // 
            this.tienvatColumn.DataPropertyName = "tienvat";
            this.tienvatColumn.HeaderText = "Tiền VAT";
            this.tienvatColumn.Name = "tienvatColumn";
            this.tienvatColumn.Width = 57;
            // 
            // tienBVMTColumn
            // 
            this.tienBVMTColumn.DataPropertyName = "tienBVMT";
            this.tienBVMTColumn.HeaderText = "Phí BVMT";
            this.tienBVMTColumn.Name = "tienBVMTColumn";
            this.tienBVMTColumn.Width = 79;
            // 
            // PhiNTColumn
            // 
            this.PhiNTColumn.DataPropertyName = "PhiNT";
            this.PhiNTColumn.HeaderText = "Phí XLNT";
            this.PhiNTColumn.Name = "PhiNTColumn";
            this.PhiNTColumn.Width = 77;
            // 
            // TienThueNTColumn
            // 
            this.TienThueNTColumn.DataPropertyName = "TienThueNT";
            this.TienThueNTColumn.HeaderText = "Thuế phí XLTNT";
            this.TienThueNTColumn.Name = "TienThueNTColumn";
            this.TienThueNTColumn.Width = 114;
            // 
            // tongcongColumn
            // 
            this.tongcongColumn.DataPropertyName = "tongtien";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.tongcongColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tongcongColumn.HeaderText = "Tổng cộng";
            this.tongcongColumn.Name = "tongcongColumn";
            this.tongcongColumn.ReadOnly = true;
            this.tongcongColumn.Width = 61;
            // 
            // nganhangColumn
            // 
            this.nganhangColumn.DataPropertyName = "NVNop";
            this.nganhangColumn.HeaderText = "NV Thu";
            this.nganhangColumn.Name = "nganhangColumn";
            this.nganhangColumn.ReadOnly = true;
            this.nganhangColumn.Width = 69;
            // 
            // maloaiColumn
            // 
            this.maloaiColumn.DataPropertyName = "tenloai";
            this.maloaiColumn.HeaderText = "Mã loại";
            this.maloaiColumn.Name = "maloaiColumn";
            this.maloaiColumn.Width = 68;
            // 
            // hotenColumn
            // 
            this.hotenColumn.DataPropertyName = "hoten_KH";
            this.hotenColumn.HeaderText = "Họ tên";
            this.hotenColumn.Name = "hotenColumn";
            this.hotenColumn.ReadOnly = true;
            this.hotenColumn.Width = 64;
            // 
            // maLTColumn
            // 
            this.maLTColumn.DataPropertyName = "maLT";
            this.maLTColumn.HeaderText = "Mã LT";
            this.maLTColumn.Name = "maLTColumn";
            this.maLTColumn.ReadOnly = true;
            this.maLTColumn.Width = 50;
            // 
            // ghichuColumn
            // 
            this.ghichuColumn.DataPropertyName = "ghichu";
            this.ghichuColumn.HeaderText = "Ghi chú";
            this.ghichuColumn.Name = "ghichuColumn";
            this.ghichuColumn.Width = 69;
            // 
            // IDHDColumn
            // 
            this.IDHDColumn.DataPropertyName = "ID_HD";
            this.IDHDColumn.HeaderText = "IDHD";
            this.IDHDColumn.Name = "IDHDColumn";
            this.IDHDColumn.ReadOnly = true;
            this.IDHDColumn.Visible = false;
            this.IDHDColumn.Width = 66;
            // 
            // frThongKeHDDaThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 414);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frThongKeHDDaThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê khách hàng đã thanh toán";
            this.Load += new System.EventHandler(this.frThongKeHDDaThu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblsoluong;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDenngay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpTungay;
        private System.Windows.Forms.CheckBox chkisdangngan;
        private System.Windows.Forms.CheckBox chkNH;
        private System.Windows.Forms.ComboBox cboNganhang;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboHTTT;
        private System.Windows.Forms.CheckBox chkHTT;
        private System.Windows.Forms.ComboBox cboThuNgan;
        private System.Windows.Forms.CheckBox chkTN;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaythuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayBKColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien0VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienvatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienBVMTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiNTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienThueNTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongcongColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nganhangColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maloaiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghichuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHDColumn;
        private System.Windows.Forms.ToolStripStatusLabel lbltongtien;
    }
}