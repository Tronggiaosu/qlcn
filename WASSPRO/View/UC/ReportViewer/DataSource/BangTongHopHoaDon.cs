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
    public partial class BangTongHopHoaDon : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        LocalReport lr = new LocalReport();

        public BangTongHopHoaDon()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;

        }
        private void BangTongHopHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cAPNUOC_TDCDataSet.RPBangTongHopHoaDonChuanChuKy' table. You can move, or remove it, as needed.
           
            LoadTo();
            LoadKy();
         
        }
        void btnTim_Click(object sender, EventArgs e)
        {
            List<ReportParameter> param = new List<ReportParameter>();
            string ky = cboKyghi.SelectedValue.ToString(); // lay id
            string to = cboTo.SelectedValue.ToString();
            var ten_kyghi = cboKyghi.Text; // lay text duoc chon
            var TenTo = cboTo.Text;
            string checks = null;
            // duong dan
            if (checkBangChuanThu.Checked == true)
            {
                reportViewer1.LocalReport.ReportPath = "ReportViewer/ReportView/ChuanThuKy.rdlc";
                this.rPBangTongHopHoaDonChuanChuKyBindingSource.DataSource = db.RPBangTongHopHoaDonChuanChuKy(ky, to);
            }
            else if (checkTheoDot.Checked == true)
            {
                reportViewer1.LocalReport.ReportPath = "ReportViewer/ReportView/ChiaTheoDot.rdlc";
                this.rPBangTongHopHoaDonChuanChuKyBindingSource.DataSource = db.RPBangTongHopHoaDonChiaTheoDot(ky, to);
            }
            else if (checkBang0TheoDot.Checked == true)
            {
                reportViewer1.LocalReport.ReportPath = "ReportViewer/ReportView/Bang0ChiaTheoDot.rdlc";
                this.rPBangTongHopHoaDonChuanChuKyBindingSource.DataSource = db.RPBangTongHopHoaDonChiaTheoDotBang0(ky, to);
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
                this.reportViewer1.LocalReport.SetParameters(param);
                ReportDataSource rd = new ReportDataSource("DataSet1");
                lr.DataSources.Add(rd);
                //  lr.SetParameters(param);
                // add data source
                reportViewer1.RefreshReport();

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
            cboKyghi.DataSource = ky.ToList();
            cboKyghi.DisplayMember = "ten_kyghi";
            cboKyghi.ValueMember = "ID_kyghi";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void reportViewer_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
             
        }


    }
}
