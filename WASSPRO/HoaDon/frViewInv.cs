using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.HoaDon
{
    public partial class frViewInv : Form
    {
        public string html = "";
        public frViewInv()
        {
            InitializeComponent();
        }

        private void frViewInv_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = html;
        }
    }
}
