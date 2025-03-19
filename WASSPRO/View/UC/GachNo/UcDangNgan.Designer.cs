namespace QLCongNo.View.UC.GachNo
{
    partial class UcDangNgan
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
            this.getDangNganTheoNgayBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.toolStrip2 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnConfirm = new QLCongNo.View.Core.NovToolStripButton();
            this.quitButton = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovGroupBox();
            this.label6 = new QLCongNo.View.Core.NovLabel();
            this.dateTimePicker2 = new QLCongNo.View.Core.NovDateTimePicker();
            this.label4 = new QLCongNo.View.Core.NovLabel();
            this.dateTimePicker1 = new QLCongNo.View.Core.NovDateTimePicker();
            this.cboHTTT = new QLCongNo.View.Core.NovComboBox();
            this.label3 = new QLCongNo.View.Core.NovLabel();
            this.cboloaiHD = new QLCongNo.View.Core.NovComboBox();
            this.cboDTSD = new QLCongNo.View.Core.NovComboBox();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.cboTNV = new QLCongNo.View.Core.NovComboBox();
            this.label2 = new QLCongNo.View.Core.NovLabel();
            this.label5 = new QLCongNo.View.Core.NovLabel();
            this.panel1 = new QLCongNo.View.Core.NovPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getDangNganTheoNgayTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getDangNganTheoNgayTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.getDangNganTheoNgayBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getDangNganTheoNgayBindingSource1
            // 
            this.getDangNganTheoNgayBindingSource1.DataMember = "getDangNganTheoNgay";
            this.getDangNganTheoNgayBindingSource1.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.BorderColor = System.Drawing.Color.Empty;
            this.toolStrip2.BorderThickness = 0;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.IsMainMenu = true;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnConfirm,
            this.quitButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.MenuItemHeight = 26;
            this.toolStrip2.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip2.Size = new System.Drawing.Size(1190, 35);
            this.toolStrip2.TabIndex = 76;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(4);
            this.btnTim.Size = new System.Drawing.Size(70, 35);
            this.btnTim.Text = "Tìm";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Image = global::QLCongNo.Properties.Resources.export_file;
            this.btnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Size = new System.Drawing.Size(143, 35);
            this.btnConfirm.Text = "Xuất file data";
            // 
            // quitButton
            // 
            this.quitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Margin = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.quitButton.Name = "quitButton";
            this.quitButton.Padding = new System.Windows.Forms.Padding(4);
            this.quitButton.Size = new System.Drawing.Size(86, 35);
            this.quitButton.Text = "Thoát";
            this.quitButton.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1190, 133);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(404, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 23);
            this.label6.TabIndex = 91;
            this.label6.Text = "Đến ngày";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(404, 51);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(172, 30);
            this.dateTimePicker2.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(208, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 23);
            this.label4.TabIndex = 89;
            this.label4.Text = "Từ ngày";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(208, 51);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(172, 30);
            this.dateTimePicker1.TabIndex = 88;
            // 
            // cboHTTT
            // 
            this.cboHTTT.BackColor = System.Drawing.Color.White;
            this.cboHTTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboHTTT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHTTT.ForeColor = System.Drawing.Color.Black;
            this.cboHTTT.FormattingEnabled = true;
            this.cboHTTT.Location = new System.Drawing.Point(992, 51);
            this.cboHTTT.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboHTTT.Name = "cboHTTT";
            this.cboHTTT.Size = new System.Drawing.Size(174, 33);
            this.cboHTTT.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(992, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 86;
            this.label3.Text = "Hình thức TT";
            // 
            // cboloaiHD
            // 
            this.cboloaiHD.BackColor = System.Drawing.Color.White;
            this.cboloaiHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboloaiHD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboloaiHD.ForeColor = System.Drawing.Color.Black;
            this.cboloaiHD.FormattingEnabled = true;
            this.cboloaiHD.Location = new System.Drawing.Point(796, 51);
            this.cboloaiHD.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboloaiHD.Name = "cboloaiHD";
            this.cboloaiHD.Size = new System.Drawing.Size(172, 33);
            this.cboloaiHD.TabIndex = 85;
            // 
            // cboDTSD
            // 
            this.cboDTSD.BackColor = System.Drawing.Color.White;
            this.cboDTSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDTSD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDTSD.ForeColor = System.Drawing.Color.Black;
            this.cboDTSD.FormattingEnabled = true;
            this.cboDTSD.Location = new System.Drawing.Point(600, 51);
            this.cboDTSD.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboDTSD.Name = "cboDTSD";
            this.cboDTSD.Size = new System.Drawing.Size(172, 33);
            this.cboDTSD.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 80;
            this.label1.Text = "Thu ngân viên";
            // 
            // cboTNV
            // 
            this.cboTNV.BackColor = System.Drawing.Color.White;
            this.cboTNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTNV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTNV.ForeColor = System.Drawing.Color.Black;
            this.cboTNV.FormattingEnabled = true;
            this.cboTNV.Location = new System.Drawing.Point(12, 51);
            this.cboTNV.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboTNV.Name = "cboTNV";
            this.cboTNV.Size = new System.Drawing.Size(172, 33);
            this.cboTNV.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(600, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 23);
            this.label2.TabIndex = 81;
            this.label2.Text = "Đối tượng sử dụng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(796, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 23);
            this.label5.TabIndex = 82;
            this.label5.Text = "Loại hóa đơn";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.panel1.Location = new System.Drawing.Point(0, 168);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 591);
            this.panel1.TabIndex = 79;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSource";
            reportDataSource1.Value = this.getDangNganTheoNgayBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPDangNgan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1190, 591);
            this.reportViewer1.TabIndex = 0;
            // 
            // getDangNganTheoNgayTableAdapter
            // 
            this.getDangNganTheoNgayTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.cboHTTT, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboloaiHD, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboDTSD, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboTNV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1178, 92);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // UcDangNgan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "UcDangNgan";
            this.Size = new System.Drawing.Size(1190, 759);
            this.Load += new System.EventHandler(this.frDangNgan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getDangNganTheoNgayBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip2;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton quitButton;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovPanel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private View.Core.NovLabel label4;
        private View.Core.NovDateTimePicker dateTimePicker1;
        private View.Core.NovComboBox cboHTTT;
        private View.Core.NovLabel label3;
        private View.Core.NovComboBox cboloaiHD;
        private View.Core.NovComboBox cboDTSD;
        private View.Core.NovLabel label1;
        private View.Core.NovComboBox cboTNV;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label5;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private View.Core.NovLabel label6;
        private View.Core.NovDateTimePicker dateTimePicker2;
        private System.Windows.Forms.BindingSource getDangNganTheoNgayBindingSource1;
        private CAPNUOC_TDCDataSetTableAdapters.getDangNganTheoNgayTableAdapter getDangNganTheoNgayTableAdapter;
        private View.Core.NovToolStripButton btnConfirm;
        private System.Windows.Forms.BindingSource getDangNganTheoNgayBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}