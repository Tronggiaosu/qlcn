namespace QLCongNo.View.UC.GachNo
{
    partial class UcDangNganBilling
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.getDangNganBillingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.toolStrip2 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.quitButton = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovGroupBox();
            this.label3 = new QLCongNo.View.Core.NovLabel();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.cboDT = new QLCongNo.View.Core.NovComboBox();
            this.cboKSV = new QLCongNo.View.Core.NovComboBox();
            this.label4 = new QLCongNo.View.Core.NovLabel();
            this.dateTimePicker1 = new QLCongNo.View.Core.NovDateTimePicker();
            this.cboloaiHD = new QLCongNo.View.Core.NovComboBox();
            this.cboDTSD = new QLCongNo.View.Core.NovComboBox();
            this.label2 = new QLCongNo.View.Core.NovLabel();
            this.label5 = new QLCongNo.View.Core.NovLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getDangNganBillingTableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getDangNganBillingTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.getDangNganBillingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // getDangNganBillingBindingSource
            // 
            this.getDangNganBillingBindingSource.DataMember = "getDangNganBilling";
            this.getDangNganBillingBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Menu;
            this.toolStrip2.BorderColor = System.Drawing.Color.Empty;
            this.toolStrip2.BorderThickness = 0;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.IsMainMenu = true;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.quitButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.MenuItemHeight = 26;
            this.toolStrip2.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip2.Size = new System.Drawing.Size(1161, 35);
            this.toolStrip2.TabIndex = 77;
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
            this.btnTim.Size = new System.Drawing.Size(111, 35);
            this.btnTim.Text = "Tìm kiếm";
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
            this.groupBox1.Size = new System.Drawing.Size(1161, 127);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 23);
            this.label3.TabIndex = 93;
            this.label3.Text = "Đội trưởng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(241, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 92;
            this.label1.Text = "Kiểm soát viên";
            // 
            // cboDT
            // 
            this.cboDT.BackColor = System.Drawing.Color.White;
            this.cboDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDT.ForeColor = System.Drawing.Color.Black;
            this.cboDT.FormattingEnabled = true;
            this.cboDT.Location = new System.Drawing.Point(12, 55);
            this.cboDT.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboDT.Name = "cboDT";
            this.cboDT.Size = new System.Drawing.Size(205, 33);
            this.cboDT.TabIndex = 91;
            // 
            // cboKSV
            // 
            this.cboKSV.BackColor = System.Drawing.Color.White;
            this.cboKSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKSV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKSV.ForeColor = System.Drawing.Color.Black;
            this.cboKSV.FormattingEnabled = true;
            this.cboKSV.Location = new System.Drawing.Point(241, 55);
            this.cboKSV.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboKSV.Name = "cboKSV";
            this.cboKSV.Size = new System.Drawing.Size(205, 33);
            this.cboKSV.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(470, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 89;
            this.label4.Text = "Ngày trả";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(470, 55);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(205, 30);
            this.dateTimePicker1.TabIndex = 88;
            // 
            // cboloaiHD
            // 
            this.cboloaiHD.BackColor = System.Drawing.Color.White;
            this.cboloaiHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboloaiHD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboloaiHD.ForeColor = System.Drawing.Color.Black;
            this.cboloaiHD.FormattingEnabled = true;
            this.cboloaiHD.Location = new System.Drawing.Point(928, 55);
            this.cboloaiHD.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboloaiHD.Name = "cboloaiHD";
            this.cboloaiHD.Size = new System.Drawing.Size(209, 33);
            this.cboloaiHD.TabIndex = 85;
            // 
            // cboDTSD
            // 
            this.cboDTSD.BackColor = System.Drawing.Color.White;
            this.cboDTSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDTSD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDTSD.ForeColor = System.Drawing.Color.Black;
            this.cboDTSD.FormattingEnabled = true;
            this.cboDTSD.Location = new System.Drawing.Point(699, 55);
            this.cboDTSD.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboDTSD.Name = "cboDTSD";
            this.cboDTSD.Size = new System.Drawing.Size(205, 33);
            this.cboDTSD.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(699, 14);
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
            this.label5.Location = new System.Drawing.Point(928, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 23);
            this.label5.TabIndex = 82;
            this.label5.Text = "Loại hóa đơn";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSource";
            reportDataSource3.Value = this.getDangNganBillingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLCongNo.ReportViewer.ReportView.RPTongHopDangNgan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 162);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1161, 458);
            this.reportViewer1.TabIndex = 79;
            // 
            // getDangNganBillingTableAdapter
            // 
            this.getDangNganBillingTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboloaiHD, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboDTSD, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboKSV, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboDT, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1149, 100);
            this.tableLayoutPanel1.TabIndex = 80;
            // 
            // UcDangNganBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "UcDangNganBilling";
            this.Size = new System.Drawing.Size(1161, 620);
            this.Load += new System.EventHandler(this.frDangNganBilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getDangNganBillingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private View.Core.NovLabel label4;
        private View.Core.NovDateTimePicker dateTimePicker1;
        private View.Core.NovComboBox cboloaiHD;
        private View.Core.NovComboBox cboDTSD;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label5;
        private View.Core.NovLabel label3;
        private View.Core.NovLabel label1;
        private View.Core.NovComboBox cboDT;
        private View.Core.NovComboBox cboKSV;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getDangNganBillingBindingSource;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private CAPNUOC_TDCDataSetTableAdapters.getDangNganBillingTableAdapter getDangNganBillingTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}