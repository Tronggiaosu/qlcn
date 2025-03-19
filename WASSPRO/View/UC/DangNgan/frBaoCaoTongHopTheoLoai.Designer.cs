namespace QLCongNo.View.UC.DangNgan
{
    partial class UcBaoCaoTongHopTheoLoai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcBaoCaoTongHopTheoLoai));
            this.getBaoCaoTongHopTheoLoaiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.GROUPBOX1 = new View.Core.NovPanel();
            this.cboDT = new View.Core.NovComboBox();
            this.dateTimePicker2 = new View.Core.NovDateTimePicker();
            this.dateTimePicker1 = new View.Core.NovDateTimePicker();
            this.chkLoaiHD = new View.Core.NovCheckBox();
            this.label2 = new View.Core.NovLabel();
            this.label1 = new View.Core.NovLabel();
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.btnTim = new View.Core.NovToolStripButton();
            this.btnThoat = new View.Core.NovToolStripButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getBaoCaoTongHopTheoLoaiTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getBaoCaoTongHopTheoLoaiTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopTheoLoaiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.GROUPBOX1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getBaoCaoTongHopTheoLoaiBindingSource
            // 
            this.getBaoCaoTongHopTheoLoaiBindingSource.DataMember = "getBaoCaoTongHopTheoLoai";
            this.getBaoCaoTongHopTheoLoaiBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GROUPBOX1
            // 
            this.GROUPBOX1.Controls.Add(this.cboDT);
            this.GROUPBOX1.Controls.Add(this.dateTimePicker2);
            this.GROUPBOX1.Controls.Add(this.dateTimePicker1);
            this.GROUPBOX1.Controls.Add(this.chkLoaiHD);
            this.GROUPBOX1.Controls.Add(this.label2);
            this.GROUPBOX1.Controls.Add(this.label1);
            this.GROUPBOX1.Controls.Add(this.toolStrip1);
            this.GROUPBOX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GROUPBOX1.Location = new System.Drawing.Point(0, 0);
            this.GROUPBOX1.Name = "GROUPBOX1";
            this.GROUPBOX1.Size = new System.Drawing.Size(882, 122);
            this.GROUPBOX1.TabIndex = 0;
            this.GROUPBOX1.TabStop = false;
            // 
            // cboDT
            // 
            this.cboDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDT.FormattingEnabled = true;
            this.cboDT.Location = new System.Drawing.Point(159, 75);
            this.cboDT.Name = "cboDT";
            this.cboDT.Size = new System.Drawing.Size(143, 24);
            this.cboDT.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(401, 46);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(142, 23);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(159, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(143, 23);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // chkLoaiHD
            // 
            this.chkLoaiHD.AutoSize = true;
            this.chkLoaiHD.Location = new System.Drawing.Point(88, 79);
            this.chkLoaiHD.Name = "chkLoaiHD";
            this.chkLoaiHD.Size = new System.Drawing.Size(70, 20);
            this.chkLoaiHD.TabIndex = 3;
            this.chkLoaiHD.Text = "Loại HĐ";
            this.chkLoaiHD.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ ngày";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(3, 19);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(876, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.lay_danh_sach;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 22);
            this.btnTim.Text = "Lấy báo cáo";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(57, 22);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = this.getBaoCaoTongHopTheoLoaiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPBaoCaoTongHopTheoLoai.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 122);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(882, 326);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // getBaoCaoTongHopTheoLoaiTableAdapter
            // 
            this.getBaoCaoTongHopTheoLoaiTableAdapter.ClearBeforeFill = true;
            // 
            // frBaoCaoTongHopTheoLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 448);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.GROUPBOX1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frBaoCaoTongHopTheoLoai";
            this.Text = "BÁO CÁO TỔNG HỌP THEO HÌNH THỨC THANH TOÁN";
            this.Load += new System.EventHandler(this.frBaoCaoTongHopTheoLoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopTheoLoaiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.GROUPBOX1.ResumeLayout(false);
            this.GROUPBOX1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private View.Core.NovPanel GROUPBOX1;
        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnThoat;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private View.Core.NovCheckBox chkLoaiHD;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label1;
        private View.Core.NovDateTimePicker dateTimePicker2;
        private View.Core.NovDateTimePicker dateTimePicker1;
        private View.Core.NovComboBox cboDT;
        private System.Windows.Forms.BindingSource getBaoCaoTongHopTheoLoaiBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoTongHopTheoLoaiTableAdapter getBaoCaoTongHopTheoLoaiTableAdapter;
    }
}