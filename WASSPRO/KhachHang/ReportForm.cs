using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace QLCongNo
{
    public partial class ReportForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public decimal IDYC;
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//PhieuNgungNuoc.rdlc";
            var congty = db.CONGTies.FirstOrDefault();
            var yeucau = db.YEUCAUs.Where(X => X.ID_yeucau == IDYC).FirstOrDefault();
            string ngaythang = "";
            string hoten_KH = "";
            string diachi = "";
            string danhbo = "";
            string kichco = "";
            string maDH = "";
            string ten_kyghi = "";
            string tongtien = "";
            string tenhieu = "";
            string malt = "";
            string tenyeucau = "";
            string soseri = "";
            string tencty = "";
            decimal? tongtienno = 0;
            var diachiKH = (from a in db.KHACHHANGs
                         from b in db.DM_PHUONG
                         from c in db.DM_QUAN
                         where a.maphuong == b.maPhuong
                         && a.maquan == c.maQuan
                         && b.maQuan == c.maQuan
                         && a.ID_KH == yeucau.ID_KH
                         select new { diachi = a.sonha + a.diachi + ", " + b.tenPhuong + ", Quận " + c.tenQuan }).FirstOrDefault();
            hoten_KH = yeucau.KHACHHANG.hoten_KH;
            diachi = diachiKH.diachi;
            danhbo = yeucau.KHACHHANG.madanhbo;
            malt = yeucau.KHACHHANG.maLT;
            tenyeucau = yeucau.DM_LOAIYEUCAU.tenloai_yc;
            tencty = congty.tenCTY;
                string ngay = DateTime.Now.Day.ToString();
            string thang = DateTime.Now.Month.ToString();
            string nam_now = DateTime.Now.Year.ToString();
            string cur_ngaythang = "Ngày " + ngay + "/" + thang + "/" + nam_now;
            ngaythang = "TP.Hồ Chí Minh " + cur_ngaythang;
            var hoadon = db.HOADONs.Where(x => x.gachno == false && x.ID_KH == yeucau.ID_KH).ToList();
            foreach (var item in hoadon)
            {
                if (ten_kyghi == "")
                    ten_kyghi = item.kyghi + "/" + item.nam.ToString();
                else
                    ten_kyghi = ten_kyghi + "; " + item.kyghi + "/" + item.nam.ToString();
                tongtienno += item.tongtien;
            }
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("tenyeucau", tenyeucau));
            param.Add(new ReportParameter("ngaythang", ngaythang));
            param.Add(new ReportParameter("hoten_KH", hoten_KH));
            param.Add(new ReportParameter("diachi", diachi));
            param.Add(new ReportParameter("danhbo", danhbo));
            param.Add(new ReportParameter("malt", malt));
            param.Add(new ReportParameter("tencty", tencty));
            param.Add(new ReportParameter("ten_kyghi", ten_kyghi));
            param.Add(new ReportParameter("tongtien", string.Format("{0:n0}", tongtienno)));
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }
    }
}
