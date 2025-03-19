using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.DanhMuc;
using QLCongNo.ReportViewer.BaoCao;

namespace QLCongNo.DangNgan
{
    public partial class frDangNganChuyenKhoan : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public string maloai;
        DataTable table;
        public frDangNganChuyenKhoan()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            //chkAll.CheckedChanged += chkAll_CheckedChanged;
            btnUpdate.Click += btnUpdate_Click;
            btnInbaocao.Click += btnInbaocao_Click;
            quitButton.Click += quitButton_Click;
            cboTO.SelectedIndexChanged += cboTO_SelectedIndexChanged;
            btnDN.Click += btnDN_Click;
            btnInPT.Click += btnInPT_Click;
            btnExcel.Click += btnExcel_Click;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            //btnIn.Click += btnIn_Click;
        }

        void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (chkAll.Checked == true)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Cells[chkColumn.Name].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Cells[chkColumn.Name].Value = false;
                }
            }
            this.Cursor = Cursors.Default;
        }

        void btnExcel_Click(object sender, EventArgs e)
        {
            var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
            var tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
            var denngay = dtpDenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            decimal NHID = decimal.Parse(cboNganhang.SelectedValue.ToString());
            decimal NVLap = decimal.Parse(nguoidung.nv_id.ToString());
            bool isdangngan = false;
            if (chkisdangngan.Checked == true)
                isdangngan = true;
            int TOID = -1;
            if (Common.ChucvuID != 1 && Common.ChucvuID != 4)
                NVLap = 0;
            if (maloai == "TT")
                TOID = int.Parse(cboTO.SelectedValue.ToString());
            var dataSource = db.getDangNganTheoNgayEX(NHID, 0, tungay, denngay, maloai, "0", isdangngan, NVLap, TOID).ToList();
            if (textBox1.Text != "")
                dataSource = dataSource.Where(x => x.timkiem.Contains(textBox1.Text.ToUpper().Replace(" ", String.Empty))).ToList();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string[] columns = { "KY_HIEU_HD", "ten_kyghi", "so_hd", "DANHBO", "NGAYDANGNGAN_NV", "ngayBK", "tongtien0VAT", "tienvat", "tienBVMT", "PhiNT", "TienThueNT", "tongtien", "tienuoc_dc", "tienthue_dc", "tienphi_dc", "PhiNT_dc", "TienThueNT_dc", "NVNop", "GHICHU", "SOPHATHANH", "hoten_KH", "MaLT" };
                var result = ExcelExportHelper.ExportExcel(dataSource, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!");
            }
        }

        void btnInPT_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDHD = 0;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                    var thu = checks.Value;
                    if (Convert.ToBoolean(thu) == true)
                    {
                        IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                       
                    }
                }
                if (chkIn.Checked == true)
                {
                    var chungtuHD = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                    frPhieuThuKH frm = new frPhieuThuKH();
                    frm.pIDCT = chungtuHD.ID_CT;
                    frm.IDHD = IDHD;
                    frm.ShowDialog();
                }
              
            }
            catch
            {
                
            }
        }

        void btnIn_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("In biên nhận cho khách hàng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                    var thu = checks.Value;
                    if (Convert.ToBoolean(thu) == true)
                    {
                        decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                        var hoadon = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        frPhieuThuKH frm = new frPhieuThuKH();
                        frm.pIDCT = hoadon.ID_CT;
                        frm.IDHD = hoadon.ID_HD;
                        frm.ShowDialog();
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        void btnDN_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Xác nhận đăng ngân?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                var tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
                var denngay = dtpDenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
                decimal NHID = decimal.Parse(cboNganhang.SelectedValue.ToString());
                decimal NVLap = decimal.Parse(nguoidung.nv_id.ToString());
                int TOID = -1;
                if (maloai == "TT")
                    TOID = int.Parse(cboTO.SelectedValue.ToString());
                var dataSource = db.UpdateDangNganTheoNgay(NHID, 0, tungay, denngay, maloai, "", false, NVLap, TOID);
                btnTim.PerformClick();
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        void cboTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int TOID = int.Parse(cboTO.SelectedValue.ToString());
                LoadNhanVien(TOID);
            }
            catch
            {

            }
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnInbaocao_Click(object sender, EventArgs e)
        {
            if (chkisdangngan.Checked == false)
                MessageBox.Show("Chưa chọn trạng thái đăng ngân");
            else
            {
                
                var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                var tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
                var denngay = dtpDenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
                decimal NHID = decimal.Parse(cboNganhang.SelectedValue.ToString());
                decimal NVLap = decimal.Parse(nguoidung.nv_id.ToString());
                if (Common.ChucvuID != 1 && Common.ChucvuID != 4)
                    NVLap = 0;
                int TOID = -1;
                if (maloai == "TT")
                    TOID = int.Parse(cboTO.SelectedValue.ToString());
                frTongHopDangNgan frm = new frTongHopDangNgan();
                frm.tungay = tungay;
                frm.denngay = denngay;
                frm.NVID = NHID;
                frm.NVLap = NVLap;
                frm.maloai = maloai;
                frm.TOID = TOID;
                frm.MdiParent = this.MdiParent;
                foreach (Form otherForm in this.MdiChildren)
                    if (otherForm != frm)
                        otherForm.Close();
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (chkAllList.Checked == true)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                    var chungtuhd = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                    var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                    if (chungtuhd != null)
                    {
                        var dangngan = db.DANGNGANs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        dangngan.NGAYDANGNGAN_NV = dtpBK.Value;
                        if (dangngan.maloai == "KH")
                        {
                            chungtuhd.NGAYTHU = dtpBK.Value;
                            hoadon.ngaythanhtoan = dtpBK.Value;
                            db.SaveChanges();
                        }

                        db.SaveChanges();
                        LOG_USER lg = new LOG_USER();
                        lg.nguoidung_id = Common.NVID;
                        lg.ghichu = "Chuyển ngày " + dangngan.ID_HD.ToString() + "sang " + dtpBK.Value.ToString("dd/MM/yyyy");
                        db.LOG_USER.Add(lg);
                    }
                }
                MessageBox.Show("Cập nhật thành công!");
                btnTim.PerformClick();
            }
            else if (chkNgayDN.Checked == true)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                    var check = checks.Value;
                    if (Convert.ToBoolean(check) == true)
                    {
                        decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                        var chungtuhd = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        if (chungtuhd != null)
                        {
                            var dangngan = db.DANGNGANs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            dangngan.NGAYDANGNGAN_NV = dtpBK.Value;
                            if (dangngan.maloai == "KH")
                            {
                                chungtuhd.NGAYTHU = dtpBK.Value;
                                hoadon.ngaythanhtoan = dtpBK.Value;
                                db.SaveChanges();
                            }

                            db.SaveChanges();
                            LOG_USER lg = new LOG_USER();
                            lg.nguoidung_id = Common.NVID;
                            lg.ghichu = "Chuyển ngày " + dangngan.ID_HD.ToString() + "sang " + dtpBK.Value.ToString("dd/MM/yyyy");
                            db.LOG_USER.Add(lg);
                        }
                    }
                }
                MessageBox.Show("Cập nhật thành công!");
                btnTim.PerformClick();
            }
            else if (chkHuyTT.Checked == true)
            {
                if (txtlydo.Text == "")
                    MessageBox.Show("ChƯa nhập lý do hủy");
                else
                {

                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                        var thu = checks.Value;
                        if (Convert.ToBoolean(thu) == true)
                        {
                            decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                            var chungtuHD = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            int NVThu = int.Parse(chungtuHD.NVID_CREATE.ToString());
                            if (maloai == "TT" && chungtuHD != null)
                            {
                                HuyThanhToanVNPTAPP(chungtuHD.ID_KH, chungtuHD.ID_CT).ToString();
                            }
                            else if (chungtuHD != null && maloai != "TT")
                            {
                                var dsChungtu = db.CHUNGTU_HOADON.Where(x => x.GHICHU == chungtuHD.GHICHU && x.ID_CT == chungtuHD.ID_CT).ToList();
                                var gachno = db.GACHNOes.Where(x => x.ID_HD == IDHD && x.PRODUCTS != null).ToList();
                                List<ChungTuLog> dslog = new List<ChungTuLog>();
                                string kyhd = "";
                                foreach (var item in dsChungtu)
                                {
                                    if (kyhd == "")
                                        kyhd = (item.HOADON.DM_KYGHI.nam).ToString() + "/" + item.HOADON.DM_KYGHI.thang;
                                    else
                                        kyhd = kyhd + ", " + (item.HOADON.DM_KYGHI.nam).ToString() + "/" + item.HOADON.DM_KYGHI.thang;
                                    var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                                    dslog.Add(new ChungTuLog()
                                    {
                                        id_ct = item.ID_CT,
                                        id_hd = item.ID_HD,
                                        manv = Common.username,
                                        ngaylap = DateTime.Now,
                                        nvid = NVThu,
                                        ngaythu = item.NGAYTHU
                                    });
                                }
                                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                                string ngaythu = DateTime.Parse(chungtuHD.NGAYTAO.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                int tongtien = int.Parse(dsChungtu.Select(x => x.TONGTIEN).Sum().ToString());
                                var khachhang = db.KHACHHANGs.Where(x => x.ID_KH == chungtuHD.ID_KH).FirstOrDefault();
                                string resulttdc = "";
                                // xoa gac no doi tac thu ho
                                if (gachno.Count > 0)
                                {
                                    object[] Arr_result = tdc.ThanhToanHoaDon_HuyGiaoDich("WASS01", hashkey, Common.username, khachhang.madanhbo, gachno.FirstOrDefault().PRODUCTS, kyhd, ngaythu, tongtien, txtlydo.Text);
                                    resulttdc = Arr_result[0].ToString().ToUpper();
                                }
                                // xoa gac no wasspro
                                else
                                {
                                    object[] Arr_result = tdc.ThanhToanHoaDon_HuyGiaoDich("WASS01", hashkey, Common.username, chungtuHD.DANHBO, chungtuHD.GHICHU, kyhd, ngaythu, tongtien, txtlydo.Text);
                                    resulttdc = Arr_result[0].ToString().ToUpper();
                                }
                                // reset trang thai hoa don
                                db.Database.ExecuteSqlCommand("resetTrangThaiHoaDOn " + chungtuHD.ID_KH.ToString() + "," + chungtuHD.ID_CT.ToString());
                                var ds = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtuHD.ID_CT).ToList().Count();
                                if (ds == 0)
                                    db.CHUNGTUs.Remove(db.CHUNGTUs.Where(x => x.ID_CT == chungtuHD.ID_CT).FirstOrDefault());
                                db.ChungTuLogs.AddRange(dslog);
                                db.SaveChanges();
                                MessageBox.Show("Cập nhật thành công!");
                                btnTim.PerformClick();
                                btnTim.PerformClick();
                            }
                            //if (chungtuHD != null && maloai == "CK")
                            //{
                            //    var gachno = db.GACHNOes.Where(x => x.ID_HD == IDHD && x.PRODUCTS != null).ToList();
                            //    if (gachno.Count > 0)
                            //    {
                            //        var dsChungtu = db.CHUNGTU_HOADON.Where(x => x.GHICHU == chungtuHD.GHICHU).ToList();
                            //        List<ChungTuLog> dslog = new List<ChungTuLog>();
                            //        string kyhd = "";
                            //        foreach (var item in dsChungtu)
                            //        {
                            //            if (kyhd == "")
                            //                kyhd = (item.HOADON.DM_KYGHI.nam).ToString() + "/" + item.HOADON.DM_KYGHI.thang;
                            //            else
                            //                kyhd = kyhd + ", " + (item.HOADON.DM_KYGHI.nam).ToString() + "/" + item.HOADON.DM_KYGHI.thang;
                            //            var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                            //            //Business.BusinessService bs = new Business.BusinessService();
                            //            //string result = bs.UnConfirmPaymentFkey(item.ID_HD.ToString(), accWS.acc_service, accWS.pass_service);
                            //            dslog.Add(new ChungTuLog() { id_ct = item.ID_CT, id_hd = item.ID_HD, manv = Common.username, ngaylap = DateTime.Now, nvid = NVThu, ngaythu = item.NGAYTHU });
                            //        }

                            //        //var giaodich = db.GIAODICHes.Where(x => x.GIAODICH_ID == chungtuHD.GIAODICHID).FirstOrDefault();
                            //        string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                            //        ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                            //        string ngaythu = DateTime.Parse(chungtuHD.NGAYTAO.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            //        int tongtien = int.Parse(dsChungtu.Select(x => x.TONGTIEN).Sum().ToString());
                            //        object[] Arr_result = tdc.ThanhToanHoaDon_HuyGiaoDich("WASS01", hashkey, Common.username, chungtuHD.DANHBO, gachno.FirstOrDefault().PRODUCTS, kyhd, ngaythu, tongtien, txtlydo.Text);
                            //        string resulttdc = Arr_result[0].ToString().ToUpper();
                            //        if (resulttdc == "TRUE" || Arr_result[1].ToString() == "")
                            //        {
                            //            db.Database.ExecuteSqlCommand("resetTrangThaiHoaDOn " + chungtuHD.ID_KH.ToString() + "," + chungtuHD.ID_CT.ToString());
                            //            var ds = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtuHD.ID_CT).ToList().Count();
                            //            if (ds == 0)
                            //                db.CHUNGTUs.Remove(db.CHUNGTUs.Where(x => x.ID_CT == chungtuHD.ID_CT).FirstOrDefault());
                            //            db.ChungTuLogs.AddRange(dslog);
                            //            db.SaveChanges();
                            //            GIAODICH ct = new GIAODICH();
                            //            ct.DANHBO = chungtuHD.DANHBO;
                            //            ct.LYDO = txtlydo.Text + " " + gachno.FirstOrDefault().PRODUCTS;
                            //            ct.TONGTIEN = tongtien;
                            //            db.GIAODICHes.Add(ct);
                            //            db.SaveChanges();
                            //            MessageBox.Show("Cập nhật thành công!");
                            //            btnTim.PerformClick();
                            //        }
                            //        else
                            //            MessageBox.Show("Có lỗi xảy ra trong quá trình xử lý, mã lỗi: " + Arr_result[0].ToString() + "-" + Arr_result[1].ToString() + "-" + Arr_result[2].ToString());
                            //        btnTim.PerformClick();
                            //    }

                            //}

                        }
                    }
                }
            }
            //}
            //catch
            //{

            //}
        }
        private string HuyThanhToanVNPTAPP(decimal? IDKH, decimal IDCT)
        {
            string result = "";
            var dsChungtuHD = db.CHUNGTU_HOADON.Where(x => x.ID_KH == IDKH && x.ID_CT == IDCT).ToList();
            if (dsChungtuHD.Count > 0)
            {
                if (maloai == "TT")
                {
                    foreach(var item in dsChungtuHD)
                    {
                        db.gachno_xoaphieuthuapp(item.ID_HD, IDCT);
                    }
                    MessageBox.Show("Hủy đăng ngân thành công, vui lòng vào đăng ngân của nhân viên để hủy thanh toán!");
                   
                }
                else if (maloai == "KH")
                {

                }
            }

            return result;
        }
        //void chkAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    if (chkAll.Checked == true)
        //    {

        //        foreach (DataGridViewRow r in dataGridView1.Rows)
        //        {
        //            r.Cells[chkColumn.Name].Value = true;
        //        }
        //    }
        //    else if (chkAll.Checked == false)
        //    {

        //        foreach (DataGridViewRow r in dataGridView1.Rows)
        //        {
        //            r.Cells[chkColumn.Name].Value = false;
        //        }
        //    }
        //    this.Cursor = Cursors.Default;
        //}

        void btnTim_Click(object sender, EventArgs e)
        {
           
                var nguoidung = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                var tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
                var denngay = dtpDenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
                decimal NHID = decimal.Parse(cboNganhang.SelectedValue.ToString());
                decimal NVLap = decimal.Parse(nguoidung.nv_id.ToString());
                bool isdangngan = false;
                if (chkisdangngan.Checked == true)
                    isdangngan = true;
                int TOID = -1;
                if (Common.ChucvuID != 1 && Common.ChucvuID != 4)
                    NVLap = 0;
                if (maloai == "TT")
                    TOID = int.Parse(cboTO.SelectedValue.ToString());
                var dataSource = db.getDangNganTheoNgay(NHID, 0, tungay, denngay, maloai, "0", isdangngan, NVLap, TOID).ToList();
                if (textBox1.Text != "")
                    dataSource = dataSource.Where(x => x.timkiem.Contains(textBox1.Text.ToUpper().Replace(" ", String.Empty))).ToList();
                //table = ExcelExportHelper.ListToDataTable(dataSource);
                dataGridView1.DataSource = dataSource;
                lblsoluong.Text = "Số lượng HĐ: " + string.Format("{0:n0}", dataGridView1.RowCount);
                lbltongtien.Text = "Tổng tiền:  " + string.Format("{0:n0}", dataSource.ToList().Sum(x => x.tongtien));
         
        }

        private void frDangNganChuyenKhoan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dtpDenngay.Format = DateTimePickerFormat.Custom;
            dtpTungay.Format = DateTimePickerFormat.Custom;
            dtpDenngay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpTungay.CustomFormat = "dd/MM/yyyy";
            // dm ngan hang
            cboNganhang.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NGANHANG> nganhang = new List<DM_NGANHANG>();
            nganhang.Add(new DM_NGANHANG() { NGANHANG_ID = 0, TENNGANHANG = "Tất cả" });
            var dmNganhang = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList();
            nganhang.AddRange(dmNganhang);
            cboNganhang.DataSource = nganhang.ToList();
            cboNganhang.ValueMember = "NGANHANG_ID";
            cboNganhang.DisplayMember = "TENNGANHANG";
            label1.Visible = true;
            cboNganhang.Visible = true;
            lblTo.Visible = false;
            cboTO.Visible = false;
            chkIn.Visible = false;
            chkHuyTT.Visible = Common.isxoa;
            dataGridView1.Columns[ngayBKColumn.Name].Visible = true;
            if(maloai == "KH" || maloai == "TC" || maloai == "GT")
            {
                label1.Text = "Nhân viên thu";
                List<NHANVIEN> dsNhanvien = new List<NHANVIEN>();
                dsNhanvien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
                var nhanvien = (from a in db.NHANVIENs
                                from b in db.CHUNGTUs
                                where a.NV_ID == b.NV_ID_LAP
                                where b.MALOAI == "KH"
                                select a).Distinct().ToList();
                dsNhanvien.AddRange(nhanvien);
                cboNganhang.DataSource = dsNhanvien;
                cboNganhang.ValueMember = "NV_ID";
                cboNganhang.DisplayMember = "Hoten";
                dataGridView1.Columns[nganhangColumn.Name].HeaderText = "Nhân viên thu";
                chkIn.Visible = true;
                dataGridView1.Columns[ngayBKColumn.Name].Visible = false;
            }
            else if (maloai == "TT")
            {
                label1.Text = "Nhân viên thu";
                decimal? TOID = Common.TOID;
                if(TOID == 0)
                    TOID = -1;
                LoadNhanVien(TOID);
                lblTo.Visible = true;
                cboTO.Visible = true;
                LoadTO(TOID);
                dataGridView1.Columns[nganhangColumn.Name].HeaderText = "Nhân viên thu";
                dataGridView1.Columns[ngayBKColumn.Name].Visible = false;
            }
        }
        public void LoadNhanVien(decimal? TOID)
        {
            cboNganhang.DropDownStyle = ComboBoxStyle.DropDownList;
            var data = DataDanhMuc.getDSNhanvien(TOID).Select(x => new { hoten = x.maNV + " - " + x.hoten, x.NV_ID }).ToList();
            cboNganhang.DataSource = data.ToList();
            cboNganhang.DisplayMember = "hoten";
            cboNganhang.ValueMember = "NV_ID";
        }
        public void LoadTO(decimal? TOID)
        {
            cboTO.DropDownStyle = ComboBoxStyle.DropDownList;
            var data = DataDanhMuc.getDSTo(TOID).ToList();
            cboTO.DataSource = data.ToList();
            cboTO.ValueMember = "TO_ID";
            cboTO.DisplayMember = "TENTO";
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                db.XuLyDangNgan();
                MessageBox.Show("Tổng hợp dữ liệu thành công!");
            }
            catch
            {

            }
        }

        private void chkHuyTT_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
