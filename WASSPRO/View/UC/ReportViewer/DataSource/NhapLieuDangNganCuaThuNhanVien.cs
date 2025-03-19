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
    public partial class NhapLieuDangNganCuaThuNhanVien : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        LocalReport lr = new LocalReport();
        public NhapLieuDangNganCuaThuNhanVien()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            dtNgayTra.Format = DateTimePickerFormat.Custom;
            dtNgayTra.CustomFormat = "dd/MM/yyyy";
        }

        private void NhapLieuDangNganCuaThuNhanVien_Load(object sender, EventArgs e)
        {
            LoadThuNhanVien();
            LoadDoiTuong();
            LoadLoaiHD();
            LoadHinhThucTT();
        }
        void btnTim_Click(object sender, EventArgs e)
        {
            List<ReportParameter> param = new List<ReportParameter>();
            decimal nhanvien = Convert.ToDecimal(cboThuNhanVien.SelectedValue.ToString()); // lay id
            DateTime ngaytra = dtNgayTra.Value.Date;
            string doituong = cboDoiTuong.SelectedValue.ToString();
            int hinhthuctt = Convert.ToInt32(cboHinhThucTT.SelectedValue.ToString());
            string LoaiHD = cboLoaiHD.SelectedValue.ToString();
            // lay text duoc chon         
            reportViewer1.LocalReport.ReportPath = "ReportViewer/ReportView/NhapLieuDangNganCuaThuNhanVien.rdlc";
            var dataSource = db.NhapLieuDangNganCuaNhanVien(nhanvien, ngaytra.Date, doituong, hinhthuctt, LoaiHD);
            this.nhapLieuDangNganCuaNhanVienBindingSource.DataSource = dataSource;
            // add param
            this.reportViewer1.LocalReport.SetParameters(param);
            //ReportDataSource rd = new ReportDataSource("DataSet1");
            //lr.DataSources.Add(rd);
            reportViewer1.RefreshReport();
        }
        private void LoadThuNhanVien()
        {
            var cn = (from a in db.NHANVIENs orderby a.hoten select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("NV_ID");
            dt.Columns.Add("hoten");
            dt.Rows.Add("", "Tất cả");
            foreach (NHANVIEN c in cn)
            {
                dt.Rows.Add(c.NV_ID, c.hoten);
            }
            cboThuNhanVien.DataSource = dt;
            cboThuNhanVien.DisplayMember = "hoten";
            cboThuNhanVien.ValueMember = "NV_ID";
        }
        private void LoadDoiTuong()
        {
            var cn = (from a in db.DM_DOITUONGSUDUNG orderby a.tenDT select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("maDT");
            dt.Columns.Add("tenDT");
            dt.Rows.Add(null, "Tất cả");
            foreach (DM_DOITUONGSUDUNG c in cn)
            {
                dt.Rows.Add(c.maDT, c.tenDT);
            }
            cboDoiTuong.DataSource = dt;
            cboDoiTuong.DisplayMember = "tenDT";
            cboDoiTuong.ValueMember = "maDT";
        }
        private void LoadLoaiHD()
        {
            var cn = (from a in db.DM_LOAIHOADON orderby a.tenloaiHD select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaLoaiHD");
            dt.Columns.Add("TenLoaiHD");
            dt.Rows.Add(null, "Tất cả");
            foreach (DM_LOAIHOADON c in cn)
            {
                dt.Rows.Add(c.LoaiHD_ID, c.tenloaiHD);
            }
            cboLoaiHD.DataSource = dt;
            cboLoaiHD.DisplayMember = "TenLoaiHD";
            cboLoaiHD.ValueMember = "MaLoaiHD";
        }
        private void LoadHinhThucTT()
        {
            var cn = (from a in db.DM_HINHTHUCTHANHTOAN orderby a.tenHTTT select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("maHTTT");
            dt.Columns.Add("tenHTTT");
            dt.Rows.Add(0, "Tất cả");
            foreach (DM_HINHTHUCTHANHTOAN c in cn)
            {
                dt.Rows.Add(c.maHTTT, c.tenHTTT);
            }
            cboHinhThucTT.DataSource = dt;
            cboHinhThucTT.DisplayMember = "tenHTTT";
            cboHinhThucTT.ValueMember = "maHTTT";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void cboDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {  
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //this.Close();

        }

        
    }
}
