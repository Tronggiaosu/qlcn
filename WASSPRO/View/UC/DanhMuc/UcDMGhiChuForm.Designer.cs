namespace QLCongNo
{
    partial class UcDMGhiChuForm
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
            this.txtGroupName = new QLCongNo.View.Core.NovTextBox();
            this.label1 = new QLCongNo.View.Core.NovLabel();
            this.panel1 = new QLCongNo.View.Core.NovPanel();
            this.label2 = new QLCongNo.View.Core.NovLabel();
            this.yccomboBox = new QLCongNo.View.Core.NovComboBox();
            this.toolStrip1 = new QLCongNo.View.Core.NovToolStrip();
            this.addButton = new QLCongNo.View.Core.NovToolStripButton();
            this.editButton = new QLCongNo.View.Core.NovToolStripButton();
            this.deleteButton = new QLCongNo.View.Core.NovToolStripButton();
            this.cancelButton = new QLCongNo.View.Core.NovToolStripButton();
            this.quitButton = new QLCongNo.View.Core.NovToolStripButton();
            this.dataGridView1 = new QLCongNo.View.Core.NovDataGridView();
            this.idColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.ghichuColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.ycColumn = new QLCongNo.View.Core.NovDataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.Color.White;
            this.txtGroupName.Enabled = false;
            this.txtGroupName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupName.ForeColor = System.Drawing.Color.Black;
            this.txtGroupName.Location = new System.Drawing.Point(148, 20);
            this.txtGroupName.Margin = new System.Windows.Forms.Padding(5);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(356, 32);
            this.txtGroupName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ghi chú";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.yccomboBox);
            this.panel1.Controls.Add(this.txtGroupName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.MediumBlue;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 118);
            this.panel1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(22, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Loại yêu cầu";
            // 
            // yccomboBox
            // 
            this.yccomboBox.BackColor = System.Drawing.Color.White;
            this.yccomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yccomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yccomboBox.ForeColor = System.Drawing.Color.Black;
            this.yccomboBox.FormattingEnabled = true;
            this.yccomboBox.Location = new System.Drawing.Point(148, 72);
            this.yccomboBox.Margin = new System.Windows.Forms.Padding(5);
            this.yccomboBox.Name = "yccomboBox";
            this.yccomboBox.Size = new System.Drawing.Size(356, 25);
            this.yccomboBox.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BorderColor = System.Drawing.Color.Empty;
            this.toolStrip1.BorderThickness = 0;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ForeColor = System.Drawing.Color.MediumBlue;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.IsMainMenu = true;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.editButton,
            this.deleteButton,
            this.cancelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MenuItemHeight = 26;
            this.toolStrip1.MenuItemTextColor = System.Drawing.Color.White;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.toolStrip1.Size = new System.Drawing.Size(528, 35);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Image = global::QLCongNo.Properties.Resources.add_1;
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.addButton.Name = "addButton";
            this.addButton.Padding = new System.Windows.Forms.Padding(4);
            this.addButton.Size = new System.Drawing.Size(85, 35);
            this.addButton.Text = "Thêm";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Image = global::QLCongNo.Properties.Resources.edit_1;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Margin = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.editButton.Name = "editButton";
            this.editButton.Padding = new System.Windows.Forms.Padding(4);
            this.editButton.Size = new System.Drawing.Size(70, 35);
            this.editButton.Text = "Sửa";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Image = global::QLCongNo.Properties.Resources.delete_new;
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Padding = new System.Windows.Forms.Padding(4);
            this.deleteButton.Size = new System.Drawing.Size(71, 35);
            this.deleteButton.Text = "Xóa";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Image = global::QLCongNo.Properties.Resources._112_ArrowReturnLeft_Blue_16x16_72;
            this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(4);
            this.cancelButton.Size = new System.Drawing.Size(72, 35);
            this.cancelButton.Text = "Hủy";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Margin = new System.Windows.Forms.Padding(4, 0, 2, 0);
            this.quitButton.Name = "quitButton";
            this.quitButton.Padding = new System.Windows.Forms.Padding(4);
            this.quitButton.Size = new System.Drawing.Size(86, 35);
            this.quitButton.Text = "Thoát";
            this.quitButton.Visible = false;
            this.quitButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(64)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.ghichuColumn,
            this.ycColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataGridView1.Location = new System.Drawing.Point(26, 157);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(478, 167);
            this.dataGridView1.TabIndex = 26;
            // 
            // idColumn
            // 
            this.idColumn.DataPropertyName = "ghichuid";
            this.idColumn.HeaderText = "ID";
            this.idColumn.MinimumWidth = 6;
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            this.idColumn.Visible = false;
            // 
            // ghichuColumn
            // 
            this.ghichuColumn.DataPropertyName = "noidung";
            this.ghichuColumn.HeaderText = "Ghi chú";
            this.ghichuColumn.MinimumWidth = 6;
            this.ghichuColumn.Name = "ghichuColumn";
            this.ghichuColumn.ReadOnly = true;
            // 
            // ycColumn
            // 
            this.ycColumn.DataPropertyName = "tenloai_yc";
            this.ycColumn.HeaderText = "Yêu cầu";
            this.ycColumn.MinimumWidth = 6;
            this.ycColumn.Name = "ycColumn";
            this.ycColumn.ReadOnly = true;
            // 
            // UcDMGhiChuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcDMGhiChuForm";
            this.Size = new System.Drawing.Size(528, 348);
            this.Load += new System.EventHandler(this.DMGhiChuForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovTextBox txtGroupName;
        private View.Core.NovLabel label1;
        private View.Core.NovPanel panel1;
        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton addButton;
        private View.Core.NovToolStripButton editButton;
        private View.Core.NovToolStripButton deleteButton;
        private View.Core.NovToolStripButton cancelButton;
        private View.Core.NovToolStripButton quitButton;
        private View.Core.NovDataGridView dataGridView1;
        private View.Core.NovLabel label2;
        private View.Core.NovComboBox yccomboBox;
        private View.Core.NovDataGridViewTextBoxColumn idColumn;
        private View.Core.NovDataGridViewTextBoxColumn ghichuColumn;
        private View.Core.NovDataGridViewTextBoxColumn ycColumn;
    }
}