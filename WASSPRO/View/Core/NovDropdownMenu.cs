using QLCongNo.View.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.BaseControl
{
    /// <summary>
    /// Custom dropdown menu with configurable properties.
    /// </summary>
    public class NovDropdownMenu : ContextMenuStrip
    {
        private ToolStripMenuItem orderToolStripMenuItem;
        private ToolStripMenuItem invoicesToolStripMenuItem;
        private ToolStripMenuItem createToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem oneToolStripMenuItem;
        private ToolStripMenuItem allToolStripMenuItem;
        private Bitmap _menuItemHeaderSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="NovDropdownMenu"/> class.
        /// </summary>
        /// <param name="container">The container for the components.</param>
        public NovDropdownMenu(IContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this menu is the main menu.
        /// </summary>
        [Browsable(false)]
        public bool IsMainMenu { get; set; }

        /// <summary>
        /// Gets or sets the height of the menu items.
        /// </summary>
        [Browsable(false)]
        public int MenuItemHeight { get; set; } = 25;

        /// <summary>
        /// Gets or sets the text color of the menu items.
        /// </summary>
        [Browsable(false)]
        public Color MenuItemTextColor { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the primary color of the menu.
        /// </summary>
        [Browsable(false)]
        public Color PrimaryColor { get; set; } = Color.Empty;

        /// <summary>
        /// Loads the height of the menu items and sets their properties.
        /// </summary>
        private void LoadMenuItemHeight()
        {
            _menuItemHeaderSize = IsMainMenu ? new Bitmap(25, 45) : new Bitmap(20, MenuItemHeight);

            void SetMenuItemProperties(ToolStripMenuItem menuItem)
            {
                menuItem.ImageScaling = ToolStripItemImageScaling.None;
                if (menuItem.Image == null) menuItem.Image = _menuItemHeaderSize;
            }

            void ProcessMenuItems(ToolStripItemCollection items)
            {
                foreach (ToolStripMenuItem menuItem in items)
                {
                    SetMenuItemProperties(menuItem);
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        ProcessMenuItems(menuItem.DropDownItems);
                    }
                }
            }

            ProcessMenuItems(this.Items);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!this.DesignMode)
            {
                this.Renderer = new MenuRenderer(IsMainMenu, PrimaryColor, MenuItemTextColor);
                LoadMenuItemHeight();
            }
        }

        private void InitializeComponent()
        {
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuspendLayout();
            //
            // orderToolStripMenuItem
            //
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.orderToolStripMenuItem.Text = "order";
            //
            // invoicesToolStripMenuItem
            //
            this.invoicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            this.invoicesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.invoicesToolStripMenuItem.Text = "invoices";
            //
            // createToolStripMenuItem
            //
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createToolStripMenuItem.Text = "Create";
            //
            // editToolStripMenuItem
            //
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.editToolStripMenuItem.Text = "edit";
            //
            // deleteToolStripMenuItem
            //
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneToolStripMenuItem,
            this.allToolStripMenuItem});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            //
            // oneToolStripMenuItem
            //
            this.oneToolStripMenuItem.Name = "oneToolStripMenuItem";
            this.oneToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.oneToolStripMenuItem.Text = "one";
            //
            // allToolStripMenuItem
            //
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.allToolStripMenuItem.Text = "all";
            this.ResumeLayout(false);
        }
    }
}