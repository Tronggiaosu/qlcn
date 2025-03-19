namespace QLCongNo
{
    partial class HuyHDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuyHDForm));
            this.btnLayDS = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnQuit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cboLotrinh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboKyghi = new System.Windows.Forms.ComboBox();
            this.txtMadanhbo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sttColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIDHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIDKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoten_KH1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachiColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.luongtieuthu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTienNuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTienThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmThueDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyhieuHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mauHDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSoHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLayDS
            // 
            this.btnLayDS.Image = global::QLCongNo.Properties.Resources.tim_kiem;
            this.btnLayDS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLayDS.Name = "btnLayDS";
            this.btnLayDS.Size = new System.Drawing.Size(80, 22);
            this.btnLayDS.Text = "Tìm kiếm";
            this.btnLayDS.Click += new System.EventHandler(this.btnLayDS_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::QLCongNo.Properties.Resources.cancel_billing;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 22);
            this.btnDelete.Text = "Hủy hóa đơn";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::QLCongNo.Properties.Resources.excel2019;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(56, 22);
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Image = global::QLCongNo.Properties.Resources.thoat;
            this.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(60, 22);
            this.btnQuit.Text = "Thoát";
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLayDS,
            this.btnDelete,
            this.btnExcel,
            this.btnQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 61;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cboLotrinh
            // 
            this.cboLotrinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLotrinh.FormattingEnabled = true;
            this.cboLotrinh.Location = new System.Drawing.Point(180, 52);
            this.cboLotrinh.Name = "cboLotrinh";
            this.cboLotrinh.Size = new System.Drawing.Size(496, 24);
            this.cboLotrinh.TabIndex = 49;
            this.cboLotrinh.SelectedIndexChanged += new System.EventHandler(this.cboLotrinh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(98, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Chọn lộ trình";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(70, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Chọn Kỳ tính cước";
            // 
            // cboKyghi
            // 
            this.cboKyghi.FormattingEnabled = true;
            this.cboKyghi.Location = new System.Drawing.Point(180, 21);
            this.cboKyghi.Name = "cboKyghi";
            this.cboKyghi.Size = new System.Drawing.Size(122, 24);
            this.cboKyghi.TabIndex = 52;
            // 
            // txtMadanhbo
            // 
            this.txtMadanhbo.Location = new System.Drawing.Point(425, 21);
            this.txtMadanhbo.Name = "txtMadanhbo";
            this.txtMadanhbo.Size = new System.Drawing.Size(251, 23);
            this.txtMadanhbo.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(341, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 54;
            this.label13.Text = "Thông tin KH";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtMadanhbo);
            this.panel1.Controls.Add(this.cboKyghi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboLotrinh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Blue;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 92);
            this.panel1.TabIndex = 62;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
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
            this.clmIDHD,
            this.clmIDKH,
            this.hoten_KH1,
            this.clmMST,
            this.diachiColumn,
            this.luongtieuthu1,
            this.clmTienNuoc,
            this.tienBVMT,
            this.clmTienThai,
            this.clmThueDH,
            this.clmTongTien,
            this.kyhieuHDColumn,
            this.mauHDColumn,
            this.clmSoHD});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(984, 620);
            this.dataGridView1.TabIndex = 63;
            // 
            // sttColumn
            // 
            this.sttColumn.DataPropertyName = "stt_ghi";
            this.sttColumn.HeaderText = "STT";
            this.sttColumn.Name = "sttColumn";
            this.sttColumn.ReadOnly = true;
            this.sttColumn.Width = 50;
            // 
            // clmIDHD
            // 
            this.clmIDHD.DataPropertyName = "ID_HD";
            this.clmIDHD.HeaderText = "Column1";
            this.clmIDHD.Name = "clmIDHD";
            this.clmIDHD.ReadOnly = true;
            this.clmIDHD.Visible = false;
            // 
            // clmIDKH
            // 
            this.clmIDKH.DataPropertyName = "id_kh";
            this.clmIDKH.HeaderText = "Mã KH";
            this.clmIDKH.Name = "clmIDKH";
            this.clmIDKH.ReadOnly = true;
            this.clmIDKH.Width = 60;
            // 
            // hoten_KH1
            // 
            this.hoten_KH1.DataPropertyName = "hoten_KH";
            this.hoten_KH1.HeaderText = "Tên KH";
            this.hoten_KH1.Name = "hoten_KH1";
            this.hoten_KH1.ReadOnly = true;
            this.hoten_KH1.Width = 200;
            // 
            // clmMST
            // 
            this.clmMST.DataPropertyName = "mst_kh";
            this.clmMST.HeaderText = "MST";
            this.clmMST.Name = "clmMST";
            this.clmMST.ReadOnly = true;
            this.clmMST.Visible = false;
            this.clmMST.Width = 80;
            // 
            // diachiColumn
            // 
            this.diachiColumn.DataPropertyName = "diachi";
            this.diachiColumn.HeaderText = "Địa chỉ";
            this.diachiColumn.Name = "diachiColumn";
            this.diachiColumn.ReadOnly = true;
            this.diachiColumn.Width = 200;
            // 
            // luongtieuthu1
            // 
            this.luongtieuthu1.DataPropertyName = "luongtieuthu";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.luongtieuthu1.DefaultCellStyle = dataGridViewCellStyle2;
            this.luongtieuthu1.HeaderText = "Lượng tiêu thụ";
            this.luongtieuthu1.Name = "luongtieuthu1";
            this.luongtieuthu1.ReadOnly = true;
            this.luongtieuthu1.Width = 60;
            // 
            // clmTienNuoc
            // 
            this.clmTienNuoc.DataPropertyName = "tiennuoc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.clmTienNuoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmTienNuoc.HeaderText = "Tiền nước";
            this.clmTienNuoc.Name = "clmTienNuoc";
            this.clmTienNuoc.ReadOnly = true;
            this.clmTienNuoc.Width = 80;
            // 
            // tienBVMT
            // 
            this.tienBVMT.DataPropertyName = "tienBVMT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.tienBVMT.DefaultCellStyle = dataGridViewCellStyle4;
            this.tienBVMT.HeaderText = "Tiền BVMT";
            this.tienBVMT.Name = "tienBVMT";
            this.tienBVMT.ReadOnly = true;
            this.tienBVMT.Width = 80;
            // 
            // clmTienThai
            // 
            this.clmTienThai.DataPropertyName = "tienthai";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.clmTienThai.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmTienThai.HeaderText = "Tiền nước thải";
            this.clmTienThai.Name = "clmTienThai";
            this.clmTienThai.ReadOnly = true;
            // 
            // clmThueDH
            // 
            this.clmThueDH.DataPropertyName = "tienthueDH";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.clmThueDH.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmThueDH.HeaderText = "Thuê đồng hồ";
            this.clmThueDH.Name = "clmThueDH";
            this.clmThueDH.ReadOnly = true;
            this.clmThueDH.Width = 80;
            // 
            // clmTongTien
            // 
            this.clmTongTien.DataPropertyName = "tongtien";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.clmTongTien.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmTongTien.HeaderText = "Tổng tiền";
            this.clmTongTien.Name = "clmTongTien";
            this.clmTongTien.ReadOnly = true;
            // 
            // kyhieuHDColumn
            // 
            this.kyhieuHDColumn.DataPropertyName = "ky_hieu_hd";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kyhieuHDColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.kyhieuHDColumn.HeaderText = "Ký hiệu HĐ";
            this.kyhieuHDColumn.Name = "kyhieuHDColumn";
            this.kyhieuHDColumn.ReadOnly = true;
            this.kyhieuHDColumn.Width = 80;
            // 
            // mauHDColumn
            // 
            this.mauHDColumn.DataPropertyName = "mau_hd";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mauHDColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.mauHDColumn.HeaderText = "Mẫu HĐ";
            this.mauHDColumn.Name = "mauHDColumn";
            this.mauHDColumn.ReadOnly = true;
            // 
            // clmSoHD
            // 
            this.clmSoHD.DataPropertyName = "so_hd";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.clmSoHD.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmSoHD.HeaderText = "Số HĐ";
            this.clmSoHD.Name = "clmSoHD";
            this.clmSoHD.ReadOnly = true;
            this.clmSoHD.Width = 70;
            // 
            // HuyHDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 737);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HuyHDForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỦY HÓA ĐƠN ĐÃ PHÁT HÀNH";
            this.Load += new System.EventHandler(this.HuyHDForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnLayDS;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton btnQuit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ComboBox cboLotrinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboKyghi;
        private System.Windows.Forms.TextBox txtMadanhbo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sttColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten_KH1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMST;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn luongtieuthu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTienNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTienThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmThueDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyhieuHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mauHDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSoHD;
    }
}