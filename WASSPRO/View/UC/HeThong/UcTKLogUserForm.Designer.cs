namespace QLCongNo
{
    partial class UcTKLogUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcTKLogUserForm));
            this.dataGridView1 = new View.Core.NovDataGridView();
            this.sttColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.maNDColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.hotenColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.ngayycColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.maNDcheckBox = new View.Core.NovCheckBox();
            this.denNgaydateTimePicker = new View.Core.NovDateTimePicker();
            this.label3 = new View.Core.NovLabel();
            this.tuNgaydateTimePicker = new View.Core.NovDateTimePicker();
            this.label1 = new View.Core.NovLabel();
            this.panel1 = new View.Core.NovPanel();
            this.maNDcomboBox = new View.Core.NovComboBox();
            this.quitButton = new View.Core.NovToolStripButton();
            this.excelButton = new View.Core.NovToolStripButton();
            this.seachButton = new View.Core.NovToolStripButton();
            this.toolStrip1 = new View.Core.NovToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.maNDColumn,
            this.hotenColumn,
            this.ngayycColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 113);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(984, 592);
            this.dataGridView1.TabIndex = 42;
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
            // maNDColumn
            // 
            this.maNDColumn.DataPropertyName = "ma_nd";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maNDColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.maNDColumn.HeaderText = "Tên đăng nhập";
            this.maNDColumn.Name = "maNDColumn";
            this.maNDColumn.ReadOnly = true;
            this.maNDColumn.Width = 150;
            // 
            // hotenColumn
            // 
            this.hotenColumn.DataPropertyName = "hoten";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotenColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.hotenColumn.HeaderText = "Họ tên";
            this.hotenColumn.Name = "hotenColumn";
            this.hotenColumn.ReadOnly = true;
            this.hotenColumn.Width = 200;
            // 
            // ngayycColumn
            // 
            this.ngayycColumn.DataPropertyName = "ngaySD";
            this.ngayycColumn.HeaderText = "Ngày đăng nhập";
            this.ngayycColumn.Name = "ngayycColumn";
            this.ngayycColumn.ReadOnly = true;
            this.ngayycColumn.Width = 150;
            // 
            // maNDcheckBox
            // 
            this.maNDcheckBox.AutoSize = true;
            this.maNDcheckBox.Location = new System.Drawing.Point(453, 23);
            this.maNDcheckBox.Name = "maNDcheckBox";
            this.maNDcheckBox.Size = new System.Drawing.Size(141, 20);
            this.maNDcheckBox.TabIndex = 4;
            this.maNDcheckBox.Text = "Chọn tên đăng nhập";
            this.maNDcheckBox.UseVisualStyleBackColor = true;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.maNDcheckBox);
            this.panel1.Controls.Add(this.denNgaydateTimePicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tuNgaydateTimePicker);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.maNDcomboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 88);
            this.panel1.TabIndex = 41;
            // 
            // maNDcomboBox
            // 
            this.maNDcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maNDcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maNDcomboBox.FormattingEnabled = true;
            this.maNDcomboBox.Location = new System.Drawing.Point(597, 23);
            this.maNDcomboBox.Margin = new System.Windows.Forms.Padding(4);
            this.maNDcomboBox.Name = "maNDcomboBox";
            this.maNDcomboBox.Size = new System.Drawing.Size(221, 21);
            this.maNDcomboBox.TabIndex = 0;
            // 
            // quitButton
            // 
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(60, 22);
            this.quitButton.Text = "Thoát";
            this.quitButton.Visible = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
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
            // seachButton
            // 
            this.seachButton.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.seachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seachButton.Name = "seachButton";
            this.seachButton.Size = new System.Drawing.Size(80, 22);
            this.seachButton.Text = "Tìm kiếm";
            this.seachButton.Click += new System.EventHandler(this.seachButton_Click);
            // 
            // toolStrip1
            // 
            
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachButton,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 40;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TKLogUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 705);
            
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.Name = "TKLogUserForm";
            this.Text = "THỐNG KÊ ĐĂNG NHẬP";
            this.Load += new System.EventHandler(this.TKLogUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovDataGridView dataGridView1;
        private View.Core.NovCheckBox maNDcheckBox;
        private View.Core.NovDateTimePicker denNgaydateTimePicker;
        private View.Core.NovLabel label3;
        private View.Core.NovDateTimePicker tuNgaydateTimePicker;
        private View.Core.NovLabel label1;
        private View.Core.NovPanel panel1;
        private View.Core.NovComboBox maNDcomboBox;
        private View.Core.NovToolStripButton quitButton;
        private View.Core.NovToolStripButton excelButton;
        private View.Core.NovToolStripButton seachButton;
        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovDataGridViewTextBoxColumn sttColumn;
        private View.Core.NovDataGridViewTextBoxColumn maNDColumn;
        private View.Core.NovDataGridViewTextBoxColumn hotenColumn;
        private View.Core.NovDataGridViewTextBoxColumn ngayycColumn;
    }
}