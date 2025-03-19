namespace QLCongNo.ReportViewer.DataSource
{
    partial class UcDSDIEUCHINHHOADON
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcDSDIEUCHINHHOADON));
            this.getDanhSachQuyetDinhDieuChinhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getDanhSachQuyetDinhDieuChinhTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getDanhSachQuyetDinhDieuChinhTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getDanhSachQuyetDinhDieuChinhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // getDanhSachQuyetDinhDieuChinhBindingSource
            // 
            this.getDanhSachQuyetDinhDieuChinhBindingSource.DataMember = "getDanhSachQuyetDinhDieuChinh";
            this.getDanhSachQuyetDinhDieuChinhBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = this.getDanhSachQuyetDinhDieuChinhBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPDanhSachHoaDonDieuChinh.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(787, 389);
            this.reportViewer1.TabIndex = 0;
            // 
            // getDanhSachQuyetDinhDieuChinhTableAdapter
            // 
            this.getDanhSachQuyetDinhDieuChinhTableAdapter.ClearBeforeFill = true;
            // 
            // DSDIEUCHINHHOADON
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 389);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DSDIEUCHINHHOADON";
            
            this.Text = "DANH SÁCH ĐIỀU CHỈNH HÓA ĐƠN";
            this.Load += new System.EventHandler(this.DSDIEUCHINHHOADON_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getDanhSachQuyetDinhDieuChinhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getDanhSachQuyetDinhDieuChinhBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getDanhSachQuyetDinhDieuChinhTableAdapter getDanhSachQuyetDinhDieuChinhTableAdapter;
    }
}