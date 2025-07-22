namespace QLCongNo.ReportViewer.DataSource
{
    partial class frBangKeHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frBangKeHoaDon));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btn215 = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.danhbo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayphathanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tieuthu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien0VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienvat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phiNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienthueNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnExcel,
            this.btn215,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1101, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(49, 22);
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(86, 22);
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btn215
            // 
            this.btn215.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btn215.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn215.Name = "btn215";
            this.btn215.Size = new System.Drawing.Size(153, 22);
            this.btn215.Text = "Xuất excel số hóa đơn";
            this.btn215.Click += new System.EventHandler(this.btn215_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(60, 22);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboKy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1101, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cboKy
            // 
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(117, 35);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(182, 24);
            this.cboKy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kỳ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1101, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1101, 391);
            this.dataGridView1.TabIndex = 3;
            // 
            // danhbo
            // 
            this.danhbo.DataPropertyName = "DANHBO";
            this.danhbo.HeaderText = "Danh bộ";
            this.danhbo.Name = "danhbo";
            // 
            // hoten
            // 
            this.hoten.DataPropertyName = "hoten";
            this.hoten.HeaderText = "Tên khách hàng";
            this.hoten.Name = "hoten";
            // 
            // Dot
            // 
            this.Dot.DataPropertyName = "DOT_ID";
            this.Dot.HeaderText = "Đợt";
            this.Dot.Name = "Dot";
            // 
            // SoHD
            // 
            this.SoHD.DataPropertyName = "SO_HD";
            this.SoHD.HeaderText = "Số hóa đơn";
            this.SoHD.Name = "SoHD";
            // 
            // ngayphathanh
            // 
            this.ngayphathanh.DataPropertyName = "NgayPhatHanh";
            this.ngayphathanh.HeaderText = "Ngày phát hành";
            this.ngayphathanh.Name = "ngayphathanh";
            // 
            // tieuthu
            // 
            this.tieuthu.DataPropertyName = "m3tieuthu";
            this.tieuthu.HeaderText = "M3 tiêu thụ";
            this.tieuthu.Name = "tieuthu";
            // 
            // tongtien0VAT
            // 
            this.tongtien0VAT.DataPropertyName = "tongtien0VAT";
            this.tongtien0VAT.HeaderText = "Tiền nước";
            this.tongtien0VAT.Name = "tongtien0VAT";
            // 
            // tienvat
            // 
            this.tienvat.DataPropertyName = "tienvat";
            this.tienvat.HeaderText = "Tiền thuế";
            this.tienvat.Name = "tienvat";
            // 
            // tienBVMT
            // 
            this.tienBVMT.DataPropertyName = "tienBVMT";
            this.tienBVMT.HeaderText = "Phí BVMT";
            this.tienBVMT.Name = "tienBVMT";
            // 
            // phiNT
            // 
            this.phiNT.DataPropertyName = "PhiNT";
            this.phiNT.HeaderText = "Phí nước thải";
            this.phiNT.Name = "phiNT";
            // 
            // tienthueNT
            // 
            this.tienthueNT.DataPropertyName = "TienThueNT";
            this.tienthueNT.HeaderText = "Thuế Phí nước thải";
            this.tienthueNT.Name = "tienthueNT";
            // 
            // frBangKeHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 538);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frBangKeHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng kê hóa đơn";
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

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhbo;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayphathanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tieuthu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien0VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienvat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn phiNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienthueNT;
        private System.Windows.Forms.ToolStripButton btn215;
    }
}