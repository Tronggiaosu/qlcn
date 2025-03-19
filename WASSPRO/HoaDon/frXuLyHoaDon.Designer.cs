namespace QLCongNo.HoaDon
{
    partial class frXuLyHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frXuLyHoaDon));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDC = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblsl = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soseriColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtienColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maLTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthaiHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhtoanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhanvienthuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaythuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhanviendangnganColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaydangnganColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnUpdate,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1092, 26);
            this.toolStrip1.TabIndex = 83;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(54, 23);
            this.btnTim.Text = "Tìm";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::QLCongNo.Properties.Resources.add_1;
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(208, 23);
            this.btnUpdate.Text = "Tạo quyết định điều chỉnh";
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(69, 23);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1092, 86);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            // 
            // cboDC
            // 
            this.cboDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDC.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDC.FormattingEnabled = true;
            this.cboDC.Location = new System.Drawing.Point(635, 35);
            this.cboDC.Name = "cboDC";
            this.cboDC.Size = new System.Drawing.Size(271, 30);
            this.cboDC.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại điều chỉnh";
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(146, 35);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(348, 30);
            this.txtTim.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nội dung tra cứu";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblsl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 447);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1092, 22);
            this.statusStrip1.TabIndex = 85;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblsl
            // 
            this.lblsl.Name = "lblsl";
            this.lblsl.Size = new System.Drawing.Size(118, 17);
            this.lblsl.Text = "toolStripStatusLabel1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTColumn,
            this.IDHDColumn,
            this.soseriColumn,
            this.kyHDColumn,
            this.tongtienColumn,
            this.maLTColumn,
            this.hotenColumn,
            this.trangthaiHD,
            this.thanhtoanColumn,
            this.nhanvienthuColumn,
            this.ngaythuColumn,
            this.nhanviendangnganColumn,
            this.ngaydangnganColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1092, 335);
            this.dataGridView1.TabIndex = 86;
            // 
            // STTColumn
            // 
            this.STTColumn.HeaderText = "STT";
            this.STTColumn.Name = "STTColumn";
            // 
            // IDHDColumn
            // 
            this.IDHDColumn.DataPropertyName = "ID_HD";
            this.IDHDColumn.HeaderText = "IDHD";
            this.IDHDColumn.Name = "IDHDColumn";
            this.IDHDColumn.Visible = false;
            // 
            // soseriColumn
            // 
            this.soseriColumn.DataPropertyName = "seri";
            this.soseriColumn.HeaderText = "Số seri";
            this.soseriColumn.Name = "soseriColumn";
            // 
            // kyHDColumn
            // 
            this.kyHDColumn.DataPropertyName = "kyghi";
            this.kyHDColumn.HeaderText = "Kỳ HĐ";
            this.kyHDColumn.Name = "kyHDColumn";
            // 
            // tongtienColumn
            // 
            this.tongtienColumn.DataPropertyName = "tongtien";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.tongtienColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.tongtienColumn.HeaderText = "Tổng cộng";
            this.tongtienColumn.Name = "tongtienColumn";
            // 
            // maLTColumn
            // 
            this.maLTColumn.DataPropertyName = "malt";
            this.maLTColumn.HeaderText = "Mã LT";
            this.maLTColumn.Name = "maLTColumn";
            // 
            // hotenColumn
            // 
            this.hotenColumn.DataPropertyName = "hoten";
            this.hotenColumn.HeaderText = "Họ tên";
            this.hotenColumn.Name = "hotenColumn";
            // 
            // trangthaiHD
            // 
            this.trangthaiHD.DataPropertyName = "tentrangthai";
            this.trangthaiHD.HeaderText = "Trạng thái HĐ";
            this.trangthaiHD.Name = "trangthaiHD";
            // 
            // thanhtoanColumn
            // 
            this.thanhtoanColumn.DataPropertyName = "thanhtoan";
            this.thanhtoanColumn.HeaderText = "Thanh toán";
            this.thanhtoanColumn.Name = "thanhtoanColumn";
            // 
            // nhanvienthuColumn
            // 
            this.nhanvienthuColumn.DataPropertyName = "hotenNV";
            this.nhanvienthuColumn.HeaderText = "Nhân viên thu";
            this.nhanvienthuColumn.Name = "nhanvienthuColumn";
            // 
            // ngaythuColumn
            // 
            this.ngaythuColumn.DataPropertyName = "ngaythanhtoan";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.ngaythuColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.ngaythuColumn.HeaderText = "Ngày thu";
            this.ngaythuColumn.Name = "ngaythuColumn";
            // 
            // nhanviendangnganColumn
            // 
            this.nhanviendangnganColumn.HeaderText = "Nhân viên đăng ngân";
            this.nhanviendangnganColumn.Name = "nhanviendangnganColumn";
            this.nhanviendangnganColumn.Visible = false;
            // 
            // ngaydangnganColumn
            // 
            this.ngaydangnganColumn.HeaderText = "Ngày đăng ngân";
            this.ngaydangnganColumn.Name = "ngaydangnganColumn";
            this.ngaydangnganColumn.Visible = false;
            // 
            // frXuLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 469);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frXuLyHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XỬ LÝ HÓA ĐƠN";
            this.Load += new System.EventHandler(this.frXuLyHoaDon_Load);
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
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel lblsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soseriColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtienColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maLTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthaiHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhtoanColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhanvienthuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaythuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhanviendangnganColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaydangnganColumn;
        private System.Windows.Forms.ComboBox cboDC;
        private System.Windows.Forms.Label label2;
    }
}