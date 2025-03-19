namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    partial class UcBaoCaoTongHopDangNganTheoNgay
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
            this.getBaoCaoTongHopDangNganTheoNgayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnThoat = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovGroupBox();
            this.cboLoaiHD = new QLCongNo.View.Core.NovComboBox();
            this.chkLoaiHD = new QLCongNo.View.Core.NovCheckBox();
            this.cboTo = new QLCongNo.View.Core.NovComboBox();
            this.chkTo = new QLCongNo.View.Core.NovCheckBox();
            this.dateTimePicker2 = new QLCongNo.View.Core.NovDateTimePicker();
            this.label3 = new QLCongNo.View.Core.NovLabel();
            this.dateTimePicker1 = new QLCongNo.View.Core.NovDateTimePicker();
            this.label2 = new QLCongNo.View.Core.NovLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getBaoCaoTongHopDangNganTheoNgayTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getBaoCaoTongHopDangNganTheoNgayTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopDangNganTheoNgayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getBaoCaoTongHopDangNganTheoNgayBindingSource
            // 
            this.getBaoCaoTongHopDangNganTheoNgayBindingSource.DataMember = "getBaoCaoTongHopDangNganTheoNgay";
            this.getBaoCaoTongHopDangNganTheoNgayBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BorderColor = System.Drawing.Color.Empty;
            this.toolStrip1.BorderThickness = 0;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.IsMainMenu = true;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MenuItemHeight = 26;
            this.toolStrip1.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip1.Size = new System.Drawing.Size(1336, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Margin = new System.Windows.Forms.Padding(20, 0, 5, 0);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(5);
            this.btnTim.Size = new System.Drawing.Size(107, 39);
            this.btnTim.Text = "Tra cứu";
            this.btnTim.ToolTipText = "Tra cứu";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(5);
            this.btnThoat.Size = new System.Drawing.Size(94, 39);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cboLoaiHD);
            this.groupBox1.Controls.Add(this.chkLoaiHD);
            this.groupBox1.Controls.Add(this.cboTo);
            this.groupBox1.Controls.Add(this.chkTo);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1336, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cboLoaiHD
            // 
            this.cboLoaiHD.BackColor = System.Drawing.Color.White;
            this.cboLoaiHD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiHD.ForeColor = System.Drawing.Color.Black;
            this.cboLoaiHD.FormattingEnabled = true;
            this.cboLoaiHD.Location = new System.Drawing.Point(1106, 27);
            this.cboLoaiHD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLoaiHD.Name = "cboLoaiHD";
            this.cboLoaiHD.Size = new System.Drawing.Size(184, 33);
            this.cboLoaiHD.TabIndex = 7;
            // 
            // chkLoaiHD
            // 
            this.chkLoaiHD.AutoSize = true;
            this.chkLoaiHD.BackColor = System.Drawing.Color.Transparent;
            this.chkLoaiHD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLoaiHD.ForeColor = System.Drawing.Color.MediumBlue;
            this.chkLoaiHD.Location = new System.Drawing.Point(961, 30);
            this.chkLoaiHD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoaiHD.Name = "chkLoaiHD";
            this.chkLoaiHD.Size = new System.Drawing.Size(132, 27);
            this.chkLoaiHD.TabIndex = 6;
            this.chkLoaiHD.Text = "Loại hóa đơn";
            this.chkLoaiHD.UseVisualStyleBackColor = true;
            // 
            // cboTo
            // 
            this.cboTo.BackColor = System.Drawing.Color.White;
            this.cboTo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTo.ForeColor = System.Drawing.Color.Black;
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(731, 27);
            this.cboTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(184, 33);
            this.cboTo.TabIndex = 5;
            // 
            // chkTo
            // 
            this.chkTo.AutoSize = true;
            this.chkTo.BackColor = System.Drawing.Color.Transparent;
            this.chkTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTo.ForeColor = System.Drawing.Color.MediumBlue;
            this.chkTo.Location = new System.Drawing.Point(668, 30);
            this.chkTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTo.Name = "chkTo";
            this.chkTo.Size = new System.Drawing.Size(51, 27);
            this.chkTo.TabIndex = 4;
            this.chkTo.Text = "Tổ";
            this.chkTo.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(427, 28);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(197, 30);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(330, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(102, 28);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 30);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(20, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ ngày";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSource";
            reportDataSource3.Value = this.getBaoCaoTongHopDangNganTheoNgayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPTongHopDangNganTheoNgay.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 124);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1336, 456);
            this.reportViewer1.TabIndex = 2;
            // 
            // getBaoCaoTongHopDangNganTheoNgayTableAdapter
            // 
            this.getBaoCaoTongHopDangNganTheoNgayTableAdapter.ClearBeforeFill = true;
            // 
            // UcBaoCaoTongHopDangNganTheoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UcBaoCaoTongHopDangNganTheoNgay";
            this.Size = new System.Drawing.Size(1336, 580);
            this.Load += new System.EventHandler(this.frBaoCaoTongHopDangNganTheoNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopDangNganTheoNgayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnThoat;
        private View.Core.NovGroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private View.Core.NovComboBox  cboTo;
        private View.Core.NovCheckBox chkTo;
        private View.Core.NovDateTimePicker dateTimePicker2;
        private View.Core.NovLabel label3;
        private View.Core.NovDateTimePicker dateTimePicker1;
        private View.Core.NovLabel label2;
        private View.Core.NovComboBox  cboLoaiHD;
        private View.Core.NovCheckBox chkLoaiHD;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private System.Windows.Forms.BindingSource getBaoCaoTongHopDangNganTheoNgayBindingSource;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoTongHopDangNganTheoNgayTableAdapter getBaoCaoTongHopDangNganTheoNgayTableAdapter;
    }
}