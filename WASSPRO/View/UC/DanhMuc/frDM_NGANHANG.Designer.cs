namespace QLCongNo.View.UC.DanhMuc
{
    partial class UcDM_NGANHANG
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
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.btnThem = new View.Core.NovToolStripButton();
            this.btnHuy = new View.Core.NovToolStripButton();
            this.btnSua = new View.Core.NovToolStripButton();
            this.toolStripButton2 = new View.Core.NovToolStripButton();
            this.groupBox1 = new View.Core.NovGroupBox();
            this.label3 = new View.Core.NovLabel();
            this.txtTenNH = new View.Core.NovTextBox();
            this.label2 = new View.Core.NovLabel();
            this.label1 = new View.Core.NovLabel();
            this.txtLoai = new View.Core.NovTextBox();
            this.txtMaNH = new View.Core.NovTextBox();
            this.dataGridView1 = new View.Core.NovDataGridView();
            this.DotITColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.Ma_Nganhang = new View.Core.NovDataGridViewTextBoxColumn();
            this.TenNHColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.loai11 = new View.Core.NovDataGridViewTextBoxColumn();
            this.madv = new View.Core.NovDataGridViewTextBoxColumn();
            this.KHACHHANGs = new View.Core.NovDataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnHuy,
            this.btnSua,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(720, 25);
            this.toolStrip1.TabIndex = 1;
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
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
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
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = global::QLCongNo.Properties.Resources._1385_Disable_16x16_72;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(64, 22);
            this.toolStripButton2.Text = "Thoát";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenNH);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLoai);
            this.groupBox1.Controls.Add(this.txtMaNH);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên ngân hàng";
            // 
            // txtTenNH
            // 
            this.txtTenNH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNH.Location = new System.Drawing.Point(144, 57);
            this.txtTenNH.Name = "txtTenNH";
            this.txtTenNH.Size = new System.Drawing.Size(492, 22);
            this.txtTenNH.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(366, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã ngân hàng";
            // 
            // txtLoai
            // 
            this.txtLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoai.Location = new System.Drawing.Point(409, 24);
            this.txtLoai.Multiline = true;
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Size = new System.Drawing.Size(227, 23);
            this.txtLoai.TabIndex = 0;
            // 
            // txtMaNH
            // 
            this.txtMaNH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNH.Location = new System.Drawing.Point(144, 25);
            this.txtMaNH.Name = "txtMaNH";
            this.txtMaNH.Size = new System.Drawing.Size(172, 22);
            this.txtMaNH.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DotITColumn,
            this.Ma_Nganhang,
            this.TenNHColumn,
            this.loai11,
            this.madv,
            this.KHACHHANGs});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(720, 256);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowEnter += new View.Core.NovDataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // DotITColumn
            // 
            this.DotITColumn.DataPropertyName = "NGANHANG_ID";
            this.DotITColumn.HeaderText = "STT";
            this.DotITColumn.Name = "DotITColumn";
            this.DotITColumn.ReadOnly = true;
            // 
            // Ma_Nganhang
            // 
            this.Ma_Nganhang.DataPropertyName = "MA_NGANHANG";
            this.Ma_Nganhang.HeaderText = "Mã ngân hàng";
            this.Ma_Nganhang.Name = "Ma_Nganhang";
            // 
            // TenNHColumn
            // 
            this.TenNHColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenNHColumn.DataPropertyName = "TENNGANHANG";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TenNHColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.TenNHColumn.HeaderText = "Tên ngân hàng";
            this.TenNHColumn.Name = "TenNHColumn";
            this.TenNHColumn.ReadOnly = true;
            this.TenNHColumn.Width = 96;
            // 
            // loai11
            // 
            this.loai11.DataPropertyName = "LOAI";
            this.loai11.HeaderText = "Loại";
            this.loai11.Name = "loai11";
            // 
            // madv
            // 
            this.madv.DataPropertyName = "MADV";
            this.madv.HeaderText = "madv";
            this.madv.Name = "madv";
            this.madv.Visible = false;
            // 
            // KHACHHANGs
            // 
            this.KHACHHANGs.DataPropertyName = "KHACHHANGs";
            this.KHACHHANGs.HeaderText = "KHACHHANGs";
            this.KHACHHANGs.Name = "KHACHHANGs";
            this.KHACHHANGs.Visible = false;
            // 
            // frDM_NGANHANG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 401);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frDM_NGANHANG";
            this.Text = "DANH MỤC NGÂN HÀNG";
            this.Load += new System.EventHandler(this.frDM_NGANHANG_Load);
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
        private View.Core.NovToolStripButton btnThem;
        private View.Core.NovToolStripButton btnSua;
        private View.Core.NovToolStripButton toolStripButton2;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label1;
        private View.Core.NovTextBox txtLoai;
        private View.Core.NovTextBox txtMaNH;
        private View.Core.NovDataGridView dataGridView1;
        private View.Core.NovLabel label3;
        private View.Core.NovTextBox txtTenNH;
        private View.Core.NovDataGridViewTextBoxColumn loai;
        private View.Core.NovDataGridViewTextBoxColumn DotITColumn;
        private View.Core.NovDataGridViewTextBoxColumn Ma_Nganhang;
        private View.Core.NovDataGridViewTextBoxColumn TenNHColumn;
        private View.Core.NovDataGridViewTextBoxColumn loai11;
        private View.Core.NovDataGridViewTextBoxColumn madv;
        private View.Core.NovDataGridViewTextBoxColumn KHACHHANGs;
        private View.Core.NovToolStripButton btnHuy;
    }
}