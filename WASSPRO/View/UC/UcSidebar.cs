using FontAwesome.Sharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLCongNo.View.Core;
using QLCongNo.View.UC.DangNgan;
using QLCongNo.View.UC.GachNo;
using System.Data.Entity;

namespace QLCongNo.View.UC
{
    /// <summary>
    /// Represents a sidebar user control with collapsible functionality.
    /// </summary>
    public partial class UcSidebar : View.Core.NovUserControl
    {
        private int _expandedWidth = 350;
        private const int _collapsedWidth = 60;
        private const int _menuItemHeight = 33;
        private bool _isResized = false;
        private int _resizedWidth = 0;
        private List<Menu> dsMenu = new List<Menu>();

        /// <summary>
        /// DB context for the application.
        /// </summary>
        public CAPNUOC_TNCEntities db { get; set; }

        public Panel ContainerPanel { get; set; }
        public Label Title { get; set; }
        public List<MenuInfo> TotalMenu { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UcSidebar"/> class.
        /// </summary>
        public UcSidebar()
        {
            InitializeComponent();
            PnlMenu.AutoScroll = true;

            db = new CAPNUOC_TNCEntities();
        }

        private void UcSidebar_Load(object sender, EventArgs e)
        {
            DDMHeThong.IsMainMenu = true;
            CollapseAll(PnlMenu);
            FixWidth(PnlMenu);
            PnlMenu.AutoScroll = true;
            PnlMenu.VerticalScroll.Visible = false;
            PnlMenu.HorizontalScroll.Visible = false;
            TotalMenu = new List<MenuInfo>();
            this.Resize += UcSidebar_Resize;
        }

        private void UcSidebar_Resize(object sender, EventArgs e)
        {
            var item = sender as UserControl;
            var width = item.Width;
            if (width != _expandedWidth && width != _collapsedWidth && width != 280)
                _expandedWidth = width;
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
                            //icon only
                            btnItem.Text = string.Empty;
                            btnItem.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                        else
                        {
                            // icon & text
                            btnItem.Text = (btnItem.Tag as Menu)?.Text;
                            btnItem.ImageAlign = ContentAlignment.MiddleLeft;
                        }

                        btnItem.Width = dWidth;
                    }
                }
            }
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
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
            panel.Height = _menuItemHeight;
        }

        private void Expand(Panel panel)
        {
            // set the panel's height to the height of its  visible controls.
            panel.Height = panel.Controls.OfType<Control>().Where(c => c.Visible).Sum(c => c.Height);
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender is Button menuItem)
            {
                // Collapse or expand the panel
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

                // Start UC
                if (menuItem.Tag is Menu itemInfo && !string.IsNullOrWhiteSpace(itemInfo.Action))
                {
                    string namespaceName = typeof(UcSidebar).Namespace;
                    string controlName = $"{namespaceName}.{itemInfo.Action}";
                    //MessageBox.Show(controlName);
                    object[] constructorArgs = Array.Empty<object>();
                    if(controlName == "QLCongNo.View.UC.GachNo.UcGachNoKH")
                    {
                        if (!string.IsNullOrEmpty(itemInfo.AdditionParam))
                        {
                            // JSON string containing the parameters
                            //string json = "{\"maloai\":\"TC\",\"trangthai\":6}";

                            // Deserialize the JSON into a dictionary
                            //Dictionary<string, object> parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                            Dictionary<string, object> parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(itemInfo.AdditionParam);

                            // Convert the values of the dictionary into an object array for CreateInstance
                            object[] constructorArgs2 = new object[parameters.Values.Count];
                            parameters.Values.CopyTo(constructorArgs2, 0);

                            // Get the type of the class
                            Type type = typeof(UcGachNoKH);

                            // Create an instance of the class, passing the parameters as an array
                            object instance = Activator.CreateInstance(type, constructorArgs2);
                        }
                        ShowForm(controlName, menuItem.Text, constructorArgs);
                    }    
                    else
                    {
                        if (!string.IsNullOrEmpty(itemInfo.AdditionParam))
                        {
                            Dictionary<string, object> parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(itemInfo.AdditionParam);

                            object[] constructorArgs2 = new object[parameters.Values.Count];
                            parameters.Values.CopyTo(constructorArgs2, 0);

                            Type type = typeof(UcDangNganChuyenKhoan);

                            object instance = Activator.CreateInstance(type, constructorArgs2);
                        }
                        ShowForm(controlName, menuItem.Text, constructorArgs);
                    }    
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

        private void ShowForm(string controlName, string title, params object[] args)
        {
            var controlType = Type.GetType(controlName) ?? throw new ArgumentException($"Control type '{controlName}' not found.");
            var uc = (NovUserControl)Activator.CreateInstance(controlType, args);
            //var uc = (NovUserControl)Activator.CreateInstance(controlType, new object[] { "Type1", 1 });
            ShowForm(uc, title);
        }

        private void ShowForm<T>(string title, params object[] args) where T : NovUserControl
        {
            //call ShowForm and pass controlName from T
            ShowForm(typeof(T).FullName, title, args);
        }

        private void ShowForm(NovUserControl uc, string title)
        {
            SuspendLayout();
            uc.Owner = this.Owner;
            uc.PnlParrent = ContainerPanel;
            ContainerPanel.Controls.Clear();
            ContainerPanel.Controls.Add(uc);
            Title.Text = title;
            uc.Dock = DockStyle.Fill;
            //todo debug
            //CollapseSideBar(true);
            //CollapseMenu();
            ResumeLayout();
        }

        public bool UserRight()
        {
            try
            {
                IQueryable<string> menuList = null;

                var menuLv1 = db.Menus.Where(x => x.Status == 1 && x.ParentId == null)
                    .OrderBy(s => s.Sort).ToList();

                if (Common.username != "vnptcto")
                {
                    var quyen = from a in db.NGUOIDUNGs
                                from b in db.NGUOIDUNG_QUYEN
                                where a.ma_nd == Common.username
                                where a.nguoidung_id == b.nguoidung_id
                                select b.quyen_id;
                    var count = quyen.Count();
                    if (count == 0)
                    {
                        menuLv1 = db.Menus.Where(x => x.Status == 1 && x.ParentId == null)
                            .OrderBy(s => s.Sort).ToList();

                        this.dsMenu = menuLv1;
                        return true;
                    }

                    foreach (decimal nd_q in quyen.ToList())
                    {
                        menuList = from m in db.QUYEN_MENU where m.quyen_id == nd_q select m.ten_menu;
                    }

                    if (menuList.Count() == 0)
                    {
                        this.dsMenu = menuLv1;
                        return true;
                    }
                }

                var menuById = db.Menus.Where(x => x.Status == 1).ToDictionary(m => m.Id);
                var menuByText = db.Menus.Where(x => x.Status == 1).ToDictionary(m => m.Text);
                var resultMenuTree = new List<Menu>();
                var resultById = new Dictionary<int, Menu>();

                var excludedMenus = menuByText
                .Where(kv => !menuList.Contains(kv.Key))
                .Select(kv => kv.Value)
                .ToList();

                foreach (var menu in excludedMenus)
                {
                    if (menu.ParentId == null)
                    {
                        if (!resultById.ContainsKey(menu.Id))
                        {
                            resultMenuTree.Add(menu);
                            resultById[menu.Id] = menu;
                        }
                    }
                    else
                    {
                        if (menuById.TryGetValue(menu.ParentId.Value, out var parent))
                        {
                            if (!resultById.ContainsKey(parent.Id))
                            {
                                parent.Children = new List<Menu>();
                                resultMenuTree.Add(parent);
                                resultById[parent.Id] = parent;
                            }

                            if (parent.Children == null)
                                parent.Children = new List<Menu>();

                            if (!parent.Children.Any(x => x.Id == menu.Id))
                                parent.Children.Add(menu);
                        }
                    }
                }

                foreach (var m in resultMenuTree)
                {
                    m.Children = m.Children?.OrderBy(x => x.Sort).ToList();
                }

                resultMenuTree = resultMenuTree.OrderBy(x => x.Sort).ToList();
                this.dsMenu = resultMenuTree;
                return false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return true;
            }
        }

        public void LoadMenu()
        {
            try
            {
                var isAuthenticationOrNot = UserRight();
                var menuLv2 = new List<Menu>();

                foreach (var itemLv1 in this.dsMenu)
                {
                    var pnl = CreatePnlMenuItem();
                    var btn = CreateMenuItem(1, itemLv1);
                    pnl.Controls.Add(btn);
                    PnlMenu.Controls.Add(pnl);
                    TotalMenu.Add(new MenuInfo { Text = itemLv1.Text, Level = 1, ParentId = null, Item = itemLv1 });

                    if (!isAuthenticationOrNot)
                    {
                        menuLv2 = itemLv1.Children?.Where(x => x.Status == 1 && x.ParentId == itemLv1.Id)
                        .OrderBy(s => s.Sort).ToList();
                    }
                    else
                    {
                        menuLv2 = db.Menus.Where(x => x.Status == 1 && x.ParentId == itemLv1.Id)
                            .OrderBy(s => s.Sort).ToList();
                    }

                    if (menuLv2?.Count > 0)
                    {
                        btn.Font = new Font(btn.Font, FontStyle.Bold);
                        foreach (var itemLv2 in menuLv2)
                        {
                            var btnLv2 = CreateMenuItem(2, itemLv2);
                            pnl.Controls.Add(btnLv2);
                            TotalMenu.Add(new MenuInfo { Text = itemLv2.Text, Level = 2, ParentId = itemLv1.Id, Item = itemLv2 });
                        }
                    }
                }
                CollapseAll(PnlMenu);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public TableLayoutPanel CreatePnlMenuItem()

        {
            var pnl = new TableLayoutPanel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Padding = new Padding(0),
                Margin = new Padding(0),
            };

            pnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnl.RowStyles.Add(new RowStyle());
            pnl.RowCount = 1;
            return pnl;
        }

        public NovButton CreateMenuItem(int level, Menu menuItem)
        {
            var paddingL = 0;
            if (level == 2) paddingL = 10;
            var btn = new NovButton
            {
                Dock = DockStyle.Top,
                Padding = new Padding(((level - 1) * 10)+ paddingL, 0, 0, 0),
                Margin = new Padding(0),
                BackColor = Color.Transparent,
                Size = new Size(_expandedWidth, _menuItemHeight),
                Font = new Font(Font, FontStyle.Regular)
            };
            SetButtonIcon(menuItem, btn);
            btn.Tag = menuItem;
            btn.Name = "btn" + menuItem.Name;
            btn.Text = menuItem.Text;
            btn.Click += MenuItem_Click;
            return btn;
        }

        private static void SetButtonIcon(Menu menuItem, NovButton btn)
        {
            // Assign IconChar from text
            if (Enum.TryParse<IconChar>(menuItem.Icon, out var iconChar))
            {
                btn.IconChar = iconChar;
                btn.IconSize = 19;
            }
        }
    }

    public class MenuInfo
    {
        public string Text { get; set; }
        public int Level { get; set; }
        public int? ParentId { get; set; }
        public Menu Item { get; set; }
    }
}