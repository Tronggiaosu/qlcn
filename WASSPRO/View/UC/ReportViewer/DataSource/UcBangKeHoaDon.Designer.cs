namespace QLCongNo.View.UC.ReportViewer.DataSource
{
    partial class UcBangKeHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnExcel = new QLCongNo.View.Core.NovToolStripButton();
            this.btn215 = new QLCongNo.View.Core.NovToolStripButton();
            this.btnThoat = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovGroupBox();
            this.cboNam = new QLCongNo.View.Core.NovComboBox();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.dataGridView1 = new QLCongNo.View.Core.NovDataGridView();
            this.danhbo = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.hoten = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.Dot = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.SoHD = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.ngayphathanh = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.tieuthu = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.tongtien0VAT = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.tienvat = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.tienBVMT = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.phiNT = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.tienthueNT = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.cboThang = new QLCongNo.View.Core.NovComboBox();
            this.novLabel1 = new QLCongNo.View.Core.NovLabel();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BorderColor = System.Drawing.Color.Empty;
            this.toolStrip1.BorderThickness = 0;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.IsMainMenu = true;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnExcel,
            this.btn215,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MenuItemHeight = 26;
            this.toolStrip1.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip1.Size = new System.Drawing.Size(1305, 39);
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
            this.btnTim.Size = new System.Drawing.Size(77, 39);
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(5);
            this.btnExcel.Size = new System.Drawing.Size(132, 39);
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btn215
            // 
            this.btn215.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn215.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btn215.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn215.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btn215.Name = "btn215";
            this.btn215.Padding = new System.Windows.Forms.Padding(5);
            this.btn215.Size = new System.Drawing.Size(231, 39);
            this.btn215.Text = "Xuất excel số hóa đơn";
            this.btn215.Click += new System.EventHandler(this.btn215_Click);
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
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cboThang);
            this.groupBox1.Controls.Add(this.novLabel1);
            this.groupBox1.Controls.Add(this.cboNam);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1305, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cboNam
            // 
            this.cboNam.BackColor = System.Drawing.Color.White;
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.ForeColor = System.Drawing.Color.Black;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(92, 26);
            this.cboNam.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(156, 33);
            this.cboNam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.danhbo,
            this.hoten,
            this.Dot,
            this.SoHD,
            this.ngayphathanh,
            this.tieuthu,
            this.tongtien0VAT,
            this.tienvat,
            this.tienBVMT,
            this.phiNT,
            this.tienthueNT});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridView1.Location = new System.Drawing.Point(0, 116);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1305, 539);
            this.dataGridView1.TabIndex = 3;
            // 
            // danhbo
            // 
            this.danhbo.DataPropertyName = "DANHBO";
            this.danhbo.HeaderText = "Danh bộ";
            this.danhbo.MinimumWidth = 6;
            this.danhbo.Name = "danhbo";
            this.danhbo.ReadOnly = true;
            this.danhbo.Width = 92;
            // 
            // hoten
            // 
            this.hoten.DataPropertyName = "hoten";
            this.hoten.HeaderText = "Tên khách hàng";
            this.hoten.MinimumWidth = 6;
            this.hoten.Name = "hoten";
            this.hoten.ReadOnly = true;
            this.hoten.Width = 142;
            // 
            // Dot
            // 
            this.Dot.DataPropertyName = "DOT_ID";
            this.Dot.HeaderText = "Đợt";
            this.Dot.MinimumWidth = 6;
            this.Dot.Name = "Dot";
            this.Dot.ReadOnly = true;
            this.Dot.Width = 65;
            // 
            // SoHD
            // 
            this.SoHD.DataPropertyName = "SO_HD";
            this.SoHD.HeaderText = "Số hóa đơn";
            this.SoHD.MinimumWidth = 6;
            this.SoHD.Name = "SoHD";
            this.SoHD.ReadOnly = true;
            this.SoHD.Width = 111;
            // 
            // ngayphathanh
            // 
            this.ngayphathanh.DataPropertyName = "NgayPhatHanh";
            this.ngayphathanh.HeaderText = "Ngày phát hành";
            this.ngayphathanh.MinimumWidth = 6;
            this.ngayphathanh.Name = "ngayphathanh";
            this.ngayphathanh.ReadOnly = true;
            this.ngayphathanh.Width = 141;
            // 
            // tieuthu
            // 
            this.tieuthu.DataPropertyName = "m3tieuthu";
            this.tieuthu.HeaderText = "M3 tiêu thụ";
            this.tieuthu.MinimumWidth = 6;
            this.tieuthu.Name = "tieuthu";
            this.tieuthu.ReadOnly = true;
            this.tieuthu.Width = 112;
            // 
            // tongtien0VAT
            // 
            this.tongtien0VAT.DataPropertyName = "tongtien0VAT";
            this.tongtien0VAT.HeaderText = "Tiền nước";
            this.tongtien0VAT.MinimumWidth = 6;
            this.tongtien0VAT.Name = "tongtien0VAT";
            this.tongtien0VAT.ReadOnly = true;
            this.tongtien0VAT.Width = 102;
            // 
            // tienvat
            // 
            this.tienvat.DataPropertyName = "tienvat";
            this.tienvat.HeaderText = "Tiền thuế";
            this.tienvat.MinimumWidth = 6;
            this.tienvat.Name = "tienvat";
            this.tienvat.ReadOnly = true;
            // 
            // tienBVMT
            // 
            this.tienBVMT.DataPropertyName = "tienBVMT";
            this.tienBVMT.HeaderText = "Phí BVMT";
            this.tienBVMT.MinimumWidth = 6;
            this.tienBVMT.Name = "tienBVMT";
            this.tienBVMT.ReadOnly = true;
            // 
            // phiNT
            // 
            this.phiNT.DataPropertyName = "PhiNT";
            this.phiNT.HeaderText = "Phí nước thải";
            this.phiNT.MinimumWidth = 6;
            this.phiNT.Name = "phiNT";
            this.phiNT.ReadOnly = true;
            this.phiNT.Width = 123;
            // 
            // tienthueNT
            // 
            this.tienthueNT.DataPropertyName = "TienThueNT";
            this.tienthueNT.HeaderText = "Thuế Phí nước thải";
            this.tienthueNT.MinimumWidth = 6;
            this.tienthueNT.Name = "tienthueNT";
            this.tienthueNT.ReadOnly = true;
            this.tienthueNT.Width = 136;
            // 
            // cboThang
            // 
            this.cboThang.BackColor = System.Drawing.Color.White;
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.ForeColor = System.Drawing.Color.Black;
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(350, 26);
            this.cboThang.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(156, 33);
            this.cboThang.TabIndex = 3;
            // 
            // novLabel1
            // 
            this.novLabel1.AutoSize = true;
            this.novLabel1.BackColor = System.Drawing.Color.Transparent;
            this.novLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novLabel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.novLabel1.Location = new System.Drawing.Point(282, 30);
            this.novLabel1.Name = "novLabel1";
            this.novLabel1.Size = new System.Drawing.Size(58, 23);
            this.novLabel1.TabIndex = 2;
            this.novLabel1.Text = "Tháng";
            // 
            // UcBangKeHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcBangKeHoaDon";
            this.Size = new System.Drawing.Size(1305, 655);
            this.Load += new System.EventHandler(this.frBangKeHoaDon_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnExcel;
        private View.Core.NovToolStripButton btnThoat;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovComboBox  cboNam;
        private View.Core.NovLabel label1;
        private View.Core.NovDataGridView dataGridView1;
        private View.Core.NovToolStripButton btn215;
        private Core.NovDataGridViewTextBoxColumn danhbo;
        private Core.NovDataGridViewTextBoxColumn hoten;
        private Core.NovDataGridViewTextBoxColumn Dot;
        private Core.NovDataGridViewTextBoxColumn SoHD;
        private Core.NovDataGridViewTextBoxColumn ngayphathanh;
        private Core.NovDataGridViewTextBoxColumn tieuthu;
        private Core.NovDataGridViewTextBoxColumn tongtien0VAT;
        private Core.NovDataGridViewTextBoxColumn tienvat;
        private Core.NovDataGridViewTextBoxColumn tienBVMT;
        private Core.NovDataGridViewTextBoxColumn phiNT;
        private Core.NovDataGridViewTextBoxColumn tienthueNT;
        private Core.NovComboBox cboThang;
        private Core.NovLabel novLabel1;
    }
}