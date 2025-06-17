namespace QLCongNo.View.UC.GachNo
{
    partial class UcHoaDon
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
            this.btnLuu = new QLCongNo.View.Core.NovToolStripButton();
            this.btnEX = new QLCongNo.View.Core.NovToolStripButton();
            this.btnDelete = new QLCongNo.View.Core.NovToolStripButton();
            this.btnHuy = new QLCongNo.View.Core.NovToolStripButton();
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.btnTim = new QLCongNo.View.Core.NovToolStripButton();
            this.btnDB = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovGroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.novLabel1 = new QLCongNo.View.Core.NovLabel();
            this.cboNam = new QLCongNo.View.Core.NovComboBox();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.label2 = new QLCongNo.View.Core.NovLabel();
            this.label5 = new QLCongNo.View.Core.NovLabel();
            this.cboKy = new QLCongNo.View.Core.NovComboBox();
            this.txtPath = new QLCongNo.View.Core.NovTextBox();
            this.cboDot = new QLCongNo.View.Core.NovComboBox();
            this.button1 = new QLCongNo.View.Core.NovButton();
            this.linkChonFile = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbltongso = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.DotColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = global::QLCongNo.Properties.Resources.refresh_new;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(5);
            this.btnLuu.Size = new System.Drawing.Size(134, 39);
            this.btnLuu.Text = "Tải dữ liệu";
            // 
            // btnEX
            // 
            this.btnEX.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEX.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnEX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEX.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnEX.Name = "btnEX";
            this.btnEX.Padding = new System.Windows.Forms.Padding(5);
            this.btnEX.Size = new System.Drawing.Size(132, 39);
            this.btnEX.Text = "Xuất Excel";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::QLCongNo.Properties.Resources.delete_new;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
            this.btnDelete.Size = new System.Drawing.Size(78, 39);
            this.btnDelete.Text = "Xóa";
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Padding = new System.Windows.Forms.Padding(5);
            this.btnHuy.Size = new System.Drawing.Size(94, 39);
            this.btnHuy.Text = "Thoát";
            this.btnHuy.Visible = false;
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
            this.btnLuu,
            this.btnDelete,
            this.btnEX,
            this.btnDB,
            this.btnHuy});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MenuItemHeight = 26;
            this.toolStrip1.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip1.Size = new System.Drawing.Size(1189, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(5);
            this.btnTim.Size = new System.Drawing.Size(77, 39);
            this.btnTim.Text = "Tìm";
            // 
            // btnDB
            // 
            this.btnDB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDB.Image = global::QLCongNo.Properties.Resources.update;
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnDB.Name = "btnDB";
            this.btnDB.Padding = new System.Windows.Forms.Padding(5);
            this.btnDB.Size = new System.Drawing.Size(197, 39);
            this.btnDB.Text = "Cập nhật hóa đơn";
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1189, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.08327F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.08327F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.08327F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.77294F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.77294F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.20431F));
            this.tableLayoutPanel2.Controls.Add(this.novLabel1, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboNam, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboKy, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPath, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.cboDot, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.button1, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.linkChonFile, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1175, 94);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // novLabel1
            // 
            this.novLabel1.AutoSize = true;
            this.novLabel1.BackColor = System.Drawing.Color.Transparent;
            this.novLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novLabel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.novLabel1.Location = new System.Drawing.Point(330, 10);
            this.novLabel1.Margin = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.novLabel1.Name = "novLabel1";
            this.novLabel1.Size = new System.Drawing.Size(90, 22);
            this.novLabel1.TabIndex = 9;
            this.novLabel1.Text = "Tải lên tệp";
            // 
            // cboNam
            // 
            this.cboNam.BackColor = System.Drawing.Color.White;
            this.cboNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.ForeColor = System.Drawing.Color.Black;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(12, 42);
            this.cboNam.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(82, 33);
            this.cboNam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(224, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Đợt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(118, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tháng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Năm";
            // 
            // cboKy
            // 
            this.cboKy.BackColor = System.Drawing.Color.White;
            this.cboKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKy.ForeColor = System.Drawing.Color.Black;
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(118, 42);
            this.cboKy.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(82, 33);
            this.cboKy.TabIndex = 3;
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.txtPath, 2);
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.ForeColor = System.Drawing.Color.Black;
            this.txtPath.Location = new System.Drawing.Point(330, 42);
            this.txtPath.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(674, 32);
            this.txtPath.TabIndex = 7;
            // 
            // cboDot
            // 
            this.cboDot.BackColor = System.Drawing.Color.White;
            this.cboDot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDot.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDot.ForeColor = System.Drawing.Color.Black;
            this.cboDot.FormattingEnabled = true;
            this.cboDot.Location = new System.Drawing.Point(224, 42);
            this.cboDot.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.cboDot.Name = "cboDot";
            this.cboDot.Size = new System.Drawing.Size(82, 33);
            this.cboDot.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.button1.IconColor = System.Drawing.Color.White;
            this.button1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.button1.IconSize = 1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1018, 39);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 20);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(155, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Chọn File";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // linkChonFile
            // 
            this.linkChonFile.AutoSize = true;
            this.linkChonFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkChonFile.Location = new System.Drawing.Point(679, 10);
            this.linkChonFile.Margin = new System.Windows.Forms.Padding(12, 10, 12, 5);
            this.linkChonFile.Name = "linkChonFile";
            this.linkChonFile.Size = new System.Drawing.Size(78, 22);
            this.linkChonFile.TabIndex = 6;
            this.linkChonFile.TabStop = true;
            this.linkChonFile.Text = "Chọn file";
            this.linkChonFile.Visible = false;
            this.linkChonFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChonFile_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbltongso);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 648);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1189, 40);
            this.panel2.TabIndex = 2;
            // 
            // lbltongso
            // 
            this.lbltongso.AutoSize = true;
            this.lbltongso.Location = new System.Drawing.Point(14, 3);
            this.lbltongso.Name = "lbltongso";
            this.lbltongso.Size = new System.Drawing.Size(75, 23);
            this.lbltongso.TabIndex = 0;
            this.lbltongso.Text = "Tổng số:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.dgvHoaDon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1189, 495);
            this.panel1.TabIndex = 3;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeight = 50;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DotColumn,
            this.KyColumn,
            this.NamColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 0);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1189, 495);
            this.dgvHoaDon.TabIndex = 6;
            // 
            // DotColumn
            // 
            this.DotColumn.DataPropertyName = "DOT";
            this.DotColumn.HeaderText = "ĐỢT";
            this.DotColumn.MinimumWidth = 6;
            this.DotColumn.Name = "DotColumn";
            this.DotColumn.ReadOnly = true;
            this.DotColumn.Width = 125;
            // 
            // KyColumn
            // 
            this.KyColumn.DataPropertyName = "KY";
            this.KyColumn.HeaderText = "KỲ";
            this.KyColumn.MinimumWidth = 6;
            this.KyColumn.Name = "KyColumn";
            this.KyColumn.ReadOnly = true;
            this.KyColumn.Width = 125;
            // 
            // NamColumn
            // 
            this.NamColumn.DataPropertyName = "NAM";
            this.NamColumn.HeaderText = "NĂM";
            this.NamColumn.MinimumWidth = 6;
            this.NamColumn.Name = "NamColumn";
            this.NamColumn.ReadOnly = true;
            this.NamColumn.Width = 125;
            // 
            // UcHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UcHoaDon";
            this.Size = new System.Drawing.Size(1189, 688);
            this.Load += new System.EventHandler(this.frHoaDon_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStripButton btnLuu;
        private View.Core.NovToolStripButton btnEX;
        private View.Core.NovToolStripButton btnDelete;
        private View.Core.NovToolStripButton btnHuy;
        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovButton button1;
        private View.Core.NovTextBox txtPath;
        private View.Core.NovComboBox cboKy;
        private View.Core.NovComboBox cboDot;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label1;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovComboBox cboNam;
        private View.Core.NovLabel label5;
        private View.Core.NovToolStripButton btnDB;
        private System.Windows.Forms.LinkLabel linkChonFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Core.NovLabel novLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbltongso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DotColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamColumn;
    }
}