using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLCongNo.GachNo
{
    public partial class frGachNoKhoDoi : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        DataTable dt = new DataTable();
        DataColumn column;
        DataRow row;
        List<DSHoaDonKhoDoi> dataKhachHang = new List<DSHoaDonKhoDoi>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 50;
        public frGachNoKhoDoi()
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
            dgvHD.SelectionChanged += dgvHD_SelectionChanged;
            dgvCT.SelectionChanged += dgvCT_SelectionChanged;
            btnConfirm.Click+=btnConfirm_Click;
        }

        void dgvCT_SelectionChanged(object sender, EventArgs e)
        {
            txttong_HD.Text = string.Format("{0:n0}", dgvCT.SelectedRows.Count);
            decimal tongtienthu = 0;
            for (int i = 0; i < dgvCT.SelectedRows.Count; i++)
            {
                tongtienthu += decimal.Parse(dgvCT.SelectedRows[i].Cells[tongtien_dgv2.Name].Value.ToString());
            }
            txtTongthu.Text = string.Format("{0:n0}", tongtienthu);
        }
        //void btnHD_Click(object sender, EventArgs e)
        //{
        //    List<GACHNO> gachno = new List<GACHNO>();
        //    foreach (DataGridViewRow r in dgvCT.Rows)
        //    {
        //        DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checksColumn.Name];
        //        var thu = checks.Value;
        //        if (Convert.ToBoolean(thu) == true)
        //        {
        //            decimal ID_HDColumn = decimal.Parse(dgvCT["ID_HDColumn", r.Index].Value.ToString());
        //            gachno.Add(new GACHNO
        //            {
        //                ID_HD = ID_HDColumn
        //            });
        //        }
        //    }

        //    txttong_HD.Text = gachno.Count().ToString();
        //}

        void dgvHD_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var ID_KH = decimal.Parse(dgvHD.SelectedRows[0].Cells[ID_KH_dgv1.Name].Value.ToString());
                var dataHoadon = db.DSHoaDonKhoDois.Where(x => x.ID_KH == ID_KH && x.ngaycapnhat == null).ToList();
                if (dataHoadon.Count > 0)
                    dgvCT.DataSource = dataHoadon.ToList();
                else
                    dgvCT.DataSource = null;
            }
            catch
            {
                
            }
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
            dgvHD.DataSource = dataSource.Distinct().OrderBy(x => x.SO_HD).ToList();
            this.Cursor = Cursors.Default;
        }

        void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvCT.RowCount > 0)
            {
                DialogResult rs = MessageBox.Show("Có xác nhận thanh toán hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    var kyghi = db.DM_KYGHI.Where(x => x.gachno == true).FirstOrDefault();
                    var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                    decimal? tongtienCT = 0;
                    // add chung tu
                    CHUNGTU chungtu = new CHUNGTU();
                    chungtu.ID_KYGHI = kyghi.ID_kyghi;
                    chungtu.MALOAI = "KH";
                    chungtu.NGAYLAP = DateTime.Now;
                    chungtu.NGAYCT = dtpNgaythu.Value;
                    chungtu.NV_ID_LAP = NVLap.nv_id;
                    //chungtu.NV_ID_NOP = NganHangID;
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
                    for (int i = 0; i < dgvCT.SelectedRows.Count; i++)
                    {
                        decimal IDHD = decimal.Parse(dgvCT.SelectedRows[i].Cells[ID_HDColumn.Name].Value.ToString());
                        var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD && x.gachno == false).FirstOrDefault();
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
                                MALOAI = "KH",
                                MALT = hoadon.MaLT,
                                MAUSO = hoadon.MAU_HD,
                                NGAYTHANHTOAN = dtpNgaythu.Value,
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
                            //hoadon.nganhang_id = NganHangID;
                            var published = db.PublishedInvoices.Where(x => x.KEY == IDHD.ToString()).FirstOrDefault();
                            published.GACH_NO = "1";
                            // ghi log
                            LOG_THUTIENNUOC log = new LOG_THUTIENNUOC();
                            log.ID_KH = hoadon.ID_KH;
                            log.SO_HD = hoadon.SO_HD;
                            log.Ky_Hieu_HD = hoadon.KY_HIEU_HD;
                            log.NGAYIN = DateTime.Now;
                            log.NV_ID = NVLap.nv_id;
                            log.GIAYBAO = 0;
                            db.SaveChanges();
                            // update hoa don
                            db.SaveChanges();
                        }
                    }
                    db.GACHNOes.AddRange(dsGachno);
                    db.CHUNGTU_HOADON.AddRange(DSchungtuHD);
                    var chungtuGachNo = db.CHUNGTUs.Where(x => x.ID_CT == IDCT_Nhanvien).FirstOrDefault();
                    var IDKH = dgvCT.SelectedRows[0].Cells[ID_KHColumn.Name].Value.ToString();
                    chungtuGachNo.NV_ID_NOP = decimal.Parse(IDKH);
                    chungtuGachNo.TONGTIEN = tongtienCT;
                    db.SaveChanges();
                    MessageBox.Show("Xác nhận thanh toán thành công!");
                    btnTim.PerformClick();
                    dgvCT.DataSource = null;
                    dgvHD.DataSource = null;
                    txtghichu.Text = "";
                    txtTongthu.Text = "0";
                    txttong_HD.Text = "0";
                    this.Cursor = Cursors.Default;
                }
            }
        }

        void dgvCT_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string ID_HD = dgvCT.SelectedRows[0].Cells[ID_HDColumn.Name].Value.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ID_HD_data = dt.Rows[i]["ID_HD"].ToString();
                if (ID_HD_data == ID_HD)
                {
                    DataRow dr = dt.Rows[i];
                    dr.Delete();
                }
            }
            dgvCT.DataSource = dt;
            sumInvoice();
            enable_btnPT();
            this.Cursor = Cursors.Default;
        }

        void dgvHD_DoubleClick(object sender, EventArgs e)
        {
            if (dt.Columns.Count <= 0)
                createTable();
            createRows();
            dgvCT.DataSource = dt;
            sumInvoice();
            enable_btnPT();
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có lưu file excel? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
                Common.ExportExcel(dgvHD);
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string text = txtTim.Text;
                    if (txtTim.Text != "")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            var dataHoaDon = dataKhachHang.Where(x => x.madanhbo.Contains(text) || x.hoten.Contains(text.ToUpper()) || x.diachi.Contains(text.ToUpper()) || x.SO_HD.Contains(text) || x.tongtien.ToString().Contains(text) || x.MaLT.Contains(text)).ToList();
                            GetCurrentRecords(CurrentPageIndex, dataHoaDon);
                            lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
                            int rowCount = dataHoaDon.Count();
                            TotalPage = rowCount / PgSize;
                            if (rowCount % PgSize > 0)
                                TotalPage += 1;
                            lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
                        }
                    }
                }
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.Cursor = Cursors.WaitCursor;
            string kyghi = cboKy.SelectedValue.ToString();
            decimal nam = decimal.Parse(cboNam.SelectedValue.ToString());
            decimal dot = decimal.Parse(cboDot.SelectedValue.ToString());
            int httt = int.Parse(cboHTTT.SelectedValue.ToString());
            string maDT = cboDTSD.SelectedValue.ToString();
            decimal loaiHD = decimal.Parse(cboloaiHD.SelectedValue.ToString());
            var tungay = DateTime.Parse(dateTimePicker1.Value.ToString("dd/MM/yyyy 00:00:00"));
            var denngay = DateTime.Parse(dateTimePicker1.Value.ToString("dd/MM/yyyy 23:59:59"));
            string maPhuong = cboPhuong.SelectedValue.ToString();
            string maQuan = cboQuan.SelectedValue.ToString();
            var dataKhachhang = db.DSHoaDonKhoDois.ToList();
            if (kyghi != "0")
                dataKhachhang = dataKhachhang.Where(x => x.kyghi == kyghi).ToList();
            if (nam != 0)
                dataKhachhang = dataKhachhang.Where(x => x.nam == nam).ToList();
            if (dot != 0)
                dataKhachhang = dataKhachhang.Where(x => x.DOT_ID == dot).ToList();
            if (maDT != "0")
                dataKhachhang = dataKhachhang.Where(x => x.MGB == maDT).ToList();
            if (loaiHD != 0)
                dataKhachhang = dataKhachhang.Where(x => x.LoaiHD_ID == loaiHD).ToList();
            if (checkBox1.Checked == true)
                dataKhachhang = dataKhachhang.Where(x => x.ngaycapnhat >= tungay.Date && x.ngaycapnhat <= denngay.Date).ToList();
            if (maPhuong != "0")
                dataKhachhang = dataKhachhang.Where(x => x.maphuong == maPhuong).ToList();
            if (maQuan != "0")
                dataKhachhang = dataKhachhang.Where(x => x.maquan == maQuan).ToList();
            dataKhachHang = dataKhachhang.ToList();
            GetCurrentRecords(CurrentPageIndex, dataKhachhang);
            int rowCount = dataKhachhang.Count();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
            lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
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
            row["ID_KH"] = dgvHD.SelectedRows[0].Cells[ID_KHColumn.Name].Value.ToString();
            row["ID_HD"] = dgvCT.SelectedRows[0].Cells[ID_HDColumn.Name].Value.ToString();
            dt.Rows.Add(row);
            RemoveDuplicateRows(dt, "ID_HD");
        }
        public void sumInvoice()
        {
            int j = 0;
            decimal tongthanhtoan = 0;
            //string ghichu_id = "";
            for (int i = 0; i < dgvCT.RowCount; i++)
            {
                j++;
                tongthanhtoan += decimal.Parse(dgvCT.Rows[i].Cells[tongtien_dgv2.Name].Value.ToString());
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
        private void enable_btnPT()
        {
            if (dgvCT.RowCount > 0)
                btnConfirm.Enabled = true;
            else
                btnConfirm.Enabled = false;
        }

        private void frGachNoKhoDoi_Load(object sender, EventArgs e)
        {
            dgvHD.AutoGenerateColumns = false;
            dgvCT.AutoGenerateColumns = false;
            // dm ky ghi
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.OrderBy(x => x.ten_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            cboKy.DataSource = dmKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            // dm nam
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
            // dm hinh thuc thanh toan
            cboHTTT.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_HINHTHUCTHANHTOAN> hinhthuc = new List<DM_HINHTHUCTHANHTOAN>();
            hinhthuc.Add(new DM_HINHTHUCTHANHTOAN() { maHTTT = 0, tenHTTT = "Tất cả" });
            var dshinhthuc = db.DM_HINHTHUCTHANHTOAN.OrderBy(x => x.tenHTTT).ToList();
            hinhthuc.AddRange(dshinhthuc);
            cboHTTT.DataSource = hinhthuc.ToList();
            cboHTTT.DisplayMember = "tenHTTT";
            cboHTTT.ValueMember = "maHTTT";
            // loai hoa don
            cboloaiHD.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_LOAIHOADON> dmLoaiHD = new List<DM_LOAIHOADON>();
            dmLoaiHD.Add(new DM_LOAIHOADON() { LoaiHD_ID = 0, tenloaiHD = "Tẩt cả" });
            var dataLoaiHD = db.DM_LOAIHOADON.OrderBy(x => x.tenloaiHD).ToList();
            dmLoaiHD.AddRange(dataLoaiHD);
            cboloaiHD.DataSource = dmLoaiHD.ToList();
            cboloaiHD.ValueMember = "LoaiHD_ID";
            cboloaiHD.DisplayMember = "tenloaiHD";
            // loai doi tuong su dung
            cboDTSD.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_DOITUONGSUDUNG> dataDTSD = new List<DM_DOITUONGSUDUNG>();
            dataDTSD.Add(new DM_DOITUONGSUDUNG() { maDT = "0", tenDT = "Tất cả" });
            var dsDT = db.DM_DOITUONGSUDUNG.OrderBy(x => x.tenDT).ToList();
            dataDTSD.AddRange(dsDT);
            cboDTSD.DataSource = dataDTSD.ToList();
            cboDTSD.ValueMember = "maDT";
            cboDTSD.DisplayMember = "tenDT";
            // dm phuong
            cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
            dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
            var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
            dsPhuong.AddRange(dataPhuong);
            cboPhuong.DataSource = dsPhuong.ToList();
            cboPhuong.ValueMember = "maPhuong";
            cboPhuong.DisplayMember = "tenPhuong";
            // dm quan
            cboQuan.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_QUAN> dsQuan = new List<DM_QUAN>();
            dsQuan.Add(new DM_QUAN() { maQuan = "0", tenQuan = "Tất cả" });
            var dataQuan = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
            dsQuan.AddRange(dataQuan);
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            // dot
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dtpNgaythu.Format = DateTimePickerFormat.Custom;
            dtpNgaythu.CustomFormat = "dd/MM/yyyy";
        }

    }
}
