namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    partial class UcBaoCaoTongHop
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
            this.getBaoCaoTongHopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.getDanhSachChuyenNoKDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getDSChuyenNoKhoDoiTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getDSChuyenNoKhoDoiTableAdapter();
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnThoat = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovGroupBox();
            this.chkDT = new QLCongNo.View.Core.NovCheckBox();
            this.cboDT = new QLCongNo.View.Core.NovComboBox();
            this.label6 = new QLCongNo.View.Core.NovLabel();
            this.dtpDenngay = new QLCongNo.View.Core.NovDateTimePicker();
            this.dtpTungay = new QLCongNo.View.Core.NovDateTimePicker();
            this.label4 = new QLCongNo.View.Core.NovLabel();
            this.getBaoCaoTongHopTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getBaoCaoTongHopTableAdapter();
            this.getBaoCaoTongHopTheoLoaiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.getBaoCaoChuanThuKyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getDanhSachChuyenNoKDBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopTheoLoaiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoChuanThuKyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // getBaoCaoTongHopBindingSource
            // 
            this.getBaoCaoTongHopBindingSource.DataMember = "getBaoCaoTongHop";
            this.getBaoCaoTongHopBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getDanhSachChuyenNoKDBindingSource
            // 
            this.getDanhSachChuyenNoKDBindingSource.DataMember = "getDSChuyenNoKhoDoi";
            this.getDanhSachChuyenNoKDBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // getDSChuyenNoKhoDoiTableAdapter
            // 
            this.getDSChuyenNoKhoDoiTableAdapter.ClearBeforeFill = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BorderColor = System.Drawing.Color.Empty;
            this.toolStrip1.BorderThickness = 0;
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.toolStrip1.Size = new System.Drawing.Size(1119, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(5);
            this.btnTim.Size = new System.Drawing.Size(107, 39);
            this.btnTim.Text = "Tra cứu";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(5);
            this.btnThoat.Size = new System.Drawing.Size(87, 39);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkDT);
            this.groupBox1.Controls.Add(this.cboDT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpDenngay);
            this.groupBox1.Controls.Add(this.dtpTungay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1119, 95);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkDT
            // 
            this.chkDT.AutoSize = true;
            this.chkDT.BackColor = System.Drawing.Color.Transparent;
            this.chkDT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDT.ForeColor = System.Drawing.Color.MediumBlue;
            this.chkDT.Location = new System.Drawing.Point(619, 38);
            this.chkDT.Margin = new System.Windows.Forms.Padding(4);
            this.chkDT.Name = "chkDT";
            this.chkDT.Size = new System.Drawing.Size(109, 27);
            this.chkDT.TabIndex = 4;
            this.chkDT.Text = "Đối tượng";
            this.chkDT.UseVisualStyleBackColor = true;
            // 
            // cboDT
            // 
            this.cboDT.BackColor = System.Drawing.Color.White;
            this.cboDT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDT.ForeColor = System.Drawing.Color.Black;
            this.cboDT.FormattingEnabled = true;
            this.cboDT.Location = new System.Drawing.Point(730, 35);
            this.cboDT.Margin = new System.Windows.Forms.Padding(4);
            this.cboDT.Name = "cboDT";
            this.cboDT.Size = new System.Drawing.Size(175, 33);
            this.cboDT.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(310, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Đến ngày";
            // 
            // dtpDenngay
            // 
            this.dtpDenngay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenngay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenngay.Location = new System.Drawing.Point(401, 36);
            this.dtpDenngay.Margin = new System.Windows.Forms.Padding(5);
            this.dtpDenngay.Name = "dtpDenngay";
            this.dtpDenngay.Size = new System.Drawing.Size(179, 30);
            this.dtpDenngay.TabIndex = 3;
            // 
            // dtpTungay
            // 
            this.dtpTungay.CustomFormat = "dd/MM/yyyy";
            this.dtpTungay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTungay.Location = new System.Drawing.Point(99, 36);
            this.dtpTungay.Margin = new System.Windows.Forms.Padding(5);
            this.dtpTungay.Name = "dtpTungay";
            this.dtpTungay.Size = new System.Drawing.Size(179, 30);
            this.dtpTungay.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(21, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Từ ngày";
            // 
            // getBaoCaoTongHopTableAdapter
            // 
            this.getBaoCaoTongHopTableAdapter.ClearBeforeFill = true;
            // 
            // getBaoCaoTongHopTheoLoaiBindingSource
            // 
            this.getBaoCaoTongHopTheoLoaiBindingSource.DataMember = "getBaoCaoTongHopTheoLoai";
            this.getBaoCaoTongHopTheoLoaiBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // getBaoCaoChuanThuKyBindingSource
            // 
            this.getBaoCaoChuanThuKyBindingSource.DataMember = "getBaoCaoChuanThuKy";
            this.getBaoCaoChuanThuKyBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.View.UC.ReportViewer.ReportView.RPBaoCaoTongHop.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 134);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1119, 805);
            this.reportViewer1.TabIndex = 2;
            // 
            // UcBaoCaoTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UcBaoCaoTongHop";
            this.Size = new System.Drawing.Size(1119, 939);
            this.Load += new System.EventHandler(this.frmBaoCaoTongHop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getDanhSachChuyenNoKDBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoTongHopTheoLoaiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBaoCaoChuanThuKyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnThoat;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovComboBox  cboDT;
        private View.Core.NovLabel label6;
        private View.Core.NovDateTimePicker dtpDenngay;
        private View.Core.NovDateTimePicker dtpTungay;
        private View.Core.NovLabel label4;
        private System.Windows.Forms.BindingSource getBaoCaoTongHopBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getBaoCaoTongHopTableAdapter getBaoCaoTongHopTableAdapter;
        private View.Core.NovCheckBox chkDT;
        private System.Windows.Forms.BindingSource getBaoCaoTongHopTheoLoaiBindingSource;

        private System.Windows.Forms.BindingSource getDanhSachChuyenNoKDBindingSource;
        private CAPNUOC_TDCDataSetTableAdapters.getDSChuyenNoKhoDoiTableAdapter getDSChuyenNoKhoDoiTableAdapter;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.BindingSource getBaoCaoChuanThuKyBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}