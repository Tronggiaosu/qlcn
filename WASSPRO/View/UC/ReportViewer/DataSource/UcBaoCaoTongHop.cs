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
    public partial class UcBaoCaoTongHop : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private LocalReport lr = new LocalReport();

        public UcBaoCaoTongHop()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
        }

        private void BaoCaoTongHop_Load(object sender, EventArgs e)
        {
            LoadTo();
            LoadKy();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<ReportParameter> param = new List<ReportParameter>();
            string ky = cboKy.SelectedValue.ToString(); // lay id
            string to = cboTo.SelectedValue.ToString();
            var ten_kyghi = cboKy.Text; // lay text duoc chon
            var TenTo = cboTo.Text;
            string checks = null;
            // duong dan
            if (checkBangChuanThu.Checked == true)
            {
                reportViewer.LocalReport.ReportPath = "ReportViewer/ReportView/ChuanThuKy.rdlc";
                this.rPBangTongHopHoaDonChuanThuKyBindingSource.DataSource = db.RPBangTongHopHoaDonChuanThuKy(ky, to);
            }
            else if (checkChiaTheoDot.Checked == true)
            {
                //BangTongHopHoaDonChiaTheoDot f = new BangTongHopHoaDonChiaTheoDot();
                //f.Show();
                reportViewer.LocalReport.ReportPath = "ReportViewer/ReportView/ChiaTheoDot.rdlc";
                this.rPBangTongHopHoaDonChuanThuKyBindingSource.DataSource = db.RPBangTongHopHoaDonChiaTheoDot(ky, to);
            }
            else if (checkBang0TheoDot.Checked == true)
            {
                reportViewer.LocalReport.ReportPath = "ReportViewer/ReportView/Bang0ChiaTheoDot.rdlc";
                this.rPBangTongHopHoaDonChuanThuKyBindingSource.DataSource = db.RPBangTongHopHoaDonChiaTheoDotBang0(ky, to);
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
                param.Add(new ReportParameter("TENTO", TenTo));
                param.Add(new ReportParameter("ten_kyghi", ten_kyghi));
                this.reportViewer.LocalReport.SetParameters(param);
                ReportDataSource rd = new ReportDataSource("DataSet1");
                lr.DataSources.Add(rd);
                //  lr.SetParameters(param);
                // add data source
                reportViewer.RefreshReport();
            }
        }

        private void LoadTo()
        {
            var cn = (from a in db.DM_TO orderby a.TENTO select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("TO_ID");
            dt.Columns.Add("TENTO");
            dt.Rows.Add(0, "Tất cả");
            foreach (DM_TO c in cn)
            {
                dt.Rows.Add(c.TO_ID, c.TENTO);
            }
            cboTo.DataSource = dt;
            cboTo.DisplayMember = "TENTO";
            cboTo.ValueMember = "TO_ID";
        }

        private void LoadKy()
        {
            var ky = (from a in db.DM_KYGHI select a).OrderByDescending(n => n.ID_kyghi);
            cboKy.DataSource = ky.ToList();
            cboKy.DisplayMember = "ten_kyghi";
            cboKy.ValueMember = "ID_kyghi";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ////this.Close();
        }

        private void reportViewer_Load(object sender, EventArgs e)
        {
        }

        private void reportViewer_Load_1(object sender, EventArgs e)
        {
        }
    }
}