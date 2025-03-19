namespace QLCongNo.View.UC.HoaDon
{
    partial class UcDSNoNhieuKySMS
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
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnExcel = new QLCongNo.View.Core.NovToolStripButton();
            this.btnThoat = new QLCongNo.View.Core.NovToolStripButton();
            this.panel1 = new QLCongNo.View.Core.NovPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbodendot = new QLCongNo.View.Core.NovComboBox();
            this.chkTT = new QLCongNo.View.Core.NovCheckBox();
            this.label2 = new QLCongNo.View.Core.NovLabel();
            this.cboTT = new QLCongNo.View.Core.NovComboBox();
            this.cbotudot = new QLCongNo.View.Core.NovComboBox();
            this.chkTuNgayKhoa = new QLCongNo.View.Core.NovCheckBox();
            this.chkDot = new QLCongNo.View.Core.NovCheckBox();
            this.dateTimePicker2 = new QLCongNo.View.Core.NovDateTimePicker();
            this.txtsoky = new QLCongNo.View.Core.NovTextBox();
            this.dateTimePicker1 = new QLCongNo.View.Core.NovDateTimePicker();
            this.chksoky = new QLCongNo.View.Core.NovCheckBox();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.dgvDSKhachHangNo = new QLCongNo.View.Core.NovDataGridView();
            this.sdtColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.danhboColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.sotienColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKhachHangNo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BorderColor = System.Drawing.Color.Empty;
            this.toolStrip1.BorderThickness = 0;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.IsMainMenu = true;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnExcel,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MenuItemHeight = 26;
            this.toolStrip1.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip1.Size = new System.Drawing.Size(1281, 35);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(4);
            this.btnTim.Size = new System.Drawing.Size(111, 35);
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Padding = new System.Windows.Forms.Padding(4);
            this.btnExcel.Size = new System.Drawing.Size(120, 35);
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(4);
            this.btnThoat.Size = new System.Drawing.Size(86, 35);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Visible = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1281, 139);
            this.panel1.TabIndex = 19;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.cbodendot, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkTT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboTT, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbotudot, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkTuNgayKhoa, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkDot, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtsoky, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.chksoky, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1098, 108);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // cbodendot
            // 
            this.cbodendot.BackColor = System.Drawing.Color.White;
            this.cbodendot.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbodendot.ForeColor = System.Drawing.Color.Black;
            this.cbodendot.FormattingEnabled = true;
            this.cbodendot.Location = new System.Drawing.Point(927, 59);
            this.cbodendot.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cbodendot.Name = "cbodendot";
            this.cbodendot.Size = new System.Drawing.Size(159, 33);
            this.cbodendot.TabIndex = 39;
            // 
            // chkTT
            // 
            this.chkTT.AutoSize = true;
            this.chkTT.BackColor = System.Drawing.Color.Transparent;
            this.chkTT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTT.ForeColor = System.Drawing.Color.MediumBlue;
            this.chkTT.Location = new System.Drawing.Point(12, 5);
            this.chkTT.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.chkTT.Name = "chkTT";
            this.chkTT.Size = new System.Drawing.Size(109, 27);
            this.chkTT.TabIndex = 26;
            this.chkTT.Text = "Trạng thái";
            this.chkTT.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(744, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Đến đợt";
            // 
            // cboTT
            // 
            this.cboTT.BackColor = System.Drawing.Color.White;
            this.cboTT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTT.ForeColor = System.Drawing.Color.Black;
            this.cboTT.FormattingEnabled = true;
            this.cboTT.Location = new System.Drawing.Point(195, 5);
            this.cboTT.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboTT.Name = "cboTT";
            this.cboTT.Size = new System.Drawing.Size(159, 33);
            this.cboTT.TabIndex = 20;
            // 
            // cbotudot
            // 
            this.cbotudot.BackColor = System.Drawing.Color.White;
            this.cbotudot.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbotudot.ForeColor = System.Drawing.Color.Black;
            this.cbotudot.FormattingEnabled = true;
            this.cbotudot.Location = new System.Drawing.Point(561, 59);
            this.cbotudot.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cbotudot.Name = "cbotudot";
            this.cbotudot.Size = new System.Drawing.Size(159, 33);
            this.cbotudot.TabIndex = 37;
            // 
            // chkTuNgayKhoa
            // 
            this.chkTuNgayKhoa.AutoSize = true;
            this.chkTuNgayKhoa.BackColor = System.Drawing.Color.Transparent;
            this.chkTuNgayKhoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTuNgayKhoa.ForeColor = System.Drawing.Color.MediumBlue;
            this.chkTuNgayKhoa.Location = new System.Drawing.Point(378, 5);
            this.chkTuNgayKhoa.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.chkTuNgayKhoa.Name = "chkTuNgayKhoa";
            this.chkTuNgayKhoa.Size = new System.Drawing.Size(159, 27);
            this.chkTuNgayKhoa.TabIndex = 34;
            this.chkTuNgayKhoa.Text = "Từ ngày khóa nước";
            this.chkTuNgayKhoa.UseVisualStyleBackColor = true;
            // 
            // chkDot
            // 
            this.chkDot.AutoSize = true;
            this.chkDot.BackColor = System.Drawing.Color.Transparent;
            this.chkDot.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDot.ForeColor = System.Drawing.Color.MediumBlue;
            this.chkDot.Location = new System.Drawing.Point(378, 59);
            this.chkDot.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.chkDot.Name = "chkDot";
            this.chkDot.Size = new System.Drawing.Size(82, 27);
            this.chkDot.TabIndex = 36;
            this.chkDot.Text = "Từ đợt";
            this.chkDot.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(561, 5);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(159, 30);
            this.dateTimePicker2.TabIndex = 35;
            // 
            // txtsoky
            // 
            this.txtsoky.BackColor = System.Drawing.Color.White;
            this.txtsoky.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsoky.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoky.ForeColor = System.Drawing.Color.Black;
            this.txtsoky.Location = new System.Drawing.Point(195, 59);
            this.txtsoky.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.txtsoky.Name = "txtsoky";
            this.txtsoky.Size = new System.Drawing.Size(159, 32);
            this.txtsoky.TabIndex = 31;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(927, 5);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(159, 30);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // chksoky
            // 
            this.chksoky.AutoSize = true;
            this.chksoky.BackColor = System.Drawing.Color.Transparent;
            this.chksoky.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chksoky.ForeColor = System.Drawing.Color.MediumBlue;
            this.chksoky.Location = new System.Drawing.Point(12, 59);
            this.chksoky.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.chksoky.Name = "chksoky";
            this.chksoky.Size = new System.Drawing.Size(126, 27);
            this.chksoky.TabIndex = 30;
            this.chksoky.Text = "Số tháng nợ";
            this.chksoky.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(744, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 23);
            this.label1.TabIndex = 32;
            this.label1.Text = "Đến ngày";
            // 
            // dgvDSKhachHangNo
            // 
            this.dgvDSKhachHangNo.AllowDrop = true;
            this.dgvDSKhachHangNo.AllowUserToAddRows = false;
            this.dgvDSKhachHangNo.AllowUserToDeleteRows = false;
            this.dgvDSKhachHangNo.AllowUserToOrderColumns = true;
            this.dgvDSKhachHangNo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvDSKhachHangNo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSKhachHangNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSKhachHangNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDSKhachHangNo.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSKhachHangNo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKhachHangNo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSKhachHangNo.ColumnHeadersHeight = 50;
            this.dgvDSKhachHangNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDSKhachHangNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sdtColumn,
            this.danhboColumn,
            this.sotienColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKhachHangNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSKhachHangNo.EnableHeadersVisualStyles = false;
            this.dgvDSKhachHangNo.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDSKhachHangNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvDSKhachHangNo.Location = new System.Drawing.Point(22, 184);
            this.dgvDSKhachHangNo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvDSKhachHangNo.Name = "dgvDSKhachHangNo";
            this.dgvDSKhachHangNo.RowHeadersVisible = false;
            this.dgvDSKhachHangNo.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKhachHangNo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDSKhachHangNo.RowTemplate.Height = 32;
            this.dgvDSKhachHangNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSKhachHangNo.Size = new System.Drawing.Size(1238, 397);
            this.dgvDSKhachHangNo.TabIndex = 29;
            // 
            // sdtColumn
            // 
            this.sdtColumn.DataPropertyName = "sdt";
            this.sdtColumn.HeaderText = "Số điện thoại";
            this.sdtColumn.MinimumWidth = 6;
            this.sdtColumn.Name = "sdtColumn";
            this.sdtColumn.ReadOnly = true;
            this.sdtColumn.Width = 127;
            // 
            // danhboColumn
            // 
            this.danhboColumn.DataPropertyName = "DANHBO";
            this.danhboColumn.HeaderText = "Số danh bộ";
            this.danhboColumn.MinimumWidth = 6;
            this.danhboColumn.Name = "danhboColumn";
            this.danhboColumn.ReadOnly = true;
            this.danhboColumn.Width = 116;
            // 
            // sotienColumn
            // 
            this.sotienColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sotienColumn.DataPropertyName = "sotien";
            this.sotienColumn.HeaderText = "Số tiền";
            this.sotienColumn.MinimumWidth = 6;
            this.sotienColumn.Name = "sotienColumn";
            this.sotienColumn.ReadOnly = true;
            // 
            // UcDSNoNhieuKySMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDSKhachHangNo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "UcDSNoNhieuKySMS";
            this.Size = new System.Drawing.Size(1281, 603);
            this.Load += new System.EventHandler(this.frDSNoNhieuKySMS_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKhachHangNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnExcel;
        private View.Core.NovToolStripButton btnThoat;
        private View.Core.NovPanel panel1;
        private View.Core.NovDateTimePicker dateTimePicker1;
        private View.Core.NovLabel label1;
        private View.Core.NovTextBox txtsoky;
        private View.Core.NovCheckBox chksoky;
        private View.Core.NovDataGridView dgvDSKhachHangNo;
        private View.Core.NovCheckBox chkTT;
        private View.Core.NovComboBox cboTT;
        private View.Core.NovDateTimePicker dateTimePicker2;
        private View.Core.NovCheckBox chkTuNgayKhoa;
        private View.Core.NovComboBox cbotudot;
        private View.Core.NovCheckBox chkDot;
        private View.Core.NovComboBox cbodendot;
        private View.Core.NovLabel label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Core.NovDataGridViewTextBoxColumn sdtColumn;
        private Core.NovDataGridViewTextBoxColumn danhboColumn;
        private Core.NovDataGridViewTextBoxColumn sotienColumn;
    }
}