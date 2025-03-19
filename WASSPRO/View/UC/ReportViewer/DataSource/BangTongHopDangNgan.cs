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
    public partial class BangTongHopDangNgan : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        LocalReport lr = new LocalReport();
        public BangTongHopDangNgan()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            dttungay.Format = DateTimePickerFormat.Custom;
            dttungay.CustomFormat = "dd/MM/yyyy";
            dttungay.Value = dtdenngay.Value.AddMonths(-1);
            dtdenngay.Format = DateTimePickerFormat.Custom;
            dtdenngay.CustomFormat = "dd/MM/yyyy";
        }

        private void BangTongHopDangNgan_Load(object sender, EventArgs e)
        {
            LoadLoaiHoaDon();
            LoadDoiThuTien();
            LoadKiemSoatVien();
        }
        void btnTim_Click(object sender, EventArgs e)
        {
            List<ReportParameter> param = new List<ReportParameter>();
            string loaihd = cboloaihd.SelectedValue.ToString(); // lay id
            DateTime tungay = dttungay.Value.Date;
            DateTime denngay = dtdenngay.Value.Date;
            // lay text duoc chon         
            var date = DateTime.Now;
            var ngay = date.ToString("dd");
            var thang = date.ToString("MM");
            var nam = date.ToString("yyyy");
            var loaihoadon = cboloaihd.Text;
            var doithutien = cbodoithutien.Text;
            var kiemsoatvien = cboKiemSoatVien.Text;
           
                reportViewer1.LocalReport.ReportPath = "ReportViewer/ReportView/BangTongHopDangNgan.rdlc";
                this.bangTongHopDangNganBindingSource.DataSource = db.BangTongHopDangNgan(loaihd,tungay,denngay);
   
            {
                // add param
                param.Add(new ReportParameter("ngay", ngay ?? "00"));
                param.Add(new ReportParameter("thang", thang ?? "00"));
                param.Add(new ReportParameter("nam", nam ?? "00"));
                param.Add(new ReportParameter("loaihoadon", loaihoadon));
                param.Add(new ReportParameter("doithutien", doithutien));
                param.Add(new ReportParameter("kiemsoatvien", kiemsoatvien));
                this.reportViewer1.LocalReport.SetParameters(param);
                ReportDataSource rd = new ReportDataSource("DataSet1");
                lr.DataSources.Add(rd);
                reportViewer1.RefreshReport();

            }
        }
        private void LoadLoaiHoaDon()
        {
            var cn = (from a in db.DM_LOAIHOADON orderby a.tenloaiHD select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaLoaiHD");
            dt.Columns.Add("TenLoaiHD");
            //dt.Rows.Add(null, "Tất cả");
            foreach (DM_LOAIHOADON c in cn)
            {
                dt.Rows.Add(c.LoaiHD_ID, c.tenloaiHD);
            }
            cboloaihd.DataSource = dt;
            cboloaihd.DisplayMember = "TenLoaiHD";
            cboloaihd.ValueMember = "MaLoaiHD";
        }
        private void LoadDoiThuTien()
        {
            var doithutien = (from a in db.NHANVIENs orderby a.hoten select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("NV_ID");
            dt.Columns.Add("hoten");
            // dt.Rows.Add(null, "Tất cả");
            foreach (NHANVIEN c in doithutien)
            {
                dt.Rows.Add(c.NV_ID, c.hoten);
            }
            cbodoithutien.DataSource = dt;
            cbodoithutien.DisplayMember = "hoten";
            cbodoithutien.ValueMember = "NV_ID";
        }
        private void LoadKiemSoatVien()
        {
            var kiemsoatvien = (from a in db.NHANVIENs orderby a.hoten select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("NV_ID");
            dt.Columns.Add("hoten");
            // dt.Rows.Add(null, "Tất cả");
            foreach (NHANVIEN c in kiemsoatvien)
            {
                dt.Rows.Add(c.NV_ID, c.hoten);
            }
            cboKiemSoatVien.DataSource = dt;
            cboKiemSoatVien.DisplayMember = "hoten";
            cboKiemSoatVien.ValueMember = "NV_ID";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //this.Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
