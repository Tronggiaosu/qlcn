namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    partial class UcBaocaoHoadontontheoky
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
            this.label1 = new View.Core.NovLabel();
            this.label2 = new View.Core.NovLabel();
            this.label3 = new View.Core.NovLabel();
            this.txtseri = new View.Core.NovTextBox();
            this.txtDanhbo = new View.Core.NovTextBox();
            this.groupBox1 = new View.Core.NovGroupBox();
            this.txtTongSPH = new View.Core.NovTextBox();
            this.txtTong = new View.Core.NovTextBox();
            this.label4 = new View.Core.NovLabel();
            this.dgvDShoadonton = new View.Core.NovDataGridView();
            this.getBaocaoHoadonton1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.btnTim = new View.Core.NovToolStripButton();
            this.btnThoat = new View.Core.NovToolStripButton();
            this.toolStrip1 = new View.Core.NovToolStrip();
            this.btnXemchitiet = new View.Core.NovToolStripButton();
            this.getBaocaoHoadonton1TableAdapter = new QLCongNo.CAPNUOC_TDCDataSetTableAdapters.getBaocaoHoadontonTableAdapter();
            this.label5 = new View.Core.NovLabel();
            this.txtSohoadon = new View.Core.NovTextBox();
            this.label6 = new View.Core.NovLabel();
            this.txtSearch = new View.Core.NovTextBox();
            this.label7 = new View.Core.NovLabel();
            this.label8 = new View.Core.NovLabel();
            this.txtTuky = new View.Core.NovTextBox();
            this.txtDenky = new View.Core.NovTextBox();
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
            this.label1.Location = new System.Drawing.Point(342, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xem nợ tồn thu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số seri:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(577, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Danh bộ:";
            // 
            // txtseri
            // 
            this.txtseri.Location = new System.Drawing.Point(77, 28);
            this.txtseri.Name = "txtseri";
            this.txtseri.ReadOnly = true;
            this.txtseri.Size = new System.Drawing.Size(136, 20);
            this.txtseri.TabIndex = 3;
            // 
            // txtDanhbo
            // 
            this.txtDanhbo.Location = new System.Drawing.Point(634, 25);
            this.txtDanhbo.Name = "txtDanhbo";
            this.txtDanhbo.ReadOnly = true;
            this.txtDanhbo.Size = new System.Drawing.Size(136, 20);
            this.txtDanhbo.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTongSPH);
            this.groupBox1.Controls.Add(this.txtTong);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvDShoadonton);
            this.groupBox1.Location = new System.Drawing.Point(13, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 335);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtTongSPH
            // 
            this.txtTongSPH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSPH.Location = new System.Drawing.Point(593, 309);
            this.txtTongSPH.Name = "txtTongSPH";
            this.txtTongSPH.ReadOnly = true;
            this.txtTongSPH.Size = new System.Drawing.Size(98, 20);
            this.txtTongSPH.TabIndex = 9;
            // 
            // txtTong
            // 
            this.txtTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTong.Location = new System.Drawing.Point(697, 309);
            this.txtTong.Name = "txtTong";
            this.txtTong.ReadOnly = true;
            this.txtTong.Size = new System.Drawing.Size(95, 20);
            this.txtTong.TabIndex = 7;
            this.txtTong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 316);
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
            this.dgvDShoadonton.Size = new System.Drawing.Size(794, 279);
            this.dgvDShoadonton.TabIndex = 0;
            this.dgvDShoadonton.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDShoadonton_CellClick);
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
            this.btnThoat.Visible = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTim,
            this.btnXemchitiet,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            //this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
            // getBaocaoHoadonton1TableAdapter
            // 
            this.getBaocaoHoadonton1TableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số hóa đơn:";
            // 
            // txtSohoadon
            // 
            this.txtSohoadon.Location = new System.Drawing.Point(77, 52);
            this.txtSohoadon.Name = "txtSohoadon";
            this.txtSohoadon.ReadOnly = true;
            this.txtSohoadon.Size = new System.Drawing.Size(136, 20);
            this.txtSohoadon.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(148, 78);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(599, 20);
            this.txtSearch.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(530, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Từ kỳ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(654, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Đến kỳ:";
            // 
            // txtTuky
            // 
            this.txtTuky.Location = new System.Drawing.Point(573, 52);
            this.txtTuky.Name = "txtTuky";
            this.txtTuky.ReadOnly = true;
            this.txtTuky.Size = new System.Drawing.Size(70, 20);
            this.txtTuky.TabIndex = 14;
            // 
            // txtDenky
            // 
            this.txtDenky.Location = new System.Drawing.Point(700, 51);
            this.txtDenky.Name = "txtDenky";
            this.txtDenky.ReadOnly = true;
            this.txtDenky.Size = new System.Drawing.Size(70, 20);
            this.txtDenky.TabIndex = 15;
            // 
            // frBaocaoHoadontontheoky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 445);
            this.Controls.Add(this.txtDenky);
            this.Controls.Add(this.txtTuky);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSohoadon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDanhbo);
            this.Controls.Add(this.txtseri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frBaocaoHoadontontheoky";
            this.Text = "Báo cáo hóa đơn tồn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frBaocaoHoadontontheoky_FormClosing);
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

        private View.Core.NovLabel label1;
        private View.Core.NovLabel label2;
        private View.Core.NovLabel label3;
        private View.Core.NovTextBox txtseri;
        private View.Core.NovTextBox txtDanhbo;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private View.Core.NovGroupBox groupBox1;
        private View.Core.NovDataGridView dgvDShoadonton;
        private View.Core.NovDataGridViewTextBoxColumn idseri;
        private View.Core.NovTextBox txtTongSPH;
        private View.Core.NovTextBox txtTong;
        private View.Core.NovLabel label4;
        private View.Core.NovToolStripButton btnTim;
        private View.Core.NovToolStripButton btnThoat;
        private View.Core.NovToolStrip toolStrip1;
        private System.Windows.Forms.BindingSource getBaocaoHoadonton1BindingSource;
        private CAPNUOC_TDCDataSetTableAdapters.getBaocaoHoadontonTableAdapter getBaocaoHoadonton1TableAdapter;
        private View.Core.NovLabel label5;
        private View.Core.NovTextBox txtSohoadon;
        private View.Core.NovLabel label6;
        private View.Core.NovTextBox txtSearch;
        private View.Core.NovToolStripButton btnXemchitiet;
        private View.Core.NovLabel label7;
        private View.Core.NovLabel label8;
        private View.Core.NovTextBox txtTuky;
        private View.Core.NovTextBox txtDenky;
    }
}