namespace QLCongNo.View.UC.GachNo
{
    partial class UcDongBoThanhToanThuHo
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
            this.seachButton = new QLCongNo.View.Core.NovToolStripButton();
            this.btnDB = new QLCongNo.View.Core.NovToolStripButton();
            this.excelButton = new QLCongNo.View.Core.NovToolStripButton();
            this.quitButton = new QLCongNo.View.Core.NovToolStripButton();
            this.groupBox1 = new QLCongNo.View.Core.NovGroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTim = new QLCongNo.View.Core.NovTextBox();
            this.dtpdenngay = new QLCongNo.View.Core.NovDateTimePicker();
            this.label6 = new QLCongNo.View.Core.NovLabel();
            this.label8 = new QLCongNo.View.Core.NovLabel();
            this.label9 = new QLCongNo.View.Core.NovLabel();
            this.dateTimePicker1 = new QLCongNo.View.Core.NovDateTimePicker();
            this.statusStrip1 = new QLCongNo.View.Core.NovStatusStrip();
            this.dataGridView1 = new QLCongNo.View.Core.NovDataGridView();
            this.STTColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.DanhBoColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.KyHDColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.TongTienColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.NgayThanhToanColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.IDHDColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MenuItemHeight = 26;
            this.toolStrip1.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip1.Size = new System.Drawing.Size(1214, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seachButton
            // 
            this.seachButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnDB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDB.Image = global::QLCongNo.Properties.Resources.sync;
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnDB.Name = "btnDB";
            this.btnDB.Padding = new System.Windows.Forms.Padding(5);
            this.btnDB.Size = new System.Drawing.Size(111, 39);
            this.btnDB.Text = "Đồng bộ";
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // excelButton
            // 
            this.excelButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelButton.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.excelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.excelButton.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.excelButton.Name = "excelButton";
            this.excelButton.Padding = new System.Windows.Forms.Padding(5);
            this.excelButton.Size = new System.Drawing.Size(132, 39);
            this.excelButton.Text = "Xuất Excel";
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.quitButton.Name = "quitButton";
            this.quitButton.Padding = new System.Windows.Forms.Padding(5);
            this.quitButton.Size = new System.Drawing.Size(94, 39);
            this.quitButton.Text = "Thoát";
            this.quitButton.Visible = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1214, 136);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.txtTim, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpdenngay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(820, 86);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // txtTim
            // 
            this.txtTim.BackColor = System.Drawing.Color.White;
            this.txtTim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.ForeColor = System.Drawing.Color.Black;
            this.txtTim.Location = new System.Drawing.Point(340, 48);
            this.txtTim.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(468, 32);
            this.txtTim.TabIndex = 5;
            this.txtTim.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtTim_PreviewKeyDown);
            // 
            // dtpdenngay
            // 
            this.dtpdenngay.CustomFormat = "dd/MM/yyyy";
            this.dtpdenngay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdenngay.Location = new System.Drawing.Point(176, 48);
            this.dtpdenngay.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.dtpdenngay.Name = "dtpdenngay";
            this.dtpdenngay.Size = new System.Drawing.Size(140, 30);
            this.dtpdenngay.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(340, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tìm kiếm theo mã danh bộ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MediumBlue;
            this.label8.Location = new System.Drawing.Point(12, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Từ ngày";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MediumBlue;
            this.label9.Location = new System.Drawing.Point(176, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(12, 14, 12, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Đến ngày";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 48);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(12, 5, 12, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 30);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ForeColor = System.Drawing.Color.MediumBlue;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 905);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 15, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1214, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
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
            this.STTColumn,
            this.DanhBoColumn,
            this.KyHDColumn,
            this.TongTienColumn,
            this.NgayThanhToanColumn,
            this.IDHDColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridView1.Location = new System.Drawing.Point(20, 173);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1174, 727);
            this.dataGridView1.TabIndex = 2;
            // 
            // STTColumn
            // 
            this.STTColumn.HeaderText = "STT";
            this.STTColumn.MinimumWidth = 6;
            this.STTColumn.Name = "STTColumn";
            // 
            // DanhBoColumn
            // 
            this.DanhBoColumn.DataPropertyName = "DanhBo";
            this.DanhBoColumn.HeaderText = "Danh bộ";
            this.DanhBoColumn.MinimumWidth = 6;
            this.DanhBoColumn.Name = "DanhBoColumn";
            // 
            // KyHDColumn
            // 
            this.KyHDColumn.DataPropertyName = "TenKy";
            this.KyHDColumn.HeaderText = "Kỳ hóa đơn";
            this.KyHDColumn.MinimumWidth = 6;
            this.KyHDColumn.Name = "KyHDColumn";
            // 
            // TongTienColumn
            // 
            this.TongTienColumn.DataPropertyName = "TongTien";
            this.TongTienColumn.HeaderText = "Tổng tiền";
            this.TongTienColumn.MinimumWidth = 6;
            this.TongTienColumn.Name = "TongTienColumn";
            // 
            // NgayThanhToanColumn
            // 
            this.NgayThanhToanColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayThanhToanColumn.DataPropertyName = "NgayThanhToan";
            this.NgayThanhToanColumn.HeaderText = "Ngày thanh toán";
            this.NgayThanhToanColumn.MinimumWidth = 6;
            this.NgayThanhToanColumn.Name = "NgayThanhToanColumn";
            // 
            // IDHDColumn
            // 
            this.IDHDColumn.DataPropertyName = "ID_HD";
            this.IDHDColumn.HeaderText = "IDHD";
            this.IDHDColumn.MinimumWidth = 6;
            this.IDHDColumn.Name = "IDHDColumn";
            this.IDHDColumn.Visible = false;
            // 
            // UcDongBoThanhToanThuHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UcDongBoThanhToanThuHo";
            this.Size = new System.Drawing.Size(1214, 927);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton seachButton;
        private View.Core.NovToolStripButton btnDB;
        private View.Core.NovToolStripButton excelButton;
        private View.Core.NovToolStripButton quitButton;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovLabel label8;
        private View.Core.NovDateTimePicker dtpdenngay;
        private View.Core.NovLabel label9;
        private View.Core.NovDateTimePicker dateTimePicker1;
        private View.Core.NovTextBox txtTim;
        private View.Core.NovLabel label6;
        private View.Core.NovStatusStrip statusStrip1;
        private View.Core.NovDataGridView dataGridView1;
        private View.Core.NovDataGridViewTextBoxColumn STTColumn;
        private View.Core.NovDataGridViewTextBoxColumn DanhBoColumn;
        private View.Core.NovDataGridViewTextBoxColumn KyHDColumn;
        private View.Core.NovDataGridViewTextBoxColumn TongTienColumn;
        private View.Core.NovDataGridViewTextBoxColumn NgayThanhToanColumn;
        private View.Core.NovDataGridViewTextBoxColumn IDHDColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}