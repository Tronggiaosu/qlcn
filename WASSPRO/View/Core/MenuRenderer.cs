using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    /// <summary>
    /// Custom renderer for menu items to apply custom colors and styles.
    /// </summary>
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        // Fields
        private readonly Color _primaryColor;

        private readonly Color _textColor;
        private readonly int _arrowThickness;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuRenderer"/> class.
        /// </summary>
        /// <param name="isMainMenu">Indicates whether the menu is the main menu.</param>
        /// <param name="primaryColor">The primary color for the menu items.</param>
        /// <param name="textColor">The text color for the menu items.</param>
        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor)
            : base(new MenuColorTable(isMainMenu, primaryColor))
        {
            this._primaryColor = primaryColor;
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
        }

        /// <summary>
        /// Renders the arrow of a <see cref="ToolStripItem"/>.
        /// </summary>
        /// <param name="e">A <see cref="ToolStripArrowRenderEventArgs"/> that contains the event data.</param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            // Fields
            var graph = e.Graphics;
            var arrowSize = new Size(5, 12);
            var arrowColor = e.Item.Selected ? Color.White : _primaryColor;
            var rect = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - arrowSize.Height) / 2,
                arrowSize.Width, arrowSize.Height);
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(arrowColor, _arrowThickness))
            {
                // Drawing
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + rect.Height / 2);
                path.AddLine(rect.Right, rect.Top + rect.Height / 2, rect.Left, rect.Top + rect.Height);
                graph.DrawPath(pen, path);
            }
        }
    }
}