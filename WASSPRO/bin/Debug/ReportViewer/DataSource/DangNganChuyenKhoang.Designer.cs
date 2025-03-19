namespace QLCongNo.ReportViewer.DataSource
{
    partial class DangNganChuyenKhoang
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNganChuyenKhoang));
            this.phieuDangNganChuyenKhoangChiTietBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDoiTruong = new System.Windows.Forms.ComboBox();
            this.cboNVLapPhieu = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.checkTongCong = new System.Windows.Forms.CheckBox();
            this.checkChiTiet = new System.Windows.Forms.CheckBox();
            this.cbodoituong = new System.Windows.Forms.ComboBox();
            this.dtdenngay = new System.Windows.Forms.DateTimePicker();
            this.dttungay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.phieuDangNganChuyenKhoangTongHopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.phieuDangNganChuyenKhoangChiTietBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phieuDangNganChuyenKhoangTongHopBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // phieuDangNganChuyenKhoangChiTietBindingSource
            // 
            this.phieuDangNganChuyenKhoangChiTietBindingSource.DataMember = "PhieuDangNganChuyenKhoangChiTiet";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboDoiTruong);
            this.groupBox1.Controls.Add(this.cboNVLapPhieu);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.checkTongCong);
            this.groupBox1.Controls.Add(this.checkChiTiet);
            this.groupBox1.Controls.Add(this.cbodoituong);
            this.groupBox1.Controls.Add(this.dtdenngay);
            this.groupBox1.Controls.Add(this.dttungay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1171, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(135, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nhân viên lập phiếu";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(135, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Đội trưởng";
            // 
            // cboDoiTruong
            // 
            this.cboDoiTruong.FormattingEnabled = true;
            this.cboDoiTruong.Location = new System.Drawing.Point(284, 117);
            this.cboDoiTruong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDoiTruong.Name = "cboDoiTruong";
            this.cboDoiTruong.Size = new System.Drawing.Size(283, 24);
            this.cboDoiTruong.TabIndex = 17;
            // 
            // cboNVLapPhieu
            // 
            this.cboNVLapPhieu.FormattingEnabled = true;
            this.cboNVLapPhieu.Location = new System.Drawing.Point(328, 162);
            this.cboNVLapPhieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboNVLapPhieu.Name = "cboNVLapPhieu";
            this.cboNVLapPhieu.Size = new System.Drawing.Size(238, 24);
            this.cboNVLapPhieu.TabIndex = 16;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnHuy});
            this.toolStrip1.Location = new System.Drawing.Point(4, 20);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1163, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(80, 22);
            this.btnTim.Text = "Tìm kiếm";
            // 
            // btnHuy
            // 
            this.btnHuy.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(60, 22);
            this.btnHuy.Text = "Thoát";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // checkTongCong
            // 
            this.checkTongCong.AutoSize = true;
            this.checkTongCong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTongCong.Location = new System.Drawing.Point(808, 162);
            this.checkTongCong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkTongCong.Name = "checkTongCong";
            this.checkTongCong.Size = new System.Drawing.Size(97, 23);
            this.checkTongCong.TabIndex = 7;
            this.checkTongCong.Text = "Tổng cộng";
            this.checkTongCong.UseVisualStyleBackColor = true;
            // 
            // checkChiTiet
            // 
            this.checkChiTiet.AutoSize = true;
            this.checkChiTiet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkChiTiet.Location = new System.Drawing.Point(634, 162);
            this.checkChiTiet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkChiTiet.Name = "checkChiTiet";
            this.checkChiTiet.Size = new System.Drawing.Size(77, 23);
            this.checkChiTiet.TabIndex = 6;
            this.checkChiTiet.Text = "Chi tiết";
            this.checkChiTiet.UseVisualStyleBackColor = true;
            // 
            // cbodoituong
            // 
            this.cbodoituong.FormattingEnabled = true;
            this.cbodoituong.Location = new System.Drawing.Point(284, 73);
            this.cbodoituong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbodoituong.Name = "cbodoituong";
            this.cbodoituong.Size = new System.Drawing.Size(283, 24);
            this.cbodoituong.TabIndex = 5;
            // 
            // dtdenngay
            // 
            this.dtdenngay.CustomFormat = "dd/MM/yyyy";
            this.dtdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtdenngay.Location = new System.Drawing.Point(737, 118);
            this.dtdenngay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtdenngay.Name = "dtdenngay";
            this.dtdenngay.Size = new System.Drawing.Size(233, 23);
            this.dtdenngay.TabIndex = 4;
            // 
            // dttungay
            // 
            this.dttungay.CustomFormat = "dd/MM/yyyy";
            this.dttungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttungay.Location = new System.Drawing.Point(737, 70);
            this.dttungay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dttungay.Name = "dttungay";
            this.dttungay.Size = new System.Drawing.Size(233, 23);
            this.dttungay.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(135, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đối tượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(629, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(629, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đến ngày";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 218);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 423);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.phieuDangNganChuyenKhoangChiTietBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.PhieuDangNganChuyenKhoangChiTiet.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1171, 423);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // phieuDangNganChuyenKhoangTongHopBindingSource
            // 
            this.phieuDangNganChuyenKhoangTongHopBindingSource.DataMember = "PhieuDangNganChuyenKhoangTongHop";
            // 
            // DangNganChuyenKhoang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DangNganChuyenKhoang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DangNganChuyenKhoang";
            this.Load += new System.EventHandler(this.DangNganChuyenKhoang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.phieuDangNganChuyenKhoangChiTietBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.phieuDangNganChuyenKhoangTongHopBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.CheckBox checkTongCong;
        private System.Windows.Forms.CheckBox checkChiTiet;
        private System.Windows.Forms.ComboBox cbodoituong;
        private System.Windows.Forms.DateTimePicker dtdenngay;
        private System.Windows.Forms.DateTimePicker dttungay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private System.Windows.Forms.BindingSource phieuDangNganChuyenKhoangChiTietBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.PhieuDangNganChuyenKhoangChiTietTableAdapter phieuDangNganChuyenKhoangChiTietTableAdapter;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet1;
        private System.Windows.Forms.BindingSource phieuDangNganChuyenKhoangTongHopBindingSource;
        private CAPNUOC_TDCDataSetTableAdapters.PhieuDangNganChuyenKhoangTongHopTableAdapter phieuDangNganChuyenKhoangTongHopTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDoiTruong;
        private System.Windows.Forms.ComboBox cboNVLapPhieu;
    }
}