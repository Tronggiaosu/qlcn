using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcCongNoTheoThang : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public string TuKy, DenKy, DenNgay;
        public UcCongNoTheoThang()
        {
            InitializeComponent();
        }

        private void frmCongNoTheoThang_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPNoNhieuKy.rdlc";
            if (!System.IO.File.Exists(this.reportViewer1.LocalReport.ReportPath))
            {
                MessageBox.Show("File report không tồn tại: " + this.reportViewer1.LocalReport.ReportPath);
                return;
            }
            var data = db.GetCongNoDocHub(TuKy, DenKy, DenNgay);
            this.getCongNoDocHubBindingSource.DataSource = data.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
}
