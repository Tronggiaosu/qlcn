using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcGachNoKeToan : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcGachNoKeToan()
        {
            InitializeComponent();
            cboTO.SelectedIndexChanged += cboTO_SelectedIndexChanged;
            btnTim.Click += btnTim_Click;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            btnQuit.Click += btnQuit_Click;
            btnExcel.Click += btnExcel_Click;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Common.ExportExcel(dataGridView1);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 9)
                    {
                        string trangthai = dataGridView1.CurrentRow.Cells[checkColumn.Name].Value.ToString();
                        if (trangthai == "Chưa nộp")
                        {
                            DialogResult rs = MessageBox.Show("Xác nhận nhân viên đã nộp đủ số tiền?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (rs == DialogResult.OK)
                            {
                                string ghichu = dataGridView1.CurrentRow.Cells[ghichuketoanColumn.Name].Value.ToString();
                                decimal IDCT = decimal.Parse(dataGridView1.CurrentRow.Cells[IDCTColumn.Name].Value.ToString());
                                var objChungtu = db.CHUNGTUs.Where(x => x.ID_CT == IDCT).FirstOrDefault();
                                var objNguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                                var objNhanvien = db.NHANVIENs.Where(x => x.NV_ID == objNguoidung.nv_id).FirstOrDefault();
                                objChungtu.user_confirm = int.Parse(objNhanvien.NV_ID.ToString());
                                objChungtu.ghichuketoan = ghichu;
                                objChungtu.danop = true;
                                objChungtu.date_confirm = DateTime.Now;
                                db.SaveChanges();
                                btnTim.PerformClick();
                            }
                        }
                        else
                            MessageBox.Show("Nhân viên đã nộp tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xử lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string tungay = "";
            string denngay = "";
            int TOID = int.Parse(cboTO.SelectedValue.ToString());
            int NVID = int.Parse(cboNV.SelectedValue.ToString());
            int danop = 2;
            string trangthai = cboTrangThai.Text;
            int NVID_confirm = 0;
            if (chkTrangthai.Checked == true)
            {
                if (trangthai == "Đã nộp")
                    danop = 1;
                else
                    danop = 0;
            }
            if (chkNgay.Checked == true)
            {
                tungay = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                denngay = dateTimePicker2.Value.ToString("yyyy/MM/dd");
            }
            if (chkNVConfirm.Checked == true)
                NVID_confirm = int.Parse(cboNVConfirm.SelectedValue.ToString());
            var dataSource = db.getDSBIENNHAN(tungay, denngay, danop, NVID, NVID_confirm, TOID, "").Where(x => x.MALOAI == "TT").ToList();
            if (dataSource.Count > 0) 
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            dataGridView1.DataSource = dataSource.ToList();
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i + 1;
            this.Cursor = Cursors.Default;
        }

        private void cboTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal TOID = decimal.Parse(cboTO.SelectedValue.ToString());
                if (TOID != 0)
                {
                    // dm nhan vien
                    List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
                    var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Where(x => x.NHANVIEN.TO_ID == TOID).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.somay, x.NHANVIEN.TO_ID }).OrderBy(x => x.tenNV).ToList();
                    dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả", TO_ID = -1 });
                    foreach (var item in nhanvien)
                    {
                        dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.somay + " - " + item.tenNV, TO_ID = item.TO_ID });
                    }
                    cboNV.DataSource = dmNhanVien.ToList();
                    cboNV.ValueMember = "NV_ID";
                    cboNV.DisplayMember = "hoten";
                    cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                }
                else
                {
                    List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
                    var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.somay }).OrderBy(x => x.tenNV).ToList();
                    dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
                    foreach (var item in nhanvien)
                    {
                        dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.somay + " - " + item.tenNV });
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

        private void frGachNoKeToan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cboTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_TO> dsTo = new List<DM_TO>();
            dsTo.Add(new DM_TO() { TO_ID = 0, TENTO = "Tất cả" });
            var data = db.DM_TO.OrderBy(X => X.TENTO).ToList();
            dsTo.AddRange(data);
            cboTO.DataSource = dsTo.ToList();
            cboTO.ValueMember = "TO_ID";
            cboTO.DisplayMember = "TENTO";
            dataGridView1.AutoGenerateColumns = false;
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            string[] dsTrangthai = { "Chưa nộp", "Đã nộp" };
            cboTrangThai.DataSource = dsTrangthai;
            cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            var nhanvienketoan = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 5).Select(x => x.NHANVIEN).OrderBy(x => x.hoten).ToList();
            cboNVConfirm.DataSource = nhanvienketoan.ToList();
            cboNVConfirm.ValueMember = "NV_ID";
            cboNVConfirm.DisplayMember = "hoten";
            chkNgay.Checked = true;
        }
    }
}