using QLCongNo.View.Core;
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
        private List<dynamic> danhsach = new List<dynamic>();

        public UcThongKeHDDaThu()
        {
            InitializeComponent();
            textBox1.KeyDown += textBox1_KeyDown;
            this.dataGridView1.DataError += dataGridView1_DataError;
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            this.ptbSendSMS.Click += (sender, e) => SendSMS();
        }

        private void SendSMS()
        {
            try
            {
                var countRow = this.danhsach.Count;
                var currentRow = this.dataGridView1.CurrentRow;

                if (countRow == 0) return;
                if (currentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn số danh bộ muốn gửi tin nhắn SMS", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var currentIndex = currentRow.Index;
                var currentDanhBo = this.dataGridView1.Rows[currentIndex].Cells[4].Value.ToString();
                var currentInfo = this.danhsach.FirstOrDefault(x => x.DANHBO == currentDanhBo);
                var kh = db.KHACHHANGs.FirstOrDefault(x => x.madanhbo == currentDanhBo);
                if (currentInfo != null)
                {
                    var danhbo = currentInfo.DANHBO;
                    var soHD = currentInfo.so_hd;
                    var hoten = currentInfo.hoten_KH;
                    var sdt = kh.SDT_KH;
                    var thoigian = currentInfo.ten_kyghi;
                    var tongtien = string.Format("{0:n0}", currentInfo.tongtien);
                    var thongtin = $"{thoigian}; Tong tien {tongtien}";

                    var type = "SMS_HOADON_THANHTOAN";
                    var title = "Hóa đơn đã thanh toán";
                    var frm = new FrmSMS();
                    frm.Type = type;
                    frm.Title = title;
                    frm.DanhBo = danhbo;
                    frm.HoTen = hoten;
                    frm.SDT = sdt;
                    frm.ThongTin = thongtin;
                    frm.DanhSach = null;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "thangColumn")
            {
                if (e.Value != null)
                {
                    string kyghiFull = e.Value.ToString();
                    if (kyghiFull.Length >= 2)
                    {
                        e.Value = kyghiFull.Substring(0, 2);
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "namColumn")
            {
                if (e.Value != null)
                {
                    string kyghiFull = e.Value.ToString();
                    if (kyghiFull.Length >= 2)
                    {
                        e.Value = kyghiFull.Substring(3, 4);
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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
                string denngay = dtpDenngay.Value.ToString("yyyy-MM-dd 23:59:59");
                if (chkNH.Checked == false)
                    nganHangID = 0;
                if (chkTN.Checked == false)
                    thuNgan = 0;
                if (chkHTT.Checked == false)
                    maLoai = "";
                var data = db.getDSDangNgan_Newest(madanhbo, thuNgan, tungay, denngay, maLoai, chkisdangngan.Checked, nganHangID).ToList();
                
                if (data.Count > 0)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                dataGridView1.DataSource = data;
                lblsoluong.Text = "Số lượng HĐ: " + string.Format("{0:n0}", data.Count());
                lbltongtien.Text = "Tổng tiền:  " + string.Format("{0:n0}", data.ToList().Sum(x => x.tongtien));
                table = ExcelExportHelper.ListToDataTable(data);
                this.Cursor = Cursors.Default;

                foreach (var item in data)
                {
                    this.danhsach.Add(item);
                }
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