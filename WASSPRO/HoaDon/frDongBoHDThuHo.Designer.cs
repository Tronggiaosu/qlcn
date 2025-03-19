namespace QLCongNo.HoaDon
{
    partial class frDongBoHDThuHo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frDongBoHDThuHo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.excelButton = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTT = new System.Windows.Forms.ComboBox();
            this.cboDot = new System.Windows.Forms.ComboBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.chkTT = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.namColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dotColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluongHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtienColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaydongboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NVDongbo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthaiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.log_idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachButton,
            this.btnDB,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(940, 26);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seachButton
            // 
            this.seachButton.Image = global::QLCongNo.Properties.Resources.lay_danh_sach;
            this.seachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seachButton.Name = "seachButton";
            this.seachButton.Size = new System.Drawing.Size(128, 23);
            this.seachButton.Text = "Lấy danh sách";
            // 
            // btnDB
            // 
            this.btnDB.Image = global::QLCongNo.Properties.Resources.sync;
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(88, 23);
            this.btnDB.Text = "Đồng bộ";
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
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboTT);
            this.groupBox1.Controls.Add(this.cboDot);
            this.groupBox1.Controls.Add(this.cboKy);
            this.groupBox1.Controls.Add(this.chkTT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 94);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Đợt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kỳ hóa đơn";
            // 
            // cboTT
            // 
            this.cboTT.FormattingEnabled = true;
            this.cboTT.Location = new System.Drawing.Point(362, 45);
            this.cboTT.Name = "cboTT";
            this.cboTT.Size = new System.Drawing.Size(138, 25);
            this.cboTT.TabIndex = 7;
            // 
            // cboDot
            // 
            this.cboDot.FormattingEnabled = true;
            this.cboDot.Location = new System.Drawing.Point(226, 45);
            this.cboDot.Name = "cboDot";
            this.cboDot.Size = new System.Drawing.Size(116, 25);
            this.cboDot.TabIndex = 6;
            // 
            // cboKy
            // 
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(37, 45);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(163, 25);
            this.cboKy.TabIndex = 5;
            // 
            // chkTT
            // 
            this.chkTT.AutoSize = true;
            this.chkTT.Location = new System.Drawing.Point(362, 18);
            this.chkTT.Name = "chkTT";
            this.chkTT.Size = new System.Drawing.Size(90, 21);
            this.chkTT.TabIndex = 3;
            this.chkTT.Text = "Trạng thái";
            this.chkTT.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeight = 36;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.namColumn,
            this.kyColumn,
            this.dotColumn,
            this.soluongHDColumn,
            this.tongtienColumn,
            this.ngaydongboColumn,
            this.NVDongbo,
            this.trangthaiColumn,
            this.log_idColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(940, 320);
            this.dataGridView1.TabIndex = 26;
            // 
            // namColumn
            // 
            this.namColumn.DataPropertyName = "nam";
            this.namColumn.HeaderText = "Năm";
            this.namColumn.Name = "namColumn";
            this.namColumn.Width = 62;
            // 
            // kyColumn
            // 
            this.kyColumn.DataPropertyName = "kyghi";
            this.kyColumn.HeaderText = "Kỳ HĐ";
            this.kyColumn.Name = "kyColumn";
            this.kyColumn.Width = 72;
            // 
            // dotColumn
            // 
            this.dotColumn.DataPropertyName = "dot_id";
            this.dotColumn.HeaderText = "Đợt";
            this.dotColumn.Name = "dotColumn";
            this.dotColumn.Width = 57;
            // 
            // soluongHDColumn
            // 
            this.soluongHDColumn.DataPropertyName = "soHD";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.soluongHDColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.soluongHDColumn.HeaderText = "Số lượng HĐ";
            this.soluongHDColumn.Name = "soluongHDColumn";
            this.soluongHDColumn.Width = 111;
            // 
            // tongtienColumn
            // 
            this.tongtienColumn.DataPropertyName = "tongtien";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.tongtienColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.tongtienColumn.HeaderText = "Tổng tiền";
            this.tongtienColumn.Name = "tongtienColumn";
            this.tongtienColumn.Width = 91;
            // 
            // ngaydongboColumn
            // 
            this.ngaydongboColumn.DataPropertyName = "ngaythuchien";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.ngaydongboColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ngaydongboColumn.HeaderText = "Ngày thực hiện";
            this.ngaydongboColumn.Name = "ngaydongboColumn";
            this.ngaydongboColumn.Width = 127;
            // 
            // NVDongbo
            // 
            this.NVDongbo.DataPropertyName = "hoten";
            this.NVDongbo.HeaderText = "Người thực hiện";
            this.NVDongbo.Name = "NVDongbo";
            this.NVDongbo.Width = 134;
            // 
            // trangthaiColumn
            // 
            this.trangthaiColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.trangthaiColumn.DataPropertyName = "trangthai";
            this.trangthaiColumn.HeaderText = "Trạng thái";
            this.trangthaiColumn.Name = "trangthaiColumn";
            // 
            // log_idColumn
            // 
            this.log_idColumn.DataPropertyName = "logThuho_ID";
            this.log_idColumn.HeaderText = "logID";
            this.log_idColumn.Name = "log_idColumn";
            this.log_idColumn.ReadOnly = true;
            this.log_idColumn.Visible = false;
            this.log_idColumn.Width = 67;
            // 
            // frDongBoHDThuHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 440);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frDongBoHDThuHo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐỒNG BỘ DỮ LIỆU THU HỘ";
            this.Load += new System.EventHandler(this.frDongBoHDThuHo_Load);
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
        private System.Windows.Forms.ToolStripButton excelButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboTT;
        private System.Windows.Forms.ComboBox cboDot;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.CheckBox chkTT;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn namColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dotColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluongHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtienColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaydongboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NVDongbo;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthaiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn log_idColumn;
    }
}