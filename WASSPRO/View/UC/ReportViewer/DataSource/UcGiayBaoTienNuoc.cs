using Microsoft.Reporting.WinForms;
using WinFormsReport = Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.DataSource
{
    public partial class UcGiayBaoTienNuoc : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public int nam, trangthai;
        public string kyghi, maquan, maphuong, search;

        public UcGiayBaoTienNuoc()
        {
            InitializeComponent();
        }

        private void GiayBaoTienNuoc_Load(object sender, EventArgs e)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectRootPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            string reportPath = Path.Combine(projectRootPath, "WASSPRO", "ReportViewer", "ReportView", "RPGiayBaoTienNuoc.rdlc");

            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("File report không tồn tại: " + reportPath);
                return;
            }
            this.reportViewer1.LocalReport.ReportPath = reportPath;
            string pngay = DateTime.Today.Day.ToString();
            string pthang = DateTime.Today.Month.ToString();
            string pnam = DateTime.Today.Year.ToString();
            string ngaythang = DateTime.Now.ToString("dd/MM/yyyy");
            List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
            param.Add(new WinFormsReport.ReportParameter("ngaythang", ngaythang));
            this.reportViewer1.LocalReport.SetParameters(param);
            var data = db.getDatagiayBaoTienNuoc(nam, kyghi, trangthai, maquan, maphuong, search.Replace(" ", String.Empty)).ToList();
            getDatagiayBaoTienNuocBindingSource.DataSource = data.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
}