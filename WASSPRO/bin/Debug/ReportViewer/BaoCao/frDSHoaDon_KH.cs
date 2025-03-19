using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.BaoCao
{
    
    public partial class frDSHoaDon_KH : Form
    {
        CAPNUOC_TNCEntities db=new CAPNUOC_TNCEntities();
        public decimal idkh;
        public frDSHoaDon_KH()
        {
            InitializeComponent();
        }
        private void frDSHoaDon_KH_Load(object sender, EventArgs e)
        {
            dgvHoadon.AutoGenerateColumns = false;
            var dsHoadon = db.getDSHoaDon_KH(idkh).OrderByDescending(x=>x.kyghi).ToList();
            dgvHoadon.DataSource = dsHoadon.ToList();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
