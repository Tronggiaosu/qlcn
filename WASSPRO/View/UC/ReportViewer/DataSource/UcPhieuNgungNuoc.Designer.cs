namespace QLCongNo.ReportViewer.DataSource
{
    partial class UcPhieuNgungNuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPhieuNgungNuoc));
            this.btnInPhieu = new View.Core.NovButton();
            this.SuspendLayout();
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(13, 13);
            this.btnInPhieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(88, 28);
            this.btnInPhieu.TabIndex = 0;
            this.btnInPhieu.Text = "In Phiếu";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.button1_Click);
            // 
            // PhieuNgungNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 449);
            this.Controls.Add(this.btnInPhieu);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PhieuNgungNuoc";
            
            this.Text = "PhieuNgungNuoc";
            this.Load += new System.EventHandler(this.PhieuNgungNuoc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private View.Core.NovButton btnInPhieu;
    }
}