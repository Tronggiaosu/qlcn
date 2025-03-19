namespace QLCongNo.GachNo
{
    partial class frDongBoThanhToanThuHo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frDongBoThanhToanThuHo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.excelButton = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpdenngay = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTienColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThanhToanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachButton,
            this.btnDB,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1079, 26);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seachButton
            // 
            this.seachButton.Image = global::QLCongNo.Properties.Resources.lay_danh_sach;
            this.seachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seachButton.Name = "seachButton";
            this.seachButton.Size = new System.Drawing.Size(128, 23);
            this.seachButton.Text = "Lấy danh sách";
            this.seachButton.Click += new System.EventHandler(this.seachButton_Click);
            // 
            // btnDB
            // 
            this.btnDB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDB.Image = global::QLCongNo.Properties.Resources.sync;
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(80, 23);
            this.btnDB.Text = "Đồng bộ";
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // excelButton
            // 
            this.excelButton.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.excelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(100, 23);
            this.excelButton.Text = "Xuất Excel";
            // 
            // quitButton
            // 
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(69, 23);
            this.quitButton.Text = "Thoát";
            this.quitButton.Visible = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpdenngay);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1079, 102);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 48;
            this.label8.Text = "Từ ngày";
            // 
            // dtpdenngay
            // 
            this.dtpdenngay.CustomFormat = "dd/MM/yyyy";
            this.dtpdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdenngay.Location = new System.Drawing.Point(350, 24);
            this.dtpdenngay.Name = "dtpdenngay";
            this.dtpdenngay.Size = new System.Drawing.Size(181, 25);
            this.dtpdenngay.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 46;
            this.label9.Text = "đến ngày";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(157, 25);
            this.dateTimePicker1.TabIndex = 44;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(101, 54);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(431, 25);
            this.txtTim.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Tìm kiếm";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1079, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTColumn,
            this.DanhBoColumn,
            this.KyHDColumn,
            this.TongTienColumn,
            this.NgayThanhToanColumn,
            this.IDHDColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1079, 535);
            this.dataGridView1.TabIndex = 30;
            // 
            // STTColumn
            // 
            this.STTColumn.HeaderText = "STT";
            this.STTColumn.Name = "STTColumn";
            // 
            // DanhBoColumn
            // 
            this.DanhBoColumn.DataPropertyName = "DanhBo";
            this.DanhBoColumn.HeaderText = "Danh bộ";
            this.DanhBoColumn.Name = "DanhBoColumn";
            // 
            // KyHDColumn
            // 
            this.KyHDColumn.DataPropertyName = "TenKy";
            this.KyHDColumn.HeaderText = "Kỳ hóa đơn";
            this.KyHDColumn.Name = "KyHDColumn";
            this.KyHDColumn.Width = 150;
            // 
            // TongTienColumn
            // 
            this.TongTienColumn.DataPropertyName = "TongTien";
            this.TongTienColumn.HeaderText = "Tổng tiền";
            this.TongTienColumn.Name = "TongTienColumn";
            // 
            // NgayThanhToanColumn
            // 
            this.NgayThanhToanColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayThanhToanColumn.DataPropertyName = "NgayThanhToan";
            this.NgayThanhToanColumn.HeaderText = "Ngày thanh toán";
            this.NgayThanhToanColumn.Name = "NgayThanhToanColumn";
            // 
            // IDHDColumn
            // 
            this.IDHDColumn.DataPropertyName = "ID_HD";
            this.IDHDColumn.HeaderText = "IDHD";
            this.IDHDColumn.Name = "IDHDColumn";
            this.IDHDColumn.Visible = false;
            // 
            // frDongBoThanhToanThuHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 685);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frDongBoThanhToanThuHo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đồng bộ thanh toán thu hộ";
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
        private System.Windows.Forms.ToolStripButton seachButton;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.ToolStripButton excelButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpdenngay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThanhToanColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHDColumn;
    }
}