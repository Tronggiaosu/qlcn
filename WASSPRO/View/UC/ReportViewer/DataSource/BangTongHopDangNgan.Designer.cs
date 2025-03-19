namespace QLCongNo.ReportViewer.DataSource
{
    partial class BangTongHopDangNgan
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bangTongHopDangNganBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new View.Core.NovGroupBox();
            this.label6 = new View.Core.NovLabel();
            this.label5 = new View.Core.NovLabel();
            this.label4 = new View.Core.NovLabel();
            this.cbodoithutien = new View.Core.NovComboBox();
            this.cboKiemSoatVien = new View.Core.NovComboBox();
            this.cboloaihd = new View.Core.NovComboBox();
            this.dtdenngay = new View.Core.NovDateTimePicker();
            this.dttungay = new View.Core.NovDateTimePicker();
            this.label3 = new View.Core.NovLabel();
            this.label2 = new View.Core.NovLabel();
            this.label1 = new View.Core.NovLabel();
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.btnTim = new View.Core.NovToolStripButton();
            this.btnHuy = new View.Core.NovToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bangTongHopDangNganBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bangTongHopDangNganBindingSource
            // 
            this.bangTongHopDangNganBindingSource.DataMember = "BangTongHopDangNgan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbodoithutien);
            this.groupBox1.Controls.Add(this.cboKiemSoatVien);
            this.groupBox1.Controls.Add(this.cboloaihd);
            this.groupBox1.Controls.Add(this.dtdenngay);
            this.groupBox1.Controls.Add(this.dttungay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(939, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(301, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(294, 22);
            this.label6.TabIndex = 32;
            this.label6.Text = "BẢNG TỔNG HỢP ĐĂNG NGÂN";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 31;
            this.label5.Text = "Kiểm soát viên\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 30;
            this.label4.Text = "Đội thu tiền";
            // 
            // cbodoithutien
            // 
            this.cbodoithutien.FormattingEnabled = true;
            this.cbodoithutien.Location = new System.Drawing.Point(195, 120);
            this.cbodoithutien.Name = "cbodoithutien";
            this.cbodoithutien.Size = new System.Drawing.Size(159, 21);
            this.cbodoithutien.TabIndex = 29;
            // 
            // cboKiemSoatVien
            // 
            this.cboKiemSoatVien.FormattingEnabled = true;
            this.cboKiemSoatVien.Location = new System.Drawing.Point(195, 157);
            this.cboKiemSoatVien.Name = "cboKiemSoatVien";
            this.cboKiemSoatVien.Size = new System.Drawing.Size(159, 21);
            this.cboKiemSoatVien.TabIndex = 28;
            // 
            // cboloaihd
            // 
            this.cboloaihd.FormattingEnabled = true;
            this.cboloaihd.Location = new System.Drawing.Point(195, 84);
            this.cboloaihd.Name = "cboloaihd";
            this.cboloaihd.Size = new System.Drawing.Size(159, 21);
            this.cboloaihd.TabIndex = 25;
            // 
            // dtdenngay
            // 
            this.dtdenngay.Location = new System.Drawing.Point(584, 121);
            this.dtdenngay.Name = "dtdenngay";
            this.dtdenngay.Size = new System.Drawing.Size(200, 20);
            this.dtdenngay.TabIndex = 24;
            // 
            // dttungay
            // 
            this.dttungay.Location = new System.Drawing.Point(584, 82);
            this.dttungay.Name = "dttungay";
            this.dttungay.Size = new System.Drawing.Size(200, 20);
            this.dttungay.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "Loại hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(491, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(491, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Đến ngày";
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
            this.toolStrip1.Size = new System.Drawing.Size(933, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.browse;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(87, 22);
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
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
            this.panel1.Location = new System.Drawing.Point(0, 195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 218);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.bangTongHopDangNganBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.BangTongHopDangNgan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(939, 218);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // BangTongHopDangNgan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 413);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "BangTongHopDangNgan";
            this.Load += new System.EventHandler(this.BangTongHopDangNgan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bangTongHopDangNganBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private View.Core.Nov groupBox1;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnHuy;
        private View.Core.NovLabel label5;
        private View.Core.NovLabel label4;
        private View.Core.NovComboBox  cbodoithutien;
        private View.Core.NovComboBox  cboKiemSoatVien;
        private View.Core.NovComboBox  cboloaihd;
        private View.Core.NovDateTimePicker dtdenngay;
        private View.Core.NovDateTimePicker dttungay;
        private View.Core.NovLabel label3;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label1;
        private View.Core.NovLabel label6;
        private System.Windows.Forms.BindingSource bangTongHopDangNganBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.BangTongHopDangNganTableAdapter bangTongHopDangNganTableAdapter;
    }
}