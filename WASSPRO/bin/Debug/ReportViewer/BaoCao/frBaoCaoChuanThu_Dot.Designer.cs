namespace QLCongNo.ReportViewer.BaoCao
{
    partial class frBaoCaoChuanThu_Dot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frBaoCaoChuanThu_Dot));
            this.getBaoCaoChuanThuDotBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.cboNam = new System.Windows.Forms.GroupBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoChuanThuDotBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.cboNam.SuspendLayout();
            this.SuspendLayout();
            // 
            // getBaoCaoChuanThuDotBindingSource
            // 
            this.getBaoCaoChuanThuDotBindingSource.DataMember = "getBaoCaoChuanThuDot";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(959, 26);
            this.toolStrip1.TabIndex = 6;
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
            // cboNam
            // 
            this.cboNam.BackColor = System.Drawing.SystemColors.Window;
            this.cboNam.Controls.Add(this.cboKy);
            this.cboNam.Controls.Add(this.cboTo);
            this.cboNam.Controls.Add(this.checkBox1);
            this.cboNam.Controls.Add(this.label1);
            this.cboNam.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.Location = new System.Drawing.Point(0, 26);
            this.cboNam.Margin = new System.Windows.Forms.Padding(4);
            this.cboNam.Name = "cboNam";
            this.cboNam.Padding = new System.Windows.Forms.Padding(4);
            this.cboNam.Size = new System.Drawing.Size(959, 112);
            this.cboNam.TabIndex = 7;
            this.cboNam.TabStop = false;
            // 
            // cboKy
            // 
            this.cboKy.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(98, 17);
            this.cboKy.Margin = new System.Windows.Forms.Padding(4);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(119, 27);
            this.cboKy.TabIndex = 3;
            // 
            // cboTo
            // 
            this.cboTo.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(98, 54);
            this.cboTo.Margin = new System.Windows.Forms.Padding(4);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(119, 27);
            this.cboTo.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(42, 56);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 23);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Tổ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSourceHDTheoDot";
            reportDataSource1.Value = this.getBaoCaoChuanThuDotBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPBaoCaoChiaTheoDot.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 138);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(959, 432);
            this.reportViewer1.TabIndex = 8;
            // 
            // frBaoCaoChuanThu_Dot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 570);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frBaoCaoChuanThu_Dot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO CHUẨN THU THEO ĐỢT";
            this.Load += new System.EventHandler(this.frBaoCaoChuanThu_Dot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoChuanThuDotBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cboNam.ResumeLayout(false);
            this.cboNam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.GroupBox cboNam;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getBaoCaoChuanThuDotBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoChuanThuDotTableAdapter getBaoCaoChuanThuDotTableAdapter;
    }
}