namespace QLCongNo.FORM
{
    partial class UcGachNo_TaiQuay
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
            this.label1 = new View.Core.NovLabel();
            this.groupBox6 = new View.Core.NovGroupBox();
            this.dgvCT = new View.Core.NovDataGridView();
            this.kyhd_dgv2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.tongtien_dgv2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.hoten_KHdgv2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.madanhbo_dgv2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.diachi_dgv2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.id_hd_dgv2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.ID_KH = new View.Core.NovDataGridViewTextBoxColumn();
            this.groupBox3 = new View.Core.NovGroupBox();
            this.dgvHD = new View.Core.NovDataGridView();
            this.kyghiColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.tongtienColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.hoten_KH_Column = new View.Core.NovDataGridViewTextBoxColumn();
            this.madanhboColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.diachiColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.ID_HD_dgv1 = new View.Core.NovDataGridViewTextBoxColumn();
            this.ID_KH_dgv1 = new View.Core.NovDataGridViewTextBoxColumn();
            this.txtTim = new View.Core.NovTextBox();
            this.cboLT = new View.Core.NovComboBox();
            this.toolStrip2 = new View.Core.NovToolStrip();
            this.btnThanhtoan = new View.Core.NovToolStripButton();
            this.btnTim = new View.Core.NovToolStripButton();
            this.btnHuy = new View.Core.NovToolStripButton();
            this.btnEX = new View.Core.NovToolStripButton();
            this.quitButton = new View.Core.NovToolStripButton();
            this.groupBox1 = new View.Core.NovGroupBox();
            this.dtpNgaythu = new View.Core.NovDateTimePicker();
            this.label2 = new View.Core.NovLabel();
            this.txttong_HD = new View.Core.NovTextBox();
            this.label10 = new View.Core.NovLabel();
            this.label5 = new View.Core.NovLabel();
            this.txtghichu = new View.Core.NovTextBox();
            this.txtTongthu = new View.Core.NovTextBox();
            this.label8 = new View.Core.NovLabel();
            this.groupBox2 = new View.Core.NovGroupBox();
            this.chkLT = new View.Core.NovCheckBox();
            this.chkkyghi = new View.Core.NovCheckBox();
            this.cboKyghi = new View.Core.NovComboBox();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            //this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tìm kiếm";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvCT);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox6.Location = new System.Drawing.Point(528, 198);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(517, 388);
            this.groupBox6.TabIndex = 84;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Danh sách gạch nợ";
            // 
            // dgvCT
            // 
            this.dgvCT.AllowUserToAddRows = false;
            this.dgvCT.AllowUserToDeleteRows = false;
            this.dgvCT.AllowUserToOrderColumns = true;
            this.dgvCT.AllowUserToResizeColumns = false;
            this.dgvCT.AllowUserToResizeRows = false;
            this.dgvCT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kyhd_dgv2,
            this.tongtien_dgv2,
            this.hoten_KHdgv2,
            this.madanhbo_dgv2,
            this.diachi_dgv2,
            this.id_hd_dgv2,
            this.ID_KH});
            this.dgvCT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCT.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvCT.Location = new System.Drawing.Point(3, 18);
            this.dgvCT.Name = "dgvCT";
            this.dgvCT.ReadOnly = true;
            this.dgvCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCT.Size = new System.Drawing.Size(511, 367);
            this.dgvCT.TabIndex = 28;
            // 
            // kyhd_dgv2
            // 
            this.kyhd_dgv2.DataPropertyName = "ten_kyghi";
            this.kyhd_dgv2.HeaderText = "Kỳ hóa đơn";
            this.kyhd_dgv2.Name = "kyhd_dgv2";
            this.kyhd_dgv2.ReadOnly = true;
            // 
            // tongtien_dgv2
            // 
            this.tongtien_dgv2.DataPropertyName = "tongtien";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.tongtien_dgv2.DefaultCellStyle = dataGridViewCellStyle1;
            this.tongtien_dgv2.HeaderText = "Tổng tiền";
            this.tongtien_dgv2.Name = "tongtien_dgv2";
            this.tongtien_dgv2.ReadOnly = true;
            this.tongtien_dgv2.Width = 89;
            // 
            // hoten_KHdgv2
            // 
            this.hoten_KHdgv2.DataPropertyName = "hoten_KH";
            this.hoten_KHdgv2.HeaderText = "Họ tên";
            this.hoten_KHdgv2.Name = "hoten_KHdgv2";
            this.hoten_KHdgv2.ReadOnly = true;
            this.hoten_KHdgv2.Width = 72;
            // 
            // madanhbo_dgv2
            // 
            this.madanhbo_dgv2.DataPropertyName = "madanhbo";
            this.madanhbo_dgv2.HeaderText = "Mã danh bộ";
            this.madanhbo_dgv2.Name = "madanhbo_dgv2";
            this.madanhbo_dgv2.ReadOnly = true;
            this.madanhbo_dgv2.Visible = false;
            this.madanhbo_dgv2.Width = 104;
            // 
            // diachi_dgv2
            // 
            this.diachi_dgv2.HeaderText = "Địa chỉ";
            this.diachi_dgv2.Name = "diachi_dgv2";
            this.diachi_dgv2.ReadOnly = true;
            this.diachi_dgv2.Visible = false;
            this.diachi_dgv2.Width = 73;
            // 
            // id_hd_dgv2
            // 
            this.id_hd_dgv2.DataPropertyName = "ID_HD";
            this.id_hd_dgv2.HeaderText = "Column1";
            this.id_hd_dgv2.Name = "id_hd_dgv2";
            this.id_hd_dgv2.ReadOnly = true;
            this.id_hd_dgv2.Visible = false;
            this.id_hd_dgv2.Width = 85;
            // 
            // ID_KH
            // 
            this.ID_KH.DataPropertyName = "ID_KH";
            this.ID_KH.HeaderText = "ID_KH";
            this.ID_KH.Name = "ID_KH";
            this.ID_KH.ReadOnly = true;
            this.ID_KH.Visible = false;
            this.ID_KH.Width = 71;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvHD);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.groupBox3.Location = new System.Drawing.Point(0, 198);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1045, 388);
            this.groupBox3.TabIndex = 85;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách hóa đơn chưa thanh toán";
            // 
            // dgvHD
            // 
            this.dgvHD.AllowUserToAddRows = false;
            this.dgvHD.AllowUserToDeleteRows = false;
            this.dgvHD.AllowUserToOrderColumns = true;
            this.dgvHD.AllowUserToResizeColumns = false;
            this.dgvHD.AllowUserToResizeRows = false;
            this.dgvHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            this.dgvHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kyghiColumn,
            this.tongtienColumn,
            this.hoten_KH_Column,
            this.madanhboColumn,
            this.diachiColumn,
            this.ID_HD_dgv1,
            this.ID_KH_dgv1});
            this.dgvHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHD.Location = new System.Drawing.Point(3, 18);
            this.dgvHD.Name = "dgvHD";
            this.dgvHD.ReadOnly = true;
            this.dgvHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHD.Size = new System.Drawing.Size(1039, 367);
            this.dgvHD.TabIndex = 25;
            // 
            // kyghiColumn
            // 
            this.kyghiColumn.DataPropertyName = "ten_kyghi";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kyghiColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.kyghiColumn.HeaderText = "Kỳ hóa đơn";
            this.kyghiColumn.Name = "kyghiColumn";
            this.kyghiColumn.ReadOnly = true;
            // 
            // tongtienColumn
            // 
            this.tongtienColumn.DataPropertyName = "tongtien";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.tongtienColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tongtienColumn.HeaderText = "Tổng tiền";
            this.tongtienColumn.Name = "tongtienColumn";
            this.tongtienColumn.ReadOnly = true;
            this.tongtienColumn.Width = 89;
            // 
            // hoten_KH_Column
            // 
            this.hoten_KH_Column.DataPropertyName = "hoten_KH";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.hoten_KH_Column.DefaultCellStyle = dataGridViewCellStyle4;
            this.hoten_KH_Column.HeaderText = "Họ tên";
            this.hoten_KH_Column.Name = "hoten_KH_Column";
            this.hoten_KH_Column.ReadOnly = true;
            this.hoten_KH_Column.Width = 72;
            // 
            // madanhboColumn
            // 
            this.madanhboColumn.DataPropertyName = "madanhbo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.madanhboColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.madanhboColumn.HeaderText = "Mã danh bộ";
            this.madanhboColumn.Name = "madanhboColumn";
            this.madanhboColumn.ReadOnly = true;
            this.madanhboColumn.Visible = false;
            this.madanhboColumn.Width = 104;
            // 
            // diachiColumn
            // 
            this.diachiColumn.DataPropertyName = "diachi";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.diachiColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.diachiColumn.HeaderText = "Địa chỉ";
            this.diachiColumn.Name = "diachiColumn";
            this.diachiColumn.ReadOnly = true;
            this.diachiColumn.Visible = false;
            this.diachiColumn.Width = 73;
            // 
            // ID_HD_dgv1
            // 
            this.ID_HD_dgv1.DataPropertyName = "ID_HD";
            this.ID_HD_dgv1.HeaderText = "Column1";
            this.ID_HD_dgv1.Name = "ID_HD_dgv1";
            this.ID_HD_dgv1.ReadOnly = true;
            this.ID_HD_dgv1.Visible = false;
            this.ID_HD_dgv1.Width = 85;
            // 
            // ID_KH_dgv1
            // 
            this.ID_KH_dgv1.DataPropertyName = "id_kh";
            this.ID_KH_dgv1.HeaderText = "ID_KH";
            this.ID_KH_dgv1.Name = "ID_KH_dgv1";
            this.ID_KH_dgv1.ReadOnly = true;
            this.ID_KH_dgv1.Visible = false;
            this.ID_KH_dgv1.Width = 71;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(196, 48);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(332, 22);
            this.txtTim.TabIndex = 1;
            // 
            // cboLT
            // 
            this.cboLT.FormattingEnabled = true;
            this.cboLT.Location = new System.Drawing.Point(446, 21);
            this.cboLT.Name = "cboLT";
            this.cboLT.Size = new System.Drawing.Size(266, 24);
            this.cboLT.TabIndex = 5;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStrip2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThanhtoan,
            this.btnTim,
            this.btnHuy,
            this.btnEX,
            this.quitButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1045, 25);
            this.toolStrip2.TabIndex = 81;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.Image = global::QLCongNo.Properties.Resources._042b_AddCategory_24x24_72;
            this.btnThanhtoan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(116, 22);
            this.btnThanhtoan.Text = "Lập phiếu thu";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources._2392_ZoomIn_48x48;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(52, 22);
            this.btnTim.Text = "Tìm";
            // 
            // btnHuy
            // 
            this.btnHuy.Image = global::QLCongNo.Properties.Resources._112_RefreshArrow_Blue_24x24_72;
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(76, 22);
            this.btnHuy.Text = "Refresh";
            // 
            // btnEX
            // 
            this.btnEX.Image = global::QLCongNo.Properties.Resources.Excel;
            this.btnEX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEX.Name = "btnEX";
            this.btnEX.Size = new System.Drawing.Size(96, 22);
            this.btnEX.Text = "Xuất Excel";
            // 
            // quitButton
            // 
            this.quitButton.Image = global::QLCongNo.Properties.Resources.delete1;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(64, 22);
            this.quitButton.Text = "Thoát";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.dtpNgaythu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txttong_HD);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtghichu);
            this.groupBox1.Controls.Add(this.txtTongthu);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1045, 87);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Biên nhận";
            // 
            // dtpNgaythu
            // 
            this.dtpNgaythu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaythu.Location = new System.Drawing.Point(523, 25);
            this.dtpNgaythu.Name = "dtpNgaythu";
            this.dtpNgaythu.Size = new System.Drawing.Size(177, 22);
            this.dtpNgaythu.TabIndex = 102;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(457, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 101;
            this.label2.Text = "Ngày thu";
            // 
            // txttong_HD
            // 
            this.txttong_HD.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttong_HD.Location = new System.Drawing.Point(195, 22);
            this.txttong_HD.Name = "txttong_HD";
            this.txttong_HD.Size = new System.Drawing.Size(221, 25);
            this.txttong_HD.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(75, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 16);
            this.label10.TabIndex = 96;
            this.label10.Text = "Số lượng hóa đơn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(132, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 93;
            this.label5.Text = "Tổng thu";
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(523, 54);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(404, 22);
            this.txtghichu.TabIndex = 97;
            // 
            // txtTongthu
            // 
            this.txtTongthu.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongthu.Location = new System.Drawing.Point(195, 53);
            this.txtTongthu.Name = "txtTongthu";
            this.txtTongthu.Size = new System.Drawing.Size(142, 25);
            this.txtTongthu.TabIndex = 94;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(464, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 95;
            this.label8.Text = "Ghi chú";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.txtTim);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboLT);
            this.groupBox2.Controls.Add(this.chkLT);
            this.groupBox2.Controls.Add(this.chkkyghi);
            this.groupBox2.Controls.Add(this.cboKyghi);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1045, 86);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // chkLT
            // 
            this.chkLT.AutoSize = true;
            this.chkLT.Location = new System.Drawing.Point(371, 21);
            this.chkLT.Name = "chkLT";
            this.chkLT.Size = new System.Drawing.Size(69, 20);
            this.chkLT.TabIndex = 4;
            this.chkLT.Text = "Lộ trình";
            this.chkLT.UseVisualStyleBackColor = true;
            // 
            // chkkyghi
            // 
            this.chkkyghi.AutoSize = true;
            this.chkkyghi.Location = new System.Drawing.Point(96, 21);
            this.chkkyghi.Name = "chkkyghi";
            this.chkkyghi.Size = new System.Drawing.Size(94, 20);
            this.chkkyghi.TabIndex = 3;
            this.chkkyghi.Text = "Kỳ hóa đơn";
            this.chkkyghi.UseVisualStyleBackColor = true;
            // 
            // cboKyghi
            // 
            this.cboKyghi.FormattingEnabled = true;
            this.cboKyghi.Location = new System.Drawing.Point(196, 21);
            this.cboKyghi.Name = "cboKyghi";
            this.cboKyghi.Size = new System.Drawing.Size(137, 24);
            this.cboKyghi.TabIndex = 3;
            // 
            // frGachNo_TaiQuay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 586);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "frGachNo_TaiQuay";
            this.Text = "GẠCH NỢ TẠI QUẦY";
            this.Load += new System.EventHandler(this.frGachNo_TaiQuay_Load);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovLabel label1;
        private View.Core.NovGroupBox groupBox6;
        private View.Core.NovDataGridView dgvCT;
        private View.Core.NovGroupBox groupBox3;
        private View.Core.NovDataGridView dgvHD;
        private View.Core.NovTextBox txtTim;
        private View.Core.NovComboBox cboLT;
        private View.Core.NovToolStrip toolStrip2;
        private View.Core.NovToolStripButton btnThanhtoan;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnHuy;
        private View.Core.NovToolStripButton btnEX;
        private View.Core.NovToolStripButton quitButton;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovDateTimePicker dtpNgaythu;
        private View.Core.NovLabel label2;
        private View.Core.NovTextBox txttong_HD;
        private View.Core.NovLabel label10;
        private View.Core.NovLabel label5;
        private View.Core.NovTextBox txtghichu;
        private View.Core.NovTextBox txtTongthu;
        private View.Core.NovLabel label8;
        private View.Core.NovGroupBox groupBox2;
        private View.Core.NovCheckBox chkLT;
        private View.Core.NovCheckBox chkkyghi;
        private View.Core.NovComboBox cboKyghi;
        private View.Core.NovDataGridViewTextBoxColumn kyhd_dgv2;
        private View.Core.NovDataGridViewTextBoxColumn tongtien_dgv2;
        private View.Core.NovDataGridViewTextBoxColumn hoten_KHdgv2;
        private View.Core.NovDataGridViewTextBoxColumn madanhbo_dgv2;
        private View.Core.NovDataGridViewTextBoxColumn diachi_dgv2;
        private View.Core.NovDataGridViewTextBoxColumn id_hd_dgv2;
        private View.Core.NovDataGridViewTextBoxColumn ID_KH;
        private View.Core.NovDataGridViewTextBoxColumn kyghiColumn;
        private View.Core.NovDataGridViewTextBoxColumn tongtienColumn;
        private View.Core.NovDataGridViewTextBoxColumn hoten_KH_Column;
        private View.Core.NovDataGridViewTextBoxColumn madanhboColumn;
        private View.Core.NovDataGridViewTextBoxColumn diachiColumn;
        private View.Core.NovDataGridViewTextBoxColumn ID_HD_dgv1;
        private View.Core.NovDataGridViewTextBoxColumn ID_KH_dgv1;
    }
}