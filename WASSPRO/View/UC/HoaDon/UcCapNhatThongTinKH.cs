using QLCongNo.View.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcCapNhatThongTinKH : NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcCapNhatThongTinKH()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            btnUpdate.Click += btnUpdate_Click;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            this.dgvKhachHang.DataError += dgvKhachHang_DataError;
            this.dgvKhachHang.CellFormatting += dgvKhachHang_CellFormatting;
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnTim.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void dgvKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhachHang.Columns[e.ColumnIndex].Name == "kyhd_dgv2")
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
            if (dgvKhachHang.Columns[e.ColumnIndex].Name == "Nhanviencapnhat")
            {
                if (e.Value != null)
                {
                    string somay = e.Value.ToString();
                    var nhanvien = db.NHANVIENs.FirstOrDefault(nv => nv.somay == somay);
                    if (nhanvien != null)
                    {
                        e.Value = nhanvien?.hoten;
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dgvKhachHang_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maDanhBo = txtTim.Text.Trim();
            if (string.IsNullOrEmpty(maDanhBo))
            {
                MessageBox.Show("Chưa nhập thông tin mã danh bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (maDanhBo.Length != 11)
            {
                MessageBox.Show("Thông tin tìm kiếm chưa chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == maDanhBo).FirstOrDefault();

                if (khachhang == null)
                {
                    MessageBox.Show($"Không tìm thấy khách hàng có mã danh bộ này {maDanhBo}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    return;
                }
                txtDanhBo.Text = khachhang.madanhbo;
                txtSonha.Text = khachhang.sonha;
                txtdiachi.Text = khachhang.diachi;
                txthieuDH.Text = khachhang.hieuHD;
                txthoten.Text = khachhang.hoten_KH;
                txtkichco.Text = khachhang.kichcoDH;
                txtmail.Text = khachhang.email;
                txtseriDH.Text = khachhang.soseri_DH;
                txtMLT.Text = khachhang.maLT;
                txtMST.Text = khachhang.MST_KH;
                txtSDT.Text = khachhang.SDT_KH;
                txtghichu.Text = khachhang.ghichu;

                txtDanhBo.Enabled = true;
                txtDanhBo.BackColor = Color.White;
                txtMLT.Enabled = true;
                txtMLT.BackColor = Color.White;
                cboQuan.Enabled = true;
                cboQuan.BackColor = Color.White;
                cboPhuong.Enabled = true;
                cboPhuong.BackColor = Color.White;
                txtSonha.Enabled = true;
                txtSonha.BackColor = Color.White;
                txtdiachi.Enabled = true;
                txtdiachi.BackColor = Color.White;
                txthoten.Enabled = true;
                txthoten.BackColor = Color.White;
                txtMST.Enabled = true;
                txtMST.BackColor = Color.White;
                txtSDT.Enabled = true;
                txtSDT.BackColor = Color.White;
                txtmail.Enabled = true;
                txtmail.BackColor = Color.White;
                txtseriDH.Enabled = true;
                txtseriDH.BackColor = Color.White;
                txthieuDH.Enabled = true;
                txthieuDH.BackColor = Color.White;
                txtkichco.Enabled = true;
                txtkichco.BackColor = Color.White;
                cboTrangthai.Enabled = true;
                cboTrangthai.BackColor = Color.White;
                cboTTHD.Enabled = true;
                cboTTHD.BackColor = Color.White;
                txtghichu.Enabled = true;
                txtghichu.BackColor = Color.White;

                chkGB.Checked = false;
                if (khachhang.isingiaybao == true)
                    chkGB.Checked = true;
                if (khachhang.nganhang_id != null || khachhang.nganhang_id != 0)
                    //cboNganHang.Text = khachhang.DM_NGANHANG.TENNGANHANG;
                    // trang thai
                    cboTrangthai.DropDownStyle = ComboBoxStyle.DropDownList;
                cboTrangthai.DataSource = db.DM_TRANGTHAI_KH.OrderBy(x => x.tenTT).ToList();
                cboTrangthai.ValueMember = "maTT";
                cboTrangthai.DisplayMember = "tenTT";

                cboTTHD.DataSource = db.DM_TRANGTHAIHOADON.Where(x => x.trangthai_id != 2 && x.trangthai_id != 3 && x.trangthai_id != 4 && x.trangthai_id != 5 && x.trangthai_id != 8 && x.trangthai_id != 9 && x.trangthai_id != 10).OrderBy(x => x.Trangthai).ToList();
                cboTTHD.ValueMember = "trangthai_id";
                cboTTHD.DisplayMember = "Trangthai";
                // quan
                cboQuan.DataSource = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
                cboQuan.ValueMember = "maQuan";
                cboQuan.DisplayMember = "tenQuan";
                cboQuan.DropDownStyle = ComboBoxStyle.DropDownList;
                cboQuan.SelectedValue = khachhang.maquan;
                //phuong
                cboPhuong.DataSource = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
                cboPhuong.ValueMember = "maPhuong";
                cboPhuong.DisplayMember = "tenPhuong";
                cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
                cboPhuong.SelectedValue = khachhang.maphuong;
                // dieu chinh
                var listKH = db.getDSHoaDon_KH(khachhang.ID_KH).ToList();
                if(listKH.Count > 0)
                {
                    dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                dgvKhachHang.DataSource = listKH;
                this.Cursor = Cursors.Default;
            }
        }

        private void dgvHoaDon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhachHang.RowCount > 0)
                {
                    for (int i = 0; i < dgvKhachHang.RowCount; i++)
                    {
                        if (dgvKhachHang.Rows[i].Cells[thanhtoanColumn.Name].Value.ToString() == "Đã thu"
                            || dgvKhachHang.Rows[i].Cells[trangthaiColumn.Name].Value.ToString() == "Hủy")
                        {
                            dgvKhachHang.Rows[i].ReadOnly = true;
                            dgvKhachHang.Rows[i].Cells[chkColumn.Name].Value = false;
                        }
                        else
                        {
                            dgvKhachHang.Rows[i].ReadOnly = false;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                foreach (DataGridViewRow r in dgvKhachHang.Rows)
                {
                    r.Cells[chkColumn.Name].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow r in dgvKhachHang.Rows)
                {
                    r.Cells[chkColumn.Name].Value = false;
                }
            }
        }

        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var maQuan = cboQuan.SelectedValue.ToString();
                if (maQuan != "0")
                {
                    // dm phuong
                    cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    //dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                    var dataPhuong = db.DM_PHUONG.Where(x => x.maQuan == maQuan).OrderBy(x => x.tenPhuong).ToList();
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
                else
                {
                    cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    //dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                    var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
            }
            catch
            {
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvKhachHang.Rows.Count == 0)
                {
                    MessageBox.Show("Danh sách không có khách hàng nào để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }    
                DialogResult rs = MessageBox.Show("Bạn có muốn cập nhật thông tin khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string maDanhBo = txtTim.Text.Trim();
                    var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                    // update khach hang
                    int trangthaiID = int.Parse(cboTrangthai.SelectedValue.ToString());
                    int trangthaiIDHD = int.Parse(cboTTHD.SelectedValue.ToString());
                    var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == maDanhBo).FirstOrDefault();
                    // add bien dong
                    BD_KHACHHANG bd = new BD_KHACHHANG();
                    bd.ID_KH = khachhang?.ID_KH;
                    bd.ngaycapnhat = DateTime.Now;
                    bd.hoten_KH = khachhang?.hoten_KH;
                    bd.nvid = int.Parse(db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault().nv_id.ToString());
                    bd.diachi = khachhang?.diachi;
                    bd.sonha = khachhang?.sonha;
                    bd.hieuDH = khachhang?.hieuHD;
                    bd.trangthai = khachhang?.trangthai;
                    bd.nguoilapdat = Common.username;
                    //bd.kichcoDH = khachhang.hieuHD;
                    bd.maphuong = khachhang?.maphuong;
                    bd.madanhbo = khachhang?.madanhbo;
                    db.BD_KHACHHANG.Add(bd);
                    db.SaveChanges();
                    khachhang.email = txtmail.Text;
                    bool giaybao = false;
                    if (chkGB.Checked == true)
                        giaybao = true;
                    khachhang.diachi = txtdiachi.Text;
                    khachhang.email = txtmail.Text;
                    khachhang.MST_KH = txtMST.Text;
                    khachhang.sonha = txtSonha.Text;
                    khachhang.SDT_KH = txtSDT.Text;
                    khachhang.soseri_DH = txtseriDH.Text;
                    khachhang.isingiaybao = giaybao;
                    khachhang.hieuHD = txthieuDH.Text;
                    khachhang.kichcoDH = txtkichco.Text;
                    khachhang.hoten_KH = txthoten.Text;
                    khachhang.ViTri_LD = cboTrangthai.Text;
                    khachhang.ghichu = txtghichu.Text;
                    db.SaveChanges();
                    if (chkTT.Checked == true)
                    {
                        khachhang.ngaycapnhat = DateTime.Now;
                        khachhang.nguoitao = Common.username;
                        khachhang.trangthai = trangthaiID;
                        db.SaveChanges();

                        //var nhanvien = db.NHANVIENs.FirstOrDefault(nv => nv.somay == Common.username);
                        //string hotenNV = nhanvien?.hoten;
                        //MessageBox.Show(hotenNV);
                        foreach (DataGridViewRow r in dgvKhachHang.Rows)
                        {
                            DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                            var thu = checks.Value;
                            if (Convert.ToBoolean(thu) == true)
                            {
                                decimal IDHD = decimal.Parse(dgvKhachHang[id_hd_dgv2.Name, r.Index].Value.ToString());
                                var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                                hoadon.trangthaiKH = trangthaiID;
                                hoadon.NgaycapnhatKH = DateTime.Now;
                                hoadon.NhanviencapnhatKH = Common.username;
                                db.SaveChanges();
                            }
                        }
                    }
                    if (chkTTHD.Checked == true)
                    {
                        foreach (DataGridViewRow r in dgvKhachHang.Rows)
                        {
                            DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                            var thu = checks.Value;
                            if (Convert.ToBoolean(thu) == true)
                            {
                                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                                decimal IDHD = decimal.Parse(dgvKhachHang[id_hd_dgv2.Name, r.Index].Value.ToString());
                                var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD && x.trangthai_id != 2).FirstOrDefault();
                                var pb = db.PublishedInvoices.Where(x => x.IDHD == IDHD && (x.GACH_NO == "0" || x.GACH_NO == null)).FirstOrDefault();
                                if (hoadon != null && pb != null)
                                {
                                    hoadon.ma_HTTT = trangthaiID;
                                    hoadon.date_update = DateTime.Now;
                                    hoadon.user_update = nguoidung.nv_id;
                                    db.SaveChanges();
                                    // KHOA NUOC
                                    if (trangthaiIDHD == 15)
                                    {
                                        hoadon.iskhoanuoc = true;
                                        hoadon.ngaykhoanuoc = DateTime.Now;
                                        db.SaveChanges();
                                        frCapNhatThongTinKH_Load(null, EventArgs.Empty);
                                    }
                                    // MO NUOC
                                    if (trangthaiIDHD == 1)
                                    {
                                        string[] dsHoaDon = db.HOADONs.Where(x => x.ID_HD == IDHD).Select(x => x.ID_HD.ToString()).ToArray();
                                        object[] reseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashkey, Common.username, hoadon.DANHBO, dsHoaDon, "1", txtghichu.Text).ToArray();
                                        string result1 = reseult[0].ToString().ToUpper();
                                        if (result1 == "TRUE")
                                        {
                                            // update trang thai app
                                            var publisedinvocie = db.PublishedInvoices.Where(x => x.IDHD == hoadon.ID_HD).FirstOrDefault();
                                            if (publisedinvocie != null)
                                            {
                                                publisedinvocie.STATUS = null;
                                                publisedinvocie.isKhodoi = false;
                                                db.SaveChanges();
                                            }
                                            if ((hoadon.trangthai_id == 11 || hoadon.trangthai_id == 12) && hoadon.tienuoc_dc < 0)
                                            {
                                                hoadon.tienphi_dc = hoadon.tienphi_dc * -1;
                                                hoadon.tienuoc_dc = hoadon.tienuoc_dc * -1;
                                                hoadon.tienthue_dc = hoadon.tienthue_dc * -1;
                                            }
                                            // trang thai hoa don
                                            hoadon.trangthai_id = 1;
                                            hoadon.trangthaiKH = 1;
                                            hoadon.NgaycapnhatKH = DateTime.Now;
                                            hoadon.NhanviencapnhatKH = Common.username;
                                            hoadon.iskhoanuoc = false;
                                            db.SaveChanges();
                                            frCapNhatThongTinKH_Load(null, EventArgs.Empty);
                                        }
                                    }
                                    // hoa don tra cham
                                    if (trangthaiIDHD == 11)
                                    {
                                        // goi ws thu ho
                                        string[] dsHoaDon = db.HOADONs.Where(x => x.ID_HD == IDHD).Select(x => x.ID_HD.ToString()).ToArray();
                                        object[] reseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashkey, Common.username, hoadon.DANHBO, dsHoaDon, "11", txtghichu.Text).ToArray();
                                        string result1 = reseult[0].ToString().ToUpper();
                                        if (result1 == "TRUE")
                                        {
                                            if (hoadon.trangthai_id == 3)
                                            {
                                                hoadon.tienphi_dc = hoadon.tienphi_dc * -1;
                                                hoadon.tienuoc_dc = hoadon.tienuoc_dc * -1;
                                                hoadon.tienthue_dc = hoadon.tienthue_dc * -1;
                                            }
                                            // update trang thai app
                                            var publisedinvocie = db.PublishedInvoices.Where(x => x.IDHD == hoadon.ID_HD).FirstOrDefault();
                                            if (publisedinvocie != null)
                                            {
                                                publisedinvocie.STATUS = "2";
                                                publisedinvocie.isKhodoi = true;
                                                db.SaveChanges();
                                            }
                                            // trang thai hoa don
                                            hoadon.trangthai_id = 11;
                                            hoadon.NgaycapnhatKH = DateTime.Now;
                                            hoadon.NhanviencapnhatKH = Common.username;
                                            db.SaveChanges();
                                        }
                                        else
                                            MessageBox.Show("Có lỗi khi cập nhật trạng thái! Mã lỗi: " + reseult[0].ToString().ToUpper() + reseult[3].ToString().ToUpper(),
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    // hoa don khieu nai
                                    if (trangthaiIDHD == 14)
                                    {
                                        // goi ws thu ho
                                        string[] dsHoaDon = db.HOADONs.Where(x => x.ID_HD == IDHD).Select(x => x.ID_HD.ToString()).ToArray();
                                        object[] reseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashkey, Common.username, hoadon.DANHBO, dsHoaDon, "14", txtghichu.Text).ToArray();
                                        string result1 = reseult[0].ToString().ToUpper();
                                        if (result1 == "TRUE")
                                        {
                                            if (hoadon.trangthai_id == 3)
                                            {
                                                hoadon.tienphi_dc = hoadon.tienphi_dc * -1;
                                                hoadon.tienuoc_dc = hoadon.tienuoc_dc * -1;
                                                hoadon.tienthue_dc = hoadon.tienthue_dc * -1;
                                            }
                                            // update trang thai app
                                            var publisedinvocie = db.PublishedInvoices.Where(x => x.IDHD == hoadon.ID_HD).FirstOrDefault();
                                            if (publisedinvocie != null)
                                            {
                                                publisedinvocie.STATUS = "2";
                                                publisedinvocie.isKhodoi = true;
                                                db.SaveChanges();
                                            }
                                            // trang thai hoa don
                                            hoadon.trangthai_id = 14;
                                            hoadon.trangthaiKH = 14;
                                            hoadon.NgaycapnhatKH = DateTime.Now;
                                            hoadon.NhanviencapnhatKH = Common.username;
                                            db.SaveChanges();
                                        }
                                        else
                                            MessageBox.Show("Có lỗi khi cập nhật trạng thái! Mã lỗi: " + reseult[0].ToString().ToUpper() + reseult[3].ToString().ToUpper(),
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    // hoa don giai toa
                                    else if (trangthaiIDHD == 12)
                                    {
                                        string[] dsHoaDon = db.HOADONs.Where(x => x.ID_HD == IDHD).Select(x => x.ID_HD.ToString()).ToArray();
                                        object[] reseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashkey, Common.username, hoadon.DANHBO, dsHoaDon, "12", txtghichu.Text).ToArray();
                                        string result1 = reseult[0].ToString().ToUpper();
                                        if (result1 == "TRUE")
                                        {
                                            if (hoadon.trangthai_id == 3)
                                            {
                                                hoadon.tienphi_dc = hoadon.tienphi_dc * -1;
                                                hoadon.tienuoc_dc = hoadon.tienuoc_dc * -1;
                                                hoadon.tienthue_dc = hoadon.tienthue_dc * -1;
                                            }
                                            //hoadon.trangthai_id = 12;
                                            // update trang thai app
                                            var publisedinvocie = db.PublishedInvoices.Where(x => x.IDHD == hoadon.ID_HD).FirstOrDefault();
                                            if (publisedinvocie != null)
                                            {
                                                publisedinvocie.STATUS = "2";
                                                publisedinvocie.isKhodoi = true;
                                                db.SaveChanges();
                                            }
                                            // trang thai hoa don
                                            hoadon.trangthai_id = 12;
                                            hoadon.trangthaiKH = 12;
                                            hoadon.NgaycapnhatKH = DateTime.Now;
                                            hoadon.NhanviencapnhatKH = Common.username;
                                            db.SaveChanges();
                                        }
                                        else
                                            MessageBox.Show("Có lỗi khi cập nhật trạng thái! Mã lỗi: " + reseult[0].ToString().ToUpper() + reseult[3].ToString().ToUpper(),
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    // hoa don kho doi
                                    else if (trangthaiIDHD == 13)
                                    {
                                        string[] dsHoaDon = db.HOADONs.Where(x => x.ID_HD == IDHD).Select(x => x.ID_HD.ToString()).ToArray();
                                        object[] reseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashkey, Common.username, hoadon.DANHBO, dsHoaDon, "13", txtghichu.Text).ToArray();
                                        string result1 = reseult[0].ToString().ToUpper();
                                        if (result1 == "TRUE")
                                        {
                                            hoadon.trangthai_id = 13;
                                            hoadon.isKhoDoi = true;
                                            hoadon.ngaychuyenno = DateTime.Now;
                                            var hoadonKD = db.HOADON_KHODOI.Where(x => x.ID_HD == hoadon.ID_HD).FirstOrDefault();
                                            if (hoadonKD == null)
                                            {
                                                HOADON_KHODOI Kd = new HOADON_KHODOI();
                                                Kd.ID_HD = hoadon.ID_HD;
                                                Kd.ID_KH = hoadon.ID_KH;
                                                Kd.NGAYCHUYEN = DateTime.Now;
                                                Kd.NGUOICHUYEN = int.Parse(nguoidung.nv_id.ToString());
                                                db.HOADON_KHODOI.Add(Kd);
                                                db.SaveChanges();
                                            }
                                            var publisedinvocie = db.PublishedInvoices.Where(x => x.IDHD == hoadon.ID_HD).FirstOrDefault();
                                            if (publisedinvocie != null)
                                            {
                                                publisedinvocie.STATUS = "2";
                                                publisedinvocie.isKhodoi = true;
                                                db.SaveChanges();
                                            }
                                            khachhang.ghichu = txtghichu.Text;
                                            khachhang.trangthai = trangthaiID;
                                            hoadon.trangthaiKH = 13;
                                            hoadon.NgaycapnhatKH = DateTime.Now;
                                            hoadon.NhanviencapnhatKH = Common.username;
                                            db.SaveChanges();
                                        }
                                        else
                                            MessageBox.Show("Có lỗi khi cập nhật trạng thái! Mã lỗi: " + reseult[0].ToString().ToUpper() + reseult[3].ToString().ToUpper(),
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTim.PerformClick();
                    db.SaveChanges();
                    if (chkTT.Checked == true)
                    {
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            catch
            {
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
        }

        private void frCapNhatThongTinKH_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvKhachHang.AutoGenerateColumns = false;
            txtDanhBo.Enabled = false;
            txtDanhBo.BackColor = Color.LightGray;
            txtMLT.Enabled = false;
            txtMLT.BackColor = Color.LightGray;
            cboQuan.Enabled = false;
            cboQuan.BackColor = Color.LightGray;
            cboPhuong.Enabled = false;
            cboPhuong.BackColor = Color.LightGray;
            txtSonha.Enabled = false;
            txtSonha.BackColor = Color.LightGray;
            txtdiachi.Enabled = false;
            txtdiachi.BackColor = Color.LightGray;
            txthoten.Enabled = false;
            txthoten.BackColor = Color.LightGray;
            txtMST.Enabled = false;
            txtMST.BackColor = Color.LightGray;
            txtSDT.Enabled = false;
            txtSDT.BackColor = Color.LightGray;
            txtmail.Enabled = false;
            txtmail.BackColor = Color.LightGray;
            txtseriDH.Enabled = false;
            txtseriDH.BackColor = Color.LightGray;
            txthieuDH.Enabled = false;
            txthieuDH.BackColor = Color.LightGray;
            txtkichco.Enabled = false;
            txtkichco.BackColor = Color.LightGray;
            cboTrangthai.Enabled = false;
            cboTrangthai.BackColor = Color.LightGray;
            cboTTHD.Enabled = false;
            cboTTHD.BackColor = Color.LightGray;
            txtghichu.Enabled = false;
            txtghichu.BackColor = Color.LightGray;
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {
        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}