using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using QLCongNo.View.UC.ReportViewer.BaoCao;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcGachNoKH : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private List<getDanhSachKhachHang_Result> dataHoaDon = new List<getDanhSachKhachHang_Result>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 100;
        public string _maloai;
        public int _trangthai;
        private decimal IDKH;

        public UcGachNoKH(string maloai, long trangthai) : this()
        {
            this._maloai = maloai;
            this._trangthai = (int)trangthai;
        }

        public UcGachNoKH(string maloai) : this()
        {
            this._maloai = maloai;
        }

        public UcGachNoKH()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnEX.Click += btnEX_Click;
            btnTim.Click += btnTim_Click;
            btnConfirm.Click += btnConfirm_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            dgvKhachhang.RowEnter += dgvKhachhang_RowEnter;
            dgvHoadon.SelectionChanged += dgvHoadon_SelectionChanged;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            btnHuy.Click += btnHuy_Click;
            //cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            dgvHoadon.CellContentClick += dgvHoadon_CellContentClick;
            //dgvKhachhang.SelectionChanged += dgvKhachhang_SelectionChanged;

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
                            //var frm = new UcViewInv
                            //{
                            //    html = result
                            //};
                            //new FrmDialog().ShowDialog(frm);
                            var frm = new Form();
                            frm.Size = new Size(1200, 800);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnConfirm.Text = "Lấy dữ liệu";
            for (int i = 0; i < dgvHoadon.RowCount; i++)
            {
                dgvHoadon.Rows[i].Cells[checksColumn.Name].Value = false;
            }
            chkAll.Checked = false;
            txttong_HD.Text = "0";
            txtTongthu.Text = "0";
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {

                foreach (DataGridViewRow r in dgvHoadon.Rows)
                {
                    r.Cells[checksColumn.Name].Value = true;
                    if (r.Cells[trangthaiColumn.Name].Value.ToString() == "Đã thu" || r.Cells[trangthaiHDColumn.Name].Value.ToString() == "Hủy")
                        r.Cells[checksColumn.Name].Value = false;
                }
            }
            else
            {

                foreach (DataGridViewRow r in dgvHoadon.Rows)
                {
                    if (r.Cells[trangthaiColumn.Name].Value.ToString() != "Đã thu" || r.Cells[trangthaiHDColumn.Name].Value.ToString() != "Hủy")
                        r.Cells[checksColumn.Name].Value = false;
                }
            }

            //if (chkAll.Checked == true)
            //{
            //    foreach (DataGridViewRow r in dgvHoadon.Rows)
            //    {
            //        r.Cells[checksColumn.Name].Value = true;
            //        //if (r.Cells[trangthaiColumn.Name].Value.ToString() == "Đã thu" || r.Cells[trangthaiHDColumn.Name].Value.ToString() == "Hủy")
            //        //    r.Cells[checksColumn.Name].Value = false;
            //    }
            //}
            //else
            //{
            //    foreach (DataGridViewRow r in dgvHoadon.Rows)
            //    {
            //        //if (r.Cells[trangthaiColumn.Name].Value.ToString() != "Đã thu" || r.Cells[trangthaiHDColumn.Name].Value.ToString() != "Hủy")
            //        r.Cells[checksColumn.Name].Value = false;
            //    }
            //}
        }

        private void dgvHoadon_SelectionChanged(object sender, EventArgs e)
        {
            txttong_HD.Text = string.Format("{0:n0}", dgvHoadon.SelectedRows.Count);
            decimal tongtienthu = 0;
            for (int i = 0; i < dgvHoadon.SelectedRows.Count; i++)
            {
                tongtienthu += decimal.Parse(dgvHoadon.SelectedRows[i].Cells[tongtien_dgv2.Name].Value.ToString());
            }
            txtTongthu.Text = string.Format("{0:n0}", tongtienthu);
        }

        private void dgvKhachhang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhachhang.RowCount > 0)
                {
                    IDKH = decimal.Parse(dgvKhachhang[IDKHColumn.Name, e.RowIndex].Value.ToString());
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
                                    where a.ID_KH == IDKH && a.trangthai_id != 0 && a.trangthai_id != 9 && a.IsInHD == true
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

                    lbltongno.Text = "Tổng số tiền nợ: " + string.Format("{0:n0}", dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Select(x => x.tongtien).Sum());
                    lbltongsokyno.Text = "Tổng số kỳ nợ: " + dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Count().ToString();

                    if (dsHoadon.Count() > 0)
                    {
                        dgvHoadon.DataSource = dsHoadon.ToList();
                    }      
                    else
                        dgvHoadon.DataSource = null;

                    for (int i = 0; i < dgvHoadon.RowCount; i++)
                    {
                        if (dgvHoadon.Rows[i].Cells[trangthaiColumn.Name].Value.ToString() == "Đã thu" || dgvHoadon.Rows[i].Cells[trangthaiHDColumn.Name].Value.ToString() == "Hủy")
                        {
                            dgvHoadon.Rows[i].ReadOnly = true;
                            dgvHoadon.Rows[i].Cells[checksColumn.Name].Value = false;
                        }
                    }

                    btnConfirm.Text = "Lấy dữ liệu";
                    chkAll.Checked = false;
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //if (dgvHoadon.RowCount > 0)
            //{
            //    if (btnConfirm.Text == "Lấy dữ liệu")
            //    {
            //        decimal? tongtienthu = 0;
            //        int tongso = 0;
            //        foreach (DataGridViewRow r in dgvHoadon.Rows)
            //        {
            //            if (r.Cells[trangthaiColumn.Name].Value.ToString() != "Đã thu")
            //            {
            //                DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checksColumn.Name];
            //                var thu = checks.Value;
            //                if (Convert.ToBoolean(thu) == true)
            //                {
            //                    var IDHD = decimal.Parse(dgvHoadon[ID_HDColumn2.Name, r.Index].Value.ToString());
            //                    var hoadon = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
            //                    if (hoadon != null)
            //                    {
            //                        tongtienthu += hoadon.TONGCONG;
            //                        tongso += 1;
            //                    }
            //                }
            //            }
            //            txtTongthu.Text = string.Format("{0:n0}", tongtienthu);
            //            txttong_HD.Text = tongso.ToString();
            //            if (tongso > 0)
            //                btnConfirm.Text = "Xác nhận thanh toán";
            //        }
            //    }
            //    else if (btnConfirm.Text == "Xác nhận thanh toán" && txttong_HD.Text != "0")
            //    {
            //        try
            //        {
            //            DialogResult rs = MessageBox.Show("Có xác nhận thanh toán hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //            if (rs == DialogResult.OK)
            //            {
            //                this.Cursor = Cursors.WaitCursor;
            //                var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();

            //                foreach(DataGridViewRow row in dgvHoadon.Rows)
            //                {
            //                    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)row.Cells[checksColumn.Name];
            //                    var thu = checks.Value;
            //                    if (Convert.ToBoolean(thu) == true)
            //                    {
            //                        decimal IDHD = decimal.Parse(dgvHoadon[ID_HDColumn2.Name, row.Index].Value.ToString());
            //                        var record = db.HOADON_KHODOI.FirstOrDefault(hdkd => hdkd.ID_HD == IDHD && hdkd.TRANGTHAI == false);
            //                        if (record != null)
            //                        {
            //                            record.TRANGTHAI = true;
            //                            record.NGUOITHANHTOAN = NVLap.NHANVIEN.hoten;
            //                            record.NGAYTHANHTOAN = DateTime.Now;
            //                            record.NGUOIXOANO = (int)NVLap.nv_id;
            //                            record.NGAYXOANO = DateTime.Now;
            //                        }

            //                        var publishedInvoice = db.PublishedInvoices.FirstOrDefault(pub => pub.IDHD == IDHD);
            //                        if(publishedInvoice != null)
            //                        {
            //                            publishedInvoice.GACH_NO = "1";
            //                        }

            //                        var hoaDon = db.HOADONs.FirstOrDefault(hd => hd.ID_HD == IDHD);
            //                        if(hoaDon != null)
            //                        {
            //                            hoaDon.trangthai_id = 10;
            //                            hoaDon.trangthaiKH = 12;
            //                        }    
            //                    }    
            //                }

            //                db.SaveChanges();

            //                txtghichu.Text = "";
            //                txtTongthu.Text = "0";
            //                txttong_HD.Text = "0";
            //                MessageBox.Show("Xác nhận thanh toán thành công!");
            //                this.Cursor = Cursors.Default;

            //                //reload lại danh sách hoá đơn của khách hàng đó
            //                if (dgvKhachhang.SelectedRows.Count > 0)
            //                {
            //                    int rowIndex = dgvKhachhang.SelectedRows[0].Index;
            //                    var eRowEvent = new DataGridViewCellEventArgs(0, rowIndex);
            //                    dgvKhachhang_RowEnter(sender, eRowEvent);
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            this.Cursor = Cursors.Default;
            //            Exception innerEx = ex.InnerException;
            //            while (innerEx != null)
            //            {
            //                MessageBox.Show($"Inner Exception: {innerEx.Message}");
            //                innerEx = innerEx.InnerException;
            //            }
            //            MessageBox.Show($"Error: {ex.Message}");
            //        }
            //    }
            //}

            if (dgvHoadon.RowCount > 0)
            {
                if (btnConfirm.Text == "Lấy dữ liệu")
                {
                    decimal? tongtienthu = 0;
                    int tongso = 0;
                    foreach (DataGridViewRow r in dgvHoadon.Rows)
                    {
                        if (r.Cells[trangthaiColumn.Name].Value.ToString() != "Đã thu")
                        {
                            DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checksColumn.Name];
                            var thu = checks.Value;
                            if (Convert.ToBoolean(thu) == true)
                            {
                                var IDHD = decimal.Parse(dgvHoadon[ID_HDColumn2.Name, r.Index].Value.ToString());
                                var hoadon = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
                                if (hoadon != null)
                                {
                                    tongtienthu += hoadon.TONGCONG;
                                    tongso += 1;
                                }
                            }
                        }
                        txtTongthu.Text = string.Format("{0:n0}", tongtienthu);
                        txttong_HD.Text = tongso.ToString();
                        if (tongso > 0)
                            btnConfirm.Text = "Xác nhận thanh toán";
                    }

                }
                else if (btnConfirm.Text == "Xác nhận thanh toán" && txttong_HD.Text != "0")
                {
                    try
                    {
                        DialogResult rs = MessageBox.Show("Có xác nhận thanh toán hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (rs == DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            var kyghi = db.DM_KYGHI.Where(x => x.hoadon == true).FirstOrDefault();
                            var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                            decimal? tongtienCT = 0;
                            decimal NganHangID = decimal.Parse(cboNganhang.SelectedValue.ToString());
                            string madanhbo = "";
                            // add chung tu
                            CHUNGTU chungtu = new CHUNGTU();
                            chungtu.ID_KYGHI = kyghi.ID_kyghi;
                            chungtu.NAM_ID = kyghi.nam;
                            chungtu.MALOAI = _maloai;
                            chungtu.NGAYLAP = DateTime.Now;
                            chungtu.NGAYCT = dtpNgaythu.Value;
                            chungtu.NV_ID_LAP = NVLap.nv_id;
                            chungtu.NV_ID_NOP = IDKH;
                            if (_maloai == "CK")
                                chungtu.NV_ID_NOP = NganHangID;
                            chungtu.GHICHU = txtghichu.Text;
                            chungtu.TRANGTHAI = false;
                            chungtu.SOCT = CreateSO_CT();
                            chungtu.TONGTIEN = 0;
                            db.CHUNGTUs.Add(chungtu);
                            db.SaveChanges();
                            // add gach no
                            string tennganhang = _maloai == "CK" ? cboNganhang.Text : "";
                            List<GACHNO> dsGachno = new List<GACHNO>();
                            List<CHUNGTU_HOADON> DSchungtuHD = new List<CHUNGTU_HOADON>();
                            foreach (DataGridViewRow r in dgvHoadon.Rows)
                            {
                                DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checksColumn.Name];
                                var thu = checks.Value;
                                if (Convert.ToBoolean(thu) == true)
                                {
                                    decimal IDHD = decimal.Parse(dgvHoadon[ID_HDColumn2.Name, r.Index].Value.ToString());
                                    var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                                    var pPublish = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
                                    var gachno = db.GACHNOes.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                                    if ((pPublish.GACH_NO == "0" || pPublish.GACH_NO == null) && gachno == null)
                                    {
                                        string Magiaodich = hoadon.ID_KH.ToString() + chungtu.ID_CT.ToString();
                                        madanhbo = hoadon.DANHBO;
                                        tongtienCT += hoadon.tongtien;
                                        decimal? IDNV = hoadon.ID_KH;
                                        if (_maloai == "CK")
                                            IDNV = NganHangID;
                                        // add ds gach no

                                        dsGachno.Add(new GACHNO()
                                        {
                                            ID_HD = hoadon.ID_HD,
                                            ID_KH = hoadon.ID_KH,
                                            DOT_ID = hoadon.DOT_ID,
                                            ID_KYGHI = hoadon.kyghi,
                                            KYHIEU = hoadon.KY_HIEU_HD,
                                            MALOAI = _maloai,
                                            MALT = hoadon.MaLT,
                                            MAUSO = hoadon.MAU_HD,
                                            NGAYTHANHTOAN = dtpNgaythu.Value,
                                            NV_ID_NOP = IDNV,
                                            SOHD = hoadon.SO_HD,
                                            TIENTHUE_GTGT = hoadon.tienvat,
                                            TONGTIENBVMT = hoadon.tienBVMT,
                                            TONGTIEN = hoadon.tongtien0VAT,
                                            TONGTHANHTOAN = hoadon.tongtien,
                                            NAM_ID = hoadon.nam,
                                            USER_CREATE = NVLap.nv_id,
                                            DATE_CREATE = DateTime.Now,
                                            STATUS = false
                                        });

                                        string[] phoadon = { hoadon.ID_HD.ToString() };
                                        // add ds chung tu hoa don
                                        DSchungtuHD.Add(new CHUNGTU_HOADON()
                                        {
                                            ID_CT = chungtu.ID_CT,
                                            ID_HD = hoadon.ID_HD,
                                            ID_KH = hoadon.ID_KH,
                                            ID_Kyghi = hoadon.kyghi,
                                            Nam = hoadon.nam,
                                            NGAYTAO = DateTime.Now,
                                            NGAYTHU = dtpNgaythu.Value,
                                            NVID_CREATE = NVLap.nv_id,
                                            NVID_THU = NVLap.nv_id,
                                            TONGTIEN = hoadon.tongtien,
                                            DADONGBO = false,
                                            DOT_ID = hoadon.DOT_ID,
                                            GHICHU = Magiaodich,
                                            DANHBO = hoadon.DANHBO
                                        });
                                        // update hoa don, publish
                                        hoadon.gachno = true;
                                        hoadon.ngaythanhtoan = dtpNgaythu.Value;
                                        hoadon.trangthai_id = 10;
                                        hoadon.trangthaiKH = 0;
                                    }
                                }
                            }
                            var khachhang = db.KHACHHANGs.FirstOrDefault(kh => kh.ID_KH == IDKH);
                            if (khachhang != null)
                            {
                                khachhang.trangthai = 0;
                            }
                            db.GACHNOes.AddRange(dsGachno);
                            db.SaveChanges();
                            db.CHUNGTU_HOADON.AddRange(DSchungtuHD);
                            db.SaveChanges();
                            var chungtuGachNo = db.CHUNGTUs.Where(x => x.ID_CT == chungtu.ID_CT).FirstOrDefault();
                            chungtuGachNo.NV_ID_NOP = _maloai == "KH" ? IDKH : NganHangID;
                            chungtuGachNo.TONGTIEN = tongtienCT;
                            db.SaveChanges();
                            var chungtuGN = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT).Select(x => x.ID_KH).Distinct().ToList();
                            string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                            ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                            string LOAI = "TAIQUAY";
                            if (_maloai == "CK")
                                LOAI = "CHUYENKHOAN";
                            int NVIDLap = int.Parse(NVLap.nv_id.ToString());
                            foreach (var item in chungtuGN)
                            {
                                var dshoadon = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT && x.ID_KH == item).ToList();
                                object[] reseult = tdc.ThanhToanHoaDonList("WASS01", hashkey, dshoadon.Select(x => x.ID_HD.ToString()).ToArray(), dshoadon.FirstOrDefault().DANHBO, "", dshoadon.FirstOrDefault().GHICHU, Common.username, LOAI, "", "").ToArray();
                                dshoadon.FirstOrDefault().LOG_THUHO = reseult[0].ToString().ToUpper() + reseult[1].ToString().ToUpper();
                                db.SaveChanges();
                            }
                            db.UpdateThanhToan(chungtu.ID_CT);
                            if (_maloai != "KD")
                                db.Database.ExecuteSqlCommand("exec DANGNGAN_NV " + Common.NVID.ToString() + ", " + chungtu.ID_CT.ToString());
                            dgvHoadon.DataSource = null;
                            txtghichu.Text = "";
                            txtTongthu.Text = "0";
                            txttong_HD.Text = "0";
                            MessageBox.Show("Xác nhận thanh toán thành công!");
                            if (_maloai != "CK")
                            {
                                UcPhieuThuKH uc = new UcPhieuThuKH();
                                uc.pIDCT = chungtu.ID_CT;
                                uc.IDHD = 0;
                                uc.Show();
                            }
                            this.Cursor = Cursors.Default;
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string quan = cboQuan.SelectedValue != null && cboQuan.SelectedValue.ToString() != "Tất cả"
                          ? cboQuan.SelectedValue.ToString() : "";
            string phuong = cboPhuong.SelectedValue != null && cboPhuong.SelectedValue.ToString() != "Tất cả"
                            ? cboPhuong.SelectedValue.ToString() : "";
            string doituong = cboDoiTuong.SelectedValue != null && cboDoiTuong.SelectedValue.ToString() != "Tất cả"
                              ? cboDoiTuong.SelectedValue.ToString() : "";
            string search = txtTim.Text.Trim();

            var khachhang = db.getDanhSachKhachHang(2, phuong, quan, doituong, (search.Replace(" ", String.Empty)).ToUpper())
                              .Distinct()
                              .ToList();  

            if (quan != "0")
            {
                khachhang = khachhang.Where(x => x.maquan == quan).ToList();
            }

            if (phuong != "0")
            {
                khachhang = khachhang.Where(x => x.maphuong == phuong).ToList();
            }

            if (doituong != "0")
            {
                khachhang = khachhang.Where(x => x.maDT == doituong).ToList();
            }

            if(khachhang.Count > 0)
            {
                dgvKhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }    
             dgvKhachhang.DataSource = khachhang.ToList();

            this.Cursor = Cursors.Default;
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //    this.Close();
        }

        private void frGachNoKH_Load(object sender, EventArgs e)
        {
            dgvKhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // dm doi tuong
            cboDoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_DOITUONGSUDUNG> dmDoiTuong = new List<DM_DOITUONGSUDUNG>();
            dmDoiTuong.Add(new DM_DOITUONGSUDUNG() { maDT = "0", tenDT = "Tất cả" });
            var data = db.DM_DOITUONGSUDUNG.OrderBy(x => x.tenDT).ToList();
            dmDoiTuong.AddRange(data);
            cboDoiTuong.DataSource = dmDoiTuong.ToList();
            cboDoiTuong.ValueMember = "maDT";
            cboDoiTuong.DisplayMember = "tenDT";
            dtpNgaythu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgaythu.CustomFormat = "dd/MM/yyyy";
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

            // dm ngan hang
            cboNganhang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NGANHANG> nganhang = new List<DM_NGANHANG>();
            //nganhang.Add(new DM_NGANHANG() { NGANHANG_ID = 0, TENNGANHANG = "Tất cả" });
            var dmNganhang = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList();
            nganhang.AddRange(dmNganhang);
            cboNganhang.DataSource = nganhang.ToList();
            cboNganhang.ValueMember = "NGANHANG_ID";
            cboNganhang.DisplayMember = "TENNGANHANG";
            lblnganhang.Enabled = false;
            cboNganhang.Enabled = false;
            if (_maloai == "CK")
            {
                lblnganhang.Enabled = true;
                cboNganhang.Enabled = true;
            }
        }

        public string CreateSO_CT()
        {
            string kyghi_gn = db.DM_KYGHI.Where(x => x.hoadon == true).FirstOrDefault().ID_kyghi;
            string maxid = db.CHUNGTUs.Where(x => x.ID_KYGHI == kyghi_gn).Select(x => x.SOCT.Replace("TM", "").Replace("CK", "").Replace("GT", "").Replace("KD", "")).Max();
            if (maxid == null)
                maxid = "0";
            string filtered = Regex.Replace(maxid, "[A-Za-z]", "");
            long id = Convert.ToInt32(filtered);
            id = id + 1;
            string strid = id.ToString("00000") + _maloai;
            return strid;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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