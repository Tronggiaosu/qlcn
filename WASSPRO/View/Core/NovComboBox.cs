using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLCongNo.View.Core
{
    public partial class NovComboBox : ComboBox
    {
        protected Color designBackColor;

        public NovComboBox()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new Padding(0, 0, 0, 10);
            this.Padding = new Padding(20, 5, 5, 5);
            // Enable double buffering to avoid flickering
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            designBackColor = this.BackColor;
            // Handle the Enter and Leave events
            this.Enter += NovTextBox_Enter;
            this.Leave += NovTextBox_Leave;
        }

        // When got focus, change the background color to Lemon Chiffon and set hasFocus to true
        private void NovTextBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.LemonChiffon;
        }

        // When lost focus, reset the background color and set hasFocus to false
        private void NovTextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = designBackColor;
        }

        // Override ProcessCmdKey to handle Enter and Shift + Enter keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                // Move focus to the next control
                this.Parent.SelectNextControl(this, true, true, true, true);
                return true; // Indicate that the key has been handled
            }
            else if (keyData == (Keys.Enter | Keys.Shift))
            {
                // Move focus to the previous control
                this.Parent.SelectNextControl(this, false, true, true, true);
                return true; // Indicate that the key has been handled
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}