namespace QLCongNo.HoaDon
{
    partial class frThongKeDieuChinhThongTin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frThongKeDieuChinhThongTin));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnTaiHD = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblsoluong = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ngaytaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maltColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masothueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachilapdatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachihoadonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyghiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHieuHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mauhdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnTaiHD,
            this.btnExcel,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1285, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(54, 23);
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnTaiHD
            // 
            this.btnTaiHD.Image = global::QLCongNo.Properties.Resources.tai_hoa_don;
            this.btnTaiHD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaiHD.Name = "btnTaiHD";
            this.btnTaiHD.Size = new System.Drawing.Size(111, 23);
            this.btnTaiHD.Text = "Tải hóa đơn";
            this.btnTaiHD.Click += new System.EventHandler(this.btnTaiHD_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(99, 23);
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(69, 23);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Visible = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1285, 98);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(106, 54);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(450, 25);
            this.txtTim.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tìm";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(375, 23);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(181, 25);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến ngày";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(107, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(159, 25);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblsoluong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1285, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblsoluong
            // 
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(49, 17);
            this.lblsoluong.Text = "Tổng số";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ngaytaoColumn,
            this.danhboColumn,
            this.maltColumn,
            this.hotenColumn,
            this.diachiColumn,
            this.masothueColumn,
            this.diachilapdatColumn,
            this.diachihoadonColumn,
            this.kyghiColumn,
            this.SOHDColumn,
            this.KyHieuHDColumn,
            this.mauhdColumn,
            this.IDHDColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1285, 410);
            this.dataGridView1.TabIndex = 29;
            // 
            // ngaytaoColumn
            // 
            this.ngaytaoColumn.DataPropertyName = "NgayPhatHanh";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.ngaytaoColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.ngaytaoColumn.HeaderText = "Ngày phát hành";
            this.ngaytaoColumn.Name = "ngaytaoColumn";
            // 
            // danhboColumn
            // 
            this.danhboColumn.DataPropertyName = "DANHBO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.danhboColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.danhboColumn.HeaderText = "Danh bộ";
            this.danhboColumn.Name = "danhboColumn";
            // 
            // maltColumn
            // 
            this.maltColumn.DataPropertyName = "maLT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.maltColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.maltColumn.HeaderText = "Mã LT";
            this.maltColumn.Name = "maltColumn";
            // 
            // hotenColumn
            // 
            this.hotenColumn.DataPropertyName = "hoten_KH";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.hotenColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.hotenColumn.HeaderText = "Họ tên";
            this.hotenColumn.Name = "hotenColumn";
            // 
            // diachiColumn
            // 
            this.diachiColumn.DataPropertyName = "diachi";
            this.diachiColumn.HeaderText = "Địa chỉ";
            this.diachiColumn.Name = "diachiColumn";
            this.diachiColumn.Visible = false;
            // 
            // masothueColumn
            // 
            this.masothueColumn.DataPropertyName = "MST";
            this.masothueColumn.HeaderText = "Mã số thuế";
            this.masothueColumn.Name = "masothueColumn";
            // 
            // diachilapdatColumn
            // 
            this.diachilapdatColumn.DataPropertyName = "diachilapdat";
            this.diachilapdatColumn.HeaderText = "Địa chỉ lắp đặt";
            this.diachilapdatColumn.Name = "diachilapdatColumn";
            // 
            // diachihoadonColumn
            // 
            this.diachihoadonColumn.DataPropertyName = "diachihoadon";
            this.diachihoadonColumn.HeaderText = "Địa chỉ";
            this.diachihoadonColumn.Name = "diachihoadonColumn";
            // 
            // kyghiColumn
            // 
            this.kyghiColumn.DataPropertyName = "ten_kyghi";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kyghiColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.kyghiColumn.HeaderText = "Kỳ HĐ";
            this.kyghiColumn.Name = "kyghiColumn";
            // 
            // SOHDColumn
            // 
            this.SOHDColumn.DataPropertyName = "SoHoaDon";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SOHDColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.SOHDColumn.HeaderText = "Số HĐ";
            this.SOHDColumn.Name = "SOHDColumn";
            // 
            // KyHieuHDColumn
            // 
            this.KyHieuHDColumn.DataPropertyName = "KyHieuHD";
            this.KyHieuHDColumn.HeaderText = "Ký hiệu";
            this.KyHieuHDColumn.Name = "KyHieuHDColumn";
            // 
            // mauhdColumn
            // 
            this.mauhdColumn.DataPropertyName = "MauHD";
            this.mauhdColumn.HeaderText = "Mẫu hóa đơn";
            this.mauhdColumn.Name = "mauhdColumn";
            // 
            // IDHDColumn
            // 
            this.IDHDColumn.DataPropertyName = "ID_HD";
            this.IDHDColumn.HeaderText = "IDHD";
            this.IDHDColumn.Name = "IDHDColumn";
            this.IDHDColumn.Visible = false;
            // 
            // frThongKeDieuChinhThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 556);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frThongKeDieuChinhThongTin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách hóa đơn điều chỉnh thông tin";
            this.Load += new System.EventHandler(this.frThongKeDieuChinhThongTin_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblsoluong;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton btnTaiHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaytaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maltColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn masothueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachilapdatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachihoadonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyghiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHieuHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mauhdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHDColumn;
    }
}