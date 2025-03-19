namespace QLCongNo.View
{
    partial class FrmMain
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
            QLCongNo.CAPNUOC_TNCEntities capnuoC_TNCEntities1 = new QLCongNo.CAPNUOC_TNCEntities();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.PnlTitle = new System.Windows.Forms.Panel();
            this.BtnUser = new FontAwesome.Sharp.IconButton();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnMinimize = new FontAwesome.Sharp.IconButton();
            this.BtnMaximize = new FontAwesome.Sharp.IconButton();
            this.BtnClose = new FontAwesome.Sharp.IconButton();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.ucLogin1 = new QLCongNo.UcLogin();
            this.PnlContainer = new System.Windows.Forms.SplitContainer();
            this.ucSidebar = new QLCongNo.View.UC.UcSidebar();
            this.DDMHeThong = new QLCongNo.View.BaseControl.NovDropdownMenu(this.components);
            this.invoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đồngBộDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlTitle.SuspendLayout();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PnlContainer)).BeginInit();
            this.PnlContainer.Panel1.SuspendLayout();
            this.PnlContainer.Panel2.SuspendLayout();
            this.PnlContainer.SuspendLayout();
            this.DDMHeThong.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTitle
            // 
            this.PnlTitle.BackColor = System.Drawing.Color.White;
            this.PnlTitle.Controls.Add(this.BtnUser);
            this.PnlTitle.Controls.Add(this.LblTitle);
            this.PnlTitle.Controls.Add(this.BtnMinimize);
            this.PnlTitle.Controls.Add(this.BtnMaximize);
            this.PnlTitle.Controls.Add(this.BtnClose);
            this.PnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTitle.Location = new System.Drawing.Point(0, 0);
            this.PnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.PnlTitle.Name = "PnlTitle";
            this.PnlTitle.Size = new System.Drawing.Size(538, 38);
            this.PnlTitle.TabIndex = 6;
            // 
            // BtnUser
            // 
            this.BtnUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUser.BackColor = System.Drawing.Color.IndianRed;
            this.BtnUser.FlatAppearance.BorderSize = 0;
            this.BtnUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(119)))), ((int)(((byte)(235)))));
            this.BtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUser.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUser.ForeColor = System.Drawing.Color.White;
            this.BtnUser.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.BtnUser.IconColor = System.Drawing.Color.White;
            this.BtnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnUser.IconSize = 16;
            this.BtnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.Location = new System.Drawing.Point(257, -1);
            this.BtnUser.Margin = new System.Windows.Forms.Padding(0);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.BtnUser.Size = new System.Drawing.Size(169, 39);
            this.BtnUser.TabIndex = 53;
            this.BtnUser.Text = "Toan-PN";
            this.BtnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUser.UseVisualStyleBackColor = false;
            this.BtnUser.Visible = false;
            this.BtnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.Location = new System.Drawing.Point(19, 5);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(108, 28);
            this.LblTitle.TabIndex = 7;
            this.LblTitle.Text = "Dashboard";
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(128)))));
            this.BtnMinimize.FlatAppearance.BorderSize = 0;
            this.BtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.BtnMinimize.IconColor = System.Drawing.Color.Black;
            this.BtnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMinimize.IconSize = 16;
            this.BtnMinimize.Location = new System.Drawing.Point(426, 1);
            this.BtnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(37, 37);
            this.BtnMinimize.TabIndex = 30;
            this.BtnMinimize.UseVisualStyleBackColor = false;
            // 
            // BtnMaximize
            // 
            this.BtnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.BtnMaximize.FlatAppearance.BorderSize = 0;
            this.BtnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMaximize.IconChar = FontAwesome.Sharp.IconChar.Expand;
            this.BtnMaximize.IconColor = System.Drawing.Color.Black;
            this.BtnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMaximize.IconSize = 16;
            this.BtnMaximize.Location = new System.Drawing.Point(463, 1);
            this.BtnMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMaximize.Name = "BtnMaximize";
            this.BtnMaximize.Size = new System.Drawing.Size(37, 37);
            this.BtnMaximize.TabIndex = 40;
            this.BtnMaximize.UseVisualStyleBackColor = false;
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.BtnClose.IconColor = System.Drawing.Color.Black;
            this.BtnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnClose.IconSize = 16;
            this.BtnClose.Location = new System.Drawing.Point(500, 1);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(37, 37);
            this.BtnClose.TabIndex = 50;
            this.BtnClose.UseVisualStyleBackColor = false;
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.PnlMain.Controls.Add(this.ucLogin1);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 38);
            this.PnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.PnlMain.Size = new System.Drawing.Size(538, 530);
            this.PnlMain.TabIndex = 7;
            // 
            // ucLogin1
            // 
            this.ucLogin1.BackColor = System.Drawing.Color.White;
            this.ucLogin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogin1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLogin1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ucLogin1.Location = new System.Drawing.Point(0, 5);
            this.ucLogin1.Margin = new System.Windows.Forms.Padding(0);
            this.ucLogin1.Name = "ucLogin1";
            this.ucLogin1.Owner = null;
            this.ucLogin1.PnlParrent = null;
            this.ucLogin1.Size = new System.Drawing.Size(538, 525);
            this.ucLogin1.TabIndex = 0;
            // 
            // PnlContainer
            // 
            this.PnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.PnlContainer.Location = new System.Drawing.Point(0, 0);
            this.PnlContainer.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.PnlContainer.Name = "PnlContainer";
            // 
            // PnlContainer.Panel1
            // 
            this.PnlContainer.Panel1.Controls.Add(this.ucSidebar);
            // 
            // PnlContainer.Panel2
            // 
            this.PnlContainer.Panel2.Controls.Add(this.PnlMain);
            this.PnlContainer.Panel2.Controls.Add(this.PnlTitle);
            this.PnlContainer.Size = new System.Drawing.Size(819, 568);
            this.PnlContainer.SplitterDistance = 280;
            this.PnlContainer.SplitterIncrement = 2;
            this.PnlContainer.SplitterWidth = 1;
            this.PnlContainer.TabIndex = 0;
            // 
            // ucSidebar
            // 
            this.ucSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(43)))), ((int)(((byte)(83)))));
            this.ucSidebar.ContainerPanel = null;
            this.ucSidebar.db = capnuoC_TNCEntities1;
            this.ucSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSidebar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSidebar.ForeColor = System.Drawing.Color.MediumBlue;
            this.ucSidebar.Location = new System.Drawing.Point(0, 0);
            this.ucSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.ucSidebar.Name = "ucSidebar";
            this.ucSidebar.Owner = null;
            this.ucSidebar.PnlParrent = null;
            this.ucSidebar.Size = new System.Drawing.Size(280, 568);
            this.ucSidebar.TabIndex = 0;
            this.ucSidebar.Title = null;
            // 
            // DDMHeThong
            // 
            this.DDMHeThong.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.DDMHeThong.IsMainMenu = false;
            this.DDMHeThong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoicesToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem,
            this.đồngBộDữLiệuToolStripMenuItem});
            this.DDMHeThong.MenuItemHeight = 25;
            this.DDMHeThong.MenuItemTextColor = System.Drawing.Color.Empty;
            this.DDMHeThong.Name = "noviDropdownMenu1";
            this.DDMHeThong.PrimaryColor = System.Drawing.Color.Empty;
            this.DDMHeThong.Size = new System.Drawing.Size(205, 100);
            // 
            // invoicesToolStripMenuItem
            // 
            this.invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            this.invoicesToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.invoicesToolStripMenuItem.Text = "Thay Đổi Mật Khẩu";
            this.invoicesToolStripMenuItem.Click += new System.EventHandler(this.invoicesToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Visible = false;
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // đồngBộDữLiệuToolStripMenuItem
            // 
            this.đồngBộDữLiệuToolStripMenuItem.Name = "đồngBộDữLiệuToolStripMenuItem";
            this.đồngBộDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.đồngBộDữLiệuToolStripMenuItem.Text = "Đồng Bộ Dữ Liệu";
            this.đồngBộDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.đồngBộDữLiệuToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 568);
            this.Controls.Add(this.PnlContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Quản Lý Công Nợ";
            this.Load += new System.EventHandler(this.FrmMain_Load_1);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.PnlTitle.ResumeLayout(false);
            this.PnlTitle.PerformLayout();
            this.PnlMain.ResumeLayout(false);
            this.PnlContainer.Panel1.ResumeLayout(false);
            this.PnlContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PnlContainer)).EndInit();
            this.PnlContainer.ResumeLayout(false);
            this.DDMHeThong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlTitle;
        private System.Windows.Forms.Label LblTitle;
        private FontAwesome.Sharp.IconButton BtnMinimize;
        private FontAwesome.Sharp.IconButton BtnMaximize;
        private FontAwesome.Sharp.IconButton BtnClose;
        private System.Windows.Forms.Panel PnlMain;
        private UC.UcSidebar ucSidebar;
        private System.Windows.Forms.SplitContainer PnlContainer;
        private UcLogin ucLogin1;
        private FontAwesome.Sharp.IconButton BtnUser;
        private BaseControl.NovDropdownMenu DDMHeThong;
        private System.Windows.Forms.ToolStripMenuItem invoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đồngBộDữLiệuToolStripMenuItem;
    }
}