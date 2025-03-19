namespace QLCongNo.View.UC
{
    partial class UcSidebar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnUser = new FontAwesome.Sharp.IconButton();
            this.PnlHeader = new QLCongNo.View.Core.NovPanel();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.BtnCollapseSideBar = new FontAwesome.Sharp.IconButton();
            this.DDMHeThong = new QLCongNo.View.BaseControl.NovDropdownMenu(this.components);
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhómNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phânQuyềnChứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtLộTrìnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đemHóaĐơnVềPhânChiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSHóaĐơnChưaChiaChoTNVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đồngBộDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlMenu = new QLCongNo.View.Core.PanelWoScrollbar();
            this.PnlFooter = new System.Windows.Forms.TableLayoutPanel();
            this.PnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.DDMHeThong.SuspendLayout();
            this.PnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnUser
            // 
            this.BtnUser.BackColor = System.Drawing.Color.IndianRed;
            this.BtnUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnUser.FlatAppearance.BorderSize = 0;
            this.BtnUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(119)))), ((int)(((byte)(235)))));
            this.BtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUser.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUser.ForeColor = System.Drawing.Color.White;
            this.BtnUser.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.BtnUser.IconColor = System.Drawing.Color.White;
            this.BtnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnUser.IconSize = 30;
            this.BtnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.Location = new System.Drawing.Point(0, 0);
            this.BtnUser.Margin = new System.Windows.Forms.Padding(0);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnUser.Size = new System.Drawing.Size(540, 88);
            this.BtnUser.TabIndex = 10;
            this.BtnUser.Text = "   Toan-PN";
            this.BtnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUser.UseVisualStyleBackColor = false;
            this.BtnUser.Visible = false;
            this.BtnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // PnlHeader
            // 
            this.PnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.PnlHeader.Controls.Add(this.PicLogo);
            this.PnlHeader.Controls.Add(this.BtnCollapseSideBar);
            this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlHeader.ForeColor = System.Drawing.Color.MediumBlue;
            this.PnlHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(540, 106);
            this.PnlHeader.TabIndex = 0;
            // 
            // PicLogo
            // 
            this.PicLogo.BackgroundImage = global::QLCongNo.Properties.Resources.logoThuDuc2;
            this.PicLogo.Image = global::QLCongNo.Properties.Resources.logoThuDuc2;
            this.PicLogo.InitialImage = global::QLCongNo.Properties.Resources.logoThuDuc2;
            this.PicLogo.Location = new System.Drawing.Point(15, 5);
            this.PicLogo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.PicLogo.Size = new System.Drawing.Size(150, 99);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLogo.TabIndex = 1;
            this.PicLogo.TabStop = false;
            this.PicLogo.Click += new System.EventHandler(this.BtnCollapseSideBar_Click);
            // 
            // BtnCollapseSideBar
            // 
            this.BtnCollapseSideBar.BackColor = System.Drawing.Color.Transparent;
            this.BtnCollapseSideBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCollapseSideBar.FlatAppearance.BorderSize = 0;
            this.BtnCollapseSideBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(119)))), ((int)(((byte)(235)))));
            this.BtnCollapseSideBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCollapseSideBar.ForeColor = System.Drawing.Color.White;
            this.BtnCollapseSideBar.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.BtnCollapseSideBar.IconColor = System.Drawing.Color.White;
            this.BtnCollapseSideBar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCollapseSideBar.IconSize = 24;
            this.BtnCollapseSideBar.Location = new System.Drawing.Point(473, 0);
            this.BtnCollapseSideBar.Margin = new System.Windows.Forms.Padding(0);
            this.BtnCollapseSideBar.Name = "BtnCollapseSideBar";
            this.BtnCollapseSideBar.Size = new System.Drawing.Size(67, 106);
            this.BtnCollapseSideBar.TabIndex = 0;
            this.BtnCollapseSideBar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnCollapseSideBar.UseVisualStyleBackColor = false;
            this.BtnCollapseSideBar.Click += new System.EventHandler(this.BtnCollapseSideBar_Click);
            // 
            // DDMHeThong
            // 
            this.DDMHeThong.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.DDMHeThong.IsMainMenu = false;
            this.DDMHeThong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderToolStripMenuItem,
            this.invoicesToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem,
            this.đồngBộDữLiệuToolStripMenuItem});
            this.DDMHeThong.MenuItemHeight = 25;
            this.DDMHeThong.MenuItemTextColor = System.Drawing.Color.Empty;
            this.DDMHeThong.Name = "noviDropdownMenu1";
            this.DDMHeThong.PrimaryColor = System.Drawing.Color.Empty;
            this.DDMHeThong.Size = new System.Drawing.Size(217, 124);
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânViênToolStripMenuItem,
            this.ngườiDùngToolStripMenuItem,
            this.nhómNgườiDùngToolStripMenuItem,
            this.phânQuyềnChứcNăngToolStripMenuItem,
            this.cậpNhậtLộTrìnhToolStripMenuItem,
            this.đemHóaĐơnVềPhânChiaToolStripMenuItem,
            this.dSHóaĐơnChưaChiaChoTNVToolStripMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.orderToolStripMenuItem.Text = "Quản Lý Người Dùng";
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.nhânViênToolStripMenuItem.Text = "Nhân Viên";
            // 
            // ngườiDùngToolStripMenuItem
            // 
            this.ngườiDùngToolStripMenuItem.Name = "ngườiDùngToolStripMenuItem";
            this.ngườiDùngToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.ngườiDùngToolStripMenuItem.Text = "Người Dùng";
            // 
            // nhómNgườiDùngToolStripMenuItem
            // 
            this.nhómNgườiDùngToolStripMenuItem.Name = "nhómNgườiDùngToolStripMenuItem";
            this.nhómNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.nhómNgườiDùngToolStripMenuItem.Text = "Nhóm Người Dùng";
            // 
            // phânQuyềnChứcNăngToolStripMenuItem
            // 
            this.phânQuyềnChứcNăngToolStripMenuItem.Name = "phânQuyềnChứcNăngToolStripMenuItem";
            this.phânQuyềnChứcNăngToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.phânQuyềnChứcNăngToolStripMenuItem.Text = "Phân Quyền Chức Năng";
            // 
            // cậpNhậtLộTrìnhToolStripMenuItem
            // 
            this.cậpNhậtLộTrìnhToolStripMenuItem.Name = "cậpNhậtLộTrìnhToolStripMenuItem";
            this.cậpNhậtLộTrìnhToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.cậpNhậtLộTrìnhToolStripMenuItem.Text = "Cập Nhật Lộ Trình";
            // 
            // đemHóaĐơnVềPhânChiaToolStripMenuItem
            // 
            this.đemHóaĐơnVềPhânChiaToolStripMenuItem.Name = "đemHóaĐơnVềPhânChiaToolStripMenuItem";
            this.đemHóaĐơnVềPhânChiaToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.đemHóaĐơnVềPhânChiaToolStripMenuItem.Text = "Đem Hóa Đơn Về Phân Chia Cho TNV";
            // 
            // dSHóaĐơnChưaChiaChoTNVToolStripMenuItem
            // 
            this.dSHóaĐơnChưaChiaChoTNVToolStripMenuItem.Name = "dSHóaĐơnChưaChiaChoTNVToolStripMenuItem";
            this.dSHóaĐơnChưaChiaChoTNVToolStripMenuItem.Size = new System.Drawing.Size(340, 26);
            this.dSHóaĐơnChưaChiaChoTNVToolStripMenuItem.Text = "DS Hóa Đơn Chưa Chia Cho TNV";
            // 
            // invoicesToolStripMenuItem
            // 
            this.invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            this.invoicesToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.invoicesToolStripMenuItem.Text = "Thay Đổi Mật Khẩu";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // đồngBộDữLiệuToolStripMenuItem
            // 
            this.đồngBộDữLiệuToolStripMenuItem.Name = "đồngBộDữLiệuToolStripMenuItem";
            this.đồngBộDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.đồngBộDữLiệuToolStripMenuItem.Text = "Đồng Bộ Dữ Liệu";
            // 
            // PnlMenu
            // 
            this.PnlMenu.AutoScroll = true;
            this.PnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.PnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMenu.Location = new System.Drawing.Point(0, 106);
            this.PnlMenu.Margin = new System.Windows.Forms.Padding(0);
            this.PnlMenu.Name = "PnlMenu";
            this.PnlMenu.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.PnlMenu.RowCount = 1;
            this.PnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PnlMenu.ScrollSpeedFactor = 5;
            this.PnlMenu.Size = new System.Drawing.Size(540, 3481);
            this.PnlMenu.TabIndex = 20;
            // 
            // PnlFooter
            // 
            this.PnlFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PnlFooter.Controls.Add(this.BtnUser);
            this.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlFooter.Location = new System.Drawing.Point(0, 3587);
            this.PnlFooter.Margin = new System.Windows.Forms.Padding(0);
            this.PnlFooter.Name = "PnlFooter";
            this.PnlFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.PnlFooter.Size = new System.Drawing.Size(540, 88);
            this.PnlFooter.TabIndex = 21;
            // 
            // UcSidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(43)))), ((int)(((byte)(83)))));
            this.Controls.Add(this.PnlMenu);
            this.Controls.Add(this.PnlFooter);
            this.Controls.Add(this.PnlHeader);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UcSidebar";
            this.Size = new System.Drawing.Size(540, 3675);
            this.Load += new System.EventHandler(this.UcSidebar_Load);
            this.PnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.DDMHeThong.ResumeLayout(false);
            this.PnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconButton BtnUser;
        private View.Core.NovPanel PnlHeader;
        private System.Windows.Forms.PictureBox PicLogo;
        private FontAwesome.Sharp.IconButton BtnCollapseSideBar;
        private BaseControl.NovDropdownMenu DDMHeThong;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đồngBộDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ngườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhómNgườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phânQuyềnChứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtLộTrìnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đemHóaĐơnVềPhânChiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dSHóaĐơnChưaChiaChoTNVToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel PnlFooter;
        private QLCongNo.View.Core.PanelWoScrollbar PnlMenu;
    }
}
