namespace QLCongNo.ReportViewer.DataSource
{
    partial class NhapLieuDangNganCuaThuNhanVien
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
            this.nhapLieuDangNganCuaNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new View.Core.NovGroupBox();
            this.label6 = new View.Core.NovLabel();
            this.label5 = new View.Core.NovLabel();
            this.label4 = new View.Core.NovLabel();
            this.label3 = new View.Core.NovLabel();
            this.label2 = new View.Core.NovLabel();
            this.label1 = new View.Core.NovLabel();
            this.dtNgayTra = new View.Core.NovDateTimePicker();
            this.cboHinhThucTT = new View.Core.NovComboBox();
            this.cboDoiTuong = new View.Core.NovComboBox();
            this.cboLoaiHD = new View.Core.NovComboBox();
            this.cboThuNhanVien = new View.Core.NovComboBox();
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.btnTim = new View.Core.NovToolStripButton();
            this.btnHuy = new View.Core.NovToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.nhapLieuDangNganCuaNhanVienBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nhapLieuDangNganCuaNhanVienBindingSource
            // 
            this.nhapLieuDangNganCuaNhanVienBindingSource.DataMember = "NhapLieuDangNganCuaNhanVien";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtNgayTra);
            this.groupBox1.Controls.Add(this.cboHinhThucTT);
            this.groupBox1.Controls.Add(this.cboDoiTuong);
            this.groupBox1.Controls.Add(this.cboLoaiHD);
            this.groupBox1.Controls.Add(this.cboThuNhanVien);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(993, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(332, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(326, 22);
            this.label6.TabIndex = 30;
            this.label6.Text = "Nhập liệu đăng ngân của thu nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 29;
            this.label5.Text = "Hình thức TT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 19);
            this.label4.TabIndex = 28;
            this.label4.Text = "Đối tượng sử dụng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(121, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 27;
            this.label3.Text = "Thu ngân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(564, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "Loại HĐ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(563, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Ngày trả";
            // 
            // dtNgayTra
            // 
            this.dtNgayTra.Location = new System.Drawing.Point(648, 92);
            this.dtNgayTra.Name = "dtNgayTra";
            this.dtNgayTra.Size = new System.Drawing.Size(254, 20);
            this.dtNgayTra.TabIndex = 24;
            // 
            // cboHinhThucTT
            // 
            this.cboHinhThucTT.FormattingEnabled = true;
            this.cboHinhThucTT.Location = new System.Drawing.Point(277, 161);
            this.cboHinhThucTT.Name = "cboHinhThucTT";
            this.cboHinhThucTT.Size = new System.Drawing.Size(241, 21);
            this.cboHinhThucTT.TabIndex = 23;
            // 
            // cboDoiTuong
            // 
            this.cboDoiTuong.FormattingEnabled = true;
            this.cboDoiTuong.Location = new System.Drawing.Point(277, 126);
            this.cboDoiTuong.Name = "cboDoiTuong";
            this.cboDoiTuong.Size = new System.Drawing.Size(241, 21);
            this.cboDoiTuong.TabIndex = 22;
            this.cboDoiTuong.SelectedIndexChanged += new System.EventHandler(this.cboDoiTuong_SelectedIndexChanged);
            // 
            // cboLoaiHD
            // 
            this.cboLoaiHD.FormattingEnabled = true;
            this.cboLoaiHD.Location = new System.Drawing.Point(648, 127);
            this.cboLoaiHD.Name = "cboLoaiHD";
            this.cboLoaiHD.Size = new System.Drawing.Size(254, 21);
            this.cboLoaiHD.TabIndex = 21;
            // 
            // cboThuNhanVien
            // 
            this.cboThuNhanVien.FormattingEnabled = true;
            this.cboThuNhanVien.Location = new System.Drawing.Point(277, 91);
            this.cboThuNhanVien.Name = "cboThuNhanVien";
            this.cboThuNhanVien.Size = new System.Drawing.Size(241, 21);
            this.cboThuNhanVien.TabIndex = 20;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnHuy});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(987, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.browse;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(87, 22);
            this.btnTim.Text = "Tìm kiếm";
            // 
            // btnHuy
            // 
            this.btnHuy.Image = global::QLCongNo.Properties.Resources.delete1;
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(64, 22);
            this.btnHuy.Text = "Thoát";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 219);
            this.panel1.TabIndex = 20;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.nhapLieuDangNganCuaNhanVienBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.NhapLieuDangNganCuaThuNhanVien.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(993, 219);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // NhapLieuDangNganCuaThuNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 425);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "NhapLieuDangNganCuaThuNhanVien";
            this.Text = "NhapLieuDangNganCuaThuNhanVien";
            this.Load += new System.EventHandler(this.NhapLieuDangNganCuaThuNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nhapLieuDangNganCuaNhanVienBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CAPNUOC_TDCDataSetTableAdapters.sp_PaymentLogonTableAdapter sp_PaymentLogonTableAdapter1;
        private View.Core.Nov groupBox1;
        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnHuy;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private View.Core.NovDateTimePicker dtNgayTra;
        private View.Core.NovComboBox  cboHinhThucTT;
        private View.Core.NovComboBox  cboDoiTuong;
        private View.Core.NovComboBox  cboLoaiHD;
        private View.Core.NovComboBox  cboThuNhanVien;
        private System.Windows.Forms.BindingSource nhapLieuDangNganCuaNhanVienBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.NhapLieuDangNganCuaNhanVienTableAdapter nhapLieuDangNganCuaNhanVienTableAdapter;
        private View.Core.NovLabel label6;
        private View.Core.NovLabel label5;
        private View.Core.NovLabel label4;
        private View.Core.NovLabel label3;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label1;
    }
}