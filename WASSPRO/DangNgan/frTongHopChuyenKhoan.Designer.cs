namespace QLCongNo.DangNgan
{
    partial class frTongHopChuyenKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frTongHopChuyenKhoan));
            this.getThongKeDangNganChuyenKhoanTheoNgayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.GROUPBOX1 = new System.Windows.Forms.GroupBox();
            this.cboDT = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.chkLoaiHD = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getThongKeDangNganChuyenKhoanTheoNgayTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getThongKeDangNganChuyenKhoanTheoNgayTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getThongKeDangNganChuyenKhoanTheoNgayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.GROUPBOX1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getThongKeDangNganChuyenKhoanTheoNgayBindingSource
            // 
            this.getThongKeDangNganChuyenKhoanTheoNgayBindingSource.DataMember = "getThongKeDangNganChuyenKhoanTheoNgay";
            this.getThongKeDangNganChuyenKhoanTheoNgayBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GROUPBOX1
            // 
            this.GROUPBOX1.BackColor = System.Drawing.SystemColors.Window;
            this.GROUPBOX1.Controls.Add(this.cboDT);
            this.GROUPBOX1.Controls.Add(this.dateTimePicker2);
            this.GROUPBOX1.Controls.Add(this.dateTimePicker1);
            this.GROUPBOX1.Controls.Add(this.chkLoaiHD);
            this.GROUPBOX1.Controls.Add(this.label2);
            this.GROUPBOX1.Controls.Add(this.label1);
            this.GROUPBOX1.Controls.Add(this.toolStrip1);
            this.GROUPBOX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GROUPBOX1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GROUPBOX1.Location = new System.Drawing.Point(0, 0);
            this.GROUPBOX1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.GROUPBOX1.Name = "GROUPBOX1";
            this.GROUPBOX1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.GROUPBOX1.Size = new System.Drawing.Size(1512, 184);
            this.GROUPBOX1.TabIndex = 1;
            this.GROUPBOX1.TabStop = false;
            // 
            // cboDT
            // 
            this.cboDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDT.FormattingEnabled = true;
            this.cboDT.Location = new System.Drawing.Point(656, 69);
            this.cboDT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cboDT.Name = "cboDT";
            this.cboDT.Size = new System.Drawing.Size(243, 27);
            this.cboDT.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(273, 105);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(241, 26);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(273, 69);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(243, 26);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // chkLoaiHD
            // 
            this.chkLoaiHD.AutoSize = true;
            this.chkLoaiHD.Location = new System.Drawing.Point(562, 71);
            this.chkLoaiHD.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkLoaiHD.Name = "chkLoaiHD";
            this.chkLoaiHD.Size = new System.Drawing.Size(84, 23);
            this.chkLoaiHD.TabIndex = 3;
            this.chkLoaiHD.Text = "Loại HĐ";
            this.chkLoaiHD.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ ngày";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(5, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1502, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.lay_danh_sach;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(112, 23);
            this.btnTim.Text = "Lấy báo cáo";
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(69, 23);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = this.getThongKeDangNganChuyenKhoanTheoNgayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPPhieuDangNganChuyenKhoan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 184);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1512, 538);
            this.reportViewer1.TabIndex = 2;
            // 
            // getThongKeDangNganChuyenKhoanTheoNgayTableAdapter
            // 
            this.getThongKeDangNganChuyenKhoanTheoNgayTableAdapter.ClearBeforeFill = true;
            // 
            // frTongHopChuyenKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 722);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.GROUPBOX1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frTongHopChuyenKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHIẾU ĐĂNG NGÂN CHUYỂN KHOẢN";
            this.Load += new System.EventHandler(this.frTongHopChuyenKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getThongKeDangNganChuyenKhoanTheoNgayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.GROUPBOX1.ResumeLayout(false);
            this.GROUPBOX1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GROUPBOX1;
        private System.Windows.Forms.ComboBox cboDT;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox chkLoaiHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getThongKeDangNganChuyenKhoanTheoNgayBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getThongKeDangNganChuyenKhoanTheoNgayTableAdapter getThongKeDangNganChuyenKhoanTheoNgayTableAdapter;

    }
}