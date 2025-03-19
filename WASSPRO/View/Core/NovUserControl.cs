using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovUserControl : UserControl
    {
        protected Color designBackColor;
        public Form Owner { get; set; }
        public Panel PnlParrent { get; set; }

        public NovUserControl()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.BackColor = Color.White;
            this.ForeColor = Color.MediumBlue;
            // Enable double buffering to avoid flickering
            this.DoubleBuffered = true;
            designBackColor = this.BackColor;
        }
    }
}