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
    public partial class frBaoCaoTongHopTheoLoai : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frBaoCaoTongHopTheoLoai()
        {
            InitializeComponent();
        }

        private void frBaoCaoTongHopTheoLoai_Load(object sender, EventArgs e)
        {
            cboDT.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            cboDT.DataSource = db.DM_LOAIHOADON.ToList();
            cboDT.ValueMember = "loaiHD_Id";
            cboDT.DisplayMember = "tenloaiHD";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPBaoCaoTongHopTheoLoai.rdlc";
            string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string dengay = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            int loaiHD = 0;
            string bophan = "TỔNG HỢP";
            if (chkLoaiHD.Checked == true)
            {
                loaiHD = int.Parse(cboDT.SelectedValue.ToString());
                if (loaiHD == 1)
                    bophan = "TƯ GIA";
                else
                    bophan = "CƠ QUAN";
            }
            string ptungay = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string pdengay = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            string pNgayThang = "Từ ngày " + ptungay + " đến ngày " + pdengay;
            if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)
                pNgayThang = "Ngày " + ptungay;
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("tenDT", bophan));
            param.Add(new ReportParameter("pNgayThang", pNgayThang));
            var data = db.getBaoCaoTongHopTheoLoai(tungay, dengay, loaiHD).ToList();
            this.reportViewer1.LocalReport.SetParameters(param);
            this.getBaoCaoTongHopTheoLoaiBindingSource.DataSource = data;
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
