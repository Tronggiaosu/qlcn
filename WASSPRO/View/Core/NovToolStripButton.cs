using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovToolStripButton : ToolStripButton
    {
        protected Color designBackColor;

        public NovToolStripButton()
        {
            InitializeComponent();
            // set font size = 11
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new Padding(4, 0, 2, 0);
            this.Padding = new Padding(4);

            designBackColor = this.BackColor;
        }
    }
}