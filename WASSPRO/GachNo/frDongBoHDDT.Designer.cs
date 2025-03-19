namespace QLCongNo.GachNo
{
    partial class frDongBoHDDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frDongBoHDDT));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.btnAll = new System.Windows.Forms.ToolStripButton();
            this.excelButton = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDT = new System.Windows.Forms.ComboBox();
            this.chkmaDT = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpdenngay = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chktrangthai = new System.Windows.Forms.CheckBox();
            this.cboTT = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblsoluong = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chkColum = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.trangthaiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtienColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.btnAll,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1054, 26);
            this.toolStrip1.TabIndex = 26;
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
            this.btnDB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDB.Image = global::QLCongNo.Properties.Resources.sync;
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(80, 23);
            this.btnDB.Text = "Đồng bộ";
            // 
            // btnAll
            // 
            this.btnAll.Image = global::QLCongNo.Properties.Resources._112_RefreshArrow_Blue_24x24_72;
            this.btnAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(129, 23);
            this.btnAll.Text = "Đồng bộ tất cả";
            // 
            // excelButton
            // 
            this.excelButton.Image = ((System.Drawing.Image)(resources.GetObject("excelButton.Image")));
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
            this.groupBox1.Controls.Add(this.cboDT);
            this.groupBox1.Controls.Add(this.chkmaDT);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpdenngay);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chktrangthai);
            this.groupBox1.Controls.Add(this.cboTT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1054, 102);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // cboDT
            // 
            this.cboDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDT.FormattingEnabled = true;
            this.cboDT.Location = new System.Drawing.Point(632, 52);
            this.cboDT.Name = "cboDT";
            this.cboDT.Size = new System.Drawing.Size(165, 25);
            this.cboDT.TabIndex = 52;
            // 
            // chkmaDT
            // 
            this.chkmaDT.AutoSize = true;
            this.chkmaDT.Location = new System.Drawing.Point(536, 56);
            this.chkmaDT.Name = "chkmaDT";
            this.chkmaDT.Size = new System.Drawing.Size(90, 21);
            this.chkmaDT.TabIndex = 51;
            this.chkmaDT.Text = "Đối tượng";
            this.chkmaDT.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 48;
            this.label8.Text = "Từ ngày";
            // 
            // dtpdenngay
            // 
            this.dtpdenngay.CustomFormat = "dd/MM/yyyy";
            this.dtpdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdenngay.Location = new System.Drawing.Point(341, 24);
            this.dtpdenngay.Name = "dtpdenngay";
            this.dtpdenngay.Size = new System.Drawing.Size(172, 25);
            this.dtpdenngay.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 46;
            this.label9.Text = "Đến ngày";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(82, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(165, 25);
            this.dateTimePicker1.TabIndex = 44;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(82, 55);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(431, 25);
            this.txtTim.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Tìm kiếm";
            // 
            // chktrangthai
            // 
            this.chktrangthai.AutoSize = true;
            this.chktrangthai.Location = new System.Drawing.Point(536, 27);
            this.chktrangthai.Name = "chktrangthai";
            this.chktrangthai.Size = new System.Drawing.Size(90, 21);
            this.chktrangthai.TabIndex = 37;
            this.chktrangthai.Text = "Trạng thái";
            this.chktrangthai.UseVisualStyleBackColor = true;
            // 
            // cboTT
            // 
            this.cboTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTT.FormattingEnabled = true;
            this.cboTT.Location = new System.Drawing.Point(632, 22);
            this.cboTT.Name = "cboTT";
            this.cboTT.Size = new System.Drawing.Size(165, 25);
            this.cboTT.TabIndex = 36;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblsoluong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1054, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblsoluong
            // 
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(0, 17);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkColum,
            this.trangthaiColumn,
            this.seriColumn,
            this.tongtienColumn,
            this.danhboColumn,
            this.HotenColumn,
            this.diachiColumn,
            this.IDHDColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1054, 298);
            this.dataGridView1.TabIndex = 29;
            // 
            // chkColum
            // 
            this.chkColum.FalseValue = "false";
            this.chkColum.HeaderText = "Chọn";
            this.chkColum.Name = "chkColum";
            this.chkColum.TrueValue = "true";
            // 
            // trangthaiColumn
            // 
            this.trangthaiColumn.DataPropertyName = "Trangthai";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.trangthaiColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.trangthaiColumn.HeaderText = "Trạng thái";
            this.trangthaiColumn.Name = "trangthaiColumn";
            // 
            // seriColumn
            // 
            this.seriColumn.DataPropertyName = "seri";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.seriColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.seriColumn.HeaderText = "Seri";
            this.seriColumn.Name = "seriColumn";
            // 
            // tongtienColumn
            // 
            this.tongtienColumn.DataPropertyName = "tongtien";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            dataGridViewCellStyle18.NullValue = null;
            this.tongtienColumn.DefaultCellStyle = dataGridViewCellStyle18;
            this.tongtienColumn.HeaderText = "Tổng tiền";
            this.tongtienColumn.Name = "tongtienColumn";
            // 
            // danhboColumn
            // 
            this.danhboColumn.DataPropertyName = "madanhbo";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.danhboColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.danhboColumn.HeaderText = "Danh bộ";
            this.danhboColumn.Name = "danhboColumn";
            // 
            // HotenColumn
            // 
            this.HotenColumn.DataPropertyName = "hoten_kh";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.HotenColumn.DefaultCellStyle = dataGridViewCellStyle20;
            this.HotenColumn.HeaderText = "Họ tên";
            this.HotenColumn.Name = "HotenColumn";
            // 
            // diachiColumn
            // 
            this.diachiColumn.HeaderText = "Địa chỉ";
            this.diachiColumn.Name = "diachiColumn";
            this.diachiColumn.Visible = false;
            // 
            // IDHDColumn
            // 
            this.IDHDColumn.DataPropertyName = "ID_HD";
            this.IDHDColumn.HeaderText = "IDHD";
            this.IDHDColumn.Name = "IDHDColumn";
            this.IDHDColumn.Visible = false;
            // 
            // frDongBoHDDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 448);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frDongBoHDDT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐỒNG BỘ HÓA ĐƠN ĐIỆN TỬ";
            this.Load += new System.EventHandler(this.frDongBoHDDT_Load);
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
        private System.Windows.Forms.ToolStripButton seachButton;
        private System.Windows.Forms.ToolStripButton excelButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTT;
        private System.Windows.Forms.DateTimePicker dtpdenngay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.CheckBox chktrangthai;
        private System.Windows.Forms.ToolStripButton btnAll;
        private System.Windows.Forms.ComboBox cboDT;
        private System.Windows.Forms.CheckBox chkmaDT;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblsoluong;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkColum;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthaiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtienColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHDColumn;
    }
}