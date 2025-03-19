namespace QLCongNo.ReportViewer.DataSource
{
    partial class BangTongHopHoaDon
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.groupBox1 = new View.Core.NovGroupBox();
            this.checkBang0TheoDot = new View.Core.NovCheckBox();
            this.checkTheoDot = new View.Core.NovCheckBox();
            this.checkBangChuanThu = new View.Core.NovCheckBox();
            this.label3 = new View.Core.NovLabel();
            this.label2 = new View.Core.NovLabel();
            this.label1 = new View.Core.NovLabel();
            this.cboTo = new View.Core.NovComboBox();
            this.cboKyghi = new View.Core.NovComboBox();
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.btnTim = new View.Core.NovToolStripButton();
            this.toolStripButton2 = new View.Core.NovToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.rPBangTongHopHoaDonChuanChuKyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rPBangTongHopHoaDonChuanChuKyTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.RPBangTongHopHoaDonChuanChuKyTableAdapter();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPBangTongHopHoaDonChuanChuKyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBang0TheoDot);
            this.groupBox1.Controls.Add(this.checkTheoDot);
            this.groupBox1.Controls.Add(this.checkBangChuanThu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboTo);
            this.groupBox1.Controls.Add(this.cboKyghi);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // checkBang0TheoDot
            // 
            this.checkBang0TheoDot.AutoSize = true;
            this.checkBang0TheoDot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBang0TheoDot.Location = new System.Drawing.Point(390, 143);
            this.checkBang0TheoDot.Name = "checkBang0TheoDot";
            this.checkBang0TheoDot.Size = new System.Drawing.Size(310, 23);
            this.checkBang0TheoDot.TabIndex = 10;
            this.checkBang0TheoDot.Text = "In bảng tổng hợp hóa đơn bằng 0 chia theo đợt\r\n";
            this.checkBang0TheoDot.UseVisualStyleBackColor = true;
            // 
            // checkTheoDot
            // 
            this.checkTheoDot.AutoSize = true;
            this.checkTheoDot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTheoDot.Location = new System.Drawing.Point(390, 120);
            this.checkTheoDot.Name = "checkTheoDot";
            this.checkTheoDot.Size = new System.Drawing.Size(265, 23);
            this.checkTheoDot.TabIndex = 9;
            this.checkTheoDot.Text = "In bảng tổng hợp hóa đơn chia theo đợt\r\n";
            this.checkTheoDot.UseVisualStyleBackColor = true;
            // 
            // checkBangChuanThu
            // 
            this.checkBangChuanThu.AutoSize = true;
            this.checkBangChuanThu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBangChuanThu.Location = new System.Drawing.Point(390, 97);
            this.checkBangChuanThu.Name = "checkBangChuanThu";
            this.checkBangChuanThu.Size = new System.Drawing.Size(134, 23);
            this.checkBangChuanThu.TabIndex = 8;
            this.checkBangChuanThu.Text = "In bảng chuẩn thu";
            this.checkBangChuanThu.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(133, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kỳ ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "In bảng tổng hợp hóa đơn";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboTo
            // 
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(201, 139);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(121, 21);
            this.cboTo.TabIndex = 4;
            // 
            // cboKyghi
            // 
            this.cboKyghi.FormattingEnabled = true;
            this.cboKyghi.Location = new System.Drawing.Point(201, 97);
            this.cboKyghi.Name = "cboKyghi";
            this.cboKyghi.Size = new System.Drawing.Size(121, 21);
            this.cboKyghi.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(708, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QLCongNo.Properties.Resources._126_Edit_24x24_72;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(86, 22);
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = global::QLCongNo.Properties.Resources._1385_Disable_16x16_72;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton2.Text = "Thoát";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 212);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.rPBangTongHopHoaDonChuanChuKyBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.ChuanThuKy.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(714, 212);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rPBangTongHopHoaDonChuanChuKyBindingSource
            // 
            this.rPBangTongHopHoaDonChuanChuKyBindingSource.DataMember = "RPBangTongHopHoaDonChuanChuKy";
            this.rPBangTongHopHoaDonChuanChuKyBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // rPBangTongHopHoaDonChuanChuKyTableAdapter
            // 
            this.rPBangTongHopHoaDonChuanChuKyTableAdapter.ClearBeforeFill = true;
            // 
            // BangTongHopHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 410);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "BangTongHopHoaDon";
            this.Text = "BangTongHopHoaDon";
            this.Load += new System.EventHandler(this.BangTongHopHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPBangTongHopHoaDonChuanChuKyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private View.Core.Nov groupBox1;
        private System.Windows.Forms.Panel panel1;
        private View.Core.NovCheckBox checkBang0TheoDot;
        private View.Core.NovCheckBox checkTheoDot;
        private View.Core.NovCheckBox checkBangChuanThu;
        private View.Core.NovLabel label3;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label1;
        private View.Core.NovComboBox  cboTo;
        private View.Core.NovComboBox  cboKyghi;
        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton toolStripButton2;
        private View.Core.NovToolStripButton btnTim;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rPBangTongHopHoaDonChuanChuKyBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.RPBangTongHopHoaDonChuanChuKyTableAdapter rPBangTongHopHoaDonChuanChuKyTableAdapter;
    }
}