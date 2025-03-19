using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
using WinFormsReport = Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcBaoCaoTongHop : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcBaoCaoTongHop()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //string basePath = AppDomain.CurrentDomain.BaseDirectory;
            //string projectRootPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            //string reportPath = Path.Combine(projectRootPath, "WASSPRO", "ReportViewer", "ReportView", "RPBaoCaoTongHop.rdlc");

            var root = "ReportViewer\\ReportView\\RPBaoCaoTongHop.rdlc";
            string basePath = Directory.GetCurrentDirectory();
            var reportPath = $"{basePath}\\{root}";

            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("File report không tồn tại: " + reportPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.reportViewer1.LocalReport.ReportPath = reportPath;

            string tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
            string dengay = dtpDenngay.Value.ToString("yyyy-MM-dd");
            int loaiHD = 0;
            string bophan = "BỘ PHẬN: TỔNG HỢP";
            if (chkDT.Checked == true)
            {
                bophan = "BỘ PHẬN: " + cboDT.Text.ToUpper();
                loaiHD = int.Parse(cboDT.SelectedValue.ToString());
            }
            string ptungay = dtpTungay.Value.ToString("dd/MM/yyyy");
            string pdengay = dtpDenngay.Value.ToString("dd/MM/yyyy");
            string pNgayThang = "Từ ngày " + ptungay + " đến ngày " + pdengay;
            //List<ReportParameter> param = new List<ReportParameter>();
            List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
            //param.Add(new ReportParameter("pTenDT", bophan));
            param.Add(new WinFormsReport.ReportParameter("pTenDT", bophan));
            //param.Add(new ReportParameter("pNgayThang", pNgayThang));
            param.Add(new WinFormsReport.ReportParameter("pNgayThang", pNgayThang));
            this.reportViewer1.LocalReport.SetParameters(param);
            var dataSource = db.getBaoCaoTongHop(tungay, dengay, "", loaiHD).ToList();

            int? nVID = chkDT.Checked ? (int?)loaiHD : null;
            var hdkd = db.getDSChuyenNoKhoDoi(tungay, dengay, nVID:null).ToList();

            var groupedData = hdkd
            .GroupBy(x => x.DANHBO)
            .Select(g => new
            {
                DANHBO = g.Key,
                hoten = g.First().hoten,
                maNV = g.First().maNV,
                kyghi = g.First().kyghi,
                nhanvien = g.First().nhanvien,
                NGUOITHANHTOAN = g.First().NGUOITHANHTOAN,
                SOPHATHANH = g.First().SOPHATHANH,
                TONGTIEN = g.Sum(x => x.TONGTIEN),
                tongtien0VAT = g.Sum(x => x.tongtien0VAT),
                tienvat = g.Sum(x => x.tienvat),
                tienBVMT = g.Sum(x => x.tienBVMT),
                PhiNT = g.Sum(x => x.PhiNT),
                TienThueNT = g.Sum(x => x.TienThueNT),
                ghichu = g.First().ghichu,
                NGAYCHUYEN = g.First().NGAYCHUYEN,
                HĐ = g.Count(),
            })
            .ToList();

            DataTable reportData = new DataTable();
            reportData.Columns.Add("DANHBO", typeof(decimal));
            reportData.Columns.Add("hoten", typeof(string));
            reportData.Columns.Add("maNV", typeof(string));
            reportData.Columns.Add("kyghi", typeof(string));
            reportData.Columns.Add("nhanvien", typeof(string));
            reportData.Columns.Add("NGUOITHANHTOAN", typeof(string));
            reportData.Columns.Add("SOPHATHANH", typeof(string));
            reportData.Columns.Add("TONGTIEN", typeof(decimal));
            reportData.Columns.Add("tongtien0VAT", typeof(decimal));
            reportData.Columns.Add("tienvat", typeof(decimal));
            reportData.Columns.Add("tienBVMT", typeof(decimal));
            reportData.Columns.Add("PhiNT", typeof(decimal));
            reportData.Columns.Add("TienThueNT", typeof(decimal));
            reportData.Columns.Add("ghichu", typeof(string));
            reportData.Columns.Add("NGAYCHUYEN", typeof(DateTime));

            var culture = new CultureInfo("vi-VN");
            foreach (var item in groupedData)
            {              
                reportData.Rows.Add(
                    item.HĐ,
                    item.hoten,
                    item.maNV,
                    item.kyghi,
                    item.nhanvien,
                    item.NGUOITHANHTOAN,
                    item.SOPHATHANH,
                    item.TONGTIEN ?? 0, 
                    item.tongtien0VAT ?? 0,
                    item.tienvat ?? 0,
                    item.tienBVMT ?? 0,
                    item.PhiNT ?? 0,
                    item.TienThueNT ?? 0,
                    item.ghichu,
                    item.NGAYCHUYEN
                );
            }

            var bindingSourceMain = new BindingSource();
            bindingSourceMain.DataSource = dataSource;
            //ReportDataSource mainDataSource = new ReportDataSource("DataSource", bindingSourceMain);
            WinFormsReport.ReportDataSource mainDataSource = new WinFormsReport.ReportDataSource("DataSource", bindingSourceMain);
            this.reportViewer1.LocalReport.DataSources.Add(mainDataSource);
            this.reportViewer1.RefreshReport();

            var bindingSourceHDKD = new BindingSource();
            bindingSourceHDKD.DataSource = reportData;  
            WinFormsReport.ReportDataSource hdkdDataSource = new WinFormsReport.ReportDataSource("DataSource1", bindingSourceHDKD);
            this.reportViewer1.LocalReport.DataSources.Add(hdkdDataSource);
            this.reportViewer1.RefreshReport();
            this.Cursor = Cursors.Default;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ////this.Close();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}