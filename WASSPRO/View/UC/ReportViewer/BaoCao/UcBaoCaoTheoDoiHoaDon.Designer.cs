namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    partial class UcBaoCaoTheoDoiHoaDon
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
            this.getBaoCaoTheoDoiHoaDonTheoToBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnThoat = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovGroupBox();
            this.cboTo = new QLCongNo.View.Core.NovComboBox();
            this.chkTo = new QLCongNo.View.Core.NovCheckBox();
            this.dateTimePicker1 = new QLCongNo.View.Core.NovDateTimePicker();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTheoDoiHoaDonTheoToBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getBaoCaoTheoDoiHoaDonTheoToBindingSource
            // 
            this.getBaoCaoTheoDoiHoaDonTheoToBindingSource.DataMember = "getBaoCaoTheoDoiHoaDonTheoTo";
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
            this.toolStrip1.Size = new System.Drawing.Size(1050, 39);
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
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.cboTo);
            this.groupBox1.Controls.Add(this.chkTo);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1050, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cboTo
            // 
            this.cboTo.BackColor = System.Drawing.Color.White;
            this.cboTo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTo.ForeColor = System.Drawing.Color.Black;
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(404, 28);
            this.cboTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(197, 33);
            this.cboTo.TabIndex = 3;
            // 
            // chkTo
            // 
            this.chkTo.AutoSize = true;
            this.chkTo.BackColor = System.Drawing.Color.Transparent;
            this.chkTo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTo.ForeColor = System.Drawing.Color.MediumBlue;
            this.chkTo.Location = new System.Drawing.Point(344, 32);
            this.chkTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkTo.Name = "chkTo";
            this.chkTo.Size = new System.Drawing.Size(51, 27);
            this.chkTo.TabIndex = 2;
            this.chkTo.Text = "Tổ";
            this.chkTo.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 29);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 30);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = this.getBaoCaoTheoDoiHoaDonTheoToBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPTheoDoiHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 124);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1050, 459);
            this.reportViewer1.TabIndex = 2;
            // 
            // UcBaoCaoTheoDoiHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UcBaoCaoTheoDoiHoaDon";
            this.Size = new System.Drawing.Size(1050, 583);
            this.Load += new System.EventHandler(this.frBaoCaoTheoDoiHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTheoDoiHoaDonTheoToBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovGroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private View.Core.NovToolStripButton btnTim;
        private System.Windows.Forms.BindingSource getBaoCaoTheoDoiHoaDonTheoToBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoTheoDoiHoaDonTheoToTableAdapter getBaoCaoTheoDoiHoaDonTheoToTableAdapter;
        private View.Core.NovComboBox  cboTo;
        private View.Core.NovCheckBox chkTo;
        private View.Core.NovDateTimePicker dateTimePicker1;
        private View.Core.NovLabel label1;
        private View.Core.NovToolStripButton btnThoat;
    }
}