namespace QLCongNo.View.UC.HoaDon
{
    partial class UcKyGhi
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
            this.dataGridView1 = new QLCongNo.View.Core.NovDataGridView();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.label2 = new QLCongNo.View.Core.NovLabel();
            this.label3 = new QLCongNo.View.Core.NovLabel();
            this.label4 = new QLCongNo.View.Core.NovLabel();
            this.label5 = new QLCongNo.View.Core.NovLabel();
            this.txtIDKyghi = new QLCongNo.View.Core.NovTextBox();
            this.txtTenkyghi = new QLCongNo.View.Core.NovTextBox();
            this.txtThang = new QLCongNo.View.Core.NovTextBox();
            this.txtNam = new QLCongNo.View.Core.NovTextBox();
            this.DtNgaytao = new QLCongNo.View.Core.NovDateTimePicker();
            this.chkGhiNuoc = new QLCongNo.View.Core.NovCheckBox();
            this.closeButton = new QLCongNo.View.Core.NovButton();
            this.editButton = new QLCongNo.View.Core.NovButton();
            this.addButton = new QLCongNo.View.Core.NovButton();
            this.novPanel1 = new QLCongNo.View.Core.NovPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ID_kyghi = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.ten_kyghi = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.thang = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.nam = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.ngaytao = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.clmGachNo = new QLCongNo.View.Core.NovDataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.novPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_kyghi,
            this.ten_kyghi,
            this.thang,
            this.nam,
            this.ngaytao,
            this.clmGachNo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridView1.Location = new System.Drawing.Point(19, 174);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1309, 513);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã tháng ghi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(452, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Năm";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(672, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tháng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(892, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ngày tạo";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(232, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tháng ghi";
            // 
            // txtIDKyghi
            // 
            this.txtIDKyghi.BackColor = System.Drawing.Color.White;
            this.txtIDKyghi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDKyghi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIDKyghi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDKyghi.ForeColor = System.Drawing.Color.Black;
            this.txtIDKyghi.Location = new System.Drawing.Point(12, 54);
            this.txtIDKyghi.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.txtIDKyghi.Name = "txtIDKyghi";
            this.txtIDKyghi.Size = new System.Drawing.Size(196, 32);
            this.txtIDKyghi.TabIndex = 1;
            // 
            // txtTenkyghi
            // 
            this.txtTenkyghi.BackColor = System.Drawing.Color.White;
            this.txtTenkyghi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenkyghi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenkyghi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenkyghi.ForeColor = System.Drawing.Color.Black;
            this.txtTenkyghi.Location = new System.Drawing.Point(232, 54);
            this.txtTenkyghi.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.txtTenkyghi.Name = "txtTenkyghi";
            this.txtTenkyghi.Size = new System.Drawing.Size(196, 32);
            this.txtTenkyghi.TabIndex = 3;
            // 
            // txtThang
            // 
            this.txtThang.BackColor = System.Drawing.Color.White;
            this.txtThang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtThang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.ForeColor = System.Drawing.Color.Black;
            this.txtThang.Location = new System.Drawing.Point(672, 54);
            this.txtThang.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(196, 32);
            this.txtThang.TabIndex = 7;
            // 
            // txtNam
            // 
            this.txtNam.BackColor = System.Drawing.Color.White;
            this.txtNam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNam.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.ForeColor = System.Drawing.Color.Black;
            this.txtNam.Location = new System.Drawing.Point(452, 54);
            this.txtNam.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(196, 32);
            this.txtNam.TabIndex = 5;
            // 
            // DtNgaytao
            // 
            this.DtNgaytao.CustomFormat = "dd/MM/yyyy";
            this.DtNgaytao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtNgaytao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtNgaytao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtNgaytao.Location = new System.Drawing.Point(892, 54);
            this.DtNgaytao.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.DtNgaytao.Name = "DtNgaytao";
            this.DtNgaytao.Size = new System.Drawing.Size(196, 30);
            this.DtNgaytao.TabIndex = 9;
            // 
            // chkGhiNuoc
            // 
            this.chkGhiNuoc.AutoSize = true;
            this.chkGhiNuoc.BackColor = System.Drawing.Color.Transparent;
            this.chkGhiNuoc.Checked = true;
            this.chkGhiNuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGhiNuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkGhiNuoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGhiNuoc.ForeColor = System.Drawing.Color.MediumBlue;
            this.chkGhiNuoc.Location = new System.Drawing.Point(1118, 54);
            this.chkGhiNuoc.Margin = new System.Windows.Forms.Padding(18, 5, 12, 14);
            this.chkGhiNuoc.Name = "chkGhiNuoc";
            this.chkGhiNuoc.Size = new System.Drawing.Size(191, 28);
            this.chkGhiNuoc.TabIndex = 10;
            this.chkGhiNuoc.Text = "Hóa đơn";
            this.chkGhiNuoc.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.closeButton.IconColor = System.Drawing.Color.White;
            this.closeButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.closeButton.IconSize = 1;
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(710, 3);
            this.closeButton.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.closeButton.Name = "closeButton";
            this.closeButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.closeButton.Size = new System.Drawing.Size(150, 43);
            this.closeButton.TabIndex = 13;
            this.closeButton.Text = "Thoát";
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // editButton
            // 
            this.editButton.AutoSize = true;
            this.editButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.editButton.IconColor = System.Drawing.Color.White;
            this.editButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.editButton.IconSize = 16;
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editButton.Location = new System.Drawing.Point(177, 3);
            this.editButton.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.editButton.Name = "editButton";
            this.editButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.editButton.Size = new System.Drawing.Size(150, 43);
            this.editButton.TabIndex = 12;
            this.editButton.Text = "Sửa";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.addButton.IconColor = System.Drawing.Color.White;
            this.addButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.addButton.IconSize = 16;
            this.addButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addButton.Location = new System.Drawing.Point(14, 3);
            this.addButton.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.addButton.Name = "addButton";
            this.addButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.addButton.Size = new System.Drawing.Size(145, 43);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Thêm";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // novPanel1
            // 
            this.novPanel1.BackColor = System.Drawing.Color.Transparent;
            this.novPanel1.Controls.Add(this.addButton);
            this.novPanel1.Controls.Add(this.editButton);
            this.novPanel1.Controls.Add(this.closeButton);
            this.novPanel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novPanel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.novPanel1.Location = new System.Drawing.Point(7, 14);
            this.novPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.novPanel1.Name = "novPanel1";
            this.novPanel1.Size = new System.Drawing.Size(865, 49);
            this.novPanel1.TabIndex = 15;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtIDKyghi, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkGhiNuoc, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DtNgaytao, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTenkyghi, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtThang, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNam, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 70);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.08333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.91667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1321, 96);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // ID_kyghi
            // 
            this.ID_kyghi.DataPropertyName = "Id_kyghi";
            this.ID_kyghi.HeaderText = "Mã tháng ghi";
            this.ID_kyghi.MinimumWidth = 6;
            this.ID_kyghi.Name = "ID_kyghi";
            this.ID_kyghi.ReadOnly = true;
            // 
            // ten_kyghi
            // 
            this.ten_kyghi.DataPropertyName = "ten_kyghi";
            this.ten_kyghi.HeaderText = "Tháng ghi";
            this.ten_kyghi.MinimumWidth = 6;
            this.ten_kyghi.Name = "ten_kyghi";
            this.ten_kyghi.ReadOnly = true;
            // 
            // thang
            // 
            this.thang.DataPropertyName = "thang";
            this.thang.HeaderText = "Tháng";
            this.thang.MinimumWidth = 6;
            this.thang.Name = "thang";
            this.thang.ReadOnly = true;
            this.thang.Visible = false;
            // 
            // nam
            // 
            this.nam.DataPropertyName = "nam";
            this.nam.HeaderText = "Năm";
            this.nam.MinimumWidth = 6;
            this.nam.Name = "nam";
            this.nam.ReadOnly = true;
            this.nam.Visible = false;
            // 
            // ngaytao
            // 
            this.ngaytao.DataPropertyName = "ngaytao";
            this.ngaytao.HeaderText = "Ngày tạo";
            this.ngaytao.MinimumWidth = 6;
            this.ngaytao.Name = "ngaytao";
            this.ngaytao.ReadOnly = true;
            // 
            // clmGachNo
            // 
            this.clmGachNo.DataPropertyName = "hoadon";
            this.clmGachNo.HeaderText = "Hóa đơn";
            this.clmGachNo.MinimumWidth = 6;
            this.clmGachNo.Name = "clmGachNo";
            this.clmGachNo.ReadOnly = true;
            // 
            // UcKyGhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.novPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UcKyGhi";
            this.Size = new System.Drawing.Size(1344, 708);
            this.Load += new System.EventHandler(this.KyGhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.novPanel1.ResumeLayout(false);
            this.novPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private View.Core.NovDataGridView dataGridView1;
        private View.Core.NovLabel label1;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label3;
        private View.Core.NovLabel label4;
        private View.Core.NovLabel label5;
        private View.Core.NovTextBox txtIDKyghi;
        private View.Core.NovTextBox txtTenkyghi;
        private View.Core.NovTextBox txtThang;
        private View.Core.NovTextBox txtNam;
        private View.Core.NovDateTimePicker DtNgaytao;
        private View.Core.NovButton closeButton;
        private View.Core.NovButton editButton;
        private View.Core.NovButton addButton;
        private View.Core.NovCheckBox chkGhiNuoc;
        private Core.NovPanel novPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Core.NovDataGridViewTextBoxColumn ID_kyghi;
        private Core.NovDataGridViewTextBoxColumn ten_kyghi;
        private Core.NovDataGridViewTextBoxColumn thang;
        private Core.NovDataGridViewTextBoxColumn nam;
        private Core.NovDataGridViewTextBoxColumn ngaytao;
        private Core.NovDataGridViewCheckBoxColumn clmGachNo;
    }
}