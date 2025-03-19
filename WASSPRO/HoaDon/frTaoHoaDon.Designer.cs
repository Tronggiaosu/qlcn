namespace QLCongNo.HoaDon
{
    partial class frTaoHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frTaoHoaDon));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.bdButton = new System.Windows.Forms.ToolStripButton();
            this.excelButton = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPhiNT25 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtTienBVMT = new System.Windows.Forms.TextBox();
            this.txtThueGTGT = new System.Windows.Forms.TextBox();
            this.txttiennuoc = new System.Windows.Forms.TextBox();
            this.txtLNTT = new System.Windows.Forms.TextBox();
            this.txtsoHD = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.cboDot = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTongtien = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.danhboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maltColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.luongtieuthuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiennuocColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienthueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtienColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachButton,
            this.bdButton,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1118, 26);
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
            this.seachButton.Click += new System.EventHandler(this.seachButton_Click);
            // 
            // bdButton
            // 
            this.bdButton.Image = global::QLCongNo.Properties.Resources.phat_hanh_hoa_don_1;
            this.bdButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdButton.Name = "bdButton";
            this.bdButton.Size = new System.Drawing.Size(116, 23);
            this.bdButton.Text = "Tạo hóa đơn";
            this.bdButton.Click += new System.EventHandler(this.bdButton_Click);
            // 
            // excelButton
            // 
            this.excelButton.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.excelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(100, 23);
            this.excelButton.Text = "Xuất Excel";
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
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
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.txtPhiNT25);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Controls.Add(this.txtTienBVMT);
            this.groupBox1.Controls.Add(this.txtThueGTGT);
            this.groupBox1.Controls.Add(this.txttiennuoc);
            this.groupBox1.Controls.Add(this.txtLNTT);
            this.groupBox1.Controls.Add(this.txtsoHD);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboNam);
            this.groupBox1.Controls.Add(this.cboKy);
            this.groupBox1.Controls.Add(this.cboDot);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1118, 112);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // txtPhiNT25
            // 
            this.txtPhiNT25.Enabled = false;
            this.txtPhiNT25.Location = new System.Drawing.Point(936, 43);
            this.txtPhiNT25.Name = "txtPhiNT25";
            this.txtPhiNT25.Size = new System.Drawing.Size(122, 25);
            this.txtPhiNT25.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(948, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 55;
            this.label1.Text = "Phí NT 25%";
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(808, 78);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(250, 25);
            this.txtTongTien.TabIndex = 54;
            // 
            // txtTienBVMT
            // 
            this.txtTienBVMT.Enabled = false;
            this.txtTienBVMT.Location = new System.Drawing.Point(808, 45);
            this.txtTienBVMT.Name = "txtTienBVMT";
            this.txtTienBVMT.Size = new System.Drawing.Size(122, 25);
            this.txtTienBVMT.TabIndex = 53;
            // 
            // txtThueGTGT
            // 
            this.txtThueGTGT.Enabled = false;
            this.txtThueGTGT.Location = new System.Drawing.Point(681, 45);
            this.txtThueGTGT.Name = "txtThueGTGT";
            this.txtThueGTGT.Size = new System.Drawing.Size(121, 25);
            this.txtThueGTGT.TabIndex = 52;
            // 
            // txttiennuoc
            // 
            this.txttiennuoc.Enabled = false;
            this.txttiennuoc.Location = new System.Drawing.Point(547, 45);
            this.txttiennuoc.Name = "txttiennuoc";
            this.txttiennuoc.Size = new System.Drawing.Size(127, 25);
            this.txttiennuoc.TabIndex = 51;
            // 
            // txtLNTT
            // 
            this.txtLNTT.Enabled = false;
            this.txtLNTT.Location = new System.Drawing.Point(418, 45);
            this.txtLNTT.Name = "txtLNTT";
            this.txtLNTT.Size = new System.Drawing.Size(122, 25);
            this.txtLNTT.TabIndex = 50;
            // 
            // txtsoHD
            // 
            this.txtsoHD.Enabled = false;
            this.txtsoHD.Location = new System.Drawing.Point(312, 45);
            this.txtsoHD.Name = "txtsoHD";
            this.txtsoHD.Size = new System.Drawing.Size(100, 25);
            this.txtsoHD.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(418, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 17);
            this.label10.TabIndex = 48;
            this.label10.Text = "LNTT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(736, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 47;
            this.label9.Text = "Tổng tiền";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(820, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 17);
            this.label8.TabIndex = 46;
            this.label8.Text = "Phí NT 20%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(681, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = "Tiền Thuế GTGT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(547, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "Tiền Nước";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Số lượng HĐ";
            // 
            // cboNam
            // 
            this.cboNam.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(32, 43);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(81, 27);
            this.cboNam.TabIndex = 42;
            // 
            // cboKy
            // 
            this.cboKy.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(119, 43);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(89, 27);
            this.cboKy.TabIndex = 41;
            // 
            // cboDot
            // 
            this.cboDot.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDot.FormattingEnabled = true;
            this.cboDot.Location = new System.Drawing.Point(214, 43);
            this.cboDot.Name = "cboDot";
            this.cboDot.Size = new System.Drawing.Size(79, 27);
            this.cboDot.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Năm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(119, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 17);
            this.label11.TabIndex = 38;
            this.label11.Text = "Tháng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(214, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "Đợt";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTongtien});
            this.statusStrip1.Location = new System.Drawing.Point(0, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1118, 22);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTongtien
            // 
            this.lblTongtien.ForeColor = System.Drawing.Color.Blue;
            this.lblTongtien.Name = "lblTongtien";
            this.lblTongtien.Size = new System.Drawing.Size(118, 17);
            this.lblTongtien.Text = "toolStripStatusLabel1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.danhboColumn,
            this.hotenColumn,
            this.maltColumn,
            this.luongtieuthuColumn,
            this.tiennuocColumn,
            this.tienthueColumn,
            this.tienBVMT,
            this.tongtienColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1118, 508);
            this.dataGridView1.TabIndex = 27;
            // 
            // danhboColumn
            // 
            this.danhboColumn.DataPropertyName = "danhbo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.danhboColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.danhboColumn.HeaderText = "Danh bộ";
            this.danhboColumn.Name = "danhboColumn";
            this.danhboColumn.ReadOnly = true;
            this.danhboColumn.Width = 78;
            // 
            // hotenColumn
            // 
            this.hotenColumn.DataPropertyName = "hoten";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.hotenColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.hotenColumn.HeaderText = "Họ tên";
            this.hotenColumn.Name = "hotenColumn";
            this.hotenColumn.ReadOnly = true;
            this.hotenColumn.Width = 69;
            // 
            // maltColumn
            // 
            this.maltColumn.DataPropertyName = "malt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.maltColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.maltColumn.HeaderText = "Mã LT";
            this.maltColumn.Name = "maltColumn";
            this.maltColumn.ReadOnly = true;
            this.maltColumn.Width = 65;
            // 
            // luongtieuthuColumn
            // 
            this.luongtieuthuColumn.DataPropertyName = "m3tieuthu";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.luongtieuthuColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.luongtieuthuColumn.HeaderText = "LNTT";
            this.luongtieuthuColumn.Name = "luongtieuthuColumn";
            this.luongtieuthuColumn.ReadOnly = true;
            this.luongtieuthuColumn.Width = 69;
            // 
            // tiennuocColumn
            // 
            this.tiennuocColumn.DataPropertyName = "tongtien0vat";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.tiennuocColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.tiennuocColumn.HeaderText = "Tiền nước";
            this.tiennuocColumn.Name = "tiennuocColumn";
            this.tiennuocColumn.ReadOnly = true;
            this.tiennuocColumn.Width = 89;
            // 
            // tienthueColumn
            // 
            this.tienthueColumn.DataPropertyName = "tienvat";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.tienthueColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.tienthueColumn.HeaderText = "Tiền thuế GTGT";
            this.tienthueColumn.Name = "tienthueColumn";
            this.tienthueColumn.ReadOnly = true;
            this.tienthueColumn.Width = 120;
            // 
            // tienBVMT
            // 
            this.tienBVMT.DataPropertyName = "tienbvmt";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.tienBVMT.DefaultCellStyle = dataGridViewCellStyle7;
            this.tienBVMT.HeaderText = "Tiền BVMT";
            this.tienBVMT.Name = "tienBVMT";
            this.tienBVMT.ReadOnly = true;
            this.tienBVMT.Width = 95;
            // 
            // tongtienColumn
            // 
            this.tongtienColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tongtienColumn.DataPropertyName = "tongtien";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.tongtienColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.tongtienColumn.HeaderText = "Tổng tiền";
            this.tongtienColumn.Name = "tongtienColumn";
            this.tongtienColumn.ReadOnly = true;
            // 
            // frTaoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 668);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frTaoHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo hóa đơn";
            this.Load += new System.EventHandler(this.frTaoHoaDon_Load);
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
        private System.Windows.Forms.ToolStripButton bdButton;
        private System.Windows.Forms.ToolStripButton excelButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtTienBVMT;
        private System.Windows.Forms.TextBox txtThueGTGT;
        private System.Windows.Forms.TextBox txttiennuoc;
        private System.Windows.Forms.TextBox txtLNTT;
        private System.Windows.Forms.TextBox txtsoHD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.ComboBox cboDot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTongtien;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPhiNT25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maltColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn luongtieuthuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiennuocColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienthueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtienColumn;
    }
}