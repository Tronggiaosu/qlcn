using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovStatusStrip : StatusStrip
    {
        protected Color designBackColor;

        public NovStatusStrip()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.BackColor = Color.White;
            this.ForeColor = Color.MediumBlue;
            // Enable double buffering to avoid flickering
            this.DoubleBuffered = true;
            designBackColor = this.BackColor;
        }
    }
}