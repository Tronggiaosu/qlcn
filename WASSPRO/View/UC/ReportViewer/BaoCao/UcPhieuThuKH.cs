using Microsoft.Reporting.WinForms;
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
    public partial class UcPhieuThuKH : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public decimal pIDCT;
        public decimal IDHD;
        public UcPhieuThuKH()
        {
            InitializeComponent();
        }
        private void frPhieuThuKH_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "ReportViewer\\ReportView\\RPPhieuThuKH.rdlc";
            var chungtu = db.CHUNGTUs.Where(x => x.ID_CT == pIDCT).FirstOrDefault();
            string ngay = chungtu.NGAYLAP.Day.ToString();
            string thang = chungtu.NGAYLAP.Month.ToString();
            string nam = chungtu.NGAYLAP.Year.ToString();
            string thangnam = "Ngày " + ngay + " tháng " + thang + " năm " + nam;
            var data = db.getPhieuThuKH(pIDCT).ToList(); 
            if(IDHD != 0)
            {
                 data  = db.getPhieuThuKH(pIDCT).Where(x=>x.ID_HD == IDHD).ToList(); 
            }
            this.getPhieuThuKHBindingSource.DataSource = data.ToList();
            var nhanvien = db.NHANVIENs.Where(x => x.NV_ID == chungtu.NV_ID_LAP).FirstOrDefault();
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("ngaythang", thangnam));
            param.Add(new ReportParameter("ngaythanhtoan", chungtu.NGAYLAP.ToString("dd/MM/yyyy")));
            param.Add(new ReportParameter("nhanvien", nhanvien.hoten));
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }
    }
}
