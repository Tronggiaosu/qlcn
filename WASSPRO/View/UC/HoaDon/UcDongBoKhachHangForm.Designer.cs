namespace QLCongNo.View.UC.HoaDon
{
    partial class UcDongBoKhachHangForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.seachButton = new QLCongNo.View.Core.NovToolStripButton();
            this.btnDB = new QLCongNo.View.Core.NovToolStripButton();
            this.quitButton = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovPanel();
            this.txtTim = new QLCongNo.View.Core.NovTextBox();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.dataGridView1 = new QLCongNo.View.Core.NovDataGridView();
            this.DanhboColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.TenKhachHangColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.diachiColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.MaLTColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.DotColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.IDKHColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.seachButton,
            this.btnDB,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MenuItemHeight = 26;
            this.toolStrip1.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStrip1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip1.Size = new System.Drawing.Size(1068, 45);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seachButton
            // 
            this.seachButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.seachButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seachButton.ForeColor = System.Drawing.Color.White;
            this.seachButton.Image = global::QLCongNo.Properties.Resources.lay_danh_sach;
            this.seachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seachButton.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.seachButton.Name = "seachButton";
            this.seachButton.Padding = new System.Windows.Forms.Padding(5);
            this.seachButton.Size = new System.Drawing.Size(165, 39);
            this.seachButton.Text = "Lấy danh sách";
            this.seachButton.Click += new System.EventHandler(this.seachButton_Click);
            // 
            // btnDB
            // 
            this.btnDB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDB.Image = global::QLCongNo.Properties.Resources.sync;
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnDB.Name = "btnDB";
            this.btnDB.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnDB.Size = new System.Drawing.Size(149, 39);
            this.btnDB.Text = "Đồng bộ";
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // quitButton
            // 
            this.quitButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.quitButton.Name = "quitButton";
            this.quitButton.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.quitButton.Size = new System.Drawing.Size(124, 39);
            this.quitButton.Text = "Thoát";
            this.quitButton.Visible = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1068, 68);
            this.groupBox1.TabIndex = 1;
            // 
            // txtTim
            // 
            this.txtTim.BackColor = System.Drawing.Color.White;
            this.txtTim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.ForeColor = System.Drawing.Color.Black;
            this.txtTim.Location = new System.Drawing.Point(120, 18);
            this.txtTim.Margin = new System.Windows.Forms.Padding(0, 0, 0, 14);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(310, 32);
            this.txtTim.TabIndex = 1;
            this.txtTim.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtTim_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh bộ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhboColumn,
            this.TenKhachHangColumn,
            this.diachiColumn,
            this.MaLTColumn,
            this.DotColumn,
            this.IDKHColumn});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridView1.Location = new System.Drawing.Point(0, 113);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1068, 643);
            this.dataGridView1.TabIndex = 2;
            // 
            // DanhboColumn
            // 
            this.DanhboColumn.DataPropertyName = "madanhbo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.DanhboColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.DanhboColumn.HeaderText = "Danh bộ";
            this.DanhboColumn.MinimumWidth = 6;
            this.DanhboColumn.Name = "DanhboColumn";
            this.DanhboColumn.ReadOnly = true;
            this.DanhboColumn.Width = 205;
            // 
            // TenKhachHangColumn
            // 
            this.TenKhachHangColumn.DataPropertyName = "hoten_KH";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.TenKhachHangColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.TenKhachHangColumn.HeaderText = "Tên khách hàng";
            this.TenKhachHangColumn.MinimumWidth = 6;
            this.TenKhachHangColumn.Name = "TenKhachHangColumn";
            this.TenKhachHangColumn.ReadOnly = true;
            this.TenKhachHangColumn.Width = 205;
            // 
            // diachiColumn
            // 
            this.diachiColumn.DataPropertyName = "diachi";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.diachiColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.diachiColumn.HeaderText = "Địa chỉ";
            this.diachiColumn.MinimumWidth = 6;
            this.diachiColumn.Name = "diachiColumn";
            this.diachiColumn.ReadOnly = true;
            this.diachiColumn.Width = 205;
            // 
            // MaLTColumn
            // 
            this.MaLTColumn.DataPropertyName = "maLT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.MaLTColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.MaLTColumn.HeaderText = "Mã lộ trình";
            this.MaLTColumn.MinimumWidth = 6;
            this.MaLTColumn.Name = "MaLTColumn";
            this.MaLTColumn.ReadOnly = true;
            this.MaLTColumn.Width = 205;
            // 
            // DotColumn
            // 
            this.DotColumn.DataPropertyName = "dotid";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.DotColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.DotColumn.HeaderText = "Đợt";
            this.DotColumn.MinimumWidth = 6;
            this.DotColumn.Name = "DotColumn";
            this.DotColumn.ReadOnly = true;
            this.DotColumn.Width = 205;
            // 
            // IDKHColumn
            // 
            this.IDKHColumn.DataPropertyName = "ID_KH";
            this.IDKHColumn.HeaderText = "IDKH";
            this.IDKHColumn.MinimumWidth = 6;
            this.IDKHColumn.Name = "IDKHColumn";
            this.IDKHColumn.ReadOnly = true;
            this.IDKHColumn.Visible = false;
            this.IDKHColumn.Width = 77;
            // 
            // UcDongBoKhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UcDongBoKhachHangForm";
            this.Size = new System.Drawing.Size(1068, 756);
            this.Load += new System.EventHandler(this.DongBoKhachHangForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton seachButton;
        private View.Core.NovToolStripButton btnDB;
        private View.Core.NovToolStripButton quitButton;
        private View.Core.NovPanel groupBox1;
        private View.Core.NovTextBox txtTim;
        private View.Core.NovLabel label1;
        private View.Core.NovDataGridView dataGridView1;
        private Core.NovDataGridViewTextBoxColumn DanhboColumn;
        private Core.NovDataGridViewTextBoxColumn TenKhachHangColumn;
        private Core.NovDataGridViewTextBoxColumn diachiColumn;
        private Core.NovDataGridViewTextBoxColumn MaLTColumn;
        private Core.NovDataGridViewTextBoxColumn DotColumn;
        private Core.NovDataGridViewTextBoxColumn IDKHColumn;
    }
}