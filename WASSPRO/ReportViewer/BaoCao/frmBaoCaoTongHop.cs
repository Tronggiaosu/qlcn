using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.BaoCao
{
    public partial class frmBaoCaoTongHop : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frmBaoCaoTongHop()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPBaoCaoTongHop.rdlc";
            string tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
            string dengay = dtpDenngay.Value.ToString("yyyy-MM-dd");
            int loaiHD = 0;
            string bophan = "BỘ PHẬN: TỔNG HỢP";
            if (chkDT.Checked == true) 
            {
                bophan = "BỘ PHẬN: " +  cboDT.Text.ToUpper();
                loaiHD = int.Parse(cboDT.SelectedValue.ToString());
            }
            string ptungay = dtpTungay.Value.ToString("dd/MM/yyyy");
            string pdengay = dtpDenngay.Value.ToString("dd/MM/yyyy");
            string pNgayThang = "Từ ngày " + ptungay + " đến ngày " + pdengay;
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("pTenDT", bophan));
            param.Add(new ReportParameter("pNgayThang", pNgayThang));
            this.reportViewer1.LocalReport.SetParameters(param);
            var dataSource = db.getBaoCaoTongHop(tungay, dengay, "", loaiHD).ToList();
            this.getBaoCaoTongHopBindingSource.DataSource = dataSource.ToList();
            this.reportViewer1.RefreshReport();

        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBaoCaoTongHop_Load(object sender, EventArgs e)
        {
            dtpDenngay.CustomFormat = "dd/MM/yyyy";
            dtpTungay.CustomFormat = "dd/MM/yyyy";
            cboDT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDT.DataSource = db.DM_LOAIHOADON.ToList();
            cboDT.ValueMember = "loaiHD_Id";
            cboDT.DisplayMember = "tenloaiHD";
        }
    }
}
