using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public class PanelWoScrollbar : TableLayoutPanel
    {
        private int _scrollSpeedFactor = 3; // Default scroll speed factor

        // Property for ScrollSpeedFactor
        [Category("Behavior")]
        [Description("Controls the speed of the scrolling (higher value = slower scrolling).")]
        public int ScrollSpeedFactor
        {
            get { return _scrollSpeedFactor; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("ScrollSpeedFactor", "ScrollSpeedFactor must be greater than 0.");
                _scrollSpeedFactor = value;
            }
        }

        public PanelWoScrollbar()
        {
            // Hide the scrollbars but still allow for scrolling
            AutoScroll = true;       // Enable double buffering to prevent flicker
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083; // Message to calculate client area size (for scrollbars)
            const int WM_NCPAINT = 0x0085;    // Message to repaint non-client area (scrollbars)

            // Ignore the messages that would draw scrollbars
            if (m.Msg == WM_NCCALCSIZE || m.Msg == WM_NCPAINT)
            {
                return;
            }
            base.WndProc(ref m);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            SuspendLayout();
            int scrollChange = e.Delta * -1 / _scrollSpeedFactor; // Delta is positive for scrolling up, negative for down

            // Current scroll position
            int currentY = -this.AutoScrollPosition.Y; // The value is negative, hence we negate it

            // Calculate the new scroll position, but ensure it is within the bounds of the content
            int newY = currentY + scrollChange;

            // Ensure newY is within the scrollable range
            int maxScrollY = this.DisplayRectangle.Height - this.ClientSize.Height; // Total content height minus visible area
            if (newY > maxScrollY)
                newY = maxScrollY; // Cap it at the bottom
            if (newY < 0)
                newY = 0; // Cap it at the top

            // Set the new scroll position
            this.AutoScrollPosition = new System.Drawing.Point(0, newY);

            ResumeLayout();
            base.OnMouseWheel(e);
        }
    }
}