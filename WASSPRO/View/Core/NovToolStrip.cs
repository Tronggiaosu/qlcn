using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovToolStrip : ToolStrip
    {
        protected Color designBackColor;

        public NovToolStrip()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.MediumBlue;
            // Enable double buffering to avoid flickering
            this.DoubleBuffered = true;
            designBackColor = this.BackColor;

            this.GripStyle = ToolStripGripStyle.Hidden;
            this.IsMainMenu = true;
            this.MenuItemHeight = 26;
            this.PrimaryColor = Color.FromArgb(65, 105, 225);
            this.MenuItemTextColor = Color.White;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this menu is the main menu.
        /// </summary>
        public bool IsMainMenu { get; set; }

        /// <summary>
        /// Gets or sets the height of the menu items.
        /// </summary>
        public int MenuItemHeight { get; set; } = 25;

        /// <summary>
        /// Gets or sets the text color of the menu items.
        /// </summary>
        public Color MenuItemTextColor { get; set; }

        /// <summary>
        /// Gets or sets the primary color of the menu.
        /// </summary>
        public Color PrimaryColor { get; set; }

        /// <summary>
        /// Gets or sets the border color of the menu.
        /// </summary>
        public Color BorderColor { get; set; }

        /// <summary>
        /// Gets or sets the border thickness of the menu.
        /// </summary>
        public int BorderThickness { get; set; } = 0;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!this.DesignMode)
            {
                this.Renderer = new ToolStripRenderer(IsMainMenu, PrimaryColor, MenuItemTextColor, BorderColor, BorderThickness);
            }
        }
    }
}