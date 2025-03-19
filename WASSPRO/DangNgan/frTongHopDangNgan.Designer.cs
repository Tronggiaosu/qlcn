namespace QLCongNo.DangNgan
{
    partial class frTongHopDangNgan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frTongHopDangNgan));
            this.getDangNganTheoNgayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.getDangNganTheoNgayTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getDangNganTheoNgayTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getBaoCaoTongHopDangNganTheoNgayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.getDangNganTheoNgayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CAPNUOC_TDCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopDangNganTheoNgayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // getDangNganTheoNgayBindingSource
            // 
            this.getDangNganTheoNgayBindingSource.DataMember = "getDangNganTheoNgay";
            this.getDangNganTheoNgayBindingSource.DataSource = this.CAPNUOC_TDCDataSet;
            // 
            // CAPNUOC_TDCDataSet
            // 
            this.CAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.CAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getDangNganTheoNgayTableAdapter
            // 
            this.getDangNganTheoNgayTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = this.getDangNganTheoNgayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPDangNgan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1179, 545);
            this.reportViewer1.TabIndex = 2;
            // 
            // getBaoCaoTongHopDangNganTheoNgayBindingSource
            // 
            this.getBaoCaoTongHopDangNganTheoNgayBindingSource.DataMember = "getBaoCaoTongHopDangNganTheoNgay";
            this.getBaoCaoTongHopDangNganTheoNgayBindingSource.DataSource = this.CAPNUOC_TDCDataSet;
            // 
            // frTongHopDangNgan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 545);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frTongHopDangNgan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TỔNG HỢP ĐĂNG NGÂN ";
            this.Load += new System.EventHandler(this.frTongHopDangNgan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getDangNganTheoNgayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CAPNUOC_TDCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopDangNganTheoNgayBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource getDangNganTheoNgayBindingSource;
        private CAPNUOC_TDCDataSet CAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getDangNganTheoNgayTableAdapter getDangNganTheoNgayTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getBaoCaoTongHopDangNganTheoNgayBindingSource;
    }
}