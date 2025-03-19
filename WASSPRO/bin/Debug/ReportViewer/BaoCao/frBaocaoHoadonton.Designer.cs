namespace QLCongNo.ReportViewer.BaoCao
{
    partial class frBaocaoHoadonton
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtseri = new System.Windows.Forms.TextBox();
            this.txtDanhbo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTongSPH = new System.Windows.Forms.TextBox();
            this.txtTongLNTT = new System.Windows.Forms.TextBox();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.txtTongPhi = new System.Windows.Forms.TextBox();
            this.txtTongVAT = new System.Windows.Forms.TextBox();
            this.txtTongTiennuoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDShoadonton = new System.Windows.Forms.DataGridView();
            this.sOHDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyghiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sOPHATHANHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lNTTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien0VATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienvatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienBVMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getBaocaoHoadonton1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.getBaocaoHoadonton1TableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getBaocaoHoadonton1TableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDShoadonton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBaocaoHoadonton1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xem nợ tồn thu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số seri:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Danh bộ:";
            // 
            // txtseri
            // 
            this.txtseri.Location = new System.Drawing.Point(261, 55);
            this.txtseri.Name = "txtseri";
            this.txtseri.Size = new System.Drawing.Size(136, 20);
            this.txtseri.TabIndex = 3;
            // 
            // txtDanhbo
            // 
            this.txtDanhbo.Location = new System.Drawing.Point(483, 55);
            this.txtDanhbo.Name = "txtDanhbo";
            this.txtDanhbo.Size = new System.Drawing.Size(136, 20);
            this.txtDanhbo.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTongSPH);
            this.groupBox1.Controls.Add(this.txtTongLNTT);
            this.groupBox1.Controls.Add(this.txtTong);
            this.groupBox1.Controls.Add(this.txtTongPhi);
            this.groupBox1.Controls.Add(this.txtTongVAT);
            this.groupBox1.Controls.Add(this.txtTongTiennuoc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvDShoadonton);
            this.groupBox1.Location = new System.Drawing.Point(13, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 257);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtTongSPH
            // 
            this.txtTongSPH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSPH.Location = new System.Drawing.Point(194, 213);
            this.txtTongSPH.Name = "txtTongSPH";
            this.txtTongSPH.ReadOnly = true;
            this.txtTongSPH.Size = new System.Drawing.Size(98, 20);
            this.txtTongSPH.TabIndex = 9;
            // 
            // txtTongLNTT
            // 
            this.txtTongLNTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongLNTT.Location = new System.Drawing.Point(288, 213);
            this.txtTongLNTT.Name = "txtTongLNTT";
            this.txtTongLNTT.ReadOnly = true;
            this.txtTongLNTT.Size = new System.Drawing.Size(111, 20);
            this.txtTongLNTT.TabIndex = 8;
            this.txtTongLNTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTong
            // 
            this.txtTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTong.Location = new System.Drawing.Point(695, 213);
            this.txtTong.Name = "txtTong";
            this.txtTong.ReadOnly = true;
            this.txtTong.Size = new System.Drawing.Size(95, 20);
            this.txtTong.TabIndex = 7;
            this.txtTong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTongPhi
            // 
            this.txtTongPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhi.Location = new System.Drawing.Point(603, 213);
            this.txtTongPhi.Name = "txtTongPhi";
            this.txtTongPhi.ReadOnly = true;
            this.txtTongPhi.Size = new System.Drawing.Size(95, 20);
            this.txtTongPhi.TabIndex = 6;
            this.txtTongPhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTongVAT
            // 
            this.txtTongVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongVAT.Location = new System.Drawing.Point(503, 213);
            this.txtTongVAT.Name = "txtTongVAT";
            this.txtTongVAT.ReadOnly = true;
            this.txtTongVAT.Size = new System.Drawing.Size(103, 20);
            this.txtTongVAT.TabIndex = 5;
            this.txtTongVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTongTiennuoc
            // 
            this.txtTongTiennuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTiennuoc.Location = new System.Drawing.Point(395, 213);
            this.txtTongTiennuoc.Name = "txtTongTiennuoc";
            this.txtTongTiennuoc.ReadOnly = true;
            this.txtTongTiennuoc.Size = new System.Drawing.Size(115, 20);
            this.txtTongTiennuoc.TabIndex = 4;
            this.txtTongTiennuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng cộng:";
            // 
            // dgvDShoadonton
            // 
            this.dgvDShoadonton.AutoGenerateColumns = false;
            this.dgvDShoadonton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDShoadonton.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sOHDDataGridViewTextBoxColumn,
            this.seriDataGridViewTextBoxColumn,
            this.namDataGridViewTextBoxColumn,
            this.kyghiDataGridViewTextBoxColumn,
            this.sOPHATHANHDataGridViewTextBoxColumn,
            this.lNTTDataGridViewTextBoxColumn,
            this.tongtien0VATDataGridViewTextBoxColumn,
            this.tienvatDataGridViewTextBoxColumn,
            this.tienBVMTDataGridViewTextBoxColumn,
            this.tongtienDataGridViewTextBoxColumn});
            this.dgvDShoadonton.DataSource = this.getBaocaoHoadonton1BindingSource;
            this.dgvDShoadonton.Location = new System.Drawing.Point(6, 19);
            this.dgvDShoadonton.Name = "dgvDShoadonton";
            this.dgvDShoadonton.Size = new System.Drawing.Size(784, 183);
            this.dgvDShoadonton.TabIndex = 0;
            this.dgvDShoadonton.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDShoadonton_CellClick);
            this.dgvDShoadonton.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // sOHDDataGridViewTextBoxColumn
            // 
            this.sOHDDataGridViewTextBoxColumn.DataPropertyName = "SO_HD";
            this.sOHDDataGridViewTextBoxColumn.HeaderText = "SO_HD";
            this.sOHDDataGridViewTextBoxColumn.Name = "sOHDDataGridViewTextBoxColumn";
            this.sOHDDataGridViewTextBoxColumn.Visible = false;
            // 
            // seriDataGridViewTextBoxColumn
            // 
            this.seriDataGridViewTextBoxColumn.DataPropertyName = "seri";
            this.seriDataGridViewTextBoxColumn.HeaderText = "seri";
            this.seriDataGridViewTextBoxColumn.Name = "seriDataGridViewTextBoxColumn";
            this.seriDataGridViewTextBoxColumn.ReadOnly = true;
            this.seriDataGridViewTextBoxColumn.Width = 50;
            // 
            // namDataGridViewTextBoxColumn
            // 
            this.namDataGridViewTextBoxColumn.DataPropertyName = "nam";
            this.namDataGridViewTextBoxColumn.HeaderText = "Năm";
            this.namDataGridViewTextBoxColumn.Name = "namDataGridViewTextBoxColumn";
            this.namDataGridViewTextBoxColumn.Width = 50;
            // 
            // kyghiDataGridViewTextBoxColumn
            // 
            this.kyghiDataGridViewTextBoxColumn.DataPropertyName = "kyghi";
            this.kyghiDataGridViewTextBoxColumn.HeaderText = "Kỳ ";
            this.kyghiDataGridViewTextBoxColumn.Name = "kyghiDataGridViewTextBoxColumn";
            this.kyghiDataGridViewTextBoxColumn.Width = 40;
            // 
            // sOPHATHANHDataGridViewTextBoxColumn
            // 
            this.sOPHATHANHDataGridViewTextBoxColumn.DataPropertyName = "SOPHATHANH";
            this.sOPHATHANHDataGridViewTextBoxColumn.HeaderText = "Số Phát hành";
            this.sOPHATHANHDataGridViewTextBoxColumn.Name = "sOPHATHANHDataGridViewTextBoxColumn";
            // 
            // lNTTDataGridViewTextBoxColumn
            // 
            this.lNTTDataGridViewTextBoxColumn.DataPropertyName = "LNTT";
            this.lNTTDataGridViewTextBoxColumn.HeaderText = "LNTT";
            this.lNTTDataGridViewTextBoxColumn.Name = "lNTTDataGridViewTextBoxColumn";
            this.lNTTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tongtien0VATDataGridViewTextBoxColumn
            // 
            this.tongtien0VATDataGridViewTextBoxColumn.DataPropertyName = "tongtien0VAT";
            this.tongtien0VATDataGridViewTextBoxColumn.HeaderText = "Tiền nước";
            this.tongtien0VATDataGridViewTextBoxColumn.Name = "tongtien0VATDataGridViewTextBoxColumn";
            // 
            // tienvatDataGridViewTextBoxColumn
            // 
            this.tienvatDataGridViewTextBoxColumn.DataPropertyName = "tienvat";
            this.tienvatDataGridViewTextBoxColumn.HeaderText = "Tiền Thuế";
            this.tienvatDataGridViewTextBoxColumn.Name = "tienvatDataGridViewTextBoxColumn";
            // 
            // tienBVMTDataGridViewTextBoxColumn
            // 
            this.tienBVMTDataGridViewTextBoxColumn.DataPropertyName = "tienBVMT";
            this.tienBVMTDataGridViewTextBoxColumn.HeaderText = "Tiền Phí";
            this.tienBVMTDataGridViewTextBoxColumn.Name = "tienBVMTDataGridViewTextBoxColumn";
            // 
            // tongtienDataGridViewTextBoxColumn
            // 
            this.tongtienDataGridViewTextBoxColumn.DataPropertyName = "tongtien";
            this.tongtienDataGridViewTextBoxColumn.HeaderText = "Tổng tiền";
            this.tongtienDataGridViewTextBoxColumn.Name = "tongtienDataGridViewTextBoxColumn";
            // 
            // getBaocaoHoadonton1BindingSource
            // 
            this.getBaocaoHoadonton1BindingSource.DataMember = "getBaocaoHoadonton1";
            this.getBaocaoHoadonton1BindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::QLCongNo.Properties.Resources._037_Colorize_24x24_72;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(49, 22);
            this.btnTim.Text = "Tìm";
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
            this.btnTim,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // getBaocaoHoadonton1TableAdapter
            // 
            this.getBaocaoHoadonton1TableAdapter.ClearBeforeFill = true;
            // 
            // frBaocaoHoadonton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 351);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDanhbo);
            this.Controls.Add(this.txtseri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frBaocaoHoadonton";
            this.Text = "Báo cáo hóa đơn tồn";
            this.Load += new System.EventHandler(this.frBaocaoHoadonton_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDShoadonton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBaocaoHoadonton1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtseri;
        private System.Windows.Forms.TextBox txtDanhbo;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDShoadonton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idseri;
        private System.Windows.Forms.ToolStripButton btnTim;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.BindingSource getBaocaoHoadonton1BindingSource;
        private CAPNUOC_TDCDataSetTableAdapters.getBaocaoHoadontonTableAdapter getBaocaoHoadonton1TableAdapter;
        private System.Windows.Forms.TextBox txtTongSPH;
        private System.Windows.Forms.TextBox txtTongLNTT;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.TextBox txtTongPhi;
        private System.Windows.Forms.TextBox txtTongVAT;
        private System.Windows.Forms.TextBox txtTongTiennuoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn sOHDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyghiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sOPHATHANHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lNTTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien0VATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienvatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienBVMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtienDataGridViewTextBoxColumn;
    }
}