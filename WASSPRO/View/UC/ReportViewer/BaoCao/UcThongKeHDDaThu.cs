using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcThongKeHDDaThu : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DataTable table;

        public UcThongKeHDDaThu()
        {
            InitializeComponent();
            textBox1.KeyDown += textBox1_KeyDown;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
        }

        private void frThongKeHDDaThu_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoGenerateColumns = false;
            dtpTungay.Format = DateTimePickerFormat.Custom;
            dtpTungay.CustomFormat = "dd/MM/yyyy";
            dtpDenngay.Format = DateTimePickerFormat.Custom;
            dtpDenngay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            // dm ngan hang
            cboNganhang.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NGANHANG> nganhang = new List<DM_NGANHANG>();
            nganhang.Add(new DM_NGANHANG() { NGANHANG_ID = 0, TENNGANHANG = "Tất cả" });
            var dmNganhang = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList();
            nganhang.AddRange(dmNganhang);
            cboNganhang.DataSource = nganhang.ToList();
            cboNganhang.ValueMember = "NGANHANG_ID";
            cboNganhang.DisplayMember = "TENNGANHANG";
            var loaiChungTu = db.DM_LOAICHUNGTU.ToList();
            cboHTTT.DataSource = loaiChungTu;
            cboHTTT.ValueMember = "maloai";
            cboHTTT.DisplayMember = "tenloai";
            var nhanvien = (from a in db.NHANVIENs
                            from b in db.NHANVIEN_LNV
                            where a.NV_ID == b.NV_ID
                            where b.ID_LoaiNV == 7
                            select a).Distinct().ToList();
            cboThuNgan.DataSource = nhanvien.OrderBy(x => x.hoten).ToList();
            cboThuNgan.ValueMember = "NV_ID";
            cboThuNgan.DisplayMember = "hoten";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string madanhbo = textBox1.Text.Trim();
                var nganHangID = int.Parse(cboNganhang.SelectedValue.ToString());
                string maLoai = cboHTTT.SelectedValue.ToString();
                int thuNgan = int.Parse(cboThuNgan.SelectedValue.ToString());
                var tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
                string denngay = dtpDenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
                if (chkNH.Checked == false)
                    nganHangID = 0;
                if (chkTN.Checked == false)
                    thuNgan = 0;
                if (chkHTT.Checked == false)
                    maLoai = "";
                var data = db.getDSDangNgan(thuNgan, tungay, denngay, maLoai, chkisdangngan.Checked, nganHangID).ToList();
                if (!string.IsNullOrEmpty(madanhbo))
                {
                    data = data.Where(x => x.DANHBO.Contains(madanhbo)).ToList();
                }
                var result = data.Select(x =>
                {
                    var ngayDangNgan = x.ngaydangngan?.ToString("dd/MM/yyyy");
                    var ngayBK = x.ngayBK?.ToString("dd/MM/yyyy");
                    var ngayThanhToan = db.GACHNOes.FirstOrDefault(g => g.ID_HD == x.ID_HD)?.NGAYTHANHTOAN?.ToString("dd/MM/yyyy");
                    var nvLap = db.NHANVIENs.FirstOrDefault(nv => nv.NV_ID == x.NV_ID_LAP)?.hoten;
                    var tenNganHang = db.DM_NGANHANG.FirstOrDefault(nh => nh.NGANHANG_ID == x.NGANHANG_ID)?.TENNGANHANG;

                    return new
                    {
                        x.so_hd,
                        x.KY_HIEU_HD,
                        x.SOPHATHANH,
                        x.nam,
                        x.DANHBO,
                        x.tongtien0VAT,
                        x.tienvat,
                        x.tienBVMT,
                        x.PhiNT,
                        x.TienThueNT,
                        x.tongtien,
                        x.hoten_KH,
                        x.NVNop,
                        x.GHICHU,
                        x.ten_kyghi,
                        ngayDangNgan,
                        ngayBK,
                        x.MaLT,
                        x.tenloai,
                        ngayThanhToan,
                        nvLap,
                        tenNganHang
                    };
                }).ToList();
                if (result.Count > 0)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                dataGridView1.DataSource = result;
                lblsoluong.Text = "Số lượng HĐ: " + string.Format("{0:n0}", result.Count());
                lbltongtien.Text = "Tổng tiền:  " + string.Format("{0:n0}", result.ToList().Sum(x => x.tongtien));
                table = ExcelExportHelper.ListToDataTable(result);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Hiện tại không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file|.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string[] columns = { "KY_HIEU_HD", "ten_kyghi", "so_hd", "DANHBO", "NGAYDANGNGAN_NV", "ngayBK", "tongtien0VAT", "tienvat", "tienBVMT", "PhiNT", "TienThueNT", "tongtien", "tienuoc_dc", "tienthue_dc", "tienphi_dc", "PhiNT_dc", "TienThueNT_dc", "NVNop", "GHICHU", "SOPHATHANH", "hoten_KH", "MaLT" };

                    var result = ExcelExportHelper.ExportExcel(table, false, columns);
                    File.WriteAllBytes(save.FileName, result);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string text = textBox1.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnSearch.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}