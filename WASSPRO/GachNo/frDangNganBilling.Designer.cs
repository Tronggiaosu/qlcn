namespace QLCongNo.GachNo
{
    partial class frDangNganBilling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frDangNganBilling));
            this.getDangNganBillingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDT = new System.Windows.Forms.ComboBox();
            this.cboKSV = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboloaiHD = new System.Windows.Forms.ComboBox();
            this.cboDTSD = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getDangNganBillingTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getDangNganBillingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getDangNganBillingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getDangNganBillingBindingSource
            // 
            this.getDangNganBillingBindingSource.DataMember = "getDangNganBilling";
            this.getDangNganBillingBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStrip2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.quitButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1032, 25);
            this.toolStrip2.TabIndex = 77;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(52, 22);
            this.btnTim.Text = "Tìm";
            // 
            // quitButton
            // 
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(65, 22);
            this.quitButton.Text = "Thoát";
            this.quitButton.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboDT);
            this.groupBox1.Controls.Add(this.cboKSV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cboloaiHD);
            this.groupBox1.Controls.Add(this.cboDTSD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 74);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 93;
            this.label3.Text = "Đội trưởng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 92;
            this.label1.Text = "Kiểm soát viên";
            // 
            // cboDT
            // 
            this.cboDT.FormattingEnabled = true;
            this.cboDT.Location = new System.Drawing.Point(27, 37);
            this.cboDT.Name = "cboDT";
            this.cboDT.Size = new System.Drawing.Size(271, 25);
            this.cboDT.TabIndex = 91;
            // 
            // cboKSV
            // 
            this.cboKSV.FormattingEnabled = true;
            this.cboKSV.Location = new System.Drawing.Point(304, 37);
            this.cboKSV.Name = "cboKSV";
            this.cboKSV.Size = new System.Drawing.Size(255, 25);
            this.cboKSV.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 89;
            this.label4.Text = "Ngày trả";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(566, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 25);
            this.dateTimePicker1.TabIndex = 88;
            // 
            // cboloaiHD
            // 
            this.cboloaiHD.FormattingEnabled = true;
            this.cboloaiHD.Location = new System.Drawing.Point(896, 37);
            this.cboloaiHD.Name = "cboloaiHD";
            this.cboloaiHD.Size = new System.Drawing.Size(113, 25);
            this.cboloaiHD.TabIndex = 85;
            // 
            // cboDTSD
            // 
            this.cboDTSD.FormattingEnabled = true;
            this.cboDTSD.Location = new System.Drawing.Point(722, 37);
            this.cboDTSD.Name = "cboDTSD";
            this.cboDTSD.Size = new System.Drawing.Size(169, 25);
            this.cboDTSD.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(722, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 81;
            this.label2.Text = "Đối tượng sử dụng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(896, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 82;
            this.label5.Text = "Loại hóa đơn";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = this.getDangNganBillingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPTongHopDangNgan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 99);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1032, 359);
            this.reportViewer1.TabIndex = 79;
            // 
            // getDangNganBillingTableAdapter
            // 
            this.getDangNganBillingTableAdapter.ClearBeforeFill = true;
            // 
            // frDangNganBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 458);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frDangNganBilling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NGÂN";
            this.Load += new System.EventHandler(this.frDangNganBilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getDangNganBillingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboloaiHD;
        private System.Windows.Forms.ComboBox cboDTSD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDT;
        private System.Windows.Forms.ComboBox cboKSV;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getDangNganBillingBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getDangNganBillingTableAdapter getDangNganBillingTableAdapter;
    }
}