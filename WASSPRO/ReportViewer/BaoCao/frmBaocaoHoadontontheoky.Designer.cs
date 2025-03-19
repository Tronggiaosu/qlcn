namespace QLCongNo.ReportViewer.BaoCao
{
    partial class frmBaocaoHoadontontheoky
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTongSPH = new System.Windows.Forms.TextBox();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDShoadonton = new System.Windows.Forms.DataGridView();
            this.getBaocaoHoadonton1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnXembaocao = new System.Windows.Forms.ToolStripButton();
            this.btnXemchitiet = new System.Windows.Forms.ToolStripButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboDenKy = new System.Windows.Forms.ComboBox();
            this.cboTuky = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDShoadonton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBaocaoHoadonton1BindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(344, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê hóa đơn tồn theo kỳ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTongSPH);
            this.groupBox1.Controls.Add(this.txtTong);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvDShoadonton);
            this.groupBox1.Location = new System.Drawing.Point(12, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 333);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtTongSPH
            // 
            this.txtTongSPH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSPH.Location = new System.Drawing.Point(724, 308);
            this.txtTongSPH.Name = "txtTongSPH";
            this.txtTongSPH.ReadOnly = true;
            this.txtTongSPH.Size = new System.Drawing.Size(98, 20);
            this.txtTongSPH.TabIndex = 9;
            // 
            // txtTong
            // 
            this.txtTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTong.Location = new System.Drawing.Point(828, 308);
            this.txtTong.Name = "txtTong";
            this.txtTong.ReadOnly = true;
            this.txtTong.Size = new System.Drawing.Size(125, 20);
            this.txtTong.TabIndex = 7;
            this.txtTong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng cộng:";
            // 
            // dgvDShoadonton
            // 
            this.dgvDShoadonton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDShoadonton.Location = new System.Drawing.Point(6, 19);
            this.dgvDShoadonton.Name = "dgvDShoadonton";
            this.dgvDShoadonton.Size = new System.Drawing.Size(947, 279);
            this.dgvDShoadonton.TabIndex = 0;
            // 
            // getBaocaoHoadonton1BindingSource
            // 
            this.getBaocaoHoadonton1BindingSource.DataMember = "getBaocaoHoadonton1";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QLCongNo.Properties.Resources.browse;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(80, 22);
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QLCongNo.Properties.Resources.delete1;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(61, 22);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnXembaocao,
            this.btnTim,
            this.btnXemchitiet,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(991, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnXembaocao
            // 
            this.btnXembaocao.Image = global::QLCongNo.Properties.Resources._327_Options_24x24_72;
            this.btnXembaocao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXembaocao.Name = "btnXembaocao";
            this.btnXembaocao.Size = new System.Drawing.Size(106, 22);
            this.btnXembaocao.Text = "Xem báo cáo";
            this.btnXembaocao.Click += new System.EventHandler(this.btnXembaocao_Click);
            // 
            // btnXemchitiet
            // 
            this.btnXemchitiet.Image = global::QLCongNo.Properties.Resources.Go;
            this.btnXemchitiet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXemchitiet.Name = "btnXemchitiet";
            this.btnXemchitiet.Size = new System.Drawing.Size(96, 22);
            this.btnXemchitiet.Text = "Xem chi tiết";
            this.btnXemchitiet.Click += new System.EventHandler(this.btnXemchitiet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(81, 125);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(841, 20);
            this.txtSearch.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Từ kỳ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Đến kỳ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNam);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cboDenKy);
            this.groupBox2.Controls.Add(this.cboTuky);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(122, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 53);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(556, 19);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(111, 20);
            this.txtNam.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(518, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Năm:";
            // 
            // cboDenKy
            // 
            this.cboDenKy.FormattingEnabled = true;
            this.cboDenKy.Location = new System.Drawing.Point(313, 18);
            this.cboDenKy.Name = "cboDenKy";
            this.cboDenKy.Size = new System.Drawing.Size(164, 21);
            this.cboDenKy.TabIndex = 17;
            // 
            // cboTuky
            // 
            this.cboTuky.FormattingEnabled = true;
            this.cboTuky.Location = new System.Drawing.Point(56, 19);
            this.cboTuky.Name = "cboTuky";
            this.cboTuky.Size = new System.Drawing.Size(189, 21);
            this.cboTuky.TabIndex = 16;
            // 
            // frmBaocaoHoadontontheoky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 499);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmBaocaoHoadontontheoky";
            this.Text = "Báo cáo hóa đơn tồn theo kỳ";
            this.Load += new System.EventHandler(this.frBaocaoHoadonton_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDShoadonton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBaocaoHoadonton1BindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDShoadonton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idseri;
        private System.Windows.Forms.TextBox txtTongSPH;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.BindingSource getBaocaoHoadonton1BindingSource;
        private CAPNUOC_TDCDataSetTableAdapters.getBaocaoHoadontonTableAdapter getBaocaoHoadonton1TableAdapter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnXemchitiet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton btnXembaocao;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboDenKy;
        private System.Windows.Forms.ComboBox cboTuky;
    }
}