using WinFormsReport = Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace QLCongNo.View.UC.ReportViewer.DataSource
{
    public partial class GiayBaoTienNuoc : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public int nam, trangthai;
        public string kyghi, maquan, maphuong, search;

        public GiayBaoTienNuoc()
        {
            InitializeComponent();
        }

        private void GiayBaoTienNuoc_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var root = "ReportViewer\\ReportView\\RPGiayBaoTienNuoc.rdlc";
            string basePath = Directory.GetCurrentDirectory();
            var reportPath = $"{basePath}\\{root}";

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
            string result = (nam + 2000).ToString() + kyghi;

            if(search.Length <= 11)
            {
                var data = db.getDatagiayBaoTienNuoc(nam, result, trangthai, maquan, maphuong, search.Replace(" ", String.Empty)).ToList();
                WinFormsReport.ReportDataSource reportDataSource = new WinFormsReport.ReportDataSource("DataSource", data);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
                param.Add(new WinFormsReport.ReportParameter("ngaythang", ngaythang));

                this.reportViewer1.LocalReport.SetParameters(param);
                this.reportViewer1.RefreshReport();
            }    
            else
            {
                var data = db.getDatagiayBaoTienNuoc(nam, result, trangthai, maquan, maphuong, search).ToList();
                WinFormsReport.ReportDataSource reportDataSource = new WinFormsReport.ReportDataSource("DataSource", data);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
                param.Add(new WinFormsReport.ReportParameter("ngaythang", ngaythang));

                this.reportViewer1.LocalReport.SetParameters(param);
                this.reportViewer1.RefreshReport();
            }    
            this.Cursor = Cursors.Default;
        }
    }
}