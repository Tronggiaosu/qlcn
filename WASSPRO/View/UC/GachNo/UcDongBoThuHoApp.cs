using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcDongBoThuHoApp : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DataTable table;

        public UcDongBoThuHoApp()
        {
            InitializeComponent();
            btnsearch.Click += btnsearch_Click;
            cboTo.SelectedIndexChanged += cboTo_SelectedIndexChanged;
            btnConfirm.Click += btnConfirm_Click;
            btnExcel.Click += btnExcel_Click;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "so_db", "so_hd", "ky_hieu", "trang_thai", "nv_xuly", "ngay_xu_ly", "ky_hd", "nam", "ngay_thanh_toan" };

                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tungay = dateTimePicker1.Value.Date;
                DateTime denngay = dateTimePicker2.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                var dataSource = db.THU_HO.Where(x => x.trang_thai == "0" && x.ngay_thanh_toan >= tungay && x.ngay_thanh_toan <= denngay).OrderByDescending(x => x.ngay_thanh_toan).ToList();
                int TOID = int.Parse(cboTo.SelectedValue.ToString());
                int NVID = int.Parse(cboNV.SelectedValue.ToString());
                if (NVID != 0)
                {
                    dataSource = dataSource.Where(x => x.nv_thu == cboNV.Text).ToList();
                }
                if (txtimdanhbo.Text != "")
                {
                    dataSource = dataSource.Where(x => x.so_db.Contains(txtimdanhbo.Text)).ToList();
                }
                var dsKhachhang = dataSource.Select(x => x.so_db).Distinct().ToList();
                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                int i = 0;
                foreach (var item in dsKhachhang)
                {
                    var dshoadon = dataSource.Where(x => x.so_db == item).Select(x => new { ds = x.so_hd + "|" + x.ky_hieu }).ToList();
                    var nvthu = dataSource.Where(x => x.so_db == item).ToList();
                    var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == item).FirstOrDefault();
                    object[] reseult = tdc.ThanhToanHoaDon_WASSPRO_List("WASS01", hashkey, khachhang.ID_KH.ToString(), dshoadon.Select(x => x.ds.ToString()).ToArray(), "", "", nvthu.FirstOrDefault().nv_thu, "", "", "Loi Thanh Toan");
                    if (reseult[0].ToString().ToUpper() == "TRUE")
                    {
                        nvthu.ForEach(x => x.trang_thai = "đã xử lý");
                        nvthu.ForEach(x => x.ngay_xu_ly = DateTime.Now);
                        nvthu.ForEach(x => x.nv_xuly = Common.username);
                        db.SaveChanges();
                    }
                    i = i + 1;
                }
                MessageBox.Show(i.ToString() + " khách hàng đã xử lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
            }
        }

        private void cboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal TOID = decimal.Parse(cboTo.SelectedValue.ToString());
                if (TOID != 0)
                {
                    // dm nhan vien
                    List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
                    var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Where(x => x.NHANVIEN.TO_ID == TOID).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.maNV, x.NHANVIEN.TO_ID }).OrderBy(x => x.tenNV).ToList();
                    dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả", TO_ID = -1 });
                    foreach (var item in nhanvien)
                    {
                        dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.tenNV, TO_ID = item.TO_ID });
                    }
                    cboNV.DataSource = dmNhanVien.ToList();
                    cboNV.ValueMember = "NV_ID";
                    cboNV.DisplayMember = "hoten";
                    cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                }
                else
                {
                    List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
                    var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.maNV }).OrderBy(x => x.tenNV).ToList();
                    dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
                    foreach (var item in nhanvien)
                    {
                        dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.tenNV });
                    }
                    cboNV.DataSource = dmNhanVien.ToList();
                    cboNV.ValueMember = "NV_ID";
                    cboNV.DisplayMember = "hoten";
                    cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                };
            }
            catch
            {
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            DateTime tungay = dateTimePicker1.Value.Date;
            DateTime denngay = dateTimePicker2.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            var dataSource = db.THU_HO.Where(x => x.ngay_thanh_toan >= tungay && x.ngay_thanh_toan <= denngay).OrderByDescending(x => x.ngay_thanh_toan).ToList();
            int TOID = int.Parse(cboTo.SelectedValue.ToString());
            int NVID = int.Parse(cboNV.SelectedValue.ToString());
            if (NVID != 0)
            {
                dataSource = dataSource.Where(x => x.nv_thu == cboNV.Text).ToList();
            }
            if (txtimdanhbo.Text != "")
            {
                dataSource = dataSource.Where(x => x.so_db.Contains(txtimdanhbo.Text)).ToList();
            }
            if (cboTT.Text != "Tất cả")
            {
                if (cboTT.Text == "Chưa xử lý")
                    dataSource = dataSource.Where(x => x.trang_thai == null).ToList();
                else
                    dataSource = dataSource.Where(x => x.trang_thai != null).ToList();
            }
            table = ExcelExportHelper.ListToDataTable(dataSource);
            dataGridView1.DataSource = table;
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i + 1;
            lblsoluong.Text = "Số lượng: " + string.Format("{0:n0}", dataSource.ToList().Count());
        }

        private void frDongBoThuHoApp_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            List<DM_TO> dmTO = new List<DM_TO>();
            var to = db.DM_TO.OrderBy(x => x.TENTO).ToList();
            dmTO.Add(new DM_TO() { TO_ID = 0, TENTO = "Tất cả" });
            dmTO.AddRange(to);
            cboTo.DataSource = dmTO.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
            cboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // dm nhan vien
            List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
            var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.maNV }).OrderBy(x => x.tenNV).ToList();
            dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
            foreach (var item in nhanvien)
            {
                dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.tenNV });
            }
            cboNV.DataSource = dmNhanVien.ToList();
            cboNV.ValueMember = "NV_ID";
            cboNV.DisplayMember = "hoten";
            cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            string[] dsTrangthai = { "Tất cả", "Chưa xử lý", "Đã xử lý" };
            cboTT.DataSource = dsTrangthai;
            cboTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}