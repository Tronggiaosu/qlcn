namespace QLCongNo
{
    partial class KyGhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KyGhi));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_kyghi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_kyghi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaytao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGachNo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIDKyghi = new System.Windows.Forms.TextBox();
            this.txtTenkyghi = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.DtNgaytao = new System.Windows.Forms.DateTimePicker();
            this.chkGhiNuoc = new System.Windows.Forms.CheckBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_kyghi,
            this.ten_kyghi,
            this.thang,
            this.nam,
            this.ngaytao,
            this.clmGachNo});
            this.dataGridView1.Location = new System.Drawing.Point(32, 206);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(815, 364);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // ID_kyghi
            // 
            this.ID_kyghi.DataPropertyName = "Id_kyghi";
            this.ID_kyghi.HeaderText = "Mã Kỳ Ghi";
            this.ID_kyghi.Name = "ID_kyghi";
            this.ID_kyghi.ReadOnly = true;
            // 
            // ten_kyghi
            // 
            this.ten_kyghi.DataPropertyName = "ten_kyghi";
            this.ten_kyghi.HeaderText = "Tên Kỳ Ghi";
            this.ten_kyghi.Name = "ten_kyghi";
            this.ten_kyghi.ReadOnly = true;
            // 
            // thang
            // 
            this.thang.DataPropertyName = "thang";
            this.thang.HeaderText = "Tháng";
            this.thang.Name = "thang";
            this.thang.ReadOnly = true;
            this.thang.Visible = false;
            // 
            // nam
            // 
            this.nam.DataPropertyName = "nam";
            this.nam.HeaderText = "Năm";
            this.nam.Name = "nam";
            this.nam.ReadOnly = true;
            this.nam.Visible = false;
            // 
            // ngaytao
            // 
            this.ngaytao.DataPropertyName = "ngaytao";
            this.ngaytao.HeaderText = "Ngày tạo";
            this.ngaytao.Name = "ngaytao";
            this.ngaytao.ReadOnly = true;
            // 
            // clmGachNo
            // 
            this.clmGachNo.DataPropertyName = "hoadon";
            this.clmGachNo.HeaderText = "Hóa đơn";
            this.clmGachNo.Name = "clmGachNo";
            this.clmGachNo.ReadOnly = true;
            this.clmGachNo.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Kỳ Ghi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Năm";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tháng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày tạo";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tên Kỳ Ghi";
            // 
            // txtIDKyghi
            // 
            this.txtIDKyghi.Location = new System.Drawing.Point(124, 26);
            this.txtIDKyghi.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtIDKyghi.Name = "txtIDKyghi";
            this.txtIDKyghi.Size = new System.Drawing.Size(189, 26);
            this.txtIDKyghi.TabIndex = 6;
            // 
            // txtTenkyghi
            // 
            this.txtTenkyghi.Location = new System.Drawing.Point(124, 60);
            this.txtTenkyghi.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTenkyghi.Name = "txtTenkyghi";
            this.txtTenkyghi.Size = new System.Drawing.Size(189, 26);
            this.txtTenkyghi.TabIndex = 7;
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(429, 26);
            this.txtThang.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(148, 26);
            this.txtThang.TabIndex = 8;
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(429, 62);
            this.txtNam.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(148, 26);
            this.txtNam.TabIndex = 9;
            // 
            // DtNgaytao
            // 
            this.DtNgaytao.CustomFormat = "dd/MM/yyyy";
            this.DtNgaytao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtNgaytao.Location = new System.Drawing.Point(429, 106);
            this.DtNgaytao.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DtNgaytao.Name = "DtNgaytao";
            this.DtNgaytao.Size = new System.Drawing.Size(148, 26);
            this.DtNgaytao.TabIndex = 10;
            // 
            // chkGhiNuoc
            // 
            this.chkGhiNuoc.AutoSize = true;
            this.chkGhiNuoc.Checked = true;
            this.chkGhiNuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGhiNuoc.Location = new System.Drawing.Point(124, 111);
            this.chkGhiNuoc.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chkGhiNuoc.Name = "chkGhiNuoc";
            this.chkGhiNuoc.Size = new System.Drawing.Size(88, 23);
            this.chkGhiNuoc.TabIndex = 22;
            this.chkGhiNuoc.Text = "Hóa đơn";
            this.chkGhiNuoc.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Image = global::QLCongNo.Properties.Resources.thoat_16x16;
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(697, 155);
            this.closeButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(150, 40);
            this.closeButton.TabIndex = 16;
            this.closeButton.Text = "Thoát";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // editButton
            // 
            this.editButton.Image = global::QLCongNo.Properties.Resources.edit_16x16;
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editButton.Location = new System.Drawing.Point(194, 155);
            this.editButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(150, 40);
            this.editButton.TabIndex = 17;
            this.editButton.Text = "Sửa";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = global::QLCongNo.Properties.Resources.add_16x16;
            this.addButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addButton.Location = new System.Drawing.Point(32, 155);
            this.addButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(150, 40);
            this.addButton.TabIndex = 19;
            this.addButton.Text = "Thêm";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // KyGhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 584);
            this.Controls.Add(this.chkGhiNuoc);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.DtNgaytao);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.txtTenkyghi);
            this.Controls.Add(this.txtIDKyghi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "KyGhi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kỳ Ghi ";
            this.Load += new System.EventHandler(this.KyGhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIDKyghi;
        private System.Windows.Forms.TextBox txtTenkyghi;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.DateTimePicker DtNgaytao;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.CheckBox chkGhiNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_kyghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_kyghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn thang;
        private System.Windows.Forms.DataGridViewTextBoxColumn nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaytao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmGachNo;
    }
}