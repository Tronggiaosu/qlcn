using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLCongNo.View.UC.GachNo;
using QLCongNo.View.UC.HoaDon;

namespace QLCongNo.View.UC
{
    /// <summary>
    /// Represents a sidebar user control with collapsible functionality.
    /// </summary>
    public partial class UcSidebar_Hard : View.Core.NovUserControl
    {
        private const int _expandedWidth = 360;
        private const int _collapsedWidth = 60;
        private const int _menuItemHeight = 28;
        public Panel ContainerPanel { get; set; }
        public Label Title { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UcSidebar"/> class.
        /// </summary>
        public UcSidebar_Hard()
        {
            InitializeComponent();
            PnlMenu.AutoScroll = true;
        }

        private void UcSidebar_Load(object sender, EventArgs e)
        {
            DDMHeThong.IsMainMenu = true;
            CollapseAll(PnlMenu);
            FixWidth(PnlMenu);
            PnlMenu.AutoScroll = true;
            PnlMenu.VerticalScroll.Visible = false;
            PnlMenu.HorizontalScroll.Visible = false;
        }

        /// <summary>
        /// Handles the Click event of the BtnCollapseSideBar control.
        /// Toggles the sidebar between expanded and collapsed states.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnCollapseSideBar_Click(object sender, EventArgs e)
        {
            CollapseSideBar(Width > _collapsedWidth);
        }

        /// <summary>
        /// Toggles the sidebar between expanded and collapsed states.
        /// </summary>
        private void CollapseSideBar(bool isExpanded)
        {
            var dWidth = isExpanded ? _collapsedWidth : _expandedWidth;
            Parent.Width = dWidth;
            var parent = Parent.Parent as SplitContainer;
            parent.SplitterDistance = dWidth;
            Width = dWidth;
            PicLogo.Visible = !isExpanded;
            BtnCollapseSideBar.Dock = isExpanded ? DockStyle.Fill : DockStyle.Right;
            if (isExpanded) CollapseAll(PnlMenu);
            foreach (var pnl in Controls.OfType<Panel>())
            {
                pnl.Width = dWidth;
                foreach (var pnlSub in pnl.Controls.OfType<Panel>())
                {
                    pnlSub.Width = dWidth;
                    foreach (var btnItem in pnlSub.Controls.OfType<Button>())
                    {
                        if (isExpanded)
                        {
                            btnItem.Tag = btnItem.Text;
                            btnItem.Text = string.Empty;
                            btnItem.ImageAlign = ContentAlignment.MiddleCenter;
                            btnItem.Padding = new Padding(0);
                        }
                        else
                        {
                            btnItem.Text = btnItem.Tag?.ToString() ?? btnItem.Text;
                            btnItem.ImageAlign = ContentAlignment.MiddleLeft;
                            btnItem.Padding = new Padding(10, 0, 0, 0);
                        }

                        btnItem.Width = dWidth;
                    }
                }
            }
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            DDMHeThong.Show(Cursor.Position);
        }

        private void CollapseMenu()
        {
            // Collapse all the panels in the menu.
            foreach (Panel pnl in PnlMenu.Controls.OfType<Panel>())
            {
                Collapse(pnl);
            }
        }

        private void Collapse(Panel panel)
        {
            // set height = first child control's height

            //var firstChild = panel.Controls.OfType<Control>().FirstOrDefault();
            //if (firstChild != null)
            //{
            //    panel.Height = firstChild.Height;
            //}
            panel.Height = _menuItemHeight;
        }

        private void Expand(Panel panel)
        {
            // set the panel's height to the height of its  visible controls.
            panel.Height = panel.Controls.OfType<Control>().Where(c => c.Visible).Sum(c => c.Height);
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as Button;
            // if the it's the first item  of the parrent, collapse the panel.
            if (menuItem.Parent.Controls[0] == menuItem)
            {
                var panel = menuItem.Parent as Panel;
                if (panel.Height <= _menuItemHeight)
                {
                    Expand(panel);
                    CollapseSideBar(false);
                }
                else
                {
                    Collapse(panel);
                }
            }
        }

        //collapseAll
        private void CollapseAll(Panel pnl)
        {
            foreach (Panel Subpnl in pnl.Controls.OfType<Panel>())
            {
                Collapse(Subpnl);
            }
        }

        /// <summary>
        /// I don't know what on the run-time, the width of the control increase with unhandled. \
        /// so this code fix the width of the control to the parent's width.
        /// </summary>
        /// <param name="pnl"></param>
        private void FixWidth(Control pnl)
        {
            foreach (Control Subpnl in pnl.Controls)
            {
                Subpnl.Width = Parent.Width;
                FixWidth(Subpnl);
            }
        }

        private void ShowForm<T>(string title, params object[] args) where T : View.Core.NovUserControl
        {
            SuspendLayout();
            var uc = (T)Activator.CreateInstance(typeof(T), args);
            ContainerPanel.Controls.Clear();
            ContainerPanel.Controls.Add(uc);
            Title.Text = title;
            uc.Dock = DockStyle.Fill;
            CollapseSideBar(true);
            CollapseMenu();
            ResumeLayout();
        }

        #region KhachHang

        private void BtnCapNhatKH_Click(object sender, EventArgs e)
        {
            ShowForm<UcCapNhatThongTinKH>((sender as Control).Text);
        }

        private void BtnInGiayBaoTienNuoc_Click(object sender, EventArgs e)
        {
            ShowForm<UcGiayBaoTienNuoc>((sender as Control).Text);
        }

        private void btnQLMoi_Click(object sender, EventArgs e)
        {
            ShowForm<UcKhachHang>((sender as Control).Text);
        }

        private void BtnCapNhatDiaChiKHBangFileExcel_Click(object sender, EventArgs e)
        {
            ShowForm<UcCapNhatDiaChiKH>((sender as Control).Text);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ShowForm<UcDongBoKhachHangForm>((sender as Control).Text);
        }

        #endregion KhachHang

        #region Hoa Don

        private void iconButton9_Click(object sender, EventArgs e)
        {
            ShowForm<UcHoaDon>((sender as Control).Text);
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            ShowForm<UcChitietHD>((sender as Control).Text);
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            ShowForm<UcTaoHoaDon>((sender as Control).Text);
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ShowForm<UcPhatHanhHD>((sender as Control).Text);
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            ShowForm<UcDongBoHDThuHo>((sender as Control).Text);
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            ShowForm<UcTraCuuHoaDon>((sender as Control).Text);
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            ShowForm<UcKyGhi>((sender as Control).Text);
        }

        private void iconButton14_Click(object sender, EventArgs e)
        {
            ShowForm<UcDongBoThanhToanThuHo>((sender as Control).Text);
        }

        #endregion Hoa Don
    }
}