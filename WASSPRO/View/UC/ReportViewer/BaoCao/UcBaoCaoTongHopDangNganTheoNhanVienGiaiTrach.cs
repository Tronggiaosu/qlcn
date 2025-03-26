using QLCongNo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WinFormsReport = Microsoft.Reporting.WinForms;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcBaoCaoTongHopDangNganTheoNhanVienGiaiTrach : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcBaoCaoTongHopDangNganTheoNhanVienGiaiTrach()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var tungay = dateTimePicker1.Value.Date;
                string tenbaocao = tungay.ToString("dd/MM/yyyy");
                var root = "ReportViewer\\ReportView\\RPTongHopDangNganTheoNhanVienGiaiTrach.rdlc";
                string basePath = Directory.GetCurrentDirectory();
                var reportPath = $"{basePath}\\{root}";

                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show("File report không tồn tại: " + reportPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.reportViewer1.LocalReport.ReportPath = reportPath;

                var startDate = dateTimePicker1.Value.Date;
                var endDate = startDate.AddDays(1);

                var queryResult = (from dn in db.DANGNGANs
                                   where dn.NGAYDANGNGAN_NV >= startDate
                                         && dn.NGAYDANGNGAN_NV < endDate
                                   join ct in db.CHUNGTUs on dn.IDCT equals ct.ID_CT
                                   join nh in db.DM_NGANHANG on ct.NV_ID_NOP equals nh.NGANHANG_ID
                                   join nv in db.NHANVIENs on ct.NV_ID_LAP equals nv.NV_ID into nvJoin
                                   from nv in nvJoin.DefaultIfEmpty()
                                   join hd in db.HOADONs on dn.ID_HD equals hd.ID_HD
                                   select new
                                   {
                                       TENNGANHANG = nh.TENNGANHANG,
                                       TONGTIEN = hd.tongtien,
                                       HOTEN_NV = nv.hoten,
                                       GHICHU = ct.GHICHU
                                   }).ToList();
                var result = queryResult
                .GroupBy(x => new { x.TENNGANHANG, x.HOTEN_NV })  
                .Select(grouped => new
                {
                    tenNhanVien = grouped.Key.HOTEN_NV,
                    donViThanhToan = grouped.Key.TENNGANHANG,
                    soLuongHoaDon = grouped.Count(),
                    tien = grouped.Sum(g => g.TONGTIEN),
                    ghiChu = string.Join("; ", grouped.Select(g => g.GHICHU).Distinct())
                }).ToList();



                List<DataDangNganNV> dataDangNgans = new List<DataDangNganNV>();
                foreach (var item in result)
                {
                    DataDangNganNV dataDangNgan = new DataDangNganNV();
                    dataDangNgan.tenNhanVien = item.tenNhanVien;
                    dataDangNgan.donViThanhToan = item.donViThanhToan;
                    dataDangNgan.soLuongHoaDon = item.soLuongHoaDon;
                    dataDangNgan.tien = (decimal)item.tien;
                    dataDangNgan.ghiChu = item.ghiChu;

                    dataDangNgans.Add(dataDangNgan);
                }

                var bindingSourceDN = new BindingSource();
                bindingSourceDN.DataSource = dataDangNgans;

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new WinFormsReport.ReportDataSource("DataSet1", bindingSourceDN));

                List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
                param.Add(new WinFormsReport.ReportParameter("tenbaocao", tenbaocao));
                this.reportViewer1.LocalReport.SetParameters(param);

                this.reportViewer1.RefreshReport();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load report: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcBaoCaoTongHopDangNganTheoNhanVienGiaiTrach_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
    }
}
