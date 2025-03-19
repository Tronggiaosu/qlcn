using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovPanel : Panel
    {
        protected Color designBackColor;

        public NovPanel()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.MediumBlue;
            // Enable double buffering to avoid flickering
            this.DoubleBuffered = true;
            designBackColor = this.BackColor;
        }
    }
}