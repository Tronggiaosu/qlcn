using Microsoft.Reporting.WinForms;
using QLCongNo.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class UcYeuCauForm : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcYeuCauForm()
        {
            InitializeComponent();
        }

        private void YeuCauForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadLoaiYC();
            LoadNV();
            LoadHieuDH();
            LoadKichCo();
            LoadNguyenNhan();
            LoadTrangThaiYC();
        }

        private void LoadTrangThaiYC()
        {
            var tt = from a in db.DM_TRANGTHAI_YC orderby a.TTYC_ID select a;
            ttcomboBox.DataSource = tt.ToList();
            ttcomboBox.DisplayMember = "trangthai_yc";
            ttcomboBox.ValueMember = "TTYC_ID";
        }

        private void LoadNguyenNhan()
        {
            var nn = from a in db.DM_NGUYENNHAN select a;
            nguyennhancomboBox.DataSource = nn.ToList();
            nguyennhancomboBox.DisplayMember = "tennguyennhan";
            nguyennhancomboBox.ValueMember = "id_nguyennhan";
        }

        private void LoadLoaiYC()
        {
            var yc = from a in db.DM_LOAIYEUCAU select a;
            yccomboBox.DataSource = yc.ToList();
            yccomboBox.DisplayMember = "tenloai_yc";
            yccomboBox.ValueMember = "maloai_yc";
        }

        private void LoadKichCo()
        {
            var kc = from a in db.DM_KICHCODH orderby a.MaKC select a;
            kichcocomboBox.DataSource = kc.ToList();
            kichcocomboBox.DisplayMember = "KichCo";
            kichcocomboBox.ValueMember = "maKC";
        }

        private void LoadNV()
        {
            var nvtc = from a in db.NHANVIEN_LNV where a.ID_LoaiNV == 3 select a.NV_ID;
            var nv = from a in db.NHANVIENs where nvtc.Contains(a.NV_ID) orderby a.hoten select a;
            groupListBox.DataSource = nv.ToList();
            groupListBox.DisplayMember = "hoten";
            groupListBox.ValueMember = "NV_ID";
        }

        private void LoadHieuDH()
        {
            var hieu = from a in db.DM_HIEUDONGHO orderby a.tenhieu select a;
            hieuDHcomboBox.DataSource = hieu.ToList();
            hieuDHcomboBox.DisplayMember = "tenhieu";
            hieuDHcomboBox.ValueMember = "mahieu";
        }

        private void yccomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string ma_yc = yccomboBox.SelectedValue.ToString();
            int ttyc_id = Convert.ToInt32(ttcomboBox.SelectedValue);
            var yc = from a in db.YEUCAUs
                     from b in db.KHACHHANGs
                     join c in db.DM_KICHCODH on b.MAKC equals c.MaKC into bc
                     from x in bc.DefaultIfEmpty()
                     join d in db.DM_HIEUDONGHO on b.maDH equals d.mahieu into bd
                     from y in bd.DefaultIfEmpty()
                     where a.ID_KH == b.ID_KH
                     where a.maloai_yc == ma_yc
                     where a.TTYC_ID == ttyc_id
                     where EntityFunctions.TruncateTime(a.ngayYC) >= tungaydateTimePicker.Value.Date && EntityFunctions.TruncateTime(a.ngayYC) <= denngaydateTimePicker.Value.Date
                     select new
                     {
                         id_kh = a.ID_KH,
                         id_yc = a.ID_yeucau,
                         a.ngayYC,
                         madanhbo = b.madanhbo,
                         hoten_KH = b.hoten_KH,
                         diachi = b.diachi,
                         soNK = b.soNK,
                         maDT = b.maDT,
                         maLT = b.maLT,
                         sdt = b.SDT_KH,
                         maDH = b.maDH,
                         y.tenhieu,
                         soseri_DH = b.soseri_DH,
                         ngaylapdat = b.ngaylapdat,
                         ngaykiemdinh = b.Ngay_Kiemdinh,
                         ngaydoiDH = b.ngaydoi_DH,
                         nguoilapdat = b.nguoilapdat,
                         maKC = b.MAKC,
                         x.KichCo,
                         a.DM_LYDO.ten_lydo,
                         a.sophieu
                     };
            string input = txtTim.Text;
            if (input != "")
            {
                yc = yc.Where(x => x.id_kh.ToString() == input || x.sophieu == input || x.hoten_KH.Contains(input));
            }
            dataGridView1.DataSource = yc.OrderByDescending(x => x.ngayYC).ToList();
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Cells[sttColumn.Name].Value = i + 1;
            this.Cursor = Cursors.Default;
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;
            switch (yccomboBox.SelectedValue.ToString())
            {
                case "DDH":
                    DDH();
                    break;

                case "KTA":
                    KTA();
                    break;

                case "NGUNGBC":
                    BCHI();
                    break;

                case "SUA":
                    SUA();
                    break;

                case "MO":
                    MO();
                    break;

                case "NGUNG":
                    NGUNG();
                    break;

                case "HUY":
                    HUY();
                    break;

                case "NANG":
                    HUY();
                    break;

                case "LAP":
                    LAP();
                    break;

                default:
                    Other();
                    break;
            }
            MessageBox.Show("Cập nhật hoàn thành thành công!", "Thông báo");
            kqtextBox.Text = "";
            seachButton.PerformClick();
        }

        private void Other()
        {
            //Cập nhật hoàn thành cho yêu cầu
            decimal id_yc = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idYCColumn.Name].Value);
            var yc = (from a in db.YEUCAUs where a.ID_yeucau == id_yc select a).FirstOrDefault();
            yc.TTYC_ID = 4;
            yc.ngayHT = ngaylap2dateTimePicker.Value;
            //Cập nhật GiaoPhieu
            //for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
            //{
            //    Gia phieu = new GiaoPhieu();
            //    phieu.id_yeucau = id_yc;
            //    phieu.id_nv = ((QLCongNo.NHANVIEN)(groupListBox.CheckedItems[ListIndex])).NV_ID;
            //    db.GiaoPhieux.Add(phieu);
            //} // for
            db.SaveChanges();
            var khachhang = db.KHACHHANGs.Where(x => x.ID_KH == yc.ID_KH).FirstOrDefault();
            khachhang.trangthai = 1;
            db.SaveChanges();
            var hoadon = db.HOADONs.Where(x => x.ID_KH == khachhang.ID_KH && x.gachno == false).FirstOrDefault();
            hoadon.isKhoDoi = true;
            db.SaveChanges();
            var publised = db.PublishedInvoices.Where(x => x.IDKH == khachhang.ID_KH && x.GACH_NO == null).FirstOrDefault();
            publised.GACH_NO = "1";
            db.SaveChanges();
        }

        private void LAP()
        {
            //Cập nhật hoàn thành cho yêu cầu
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                decimal id_yc = Convert.ToDecimal(dataGridView1.SelectedRows[i].Cells[idYCColumn.Name].Value);
                var yc = (from a in db.YEUCAUs where a.ID_yeucau == id_yc select a).FirstOrDefault();
                yc.TTYC_ID = 4;
                yc.ngayHT = ngaylap2dateTimePicker.Value;
                //Cập nhật GiaoPhieu
                //for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
                //{
                //    GiaoPhieu phieu = new GiaoPhieu();
                //    phieu.id_yeucau = id_yc;
                //    phieu.id_nv = ((QLCongNo.NHANVIEN)(groupListBox.CheckedItems[ListIndex])).NV_ID;
                //    db.GiaoPhieux.Add(phieu);
                //} // for
                //Cập nhật khách hàng
                decimal id_kh = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idKHColumn.Name].Value);
                var kh = (from a in db.KHACHHANGs where a.ID_KH == id_kh select a).FirstOrDefault();
                kh.trangthai = 0;
                kh.ngaytao = DateTime.Now;
                kh.ngaycapnhat = DateTime.Now;
            }
            db.SaveChanges();
        }

        private void HUY()
        {
            //Cập nhật hoàn thành cho yêu cầu
            decimal id_yc = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idYCColumn.Name].Value);
            var yc = (from a in db.YEUCAUs where a.ID_yeucau == id_yc select a).FirstOrDefault();
            yc.TTYC_ID = 4;
            yc.ngayHT = ngaylap2dateTimePicker.Value;
            //Cập nhật GiaoPhieu
            for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
            {
                GiaoPhieu phieu = new GiaoPhieu();
                phieu.id_yeucau = id_yc;
                phieu.id_nv = ((QLCongNo.NHANVIEN)(groupListBox.CheckedItems[ListIndex])).NV_ID;
                db.GiaoPhieux.Add(phieu);
            } // for
            //Cập nhật khách hàng
            decimal id_kh = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idKHColumn.Name].Value);
            var kh = (from a in db.KHACHHANGs where a.ID_KH == id_kh select a).FirstOrDefault();
            kh.trangthai = 4;
            db.SaveChanges();
        }

        private void NGUNG()
        {
            //Cập nhật hoàn thành cho yêu cầu
            decimal id_yc = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idYCColumn.Name].Value);
            var yc = (from a in db.YEUCAUs where a.ID_yeucau == id_yc select a).FirstOrDefault();
            yc.TTYC_ID = 4;
            yc.ghichu = kqtextBox.Text;
            yc.ngayHT = ngaylap2dateTimePicker.Value;
            //Cập nhật GiaoPhieu
            for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
            {
                GiaoPhieu phieu = new GiaoPhieu();
                phieu.id_yeucau = id_yc;
                phieu.id_nv = ((QLCongNo.NHANVIEN)(groupListBox.CheckedItems[ListIndex])).NV_ID;
                db.GiaoPhieux.Add(phieu);
            } // for
            //Cập nhật khách hàng
            decimal id_kh = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idKHColumn.Name].Value);
            var kh = (from a in db.KHACHHANGs where a.ID_KH == id_kh select a).FirstOrDefault();
            kh.trangthai = 1;
            db.SaveChanges();
        }

        private void BCHI()
        {
            //Cập nhật hoàn thành cho yêu cầu
            decimal id_yc = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idYCColumn.Name].Value);
            var yc = (from a in db.YEUCAUs where a.ID_yeucau == id_yc select a).FirstOrDefault();
            yc.TTYC_ID = 4;
            yc.ghichu = kqtextBox.Text;
            yc.ngayHT = ngaylap2dateTimePicker.Value;
            //Cập nhật GiaoPhieu
            for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
            {
                GiaoPhieu phieu = new GiaoPhieu();
                phieu.id_yeucau = id_yc;
                phieu.id_nv = ((QLCongNo.NHANVIEN)(groupListBox.CheckedItems[ListIndex])).NV_ID;
                db.GiaoPhieux.Add(phieu);
            } // for
            db.SaveChanges();
        }

        private void MO()
        {
            //Cập nhật hoàn thành cho yêu cầu
            decimal id_yc = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idYCColumn.Name].Value);
            var yc = (from a in db.YEUCAUs where a.ID_yeucau == id_yc select a).FirstOrDefault();
            yc.TTYC_ID = 4;
            yc.ngayHT = ngaylap2dateTimePicker.Value;
            //Cập nhật GiaoPhieu
            for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
            {
                GiaoPhieu phieu = new GiaoPhieu();
                phieu.id_yeucau = id_yc;
                phieu.id_nv = ((QLCongNo.NHANVIEN)(groupListBox.CheckedItems[ListIndex])).NV_ID;
                db.GiaoPhieux.Add(phieu);
            } // for
            //Cập nhật khách hàng
            decimal id_kh = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idKHColumn.Name].Value);
            var kh = (from a in db.KHACHHANGs where a.ID_KH == id_kh select a).FirstOrDefault();
            kh.trangthai = 0;
            db.SaveChanges();
        }

        private void SUA()
        {
            //Cập nhật hoàn thành cho yêu cầu
            decimal id_yc = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idYCColumn.Name].Value);
            var yc = (from a in db.YEUCAUs where a.ID_yeucau == id_yc select a).FirstOrDefault();
            yc.TTYC_ID = 4;
            yc.ngayHT = ngaylap2dateTimePicker.Value;
            yc.ghichu = ghichutextBox.Text;
            yc.idnguyennhan = Convert.ToInt32(nguyennhancomboBox.SelectedValue);
            //Cập nhật GiaoPhieu
            for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
            {
                GiaoPhieu phieu = new GiaoPhieu();
                phieu.id_yeucau = id_yc;
                phieu.id_nv = ((QLCongNo.NHANVIEN)(groupListBox.CheckedItems[ListIndex])).NV_ID;
                db.GiaoPhieux.Add(phieu);
            } // for
            db.SaveChanges();
        }

        private void KTA()
        {
            //Cập nhật hoàn thành cho yêu cầu
            decimal id_yc = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idYCColumn.Name].Value);
            var yc = (from a in db.YEUCAUs where a.ID_yeucau == id_yc select a).FirstOrDefault();
            yc.TTYC_ID = 4;
            yc.ngayHT = ngaylap2dateTimePicker.Value;
            yc.ghichu = kqtextBox.Text;
            //Cập nhật GiaoPhieu
            for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
            {
                GiaoPhieu phieu = new GiaoPhieu();
                phieu.id_yeucau = id_yc;
                phieu.id_nv = ((QLCongNo.NHANVIEN)(groupListBox.CheckedItems[ListIndex])).NV_ID;
                db.GiaoPhieux.Add(phieu);
            } // for
            db.SaveChanges();
        }

        private void DDH()
        {
            //Cập nhật hoàn thành cho yêu cầu
            decimal id_yc = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idYCColumn.Name].Value);
            var yc = (from a in db.YEUCAUs where a.ID_yeucau == id_yc select a).FirstOrDefault();
            yc.TTYC_ID = 4;
            yc.ngayHT = ngaylap2dateTimePicker.Value;
            yc.ghichu = txtGhiChuDDH.Text;
            //Cập nhật GiaoPhieu
            for (int ListIndex = 0; ListIndex < groupListBox.CheckedItems.Count; ListIndex++)
            {
                GiaoPhieu phieu = new GiaoPhieu();
                phieu.id_yeucau = id_yc;
                phieu.id_nv = ((QLCongNo.NHANVIEN)(groupListBox.CheckedItems[ListIndex])).NV_ID;
                db.GiaoPhieux.Add(phieu);
            } // for

            //Cập nhật khách hàng
            decimal id_kh = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idKHColumn.Name].Value);
            var kh = (from a in db.KHACHHANGs where a.ID_KH == id_kh select a).FirstOrDefault();
            kh.MAKC = kichcocomboBox.SelectedValue != null ? Convert.ToInt32(kichcocomboBox.SelectedValue) : 0;
            kh.soseri_DH = serialtextBox.Text;
            kh.maDH = hieuDHcomboBox.SelectedValue != null ? Convert.ToInt32(hieuDHcomboBox.SelectedValue) : 0;
            kh.ngaylapdat = ngaylap2dateTimePicker.Value;
            kh.Ngay_Kiemdinh = ngaykiemdinh2dateTimePicker.Value;
            kh.ngaydoi_DH = ngaylap2dateTimePicker.Value;

            //Cập nhật BD_KHACHHANG
            BD_KHACHHANG bd_kh = new BD_KHACHHANG();
            //bd_kh.ID_yeucau = id_yc;
            bd_kh.ID_KH = id_kh;
            bd_kh.maDH = dataGridView1.SelectedRows[0].Cells[maDHColumn.Name].Value != null ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[maDHColumn.Name].Value) : 0;
            bd_kh.soseri_DH = dataGridView1.SelectedRows[0].Cells[soseriDHColumn.Name].Value != null ? dataGridView1.SelectedRows[0].Cells[soseriDHColumn.Name].Value.ToString() : "";
            bd_kh.ngaylapdat = dataGridView1.SelectedRows[0].Cells[ngaylapdatColumn.Name].Value != null ? Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[ngaylapdatColumn.Name].Value) : DateTime.Now;
            bd_kh.Ngay_Kiemdinh = dataGridView1.SelectedRows[0].Cells[ngaykiemdinhColumn.Name].Value != null ? Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[ngaykiemdinhColumn.Name].Value) : DateTime.Now;
            bd_kh.ngaydoi_DH = dataGridView1.SelectedRows[0].Cells[ngaydoiDHColumn.Name].Value != null ? Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[ngaydoiDHColumn.Name].Value) : DateTime.Now;
            bd_kh.MAKC = dataGridView1.SelectedRows[0].Cells[maKCColumn.Name].Value != null ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[maKCColumn.Name].Value) : 0;
            //bd_kh.nguoilapdat = dataGridView1.SelectedRows[0].Cells[nguoilapdatColumn.Name].Value.ToString();
            db.BD_KHACHHANG.Add(bd_kh);
            db.SaveChanges();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }

        private void groupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ListIndex;
            groupListBox.SelectedIndexChanged -= groupListBox_SelectedIndexChanged;
            for (ListIndex = 0; ListIndex < groupListBox.Items.Count; ListIndex++)
            {
                if (groupListBox.SelectedIndex == ListIndex)
                {
                    // set selected item as checked
                    groupListBox.SetItemChecked(ListIndex, true);
                }
            } // for
            groupListBox.SelectedIndexChanged += groupListBox_SelectedIndexChanged;
        }

        //Print
        private void printButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                UcReportForm rpf = new UcReportForm
                {
                    IDYC = decimal.Parse(dataGridView1.SelectedRows[i].Cells[idYCColumn.Name].Value.ToString())
                };
                new FrmDialog().ShowDialog(rpf);
            }
            //if (printDialog1.ShowDialog() == DialogResult.OK)
            //{
            //string yeucau = yccomboBox.SelectedValue.ToString();
            //if (yeucau == "KTA" || yeucau == "11")
            //{
            //    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            //    {
            //        RPPhieuKTA rpf = new RPPhieuKTA();
            //        rpf.yeucau = yccomboBox.Text;
            //        rpf.loaiyeucau = yeucau;
            //        rpf.khachhang = dataGridView1.SelectedRows[i].Cells[hotenColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[hotenColumn.Name].Value.ToString() : "không";
            //        rpf.madb = dataGridView1.SelectedRows[i].Cells[idKHColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[idKHColumn.Name].Value.ToString() : "không";
            //        rpf.diachi = dataGridView1.SelectedRows[i].Cells[diachi1Column.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[diachi1Column.Name].Value.ToString() : "không";
            //        rpf.hieudh = dataGridView1.SelectedRows[i].Cells[hieuDHColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[hieuDHColumn.Name].Value.ToString() : "không";
            //        rpf.kichco = dataGridView1.SelectedRows[i].Cells[kcColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[kcColumn.Name].Value.ToString() : "không";
            //        rpf.chiso = dataGridView1.SelectedRows[i].Cells[chisoColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[chisoColumn.Name].Value.ToString() : "không";
            //        rpf.lydo = dataGridView1.SelectedRows[i].Cells[lydoColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[lydoColumn.Name].Value.ToString() : "không";
            //        rpf.khid = dataGridView1.SelectedRows[i].Cells[idKHColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[idKHColumn.Name].Value.ToString() : "Chưa xác định";
            //        rpf.idyc = "..............";
            //        rpf.soseri = dataGridView1.SelectedRows[i].Cells[soseriDHColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[soseriDHColumn.Name].Value.ToString() : "Chưa xác định";
            //        rpf.maDT = dataGridView1.SelectedRows[i].Cells[maDT.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[maDT.Name].Value.ToString() : "Chưa xác định";
            //        rpf.Show();
            //        rpf.Hide();
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            //    {
            //        ReportForm rpf = new ReportForm();
            //        rpf.yeucau = yccomboBox.Text;
            //        rpf.loaiyeucau = yeucau;
            //        rpf.khachhang = dataGridView1.SelectedRows[i].Cells[hotenColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[hotenColumn.Name].Value.ToString() : "không";
            //        rpf.madb = dataGridView1.SelectedRows[i].Cells[idKHColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[idKHColumn.Name].Value.ToString() : "không";
            //        rpf.diachi = dataGridView1.SelectedRows[i].Cells[diachi1Column.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[diachi1Column.Name].Value.ToString() : "không";
            //        rpf.hieudh = dataGridView1.SelectedRows[i].Cells[hieuDHColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[hieuDHColumn.Name].Value.ToString() : "không";
            //        rpf.kichco = dataGridView1.SelectedRows[i].Cells[kcColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[kcColumn.Name].Value.ToString() : "không";
            //        rpf.chiso = dataGridView1.SelectedRows[i].Cells[chisoColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[chisoColumn.Name].Value.ToString() : "không";
            //        rpf.lydo = dataGridView1.SelectedRows[i].Cells[lydoColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[lydoColumn.Name].Value.ToString() : "không";
            //        rpf.khid = dataGridView1.SelectedRows[i].Cells[idKHColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[idKHColumn.Name].Value.ToString() : "Chưa xác định";
            //        rpf.idyc = "..............";
            //        rpf.soseri = dataGridView1.SelectedRows[i].Cells[soseriDHColumn.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[soseriDHColumn.Name].Value.ToString() : "Chưa xác định";
            //        rpf.maDT = dataGridView1.SelectedRows[i].Cells[maDT.Name].Value != null ? dataGridView1.SelectedRows[i].Cells[maDT.Name].Value.ToString() : "Chưa xác định";
            //        rpf.Show();
            //        rpf.Hide();
            //    }
            //}
            //}
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                dataGridView1.SelectAll();
            }
            else dataGridView1.ClearSelection();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            kqtextBox.Focus();
        }
    }
}