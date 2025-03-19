using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.DataSource
{
    public partial class GiayBaoTienNuoc : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public int nam, trangthai;
        public string kyghi, maquan, maphuong, search;
        public GiayBaoTienNuoc()
        {
            InitializeComponent();
        }

        private void GiayBaoTienNuoc_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPGiayBaoTienNuoc.rdlc";
            string pngay = DateTime.Today.Day.ToString();
            string pthang = DateTime.Today.Month.ToString();
            string pnam = DateTime.Today.Year.ToString();
            string ngaythang = DateTime.Now.ToString("dd/MM/yyyy");
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("ngaythang", ngaythang));
            this.reportViewer1.LocalReport.SetParameters(param);
            var data = db.getDatagiayBaoTienNuoc(nam, kyghi, trangthai, maquan, maphuong, search.Replace(" ", String.Empty)).ToList();
            getDatagiayBaoTienNuocBindingSource.DataSource = data.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
}
