namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    partial class UcDSHoaDon_KH
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
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.btnThoat = new View.Core.NovToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvHoadon = new View.Core.NovDataGridView();
            this.dataGridViewTextBoxColumn1 = new View.Core.NovDataGridViewTextBoxColumn();
            this.kyhd_dgv2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.dotColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.kyhieuHDColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.tongtien_dgv2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.ID_KHColumn2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.ID_HDColumn2 = new View.Core.NovDataGridViewTextBoxColumn();
            this.trangthaiHDColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.chitietColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.trangthaiColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.nhanvienColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.ngaythanhtoanColumn = new View.Core.NovDataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1162, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvHoadon);
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 398);
            this.panel1.TabIndex = 10;
            // 
            // dgvHoadon
            // 
            this.dgvHoadon.AllowUserToAddRows = false;
            this.dgvHoadon.AllowUserToDeleteRows = false;
            this.dgvHoadon.AllowUserToOrderColumns = true;
            this.dgvHoadon.AllowUserToResizeColumns = false;
            this.dgvHoadon.AllowUserToResizeRows = false;
            this.dgvHoadon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

            this.dgvHoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoadon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.kyhd_dgv2,
            this.dotColumn,
            this.kyhieuHDColumn,
            this.dataGridViewTextBoxColumn2,
            this.tongtien_dgv2,
            this.ID_KHColumn2,
            this.ID_HDColumn2,
            this.trangthaiHDColumn,
            this.chitietColumn,
            this.trangthaiColumn,
            this.nhanvienColumn,
            this.ngaythanhtoanColumn});
            this.dgvHoadon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoadon.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvHoadon.Location = new System.Drawing.Point(0, 0);
            this.dgvHoadon.Name = "dgvHoadon";
            this.dgvHoadon.Size = new System.Drawing.Size(1162, 398);
            this.dgvHoadon.TabIndex = 35;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "nam";
            this.dataGridViewTextBoxColumn1.HeaderText = "Năm";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 62;
            // 
            // kyhd_dgv2
            // 
            this.kyhd_dgv2.DataPropertyName = "kyghi";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kyhd_dgv2.DefaultCellStyle = dataGridViewCellStyle1;
            this.kyhd_dgv2.HeaderText = "Kỳ hóa đơn";
            this.kyhd_dgv2.Name = "kyhd_dgv2";
            this.kyhd_dgv2.ReadOnly = true;
            // 
            // dotColumn
            // 
            this.dotColumn.DataPropertyName = "DOT_ID";
            this.dotColumn.HeaderText = "Đợt";
            this.dotColumn.Name = "dotColumn";
            this.dotColumn.ReadOnly = true;
            this.dotColumn.Visible = false;
            this.dotColumn.Width = 53;
            // 
            // kyhieuHDColumn
            // 
            this.kyhieuHDColumn.DataPropertyName = "KY_HIEU_HD";
            this.kyhieuHDColumn.HeaderText = "Ký hiệu";
            this.kyhieuHDColumn.Name = "kyhieuHDColumn";
            this.kyhieuHDColumn.ReadOnly = true;
            this.kyhieuHDColumn.Width = 76;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "so_hd";
            this.dataGridViewTextBoxColumn2.HeaderText = "Số hóa đơn";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 102;
            // 
            // tongtien_dgv2
            // 
            this.tongtien_dgv2.DataPropertyName = "tongtien";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.tongtien_dgv2.DefaultCellStyle = dataGridViewCellStyle2;
            this.tongtien_dgv2.HeaderText = "Tổng tiền";
            this.tongtien_dgv2.Name = "tongtien_dgv2";
            this.tongtien_dgv2.ReadOnly = true;
            this.tongtien_dgv2.Width = 89;
            // 
            // ID_KHColumn2
            // 
            this.ID_KHColumn2.DataPropertyName = "ID_KH";
            this.ID_KHColumn2.HeaderText = "ID_KH";
            this.ID_KHColumn2.Name = "ID_KHColumn2";
            this.ID_KHColumn2.Visible = false;
            this.ID_KHColumn2.Width = 71;
            // 
            // ID_HDColumn2
            // 
            this.ID_HDColumn2.DataPropertyName = "ID_HD";
            this.ID_HDColumn2.HeaderText = "ID_HD";
            this.ID_HDColumn2.Name = "ID_HDColumn2";
            this.ID_HDColumn2.ReadOnly = true;
            this.ID_HDColumn2.Visible = false;
            this.ID_HDColumn2.Width = 73;
            // 
            // trangthaiHDColumn
            // 
            this.trangthaiHDColumn.DataPropertyName = "tentrangthai";
            this.trangthaiHDColumn.HeaderText = "Trạng thái HĐ";
            this.trangthaiHDColumn.Name = "trangthaiHDColumn";
            this.trangthaiHDColumn.Width = 115;
            // 
            // chitietColumn
            // 
            this.chitietColumn.DataPropertyName = "chitiet";
            this.chitietColumn.HeaderText = "Chi tiết";
            this.chitietColumn.Name = "chitietColumn";
            this.chitietColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chitietColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chitietColumn.Visible = false;
            this.chitietColumn.Width = 72;
            // 
            // trangthaiColumn
            // 
            this.trangthaiColumn.DataPropertyName = "thanhtoan";
            this.trangthaiColumn.HeaderText = "Thanh toán";
            this.trangthaiColumn.Name = "trangthaiColumn";
            this.trangthaiColumn.ReadOnly = true;
            // 
            // nhanvienColumn
            // 
            this.nhanvienColumn.DataPropertyName = "hotenNV";
            this.nhanvienColumn.HeaderText = "Nhân viên";
            this.nhanvienColumn.Name = "nhanvienColumn";
            this.nhanvienColumn.ReadOnly = true;
            this.nhanvienColumn.Width = 93;
            // 
            // ngaythanhtoanColumn
            // 
            this.ngaythanhtoanColumn.DataPropertyName = "ngaythanhtoan";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm:ss";
            dataGridViewCellStyle3.NullValue = null;
            this.ngaythanhtoanColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ngaythanhtoanColumn.HeaderText = "Ngày thanh toán";
            this.ngaythanhtoanColumn.Name = "ngaythanhtoanColumn";
            this.ngaythanhtoanColumn.Width = 96;
            // 
            // frDSHoaDon_KH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 445);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frDSHoaDon_KH";
            this.Text = "Danh sách hóa đơn";
            this.Load += new System.EventHandler(this.frDSHoaDon_KH_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.Core.NovToolStrip toolStrip1;
        private View.Core.NovToolStripButton btnThoat;
        private System.Windows.Forms.Panel panel1;
        private View.Core.NovDataGridView dgvHoadon;
        private View.Core.NovDataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private View.Core.NovDataGridViewTextBoxColumn kyhd_dgv2;
        private View.Core.NovDataGridViewTextBoxColumn dotColumn;
        private View.Core.NovDataGridViewTextBoxColumn kyhieuHDColumn;
        private View.Core.NovDataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private View.Core.NovDataGridViewTextBoxColumn tongtien_dgv2;
        private View.Core.NovDataGridViewTextBoxColumn ID_KHColumn2;
        private View.Core.NovDataGridViewTextBoxColumn ID_HDColumn2;
        private View.Core.NovDataGridViewTextBoxColumn trangthaiHDColumn;
        private System.Windows.Forms.DataGridViewButtonColumn chitietColumn;
        private View.Core.NovDataGridViewTextBoxColumn trangthaiColumn;
        private View.Core.NovDataGridViewTextBoxColumn nhanvienColumn;
        private View.Core.NovDataGridViewTextBoxColumn ngaythanhtoanColumn;
    }
}