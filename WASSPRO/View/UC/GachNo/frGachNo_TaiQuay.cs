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
using QLCongNo.BLL;
using QLCongNo.ReportViewer.DataSource;
namespace QLCongNo.FORM
{
    public partial class UcGachNo_TaiQuay : View.Core.NovUserControl
    {
       CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        ChungTu_BLL ct = new ChungTu_BLL();
        LoTrinh_BLL lt = new LoTrinh_BLL();
        Nhanvien_BLL nv = new Nhanvien_BLL();
        DataTable dt = new DataTable();
        DataColumn column;
        DataRow row;
        public UcGachNo_TaiQuay()
        {
            InitializeComponent();
            chkkyghi.CheckedChanged += chkkyghi_CheckedChanged;
            chkLT.CheckedChanged += chkLT_CheckedChanged;
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            dgvHD.DoubleClick += dgvHD_DoubleClick;
            dgvCT.DoubleClick += dgvCT_DoubleClick;
            btnThanhtoan.Click += btnThanhtoan_Click;
        }
        void btnThanhtoan_Click(object sender, EventArgs e)
        {
            var nhanvien = (from a in db.NHANVIENs
                           from c in db.NGUOIDUNGs
                           where a.maNV == c.manv && c.ma_nd == Common.username
                           select a).FirstOrDefault();
            string ID_NV_nop = dgvCT.Rows[0].Cells[ID_KH.Name].Value.ToString();
            var kyghi_gn = db.DANHMUCKYGHIs.Where(x => x.gachno == true).FirstOrDefault();
            if (kyghi_gn == null)
                MessageBox.Show("Không có kỳ gạch nợ nào trong hệ thống!");
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn gạch nợ những hóa đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        CHUNGTU CT_EN = new CHUNGTU();
                        CT_EN.ID_kyghi = kyghi_gn.ID_kyghi;
                        CT_EN.ghichu = txtghichu.Text;
                        CT_EN.NV_ID_lap = nhanvien.NV_ID;
                        CT_EN.NV_ID_nop = int.Parse(ID_NV_nop);
                        CT_EN.SOCT = SO_CT_tutang(); ;
                        CT_EN.maloai = "KH";
                        CT_EN.tongtien = 0;
                        CT_EN.ngaylap = DateTime.Now;
                        CT_EN.ngayct = dtpNgaythu.Value;
                        CT_EN.trangthai = false;
                        db.CHUNGTUs.Add(CT_EN);
                        db.SaveChanges();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            decimal IDHD = decimal.Parse(dt.Rows[i]["ID_HD"].ToString());
                            string tongtien = dt.Rows[i]["tongtien"].ToString();
                            string hoten = dt.Rows[i]["hoten_KH"].ToString();
                            var dmphieuthu = db.dm_phieu_thu.Where(x => x.FKEY == IDHD.ToString()).FirstOrDefault();
                            var chungtuHD = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            if (dmphieuthu == null && chungtuHD == null || dmphieuthu.Checks == 0 && chungtuHD == null)
                            {
                                // insert table chungtu_hoadon
                                CHUNGTU_HOADON CT_HD = new CHUNGTU_HOADON();
                                CT_HD.ID_HD = IDHD;
                                CT_HD.sotien = decimal.Parse(tongtien);
                                CT_HD.ID_CT = db.CHUNGTUs.Where(x => x.NV_ID_lap == nhanvien.NV_ID).Max(x => x.ID_CT);
                                CT_HD.dadongbo = false;
                                db.CHUNGTU_HOADON.Add(CT_HD);
                                db.SaveChanges();
                                // update table hoadon(ngaythanhtoan, sotienno, sotienthanhtoan
                                var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD && x.IsInHD == true).FirstOrDefault();
                                hoadon.sotienno = 0;
                                hoadon.sotienthanhtoan = hoadon.tongtien;
                                hoadon.ngaythanhtoan = dtpNgaythu.Value;
                                db.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Khách hàng " + hoten + "đã thanh toán, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        var IDCT_Nhanvien = db.CHUNGTUs.Where(x => x.NV_ID_lap == nhanvien.NV_ID).Max(x => x.ID_CT);
                        var chungtu = db.CHUNGTUs.Where(x => x.ID_CT == IDCT_Nhanvien).FirstOrDefault();
                        var chungtuhoadon = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT).ToList();
                        if (chungtuhoadon.Count() == 0)
                        {
                            db.CHUNGTUs.Remove(chungtu);
                            MessageBox.Show("Tất cả khách hàng đã thanh toán, vui lòng kiểm tra lại!");
                        }
                        else
                        {
                            var tongtien = chungtuhoadon.Select(x => x.sotien).Sum();
                            chungtu.tongtien = tongtien;
                            db.SaveChanges();
                            foreach (var fkey in chungtuhoadon)
                            {
                                var published = db.PublishedInvoices.Where(x => x.KEY == fkey.ID_HD.ToString()).FirstOrDefault();
                                published.GACH_NO = "1";
                                db.SaveChanges();

                            }
                            DialogResult print = MessageBox.Show("Thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            this.Cursor = Cursors.WaitCursor;
                            dt = null;
                            dgvCT.DataSource = null;
                            dgvHD.DataSource = null;
                            txtghichu.Text = "";
                            txtTongthu.Text = "0";
                            txttong_HD.Text = "0";
                            PhieuThuKH frm = new PhieuThuKH();
                            frm.ID_CT = IDCT_Nhanvien.ToString();
                            frm.Maloai = "KH";
                            frm.Show();
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                        MessageBox.Show("Không có hóa đơn trong danh sách gạch nợ, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }

        void dgvCT_DoubleClick(object sender, EventArgs e)
        {
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
         //   this.Close();
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            var data = from a in db.HOADONs
                       from b in db.KHACHHANGs
                       from c in db.DANHMUCKYGHIs
                       from d in db.LOTRINHs
                       where a.ID_KH == b.ID_KH
                       where a.kyghi == c.ID_kyghi
                       where a.sotienno != 0
                       where a.IsInHD == true
                       where a.MaLT == d.maLT
                       select new
                       {
                           a.ID_HD,
                           a.ID_KH,
                           b.madanhbo,
                           a.tongtien,
                           hoten_KH = a.ID_KH.ToString() + " - " + b.hoten_KH,
                           c.ten_kyghi,
                           a.kyghi,
                           MaLT = a.MaLT + " - " + d.tenLT,
                           b.diachi
                       };
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string filtered = Regex.Replace(text, "[A-Za-z]", "");
                    string result = Regex.Replace(filtered, @"\s+", "");
                    string res = Regex.Replace(result, @"[^\u0000-\u007F]+", " ");
                    if (res == "" || res == null || res == " ")
                        res = "0";
                    decimal id = Convert.ToDecimal(res);
                    data = data.Where(x => x.ID_KH == id || x.hoten_KH.Contains(text) || x.madanhbo.Contains(text) || x.diachi.Contains(text));
                    dgvHD.DataSource = data.OrderBy(x => x.ten_kyghi).ToList();
                }
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string kyghi = cboKyghi.SelectedValue.ToString();
                string maLT = cboLT.SelectedValue.ToString();
                var data = from a in db.HOADONs
                           from b in db.KHACHHANGs
                           from c in db.DANHMUCKYGHIs
                           from d in db.LOTRINHs
                           where a.ID_KH == b.ID_KH
                           where a.kyghi == c.ID_kyghi
                           where a.sotienno != 0
                           where a.IsInHD == true
                           where a.MaLT == d.maLT
                           select new
                           {
                               a.ID_HD,
                               a.ID_KH,
                               b.madanhbo,
                               a.tongtien,
                               hoten_KH = a.ID_KH.ToString() + " - " + b.hoten_KH,
                               c.ten_kyghi,
                               a.kyghi,
                               MaLT = a.MaLT + " - " + d.tenLT,
                               b.diachi,
                               b.MA_HTTT

                           };
                if (chkkyghi.Checked == true && chkLT.Checked == true)
                    data = data.Where(x => x.MaLT == maLT && x.kyghi == kyghi);
                if (chkkyghi.Checked == true)
                    data = data.Where(x => x.kyghi == kyghi);
                if (chkLT.Checked == true)
                    data = data.Where(x => x.MaLT == maLT);
                dgvHD.DataSource = data.OrderBy(x => x.ten_kyghi).ToList();
            }
            catch
            {
                MessageBox.Show("Chưa chọn lộ trình!");
            }
        }

        void chkLT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLT.Checked == true)
                cboLT.Enabled = true;
            else
                cboLT.Enabled = false;
        }

        void chkkyghi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkkyghi.Checked == true)
                cboKyghi.Enabled = true;
            else
                cboKyghi.Enabled = false;
        }

        private void frGachNo_TaiQuay_Load(object sender, EventArgs e)
        {
            dgvHD.AutoGenerateColumns = false;
            dgvCT.AutoGenerateColumns = false;
            cboLT.Enabled = false;
            cboKyghi.Enabled = false;
            txttong_HD.Enabled = false;
            txtTongthu.Enabled = false;
            cboKyghi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboKyghi.DataSource = db.DANHMUCKYGHIs.OrderByDescending(x => x.ID_kyghi).ToList();
            cboKyghi.ValueMember = "ID_kyghi";
            cboKyghi.DisplayMember = "Ten_kyghi";
            cboLT.DataSource = db.LOTRINHs.OrderBy(x => x.tenLT).ToList();
            cboLT.ValueMember = "maLT";
            cboLT.DisplayMember = "tenLT";
            enable_btnPT();
            cboLT.AutoCompleteMode = AutoCompleteMode.Suggest;
            //this.dgvCT.RowsDefaultCellStyle.BackColor = Color.White;
            //this.dgvCT.AlternatingRowsDefaultCellStyle.BackColor = Color.MintCream;
            //this.dgvHD.RowsDefaultCellStyle.BackColor = Color.White;
            //this.dgvHD.AlternatingRowsDefaultCellStyle.BackColor = Color.MintCream;
            //dgvCT.ColumnHeadersDefaultCellStyle.BackColor = Color.Linen;
            //dgvCT.EnableHeadersVisualStyles = false;
            //dgvHD.ColumnHeadersDefaultCellStyle.BackColor = Color.Linen;
            //dgvHD.EnableHeadersVisualStyles = false;
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
            dt.Rows.Add(row);
            RemoveDuplicateRows(dt, "ID_HD");
        }
        public void sumInvoice()
        {
            int j = 0;
            decimal tongthanhtoan = 0;
            string ghichu_id = "";
            for (int i = 0; i < dgvCT.RowCount; i++)
            {
                j++;
                tongthanhtoan += decimal.Parse(dgvCT.Rows[i].Cells[tongtien_dgv2.Name].Value.ToString());
                if (ghichu_id == "")
                    ghichu_id = dgvCT.Rows[i].Cells[ID_KH.Name].Value.ToString();
                else
                {
                    if (ghichu_id.IndexOf(dgvCT.Rows[i].Cells[ID_KH.Name].Value.ToString()) == -1)
                        ghichu_id = ghichu_id + ", " + dgvCT.Rows[i].Cells[ID_KH.Name].Value.ToString();
                }
            }
            txtTongthu.Text = string.Format("{0:n0}", tongthanhtoan);
            txttong_HD.Text = j.ToString();
            txtghichu.Text = ghichu_id;
        }
        public string SO_CT_tutang()
        {
            string kyghi_gn = db.DANHMUCKYGHIs.Where(x => x.gachno == true).FirstOrDefault().ID_kyghi;
            string maxid = db.CHUNGTUs.Where(x => x.ID_kyghi == kyghi_gn ).Select(x => x.SOCT).Max();
            if (maxid == null)
                maxid = "0";
            string filtered = Regex.Replace(maxid, "[A-Za-z]", "");
            long id = Convert.ToInt32(filtered);
            id++;
            string strid = id.ToString("0000") + "TM";
            return strid;
        }
        private void enable_btnPT()
        {
            if (dgvCT.RowCount > 0)
                btnThanhtoan.Enabled = true;
            else
                btnThanhtoan.Enabled = false;
        }

    }
}
