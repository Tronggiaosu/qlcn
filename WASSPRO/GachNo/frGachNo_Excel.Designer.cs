namespace QLCongNo.GachNo
{
    partial class frGachNo_Excel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frGachNo_Excel));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnKiemtra = new System.Windows.Forms.ToolStripButton();
            this.btnEX = new System.Windows.Forms.ToolStripButton();
            this.btnExcelFail = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpNgaythu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsoHD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txttongthanhtoan = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblsoluongthanhtoan = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.danhboColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtienColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaythuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.lblsoluongsai = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKiemtra,
            this.btnEX,
            this.btnExcelFail,
            this.quitButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1342, 26);
            this.toolStrip2.TabIndex = 75;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnKiemtra
            // 
            this.btnKiemtra.Image = global::QLCongNo.Properties.Resources.refresh_new;
            this.btnKiemtra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKiemtra.Name = "btnKiemtra";
            this.btnKiemtra.Size = new System.Drawing.Size(101, 23);
            this.btnKiemtra.Text = "Tải dữ liệu";
            // 
            // btnEX
            // 
            this.btnEX.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnEX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEX.Name = "btnEX";
            this.btnEX.Size = new System.Drawing.Size(164, 23);
            this.btnEX.Text = "Xuất Excel DS Đúng";
            // 
            // btnExcelFail
            // 
            this.btnExcelFail.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnExcelFail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcelFail.Name = "btnExcelFail";
            this.btnExcelFail.Size = new System.Drawing.Size(203, 23);
            this.btnExcelFail.Text = "Xuất excel DS Chưa Đúng";
            // 
            // quitButton
            // 
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(69, 23);
            this.quitButton.Text = "Thoát";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.btnFile);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1342, 72);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(33, 26);
            this.btnFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(107, 27);
            this.btnFile.TabIndex = 1;
            this.btnFile.Text = "Chọn file...";
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(160, 27);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(418, 26);
            this.txtPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Controls.Add(this.dtpNgaythu);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboNH);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtsoHD);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtghichu);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txttongthanhtoan);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 98);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1342, 316);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            // 
            // dtpNgaythu
            // 
            this.dtpNgaythu.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaythu.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaythu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaythu.Location = new System.Drawing.Point(160, 27);
            this.dtpNgaythu.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgaythu.Name = "dtpNgaythu";
            this.dtpNgaythu.Size = new System.Drawing.Size(180, 26);
            this.dtpNgaythu.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 99;
            this.label3.Text = "Ngày thu";
            // 
            // cboNH
            // 
            this.cboNH.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNH.FormattingEnabled = true;
            this.cboNH.Location = new System.Drawing.Point(160, 141);
            this.cboNH.Margin = new System.Windows.Forms.Padding(4);
            this.cboNH.Name = "cboNH";
            this.cboNH.Size = new System.Drawing.Size(418, 27);
            this.cboNH.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 97;
            this.label2.Text = "Ngân hàng";
            // 
            // txtsoHD
            // 
            this.txtsoHD.Enabled = false;
            this.txtsoHD.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsoHD.Location = new System.Drawing.Point(160, 64);
            this.txtsoHD.Margin = new System.Windows.Forms.Padding(4);
            this.txtsoHD.Name = "txtsoHD";
            this.txtsoHD.Size = new System.Drawing.Size(180, 26);
            this.txtsoHD.TabIndex = 96;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(43, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 95;
            this.label4.Text = "Số lượng HĐ";
            // 
            // txtghichu
            // 
            this.txtghichu.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtghichu.Location = new System.Drawing.Point(680, 27);
            this.txtghichu.Margin = new System.Windows.Forms.Padding(4);
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(621, 141);
            this.txtghichu.TabIndex = 94;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(602, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 93;
            this.label6.Text = "Ghi chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(40, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 19);
            this.label5.TabIndex = 91;
            this.label5.Text = "Tổng tiền thu";
            // 
            // txttongthanhtoan
            // 
            this.txttongthanhtoan.Enabled = false;
            this.txttongthanhtoan.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttongthanhtoan.Location = new System.Drawing.Point(160, 104);
            this.txttongthanhtoan.Margin = new System.Windows.Forms.Padding(4);
            this.txttongthanhtoan.Name = "txttongthanhtoan";
            this.txttongthanhtoan.Size = new System.Drawing.Size(180, 26);
            this.txttongthanhtoan.TabIndex = 92;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.statusStrip1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 414);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(629, 270);
            this.groupBox3.TabIndex = 78;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách thanh toán";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 23);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(621, 221);
            this.dataGridView1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblsoluongthanhtoan});
            this.statusStrip1.Location = new System.Drawing.Point(4, 244);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 15, 0);
            this.statusStrip1.Size = new System.Drawing.Size(621, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblsoluongthanhtoan
            // 
            this.lblsoluongthanhtoan.Name = "lblsoluongthanhtoan";
            this.lblsoluongthanhtoan.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Controls.Add(this.statusStrip2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(629, 414);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(713, 270);
            this.groupBox4.TabIndex = 79;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách không đúng";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.danhboColumn,
            this.kyHDColumn,
            this.NamColumn,
            this.tongtienColumn,
            this.NgaythuColumn});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(4, 23);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(705, 221);
            this.dataGridView2.TabIndex = 1;
            // 
            // danhboColumn
            // 
            this.danhboColumn.DataPropertyName = "danhbo";
            this.danhboColumn.HeaderText = "Danh Bộ";
            this.danhboColumn.Name = "danhboColumn";
            // 
            // kyHDColumn
            // 
            this.kyHDColumn.DataPropertyName = "kyghi";
            this.kyHDColumn.HeaderText = "Kỳ HĐ";
            this.kyHDColumn.Name = "kyHDColumn";
            // 
            // NamColumn
            // 
            this.NamColumn.DataPropertyName = "nam";
            this.NamColumn.HeaderText = "Năm";
            this.NamColumn.Name = "NamColumn";
            // 
            // tongtienColumn
            // 
            this.tongtienColumn.DataPropertyName = "tongtien";
            this.tongtienColumn.HeaderText = "Tổng tiền";
            this.tongtienColumn.Name = "tongtienColumn";
            // 
            // NgaythuColumn
            // 
            this.NgaythuColumn.DataPropertyName = "ngaythanhtoan";
            this.NgaythuColumn.HeaderText = "Ngày thu";
            this.NgaythuColumn.Name = "NgaythuColumn";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblsoluongsai});
            this.statusStrip2.Location = new System.Drawing.Point(4, 244);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 15, 0);
            this.statusStrip2.Size = new System.Drawing.Size(705, 22);
            this.statusStrip2.TabIndex = 0;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // lblsoluongsai
            // 
            this.lblsoluongsai.Name = "lblsoluongsai";
            this.lblsoluongsai.Size = new System.Drawing.Size(0, 17);
            // 
            // frGachNo_Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 684);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frGachNo_Excel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GẠCH NỢ CHUYỂN KHOẢN";
            this.Load += new System.EventHandler(this.frGachNo_Excel_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnEX;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtsoHD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttongthanhtoan;
        private System.Windows.Forms.ComboBox cboNH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhboColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtienColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaythuColumn;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel lblsoluongthanhtoan;
        private System.Windows.Forms.ToolStripStatusLabel lblsoluongsai;
        private System.Windows.Forms.ToolStripButton btnExcelFail;
        private System.Windows.Forms.DateTimePicker dtpNgaythu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton btnKiemtra;
    }
}