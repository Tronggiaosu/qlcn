using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.HoaDon
{
    public partial class frCapNhatThongTinKH : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frCapNhatThongTinKH()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            btnUpdate.Click += btnUpdate_Click;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            //dgvHoaDon.RowEnter += dgvHoaDon_RowEnter;
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            //btnDC.Click += btnDC_Click;
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                    btnTim.PerformClick();
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            string text = txtTim.Text;
            if (txtTim.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin!");
            }
            else
            {
                var IDKH = db.getDanhSachKhachHang(2, "", "", "", text.Replace(" ", String.Empty)).Where(x => x.madanhbo == text).Select(x => x.ID_KH).Distinct().FirstOrDefault();
                this.Cursor = Cursors.WaitCursor;
                var khachhang = db.KHACHHANGs.Where(x => x.ID_KH == IDKH).FirstOrDefault();
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
                txtMLT.Enabled = false;
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

                cboTTHD.DataSource = db.DM_TRANGTHAIHOADON.Where(x=>x.trangthai_id != 2 && x.trangthai_id != 3 && x.trangthai_id != 4 && x.trangthai_id!= 5&& x.trangthai_id !=8 && x.trangthai_id !=9 && x.trangthai_id!= 10).OrderBy(x => x.Trangthai).ToList();
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
                dgvHoaDon.DataSource = db.getDSHoaDon_KH(IDKH).ToList();
                this.Cursor = Cursors.Default;

            }
        }
        void dgvHoaDon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHoaDon.RowCount > 0)
                {
                    for (int i = 0; i < dgvHoaDon.RowCount; i++)
                    {
                        if (dgvHoaDon.Rows[i].Cells[thanhtoanColumn.Name].Value.ToString() == "Đã thu"
                            || dgvHoaDon.Rows[i].Cells[trangthaiColumn.Name].Value.ToString() == "Hủy")
                        {
                            dgvHoaDon.Rows[i].ReadOnly = true;
                            dgvHoaDon.Rows[i].Cells[chkColumn.Name].Value = false;
                        }
                        else
                        {
                            dgvHoaDon.Rows[i].ReadOnly = false;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {

                foreach (DataGridViewRow r in dgvHoaDon.Rows)
                {
                    r.Cells[chkColumn.Name].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow r in dgvHoaDon.Rows)
                {
                    r.Cells[chkColumn.Name].Value = false;
                }
            }
        }

        void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
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

        void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{

                DialogResult rs = MessageBox.Show("Bạn có muôn cập nhật thông tin khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    var nguoidung = db.NGUOIDUNGs.Where(x=>x.ma_nd == Common.username).FirstOrDefault();
                    // update khach hang
                    int trangthaiID = int.Parse(cboTrangthai.SelectedValue.ToString());
                    int trangthaiIDHD = int.Parse(cboTTHD.SelectedValue.ToString());
                    var IDKH = db.getDanhSachKhachHang(2, "", "", "", txtTim.Text.Replace(" ", String.Empty)).Where(x => x.madanhbo == txtTim.Text).Select(x => x.ID_KH).Distinct().FirstOrDefault();
                    var khachhang = db.KHACHHANGs.Where(x => x.ID_KH == IDKH).FirstOrDefault();
                    // add bien dong
                    BD_KHACHHANG bd = new BD_KHACHHANG();
                    bd.ID_KH = khachhang.ID_KH;
                    bd.ngaycapnhat = DateTime.Now;
                    bd.hoten_KH = khachhang.hoten_KH;
                    bd.nvid = int.Parse( db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault().nv_id.ToString());
                    bd.diachi = khachhang.diachi;
                    bd.sonha = khachhang.sonha;
                    bd.hieuDH = khachhang.hieuHD;
                    bd.trangthai = khachhang.trangthai;
                    bd.nguoilapdat = Common.username;
                    //bd.kichcoDH = khachhang.hieuHD;
                    bd.maphuong = khachhang.maphuong;
                    bd.madanhbo = khachhang.madanhbo;
                    db.BD_KHACHHANG.Add(bd);
                    db.SaveChanges();
                    khachhang.email = txtmail.Text;
                    bool giaybao = false;
                    if (chkGB.Checked == true)
                        giaybao = true;
                    //khachhang.diachi = txtdiachi.Text;
                    khachhang.email = txtmail.Text;
                    khachhang.MST_KH = txtMST.Text;
                    //khachhang.sonha = txtSonha.Text;
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
                        foreach (DataGridViewRow r in dgvHoaDon.Rows) 
                        {
                            DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                            var thu = checks.Value;
                            if (Convert.ToBoolean(thu) == true)
                            {
                                decimal IDHD = decimal.Parse(dgvHoaDon[id_hd_dgv2.Name, r.Index].Value.ToString());
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
                        foreach (DataGridViewRow r in dgvHoaDon.Rows)
                        {
                            DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                            var thu = checks.Value;
                            if (Convert.ToBoolean(thu) == true)
                            {
                                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                                decimal IDHD = decimal.Parse(dgvHoaDon[id_hd_dgv2.Name, r.Index].Value.ToString());
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
                                            MessageBox.Show("Có lỗi khi cập nhật trạng thái! Mã lỗi: " + reseult[0].ToString().ToUpper() + reseult[3].ToString().ToUpper());
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
                                            MessageBox.Show("Có lỗi khi cập nhật trạng thái! Mã lỗi: " + reseult[0].ToString().ToUpper() + reseult[3].ToString().ToUpper());
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
                                            MessageBox.Show("Có lỗi khi cập nhật trạng thái! Mã lỗi: " + reseult[0].ToString().ToUpper() + reseult[3].ToString().ToUpper());
                                    }
                                    // hoa don kho doi
                                    else if (trangthaiIDHD ==13)
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
                                            MessageBox.Show("Có lỗi khi cập nhật trạng thái! Mã lỗi: " + reseult[0].ToString().ToUpper() + reseult[3].ToString().ToUpper());

                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Cập nhật thành công!");
                    btnTim.PerformClick();   
                    db.SaveChanges();
                    if (chkTT.Checked == true)
                    {
                        
                    }
                    this.Cursor = Cursors.Default;
                }
            //}
            //catch
            //{

            //}
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frCapNhatThongTinKH_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
    }
}
