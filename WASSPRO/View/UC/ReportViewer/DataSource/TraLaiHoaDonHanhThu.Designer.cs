namespace QLCongNo.ReportViewer.DataSource
{
    partial class TraLaiHoaDonHanhThu
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
            this.traLaiHoaDonHanhThuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new View.Core.NovGroupBox();
            this.dtdenngay = new View.Core.NovDateTimePicker();
            this.label4 = new View.Core.NovLabel();
            this.cboNVThu = new View.Core.NovComboBox();
            this.dttungay = new View.Core.NovDateTimePicker();
            this.label3 = new View.Core.NovLabel();
            this.label2 = new View.Core.NovLabel();
            this.label1 = new View.Core.NovLabel();
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.btnTim = new View.Core.NovToolStripButton();
            this.btnHuy = new View.Core.NovToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.traLaiHoaDonHanhThuBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // traLaiHoaDonHanhThuBindingSource
            // 
            this.traLaiHoaDonHanhThuBindingSource.DataMember = "TraLaiHoaDonHanhThu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtdenngay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboNVThu);
            this.groupBox1.Controls.Add(this.dttungay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dtdenngay
            // 
            this.dtdenngay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtdenngay.Location = new System.Drawing.Point(648, 96);
            this.dtdenngay.Name = "dtdenngay";
            this.dtdenngay.Size = new System.Drawing.Size(200, 26);
            this.dtdenngay.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "Từ ngày";
            // 
            // cboNVThu
            // 
            this.cboNVThu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNVThu.FormattingEnabled = true;
            this.cboNVThu.Location = new System.Drawing.Point(366, 140);
            this.cboNVThu.Name = "cboNVThu";
            this.cboNVThu.Size = new System.Drawing.Size(283, 27);
            this.cboNVThu.TabIndex = 22;
            this.cboNVThu.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dttungay
            // 
            this.dttungay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttungay.Location = new System.Drawing.Point(328, 96);
            this.dttungay.Name = "dttungay";
            this.dttungay.Size = new System.Drawing.Size(200, 26);
            this.dttungay.TabIndex = 21;
            this.dttungay.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(245, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Thu nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Trả lại hóa đơn hành thu";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnHuy});
            this.toolStrip1.Location = new System.Drawing.Point(3, 22);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(996, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.browse;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(87, 22);
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click_1);
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
            this.panel1.Size = new System.Drawing.Size(1002, 217);
            this.panel1.TabIndex = 1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.traLaiHoaDonHanhThuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.TraLaiHoaDonHanhThu.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1002, 217);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // TraLaiHoaDonHanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "TraLaiHoaDonHanhThu";
            this.Load += new System.EventHandler(this.TraLaiHoaDonHanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.traLaiHoaDonHanhThuBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private View.Core.Nov groupBox1;
        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnHuy;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private View.Core.NovDateTimePicker dttungay;
        private View.Core.NovLabel label3;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private View.Core.NovComboBox  cboNVThu;
        private System.Windows.Forms.BindingSource traLaiHoaDonHanhThuBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.TraLaiHoaDonHanhThuTableAdapter traLaiHoaDonHanhThuTableAdapter;
        private View.Core.NovDateTimePicker dtdenngay;
        private View.Core.NovLabel label4;
    }
}