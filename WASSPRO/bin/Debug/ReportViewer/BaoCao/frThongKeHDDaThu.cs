using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.BaoCao
{
    public partial class frThongKeHDDaThu : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        DataTable table;
        public frThongKeHDDaThu()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frThongKeHDDaThu_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dtpDenngay.Format = DateTimePickerFormat.Custom;
            dtpTungay.Format = DateTimePickerFormat.Custom;
            dtpDenngay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpTungay.CustomFormat = "dd/MM/yyyy";
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
            cboThuNgan.DataSource = nhanvien.OrderBy(x=>x.hoten).ToList();
            cboThuNgan.ValueMember = "NV_ID";
            cboThuNgan.DisplayMember = "hoten";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var nganHangID = int.Parse(cboNganhang.SelectedValue.ToString());
                string maLoai = cboHTTT.SelectedValue.ToString();
                int thuNgan = int.Parse(cboThuNgan.SelectedValue.ToString());
                var tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
                var denngay = dtpDenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
                if (chkNH.Checked == false)
                    nganHangID = 0;
                if (chkTN.Checked == false)
                    thuNgan = 0;
                if (chkHTT.Checked == false)
                    maLoai = "";
                var data = db.getDSDangNgan(thuNgan, tungay, denngay, maLoai, chkisdangngan.Checked, nganHangID).ToList();
                dataGridView1.DataSource = data.ToList();
                lblsoluong.Text = "Số lượng HĐ: " + string.Format("{0:n0}", data.Count());
                lbltongtien.Text = "Tổng tiền:  " + string.Format("{0:n0}", data.ToList().Sum(x => x.tongtien));
                table = ExcelExportHelper.ListToDataTable(data);
            }
            catch
            {

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file|.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {

                    string[] columns = { "KY_HIEU_HD", "ten_kyghi", "so_hd", "DANHBO", "NGAYDANGNGAN_NV", "ngayBK", "tongtien0VAT", "tienvat", "tienBVMT", "PhiNT", "TienThueNT", "tongtien", "tienuoc_dc", "tienthue_dc", "tienphi_dc", "PhiNT_dc", "TienThueNT_dc", "NVNop", "GHICHU", "SOPHATHANH", "hoten_KH", "MaLT" };


                    var result = ExcelExportHelper.ExportExcel(table, false, columns);
                    File.WriteAllBytes(save.FileName, result);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Xuất dữ liệu thành công!");
                }
            }
            catch
            {

            }
        }
    }
}
