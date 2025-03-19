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
    public partial class TraLaiHoaDonHanhThu : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        LocalReport lr = new LocalReport();
        public TraLaiHoaDonHanhThu()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click_1;
            dttungay.Format = DateTimePickerFormat.Custom;
            dttungay.CustomFormat = "dd/MM/yyyy";
            dttungay.Value = dtdenngay.Value.AddMonths(-1);
            dtdenngay.Format = DateTimePickerFormat.Custom;
            dtdenngay.CustomFormat = "dd/MM/yyyy";
        }
        private void TraLaiHoaDonHanhThu_Load(object sender, EventArgs e)
        {

            LoadNVThu();
        }

        void btnTim_Click_1(object sender, EventArgs e)
        {

            List<ReportParameter> param = new List<ReportParameter>();
            decimal nhanvien = Convert.ToDecimal(cboNVThu.SelectedValue.ToString()); //OK
            DateTime tungay = dttungay.Value.Date; 
            DateTime denngay = dtdenngay.Value.Date;
            // lay text duoc chon         
            // duong dan
           
                reportViewer1.LocalReport.ReportPath = "ReportViewer/ReportView/TraLaiHoaDonHanhThu.rdlc";
                this.traLaiHoaDonHanhThuBindingSource.DataSource = db.TraLaiHoaDonHanhThu(nhanvien, tungay, denngay);
    
            {
                // add param
                this.reportViewer1.LocalReport.SetParameters(param);
                ReportDataSource rd = new ReportDataSource("DataSet1");
                lr.DataSources.Add(rd);
                reportViewer1.RefreshReport();

            }

        }
           private void LoadNVThu()
        {
            var nvthu = (from a in db.NHANVIENs orderby a.hoten select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("NV_ID");
            dt.Columns.Add("hoten");
            dt.Rows.Add(0, "Tất cả");
            foreach (NHANVIEN c in nvthu)
            {
                dt.Rows.Add(c.NV_ID, c.hoten);
            }
            cboNVThu.DataSource = dt;
            cboNVThu.DisplayMember = "hoten";
            cboNVThu.ValueMember = "NV_ID";
        }

        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
             
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        
    }
}
