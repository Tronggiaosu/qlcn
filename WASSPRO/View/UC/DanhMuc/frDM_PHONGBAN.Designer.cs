namespace QLCongNo.View.UC.DanhMuc
{
    partial class UcDM_PHONGBAN
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
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.btnThem = new View.Core.NovToolStripButton();
            this.btnSua = new View.Core.NovToolStripButton();
            this.btnThoat = new View.Core.NovToolStripButton();
            this.btnHuy = new View.Core.NovToolStripButton();
            this.groupBox1 = new View.Core.NovGroupBox();
            this.cboCN = new View.Core.NovComboBox();
            this.label2 = new View.Core.NovLabel();
            this.label3 = new View.Core.NovLabel();
            this.label4 = new View.Core.NovLabel();
            this.label1 = new View.Core.NovLabel();
            this.txtGhichu = new View.Core.NovTextBox();
            this.txtTenPB = new View.Core.NovTextBox();
            this.txtmaPB = new View.Core.NovTextBox();
            this.panel1 = new View.Core.NovPanel();
            this.dataGridView1 = new View.Core.NovDataGridView();
            this.MaPhongColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.TenphongColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.mota = new View.Core.NovDataGridViewTextBoxColumn();
            this.DotITColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.CHINHANH = new View.Core.NovDataGridViewTextBoxColumn();
            this.CHINHANH1 = new View.Core.NovDataGridViewTextBoxColumn();
            this.CHINHANH2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.DM_TO = new View.Core.NovDataGridViewTextBoxColumn();
            this.NHANVIENs = new View.Core.NovDataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnSua,
            this.btnHuy,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::QLCongNo.Properties.Resources._010_LowPriority_16x16_72;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(63, 22);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::QLCongNo.Properties.Resources._126_Edit_24x24_72;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(51, 22);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::QLCongNo.Properties.Resources._1385_Disable_16x16_72;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(64, 22);
            this.btnThoat.Text = "Thoát";
            // 
            // btnHuy
            // 
            this.btnHuy.Image = global::QLCongNo.Properties.Resources._private;
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(53, 22);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGhichu);
            this.groupBox1.Controls.Add(this.txtTenPB);
            this.groupBox1.Controls.Add(this.txtmaPB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cboCN
            // 
            this.cboCN.FormattingEnabled = true;
            this.cboCN.Location = new System.Drawing.Point(181, 15);
            this.cboCN.Name = "cboCN";
            this.cboCN.Size = new System.Drawing.Size(272, 24);
            this.cboCN.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(476, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ghi chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chi nhánh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(102, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tên phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã phòng";
            // 
            // txtGhichu
            // 
            this.txtGhichu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhichu.Location = new System.Drawing.Point(534, 12);
            this.txtGhichu.Multiline = true;
            this.txtGhichu.Name = "txtGhichu";
            this.txtGhichu.Size = new System.Drawing.Size(356, 50);
            this.txtGhichu.TabIndex = 2;
            // 
            // txtTenPB
            // 
            this.txtTenPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPB.Location = new System.Drawing.Point(181, 73);
            this.txtTenPB.Name = "txtTenPB";
            this.txtTenPB.Size = new System.Drawing.Size(272, 22);
            this.txtTenPB.TabIndex = 3;
            // 
            // txtmaPB
            // 
            this.txtmaPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmaPB.Location = new System.Drawing.Point(181, 45);
            this.txtmaPB.Name = "txtmaPB";
            this.txtmaPB.Size = new System.Drawing.Size(272, 22);
            this.txtmaPB.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 275);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhongColumn,
            this.TenphongColumn,
            this.mota,
            this.DotITColumn,
            this.CHINHANH,
            this.CHINHANH1,
            this.CHINHANH2,
            this.DM_TO,
            this.NHANVIENs});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(918, 275);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowEnter += new View.Core.NovDataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // MaPhongColumn
            // 
            this.MaPhongColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaPhongColumn.DataPropertyName = "maPB";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MaPhongColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.MaPhongColumn.HeaderText = "Mã phòng";
            this.MaPhongColumn.Name = "MaPhongColumn";
            this.MaPhongColumn.ReadOnly = true;
            this.MaPhongColumn.Width = 80;
            // 
            // TenphongColumn
            // 
            this.TenphongColumn.DataPropertyName = "tenPB";
            this.TenphongColumn.HeaderText = "Tên phòng";
            this.TenphongColumn.Name = "TenphongColumn";
            this.TenphongColumn.ReadOnly = true;
            // 
            // mota
            // 
            this.mota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mota.DataPropertyName = "mota";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mota.DefaultCellStyle = dataGridViewCellStyle2;
            this.mota.HeaderText = "Ghi chú";
            this.mota.Name = "mota";
            this.mota.ReadOnly = true;
            this.mota.Width = 69;
            // 
            // DotITColumn
            // 
            this.DotITColumn.DataPropertyName = "maCN";
            this.DotITColumn.HeaderText = "maCN";
            this.DotITColumn.Name = "DotITColumn";
            this.DotITColumn.ReadOnly = true;
            this.DotITColumn.Visible = false;
            // 
            // CHINHANH
            // 
            this.CHINHANH.DataPropertyName = "CHINHANH";
            this.CHINHANH.HeaderText = "CHINHANH";
            this.CHINHANH.Name = "CHINHANH";
            this.CHINHANH.Visible = false;
            // 
            // CHINHANH1
            // 
            this.CHINHANH1.DataPropertyName = "CHINHANH1";
            this.CHINHANH1.HeaderText = "CHINHANH1";
            this.CHINHANH1.Name = "CHINHANH1";
            this.CHINHANH1.Visible = false;
            // 
            // CHINHANH2
            // 
            this.CHINHANH2.DataPropertyName = "CHINHANH2";
            this.CHINHANH2.HeaderText = "CHINHANH2";
            this.CHINHANH2.Name = "CHINHANH2";
            this.CHINHANH2.Visible = false;
            // 
            // DM_TO
            // 
            this.DM_TO.DataPropertyName = "DM_TO";
            this.DM_TO.HeaderText = "DM_TO";
            this.DM_TO.Name = "DM_TO";
            this.DM_TO.Visible = false;
            // 
            // NHANVIENs
            // 
            this.NHANVIENs.DataPropertyName = "NHANVIENs";
            this.NHANVIENs.HeaderText = "NHANVIENs";
            this.NHANVIENs.Name = "NHANVIENs";
            this.NHANVIENs.Visible = false;
            // 
            // frDM_PHONGBAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 410);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frDM_PHONGBAN";
            this.Text = "DANH MỤC PHÒNG BAN";
            this.Load += new System.EventHandler(this.frDM_PHONGBAN_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnThem;
        private View.Core.NovToolStripButton btnSua;
        private View.Core.NovToolStripButton btnThoat;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovComboBox cboCN;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label3;
        private View.Core.NovLabel label1;
        private View.Core.NovTextBox txtGhichu;
        private View.Core.NovTextBox txtmaPB;
        private View.Core.NovPanel panel1;
        private View.Core.NovDataGridView dataGridView1;
        private View.Core.NovLabel label4;
        private View.Core.NovTextBox txtTenPB;
        private View.Core.NovDataGridViewTextBoxColumn MaPhongColumn;
        private View.Core.NovDataGridViewTextBoxColumn TenphongColumn;
        private View.Core.NovDataGridViewTextBoxColumn mota;
        private View.Core.NovDataGridViewTextBoxColumn DotITColumn;
        private View.Core.NovDataGridViewTextBoxColumn CHINHANH;
        private View.Core.NovDataGridViewTextBoxColumn CHINHANH1;
        private View.Core.NovDataGridViewTextBoxColumn CHINHANH2;
        private View.Core.NovDataGridViewTextBoxColumn DM_TO;
        private View.Core.NovDataGridViewTextBoxColumn NHANVIENs;
        private View.Core.NovToolStripButton btnHuy;
    }
}