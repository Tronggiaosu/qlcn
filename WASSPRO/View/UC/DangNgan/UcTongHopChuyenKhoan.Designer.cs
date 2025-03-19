namespace QLCongNo.View.UC.DangNgan
{
    partial class UcTongHopChuyenKhoan
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
            this.getThongKeDangNganChuyenKhoanTheoNgayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.GROUPBOX1 = new QLCongNo.View.Core.NovPanel();
            this.cboDT = new QLCongNo.View.Core.NovComboBox();
            this.dateTimePicker2 = new QLCongNo.View.Core.NovDateTimePicker();
            this.dateTimePicker1 = new QLCongNo.View.Core.NovDateTimePicker();
            this.chkLoaiHD = new QLCongNo.View.Core.NovCheckBox();
            this.label2 = new QLCongNo.View.Core.NovLabel();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnThoat = new QLCongNo.View.Core.NovToolStripButton();
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
            this.GROUPBOX1.BackColor = System.Drawing.Color.Transparent;
            this.GROUPBOX1.Controls.Add(this.cboDT);
            this.GROUPBOX1.Controls.Add(this.dateTimePicker2);
            this.GROUPBOX1.Controls.Add(this.dateTimePicker1);
            this.GROUPBOX1.Controls.Add(this.chkLoaiHD);
            this.GROUPBOX1.Controls.Add(this.label2);
            this.GROUPBOX1.Controls.Add(this.label1);
            this.GROUPBOX1.Controls.Add(this.toolStrip1);
            this.GROUPBOX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GROUPBOX1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GROUPBOX1.ForeColor = System.Drawing.Color.MediumBlue;
            this.GROUPBOX1.Location = new System.Drawing.Point(0, 0);
            this.GROUPBOX1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.GROUPBOX1.Name = "GROUPBOX1";
            this.GROUPBOX1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.GROUPBOX1.Size = new System.Drawing.Size(1512, 149);
            this.GROUPBOX1.TabIndex = 0;
            // 
            // cboDT
            // 
            this.cboDT.BackColor = System.Drawing.Color.White;
            this.cboDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDT.ForeColor = System.Drawing.Color.Black;
            this.cboDT.FormattingEnabled = true;
            this.cboDT.Location = new System.Drawing.Point(586, 91);
            this.cboDT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cboDT.Name = "cboDT";
            this.cboDT.Size = new System.Drawing.Size(243, 33);
            this.cboDT.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(305, 92);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(241, 30);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(24, 92);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(243, 30);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // chkLoaiHD
            // 
            this.chkLoaiHD.AutoSize = true;
            this.chkLoaiHD.BackColor = System.Drawing.Color.Transparent;
            this.chkLoaiHD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLoaiHD.ForeColor = System.Drawing.Color.MediumBlue;
            this.chkLoaiHD.Location = new System.Drawing.Point(590, 58);
            this.chkLoaiHD.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkLoaiHD.Name = "chkLoaiHD";
            this.chkLoaiHD.Size = new System.Drawing.Size(132, 27);
            this.chkLoaiHD.TabIndex = 5;
            this.chkLoaiHD.Text = "Loại hóa đơn";
            this.chkLoaiHD.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(303, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(23, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ ngày";
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
            this.toolStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolStrip1.MenuItemHeight = 26;
            this.toolStrip1.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip1.Size = new System.Drawing.Size(1502, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QLCongNo.Properties.Resources.lay_danh_sach;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(5);
            this.btnTim.Size = new System.Drawing.Size(146, 39);
            this.btnTim.Text = "Lấy báo cáo";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(5);
            this.btnThoat.Size = new System.Drawing.Size(94, 39);
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
            this.reportViewer1.Location = new System.Drawing.Point(0, 149);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1512, 725);
            this.reportViewer1.TabIndex = 1;
            // 
            // getThongKeDangNganChuyenKhoanTheoNgayTableAdapter
            // 
            this.getThongKeDangNganChuyenKhoanTheoNgayTableAdapter.ClearBeforeFill = true;
            // 
            // UcTongHopChuyenKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.GROUPBOX1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "UcTongHopChuyenKhoan";
            this.Size = new System.Drawing.Size(1512, 874);
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

        private View.Core.NovPanel GROUPBOX1;
        private View.Core.NovComboBox cboDT;
        private View.Core.NovDateTimePicker dateTimePicker2;
        private View.Core.NovDateTimePicker dateTimePicker1;
        private View.Core.NovCheckBox chkLoaiHD;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label1;
        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnThoat;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getThongKeDangNganChuyenKhoanTheoNgayBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getThongKeDangNganChuyenKhoanTheoNgayTableAdapter getThongKeDangNganChuyenKhoanTheoNgayTableAdapter;

    }
}