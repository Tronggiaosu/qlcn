using Microsoft.Reporting.WinForms;
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
    public partial class frQuyetDinhDieuChinh : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public decimal QDID;
        public frQuyetDinhDieuChinh()
        {
            InitializeComponent();
        }

        private void frQuyetDinhDieuChinh_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPPhieuDieuChinhHoaDon.rdlc";
            var timenow = DateTime.Now;
            string ngaythang = "TP. Hồ Chí Minh, ngày " + timenow.ToString("dd") + " tháng " + timenow.ToString("MM") + " năm " + timenow.ToString("yyyy");
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("ngaythang", ngaythang));
            var dataSource = db.getBaoCaoPhieuDieuChinhHoaDon(QDID).ToList();
            this.getBaoCaoPhieuDieuChinhHoaDonBindingSource.DataSource = dataSource.ToList();
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }
    }
}
