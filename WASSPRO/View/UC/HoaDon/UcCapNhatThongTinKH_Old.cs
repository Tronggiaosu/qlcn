using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcCapNhatThongTinKH_Old : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcCapNhatThongTinKH_Old()
        {
            InitializeComponent();
            //quitButton.Click += quitButton_Click;
            btnUpdate.Click += btnUpdate_Click;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            //dgvHoaDon.RowEnter += dgvHoaDon_RowEnter;
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;

            //btnDC.Click += btnDC_Click;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.F4):
                    btnUpdate.PerformClick();
                    return true;

                case (Keys.F3):
                    txtTim.Focus();
                    txtTim.SelectAll();
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                    btnTim.PerformClick();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string text = txtTim.Text;
            if (txtTim.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin!");
            }
            else
            {
                // todo mock
                // var IDKH = db.getDanhSachKhachHang(2, "", "", "", text.Replace(" ", String.Empty)).Where(x => x.madanhbo == text).Select(x => x.ID_KH).Distinct().FirstOrDefault();
                var idkh = 1;
                this.Cursor = Cursors.WaitCursor;

                // todo mock
                //var khachhang = db.KHACHHANGs.Where(x => x.ID_KH == IDKH).FirstOrDefault();
                var khachhang = new KHACHHANG
                {
                    ID_KH = 1,
                    madanhbo = "123456",
                    sonha = "123",
                    diachi = "123",
                    hieuHD = "123",
                    hoten_KH = "123",
                    kichcoDH = "123",
                    email = "123",
                    soseri_DH = "123",
                    maLT = "123",
                    MST_KH = "123",
                    SDT_KH = "123",
                    ghichu = "123",
                    isingiaybao = true,
                    nganhang_id = 1,
                    maquan = "1",
                    maphuong = "1",
                    trangthai = 1,
                };
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
                    cboTrangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                // todo mock
                //cboTrangthai.DataSource = db.DM_TRANGTHAI_KH.OrderBy(x => x.tenTT).ToList();
                cboTrangthai.DataSource = new List<DM_TRANGTHAI_KH>
                {
                    new DM_TRANGTHAI_KH { maTT = 1, tenTT = "Active" },
                    new DM_TRANGTHAI_KH { maTT = 2, tenTT = "Inactive" },
                    new DM_TRANGTHAI_KH { maTT = 3, tenTT = "Pending" },
                };
                cboTrangthai.ValueMember = "maTT";
                cboTrangthai.DisplayMember = "tenTT";

                // todo mock
                //cboTTHD.DataSource = db.DM_TRANGTHAIHOADON.Where(x => x.trangthai_id != 2 && x.trangthai_id != 3 && x.trangthai_id != 4 && x.trangthai_id != 5 && x.trangthai_id != 8 && x.trangthai_id != 9 && x.trangthai_id != 10).OrderBy(x => x.Trangthai).ToList();
                cboTTHD.DataSource = new List<DM_TRANGTHAIHOADON>
                {
                    new DM_TRANGTHAIHOADON { trangthai_id = 1, Trangthai = "Paid" },
                    new DM_TRANGTHAIHOADON { trangthai_id = 2, Trangthai = "Unpaid" },
                    new DM_TRANGTHAIHOADON { trangthai_id = 3, Trangthai = "Adjustment" },
                };
                cboTTHD.ValueMember = "trangthai_id";
                cboTTHD.DisplayMember = "Trangthai";
                // quan
                // todo mock
                //cboQuan.DataSource = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
                var ds = new List<DM_QUAN> {
                    new DM_QUAN { maQuan = "1", tenQuan = "District 1" },
                    new DM_QUAN { maQuan = "2", tenQuan = "District 2" },
                };
                cboQuan.DataSource = ds;
                cboQuan.ValueMember = "maQuan";
                cboQuan.DisplayMember = "tenQuan";
                cboQuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cboQuan.SelectedValue = khachhang.maquan;
                //phuong
                // todo mock
                //cboPhuong.DataSource = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
                cboPhuong.DataSource = new List<DM_PHUONG>
                {
                    new DM_PHUONG { maPhuong = "1", tenPhuong = "Phường Linh Trung " },
                    new DM_PHUONG { maPhuong = "2", tenPhuong = "Phường Bình Thọ" },
                };
                cboPhuong.ValueMember = "maPhuong";
                cboPhuong.DisplayMember = "tenPhuong";
                cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                cboPhuong.SelectedValue = khachhang.maphuong;
                // dieu chinh
                // todo mock
                //dgvHoaDon.DataSource = db.getDSHoaDon_KH(IDKH).ToList();
                dgvHoaDon.DataSource = MockGriddata();
                this.Cursor = Cursors.Default;
            }
        }

        private List<getDSHoaDon_KH_Result> MockGriddata()
        {
            var mockData = new List<getDSHoaDon_KH_Result>
            {
            new getDSHoaDon_KH_Result
            {
                ID_HD = 1,
                hoten = "Nguyen Van A",
                kyghi = "2023-01",
                nam = 2023,
                ID_KH = 1001,
                DOT_ID = 1,
                quan = "District 1",
                phuong = "Ward 5",
                hotenNV = "Tran Thi B",
                SO_HD = "INV12345",
                KY_HIEU_HD = "AB-01",
                tentrangthai = "Paid",
                chitiet = "Detail 1",
                chuyendoi = "Converted",
                dongbo = "Synchronized",
                thanhtoan = "Yes",
                ngaythanhtoan = DateTime.Now.AddDays(-2),
                tongtien = 1000000,
                trangthai_id = 1,
                seri = "SER123",
                MaLT = "MT123",
                NGAYDANGNGAN_NV = DateTime.Now.AddDays(-5),
                ghichu = "Note 1",
                trangthaiKH = "Active",
                dieuchinh = "Adjustment 1",
                ngaytao = DateTime.Now.AddDays(-10),
                NgaycapnhatKH = DateTime.Now.AddDays(-3),
                NhanviencapnhatKH = "Le Van C",
                trangthaiKHHD = "Updated"
            },
            new getDSHoaDon_KH_Result
            {
                ID_HD = 2,
                hoten = "Le Thi C",
                kyghi = "2023-02",
                nam = 2023,
                ID_KH = 1002,
                DOT_ID = 2,
                quan = "District 2",
                phuong = "Ward 7",
                hotenNV = "Pham Van D",
                SO_HD = "INV12346",
                KY_HIEU_HD = "AB-02",
                tentrangthai = "Unpaid",
                chitiet = "Detail 2",
                chuyendoi = "Pending",
                dongbo = "Not Synchronized",
                thanhtoan = "No",
                ngaythanhtoan = null,
                tongtien = 2000000,
                trangthai_id = 2,
                seri = "SER124",
                MaLT = "MT124",
                NGAYDANGNGAN_NV = DateTime.Now.AddDays(-8),
                ghichu = "Note 2",
                trangthaiKH = "Inactive",
                dieuchinh = "Adjustment 2",
                ngaytao = DateTime.Now.AddDays(-12),
                NgaycapnhatKH = DateTime.Now.AddDays(-4),
                NhanviencapnhatKH = "Le Thi E",
                trangthaiKHHD = "Not Updated"
            },
            new getDSHoaDon_KH_Result
            {
                ID_HD = 3,
                hoten = "Tran Van B",
                kyghi = "2023-03",
                nam = 2023,
                ID_KH = 1003,
                DOT_ID = 3,
                quan = "District 3",
                phuong = "Ward 9",
                hotenNV = "Nguyen Thi F",
                SO_HD = "INV12347",
                KY_HIEU_HD = "AB-03",
                tentrangthai = "Adjustment",
                chitiet = "Detail 3",
                chuyendoi = "Converted",
                dongbo = "Synchronized",
                thanhtoan = "Yes",
                ngaythanhtoan = DateTime.Now.AddDays(-3),
                tongtien = 3000000,
                trangthai_id = 3,
                seri = "SER125",
                MaLT = "MT125",
                NGAYDANGNGAN_NV = DateTime.Now.AddDays(-6),
                ghichu = "Note 3",
                trangthaiKH = "Pending",
                dieuchinh = "Adjustment 3",
                ngaytao = DateTime.Now.AddDays(-11),
                NgaycapnhatKH = DateTime.Now.AddDays(-2),
                NhanviencapnhatKH = "Le Van G",
                trangthaiKHHD = "Updated"
            },
            new getDSHoaDon_KH_Result
            {
                ID_HD = 4,
                hoten = "Pham Van D",
                kyghi = "2023-04",
                nam = 2023,
                ID_KH = 1004,
                DOT_ID = 4,
                quan = "District 4",
                phuong = "Ward 11",
                hotenNV = "Le Van H",
                SO_HD = "INV12348",
                KY_HIEU_HD = "AB-04",
                tentrangthai = "Paid",
                chitiet = "Detail 4",
                chuyendoi = "Pending",
                dongbo = "Not Synchronized",
                thanhtoan = "No",
                ngaythanhtoan = null,
                tongtien = 4000000,
                trangthai_id = 4,
                seri = "SER126",
                MaLT = "MT126",
                NGAYDANGNGAN_NV = DateTime.Now.AddDays(-7),
                ghichu = "Note 4",
                trangthaiKH = "Active",
                dieuchinh = "Adjustment 4",
                ngaytao = DateTime.Now.AddDays(-13),
                NgaycapnhatKH = DateTime.Now.AddDays(-5),
                NhanviencapnhatKH = "Le Thi I",
                trangthaiKHHD = "Not Updated"
            },
            new getDSHoaDon_KH_Result
            {
                ID_HD = 5,
                hoten = "Nguyen Van E",
                kyghi = "2023-05",
                nam = 2023,
                ID_KH = 1005,
                DOT_ID = 5,
                quan = "District 5",
                phuong = "Ward 13",
                hotenNV = "Tran Thi K",
                SO_HD = "INV12349",
                KY_HIEU_HD = "AB-05",
                tentrangthai = "Unpaid",
                chitiet = "Detail 5",
                chuyendoi = "Converted",
                dongbo = "Synchronized",
                thanhtoan = "Yes",
                ngaythanhtoan = DateTime.Now.AddDays(-4),
                tongtien = 5000000,
                trangthai_id = 5,
                seri = "SER127",
                MaLT = "MT127",
                NGAYDANGNGAN_NV = DateTime.Now.AddDays(-9),
                ghichu = "Note 5",
                trangthaiKH = "Inactive",
                dieuchinh = "Adjustment 5",
                ngaytao = DateTime.Now.AddDays(-14),
                NgaycapnhatKH = DateTime.Now.AddDays(-6),
                NhanviencapnhatKH = "Le Van L",
                trangthaiKHHD = "Updated"
            },
            new getDSHoaDon_KH_Result
            {
                ID_HD = 6,
                hoten = "Le Thi F",
                kyghi = "2023-06",
                nam = 2023,
                ID_KH = 1006,
                DOT_ID = 6,
                quan = "District 6",
                phuong = "Ward 15",
                hotenNV = "Pham Van M",
                SO_HD = "INV12350",
                KY_HIEU_HD = "AB-06",
                tentrangthai = "Paid",
                chitiet = "Detail 6",
                chuyendoi = "Pending",
                dongbo = "Not Synchronized",
                thanhtoan = "No",
                ngaythanhtoan = null,
                tongtien = 6000000,
                trangthai_id = 6,
                seri = "SER128",
                MaLT = "MT128",
                NGAYDANGNGAN_NV = DateTime.Now.AddDays(-10),
                ghichu = "Note 6",
                trangthaiKH = "Active",
                dieuchinh = "Adjustment 6",
                ngaytao = DateTime.Now.AddDays(-15),
                NgaycapnhatKH = DateTime.Now.AddDays(-7),
                NhanviencapnhatKH = "Le Thi N",
                trangthaiKHHD = "Not Updated"
            },
        };
            return mockData;
        }

        private void dgvHoaDon_RowEnter(object sender, DataGridViewCellEventArgs e)
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
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

        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var maQuan = cboQuan.SelectedValue.ToString();
                if (maQuan != "0")
                {
                    // dm phuong
                    cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    //dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });

                    // todo mock
                    //var dataPhuong = db.DM_PHUONG.Where(x => x.maQuan == maQuan).OrderBy(x => x.tenPhuong).ToList();
                    var dataPhuong = new List<DM_PHUONG>
                    {
                        new DM_PHUONG { maPhuong = "1", tenPhuong = "Ward 1" },
                        new DM_PHUONG { maPhuong = "2", tenPhuong = "Ward 2" },
                    };
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
                else
                {
                    cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    //dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                    //var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
                    var dataPhuong = new List<DM_PHUONG>
                    {
                        new DM_PHUONG { maPhuong = "1", tenPhuong = "Ward 1" },
                        new DM_PHUONG { maPhuong = "2", tenPhuong = "Ward 2" },
                    };
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
            //try
            //{
            DialogResult rs = MessageBox.Show("Bạn có muôn cập nhật thông tin khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
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
                bd.nvid = int.Parse(db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault().nv_id.ToString());
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

        private void quitButton_Click(object sender, EventArgs e)
        {
            //this.Close();
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