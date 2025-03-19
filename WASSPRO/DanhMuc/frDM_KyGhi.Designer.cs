namespace QLCongNo.DanhMuc
{
    partial class frDM_KyGhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frDM_KyGhi));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nhanvienColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaycapnhatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenkyghiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_kyghiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSua,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(790, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::QLCongNo.Properties.Resources.update;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(78, 22);
            this.btnSua.Text = "Cập nhật";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(60, 22);
            this.btnThoat.Text = "Thoát";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboNam);
            this.groupBox1.Controls.Add(this.cboKy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 70);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kỳ";
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(390, 21);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(78, 24);
            this.cboNam.TabIndex = 12;
            // 
            // cboKy
            // 
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(244, 21);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(81, 24);
            this.cboKy.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 350);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nhanvienColumn,
            this.ngaycapnhatColumn,
            this.tenkyghiColumn,
            this.NamColumn,
            this.id_kyghiColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(790, 350);
            this.dataGridView1.TabIndex = 0;
            // 
            // nhanvienColumn
            // 
            this.nhanvienColumn.DataPropertyName = "hoten";
            this.nhanvienColumn.HeaderText = "Nhân viên";
            this.nhanvienColumn.Name = "nhanvienColumn";
            this.nhanvienColumn.ReadOnly = true;
            this.nhanvienColumn.Width = 88;
            // 
            // ngaycapnhatColumn
            // 
            this.ngaycapnhatColumn.DataPropertyName = "ngaytao";
            this.ngaycapnhatColumn.HeaderText = "Ngày cập nhật";
            this.ngaycapnhatColumn.Name = "ngaycapnhatColumn";
            this.ngaycapnhatColumn.ReadOnly = true;
            this.ngaycapnhatColumn.Width = 113;
            // 
            // tenkyghiColumn
            // 
            this.tenkyghiColumn.DataPropertyName = "ten_kyghi";
            this.tenkyghiColumn.HeaderText = "Tên kỳ";
            this.tenkyghiColumn.Name = "tenkyghiColumn";
            this.tenkyghiColumn.ReadOnly = true;
            this.tenkyghiColumn.Width = 70;
            // 
            // NamColumn
            // 
            this.NamColumn.DataPropertyName = "nam";
            this.NamColumn.HeaderText = "Năm";
            this.NamColumn.Name = "NamColumn";
            this.NamColumn.ReadOnly = true;
            this.NamColumn.Width = 58;
            // 
            // id_kyghiColumn
            // 
            this.id_kyghiColumn.DataPropertyName = "id_kyghi";
            this.id_kyghiColumn.HeaderText = "ID_Kyghi";
            this.id_kyghiColumn.Name = "id_kyghiColumn";
            this.id_kyghiColumn.ReadOnly = true;
            this.id_kyghiColumn.Visible = false;
            // 
            // frDM_KyGhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 445);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frDM_KyGhi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH MỤC KỲ GHI";
            this.Load += new System.EventHandler(this.frDM_KyGhi_Load);
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

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhanvienColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaycapnhatColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenkyghiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_kyghiColumn;
    }
}