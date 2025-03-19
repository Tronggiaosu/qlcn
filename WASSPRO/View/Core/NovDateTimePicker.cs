using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovDateTimePicker : DateTimePicker
    {
        protected Color designBackColor;

        public NovDateTimePicker()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            // Enable double buffering to avoid flickering
            this.DoubleBuffered = true;
            designBackColor = this.BackColor;
        }
    }
}