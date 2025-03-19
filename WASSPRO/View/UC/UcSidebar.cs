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

namespace QLCongNo.View.UC
{
    /// <summary>
    /// Represents a sidebar user control with collapsible functionality.
    /// </summary>
    public partial class UcSidebar : View.Core.NovUserControl
    {
        private const int _expandedWidth = 450;
        private const int _collapsedWidth = 60;
        private const int _menuItemHeight = 33;

        /// <summary>
        /// DB context for the application.
        /// </summary>
        public CAPNUOC_TNCEntities db { get; set; }

        public Panel ContainerPanel { get; set; }
        public Label Title { get; set; }

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
                    object[] constructorArgs = Array.Empty<object>();
                    if (!string.IsNullOrEmpty(itemInfo.AdditionParam))
                    {
                        // JSON string containing the parameters
                        string json = "{\"maloai\":\"TC\",\"trangthai\":6}";

                        // Deserialize the JSON into a dictionary
                        Dictionary<string, object> parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

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

        public void LoadMenu()
        {
            // load menu table from db  where Status = 1 and ParentId is null
            var menuLv1 = db.Menus.Where(x => x.Status == 1 && x.ParentId == null)
                .OrderBy(s => s.Sort).ToList();

            // loop on lv1 menu, then add panel with a button inside it. then load menu lv2 then add a button inside the panel.
            foreach (var itemLv1 in menuLv1)
            {
                var pnl = CreatePnlMenuItem();

                var btn = CreateMenuItem(1, itemLv1);
                pnl.Controls.Add(btn);
                PnlMenu.Controls.Add(pnl);

                var menuLv2 = db.Menus.Where(x => x.Status == 1 && x.ParentId == itemLv1.Id)
                    .OrderBy(s => s.Sort).ToList();

                if (menuLv2.Count > 0)
                    btn.Font = new Font(btn.Font, FontStyle.Bold);
                foreach (var itemLv2 in menuLv2)
                {
                    var btnLv2 = CreateMenuItem(2, itemLv2);
                    pnl.Controls.Add(btnLv2);
                }
            }
            CollapseAll(PnlMenu);
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
}