using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.DangNgan
{
    public partial class frTongHopDangNgan : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public string tungay, denngay;
        public decimal? NVID, NVLap;
        public int loaiHD;
        public string maloai;
        public string maDT;
        public int TOID;
        public frTongHopDangNgan()
        {
            InitializeComponent();
        }

        private void frTongHopDangNgan_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPDangNgan.rdlc";
            bool isdangngan = true;
            var dataSource = db.getDangNganTheoNgay(NVID, loaiHD, tungay, denngay, maloai, maDT, true, NVLap, TOID).ToList();
            this.getDangNganTheoNgayBindingSource.DataSource = dataSource.ToList();
            string tenbaocao = "";
            if (maloai == "KH")
                tenbaocao = "ĐĂNG NGÂN CỦA THU NGÂN TẠI QUẦY";
            if (maloai == "CK")
                tenbaocao = "ĐĂNG NGÂN CỦA THU NGÂN CHUYỂN KHOẢN";
            if (maloai == "TT")
                tenbaocao = "ĐĂNG NGÂN CỦA NHÂN VIÊN THU";
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("tenbaocao", tenbaocao));
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }
    }
}

