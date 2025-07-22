using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.BaoCao
{
    public partial class frmBaocaoHDtontheongay : Form
    {
        
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frmBaocaoHDtontheongay()
        {
            InitializeComponent();
        }

       
        public void HienthiDL()
        {
<<<<<<< .mine
            var tngay = Convert.ToDateTime(tungay);
            var dngay = Convert.ToDateTime(denngay);
            var select = (from a in db.HOADONs
                          join b in db.DM_KYGHI
                          on a.kyghi equals b.ID_kyghi
                          where (a.ngaythanhtoan >= tngay && a.ngaythanhtoan <= dngay)
                                && a.tongtien != 0
                                && a.IsInHD == true
                          select new
                          {
                              kyhoadon = b.ID_kyghi + "/" + b.nam,
                              seri = a.KY_HIEU_HD + "" + a.SO_HD,
                              a.SO_HD,
                              a.SOPHATHANH,
                              a.hoten,
                              a.diachi,
                              a.tongtien

                          }).ToList();
||||||| .r374
            var tngay = Convert.ToDateTime(tungay);
            var dngay = Convert.ToDateTime(denngay);
            var select = (from a in db.HOADON
                          join b in db.DM_KYGHI
                          on a.kyghi equals b.ID_kyghi
                          where (a.ngaythanhtoan >= tngay && a.ngaythanhtoan <= dngay)
                                && a.tongtien != 0
                                && a.IsInHD == true
                          select new
                          {
                              kyhoadon = b.ID_kyghi + "/" + b.nam,
                              seri = a.KY_HIEU_HD + "" + a.SO_HD,
                              a.SO_HD,
                              a.SOPHATHANH,
                              a.hoten,
                              a.diachi,
                              a.tongtien

                          }).ToList();
=======
            var tngay = dtpTungay.Value.ToString("yyyy-MM-dd");
            var dngay = dtpDenngay.Value.ToString("yyyy-MM-dd");
            var select = db.getBaocaoHoadontontheongay(tngay, dngay).ToList();
>>>>>>> .r380
            dgvHDtheongay.DataSource = select.ToList();
            
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            var sl = from a in db.HOADONs
                     join b in db.DM_KYGHI
                     on a.kyghi equals b.ID_kyghi

                     select new
                     {
                         kyhoadon = b.ID_kyghi + "/" + b.nam,
                         seri = a.KY_HIEU_HD + "" + a.SO_HD,
                         a.SO_HD,
                         a.SOPHATHANH,
                         a.hoten,
                         a.diachi,
                         a.tongtien

                     };

            string input = txtSearch.Text;

            sl = sl.Where(x => x.SO_HD.ToString() == input || x.diachi.Contains(input) || x.SOPHATHANH == input || x.hoten.Contains(input));

            dgvHDtheongay.DataSource = sl.OrderBy(x => x.SO_HD).ThenBy(x => x.SO_HD).ToList();
           
        }
        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            frmChitiethoadonton frm = new frmChitiethoadonton();
            frm.MdiParent = this.MdiParent;
            frm.Dock = DockStyle.Fill;
            frm.id_hd = dgvHDtheongay[2, dgvHDtheongay.CurrentRow.Index].Value.ToString();
            frm.Show();
        }

        private void btnXembaocao_Click(object sender, EventArgs e)
        {
            HienthiDL();
        }
    }
}
