using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    /// <summary>
    /// Custom renderer for menu items to apply custom colors and styles.
    /// </summary>
    public class ToolStripRenderer : ToolStripProfessionalRenderer
    {
        // Fields
        private readonly Color _primaryColor;

        private readonly Color _hoverColor;
        private readonly Color _textColor;
        private readonly int _arrowThickness;
        private readonly int _borderThickness;
        private readonly Color _borderColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripRenderer"/> class.
        /// </summary>
        /// <param name="isMainMenu">Indicates whether the menu is the main menu.</param>
        /// <param name="primaryColor">The primary color for the menu items.</param>
        /// <param name="textColor">The text color for the menu items.</param>
        /// <param name="borderColor">The border color for the menu items.</param>
        /// <param name="borderThickness">The border thickness for the menu items.</param>
        public ToolStripRenderer(bool isMainMenu, Color primaryColor, Color textColor, Color borderColor, int borderThickness)
            : base(new ToolStripColorTable(isMainMenu, primaryColor))
        {
            _primaryColor = primaryColor;
            _hoverColor = Color.FromArgb(230, _primaryColor);

            _borderColor = borderColor;
            _borderThickness = borderThickness;
            if (isMainMenu)
            {
                _arrowThickness = 3;
                this._textColor = textColor == Color.Empty ? Color.Gainsboro : textColor;
            }
            else
            {
                _arrowThickness = 2;
                this._textColor = textColor == Color.Empty ? Color.DimGray : textColor;
            }
        }

        /// <summary>
        /// Renders the text of a <see cref="ToolStripItem"/>.
        /// </summary>
        /// <param name="e">A <see cref="ToolStripItemTextRenderEventArgs"/> that contains the event data.</param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? Color.White : _textColor;
            e.Item.BackColor = e.Item.Selected ? Color.White : _primaryColor;
        }

        /// <summary>
        /// Renders the background of a <see cref="ToolStripButton"/>.
        /// </summary>
        /// <param name="e">A <see cref="ToolStripItemRenderEventArgs"/> that contains the event data.</param>
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderButtonBackground(e);
            if (e.Item.Selected)
            {
                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                // Draw rectangle with hover color
                using (Brush brush = new SolidBrush(_hoverColor))
                {
                    e.Graphics.FillRectangle(brush, rectangle);
                }
                // Draw border
                using (Pen pen = new Pen(_borderColor))
                {
                    e.Graphics.DrawRectangle(pen, rectangle);
                }
            }
        }
    }
}