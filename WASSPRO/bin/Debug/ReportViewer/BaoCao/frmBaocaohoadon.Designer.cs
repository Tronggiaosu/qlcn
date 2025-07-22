namespace QLCongNo.ReportViewer.BaoCao
{
    partial class frmBaocaohoadon
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpdenngay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtptungay = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDenky = new System.Windows.Forms.ComboBox();
            this.cboTuky = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXembaocao = new System.Windows.Forms.Button();
            this.cbochonloaibaocao = new System.Windows.Forms.ComboBox();
            this.cAPNUOC_TDCDataSet = new QLCongNo.CAPNUOC_TDCDataSet();
            this.cAPNUOCTDCDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOCTDCDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpdenngay);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtptungay);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 78);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn ngày tháng năm";
            // 
            // dtpdenngay
            // 
            this.dtpdenngay.CustomFormat = "dd-MM-yyyy";
            this.dtpdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdenngay.Location = new System.Drawing.Point(313, 30);
            this.dtpdenngay.Name = "dtpdenngay";
            this.dtpdenngay.Size = new System.Drawing.Size(141, 20);
            this.dtpdenngay.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đến ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Từ ngày:";
            // 
            // dtptungay
            // 
            this.dtptungay.CustomFormat = "dd-MM-yyyy";
            this.dtptungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptungay.Location = new System.Drawing.Point(78, 29);
            this.dtptungay.Name = "dtptungay";
            this.dtptungay.Size = new System.Drawing.Size(140, 20);
            this.dtptungay.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cboDenky);
            this.groupBox1.Controls.Add(this.cboTuky);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(31, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 78);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn kỳ báo cáo";
            // 
            // cboDenky
            // 
            this.cboDenky.DisplayMember = "ten_kyghi";
            this.cboDenky.FormattingEnabled = true;
            this.cboDenky.Location = new System.Drawing.Point(313, 27);
            this.cboDenky.Name = "cboDenky";
            this.cboDenky.Size = new System.Drawing.Size(171, 21);
            this.cboDenky.TabIndex = 3;
            this.cboDenky.ValueMember = "ID_kyghi";
            // 
            // cboTuky
            // 
            this.cboTuky.DisplayMember = "Ten_kyghi";
            this.cboTuky.FormattingEnabled = true;
            this.cboTuky.Location = new System.Drawing.Point(57, 27);
            this.cboTuky.Name = "cboTuky";
            this.cboTuky.Size = new System.Drawing.Size(188, 21);
            this.cboTuky.TabIndex = 2;
            this.cboTuky.ValueMember = "Id_kyghi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đến kỳ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ kỳ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Báo cáo hóa đơn";
            // 
            // btnXembaocao
            // 
            this.btnXembaocao.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXembaocao.Location = new System.Drawing.Point(222, 165);
            this.btnXembaocao.Name = "btnXembaocao";
            this.btnXembaocao.Size = new System.Drawing.Size(113, 23);
            this.btnXembaocao.TabIndex = 6;
            this.btnXembaocao.Text = "xem báo cáo";
            this.btnXembaocao.UseVisualStyleBackColor = true;
            this.btnXembaocao.Click += new System.EventHandler(this.btnXembaocao_Click);
            // 
            // cbochonloaibaocao
            // 
            this.cbochonloaibaocao.FormattingEnabled = true;
            this.cbochonloaibaocao.Items.AddRange(new object[] {
            "----chọn loại báo báo----",
            "1. Thống kê hóa đơn tồn từ kỳ đến kỳ",
            "2. Thống kê hóa đơn tồn ngày tháng năm"});
            this.cbochonloaibaocao.Location = new System.Drawing.Point(109, 45);
            this.cbochonloaibaocao.Name = "cbochonloaibaocao";
            this.cbochonloaibaocao.Size = new System.Drawing.Size(351, 21);
            this.cbochonloaibaocao.TabIndex = 5;
            this.cbochonloaibaocao.SelectedIndexChanged += new System.EventHandler(this.cbochonloaibaocao_SelectedIndexChanged);
            // 
            // cAPNUOC_TDCDataSet
            // 
            this.cAPNUOC_TDCDataSet.DataSetName = "CAPNUOC_TDCDataSet";
            this.cAPNUOC_TDCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cAPNUOCTDCDataSetBindingSource
            // 
            this.cAPNUOCTDCDataSetBindingSource.DataSource = this.cAPNUOC_TDCDataSet;
            this.cAPNUOCTDCDataSetBindingSource.Position = 0;
            // 
            // frmBaocaohoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 203);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXembaocao);
            this.Controls.Add(this.cbochonloaibaocao);
            this.Name = "frmBaocaohoadon";
            this.Text = "Báo cáo hóa đơn tồn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaocaohoadon_FormClosing);
            this.Load += new System.EventHandler(this.frmBaocaohoadon_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOC_TDCDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cAPNUOCTDCDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtptungay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDenky;
        private System.Windows.Forms.ComboBox cboTuky;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXembaocao;
        private System.Windows.Forms.ComboBox cbochonloaibaocao;
        private System.Windows.Forms.DateTimePicker dtpdenngay;
        private System.Windows.Forms.Label label5;
        private CAPNUOC_TDCDataSet cAPNUOC_TDCDataSet;
        private System.Windows.Forms.BindingSource cAPNUOCTDCDataSetBindingSource;
    }
}