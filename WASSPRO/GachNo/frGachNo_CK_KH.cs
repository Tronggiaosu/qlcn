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
namespace QLCongNo.FORM
{
    public partial class frGachNo_CK_KH : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        DataTable dt = new DataTable();
        DataColumn column;
        DataRow row;
        List<HOADON> dataHoaDon = new List<HOADON>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 100;
        public frGachNo_CK_KH()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            dgvHD.DoubleClick += dgvHD_DoubleClick;
            dgvCT.DoubleClick += dgvCT_DoubleClick;
            btnConfirm.Click += btnConfirm_Click;
            btnPrevious.Click += btnPrevious_Click;
            btnNext.Click += btnNext_Click;
            btnFirst.Click += btnFisrt_Click;
            btnLast.Click += btnLast_Click;
        }
        void btnLast_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = TotalPage;
            GetCurrentRecords(CurrentPageIndex, dataHoaDon);
            lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
        }

        void btnFisrt_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            GetCurrentRecords(CurrentPageIndex, dataHoaDon);
            lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
        }
        void btnNext_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                GetCurrentRecords(this.CurrentPageIndex, dataHoaDon);
                lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            }
        }

        void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                GetCurrentRecords(this.CurrentPageIndex, dataHoaDon);
                lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
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
            dgvHD.DataSource = dataSource.OrderBy(x => x.SO_HD).ToList();
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
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        decimal IDHD = decimal.Parse(dt.Rows[i]["ID_HD"].ToString());
                        var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        var dmPhieuthu = db.dm_phieu_thu.Where(x => x.FKEY == IDHD.ToString()).FirstOrDefault();
                        if (dmPhieuthu == null)
                        {
                            tongtienCT += hoadon.tongtien;
                            // add ds gach no
                            dsGachno.Add(new GACHNO(){
                                ID_HD = hoadon.ID_HD,
                                ID_KH = hoadon.ID_KH,
                                DOT_ID = hoadon.DOT_ID,
                                ID_KYGHI = hoadon.kyghi,
                                KYHIEU = hoadon.KY_HIEU_HD,
                                MALOAI = "KH",
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
            string ID_HD = dgvCT.SelectedRows[0].Cells[id_hd_dgv2.Name].Value.ToString();
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
                    this.Cursor = Cursors.WaitCursor;
                    string text = txtTim.Text;
                    var dataSource = db.HOADONs.Where(x => x.gachno == false && x.trangthai_id != 0 && x.isKhoDoi == false && x.trangthai_id != 9 && x.trangthai_id != 10 && x.trangthai_id != 2).ToList();
                    var dmphieuthu = db.dm_phieu_thu.Where(x => x.Checks == 0).Select(x => x.FKEY).ToList();
                    dataSource = (from hd in dataSource
                                  where !dmphieuthu.Contains(hd.ID_HD.ToString())
                                  select hd).ToList();
                    var dataHoaDon = dataSource.Where(x => x.gachno == false && x.isKhoDoi == false && x.trangthai_id != 0 && x.DANHBO.Contains(text) || x.KHACHHANG.hoten_KH.Contains(text) || x.MaLT.Contains(text) || x.SO_HD.Contains(text) || x.tongtien.ToString().Contains(text) || x.diachihoadon.Contains(text)).ToList();
                    GetCurrentRecords(CurrentPageIndex, dataHoaDon);
                    lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var dataSource = db.HOADONs.Where(x => x.gachno == false && x.trangthai_id != 0 && x.isKhoDoi == false && x.trangthai_id != 9 && x.trangthai_id != 10 && x.trangthai_id != 2).ToList();
            var dmphieuthu = db.dm_phieu_thu.Where(x=>x.Checks == 0).Select(x=>x.FKEY).ToList();
            dataSource = (from hd in dataSource
                          where !dmphieuthu.Contains(hd.ID_HD.ToString())
                          select hd).ToList();
            decimal DOTID = decimal.Parse(cboDot.SelectedValue.ToString());
            string IDKyghi = cboKy.SelectedValue.ToString();
            decimal namID = decimal.Parse(cboNam.SelectedValue.ToString());
            decimal NganHangID = decimal.Parse( cboNH.SelectedValue.ToString());
            string maDT = cboDT.SelectedValue.ToString();
            if (DOTID != 0)
                dataSource = dataSource.Where(x => x.DOT_ID == DOTID).ToList();
            if (IDKyghi != "0")
                dataSource = dataSource.Where(x => x.kyghi == IDKyghi).ToList();
            if (namID != 0)
                dataSource = dataSource.Where(x => x.nam == namID).ToList();
            if (maDT != "0")
                dataSource = dataSource.Where(x => x.MADT == maDT).ToList();
            if (NganHangID != 0)
                dataSource = dataSource.Where(x => x.KHACHHANG.nganhang_id == NganHangID).ToList();
            dataHoaDon = dataSource.ToList();
            GetCurrentRecords(CurrentPageIndex, dataSource);
            int rowCount = dataHoaDon.Count();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
            lblPage.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            this.Cursor = Cursors.Default;
        }

        private void frGachNo_CK_KH_Load(object sender, EventArgs e)
        {
            dgvHD.AutoGenerateColumns = false;
            // dm dot
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
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
            // dm doi tuong su dung
            cboDT.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_DOITUONGSUDUNG> dmDoiTuong = new List<DM_DOITUONGSUDUNG>();
            dmDoiTuong.Add(new DM_DOITUONGSUDUNG() { maDT = "0", tenDT = "Tất cả" });
            var data = db.DM_DOITUONGSUDUNG.OrderBy(x => x.tenDT).ToList();
            dmDoiTuong.AddRange(data);
            cboDT.DataSource = dmDoiTuong.ToList();
            cboDT.ValueMember = "maDT";
            cboDT.DisplayMember = "tenDT";
            // dm ngan hang
            cboNH.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NGANHANG> nganhang = new List<DM_NGANHANG>();
            nganhang.Add(new DM_NGANHANG() { NGANHANG_ID = 0, TENNGANHANG = "Tất cả" });
            var dmNganhang = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList();
            nganhang.AddRange(dmNganhang);
            cboNH.DataSource = nganhang.ToList();
            cboNH.ValueMember = "NGANHANG_ID";
            cboNH.DisplayMember = "TENNGANHANG";
            // dm ngan hang thu
            cboNganHangThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNganHangThu.DataSource = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList(); ;
            cboNganHangThu.ValueMember = "NGANHANG_ID";
            cboNganHangThu.DisplayMember = "TENNGANHANG";
            dtpNgaythu.Format = DateTimePickerFormat.Custom;
            dtpNgaythu.CustomFormat = "dd/MM/yyyy";
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
            row = dt.NewRow();
            row["ID_KH"] = dgvHD.SelectedRows[0].Cells[ID_KH_dgv1.Name].Value;
            row["ID_HD"] = dgvHD.SelectedRows[0].Cells[ID_HD_dgv1.Name].Value;
            row["tongtien"] = dgvHD.SelectedRows[0].Cells[tongtienColumn.Name].Value.ToString();
            row["hoten_KH"] = dgvHD.SelectedRows[0].Cells[hoten_KH_Column.Name].Value.ToString();
            row["madanhbo"] = dgvHD.SelectedRows[0].Cells[madanhboColumn.Name].Value.ToString();
            row["ten_kyghi"] = dgvHD.SelectedRows[0].Cells[kyghiColumn.Name].Value.ToString();
            row["diachi"] = dgvHD.SelectedRows[0].Cells[diachiColumn.Name].Value.ToString();
            row["maLT"] = dgvHD.SelectedRows[0].Cells[maLTColumn.Name].Value.ToString();
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
            string strid = id.ToString("0000") + "CK";
            return strid;
        }
        private void enable_btnPT()
        {
            if (dgvCT.RowCount > 0)
                btnConfirm.Enabled = true;
            else
                btnConfirm.Enabled = false;
        }

    }
}
