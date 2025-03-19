namespace QLCongNo.View.UC.HoaDon
{
    partial class UcDSHoaDonDieuChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcDSHoaDonDieuChinh));
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.seachButton = new View.Core.NovToolStripButton();
            this.bdButton = new View.Core.NovToolStripButton();
            this.excelButton = new View.Core.NovToolStripButton();
            this.quitButton = new View.Core.NovToolStripButton();
            this.statusStrip1 = new View.Core.NovStatusStrip();
            this.lblTongtien = new View.Core.NovToolStripStatusLabel();
            this.groupBox1 = new View.Core.NovGroupBox();
            this.dataGridView1 = new View.Core.NovDataGridView();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 

            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seachButton,
            this.bdButton,
            this.excelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1147, 26);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // seachButton
            // 
            this.seachButton.Image = global::QLCongNo.Properties.Resources.lay_danh_sach;
            this.seachButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seachButton.Name = "seachButton";
            this.seachButton.Size = new System.Drawing.Size(128, 23);
            this.seachButton.Text = "Lấy danh sách";
            // 
            // bdButton
            // 
            this.bdButton.Image = global::QLCongNo.Properties.Resources.cap_nhat_hoa_don;
            this.bdButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdButton.Name = "bdButton";
            this.bdButton.Size = new System.Drawing.Size(121, 23);
            this.bdButton.Text = "Xem hóa đơn";
            // 
            // excelButton
            // 
            this.excelButton.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.excelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(100, 23);
            this.excelButton.Text = "Xuất Excel";
            // 
            // quitButton
            // 
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(69, 23);
            this.quitButton.Text = "Thoát";
            this.quitButton.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTongtien});
            this.statusStrip1.Location = new System.Drawing.Point(0, 574);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1147, 22);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTongtien
            // 
            this.lblTongtien.ForeColor = System.Drawing.Color.Blue;
            this.lblTongtien.Name = "lblTongtien";
            this.lblTongtien.Size = new System.Drawing.Size(118, 17);
            this.lblTongtien.Text = "toolStripStatusLabel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1147, 51);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1147, 497);
            this.dataGridView1.TabIndex = 28;
            // 
            // frDSHoaDonDieuChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 596);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
                        this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frDSHoaDonDieuChinh";
            this.Text = "Danh sách hóa đơn điều chỉnh thông tin";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton seachButton;
        private View.Core.NovToolStripButton bdButton;
        private View.Core.NovToolStripButton excelButton;
        private View.Core.NovToolStripButton quitButton;
        private View.Core.NovStatusStrip statusStrip1;
        private View.Core.NovToolStripStatusLabel lblTongtien;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovDataGridView dataGridView1;
    }
}