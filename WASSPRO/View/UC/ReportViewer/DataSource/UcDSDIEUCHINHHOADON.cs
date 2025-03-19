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
    public partial class UcDSDIEUCHINHHOADON : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public string tungay, denngay, text;
        public int trangthai;

        public UcDSDIEUCHINHHOADON()
        {
            InitializeComponent();
        }

        private void DSDIEUCHINHHOADON_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPDanhSachHoaDonDieuChinh.rdlc";
            this.getDanhSachQuyetDinhDieuChinhBindingSource.DataSource = db.getDanhSachQuyetDinhDieuChinhEX(trangthai, tungay, denngay, text).ToList();
            this.reportViewer1.RefreshReport();
        }
    }
}