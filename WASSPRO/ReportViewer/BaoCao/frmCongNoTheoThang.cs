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
    public partial class frmCongNoTheoThang : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public string TuKy, DenKy, DenNgay;
        public frmCongNoTheoThang()
        {
            InitializeComponent();
        }

        private void frmCongNoTheoThang_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPNoNhieuKy.rdlc";
            var data = db.GetCongNoDocHub(TuKy, DenKy, DenNgay);
            this.getCongNoDocHubBindingSource.DataSource = data.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
}
