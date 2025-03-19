using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovToolStripStatusLabel : ToolStripStatusLabel
    {
        protected Color designBackColor;

        public NovToolStripStatusLabel()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.BackColor = Color.White;
            this.ForeColor = Color.MediumBlue;
            // Enable double buffering to avoid flickering
            designBackColor = this.BackColor;
        }
    }
}