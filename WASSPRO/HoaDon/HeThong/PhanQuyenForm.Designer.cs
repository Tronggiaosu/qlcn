namespace QLCongNo
{
    partial class PhanQuyenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhanQuyenForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.cancelButton = new System.Windows.Forms.ToolStripButton();
            this.quitButton = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupListBox = new System.Windows.Forms.CheckedListBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editButton,
            this.cancelButton,
            this.quitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1148, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // editButton
            // 
            this.editButton.Image = global::QLCongNo.Properties.Resources.role_new;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(93, 22);
            this.editButton.Text = "Phân quyền";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Image = global::QLCongNo.Properties.Resources.cancel;
            this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(48, 22);
            this.cancelButton.Text = "Hủy";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Image = global::QLCongNo.Properties.Resources.thoat;
            this.quitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(60, 22);
            this.quitButton.Text = "Thoát";
            this.quitButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.treeView1.Enabled = false;
            this.treeView1.Location = new System.Drawing.Point(555, 25);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(593, 716);
            this.treeView1.TabIndex = 23;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // groupListBox
            // 
            this.groupListBox.CheckOnClick = true;
            this.groupListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupListBox.FormattingEnabled = true;
            this.groupListBox.Location = new System.Drawing.Point(0, 25);
            this.groupListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupListBox.Name = "groupListBox";
            this.groupListBox.Size = new System.Drawing.Size(544, 716);
            this.groupListBox.TabIndex = 22;
            this.groupListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.groupListBox_ItemCheck);
            // 
            // PhanQuyenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 741);
            this.ControlBox = false;
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupListBox);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PhanQuyenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHÂN QUYỀN ";
            this.Load += new System.EventHandler(this.PhanQuyenForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton editButton;
        private System.Windows.Forms.ToolStripButton quitButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckedListBox groupListBox;
        private System.Windows.Forms.ToolStripButton cancelButton;
    }
}