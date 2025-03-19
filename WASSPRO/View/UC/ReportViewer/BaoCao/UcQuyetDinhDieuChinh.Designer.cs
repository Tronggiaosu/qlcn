namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    partial class UcQuyetDinhDieuChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcQuyetDinhDieuChinh));
            this.getBaoCaoPhieuDieuChinhHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getBaoCaoPhieuDieuChinhHoaDonTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getBaoCaoPhieuDieuChinhHoaDonTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoPhieuDieuChinhHoaDonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // getBaoCaoPhieuDieuChinhHoaDonBindingSource
            // 
            this.getBaoCaoPhieuDieuChinhHoaDonBindingSource.DataMember = "getBaoCaoPhieuDieuChinhHoaDon";
            this.getBaoCaoPhieuDieuChinhHoaDonBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
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
            reportDataSource1.Value = this.getBaoCaoPhieuDieuChinhHoaDonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPPhieuDieuChinhHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(752, 321);
            this.reportViewer1.TabIndex = 0;
            // 
            // getBaoCaoPhieuDieuChinhHoaDonTableAdapter
            // 
            this.getBaoCaoPhieuDieuChinhHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // frQuyetDinhDieuChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 321);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frQuyetDinhDieuChinh";
            
            this.Text = "PHIẾU ĐIỀU CHỈNH HÓA ĐƠN";
            this.Load += new System.EventHandler(this.frQuyetDinhDieuChinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoPhieuDieuChinhHoaDonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private System.Windows.Forms.BindingSource getBaoCaoPhieuDieuChinhHoaDonBindingSource;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoPhieuDieuChinhHoaDonTableAdapter getBaoCaoPhieuDieuChinhHoaDonTableAdapter;
    }
}