namespace QLCongNo.HoaDon
{
    partial class DongBoKhachHangForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DongBoKhachHangForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DanhboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHangColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DotColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDKHColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachButton,
            this.btnDB,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(950, 26);
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
            this.seachButton.Click += new System.EventHandler(this.seachButton_Click);
            // 
            // btnDB
            // 
            this.btnDB.Image = global::QLCongNo.Properties.Resources.sync;
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(88, 23);
            this.btnDB.Text = "Đồng bộ";
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
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
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 87);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(105, 22);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(350, 30);
            this.txtTim.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Danh bộ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhboColumn,
            this.TenKhachHangColumn,
            this.diachiColumn,
            this.MaLTColumn,
            this.DotColumn,
            this.IDKHColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(950, 446);
            this.dataGridView1.TabIndex = 27;
            // 
            // DanhboColumn
            // 
            this.DanhboColumn.DataPropertyName = "madanhbo";
            this.DanhboColumn.HeaderText = "Danh bộ";
            this.DanhboColumn.Name = "DanhboColumn";
            this.DanhboColumn.Width = 120;
            // 
            // TenKhachHangColumn
            // 
            this.TenKhachHangColumn.DataPropertyName = "hoten_KH";
            this.TenKhachHangColumn.HeaderText = "Tên khách hàng";
            this.TenKhachHangColumn.Name = "TenKhachHangColumn";
            this.TenKhachHangColumn.Width = 250;
            // 
            // diachiColumn
            // 
            this.diachiColumn.DataPropertyName = "diachi";
            this.diachiColumn.HeaderText = "Địa chỉ";
            this.diachiColumn.Name = "diachiColumn";
            this.diachiColumn.Width = 250;
            // 
            // MaLTColumn
            // 
            this.MaLTColumn.DataPropertyName = "maLT";
            this.MaLTColumn.HeaderText = "Mã LT";
            this.MaLTColumn.Name = "MaLTColumn";
            // 
            // DotColumn
            // 
            this.DotColumn.DataPropertyName = "dotid";
            this.DotColumn.HeaderText = "Đợt";
            this.DotColumn.Name = "DotColumn";
            // 
            // IDKHColumn
            // 
            this.IDKHColumn.DataPropertyName = "ID_KH";
            this.IDKHColumn.HeaderText = "IDKH";
            this.IDKHColumn.Name = "IDKHColumn";
            this.IDKHColumn.Visible = false;
            // 
            // DongBoKhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 559);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "DongBoKhachHangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đồng bộ khách hàng";
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

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton seachButton;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHangColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DotColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDKHColumn;
    }
}