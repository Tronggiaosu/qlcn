using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    /// <summary>
    /// Provides custom color table for menu rendering.
    /// </summary>
    public class ToolStripColorTable : ProfessionalColorTable
    {
        // Fields
        private readonly Color _backColor;

        private readonly Color _leftColumnColor;
        private readonly Color _borderColor;
        private readonly Color _menuItemBorderColor;
        private readonly Color _menuItemSelectedColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripColorTable"/> class.
        /// </summary>
        /// <param name="isMainMenu">Indicates whether the menu is the main menu.</param>
        /// <param name="primaryColor">The primary color for the menu items.</param>
        public ToolStripColorTable(bool isMainMenu, Color primaryColor)
        {
            if (isMainMenu)
            {
                _backColor = Color.FromArgb(37, 39, 60);
                _leftColumnColor = Color.FromArgb(32, 33, 51);
                _borderColor = Color.FromArgb(32, 33, 51);
                _borderColor = Color.Transparent;
                _menuItemBorderColor = primaryColor;
                _menuItemSelectedColor = primaryColor;
            }
            else
            {
                _backColor = Color.White;
                _leftColumnColor = Color.LightGray;
                _borderColor = Color.LightGray;
                _borderColor = Color.Transparent;
                _menuItemBorderColor = primaryColor;
                _menuItemSelectedColor = primaryColor;
            }
        }

        /// <summary>
        /// Gets the background color of the ToolStripDropDown.
        /// </summary>
        public override Color ToolStripDropDownBackground
        {
            get { return _backColor; }
        }

        /// <summary>
        /// Gets the border color of the menu.
        /// </summary>
        public override Color MenuBorder
        {
            get { return _borderColor; }
        }

        /// <summary>
        /// Gets the border color of the menu item.
        /// </summary>
        public override Color MenuItemBorder
        {
            get { return _menuItemBorderColor; }
        }

        /// <summary>
        /// Gets the color of the selected menu item.
        /// </summary>
        public override Color MenuItemSelected
        {
            get { return _menuItemSelectedColor; }
        }

        /// <summary>
        /// Gets the starting color of the gradient used in the image margin.
        /// </summary>
        public override Color ImageMarginGradientBegin
        {
            get { return _leftColumnColor; }
        }

        /// <summary>
        /// Gets the middle color of the gradient used in the image margin.
        /// </summary>
        public override Color ImageMarginGradientMiddle
        {
            get { return _leftColumnColor; }
        }

        /// <summary>
        /// Gets the ending color of the gradient used in the image margin.
        /// </summary>
        public override Color ImageMarginGradientEnd
        {
            get { return _leftColumnColor; }
        }
    }
}