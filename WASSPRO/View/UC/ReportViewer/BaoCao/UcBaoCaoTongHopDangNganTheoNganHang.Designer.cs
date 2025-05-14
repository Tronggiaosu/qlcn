namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    partial class UcBaoCaoTongHopDangNganTheoNganHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnThoat = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovGroupBox();
            this.novLabel3 = new QLCongNo.View.Core.NovLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.novLabel2 = new QLCongNo.View.Core.NovLabel();
            this.dtPickerTu = new QLCongNo.View.Core.NovDateTimePicker();
            this.novLabel1 = new QLCongNo.View.Core.NovLabel();
            this.dtPickerDen = new QLCongNo.View.Core.NovDateTimePicker();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.iconDropDownButton1 = new FontAwesome.Sharp.IconDropDownButton();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1473, 39);
            this.toolStrip1.TabIndex = 1;
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
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
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
            this.groupBox1.Controls.Add(this.novLabel3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.novLabel2);
            this.groupBox1.Controls.Add(this.dtPickerTu);
            this.groupBox1.Controls.Add(this.novLabel1);
            this.groupBox1.Controls.Add(this.dtPickerDen);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.groupBox1.Size = new System.Drawing.Size(1473, 102);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // novLabel3
            // 
            this.novLabel3.AutoSize = true;
            this.novLabel3.BackColor = System.Drawing.Color.Transparent;
            this.novLabel3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novLabel3.ForeColor = System.Drawing.Color.MediumBlue;
            this.novLabel3.Location = new System.Drawing.Point(563, 42);
            this.novLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.novLabel3.Name = "novLabel3";
            this.novLabel3.Size = new System.Drawing.Size(80, 23);
            this.novLabel3.TabIndex = 7;
            this.novLabel3.Text = "Lọc theo:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(647, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 31);
            this.comboBox1.TabIndex = 6;
            // 
            // novLabel2
            // 
            this.novLabel2.AutoSize = true;
            this.novLabel2.BackColor = System.Drawing.Color.Transparent;
            this.novLabel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novLabel2.ForeColor = System.Drawing.Color.MediumBlue;
            this.novLabel2.Location = new System.Drawing.Point(283, 42);
            this.novLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.novLabel2.Name = "novLabel2";
            this.novLabel2.Size = new System.Drawing.Size(87, 23);
            this.novLabel2.TabIndex = 5;
            this.novLabel2.Text = "Đến ngày:";
            // 
            // dtPickerTu
            // 
            this.dtPickerTu.CustomFormat = "dd/MM/yyyy";
            this.dtPickerTu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerTu.Location = new System.Drawing.Point(120, 39);
            this.dtPickerTu.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.dtPickerTu.Name = "dtPickerTu";
            this.dtPickerTu.Size = new System.Drawing.Size(144, 30);
            this.dtPickerTu.TabIndex = 2;
            // 
            // novLabel1
            // 
            this.novLabel1.AutoSize = true;
            this.novLabel1.BackColor = System.Drawing.Color.Transparent;
            this.novLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novLabel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.novLabel1.Location = new System.Drawing.Point(36, 42);
            this.novLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.novLabel1.Name = "novLabel1";
            this.novLabel1.Size = new System.Drawing.Size(75, 23);
            this.novLabel1.TabIndex = 4;
            this.novLabel1.Text = "Từ ngày:";
            // 
            // dtPickerDen
            // 
            this.dtPickerDen.CustomFormat = "dd/MM/yyyy";
            this.dtPickerDen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerDen.Location = new System.Drawing.Point(377, 39);
            this.dtPickerDen.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.dtPickerDen.Name = "dtPickerDen";
            this.dtPickerDen.Size = new System.Drawing.Size(144, 30);
            this.dtPickerDen.TabIndex = 3;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.DocumentMapWidth = 59;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = null;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPTongHopDangNganTheoNgay.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 141);
            this.reportViewer2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1473, 624);
            this.reportViewer2.TabIndex = 3;
            // 
            // iconDropDownButton1
            // 
            this.iconDropDownButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconDropDownButton1.IconColor = System.Drawing.Color.Black;
            this.iconDropDownButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDropDownButton1.Name = "iconDropDownButton1";
            this.iconDropDownButton1.Size = new System.Drawing.Size(23, 23);
            this.iconDropDownButton1.Text = "iconDropDownButton1";
            // 
            // UcBaoCaoTongHopDangNganTheoNganHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UcBaoCaoTongHopDangNganTheoNganHang";
            this.Size = new System.Drawing.Size(1473, 765);
            this.Load += new System.EventHandler(this.UcBaoCaoTongHopDangNganTheoNganHang_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Core.NovToolStrip toolStrip1;
        private Core.NovToolStripButton btnTim;
        private Core.NovToolStripButton btnThoat;
        private Core.NovGroupBox groupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private FontAwesome.Sharp.IconDropDownButton iconDropDownButton1;
        private Core.NovLabel novLabel2;
        private Core.NovDateTimePicker dtPickerTu;
        private Core.NovLabel novLabel1;
        private Core.NovDateTimePicker dtPickerDen;
        private System.Windows.Forms.ComboBox comboBox1;
        private Core.NovLabel novLabel3;
    }
}
