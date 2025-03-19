namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    partial class UcBaoCaoChuanThu_Dot
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
            this.getBaoCaoChuanThuDotBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnThoat = new QLCongNo.View.Core.NovToolStripButton();
            this.cboNam = new QLCongNo.View.Core.NovGroupBox();
            this.cboThang = new QLCongNo.View.Core.NovComboBox();
            this.cboTo = new QLCongNo.View.Core.NovComboBox();
            this.checkBox1 = new QLCongNo.View.Core.NovCheckBox();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBoxNam = new QLCongNo.View.Core.NovComboBox();
            this.novLabel1 = new QLCongNo.View.Core.NovLabel();
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
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BorderColor = System.Drawing.Color.Empty;
            this.toolStrip1.BorderThickness = 0;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.toolStrip1.Size = new System.Drawing.Size(959, 39);
            this.toolStrip1.TabIndex = 6;
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
            // cboNam
            // 
            this.cboNam.BackColor = System.Drawing.Color.Transparent;
            this.cboNam.Controls.Add(this.comboBoxNam);
            this.cboNam.Controls.Add(this.novLabel1);
            this.cboNam.Controls.Add(this.cboThang);
            this.cboNam.Controls.Add(this.cboTo);
            this.cboNam.Controls.Add(this.checkBox1);
            this.cboNam.Controls.Add(this.label1);
            this.cboNam.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.ForeColor = System.Drawing.Color.MediumBlue;
            this.cboNam.Location = new System.Drawing.Point(0, 39);
            this.cboNam.Margin = new System.Windows.Forms.Padding(4);
            this.cboNam.Name = "cboNam";
            this.cboNam.Padding = new System.Windows.Forms.Padding(4);
            this.cboNam.Size = new System.Drawing.Size(959, 81);
            this.cboNam.TabIndex = 7;
            this.cboNam.TabStop = false;
            // 
            // cboThang
            // 
            this.cboThang.BackColor = System.Drawing.Color.White;
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.ForeColor = System.Drawing.Color.Black;
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(339, 28);
            this.cboThang.Margin = new System.Windows.Forms.Padding(4);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(144, 33);
            this.cboThang.TabIndex = 3;
            // 
            // cboTo
            // 
            this.cboTo.BackColor = System.Drawing.Color.White;
            this.cboTo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTo.ForeColor = System.Drawing.Color.Black;
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(590, 29);
            this.cboTo.Margin = new System.Windows.Forms.Padding(4);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(144, 33);
            this.cboTo.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.checkBox1.Location = new System.Drawing.Point(533, 31);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 27);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Tổ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(268, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
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
            this.reportViewer1.Location = new System.Drawing.Point(0, 120);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(959, 450);
            this.reportViewer1.TabIndex = 8;
            // 
            // comboBoxNam
            // 
            this.comboBoxNam.BackColor = System.Drawing.Color.White;
            this.comboBoxNam.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNam.ForeColor = System.Drawing.Color.Black;
            this.comboBoxNam.FormattingEnabled = true;
            this.comboBoxNam.Location = new System.Drawing.Point(83, 27);
            this.comboBoxNam.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNam.Name = "comboBoxNam";
            this.comboBoxNam.Size = new System.Drawing.Size(144, 33);
            this.comboBoxNam.TabIndex = 5;
            // 
            // novLabel1
            // 
            this.novLabel1.AutoSize = true;
            this.novLabel1.BackColor = System.Drawing.Color.Transparent;
            this.novLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novLabel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.novLabel1.Location = new System.Drawing.Point(19, 30);
            this.novLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.novLabel1.Name = "novLabel1";
            this.novLabel1.Size = new System.Drawing.Size(47, 23);
            this.novLabel1.TabIndex = 4;
            this.novLabel1.Text = "Năm";
            // 
            // UcBaoCaoChuanThu_Dot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcBaoCaoChuanThu_Dot";
            this.Size = new System.Drawing.Size(959, 570);
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

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnThoat;
        private View.Core.NovGroupBox cboNam;
        private View.Core.NovComboBox  cboThang;
        private View.Core.NovComboBox  cboTo;
        private View.Core.NovCheckBox checkBox1;
        private View.Core.NovLabel label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getBaoCaoChuanThuDotBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoChuanThuDotTableAdapter getBaoCaoChuanThuDotTableAdapter;
        private Core.NovComboBox comboBoxNam;
        private Core.NovLabel novLabel1;
    }
}