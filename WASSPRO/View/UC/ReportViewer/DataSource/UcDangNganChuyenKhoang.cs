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
    public partial class UcDangNganChuyenKhoang : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private LocalReport lr = new LocalReport();

        public UcDangNganChuyenKhoang()
        {
            InitializeComponent();

            btnTim.Click += btnTim_Click;
            dttungay.Format = DateTimePickerFormat.Custom;
            dttungay.CustomFormat = "dd/MM/yyyy";
            dttungay.Value = dtdenngay.Value.AddMonths(-1);
            dtdenngay.Format = DateTimePickerFormat.Custom;
            dtdenngay.CustomFormat = "dd/MM/yyyy";
        }

        private void DangNganChuyenKhoang_Load(object sender, EventArgs e)
        {
            LoadDoiTuong();
            LoadDoiTruong();
            LoadNVLapPhieu();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<ReportParameter> param = new List<ReportParameter>();
            string doituong = cbodoituong.SelectedValue.ToString(); // lay id
            DateTime tungay = dttungay.Value.Date;
            DateTime denngay = dtdenngay.Value.Date;
            // lay text duoc chon
            var date = DateTime.Now;
            var ngay = date.ToString("dd");
            var thang = date.ToString("MM");
            var nam = date.ToString("yyyy");
            var dtuong = cbodoituong.Text;
            var doitruong = cboDoiTruong.Text;
            var lapphieu = cboNVLapPhieu.Text;
            string checks = null;
            // duong dan
            if (checkChiTiet.Checked == true)
            {
                reportViewer1.LocalReport.ReportPath = "ReportViewer/ReportView/PhieuDangNganChuyenKhoangChiTiet.rdlc";
                this.phieuDangNganChuyenKhoangChiTietBindingSource.DataSource = db.PhieuDangNganChuyenKhoangChiTiet(doituong, tungay, denngay);
            }
            else if (checkTongCong.Checked == true)
            {
                reportViewer1.LocalReport.ReportPath = "ReportViewer/ReportView/PhieuDangNganChuyenKhoangTongHop.rdlc";
                this.phieuDangNganChuyenKhoangChiTietBindingSource.DataSource = db.PhieuDangNganChuyenKhoangTongHop(doituong, tungay, denngay);
            }
            else
                checks = "";

            if (checks == "")
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo!");
            }
            else
            {
                // add param
                param.Add(new ReportParameter("ngay", ngay ?? "00"));
                param.Add(new ReportParameter("thang", thang ?? "00"));
                param.Add(new ReportParameter("nam", nam ?? "00"));
                param.Add(new ReportParameter("dtuong", dtuong));
                param.Add(new ReportParameter("doitruong", doitruong));
                param.Add(new ReportParameter("lapphieu", lapphieu));
                this.reportViewer1.LocalReport.SetParameters(param);
                ReportDataSource rd = new ReportDataSource("DataSet1");
                lr.DataSources.Add(rd);
                reportViewer1.RefreshReport();
            }
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
            cbodoituong.DataSource = dt;
            cbodoituong.DisplayMember = "tenDT";
            cbodoituong.ValueMember = "maDT";
        }

        private void LoadDoiTruong()
        {
            var doitruong = (from a in db.NHANVIENs orderby a.hoten select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("NV_ID");
            dt.Columns.Add("hoten");
            // dt.Rows.Add(null, "Tất cả");
            foreach (NHANVIEN c in doitruong)
            {
                dt.Rows.Add(c.NV_ID, c.hoten);
            }
            cboDoiTruong.DataSource = dt;
            cboDoiTruong.DisplayMember = "hoten";
            cboDoiTruong.ValueMember = "NV_ID";
        }

        private void LoadNVLapPhieu()
        {
            var nvlapphieu = (from a in db.NHANVIENs orderby a.hoten select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("NV_ID");
            dt.Columns.Add("hoten");
            // dt.Rows.Add(null, "Tất cả");
            foreach (NHANVIEN c in nvlapphieu)
            {
                dt.Rows.Add(c.NV_ID, c.hoten);
            }
            cboNVLapPhieu.DataSource = dt;
            cboNVLapPhieu.DisplayMember = "hoten";
            cboNVLapPhieu.ValueMember = "NV_ID";
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}