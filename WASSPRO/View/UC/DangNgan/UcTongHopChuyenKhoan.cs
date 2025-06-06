using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WinFormsReport = Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using QLCongNo.View.UC.HoaDon;
using System.Text.RegularExpressions;

namespace QLCongNo.View.UC.DangNgan
{
    public partial class UcTongHopChuyenKhoan : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcTongHopChuyenKhoan()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var root = "ReportViewer\\ReportView\\RPPhieuDangNganChuyenKhoan.rdlc";
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
                param.Add(new WinFormsReport.ReportParameter("pNgaythang", pNgayThang));
                var data = db.getThongKeDangNganChuyenKhoanTheoNgay(loaiHD, tungay, dengay).ToList();

                //var copyData = data.ToList();

                ////var copyData = data;
                //var pattern = @"(\d{1,2}/\d{1,2}/\d{2}).*?:\s*(\d{1,3}\.\d{3})";
                ////foreach (var item in data)
                ////    copyData.Add(item);

                //foreach (var item in copyData)
                //{
                //    var ghichu = item.ghichu;
                //    var matches = Regex.Matches(ghichu, pattern);

                //    foreach (Match rowData in matches)
                //    {
                //        var date = rowData.Groups[1].Value;
                //        var amount = rowData.Groups[2].Value;

                //        var parsedDate = DateTime.ParseExact(date, "d/M/yy", null);
                //        var formattedDate = parsedDate.ToString("dd/MM/yyyy");
                //        var formattedAmount = decimal.Parse(amount.Replace(".", ""));
                //        copyData.Add(new getThongKeDangNganChuyenKhoanTheoNgay_Result
                //        {
                //            soluong = 1,
                //            ngay = formattedDate,
                //            tiennuoc = 0,
                //            tienBVMT = 0,
                //            tongtien = formattedAmount,
                //            ghichu = String.Empty
                //        });
                //    }
                //}

                this.reportViewer1.LocalReport.SetParameters(param);
                this.getThongKeDangNganChuyenKhoanTheoNgayBindingSource.DataSource = data;
                this.reportViewer1.RefreshReport();
                this.Cursor = Cursors.Default;

                if (data.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn vui lòng chọn thời gian ngắn hơn, khoảng 2 tháng!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //    this.Close();
        }

        private void frTongHopChuyenKhoan_Load(object sender, EventArgs e)
        {
            cboDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            cboDT.DataSource = db.DM_LOAIHOADON.ToList();
            cboDT.ValueMember = "loaiHD_Id";
            cboDT.DisplayMember = "tenloaiHD";
        }
    }
}