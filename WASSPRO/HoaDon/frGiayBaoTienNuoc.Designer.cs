namespace QLCongNo.HoaDon
{
    partial class frGiayBaoTienNuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frGiayBaoTienNuoc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.btnIn = new System.Windows.Forms.ToolStripButton();
            this.excelButton = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chktrangthai = new System.Windows.Forms.CheckBox();
            this.cboTT = new System.Windows.Forms.ComboBox();
            this.cboPhuong = new System.Windows.Forms.ComboBox();
            this.cboQuan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthaiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtienColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenKHColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sonhaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuongColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnIn,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(963, 26);
            this.toolStrip1.TabIndex = 25;
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
            // btnIn
            // 
            this.btnIn.Image = global::QLCongNo.Properties.Resources.print;
            this.btnIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(117, 23);
            this.btnIn.Text = "In danh sách";
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
            this.groupBox1.Controls.Add(this.cboKy);
            this.groupBox1.Controls.Add(this.cboNam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chktrangthai);
            this.groupBox1.Controls.Add(this.cboTT);
            this.groupBox1.Controls.Add(this.cboPhuong);
            this.groupBox1.Controls.Add(this.cboQuan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(963, 136);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // cboKy
            // 
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(350, 29);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(106, 25);
            this.cboKy.TabIndex = 31;
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(83, 29);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(180, 25);
            this.cboNam.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Năm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Tháng";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(83, 92);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(431, 25);
            this.txtTim.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Tìm kiếm";
            // 
            // chktrangthai
            // 
            this.chktrangthai.AutoSize = true;
            this.chktrangthai.Location = new System.Drawing.Point(480, 32);
            this.chktrangthai.Name = "chktrangthai";
            this.chktrangthai.Size = new System.Drawing.Size(90, 21);
            this.chktrangthai.TabIndex = 25;
            this.chktrangthai.Text = "Trạng thái";
            this.chktrangthai.UseVisualStyleBackColor = true;
            // 
            // cboTT
            // 
            this.cboTT.FormattingEnabled = true;
            this.cboTT.Location = new System.Drawing.Point(579, 30);
            this.cboTT.Name = "cboTT";
            this.cboTT.Size = new System.Drawing.Size(152, 25);
            this.cboTT.TabIndex = 24;
            // 
            // cboPhuong
            // 
            this.cboPhuong.FormattingEnabled = true;
            this.cboPhuong.Location = new System.Drawing.Point(350, 61);
            this.cboPhuong.Name = "cboPhuong";
            this.cboPhuong.Size = new System.Drawing.Size(381, 25);
            this.cboPhuong.TabIndex = 23;
            // 
            // cboQuan
            // 
            this.cboQuan.FormattingEnabled = true;
            this.cboQuan.Location = new System.Drawing.Point(83, 61);
            this.cboQuan.Name = "cboQuan";
            this.cboQuan.Size = new System.Drawing.Size(180, 25);
            this.cboQuan.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Phường";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Quận";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTColumn,
            this.trangthaiColumn,
            this.seriColumn,
            this.tongtienColumn,
            this.danhboColumn,
            this.hotenKHColumn,
            this.sonhaColumn,
            this.diachiColumn,
            this.phuongColumn,
            this.quanColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(963, 278);
            this.dataGridView1.TabIndex = 27;
            // 
            // STTColumn
            // 
            this.STTColumn.HeaderText = "STT";
            this.STTColumn.Name = "STTColumn";
            // 
            // trangthaiColumn
            // 
            this.trangthaiColumn.DataPropertyName = "tentrangthai";
            this.trangthaiColumn.HeaderText = "Trạng thái";
            this.trangthaiColumn.Name = "trangthaiColumn";
            // 
            // seriColumn
            // 
            this.seriColumn.DataPropertyName = "seri";
            this.seriColumn.HeaderText = "Số seri";
            this.seriColumn.Name = "seriColumn";
            // 
            // tongtienColumn
            // 
            this.tongtienColumn.DataPropertyName = "tongtien";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.tongtienColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.tongtienColumn.HeaderText = "Tổng tiền";
            this.tongtienColumn.Name = "tongtienColumn";
            // 
            // danhboColumn
            // 
            this.danhboColumn.DataPropertyName = "madanhbo";
            this.danhboColumn.HeaderText = "Danh bộ";
            this.danhboColumn.Name = "danhboColumn";
            // 
            // hotenKHColumn
            // 
            this.hotenKHColumn.DataPropertyName = "hoten_KH";
            this.hotenKHColumn.HeaderText = "Họ tên";
            this.hotenKHColumn.Name = "hotenKHColumn";
            // 
            // sonhaColumn
            // 
            this.sonhaColumn.DataPropertyName = "sonha";
            this.sonhaColumn.HeaderText = "Số nhà";
            this.sonhaColumn.Name = "sonhaColumn";
            // 
            // diachiColumn
            // 
            this.diachiColumn.DataPropertyName = "diachi";
            this.diachiColumn.HeaderText = "Đường";
            this.diachiColumn.Name = "diachiColumn";
            // 
            // phuongColumn
            // 
            this.phuongColumn.DataPropertyName = "tenphuong";
            this.phuongColumn.HeaderText = "Phường";
            this.phuongColumn.Name = "phuongColumn";
            // 
            // quanColumn
            // 
            this.quanColumn.DataPropertyName = "tenquan";
            this.quanColumn.HeaderText = "Quận";
            this.quanColumn.Name = "quanColumn";
            // 
            // frGiayBaoTienNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 440);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frGiayBaoTienNuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIẤY BÁO TIỀN NƯỚC";
            this.Load += new System.EventHandler(this.frGiayBaoTienNuoc_Load);
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
        private System.Windows.Forms.ToolStripButton btnIn;
        private System.Windows.Forms.ToolStripButton excelButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chktrangthai;
        private System.Windows.Forms.ComboBox cboTT;
        private System.Windows.Forms.ComboBox cboPhuong;
        private System.Windows.Forms.ComboBox cboQuan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthaiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtienColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenKHColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sonhaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuongColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quanColumn;
    }
}