using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLCongNo.View.UC.HoaDon;
using QLCongNo.View.UC.ReportViewer.BaoCao;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcGachNoKH : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 100;
        public string _maloai;
        public int _trangthai;
        private decimal IDKH;
        private decimal NV_ID;
        private string maPB;
        private bool isPhanQuyen = false;
        private static string _staticMaloai;

        public UcGachNoKH(string maloai, long trangthai)
        {
            this._maloai = maloai;
            _staticMaloai = maloai;
            this._trangthai = (int)trangthai;
        }
        public UcGachNoKH(string maloai)
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
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            dgvHoadon.CellContentClick += dgvHoadon_CellContentClick;
            this.dgvHoadon.DataError += dgvHoadon_DataError;
            this.dgvHoadon.CellFormatting += dgvHoadon_CellFormatting;
            //this.dgvHoadon.KeyDown += DgvHoadon_KeyDown;
            this.dgvHoadon.ColumnHeaderMouseClick += DgvHoadon_ColumnHeaderMouseClick;
            //this.dgvKhachhang.KeyDown += DgvKhachhang_KeyDown;

            this.dgvHoadon.KeyDown += dgvHoadon_KeyDown;
            this.dgvKhachhang.KeyDown += dgvKhachhang_KeyDown;
            dgvHoadon.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvHoadon.MultiSelect = true;
            dgvKhachhang.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvKhachhang.MultiSelect = true;
        }

        private void dgvHoadon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject dataObj = dgvHoadon.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
                e.Handled = true;
            }
        }

        private void dgvKhachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject dataObj = dgvKhachhang.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
                e.Handled = true;
            }
        }


        private void DgvHoadon_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.dgvHoadon.SelectAll();
            }
        }

        //private void DgvHoadon_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.C)
        //    {
        //        Copy(this.dgvHoadon);
        //        e.Handled = true;
        //    }
        //}

        //private void DgvKhachhang_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.C)
        //    {
        //        Copy(this.dgvKhachhang);
        //        e.Handled = true;
        //    }
        //}

        //private void Copy(DataGridView dgv)
        //{
        //    var count = dgv.SelectedCells.Count;
        //    if (count == dgv.RowCount * dgv.ColumnCount && count != 8)
        //    {
        //        //Copy all of datagridview
        //        DataObject dataObj = dgv.GetClipboardContent();
        //        if (dataObj != null)
        //            Clipboard.SetDataObject(dataObj);
        //    }
        //    else
        //    {
        //        //Copy 1 cell
        //        var currentCell = dgv.CurrentCell;
        //        if (currentCell != null && currentCell.Value != null)
        //        {
        //            Clipboard.SetText(currentCell.Value.ToString());
        //        }
        //    }
        //}

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

        private void dgvHoadon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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
                        if (e.ColumnIndex == 12)
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
                            frm.Size = new Size(1200, 800);
                            WebBrowser webBrowser = new WebBrowser();
                            webBrowser.ScriptErrorsSuppressed = true;
                            webBrowser.Dock = DockStyle.Fill;
                            webBrowser.DocumentText = result;
                            frm.Controls.Add(webBrowser);
                            frm.ShowDialog();
                        }
                        this.Cursor = Cursors.Default;
                    }
                    else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        bool isChecked = Convert.ToBoolean(dgvHoadon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? false);
                        if (this.dgvHoadon.Rows[e.RowIndex].Cells[trangthaiColumn.Name].Value.ToString() != "Đã thu")
                        {
                            var status = this.dgvHoadon.Rows[e.RowIndex].Cells[trangthaiHDColumn.Name].Value.ToString();
                            if (status != "Khó đòi" && status != "Hủy")
                            {
                                if (this.isPhanQuyen == true)
                                    dgvHoadon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !isChecked;
                            }
                            else
                            {
                                //if (this.maPB == "14") // Phong Kinh Doanh
                                //{
                                //    dgvHoadon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !isChecked;
                                //}
                            }
                        }
                    }
                }
            }
            catch { }
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
            bool isChecked = Convert.ToBoolean(chkAll.Checked);
            foreach (DataGridViewRow r in dgvHoadon.Rows)
            {
                if (r.Cells[trangthaiColumn.Name].Value.ToString() != "Đã thu")
                {
                    var status = r.Cells[trangthaiHDColumn.Name].Value.ToString();
                    if (status != "Khó đòi" && status != "Hủy")
                    {
                        if (this.isPhanQuyen == true)
                            r.Cells[checksColumn.Name].Value = isChecked;
                    }
                    else
                    {
                        //if (this.maPB == "14") // Phong Kinh Doanh
                        //{
                        //    r.Cells[checksColumn.Name].Value = isChecked;
                        //}
                    }
                }
            }
        }

        private void dgvHoadon_SelectionChanged(object sender, EventArgs e)
        {
            //txttong_HD.Text = string.Format("{0:n0}", dgvHoadon.SelectedRows.Count);
            //decimal tongtienthu = 0;
            //for (int i = 0; i < dgvHoadon.SelectedRows.Count; i++)
            //{
            //    tongtienthu += decimal.Parse(dgvHoadon.SelectedRows[i].Cells[tongtien_dgv2.Name].Value.ToString());
            //}
            //txtTongthu.Text = string.Format("{0:n0}", tongtienthu);
        }

        private void dgvKhachhang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhachhang.RowCount > 0)
                {
                    IDKH = decimal.Parse(dgvKhachhang[IDKHColumn.Name, e.RowIndex].Value.ToString());
                    var dsHoadon = db.getDSHoaDon_KH_Newest(IDKH).ToList();

                    lbltongno.Text = "Tổng tiền nợ: " + string.Format("{0:n0}", dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Select(x => x.tongtien).Sum());
                    lbltongsokyno.Text = "Tổng kỳ nợ: " + dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Count().ToString();
                    if (dsHoadon.Count() > 0)
                        dgvHoadon.DataSource = dsHoadon
                            //.OrderBy(hd => hd.thanhtoan == "Chưa thu" ? 0 : 1)
                            .ToList();
                    else
                        dgvHoadon.DataSource = null;

                    this.lblDSHoaDon.Text = $"Danh sách hóa đơn ({dsHoadon.ToList().Count})";
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
                    this.lblDSHoaDon.Text = $"Danh sách hóa đơn (0)";
                }     
            }
            catch { }
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
                            chungtu.MALOAI = _staticMaloai;
                            chungtu.NGAYLAP = DateTime.Now;
                            chungtu.NGAYCT = dtpNgaythu.Value;
                            chungtu.NV_ID_LAP = NVLap.nv_id;
                            chungtu.NV_ID_NOP = IDKH;
                            if (_staticMaloai == "CK")
                                chungtu.NV_ID_NOP = NganHangID;
                            chungtu.GHICHU = txtghichu.Text;
                            chungtu.TRANGTHAI = false;
                            chungtu.SOCT = CreateSO_CT();
                            chungtu.TONGTIEN = 0;
                            db.CHUNGTUs.Add(chungtu);
                            db.SaveChanges();
                            // add gach no
                            string tennganhang = _staticMaloai == "CK" ? cboNganhang.Text : "";
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
                                        if (_staticMaloai == "CK")
                                            IDNV = NganHangID;
                                        // add ds gach no

                                        dsGachno.Add(new GACHNO()
                                        {
                                            ID_HD = hoadon.ID_HD,
                                            ID_KH = hoadon.ID_KH,
                                            DOT_ID = hoadon.DOT_ID,
                                            ID_KYGHI = hoadon.kyghi,
                                            KYHIEU = hoadon.KY_HIEU_HD,
                                            MALOAI = _staticMaloai,
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
                            chungtuGachNo.NV_ID_NOP = _staticMaloai == "KH" ? IDKH : NganHangID;
                            chungtuGachNo.TONGTIEN = tongtienCT;
                            db.SaveChanges();
                            var chungtuGN = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT).Select(x => x.ID_KH).Distinct().ToList();
                            string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                            ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                            string LOAI = "TAIQUAY";
                            if (_staticMaloai == "CK")
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
                            if (_staticMaloai != "KD")
                                db.Database.ExecuteSqlCommand("exec DANGNGAN_NV " + Common.NVID.ToString() + ", " + chungtu.ID_CT.ToString());
                            dgvHoadon.DataSource = null;
                            txtghichu.Text = "";
                            txtTongthu.Text = "0";
                            txttong_HD.Text = "0";
                            MessageBox.Show("Xác nhận thanh toán thành công!");
                            if (_staticMaloai == "KH")
                            {
                                var frm = new UcPhieuThuKH
                                {
                                    pIDCT = chungtu.ID_CT,
                                    IDHD = 0
                                };
                                new FrmDialog().ShowDialog(frm);
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
            if (txtTim.Text != "")
            {
                string maQuan = cboQuan.SelectedValue.ToString();
                string maPhuong = cboPhuong.SelectedValue.ToString();
                string maDT = cboDoiTuong.SelectedValue.ToString();
                string tenQuan = "";
                string tenPhuong = "";
                string strSearch = txtTim.Text;

                if (cboQuan.SelectedItem is DM_QUAN selectedQuan)
                {
                    tenQuan = selectedQuan.tenQuan;
                }
                if (cboPhuong.SelectedItem is DM_PHUONG selectedPhuong)
                {
                    tenPhuong = selectedPhuong.tenPhuong;
                }
                
                var khachhang = db.getDanhSachKhachHang(2, maQuan, maPhuong, maDT, (strSearch.Replace(" ", String.Empty)).ToUpper()).Distinct().ToList();

                if (tenQuan != "Tất cả")
                {
                    khachhang = khachhang.Where(x => x.tenQuan == tenQuan).ToList();
                }

                if (tenPhuong != "Tất cả")
                {
                    khachhang = khachhang.Where(x => x.tenPhuong == tenPhuong).ToList();
                }

                dgvKhachhang.DataSource = khachhang.ToList();
                if (khachhang.Count() == 0)
                {
                    dgvHoadon.DataSource = null;
                    this.lblDSHoaDon.Text = $"Danh sách hóa đơn (0)";
                }
                    

                this.lblDSKhachHang.Text = $"Danh sách khách hàng ({khachhang.ToList().Count})";
            }
            else
            {
                this.lblDSKhachHang.Text = $"Danh sách khách hàng (0)";
                MessageBox.Show("Chưa nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
                
            this.Cursor = Cursors.Default;
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //    this.Close();
        }

        private void frGachNoKH_Load(object sender, EventArgs e)
        {
            try
            {
                var func = $"QUYEN_GACHNO";
                var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                var dsPhanQuyen = db.NGUOIDUNG_CHUCNANG.Where(x => x.FUNCTION == func).Select(x => x.NV_ID).ToList();
                var phong = db.NHANVIENs.Where(x => x.maNV == nguoidung.manv).FirstOrDefault();
                this.NV_ID = nguoidung.nv_id ?? 0;
                this.maPB = phong.maPB;
                this.isPhanQuyen = dsPhanQuyen != null && dsPhanQuyen.Contains(this.NV_ID);

                txttong_HD.Text = "0";
                txtTongthu.Text = "0";
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
                if (_staticMaloai == "CK")
                {
                    lblnganhang.Enabled = true;
                    cboNganhang.Enabled = true;
                }
            }
            catch { }
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
            string strid = id.ToString("00000") + _staticMaloai;
            return strid;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
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