using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using QLCongNo.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcGachNoKhoDoi : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        DataTable dt = new DataTable();
        DataColumn column;
        DataRow row;
        List<DSHoaDonKhoDoi> dataKhachHang = new List<DSHoaDonKhoDoi>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 50;
        private decimal ID_KH;
        public UcGachNoKhoDoi()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            btnPrevious.Click += btnPrevious_Click;
            btnNext.Click += btnNext_Click;
            btnFirst.Click += btnFisrt_Click;
            btnLast.Click += btnLast_Click;
            btnConfirm.Click += btnConfirm_Click;
            cboHTTT.SelectedIndexChanged += cboHTTT_SelectedIndexChanged;
            dgvKH.RowEnter += dgvKH_RowEnter;
            dgvHD.CellContentClick += dgvHD_CellContentClick;
            this.dgvHD.DataError += dgvHD_DataError;
            this.dgvHD.CellFormatting += dgvHD_CellFormatting;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
        }
        private void dgvHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHD.Columns[e.ColumnIndex].Name == "thangColumn")
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
            if (dgvHD.Columns[e.ColumnIndex].Name == "namColumn")
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

        private void dgvHD_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
        private void cboHTTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = (DM_HINHTHUCTHANHTOAN)cboHTTT.SelectedItem;
                if (selectedItem != null && selectedItem.tenHTTT == "Ngân hàng")
                {
                    cbonganhang.Enabled = true;
                }
                else
                {
                    cbonganhang.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvKH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKH.RowCount == 0)
                {
                    dgvHD.DataSource = null;
                    return;
                }

                ID_KH = decimal.Parse(dgvKH[ID_KHColumn.Name, e.RowIndex].Value.ToString());

                var dsRaw = db.getDSHoaDon_KH_Newest(ID_KH)
                    .Where(hd =>
                        cbkThanhToan.Checked
                            ? db.HOADON_KHODOI.Any(kh => kh.ID_HD == hd.ID_HD && kh.TRANGTHAI == true)
                            : (hd.trangthai_id == 13 && db.HOADON_KHODOI.Any(kh => kh.ID_HD == hd.ID_HD && kh.TRANGTHAI == false))
                    )
                    .ToList();

                var idList = dsRaw.Select(h => h.ID_HD).ToList();
                var khodoiDict = db.HOADON_KHODOI
                    .Where(k => k.ID_HD.HasValue && idList.Contains(k.ID_HD.Value))
                    .ToDictionary(k => k.ID_HD.Value, k => k);


                var dsHoaDon = dsRaw.Select(hd =>
                {
                    var khodoi = khodoiDict.ContainsKey(hd.ID_HD) ? khodoiDict[hd.ID_HD] : null;

                    return new DataHoaDonKhoDoi
                    {
                        ID_HD = hd.ID_HD,
                        trangthaiKH = hd.trangthaiKH,
                        kyghi = hd.kyghi,
                        SO_HD = hd.SO_HD,
                        tongtien = hd.tongtien,
                        tentrangthai = hd.tentrangthai,
                        chitiet = hd.chitiet,
                        thanhtoan = hd.thanhtoan,
                        ghichu = hd.ghichu,
                        NGAYCHUYEN = khodoi?.NGAYCHUYEN,
                        NGAYTHANHTOAN = khodoi?.NGAYTHANHTOAN,
                        NGUOITHANHTOAN = khodoi?.NGUOITHANHTOAN,
                        nam = hd.nam
                    };
                })
                .OrderByDescending(x => x.nam)
                .ThenBy(x => x.kyghi)
                .ToList();

                dgvHD.DataSource = dsHoaDon.Any() ? dsHoaDon : null;
                txtTongthu.Text = string.Format("{0:n0}", dsHoaDon.Where(x => x.tentrangthai == "Khó đòi").Sum(x => x.tongtien ?? 0));
                txttong_HD.Text = dsHoaDon.Count(x => x.tentrangthai == "Khó đòi").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            //try
            //{
            //    if (dgvKH.RowCount == 0)
            //    {
            //        dgvHD.DataSource = null;
            //        return;
            //    }

            //    ID_KH = decimal.Parse(dgvKH[ID_KHColumn.Name, e.RowIndex].Value.ToString());

            //    var dsRaw = db.getDSHoaDon_KH_Newest(ID_KH).ToList();

            //    bool trangthaiKhoDoi = cbkThanhToan.Checked;

            //    var khodoiList = db.HOADON_KHODOI
            //        .Where(k => k.ID_HD.HasValue && k.TRANGTHAI == trangthaiKhoDoi)
            //        .ToList();

            //    var dsHoaDon = (
            //        from hd in dsRaw
            //        join kd in khodoiList on hd.ID_HD equals kd.ID_HD into gj
            //        from kd in gj.DefaultIfEmpty()
            //        where trangthaiKhoDoi || hd.trangthai_id == 13 
            //        select new DataHoaDonKhoDoi
            //        {
            //            ID_HD = hd.ID_HD,
            //            trangthaiKH = hd.trangthaiKH,
            //            kyghi = hd.kyghi,
            //            SO_HD = hd.SO_HD,
            //            tongtien = hd.tongtien,
            //            tentrangthai = hd.tentrangthai,
            //            chitiet = hd.chitiet,
            //            thanhtoan = hd.thanhtoan,
            //            ghichu = hd.ghichu,
            //            NGAYCHUYEN = kd?.NGAYCHUYEN,
            //            NGAYTHANHTOAN = kd?.NGAYTHANHTOAN,
            //            NGUOITHANHTOAN = kd?.NGUOITHANHTOAN,
            //            nam = hd.nam
            //        })
            //        .OrderByDescending(x => x.nam)
            //        .ThenBy(x => x.kyghi)
            //        .ToList();

            //    dgvHD.DataSource = dsHoaDon.Any() ? dsHoaDon : null;
            //    txtTongthu.Text = string.Format("{0:n0}", dsHoaDon.Where(x => x.tentrangthai == "Khó đòi").Sum(x => x.tongtien ?? 0));
            //    txttong_HD.Text = dsHoaDon.Count(x => x.tentrangthai == "Khó đòi").ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}
        }

        void dgvCT_SelectionChanged(object sender, EventArgs e)
        {
            //txttong_HD.Text = string.Format("{0:n0}", dgvCT.SelectedRows.Count);
            //decimal tongtienthu = 0;
            //for (int i = 0; i < dgvCT.SelectedRows.Count; i++)
            //{
            //    tongtienthu += decimal.Parse(dgvCT.SelectedRows[i].Cells[tongtien_dgv2.Name].Value.ToString());
            //}
            //txtTongthu.Text = string.Format("{0:n0}", tongtienthu);
        }
        void btnHD_Click(object sender, EventArgs e)
        {
            //List<GACHNO> gachno = new List<GACHNO>();
            //foreach (DataGridViewRow r in dgvCT.Rows)
            //{
            //    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checksColumn.Name];
            //    var thu = checks.Value;
            //    if (Convert.ToBoolean(thu) == true)
            //    {
            //        decimal ID_HDColumn = decimal.Parse(dgvCT["ID_HDColumn", r.Index].Value.ToString());
            //        gachno.Add(new GACHNO
            //        {
            //            ID_HD = ID_HDColumn
            //        });
            //    }
            //}

            //txttong_HD.Text = gachno.Count().ToString();
        }

        void dgvHD_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var ID_KH = decimal.Parse(dgvHD.SelectedRows[0].Cells[ID_KH_dgv1.Name].Value.ToString());
            //    var dataHoadon = db.DSHoaDonKhoDois.Where(x => x.ID_KH == ID_KH && x.ngaycapnhat == null).ToList();
            //    if (dataHoadon.Count > 0)
            //        dgvCT.DataSource = dataHoadon.ToList();
            //    else
            //        dgvCT.DataSource = null;
            //}
            //catch
            //{

            //}
        }

        void btnLast_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = TotalPage;
            GetCurrentRecords(CurrentPageIndex, dataKhachHang);
            lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
        }

        void btnFisrt_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            GetCurrentRecords(CurrentPageIndex, dataKhachHang);
            lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
        }
        void btnNext_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                GetCurrentRecords(this.CurrentPageIndex, dataKhachHang);
                lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            }
        }

        void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                GetCurrentRecords(this.CurrentPageIndex, dataKhachHang);
                lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            }
        }
        private void GetCurrentRecords(int page, List<DSHoaDonKhoDoi> dataKhachHang)
        {
            this.Cursor = Cursors.WaitCursor;
            var dataSource = dataKhachHang.ToList();

            if (page == 1)
                dataSource = dataSource.Take(PgSize).ToList();
            else
            {
                int PreviousPageOffSet = (page - 1) * PgSize;
                dataSource = (from kh in dataKhachHang
                              where !(dataKhachHang.Take(PreviousPageOffSet).Select(x => x.ID_KH)).Contains(kh.ID_KH)
                              select kh).Take(PgSize).ToList();
            }
            //dgvHD.DataSource = dataSource.Distinct().OrderBy(x => x.SO_HD).ToList();
            this.Cursor = Cursors.Default;
        }

        void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHD.RowCount == 0) return;

                if(cbkThanhToan.Checked == true && dgvHD.RowCount > 0)
                {
                    MessageBox.Show("Những hoá đơn này đã thanh toán rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }    

                int maHTTT = (cboHTTT.SelectedValue != null) ? Convert.ToInt32(cboHTTT.SelectedValue) : 0;
                decimal NganHangID = decimal.Parse(cbonganhang.SelectedValue.ToString());
                DialogResult rs = MessageBox.Show("Xác nhận thanh toán tất cả các hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnConfirm.Enabled = false;
                    using (var _tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var kyghi = db.DM_KYGHI.Where(x => x.gachno == true).FirstOrDefault();
                            var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                            decimal? tongtienCT = 0;

                            CHUNGTU chungtu = new CHUNGTU();
                            chungtu.ID_KYGHI = kyghi.ID_kyghi;
                            chungtu.MALOAI = "KD";
                            chungtu.NGAYLAP = DateTime.Now;
                            chungtu.NGAYCT = dtpNgayBK.Value;
                            chungtu.NV_ID_LAP = NVLap.nv_id;
                            if (maHTTT == 2)
                            {
                                chungtu.NV_ID_NOP = NganHangID;
                            }
                            else
                            {
                                chungtu.NV_ID_NOP = ID_KH;
                            }
                            chungtu.GHICHU = txtghichu.Text;
                            chungtu.TRANGTHAI = false;
                            chungtu.SOCT = SO_CT_tutang();
                            chungtu.TONGTIEN = 0;
                            db.CHUNGTUs.Add(chungtu);
                            db.SaveChanges();

                            var IDCT_Nhanvien = db.CHUNGTUs.Where(x => x.NV_ID_LAP == NVLap.nv_id).Max(x => x.ID_CT);
                            List<GACHNO> dsGachno = new List<GACHNO>();
                            List<CHUNGTU_HOADON> DSchungtuHD = new List<CHUNGTU_HOADON>();
                            foreach (DataGridViewRow row in dgvHD.Rows)
                            {
                                decimal IDHD = decimal.Parse(dgvHD[ID_HDColumn.Name, row.Index].Value.ToString());
                                var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD && x.gachno == false).FirstOrDefault();
                                var dmPhieuthu = db.dm_phieu_thu.Where(x => x.FKEY == IDHD.ToString()).FirstOrDefault();
                                if (dmPhieuthu == null)
                                {
                                    tongtienCT += hoadon.tongtien;
                                    dsGachno.Add(new GACHNO()
                                    {
                                        ID_HD = hoadon.ID_HD,
                                        ID_KH = hoadon.ID_KH,
                                        DOT_ID = hoadon.DOT_ID,
                                        ID_KYGHI = hoadon.kyghi,
                                        KYHIEU = hoadon.KY_HIEU_HD,
                                        MALOAI = "KD",
                                        MALT = hoadon.MaLT,
                                        MAUSO = hoadon.MAU_HD,
                                        NGAYTHANHTOAN = dtpNgayBK.Value,
                                        NV_ID_NOP = hoadon.ID_KH,
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

                                    hoadon.gachno = true;
                                    hoadon.ngaythanhtoan = DateTime.Now;
                                    var published = db.PublishedInvoices.Where(x => x.KEY == IDHD.ToString()).FirstOrDefault();
                                    if (published != null)
                                    {
                                        published.GACH_NO = "1";
                                    }

                                    LOG_THUTIENNUOC log = new LOG_THUTIENNUOC();
                                    log.ID_KH = hoadon.ID_KH;
                                    log.SO_HD = hoadon.SO_HD;
                                    log.Ky_Hieu_HD = hoadon.KY_HIEU_HD;
                                    log.NGAYIN = DateTime.Now;
                                    log.NV_ID = NVLap.nv_id;
                                    log.GIAYBAO = 0;
                                }

                                var record = db.HOADON_KHODOI.FirstOrDefault(hdkd => hdkd.ID_HD == IDHD && hdkd.TRANGTHAI == false);
                                if (record != null)
                                {
                                    record.TRANGTHAI = true;
                                    record.NGUOITHANHTOAN = NVLap.NHANVIEN.hoten;
                                    record.NGAYTHANHTOAN = DateTime.Now;
                                }
                            }
                            db.SaveChanges();
                            // update trạng thái của khách hàng
                            //var khachhang = db.KHACHHANGs.FirstOrDefault(kh => kh.ID_KH == ID_KH);
                            //if (khachhang != null)
                            //{
                            //    khachhang.trangthai = 0;
                            //}
                            db.GACHNOes.AddRange(dsGachno);
                            db.CHUNGTU_HOADON.AddRange(DSchungtuHD);
                            var chungtuGachNo = db.CHUNGTUs.Where(x => x.ID_CT == IDCT_Nhanvien).FirstOrDefault();
                            chungtuGachNo.NV_ID_NOP = ID_KH;
                            chungtuGachNo.TONGTIEN = tongtienCT;
                            db.SaveChanges();
                            MessageBox.Show("Xác nhận thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnTim.PerformClick();
                            dgvHD.DataSource = null;
                            txtghichu.Text = "";
                            txtTongthu.Text = "0";
                            txttong_HD.Text = "0";
                            this.Cursor = Cursors.Default;
                            if (dgvKH.SelectedRows.Count > 0)
                            {
                                int rowIndex = dgvKH.SelectedRows[0].Index;
                                var eRowEvent = new DataGridViewCellEventArgs(0, rowIndex);
                                dgvKH_RowEnter(sender, eRowEvent);
                            }

                            _tran.Commit();
                        }
                        catch (Exception ex1) 
                        {
                            _tran.Rollback();
                            MessageBox.Show("Có lỗi xảy ra: " + ex1.Message);
                        }
                    }    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            btnConfirm.Enabled = true;
        }

        void dgvCT_DoubleClick(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //string ID_HD = dgvCT.SelectedRows[0].Cells[ID_HDColumn.Name].Value.ToString();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string ID_HD_data = dt.Rows[i]["ID_HD"].ToString();
            //    if (ID_HD_data == ID_HD)
            //    {
            //        DataRow dr = dt.Rows[i];
            //        dr.Delete();
            //    }
            //}
            //dgvCT.DataSource = dt;
            //sumInvoice();
            //enable_btnPT();
            //this.Cursor = Cursors.Default;
        }

        void dgvHD_DoubleClick(object sender, EventArgs e)
        {
            //if (dt.Columns.Count <= 0)
            //    createTable();
            //createRows();
            //dgvCT.DataSource = dt;
            //sumInvoice();
            //enable_btnPT();
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            if (dgvHD.RowCount == 0)
            {
                MessageBox.Show("Không có hóa đơn nào trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult rs = MessageBox.Show("Bạn có lưu file excel? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
                Common.ExportExcel(dgvHD);
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }
        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            //if (txtTim.Text != "")
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        string text = txtTim.Text;
            //        if (txtTim.Text != "")
            //        {
            //            if (e.KeyCode == Keys.Enter)
            //            {
            //                var dataHoaDon = dataKhachHang.Where(x => x.madanhbo.Contains(text) || x.hoten.Contains(text.ToUpper()) || x.diachi.Contains(text.ToUpper()) || x.SO_HD.Contains(text) || x.tongtien.ToString().Contains(text) || x.MaLT.Contains(text)).ToList();
            //                GetCurrentRecords(CurrentPageIndex, dataHoaDon);
            //                lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            //                int rowCount = dataHoaDon.Count();
            //                TotalPage = rowCount / PgSize;
            //                if (rowCount % PgSize > 0)
            //                    TotalPage += 1;
            //                lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            //            }
            //        }
            //    }
            //}

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

        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string search = txtTim.Text.Trim();
            string maQuan = cboQuan.SelectedValue.ToString();
            string maPhuong = cboPhuong.SelectedValue.ToString();

            string tenPhuong = (cboPhuong.SelectedItem as DM_PHUONG)?.tenPhuong ?? "";
            string tenQuan = (cboQuan.SelectedItem as DM_QUAN)?.tenQuan ?? "";

            var idKh_HoaDonKhodoi = db.HOADON_KHODOI.Select(h => h.ID_KH).Distinct().ToList();

            var khachhang = db.getDanhSachKhachHang(2, maQuan, maPhuong, "0", (search.Replace(" ", String.Empty)).ToUpper())
                  .Where(kh => idKh_HoaDonKhodoi.Contains(kh.ID_KH))
                  .Distinct()
                  .ToList();


            if (tenQuan != "Tất cả")
            {
                khachhang = khachhang.Where(x => x.tenQuan == tenQuan).ToList();
            }

            if (tenPhuong != "Tất cả")
            {
                khachhang = khachhang.Where(x => x.tenPhuong == tenPhuong).ToList();
            }

            var khachHang = khachhang.ToList();
            if (khachHang.Count > 0)
            {
                dgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            dgvKH.DataSource = khachHang;

            if (khachHang.Count() == 0)
            {
                dgvHD.DataSource = null;
            }
            this.Cursor = Cursors.Default;
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
        }
        public void createRows()
        {
            row = dt.NewRow();
            //row["ID_KH"] = dgvHD.SelectedRows[0].Cells[ID_KHColumn.Name].Value.ToString();
            //row["ID_HD"] = dgvCT.SelectedRows[0].Cells[ID_HDColumn.Name].Value.ToString();
            dt.Rows.Add(row);
            RemoveDuplicateRows(dt, "ID_HD");
        }
        public void sumInvoice()
        {
            int j = 0;
            decimal tongthanhtoan = 0;
            //string ghichu_id = "";
            for (int i = 0; i < dgvHD.RowCount; i++)
            {
                j++;
                tongthanhtoan += decimal.Parse(dgvHD.Rows[i].Cells[tongtien_dgv2.Name].Value.ToString());
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
            string strid = id.ToString("0000") + "KD";
            return strid;
        }

        private void frGachNoKhoDoi_Load(object sender, EventArgs e)
        {
            dgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKH.AutoGenerateColumns = false;
            dgvHD.AutoGenerateColumns = false;
            //dgvCT.AutoGenerateColumns = false;
            // dm hinh thuc thanh toan
            cboHTTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_HINHTHUCTHANHTOAN> hinhthuc = new List<DM_HINHTHUCTHANHTOAN>();
            hinhthuc.Add(new DM_HINHTHUCTHANHTOAN() { maHTTT = 0, tenHTTT = "Tất cả" });
            var dshinhthuc = db.DM_HINHTHUCTHANHTOAN.OrderBy(x => x.tenHTTT).ToList();
            hinhthuc.AddRange(dshinhthuc);
            cboHTTT.DataSource = hinhthuc.ToList();
            cboHTTT.DisplayMember = "tenHTTT";
            cboHTTT.ValueMember = "maHTTT";
            // dm ngan hang
            cbonganhang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NGANHANG> nganhang = new List<DM_NGANHANG>();
            //nganhang.Add(new DM_NGANHANG() { NGANHANG_ID = 0, TENNGANHANG = "Tất cả" });
            var dmNganhang = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList();
            nganhang.AddRange(dmNganhang);
            cbonganhang.DataSource = nganhang.ToList();
            cbonganhang.ValueMember = "NGANHANG_ID";
            cbonganhang.DisplayMember = "TENNGANHANG";
            cbonganhang.Enabled = false;
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

            btnFirst.Visible = false;
            btnLast.Visible = false;
            btnPrevious.Visible = false;
            btnNext.Visible = false;
            lblPage.Visible = false;
        }

        private void dgvHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHD.RowCount > 0)
                {
                    var senderGrid = (DataGridView)sender;
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        decimal IDHD = decimal.Parse(dgvHD.Rows[e.RowIndex].Cells[ID_HDColumn.Name].Value.ToString());
                        if (e.ColumnIndex == 7)
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
                            frm.StartPosition = FormStartPosition.CenterScreen;
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

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }
    }
}
