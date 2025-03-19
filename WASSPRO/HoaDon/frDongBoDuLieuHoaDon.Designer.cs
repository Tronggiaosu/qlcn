namespace QLCongNo.HoaDon
{
    partial class frDongBoDuLieuHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnDongBo = new System.Windows.Forms.ToolStripButton();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbltongsokyno = new System.Windows.Forms.Label();
            this.lbltongno = new System.Windows.Forms.Label();
            this.txtdanhbo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyGhiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTienColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NVThuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDangNganColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnDongBo,
            this.btnDB,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(926, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(50, 22);
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnDongBo
            // 
            this.btnDongBo.Image = global::QLCongNo.Properties.Resources.sync;
            this.btnDongBo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDongBo.Name = "btnDongBo";
            this.btnDongBo.Size = new System.Drawing.Size(76, 22);
            this.btnDongBo.Text = "Đồng bộ";
            this.btnDongBo.Click += new System.EventHandler(this.btnDongBo_Click);
            // 
            // btnDB
            // 
            this.btnDB.Image = global::QLCongNo.Properties.Resources.refresh_new;
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(208, 22);
            this.btnDB.Text = "Đồng bộ hóa đơn không  tồn tại";
            this.btnDB.Visible = false;
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(61, 22);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Visible = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbltongsokyno);
            this.groupBox1.Controls.Add(this.lbltongno);
            this.groupBox1.Controls.Add(this.txtdanhbo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(926, 132);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lbltongsokyno
            // 
            this.lbltongsokyno.AutoSize = true;
            this.lbltongsokyno.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltongsokyno.Location = new System.Drawing.Point(39, 86);
            this.lbltongsokyno.Name = "lbltongsokyno";
            this.lbltongsokyno.Size = new System.Drawing.Size(143, 25);
            this.lbltongsokyno.TabIndex = 4;
            this.lbltongsokyno.Text = "Tổng số kỳ nợ:";
            // 
            // lbltongno
            // 
            this.lbltongno.AutoSize = true;
            this.lbltongno.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltongno.Location = new System.Drawing.Point(183, 86);
            this.lbltongno.Name = "lbltongno";
            this.lbltongno.Size = new System.Drawing.Size(156, 25);
            this.lbltongno.TabIndex = 3;
            this.lbltongno.Text = "Tổng số tiền nợ:";
            // 
            // txtdanhbo
            // 
            this.txtdanhbo.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdanhbo.Location = new System.Drawing.Point(156, 30);
            this.txtdanhbo.Name = "txtdanhbo";
            this.txtdanhbo.Size = new System.Drawing.Size(392, 30);
            this.txtdanhbo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập danh bộ: ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(926, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTColumn,
            this.KyGhiColumn,
            this.TongTienColumn,
            this.TrangThaiColumn,
            this.NVThuColumn,
            this.NgayThuColumn,
            this.NgayDangNganColumn,
            this.IDHDColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(926, 293);
            this.dataGridView1.TabIndex = 3;
            // 
            // STTColumn
            // 
            this.STTColumn.HeaderText = "STT";
            this.STTColumn.Name = "STTColumn";
            // 
            // KyGhiColumn
            // 
            this.KyGhiColumn.DataPropertyName = "kyghi";
            this.KyGhiColumn.HeaderText = "Kỳ hóa đơn";
            this.KyGhiColumn.Name = "KyGhiColumn";
            // 
            // TongTienColumn
            // 
            this.TongTienColumn.DataPropertyName = "tongtien";
            dataGridViewCellStyle4.Format = "N0";
            this.TongTienColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.TongTienColumn.HeaderText = "Tổng tiền";
            this.TongTienColumn.Name = "TongTienColumn";
            this.TongTienColumn.Width = 140;
            // 
            // TrangThaiColumn
            // 
            this.TrangThaiColumn.DataPropertyName = "thanhtoan";
            this.TrangThaiColumn.HeaderText = "Trạng thái thanh toán";
            this.TrangThaiColumn.Name = "TrangThaiColumn";
            // 
            // NVThuColumn
            // 
            this.NVThuColumn.DataPropertyName = "hotenNV";
            this.NVThuColumn.HeaderText = "Nhân viên thu";
            this.NVThuColumn.Name = "NVThuColumn";
            this.NVThuColumn.Width = 150;
            // 
            // NgayThuColumn
            // 
            this.NgayThuColumn.DataPropertyName = "ngaythanhtoan";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy HH:mm:ss";
            this.NgayThuColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.NgayThuColumn.HeaderText = "Ngày thu";
            this.NgayThuColumn.Name = "NgayThuColumn";
            this.NgayThuColumn.Width = 120;
            // 
            // NgayDangNganColumn
            // 
            this.NgayDangNganColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayDangNganColumn.DataPropertyName = "NGAYDANGNGAN_NV";
            dataGridViewCellStyle6.Format = "dd/MM/yyyy HH:mm:ss";
            this.NgayDangNganColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.NgayDangNganColumn.HeaderText = "Ngày đăng ngân";
            this.NgayDangNganColumn.Name = "NgayDangNganColumn";
            // 
            // IDHDColumn
            // 
            this.IDHDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDHDColumn.DataPropertyName = "ID_HD";
            this.IDHDColumn.HeaderText = "IDHD";
            this.IDHDColumn.Name = "IDHDColumn";
            this.IDHDColumn.Visible = false;
            // 
            // frDongBoDuLieuHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 472);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frDongBoDuLieuHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐỒNG BỘ DỮ LIỆU HÓA ĐƠN";
            this.Load += new System.EventHandler(this.frDongBoDuLieuHoaDon_Load);
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
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStripButton btnDongBo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtdanhbo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbltongsokyno;
        private System.Windows.Forms.Label lbltongno;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyGhiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NVThuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDangNganColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHDColumn;
    }
}