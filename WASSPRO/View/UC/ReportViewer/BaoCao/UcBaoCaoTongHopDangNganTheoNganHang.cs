using QLCongNo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsReport = Microsoft.Reporting.WinForms;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcBaoCaoTongHopDangNganTheoNganHang : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcBaoCaoTongHopDangNganTheoNganHang()
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
                var root = "ReportViewer\\ReportView\\RPTongHopDangNganTheoNganHang.rdlc";
                string basePath = Directory.GetCurrentDirectory();
                var reportPath = $"{basePath}\\{root}";

                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show("File report không tồn tại: " + reportPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.reportViewer2.LocalReport.ReportPath = reportPath;

                var startDate = dateTimePicker1.Value.Date;
                var endDate = startDate.AddDays(1);
                var result = (from dn in db.DANGNGANs
                              where
                                    dn.NGAYDANGNGAN_NV >= startDate
                                  && dn.NGAYDANGNGAN_NV < endDate
                              join ct in db.CHUNGTUs on dn.IDCT equals ct.ID_CT
                              join nh in db.DM_NGANHANG on ct.NV_ID_NOP equals nh.NGANHANG_ID
                              join hd in db.HOADONs on dn.ID_HD equals hd.ID_HD
                              group new { hd, nh } by nh.TENNGANHANG into grouped
                              select new
                              {
                                  donViThanhToan = grouped.Key,
                                  soLuongHoaDon = grouped.Count(),
                                  tien = grouped.Sum(g => g.hd.tongtien)
                              }).ToList();
                List<DataDangNganNH> dataDangNgans = new List<DataDangNganNH>();
                foreach (var item in result)
                {
                    DataDangNganNH dataDangNgan = new DataDangNganNH();
                    dataDangNgan.donViThanhToan = item.donViThanhToan;
                    dataDangNgan.soLuongHoaDon = item.soLuongHoaDon;
                    dataDangNgan.tien = (decimal)item.tien;

                    dataDangNgans.Add(dataDangNgan);
                }

                var bindingSourceDN = new BindingSource();
                bindingSourceDN.DataSource = dataDangNgans;

                this.reportViewer2.LocalReport.DataSources.Clear();
                this.reportViewer2.LocalReport.DataSources.Add(new WinFormsReport.ReportDataSource("DataSet1", bindingSourceDN));

                List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
                param.Add(new WinFormsReport.ReportParameter("tenbaocao", tenbaocao));
                this.reportViewer2.LocalReport.SetParameters(param);

                this.reportViewer2.RefreshReport();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load report: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcBaoCaoTongHopDangNganTheoNganHang_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
    }
}
