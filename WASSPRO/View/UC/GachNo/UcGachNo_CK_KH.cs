using QLCongNo.View.UC.HoaDon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcGachNo_CK_KH : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DataTable dt = new DataTable();
        private DataColumn column;
        private DataRow row;
        private List<HOADON> dataHoaDon = new List<HOADON>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 100;
        private decimal ID_KH;

        public UcGachNo_CK_KH()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            //dgvHoadon.DoubleClick += dgvCT_DoubleClick;
            btnConfirm.Click += btnConfirm_Click;
            //btnPrevious.Click += btnPrevious_Click;
            //btnNext.Click += btnNext_Click;
            //btnFirst.Click += btnFisrt_Click;
            //btnLast.Click += btnLast_Click;
            this.dgvHoadon.DataError += dgvHoadon_DataError;
            this.dgvHoadon.CellFormatting += dgvHoadon_CellFormatting;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            dgvHoadon.CellContentClick += dgvHoadon_CellContentClick;
        }
        private void dgvHoadon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoadon.Columns[e.ColumnIndex].Name == "thangColumn")
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
            if (dgvHoadon.Columns[e.ColumnIndex].Name == "namColumn")
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
        private void dgvHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHoadon.RowCount > 0)
                {
                    var senderGrid = (DataGridView)sender;
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        decimal IDHD = decimal.Parse(dgvHoadon.Rows[e.RowIndex].Cells[ID_HDColumn2.Name].Value.ToString());
                        if (e.ColumnIndex == 11)
                        {
                            Portal.PortalService portal = new Portal.PortalService();
                            var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                            var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            var hoadonloi = db.HOADONs.Where(x => x.ID_KH == hoadon.ID_KH && x.trangthai_id == -22).FirstOrDefault();
                            var hoadonsai = db.HOADONs.Where(x => x.ID_HD == IDHD && x.DOT_ID == 1 && x.kyghi == "202302" && x.keys == null).FirstOrDefault();
                            if (hoadonloi != null)
                                IDHD = hoadonloi.ID_HD;
                            var result = portal.getInvViewFkeyNoPay(IDHD.ToString(), accWS.acc_service, "123456aA@");
                            portal78.PortalService p78 = new portal78.PortalService();
                            if (hoadonsai != null)
                                result = p78.getInvViewFkeyNoPay(hoadonsai.DienGiai, "capnuocthuducservice", "Einv@oi@vn#pt20");
                            else if (hoadon.MAU_HD == "1/001" || hoadon.MAU_HD == "1/002" || hoadon.MAU_HD == "1/003")
                                result = p78.getInvViewFkeyNoPay(IDHD.ToString(), "capnuocthuducservice", "Einv@oi@vn#pt20");
                            var frm = new Form();
                            frm.Size = new System.Drawing.Size(1200, 800);
                            WebBrowser webBrowser = new WebBrowser();
                            webBrowser.Dock = DockStyle.Fill;
                            webBrowser.DocumentText = result;
                            frm.Controls.Add(webBrowser);
                            frm.ShowDialog();
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch
            {
            }
        }

        private void dgvHoadon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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
                    dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                    var dataPhuong = db.DM_PHUONG.Where(x => x.maQuan == maQuan).OrderBy(x => x.tenPhuong).ToList();
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
                else
                {
                    cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
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
        private void dgvKhachhang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhachhang.RowCount > 0)
                {
                    ID_KH = decimal.Parse(dgvKhachhang[IDKHColumn.Name, e.RowIndex].Value.ToString());
                    var dsHoadon = (from a in db.HOADONs
                                    join ky in db.DM_KYGHI on a.kyghi equals ky.ID_kyghi
                                    join pb in db.PublishedInvoices on a.ID_HD equals pb.IDHD into pbJoin
                                    from pb in pbJoin.DefaultIfEmpty()
                                    join kh in db.KHACHHANGs on a.ID_KH equals kh.ID_KH into khJoin
                                    from kh in khJoin.DefaultIfEmpty()
                                    join tt in db.DM_TRANGTHAI_KH on kh.trangthai equals tt.maTT into ttJoin
                                    from tt in ttJoin.DefaultIfEmpty()
                                    join c in db.GACHNOes on a.ID_HD equals c.ID_HD into cJoin
                                    from c in cJoin.DefaultIfEmpty()
                                    join nh in db.DM_NGANHANG on c.NV_ID_NOP equals nh.NGANHANG_ID into nhJoin
                                    from nh in nhJoin.DefaultIfEmpty()
                                    join nvtq in db.NHANVIENs on c.USER_CREATE equals nvtq.NV_ID into nvJoin
                                    from nvtq in nvJoin.DefaultIfEmpty()
                                    join dn in db.DANGNGANs on a.ID_HD equals dn.ID_HD into dnJoin
                                    from dn in dnJoin.DefaultIfEmpty()
                                    join cthd in db.CHUNGTU_HOADON on a.ID_HD equals cthd.ID_HD into cthdJoin
                                    from cthd in cthdJoin.DefaultIfEmpty()
                                    join ct in db.CHUNGTUs on cthd.ID_CT equals ct.ID_CT into ctJoin
                                    from ct in ctJoin.DefaultIfEmpty()
                                    where a.ID_KH == ID_KH && a.trangthai_id != 0 && a.trangthai_id != 9 && a.IsInHD == true
                                    orderby ky.ngaytao descending
                                    select new HoaDonDTO
                                    {
                                        ID_HD = a.ID_HD,
                                        hoten = a.hoten,
                                        kyghi = ky.ten_kyghi,
                                        nam = a.nam,
                                        ID_KH = a.ID_KH,
                                        DOT_ID = a.DOT_ID,
                                        thanhtoan = (pb.GACH_NO == "0" || pb.GACH_NO == null) ? "Chưa thu" : "Đã thu",
                                        hotenNV = (pb.GACH_NO != "0" && pb.GACH_NO != null)
                                            ? (pb.NVThu ?? (c.ID_HD != null && (nh.LOAI != null || c.MALOAI == "CK")
                                                ? nh.TENNGANHANG
                                                : (c.MALOAI == "KH" || c.MALOAI == "TC" || c.MALOAI == "GT"
                                                    ? nvtq.hoten
                                                    : null)))
                                            : null,
                                        SO_HD = a.SO_HD,
                                        KY_HIEU_HD = a.KY_HIEU_HD,
                                        tentrangthai = db.DM_TRANGTHAIHOADON.FirstOrDefault(tthd => tthd.trangthai_id == a.trangthai_id).Trangthai,
                                        chitiet = "Chi tiết",
                                        ngaythanhtoan = (pb.GACH_NO != "0" && pb.GACH_NO != null)
                                            ? (pb.Ngaythutienapp ?? c.NGAYTHANHTOAN ?? a.ngaythanhtoan)
                                            : null,
                                        tongtien = a.tongtien,
                                        trangthai_id = a.trangthai_id,
                                        seri = a.KY_HIEU_HD + " " + a.SO_HD,
                                        MaLT = a.MaLT,
                                        ghichu = (pb.GACH_NO != "0" && pb.GACH_NO != null) ? (ct.GHICHU) : null,
                                        trangthaiKH = ((pb.GACH_NO == "0" || pb.GACH_NO == null) && a.trangthai_id != 2) ? tt.tenTT : "",
                                        dieuchinh = a.ghichu,
                                        ngaytao = ky.ngaytao,
                                        NgaycapnhatKH = a.NgaycapnhatKH,
                                        ngayBK = (pb.GACH_NO != "0" && pb.GACH_NO != null)
                                            ? (ct.NGAYLAP < new DateTime(2019, 12, 19)
                                                ? (c.ID_HD != null && c.PRODUCTS != null
                                                    ? c.NGAYTHANHTOAN
                                                    : ct.NGAYCT)
                                                : ct.NGAYCT)
                                            : null,
                                        NGAYDANGNGAN_NV = (pb.GACH_NO != "0" && pb.GACH_NO != null && dn.IsDangNgan == true)
                                            ? dn.NGAYDANGNGAN_NV
                                            : null,
                                        NVID_CREATE_HOTEN = (pb.GACH_NO != "0" && pb.GACH_NO != null) ? nvtq.hoten : null, 
                                        maloai = (pb.GACH_NO != "0" && pb.GACH_NO != null)
                                            ? (c.MALOAI == "Ngân hàng" || c.MALOAI == "CK"
                                                ? "Chuyển khoản"
                                                : (c.MALOAI == "Pay Service"
                                                    ? "Thu hộ"
                                                    : "Tại quầy"))
                                            : null,
                                    }).ToList();
                    foreach (var item in dsHoadon)
                    {
                        item.ngaythanhtoanFormatted = item.ngaythanhtoan?.ToString("dd/MM/yyyy");
                        item.ngayBKFormatted = item.ngayBK?.ToString("dd/MM/yyyy");
                        item.NGAYDANGNGAN_NVFormatted = item.NGAYDANGNGAN_NV?.ToString("dd/MM/yyyy");
                    }

                    txtTongthu.Text = string.Format("{0:n0}", dsHoadon.Select(x => x.tongtien).Sum());
                    txttong_HD.Text = dsHoadon.Count().ToString();

                    if (dsHoadon.Count() > 0)
                        dgvHoadon.DataSource = dsHoadon.OrderByDescending(X => X.ngaytao).ToList();
                    else
                        dgvHoadon.DataSource = null;

                    for (int i = 0; i < dgvHoadon.RowCount; i++)
                    {
                        if (dgvHoadon.Rows[i].Cells[trangthaiHDColumn.Name].Value.ToString() == "Đã thu" || dgvHoadon.Rows[i].Cells[trangthaiHDColumn.Name].Value.ToString() == "Hủy")
                        {
                            dgvHoadon.Rows[i].ReadOnly = true;
                            dgvHoadon.Rows[i].Cells[checksColumn.Name].Value = false;
                        }
                    }
                }
                else
                {
                    dgvHoadon.DataSource = null;
                }
            }
            catch
            {
                // Handle exceptions if necessary
            }
        }


        private void btnLast_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = TotalPage;
            GetCurrentRecords(CurrentPageIndex, dataHoaDon);
            //lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
        }

        private void btnFisrt_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            GetCurrentRecords(CurrentPageIndex, dataHoaDon);
            //lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                GetCurrentRecords(this.CurrentPageIndex, dataHoaDon);
                //lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                GetCurrentRecords(this.CurrentPageIndex, dataHoaDon);
                //lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            }
        }

        private void GetCurrentRecords(int page, List<HOADON> dataHoaDon)
        {
            var dataSource = dataHoaDon.ToList();

            if (page == 1)
                dataSource = dataSource.Take(PgSize).ToList();
            else
            {
                int PreviousPageOffSet = (page - 1) * PgSize;
                dataSource = (from kh in dataHoaDon
                              where !(dataHoaDon.Take(PreviousPageOffSet).Select(x => x.ID_KH)).Contains(kh.ID_KH)
                              select kh).Take(PgSize).ToList();
            }
            dgvKhachhang.DataSource = dataSource.OrderBy(x => x.SO_HD).ToList();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvHoadon.RowCount == 0)
            {
                MessageBox.Show("Không có hóa đơn nào trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvHoadon.RowCount > 0)
            {
                DialogResult rs = MessageBox.Show("Có xác nhận thanh toán hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    var kyghi = db.DM_KYGHI.Where(x => x.gachno == true).FirstOrDefault();
                    var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                    decimal NganHangID = decimal.Parse(cboNganHangThu.SelectedValue.ToString());
                    decimal? tongtienCT = 0;
                    // add chung tu
                    CHUNGTU chungtu = new CHUNGTU();
                    chungtu.ID_KYGHI = kyghi.ID_kyghi;
                    chungtu.MALOAI = "CK";
                    chungtu.NGAYLAP = DateTime.Now;
                    chungtu.NV_ID_LAP = NVLap.nv_id;
                    chungtu.NV_ID_NOP = NganHangID;
                    chungtu.GHICHU = txtghichu.Text;
                    chungtu.TRANGTHAI = false;
                    chungtu.SOCT = SO_CT_tutang();
                    chungtu.TONGTIEN = 0;
                    db.CHUNGTUs.Add(chungtu);
                    db.SaveChanges();
                    // add gach no
                    var IDCT_Nhanvien = db.CHUNGTUs.Where(x => x.NV_ID_LAP == NVLap.nv_id).Max(x => x.ID_CT);
                    List<GACHNO> dsGachno = new List<GACHNO>();
                    List<CHUNGTU_HOADON> DSchungtuHD = new List<CHUNGTU_HOADON>();
                    foreach (DataGridViewRow r in dgvHoadon.Rows)
                    {
                        decimal IDHD = decimal.Parse(dgvHoadon[ID_HDColumn.Name, r.Index].Value.ToString());
                        var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        var dmPhieuthu = db.dm_phieu_thu.Where(x => x.FKEY == IDHD.ToString()).FirstOrDefault();
                        if (dmPhieuthu == null)
                        {
                            tongtienCT += hoadon.tongtien;
                            // add ds gach no
                            dsGachno.Add(new GACHNO()
                            {
                                ID_HD = hoadon.ID_HD,
                                ID_KH = hoadon.ID_KH,
                                DOT_ID = hoadon.DOT_ID,
                                ID_KYGHI = hoadon.kyghi,
                                KYHIEU = hoadon.KY_HIEU_HD,
                                MALOAI = "CK",
                                MALT = hoadon.MaLT,
                                MAUSO = hoadon.MAU_HD,
                                NGAYTHANHTOAN = DateTime.Now,
                                NV_ID_NOP = hoadon.ID_KH,
                                SOHD = hoadon.SO_HD,
                                TIENTHUE_GTGT = hoadon.tienvat,
                                TONGTIENBVMT = hoadon.tienBVMT,
                                TONGTIEN = hoadon.tongtien0VAT,
                                TONGTHANHTOAN = hoadon.tongtien,
                                NAM_ID = hoadon.nam,
                                USER_CREATE = NVLap.nv_id,
                                DATE_CREATE = DateTime.Now,
                                STATUS = false,
                            });
                            // add ds chung tu hoa don
                            DSchungtuHD.Add(new CHUNGTU_HOADON()
                            {
                                ID_CT = IDCT_Nhanvien,
                                ID_HD = hoadon.ID_HD,
                                ID_KH = hoadon.ID_KH,
                                ID_Kyghi = hoadon.kyghi,
                                Nam = hoadon.nam,
                                NGAYTAO = DateTime.Now,
                                NGAYTHU = DateTime.Now,
                                NVID_CREATE = NVLap.nv_id,
                                NVID_THU = NVLap.nv_id,
                                TONGTIEN = hoadon.tongtien,
                                DADONGBO = false,
                                DOT_ID = hoadon.DOT_ID
                            });
                            // update hoa don, publish
                            hoadon.gachno = true;
                            hoadon.ngaythanhtoan = dtpNgaythu.Value;
                            var published = db.PublishedInvoices.Where(x => x.KEY == IDHD.ToString()).FirstOrDefault();
                            published.GACH_NO = "1";
                            db.SaveChanges();
                        }
                    }
                    db.GACHNOes.AddRange(dsGachno);
                    db.CHUNGTU_HOADON.AddRange(DSchungtuHD);
                    var chungtuGachNo = db.CHUNGTUs.Where(x => x.ID_CT == IDCT_Nhanvien).FirstOrDefault();
                    chungtuGachNo.TONGTIEN = tongtienCT;
                    db.SaveChanges();
                    MessageBox.Show("Xác nhận thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTim.PerformClick();
                    dgvKhachhang.DataSource = null;
                    dgvHoadon.DataSource = null;
                    txtghichu.Text = "";
                    txtTongthu.Text = "0";
                    txttong_HD.Text = "0";
                    this.Cursor = Cursors.Default;
                    if (dgvKhachhang.SelectedRows.Count > 0)
                    {
                        int rowIndex = dgvKhachhang.SelectedRows[0].Index;
                        var eRowEvent = new DataGridViewCellEventArgs(0, rowIndex);
                        dgvKhachhang_RowEnter(sender, eRowEvent);
                    }
                }
            }
        }

        private void dgvCT_DoubleClick(object sender, EventArgs e)
        {
        }

        private void dgvHD_DoubleClick(object sender, EventArgs e)
        {
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            if (dgvHoadon.RowCount == 0)
            {
                MessageBox.Show("Không có hóa đơn nào trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult rs = MessageBox.Show("Bạn có lưu file excel? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
                Common.ExportExcel(dgvHoadon);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnTim.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text != "")
            {
                this.Cursor = Cursors.WaitCursor;
                string maPhuong = cboPhuong.SelectedValue.ToString();
                string maQuan = cboQuan.SelectedValue.ToString();
                string strSearch = txtTim.Text;
                var khachhang = db.getDanhSachKhachHang(2, maQuan, maPhuong, "0", (strSearch.Replace(" ", String.Empty)).ToUpper()).Distinct().ToList();
                if(khachhang.Count > 0 )
                {
                    dgvKhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }    
                dgvKhachhang.DataSource = khachhang.Distinct().OrderBy(x => x.madanhbo).ToList();
                if (khachhang.Count == 0)
                    dgvHoadon.DataSource = null;
            }
            else
                MessageBox.Show("Chưa nhập thông tin Mã danh bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Cursor = Cursors.Default;
        }


        private void frGachNo_CK_KH_Load(object sender, EventArgs e)
        {
            dgvKhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachhang.AutoGenerateColumns = false;
            dgvHoadon.AutoGenerateColumns = false;
            // dm phuong
            cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
            dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
            var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
            dsPhuong.AddRange(dataPhuong);
            cboPhuong.DataSource = dsPhuong.ToList();
            cboPhuong.ValueMember = "maPhuong";
            cboPhuong.DisplayMember = "tenPhuong";
            // dm quan
            cboQuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_QUAN> dsQuan = new List<DM_QUAN>();
            dsQuan.Add(new DM_QUAN() { maQuan = "0", tenQuan = "Tất cả" });
            var dataQuan = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
            dsQuan.AddRange(dataQuan);
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            // dm ngan hang thu
            cboNganHangThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboNganHangThu.DataSource = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList(); ;
            cboNganHangThu.ValueMember = "NGANHANG_ID";
            cboNganHangThu.DisplayMember = "TENNGANHANG";
            dtpNgaythu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgaythu.CustomFormat = "dd/MM/yyyy";

            //btnFirst.Visible = false;
            //btnPrevious.Visible = false;
            //btnLast.Visible = false;
            //btnNext.Visible = false;
            //lblPage.Visible = false;
            btnHuy.Visible = false;
        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);
            return dTable;
        }

        public void createTable()
        {
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID_KH";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ID_HD";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "tongtien";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "hoten_KH";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "madanhbo";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "ten_kyghi";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "diachi";
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "maLT";
            dt.Columns.Add(column);
        }

        public void createRows()
        {
        }

        public void sumInvoice()
        {
            int j = 0;
            decimal tongthanhtoan = 0;
            //string ghichu_id = "";
            for (int i = 0; i < dgvHoadon.RowCount; i++)
            {
                j++;
                tongthanhtoan += decimal.Parse(dgvHoadon.Rows[i].Cells[tongtienColumn.Name].Value.ToString());
                //if (ghichu_id == "")
                //    ghichu_id = dgvCT.Rows[i].Cells[ID_KH.Name].Value.ToString();
                //else
                //{
                //    if (ghichu_id.IndexOf(dgvCT.Rows[i].Cells[ID_KH.Name].Value.ToString()) == -1)
                //        ghichu_id = ghichu_id + ", " + dgvCT.Rows[i].Cells[ID_KH.Name].Value.ToString();
                //}
            }
            txtTongthu.Text = string.Format("{0:n0}", tongthanhtoan);
            txttong_HD.Text = j.ToString();
            //txtghichu.Text = ghichu_id;
        }

        public string SO_CT_tutang()
        {
            string kyghi_gn = db.DM_KYGHI.Where(x => x.gachno == true).FirstOrDefault().ID_kyghi;
            string maxid = db.CHUNGTUs.Where(x => x.ID_KYGHI == kyghi_gn).Select(x => x.SOCT).Max();
            if (maxid == null)
                maxid = "0";
            string filtered = Regex.Replace(maxid, "[A-Za-z]", "");
            long id = Convert.ToInt32(filtered);
            id++;
            string strid = id.ToString("0000") + "CK";
            return strid;
        }

        public class HoaDonDTO
        {
            public decimal ID_HD { get; set; }
            public string hoten { get; set; }
            public string kyghi { get; set; }
            public int? nam { get; set; }
            public decimal? ID_KH { get; set; }
            public decimal? DOT_ID { get; set; }
            public string hotenNV { get; set; }
            public string SO_HD { get; set; }
            public string KY_HIEU_HD { get; set; }
            public string tentrangthai { get; set; }
            public string chitiet { get; set; }
            public string thanhtoan { get; set; }
            public DateTime? ngaythanhtoan { get; set; }
            public decimal? tongtien { get; set; }
            public decimal? trangthai_id { get; set; }
            public string seri { get; set; }
            public string MaLT { get; set; }
            public string ghichu { get; set; }
            public string trangthaiKH { get; set; }
            public string dieuchinh { get; set; }
            public DateTime ngaytao { get; set; }
            public DateTime? NgaycapnhatKH { get; set; }
            public DateTime? ngayBK { get; set; }
            public DateTime? NGAYDANGNGAN_NV { get; set; }
            public string NVID_CREATE_HOTEN { get; set; }
            public string maloai { get; set; }
            public string ngaythanhtoanFormatted { get; set; }
            public string ngayBKFormatted { get; set; }
            public string NGAYDANGNGAN_NVFormatted { get; set; }
        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }
    }
}