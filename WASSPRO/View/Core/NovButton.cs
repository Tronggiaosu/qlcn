using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovButton : IconButton
    {
        protected Color designBackColor;

        public NovButton()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // Enable double buffering to avoid flickering

            this.BackColor = Color.RoyalBlue;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(81, 119, 235);
            this.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.White;
            this.IconColor = Color.White;
            this.IconFont = IconFont.Solid;
            this.IconSize = 1;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.Margin = new Padding(8, 0, 0, 0);
            this.Padding = new Padding(10, 0, 0, 0);
            this.Size = new Size(120, 28);
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.UseVisualStyleBackColor = false;

            designBackColor = this.BackColor;
        }
    }
}