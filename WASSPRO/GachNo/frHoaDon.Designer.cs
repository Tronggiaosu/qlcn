namespace QLCongNo.GachNo
{
    partial class frHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frHoaDon));
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnEX = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnDB = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboKy = new System.Windows.Forms.ComboBox();
            this.cboDot = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbltongso = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.linkChonFile = new System.Windows.Forms.LinkLabel();
            this.NAMColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dotcolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::QLCongNo.Properties.Resources.refresh_new;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(101, 23);
            this.btnLuu.Text = "Tải dữ liệu";
            // 
            // btnEX
            // 
            this.btnEX.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnEX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEX.Name = "btnEX";
            this.btnEX.Size = new System.Drawing.Size(100, 23);
            this.btnEX.Text = "Xuất Excel";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::QLCongNo.Properties.Resources.delete_new;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 23);
            this.btnDelete.Text = "Xóa";
            // 
            // btnHuy
            // 
            this.btnHuy.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(69, 23);
            this.btnHuy.Text = "Thoát";
            this.btnHuy.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnLuu,
            this.btnDelete,
            this.btnEX,
            this.btnDB,
            this.btnHuy});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(981, 26);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(54, 23);
            this.btnTim.Text = "Tìm";
            // 
            // btnDB
            // 
            this.btnDB.Image = global::QLCongNo.Properties.Resources.update;
            this.btnDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(152, 23);
            this.btnDB.Text = "Cập nhật hóa đơn";
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkChonFile);
            this.groupBox1.Controls.Add(this.cboNam);
            this.groupBox1.Controls.Add(this.cboKy);
            this.groupBox1.Controls.Add(this.cboDot);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(981, 97);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // cboNam
            // 
            this.cboNam.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(35, 47);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(81, 30);
            this.cboNam.TabIndex = 36;
            // 
            // cboKy
            // 
            this.cboKy.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKy.FormattingEnabled = true;
            this.cboKy.Location = new System.Drawing.Point(122, 47);
            this.cboKy.Name = "cboKy";
            this.cboKy.Size = new System.Drawing.Size(89, 30);
            this.cboKy.TabIndex = 35;
            // 
            // cboDot
            // 
            this.cboDot.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDot.FormattingEnabled = true;
            this.cboDot.Location = new System.Drawing.Point(217, 46);
            this.cboDot.Name = "cboDot";
            this.cboDot.Size = new System.Drawing.Size(79, 30);
            this.cboDot.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 19);
            this.label5.TabIndex = 33;
            this.label5.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tháng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "Đợt";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(813, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Chọn file...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(302, 46);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(505, 30);
            this.txtPath.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbltongso});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(981, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbltongso
            // 
            this.lbltongso.Name = "lbltongso";
            this.lbltongso.Size = new System.Drawing.Size(118, 17);
            this.lbltongso.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 415);
            this.panel1.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NAMColumn,
            this.KyColumn,
            this.dotcolumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(981, 415);
            this.dataGridView1.TabIndex = 0;
            // 
            // linkChonFile
            // 
            this.linkChonFile.AutoSize = true;
            this.linkChonFile.Location = new System.Drawing.Point(299, 22);
            this.linkChonFile.Name = "linkChonFile";
            this.linkChonFile.Size = new System.Drawing.Size(63, 17);
            this.linkChonFile.TabIndex = 38;
            this.linkChonFile.TabStop = true;
            this.linkChonFile.Text = "Chọn file";
            this.linkChonFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChonFile_LinkClicked);
            // 
            // NAMColumn
            // 
            this.NAMColumn.DataPropertyName = "NAM";
            this.NAMColumn.HeaderText = "NĂM";
            this.NAMColumn.Name = "NAMColumn";
            this.NAMColumn.ReadOnly = true;
            // 
            // KyColumn
            // 
            this.KyColumn.DataPropertyName = "KY";
            this.KyColumn.HeaderText = "THÁNG";
            this.KyColumn.Name = "KyColumn";
            this.KyColumn.ReadOnly = true;
            // 
            // dotcolumn
            // 
            this.dotcolumn.DataPropertyName = "dot";
            this.dotcolumn.HeaderText = "ĐỢT";
            this.dotcolumn.Name = "dotcolumn";
            this.dotcolumn.ReadOnly = true;
            // 
            // frHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DỮ LIỆU HÓA ĐƠN";
            this.Load += new System.EventHandler(this.frHoaDon_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnEX;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ComboBox cboKy;
        private System.Windows.Forms.ComboBox cboDot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel lbltongso;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton btnDB;
        private System.Windows.Forms.LinkLabel linkChonFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAMColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dotcolumn;
    }
}