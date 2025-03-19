namespace QLCongNo.ReportViewer.BaoCao
{
    partial class frmBaoCaoTongHop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCaoTongHop));
            this.getBaoCaoTongHopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDT = new System.Windows.Forms.CheckBox();
            this.cboDT = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDenngay = new System.Windows.Forms.DateTimePicker();
            this.dtpTungay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getBaoCaoTongHopTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getBaoCaoTongHopTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getBaoCaoTongHopBindingSource
            // 
            this.getBaoCaoTongHopBindingSource.DataMember = "getBaoCaoTongHop";
            this.getBaoCaoTongHopBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1047, 26);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(82, 23);
            this.btnTim.Text = "Tra cứu";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(60, 23);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.chkDT);
            this.groupBox1.Controls.Add(this.cboDT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpDenngay);
            this.groupBox1.Controls.Add(this.dtpTungay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1047, 117);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // chkDT
            // 
            this.chkDT.AutoSize = true;
            this.chkDT.Location = new System.Drawing.Point(353, 24);
            this.chkDT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDT.Name = "chkDT";
            this.chkDT.Size = new System.Drawing.Size(98, 23);
            this.chkDT.TabIndex = 123;
            this.chkDT.Text = "Đối tượng";
            this.chkDT.UseVisualStyleBackColor = true;
            // 
            // cboDT
            // 
            this.cboDT.FormattingEnabled = true;
            this.cboDT.Location = new System.Drawing.Point(353, 56);
            this.cboDT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDT.Name = "cboDT";
            this.cboDT.Size = new System.Drawing.Size(305, 27);
            this.cboDT.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 19);
            this.label6.TabIndex = 118;
            this.label6.Text = "Đến ngày";
            // 
            // dtpDenngay
            // 
            this.dtpDenngay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenngay.Location = new System.Drawing.Point(131, 57);
            this.dtpDenngay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtpDenngay.Name = "dtpDenngay";
            this.dtpDenngay.Size = new System.Drawing.Size(179, 26);
            this.dtpDenngay.TabIndex = 117;
            // 
            // dtpTungay
            // 
            this.dtpTungay.CustomFormat = "dd/MM/yyyy";
            this.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTungay.Location = new System.Drawing.Point(131, 21);
            this.dtpTungay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtpTungay.Name = "dtpTungay";
            this.dtpTungay.Size = new System.Drawing.Size(179, 26);
            this.dtpTungay.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 116;
            this.label4.Text = "Từ ngày";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = this.getBaoCaoTongHopBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPBaoCaoTongHop.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 143);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1047, 350);
            this.reportViewer1.TabIndex = 6;
            // 
            // getBaoCaoTongHopTableAdapter
            // 
            this.getBaoCaoTongHopTableAdapter.ClearBeforeFill = true;
            // 
            // frmBaoCaoTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 493);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmBaoCaoTongHop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TỔNG HỢP ĐĂNG NGÂN";
            this.Load += new System.EventHandler(this.frmBaoCaoTongHop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDenngay;
        private System.Windows.Forms.DateTimePicker dtpTungay;
        private System.Windows.Forms.Label label4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getBaoCaoTongHopBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoTongHopTableAdapter getBaoCaoTongHopTableAdapter;
        private System.Windows.Forms.CheckBox chkDT;

    }
}