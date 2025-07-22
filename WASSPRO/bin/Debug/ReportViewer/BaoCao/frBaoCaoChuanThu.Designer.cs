namespace QLCongNo.ReportViewer.BaoCao
{
    partial class frBaoCaoChuanThu
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frBaoCaoChuanThu));
            this.getBaoCaoChuanThuKyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.cboNam = new System.Windows.Forms.GroupBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getBaoCaoChuanThuKyTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getBaoCaoChuanThuKyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoChuanThuKyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.cboNam.SuspendLayout();
            this.SuspendLayout();
            // 
            // getBaoCaoChuanThuKyBindingSource
            // 
            this.getBaoCaoChuanThuKyBindingSource.DataMember = "getBaoCaoChuanThuKy";
            this.getBaoCaoChuanThuKyBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(791, 26);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Cambria", 12F);
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(82, 23);
            this.btnTim.Text = "Tra cứu";
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(61, 23);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Visible = false;
            // 
            // cboNam
            // 
            this.cboNam.BackColor = System.Drawing.SystemColors.Window;
            this.cboNam.Controls.Add(this.cboKy);
            this.cboNam.Controls.Add(this.cboTo);
            this.cboNam.Controls.Add(this.checkBox1);
            this.cboNam.Controls.Add(this.label1);
            this.cboNam.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboNam.Location = new System.Drawing.Point(0, 26);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(791, 112);
            this.cboNam.TabIndex = 6;
            this.cboNam.TabStop = false;
            // 
            // cboKy
            // 
            this.cboKy.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(98, 17);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(119, 27);
            this.cboKy.TabIndex = 3;
            // 
            // cboTo
            // 
            this.cboTo.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(98, 54);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(119, 27);
            this.cboTo.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(42, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 23);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Tổ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = this.getBaoCaoChuanThuKyBindingSource;
            reportDataSource2.Name = "DataSourceHDTheoDot";
            reportDataSource2.Value = null;
            reportDataSource3.Name = "DataSourceDHKhongDong";
            reportDataSource3.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPTongHopHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 138);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(791, 383);
            this.reportViewer1.TabIndex = 7;
            // 
            // getBaoCaoChuanThuKyTableAdapter
            // 
            this.getBaoCaoChuanThuKyTableAdapter.ClearBeforeFill = true;
            // 
            // frBaoCaoChuanThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 521);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frBaoCaoChuanThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO CHUẨN THU";
            this.Load += new System.EventHandler(this.frBaoCaoChuanThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoChuanThuKyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cboNam.ResumeLayout(false);
            this.cboNam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.GroupBox cboNam;
        private System.Windows.Forms.BindingSource getBaoCaoChuanThuKyBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoChuanThuKyTableAdapter getBaoCaoChuanThuKyTableAdapter;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.CheckBox checkBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
    }
}