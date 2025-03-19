using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.LoTrinhThu
{
    public partial class UcCapNhatLT : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcCapNhatLT()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            btnThoat.Click += btnThoat_Click;
            cboTo.SelectedIndexChanged += cboTo_SelectedIndexChanged;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            btnThem.Click += btnThem_Click;
            btnEX.Click += btnEX_Click;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            btncapnhatTT.Click += btncapnhatTT_Click;
        }

        private void btncapnhatTT_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkTT.Checked == true)
                {
                    DialogResult rs = MessageBox.Show("Bạn có cập nhật trạng thái cho những nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        foreach (DataGridViewRow r in dataGridView1.Rows)
                        {
                            DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checkTTColumn.Name];
                            var thu = checks.Value;
                            if (Convert.ToBoolean(thu) == true)
                            {
                                var ID = decimal.Parse(dataGridView1[IDColumn.Name, r.Index].Value.ToString());
                                var nhanvienHD = db.NHANVIEN_HOADON.Where(x => x.ID == ID).FirstOrDefault();
                                if (nhanvienHD != null)
                                {
                                    bool trangthaiNV = false;
                                    if (cboTrangthai.Text == "Hoạt động")
                                        trangthaiNV = true;
                                    nhanvienHD.TRANGTHAI = trangthaiNV;
                                    db.SaveChanges();
                                }
                            }
                        }
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnTim.PerformClick();
                    }
                }
            }
            catch
            {
            }

            //for (int i = 0; i< dataGridView1.RowCount; i++)
            //{
            //    decimal ID = decimal.Parse(dataGridView1.Rows[i].Cells[IDColumn.Name].Value.ToString());
            //    var nhanvienHD = db.NHANVIEN_HOADON.Where(x => x.ID == ID).FirstOrDefault();
            //    int tuso = int.Parse(dataGridView1.Rows[i].Cells[tultColumn.Name].Value.ToString());
            //    int denso = int.Parse(dataGridView1.Rows[i].Cells[denLTColumn.Name].Value.ToString());
            //    string gioDB = dataGridView1.Rows[i].Cells[gioBDColumn.Name].Value.ToString();
            //    string gioKT = dataGridView1.Rows[i].Cells[gioKTColumn.Name].Value.ToString();
            //    bool t7 = bool.Parse(dataGridView1.Rows[i].Cells[thut7Column.Name].Value.ToString());
            //    bool cn = bool.Parse(dataGridView1.Rows[i].Cells[ThuCNColumn.Name].Value.ToString());
            //    string trangthai = dataGridView1.Rows[i].Cells[trangthaiColumn.Name].Value.ToString();
            //    decimal DOTID = decimal.Parse(dataGridView1.Rows[i].Cells[tendotColumn.Name].Value.ToString());
            //    decimal NVID = decimal.Parse(dataGridView1.Rows[i].Cells[hotenColumn.Name].Value.ToString());
            //    var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
            //    bool trangthaiLT = false;
            //    if (trangthai == "Hoạt động")
            //        trangthaiLT = true;
            //    if (tuso == 0 || denso == 0)
            //        MessageBox.Show("Chưa nhập khoảng lộ trình");
            //    else if (gioDB == "" || gioKT == "")
            //        MessageBox.Show("Chưa nhập giờ bắt đầu hoặc giờ kết thúc");
            //    else
            //    {
            //        var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
            //        LOG_USER log = new LOG_USER();
            //        log.nguoidung_id = nguoidung.nguoidung_id;
            //        log.ngay_sd = DateTime.Now;
            //        log.ghichu = "doi lo trinh nhan vien " + nhanvienHD.NV_ID.ToString() + " " + nhanvienHD.TuLT.ToString() + " den " + nhanvienHD.DenLT.ToString();
            //        db.LOG_USER.Add(log);
            //        db.SaveChanges();
            //        db.DeleteLoTrinhThu(nhanvienHD.ID);
            //        nhanvienHD.TuLT = tuso;
            //        nhanvienHD.DenLT = denso;
            //        nhanvienHD.GIOBD = gioDB;
            //        nhanvienHD.GIOKT = gioKT;
            //        nhanvienHD.T7 = t7;
            //        nhanvienHD.CN = cn;
            //        nhanvienHD.TRANGTHAI = trangthaiLT;
            //        nhanvienHD.NV_ID = NVID;
            //        nhanvienHD.DOT_ID = DOTID;
            //        nhanvienHD.USER_UPDATE = NVLap.nv_id;
            //        nhanvienHD.DATE_UPDATE = DateTime.Now;
            //        db.SaveChanges();
            //        db.UpdateLoTrinhThu(nhanvienHD.ID);
            //        //foreach (DataGridViewRow row in dataGridView1.Rows)
            //        //{
            //        //    if (decimal.Parse(row.Cells[IDColumn.Name].Value.ToString()).Equals(ID))
            //        //    {
            //        //        row.Selected = true;
            //        //        break;
            //        //    }
            //        //}
            //}
            //}
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Cells[checkTTColumn.Name].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Cells[checkTTColumn.Name].Value = false;
                }
            }
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int TOID = int.Parse(cboTo.SelectedValue.ToString());
            int DOTID = int.Parse(cboDot.SelectedValue.ToString());
            decimal NVID = decimal.Parse(cboNV.SelectedValue.ToString());
            var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
            if (TOID == 0)
                TOID = 1;
            if (DOTID == 0)
                DOTID = 1;
            var nhanvien = db.NHANVIENs.Where(x => x.TO_ID == TOID).FirstOrDefault();
            NHANVIEN_HOADON nhanvienHD = new NHANVIEN_HOADON();
            nhanvienHD.CUON_GCS = "";
            nhanvienHD.NV_ID = NVID == 0 ? nhanvien.NV_ID : NVID;
            nhanvienHD.GIOBD = "07:00";
            nhanvienHD.GIOKT = "15:00";
            nhanvienHD.TuLT = 0;
            nhanvienHD.DenLT = 0;
            nhanvienHD.DATE_UPDATE = DateTime.Now;
            nhanvienHD.USER_UPDATE = Common.NVID;
            nhanvienHD.TRANGTHAI = false;
            nhanvienHD.DATE_CREATE = DateTime.Now;
            nhanvienHD.DOT_ID = DOTID;
            nhanvienHD.USER_CREATE = NVLap.nv_id;
            db.NHANVIEN_HOADON.Add(nhanvienHD);
            db.SaveChanges();
            var data = db.getPhanQuyenLoTrinh(TOID, DOTID, NVID).OrderBy(x => x.DOT_ID).OrderBy(x => x.CUON_GCS).ToList();
            dataGridView1.DataSource = data.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //try
                //{
                if (e.ColumnIndex == 13)
                {
                    decimal ID = decimal.Parse(dataGridView1.SelectedRows[0].Cells[IDColumn.Name].Value.ToString());
                    var nhanvienHD = db.NHANVIEN_HOADON.Where(x => x.ID == ID).FirstOrDefault();
                    DialogResult rs = MessageBox.Show("Có cập nhật  khoảng lộ trình này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        int tuso = int.Parse(dataGridView1.CurrentRow.Cells[tultColumn.Name].Value.ToString());
                        int denso = int.Parse(dataGridView1.CurrentRow.Cells[denLTColumn.Name].Value.ToString());
                        string gioDB = dataGridView1.CurrentRow.Cells[gioBDColumn.Name].Value.ToString();
                        string gioKT = dataGridView1.CurrentRow.Cells[gioKTColumn.Name].Value.ToString();
                        bool t7 = bool.Parse(dataGridView1.CurrentRow.Cells[thut7Column.Name].Value.ToString());
                        bool cn = bool.Parse(dataGridView1.CurrentRow.Cells[ThuCNColumn.Name].Value.ToString());
                        string trangthai = dataGridView1.CurrentRow.Cells[trangthaiColumn.Name].Value.ToString();
                        decimal DOTID = decimal.Parse(dataGridView1.CurrentRow.Cells[tendotColumn.Name].Value.ToString());
                        decimal NVID = decimal.Parse(dataGridView1.CurrentRow.Cells[hotenColumn.Name].Value.ToString());
                        var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                        bool trangthaiLT = false;
                        if (trangthai == "Hoạt động")
                            trangthaiLT = true;
                        if (tuso == 0 || denso == 0)
                            MessageBox.Show("Chưa nhập khoảng lộ trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else if (gioDB == "" || gioKT == "")
                            MessageBox.Show("Chưa nhập giờ bắt đầu hoặc giờ kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            db.PublishedInvoices.Where(x => x.IDNhanvienHD == nhanvienHD.ID).ToList().ForEach(x => x.IDNhanvienHD = null);
                            db.NHANVIEN_HOADON.Remove(nhanvienHD);
                            int PdOTID = int.Parse(DOTID.ToString());
                            int pNVID = int.Parse(NVID.ToString());
                            NHANVIEN_HOADON objNhanvienHD = new NHANVIEN_HOADON();
                            objNhanvienHD.CUON_GCS = "";
                            objNhanvienHD.NV_ID = NVID;
                            objNhanvienHD.GIOBD = gioDB;
                            objNhanvienHD.GIOKT = gioKT;
                            objNhanvienHD.T7 = t7;
                            objNhanvienHD.TuLT = tuso;
                            objNhanvienHD.DenLT = denso;
                            objNhanvienHD.CN = cn;
                            objNhanvienHD.TRANGTHAI = trangthaiLT;
                            objNhanvienHD.DATE_CREATE = DateTime.Now;
                            objNhanvienHD.DOT_ID = DOTID;
                            objNhanvienHD.USER_CREATE = NVLap.nv_id;
                            db.NHANVIEN_HOADON.Add(objNhanvienHD);
                            db.SaveChanges();
                            db.Update_chiakhachhangchonhanvien(pNVID, PdOTID, objNhanvienHD.ID, tuso, denso);
                            var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                            LOG_USER log = new LOG_USER();
                            log.nguoidung_id = nguoidung.nguoidung_id;
                            log.ngay_sd = DateTime.Now;
                            log.ghichu = "doi lo trinh nhan vien " + nhanvienHD.NV_ID.ToString() + " " + nhanvienHD.TuLT.ToString() + " den " + nhanvienHD.DenLT.ToString();
                            db.LOG_USER.Add(log);
                            db.SaveChanges();
                            //db.DeleteLoTrinhThu(nhanvienHD.ID);
                            //db.UpdateLoTrinhThu(nhanvienHD.ID);
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnTim.PerformClick();
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (decimal.Parse(row.Cells[IDColumn.Name].Value.ToString()).Equals(ID))
                                {
                                    row.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == 14)
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn xóa khoảng lộ trình này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        decimal ID = decimal.Parse(dataGridView1.SelectedRows[0].Cells[IDColumn.Name].Value.ToString());
                        var nhanvienHD = db.NHANVIEN_HOADON.Where(x => x.ID == ID).FirstOrDefault();
                        if (nhanvienHD.TRANGTHAI == true)
                        {
                            MessageBox.Show("Trạng thái đang hoạt động, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                            LOG_USER log = new LOG_USER();
                            log.nguoidung_id = nguoidung.nguoidung_id;
                            log.ngay_sd = DateTime.Now;
                            log.ghichu = "doi lo trinh nhan vien " + nhanvienHD.NV_ID.ToString() + " " + nhanvienHD.TuLT.ToString() + " den " + nhanvienHD.DenLT.ToString();
                            db.LOG_USER.Add(log);
                            db.SaveChanges();
                            db.DeleteLoTrinhThu(nhanvienHD.ID);
                            db.NHANVIEN_HOADON.Remove(nhanvienHD);
                            db.SaveChanges();
                            btnTim.PerformClick();
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                //}
                //catch
                //{
                //    MessageBox.Show("Có lỗi trong quá trình lấy dữ liệu!");
                //}
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //    this.Close();
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
                        dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.maNV + " - " + item.tenNV, TO_ID = item.TO_ID });
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
                        dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.maNV + " - " + item.tenNV });
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            int TOID = int.Parse(cboTo.SelectedValue.ToString());
            int DOTID = int.Parse(cboDot.SelectedValue.ToString());
            decimal NVID = decimal.Parse(cboNV.SelectedValue.ToString());
            var data = db.getPhanQuyenLoTrinh(TOID, DOTID, NVID).OrderBy(x => x.DOT_ID).OrderBy(x => x.CUON_GCS).ToList();
            bool trangthaiNV = false;
            if (cboTrangthai.Text == "Hoạt động")
                trangthaiNV = true;
            if (chkTT.Checked == true)
                data = data.Where(x => x.TRANGTHAI == trangthaiNV).ToList();
            dataGridView1.DataSource = data.OrderBy(x => x.TENDOT).OrderBy(x => x.hoten).ToList();
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)dataGridView1.Columns[tendotColumn.Name];
            combo.DataPropertyName = "dot_id";
            combo.DataSource = db.DM_DOT.ToList();
            combo.ValueMember = "dot_id";
            combo.DisplayMember = "tendot"; // I also suspect this should be a text column
            DataGridViewComboBoxColumn comboTrangthai = (DataGridViewComboBoxColumn)dataGridView1.Columns[trangthaiColumn.Name];
            string[] trangthai = { "Khóa", "Hoạt động" };
            comboTrangthai.DataPropertyName = "tendot";
            comboTrangthai.DataSource = trangthai;
            DataGridViewComboBoxColumn comboNhanvien = (DataGridViewComboBoxColumn)dataGridView1.Columns[hotenColumn.Name];

            var dataNhanvien = db.NHANVIENs.ToList();
            //if (TOID != 0)
            //    dataNhanvien = dataNhanvien.Where(x => x.TO_ID == TOID).ToList();
            comboNhanvien.DataPropertyName = "NV_ID";
            comboNhanvien.DataSource = dataNhanvien.Select(x => new { x.NV_ID, hoten = x.somay + " - " + x.hoten }).ToList();
            comboNhanvien.ValueMember = "NV_ID";
            comboNhanvien.DisplayMember = "hoten"; // I also suspect this should be a text co
        }

        private void frCapNhatLT_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            // dm to
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
                dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.maNV + " - " + item.tenNV });
            }
            cboNV.DataSource = dmNhanVien.ToList();
            cboNV.ValueMember = "NV_ID";
            cboNV.DisplayMember = "hoten";
            cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // dm dot
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
            //colbox.DataSource = db.DM_DOT.OrderBy(x=>x.TENDOT).ToList();
            //colbox.ValueMember = "DOT_ID";
            //colbox.DisplayMember = "TENDOT";
            //colbox.HeaderText = "Đợt";
            //colbox.Name = "DOTIDColumn";
            //dataGridView1.Columns.Add(colbox);
            cboTrangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            string[] s = { "Hoạt động", "Khóa" };
            cboTrangthai.DataSource = s;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}