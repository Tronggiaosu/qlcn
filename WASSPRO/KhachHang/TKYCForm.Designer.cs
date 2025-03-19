namespace QLCongNo
{
    partial class TKYCForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TKYCForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.seachButton = new System.Windows.Forms.ToolStripButton();
            this.excelButton = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ttcheckBox = new System.Windows.Forms.CheckBox();
            this.loaiYCcheckBox = new System.Windows.Forms.CheckBox();
            this.denNgaydateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tuNgaydateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ttcomboBox = new System.Windows.Forms.ComboBox();
            this.yccomboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sttColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sophieuColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ycColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayycColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayHTColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nguoiTHColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachi1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiKHColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idYCColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachButton,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 37;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seachButton
            // 
            this.seachButton.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.seachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seachButton.Name = "seachButton";
            this.seachButton.Size = new System.Drawing.Size(80, 22);
            this.seachButton.Text = "Tìm kiếm";
            this.seachButton.Click += new System.EventHandler(this.seachButton_Click);
            // 
            // excelButton
            // 
            this.excelButton.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.excelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(86, 22);
            this.excelButton.Text = "Xuất Excel";
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(60, 22);
            this.quitButton.Text = "Thoát";
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ttcheckBox);
            this.panel1.Controls.Add(this.loaiYCcheckBox);
            this.panel1.Controls.Add(this.denNgaydateTimePicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tuNgaydateTimePicker);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ttcomboBox);
            this.panel1.Controls.Add(this.yccomboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 101);
            this.panel1.TabIndex = 38;
            // 
            // ttcheckBox
            // 
            this.ttcheckBox.AutoSize = true;
            this.ttcheckBox.Location = new System.Drawing.Point(453, 54);
            this.ttcheckBox.Name = "ttcheckBox";
            this.ttcheckBox.Size = new System.Drawing.Size(114, 20);
            this.ttcheckBox.TabIndex = 4;
            this.ttcheckBox.Text = "Chọn trạng thái";
            this.ttcheckBox.UseVisualStyleBackColor = true;
            // 
            // loaiYCcheckBox
            // 
            this.loaiYCcheckBox.AutoSize = true;
            this.loaiYCcheckBox.Location = new System.Drawing.Point(453, 23);
            this.loaiYCcheckBox.Name = "loaiYCcheckBox";
            this.loaiYCcheckBox.Size = new System.Drawing.Size(127, 20);
            this.loaiYCcheckBox.TabIndex = 4;
            this.loaiYCcheckBox.Text = "Chọn loại yêu cầu";
            this.loaiYCcheckBox.UseVisualStyleBackColor = true;
            // 
            // denNgaydateTimePicker
            // 
            this.denNgaydateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.denNgaydateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.denNgaydateTimePicker.Location = new System.Drawing.Point(268, 52);
            this.denNgaydateTimePicker.Name = "denNgaydateTimePicker";
            this.denNgaydateTimePicker.Size = new System.Drawing.Size(123, 23);
            this.denNgaydateTimePicker.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày";
            // 
            // tuNgaydateTimePicker
            // 
            this.tuNgaydateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.tuNgaydateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tuNgaydateTimePicker.Location = new System.Drawing.Point(268, 23);
            this.tuNgaydateTimePicker.Name = "tuNgaydateTimePicker";
            this.tuNgaydateTimePicker.Size = new System.Drawing.Size(123, 23);
            this.tuNgaydateTimePicker.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ ngày";
            // 
            // ttcomboBox
            // 
            this.ttcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ttcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttcomboBox.FormattingEnabled = true;
            this.ttcomboBox.Location = new System.Drawing.Point(583, 52);
            this.ttcomboBox.Margin = new System.Windows.Forms.Padding(4);
            this.ttcomboBox.Name = "ttcomboBox";
            this.ttcomboBox.Size = new System.Drawing.Size(260, 21);
            this.ttcomboBox.TabIndex = 0;
            // 
            // yccomboBox
            // 
            this.yccomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yccomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yccomboBox.FormattingEnabled = true;
            this.yccomboBox.Location = new System.Drawing.Point(583, 21);
            this.yccomboBox.Margin = new System.Windows.Forms.Padding(4);
            this.yccomboBox.Name = "yccomboBox";
            this.yccomboBox.Size = new System.Drawing.Size(260, 21);
            this.yccomboBox.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sttColumn,
            this.sophieuColumn,
            this.dbColumn,
            this.hotenColumn,
            this.ycColumn,
            this.ngayycColumn,
            this.ngayHTColumn,
            this.nguoiTHColumn,
            this.ttColumn,
            this.diachi1Column,
            this.sdtColumn,
            this.loaiKHColumn,
            this.clmGhiChu,
            this.idYCColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 126);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(984, 632);
            this.dataGridView1.TabIndex = 39;
            // 
            // sttColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sttColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.sttColumn.HeaderText = "STT";
            this.sttColumn.Name = "sttColumn";
            this.sttColumn.ReadOnly = true;
            this.sttColumn.Width = 50;
            // 
            // sophieuColumn
            // 
            this.sophieuColumn.DataPropertyName = "sophieu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sophieuColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.sophieuColumn.HeaderText = "Số phiếu";
            this.sophieuColumn.Name = "sophieuColumn";
            this.sophieuColumn.ReadOnly = true;
            this.sophieuColumn.Visible = false;
            this.sophieuColumn.Width = 60;
            // 
            // dbColumn
            // 
            this.dbColumn.DataPropertyName = "id_kh";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dbColumn.HeaderText = "Mã KH";
            this.dbColumn.Name = "dbColumn";
            this.dbColumn.ReadOnly = true;
            this.dbColumn.Width = 80;
            // 
            // hotenColumn
            // 
            this.hotenColumn.DataPropertyName = "hoten_kh";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotenColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.hotenColumn.HeaderText = "Họ tên";
            this.hotenColumn.Name = "hotenColumn";
            this.hotenColumn.ReadOnly = true;
            this.hotenColumn.Width = 150;
            // 
            // ycColumn
            // 
            this.ycColumn.DataPropertyName = "tenloai_yc";
            this.ycColumn.HeaderText = "Loại yêu cầu";
            this.ycColumn.Name = "ycColumn";
            this.ycColumn.ReadOnly = true;
            this.ycColumn.Width = 150;
            // 
            // ngayycColumn
            // 
            this.ngayycColumn.DataPropertyName = "ngayYC";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.ngayycColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.ngayycColumn.HeaderText = "Ngày yêu cầu";
            this.ngayycColumn.Name = "ngayycColumn";
            this.ngayycColumn.ReadOnly = true;
            // 
            // ngayHTColumn
            // 
            this.ngayHTColumn.DataPropertyName = "ngayHT";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.ngayHTColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.ngayHTColumn.HeaderText = "Ngày hoàn thành";
            this.ngayHTColumn.Name = "ngayHTColumn";
            this.ngayHTColumn.ReadOnly = true;
            // 
            // nguoiTHColumn
            // 
            this.nguoiTHColumn.HeaderText = "Người thực hiện";
            this.nguoiTHColumn.Name = "nguoiTHColumn";
            this.nguoiTHColumn.ReadOnly = true;
            this.nguoiTHColumn.Visible = false;
            this.nguoiTHColumn.Width = 150;
            // 
            // ttColumn
            // 
            this.ttColumn.DataPropertyName = "tenTTYC";
            this.ttColumn.HeaderText = "Trạng thái";
            this.ttColumn.Name = "ttColumn";
            this.ttColumn.ReadOnly = true;
            // 
            // diachi1Column
            // 
            this.diachi1Column.DataPropertyName = "diachi";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi1Column.DefaultCellStyle = dataGridViewCellStyle8;
            this.diachi1Column.HeaderText = "Địa chỉ";
            this.diachi1Column.Name = "diachi1Column";
            this.diachi1Column.ReadOnly = true;
            this.diachi1Column.Visible = false;
            this.diachi1Column.Width = 250;
            // 
            // sdtColumn
            // 
            this.sdtColumn.DataPropertyName = "sdt_kh";
            this.sdtColumn.HeaderText = "SĐT";
            this.sdtColumn.Name = "sdtColumn";
            this.sdtColumn.ReadOnly = true;
            // 
            // loaiKHColumn
            // 
            this.loaiKHColumn.DataPropertyName = "tenDT";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaiKHColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.loaiKHColumn.HeaderText = "Loại KH";
            this.loaiKHColumn.Name = "loaiKHColumn";
            this.loaiKHColumn.ReadOnly = true;
            this.loaiKHColumn.Visible = false;
            // 
            // clmGhiChu
            // 
            this.clmGhiChu.DataPropertyName = "ghichu";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clmGhiChu.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmGhiChu.HeaderText = "Kết quả";
            this.clmGhiChu.Name = "clmGhiChu";
            this.clmGhiChu.ReadOnly = true;
            this.clmGhiChu.Width = 250;
            // 
            // idYCColumn
            // 
            this.idYCColumn.DataPropertyName = "id_yeucau";
            this.idYCColumn.HeaderText = "idYC";
            this.idYCColumn.Name = "idYCColumn";
            this.idYCColumn.ReadOnly = true;
            this.idYCColumn.Visible = false;
            // 
            // TKYCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 758);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TKYCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ YÊU CẦU";
            this.Load += new System.EventHandler(this.TKYCForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton seachButton;
        private System.Windows.Forms.ToolStripButton excelButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox loaiYCcheckBox;
        private System.Windows.Forms.DateTimePicker denNgaydateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker tuNgaydateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox yccomboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox ttcheckBox;
        private System.Windows.Forms.ComboBox ttcomboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn sttColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sophieuColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dbColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ycColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayycColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayHTColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nguoiTHColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachi1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiKHColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn idYCColumn;
    }
}