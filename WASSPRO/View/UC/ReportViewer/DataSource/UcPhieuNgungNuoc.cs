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
    public partial class UcPhieuNgungNuoc : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        LocalReport lr = new LocalReport();
        public UcPhieuNgungNuoc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            var date = DateTime.Now;
            var ngay = date.ToString("dd");
            var thang = date.ToString("MM");
            var nam = date.ToString("yyyy");
            var data = (from a in db.HOADONs
                        from b in db.KHACHHANGs
                        from c in db.DM_KYGHI
                        from d in db.DM_KICHCODH
                        from f in db.DM_HIEUDONGHO
                        where a.ID_KH == b.ID_KH && a.kyghi==c.ID_kyghi && b.MAKC == d.MaKC && f.mahieu == b.maDH 
                        && a.gachno == false 
                        select new {b.hoten_KH, b.diachi, a.DANHBO, a.MaLT, d.KichCo,
                        a.tongtien, b.maDH , c.ten_kyghi, f.tenhieu}).FirstOrDefault();
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("ngay", ngay ?? "00"));
            param.Add(new ReportParameter("thang", thang ?? "00"));
            param.Add(new ReportParameter("nam", nam ?? "00"));
            param.Add(new ReportParameter("hoten_KH", data.hoten_KH ?? ""));
            param.Add(new ReportParameter("diachi", data.diachi ?? ""));
            param.Add(new ReportParameter("DANHBO", data.DANHBO ?? ""));
            param.Add(new ReportParameter("KichCo", data.KichCo ?? ""));
            param.Add(new ReportParameter("maDH", Convert.ToString(data.maDH)));
            param.Add(new ReportParameter("ten_kyghi", data.ten_kyghi ?? ""));
            param.Add(new ReportParameter("tongtien", Convert.ToString(data.tongtien)));
            param.Add(new ReportParameter("tenhieu", data.tenhieu ?? ""));
            param.Add(new ReportParameter("MaLT", data.MaLT ?? ""));
         
        }

        private void PhieuNgungNuoc_Load(object sender, EventArgs e)
        {
             
        }
    }
}
