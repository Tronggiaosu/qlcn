using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.GachNo
{
    public partial class frDongBoThanhToanThuHo : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frDongBoThanhToanThuHo()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDB_Click(object sender, EventArgs e)
        {

        }

    }
}
