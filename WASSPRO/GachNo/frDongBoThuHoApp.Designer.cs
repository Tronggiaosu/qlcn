namespace QLCongNo.GachNo
{
    partial class frDongBoThuHoApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frDongBoThuHoApp));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnsearch = new System.Windows.Forms.ToolStripButton();
            this.btnConfirm = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblsoluong = new System.Windows.Forms.ToolStripStatusLabel();
            this.txttim = new System.Windows.Forms.GroupBox();
            this.cboTT = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtimdanhbo = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nvxulyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayxulyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthaiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyhieuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaythanhtoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nvthuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.txttim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnsearch,
            this.btnConfirm,
            this.btnExcel,
            this.btnQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1109, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnsearch
            // 
            this.btnsearch.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnsearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(52, 22);
            this.btnsearch.Text = "Tìm";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Image = global::QLCongNo.Properties.Resources.sync;
            this.btnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(80, 22);
            this.btnConfirm.Text = "Đồng bộ";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(92, 22);
            this.btnExcel.Text = "Xuất excel";
            // 
            // btnQuit
            // 
            this.btnQuit.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(65, 22);
            this.btnQuit.Text = "Thoát";
            this.btnQuit.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblsoluong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1109, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // lblsoluong
            // 
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(0, 17);
            // 
            // txttim
            // 
            this.txttim.Controls.Add(this.cboTT);
            this.txttim.Controls.Add(this.label6);
            this.txttim.Controls.Add(this.label5);
            this.txttim.Controls.Add(this.txtimdanhbo);
            this.txttim.Controls.Add(this.dateTimePicker2);
            this.txttim.Controls.Add(this.dateTimePicker1);
            this.txttim.Controls.Add(this.cboNV);
            this.txttim.Controls.Add(this.cboTo);
            this.txttim.Controls.Add(this.label3);
            this.txttim.Controls.Add(this.label4);
            this.txttim.Controls.Add(this.label2);
            this.txttim.Controls.Add(this.label1);
            this.txttim.Dock = System.Windows.Forms.DockStyle.Top;
            this.txttim.Location = new System.Drawing.Point(0, 25);
            this.txttim.Name = "txttim";
            this.txttim.Size = new System.Drawing.Size(1109, 113);
            this.txttim.TabIndex = 2;
            this.txttim.TabStop = false;
            // 
            // cboTT
            // 
            this.cboTT.FormattingEnabled = true;
            this.cboTT.Location = new System.Drawing.Point(921, 21);
            this.cboTT.Name = "cboTT";
            this.cboTT.Size = new System.Drawing.Size(144, 25);
            this.cboTT.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(841, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Trạng thái";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(615, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nhân viên";
            // 
            // txtimdanhbo
            // 
            this.txtimdanhbo.Location = new System.Drawing.Point(95, 55);
            this.txtimdanhbo.Name = "txtimdanhbo";
            this.txtimdanhbo.Size = new System.Drawing.Size(470, 25);
            this.txtimdanhbo.TabIndex = 10;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(377, 22);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(188, 25);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(95, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(190, 25);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // cboNV
            // 
            this.cboNV.FormattingEnabled = true;
            this.cboNV.Location = new System.Drawing.Point(693, 53);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(373, 25);
            this.cboNV.TabIndex = 7;
            // 
            // cboTo
            // 
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(693, 20);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(134, 25);
            this.cboTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(658, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tổ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tìm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTColumn,
            this.nvxulyColumn,
            this.ngayxulyColumn,
            this.trangthaiColumn,
            this.danhboColumn,
            this.soHDColumn,
            this.kyhieuColumn,
            this.ngaythanhtoan,
            this.kyHDColumn,
            this.namColumn,
            this.nvthuColumn,
            this.errorColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1109, 270);
            this.dataGridView1.TabIndex = 3;
            // 
            // STTColumn
            // 
            this.STTColumn.HeaderText = "STT";
            this.STTColumn.Name = "STTColumn";
            this.STTColumn.Visible = false;
            // 
            // nvxulyColumn
            // 
            this.nvxulyColumn.DataPropertyName = "nv_xuly";
            this.nvxulyColumn.HeaderText = "Người xử lý";
            this.nvxulyColumn.Name = "nvxulyColumn";
            // 
            // ngayxulyColumn
            // 
            this.ngayxulyColumn.DataPropertyName = "ngay_xu_ly";
            this.ngayxulyColumn.HeaderText = "Ngày xử lý";
            this.ngayxulyColumn.Name = "ngayxulyColumn";
            // 
            // trangthaiColumn
            // 
            this.trangthaiColumn.DataPropertyName = "trang_thai";
            this.trangthaiColumn.HeaderText = "Trạng thái";
            this.trangthaiColumn.Name = "trangthaiColumn";
            // 
            // danhboColumn
            // 
            this.danhboColumn.DataPropertyName = "so_db";
            this.danhboColumn.HeaderText = "Danh bộ";
            this.danhboColumn.Name = "danhboColumn";
            // 
            // soHDColumn
            // 
            this.soHDColumn.DataPropertyName = "so_hd";
            this.soHDColumn.HeaderText = "Số HĐ";
            this.soHDColumn.Name = "soHDColumn";
            // 
            // kyhieuColumn
            // 
            this.kyhieuColumn.DataPropertyName = "ky_hieu";
            this.kyhieuColumn.HeaderText = "Ký hiệu";
            this.kyhieuColumn.Name = "kyhieuColumn";
            // 
            // ngaythanhtoan
            // 
            this.ngaythanhtoan.DataPropertyName = "ngay_thanh_toan";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm:ss";
            dataGridViewCellStyle1.NullValue = null;
            this.ngaythanhtoan.DefaultCellStyle = dataGridViewCellStyle1;
            this.ngaythanhtoan.HeaderText = "Ngày thanh toán";
            this.ngaythanhtoan.Name = "ngaythanhtoan";
            // 
            // kyHDColumn
            // 
            this.kyHDColumn.DataPropertyName = "ky_hd";
            this.kyHDColumn.HeaderText = "Tháng";
            this.kyHDColumn.Name = "kyHDColumn";
            // 
            // namColumn
            // 
            this.namColumn.DataPropertyName = "nam";
            this.namColumn.HeaderText = "Năm";
            this.namColumn.Name = "namColumn";
            // 
            // nvthuColumn
            // 
            this.nvthuColumn.DataPropertyName = "nv_thu";
            this.nvthuColumn.HeaderText = "Nhân viên thu";
            this.nvthuColumn.Name = "nvthuColumn";
            // 
            // errorColumn
            // 
            this.errorColumn.DataPropertyName = "ErrorDes";
            this.errorColumn.HeaderText = "Chi tiết lỗi";
            this.errorColumn.Name = "errorColumn";
            // 
            // frDongBoThuHoApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 430);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txttim);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frDongBoThuHoApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐÔNG BỘ THU HỘ DO APP LỖI";
            this.Load += new System.EventHandler(this.frDongBoThuHoApp_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.txttim.ResumeLayout(false);
            this.txttim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox txttim;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox txtimdanhbo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btnsearch;
        private System.Windows.Forms.ToolStripButton btnConfirm;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStripStatusLabel lblsoluong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nvxulyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayxulyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthaiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyhieuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaythanhtoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nvthuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorColumn;
    }
}