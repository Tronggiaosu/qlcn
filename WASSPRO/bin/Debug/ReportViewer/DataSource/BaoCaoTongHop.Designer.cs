namespace QLCongNo.ReportViewer.DataSource
{
    partial class BaoCaoTongHop
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
            this.rPBangTongHopHoaDonChuanThuKyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.checkBang0TheoDot = new System.Windows.Forms.CheckBox();
            this.checkChiaTheoDot = new System.Windows.Forms.CheckBox();
            this.checkBangChuanThu = new System.Windows.Forms.CheckBox();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rPBangTongHopHoaDonChuanChuKyTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getBaoCaoChuanThuKyTableAdapter();
            this.rPBangTongHopHoaDonChuanThuKyBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rPBangTongHopHoaDonChuanChuKyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rPBangTongHopHoaDonChuanThuKyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rPBangTongHopHoaDonChuanThuKyBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPBangTongHopHoaDonChuanChuKyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rPBangTongHopHoaDonChuanThuKyBindingSource
            // 
            this.rPBangTongHopHoaDonChuanThuKyBindingSource.DataMember = "RPBangTongHopHoaDonChuanThuKy";
            this.rPBangTongHopHoaDonChuanThuKyBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.checkBang0TheoDot);
            this.groupBox1.Controls.Add(this.checkChiaTheoDot);
            this.groupBox1.Controls.Add(this.checkBangChuanThu);
            this.groupBox1.Controls.Add(this.cboTo);
            this.groupBox1.Controls.Add(this.cboKy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(924, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.toolStrip1.Size = new System.Drawing.Size(918, 25);
            this.toolStrip1.TabIndex = 14;
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
            // checkBang0TheoDot
            // 
            this.checkBang0TheoDot.AutoSize = true;
            this.checkBang0TheoDot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBang0TheoDot.Location = new System.Drawing.Point(468, 112);
            this.checkBang0TheoDot.Name = "checkBang0TheoDot";
            this.checkBang0TheoDot.Size = new System.Drawing.Size(366, 23);
            this.checkBang0TheoDot.TabIndex = 6;
            this.checkBang0TheoDot.Text = "Bảng tổng hợp những hóa đơn bằng 0 chia theo đợt";
            this.checkBang0TheoDot.UseVisualStyleBackColor = true;
            // 
            // checkChiaTheoDot
            // 
            this.checkChiaTheoDot.AutoSize = true;
            this.checkChiaTheoDot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkChiaTheoDot.Location = new System.Drawing.Point(468, 83);
            this.checkChiaTheoDot.Name = "checkChiaTheoDot";
            this.checkChiaTheoDot.Size = new System.Drawing.Size(272, 23);
            this.checkChiaTheoDot.TabIndex = 5;
            this.checkChiaTheoDot.Text = "Bảng tổng hợp hóa đơn chia theo đợt\r\n";
            this.checkChiaTheoDot.UseVisualStyleBackColor = true;
            // 
            // checkBangChuanThu
            // 
            this.checkBangChuanThu.AutoSize = true;
            this.checkBangChuanThu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBangChuanThu.Location = new System.Drawing.Point(468, 54);
            this.checkBangChuanThu.Name = "checkBangChuanThu";
            this.checkBangChuanThu.Size = new System.Drawing.Size(158, 23);
            this.checkBangChuanThu.TabIndex = 4;
            this.checkBangChuanThu.Text = "In Bảng Chuẩn Thu";
            this.checkBangChuanThu.UseVisualStyleBackColor = true;
            // 
            // cboTo
            // 
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(227, 103);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(121, 21);
            this.cboTo.TabIndex = 3;
            // 
            // cboKy
            // 
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(227, 57);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(121, 21);
            this.cboKy.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kỳ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 270);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.rPBangTongHopHoaDonChuanThuKyBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.ChuanThuKy.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(924, 270);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.Load += new System.EventHandler(this.reportViewer_Load_1);
            // 
            // rPBangTongHopHoaDonChuanChuKyTableAdapter
            // 
            this.rPBangTongHopHoaDonChuanChuKyTableAdapter.ClearBeforeFill = true;
            // 
            // rPBangTongHopHoaDonChuanThuKyBindingSource1
            // 
            this.rPBangTongHopHoaDonChuanThuKyBindingSource1.DataMember = "RPBangTongHopHoaDonChuanThuKy";
            this.rPBangTongHopHoaDonChuanThuKyBindingSource1.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // rPBangTongHopHoaDonChuanChuKyBindingSource
            // 
            this.rPBangTongHopHoaDonChuanChuKyBindingSource.DataMember = "RPBangTongHopHoaDonChuanThuKy";
            this.rPBangTongHopHoaDonChuanChuKyBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // BaoCaoTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 423);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "BaoCaoTongHop";
            this.Load += new System.EventHandler(this.BaoCaoTongHop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rPBangTongHopHoaDonChuanThuKyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rPBangTongHopHoaDonChuanThuKyBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPBangTongHopHoaDonChuanChuKyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBang0TheoDot;
        private System.Windows.Forms.CheckBox checkChiaTheoDot;
        private System.Windows.Forms.CheckBox checkBangChuanThu;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private System.Windows.Forms.BindingSource rPBangTongHopHoaDonChuanThuKyBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoChuanThuKyTableAdapter rPBangTongHopHoaDonChuanChuKyTableAdapter;
        private System.Windows.Forms.BindingSource rPBangTongHopHoaDonChuanThuKyBindingSource1;
        private System.Windows.Forms.BindingSource rPBangTongHopHoaDonChuanChuKyBindingSource;
    }
}