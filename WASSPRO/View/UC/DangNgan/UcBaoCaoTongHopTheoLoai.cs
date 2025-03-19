using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WinFormsReport = Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using QLCongNo.View.UC.HoaDon;

namespace QLCongNo.View.UC.DangNgan
{
    public partial class UcBaoCaoTongHopTheoLoai : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcBaoCaoTongHopTheoLoai()
        {
            InitializeComponent();
        }

        private void frBaoCaoTongHopTheoLoai_Load(object sender, EventArgs e)
        {
            cboDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            cboDT.DataSource = db.DM_LOAIHOADON.ToList();
            cboDT.ValueMember = "loaiHD_Id";
            cboDT.DisplayMember = "tenloaiHD";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var root = "ReportViewer\\ReportView\\RPBaoCaoTongHopTheoLoai.rdlc";
            string basePath = Directory.GetCurrentDirectory();
            var reportPath = $"{basePath}\\{root}";

            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("File report không tồn tại: " + reportPath);
                return;
            }
            this.reportViewer1.LocalReport.ReportPath = reportPath;
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
            List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
            param.Add(new WinFormsReport.ReportParameter("tenDT", bophan));
            param.Add(new WinFormsReport.ReportParameter("pNgayThang", pNgayThang));
            var data = db.getBaoCaoTongHopTheoLoai(tungay, dengay, loaiHD).ToList();
            this.reportViewer1.LocalReport.SetParameters(param);
            this.getBaoCaoTongHopTheoLoaiBindingSource.DataSource = data;
            this.reportViewer1.RefreshReport();
            this.Cursor = Cursors.Default;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }
    }
}