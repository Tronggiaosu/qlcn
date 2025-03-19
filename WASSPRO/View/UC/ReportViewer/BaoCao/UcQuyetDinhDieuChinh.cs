using Microsoft.Reporting.WinForms;
using WinFormsReport = Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QLCongNo.View.UC.HoaDon;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcQuyetDinhDieuChinh : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public decimal QDID;
        public UcQuyetDinhDieuChinh()
        {
            InitializeComponent();
        }

        private void frQuyetDinhDieuChinh_Load(object sender, EventArgs e)
        {
            var root = "ReportViewer\\ReportView\\RPPhieuDieuChinhHoaDon.rdlc";
            string basePath = Directory.GetCurrentDirectory();
            var reportPath = $"{basePath}\\{root}";

            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("File report không tồn tại: " + reportPath);
                return;
            }
            this.reportViewer1.LocalReport.ReportPath = reportPath;

            var timenow = DateTime.Now;
            string ngaythang = "TP. Hồ Chí Minh, ngày " + timenow.ToString("dd") + " tháng " + timenow.ToString("MM") + " năm " + timenow.ToString("yyyy");
            List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
            param.Add(new WinFormsReport.ReportParameter("ngaythang", ngaythang));
            var dataSource = db.getBaoCaoPhieuDieuChinhHoaDon(QDID).ToList();
            this.getBaoCaoPhieuDieuChinhHoaDonBindingSource.DataSource = dataSource.ToList();
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }
    }
}
