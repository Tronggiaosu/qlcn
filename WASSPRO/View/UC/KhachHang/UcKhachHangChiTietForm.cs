using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class UcKhachHangChiTietForm : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public decimal kh_id = 0;
        QLCongNo.Publish.PublishService ws = new QLCongNo.Publish.PublishService();
        public UcKhachHangChiTietForm()
        {
            InitializeComponent();
        }
        private void KhachHangChiTietForm_Load(object sender, EventArgs e)
        {
            LoadDT();
            LoadHTTT();
            htttcomboBox.SelectedIndex = 2;
            cncomboBox.SelectedIndexChanged -= cncomboBox_SelectedIndexChanged;
            LoadCN();
            cncomboBox.SelectedIndexChanged += cncomboBox_SelectedIndexChanged;
            LoadPhiBVMT();
            LoadNV();
            LoadHieuDH();
            LoadKichCo();
            LoadTrangThai();
            LoadLT();      
            LoadBank();
            if (kh_id > 0)
            {
                //Reset();
                ngaydoiDHdateTimePicker.Enabled = true;
                LoadKhachHang(kh_id);
            }
            else
            {
                addButton.PerformClick();
                ngaydoiDHdateTimePicker.Enabled = false;
            }
        }

        private void LoadBank()
        {
            var bank = from a in db.DM_NGANHANG orderby a.TENNGANHANG select a;
            BankcomboBox.DataSource = bank.ToList();
            BankcomboBox.DisplayMember = "tennganhang";
            BankcomboBox.ValueMember = "idnganhang";
        }
        private void LoadCN()
        {
            var cn = (from a in db.CHINHANHs orderby a.tenCN select a).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("maCN");
            dt.Columns.Add("tenCN");
            dt.Rows.Add(-1, "Tất cả");
            foreach (CHINHANH c in cn)
            {
                dt.Rows.Add(c.maCN, c.tenCN);
            }
            cncomboBox.DataSource = dt;
            cncomboBox.DisplayMember = "tenCN";
            cncomboBox.ValueMember = "maCN";  
        }       
        private void LoadTrangThai()
        {
            var tt = from a in db.DM_TRANGTHAI_KH select a;
            trangthaicomboBox.DataSource = tt.ToList();
            trangthaicomboBox.DisplayMember = "tenTT";
            trangthaicomboBox.ValueMember = "maTT";
        }
        private void LoadKichCo()
        {
            var kc = from a in db.DM_KICHCODH orderby a.MaKC select a;
            kichCocomboBox.DataSource = kc.ToList();
            kichCocomboBox.DisplayMember = "KichCo";
            kichCocomboBox.ValueMember = "maKC";
        }       
        private void LoadNV()
        {
            var nv = from a in db.NHANVIEN_LNV where a.ID_LoaiNV == 3 orderby a.NHANVIEN.hoten select a;
            nguoilapdatcomboBox.DataSource = nv.ToList();
            nguoilapdatcomboBox.DisplayMember = "hoten";
            nguoilapdatcomboBox.ValueMember = "manv";
        }
        private void LoadPhiBVMT()
        {
            var bvmt = from a in db.DM_GiaBVMT orderby a.giaphi select new { giaphi = a.ma_giaBVMT + "-"+a.giaphi, a.ma_giaBVMT};
            bvmtcomboBox.DataSource = bvmt.ToList();
            bvmtcomboBox.DisplayMember = "giaphi";
            bvmtcomboBox.ValueMember = "ma_giaBVMT";
        }            
        private void LoadHTTT()
        {
            var httt = from a in db.DM_HINHTHUCTHANHTOAN orderby a.tenHTTT select a;
            htttcomboBox.DataSource = httt.ToList();
            htttcomboBox.DisplayMember = "tenHTTT";
            htttcomboBox.ValueMember = "maHTTT";
        }
        private void LoadDT()
        {
            var dt = from a in db.DM_DOITUONGSUDUNG orderby a.tenDT select a;
            dtcomboBox.DataSource = dt.ToList();
            dtcomboBox.DisplayMember = "tenDT";
            dtcomboBox.ValueMember = "maDT";
        }
        private void LoadLT()
        {
            var lt = from a in db.LOTRINHs orderby a.MaLT select new { full = a.MaLT + " - " + a.TenLT, a.MaLT, a.maCN };
            if (cncomboBox.Text != "Tất cả")
            {
                string ma = cncomboBox.SelectedValue.ToString();
                lt = from a in lt
                     from b in db.CHINHANHs
                     where a.maCN == ma
                     where a.maCN == b.maCN
                     select new { a.full, a.MaLT, a.maCN };
            }
            ltcomboBox.DataSource = lt.ToList();
            ltcomboBox.DisplayMember = "full";
            ltcomboBox.ValueMember = "maLT";
        }
        private void LoadHieuDH()
        {
            var hieu = from a in db.DM_HIEUDONGHO orderby a.tenhieu select a;
            hieuDHcomboBox.DataSource = hieu.ToList();
            hieuDHcomboBox.DisplayMember = "tenhieu";
            hieuDHcomboBox.ValueMember = "mahieu";
        }
        private void LoadKhachHang(decimal kh_id)
        {
            var kh = (from a in db.KHACHHANGs where a.ID_KH == kh_id select a).FirstOrDefault();
            hotentextBox.Text = kh.hoten_KH;
            diachitextBox.Text = kh.diachi;
            diachitttextBox.Text = kh.diachithanhtoan;
            sdt1textBox.Text = kh.SDT_KH;
            emailtextBox.Text = kh.email;
            msttextBox.Text = kh.MST_KH;
            hdtextBox.Text = kh.sohopdong;
            soNKtextBox.Text = kh.soNK.ToString();
            hokhautextBox.Text = kh.soHK;
            htttcomboBox.SelectedValue = kh.MA_HTTT;
            if ((bool)kh.ischuaxacdinh_NK) xdNKcheckBox.Checked = true;
            else xdNKcheckBox.Checked = false; 
            ltcomboBox.SelectedValue = kh.maLT;
            ghichutextBox.Text = kh.ghichu;
            soTKtextBox.Text = kh.Banknumber;
            tenTKtextBox.Text = kh.bankaccountName;
            daidientextBox.Text = kh.RepresentPerson;
            lienhetextBox.Text = kh.contactperson;
            //Giá nước
            dtcomboBox.SelectedValue = kh.maDT != null ? kh.maDT : "";
            bvmtcomboBox.SelectedValue = kh.ma_giabvmt != null ? kh.ma_giabvmt : "";
            //Đồng hồ
            kichCocomboBox.SelectedValue = kh.MAKC != null ? kh.MAKC : 0;
            serialtextBox.Text = kh.soseri_DH;
            hieuDHcomboBox.SelectedValue = kh.maDH != null ? kh.maDH : 0;
            nguoilapdatcomboBox.SelectedValue = kh.nguoilapdat != null ? kh.nguoilapdat : "";
            ngaylapdatdateTimePicker.Value = kh.ngaylapdat != null ? (DateTime)kh.ngaylapdat : DateTime.Now;
            ngaykiemdinhdateTimePicker.Value = kh.Ngay_Kiemdinh != null ? (DateTime)kh.Ngay_Kiemdinh : DateTime.Now;
            ngaydoiDHdateTimePicker.Value = kh.ngaydoi_DH != null ? (DateTime)kh.ngaydoi_DH : DateTime.Now;
            trangthaicomboBox.SelectedValue = Convert.ToInt32(kh.trangthai);
        }       
        private void dtcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maDT = dtcomboBox.SelectedValue.ToString();
            string giaBVMT = (from a in db.DM_DOITUONGSUDUNG where a.maDT == maDT select a.ma_giaBVMT).FirstOrDefault();
            bvmtcomboBox.SelectedValue = giaBVMT;
        }              
        private void quitButton_Click(object sender, EventArgs e)
        {
         //   this.Close();
        }     
        private void SaveData()
        {
            var kh = (from a in db.KHACHHANGs where a.ID_KH == kh_id select a).FirstOrDefault();
            kh.hoten_KH = hotentextBox.Text;
            kh.diachi = diachitextBox.Text;
            kh.diachithanhtoan = diachitttextBox.Text;
            kh.SDT_KH = sdt1textBox.Text;
            kh.MST_KH = msttextBox.Text;
            kh.email = emailtextBox.Text;
            kh.sohopdong = hdtextBox.Text;
            kh.soNK = Convert.ToInt32(soNKtextBox.Text);
            kh.soHK = hokhautextBox.Text;
            kh.MA_HTTT = htttcomboBox.SelectedValue != null ? Convert.ToInt32(htttcomboBox.SelectedValue) : 0;
            kh.maLT = ltcomboBox.SelectedValue != null ? ltcomboBox.SelectedValue.ToString() : "";
            kh.ghichu = ghichutextBox.Text;
            kh.bankaccountName = tenTKtextBox.Text;
            kh.Banknumber = soTKtextBox.Text;
            //Giá nước
            kh.maDT = dtcomboBox.SelectedValue != null ? dtcomboBox.SelectedValue.ToString() : "";
            kh.ma_giabvmt = bvmtcomboBox.SelectedValue != null ? bvmtcomboBox.SelectedValue.ToString() : "";
            //Đồng hồ
            kh.MAKC = kichCocomboBox.SelectedValue != null ? Convert.ToInt32(kichCocomboBox.SelectedValue) : 0;
            kh.soseri_DH = serialtextBox.Text;
            kh.maDH = hieuDHcomboBox.SelectedValue != null ? Convert.ToInt32(hieuDHcomboBox.SelectedValue) : 0;
            kh.nguoilapdat = nguoilapdatcomboBox.SelectedValue != null ? nguoilapdatcomboBox.SelectedValue.ToString() : "";
            kh.ngaylapdat = ngaylapdatdateTimePicker.Value;
            kh.Ngay_Kiemdinh = ngaykiemdinhdateTimePicker.Value;
            kh.ngaydoi_DH = ngaydoiDHdateTimePicker.Value;
            kh.trangthai = Convert.ToInt32(trangthaicomboBox.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Cập nhật thành công!", "Thông báo");
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (addButton.Text == "Thêm")
            {
                addButton.Text = "Lưu";
                Reset();
                ngaydoiDHdateTimePicker.Enabled = false;
                ngaykiemdinhdateTimePicker.Enabled = false;
                ngaylapdatdateTimePicker.Enabled = false;
            }
            else
            {                
                AddData();
            }           
        }
        private void AddData()
        {
            try
            {
                if (!DataOK()) return;
                KHACHHANG kh = new KHACHHANG();
                string malt = ltcomboBox.SelectedValue.ToString();
                kh.maLT = malt;
                kh.madanhbo = "1";
                var countKH = from a in db.KHACHHANGs where a.maLT == malt select a;
                kh.stt_thu = countKH.Count() + 1;
                kh.stt_ghi = countKH.Count() + 1;
                if (xdNKcheckBox.Checked) kh.ischuaxacdinh_NK = true;
                else kh.ischuaxacdinh_NK = false;
                kh.hoten_KH = hotentextBox.Text;
                kh.diachi = diachitextBox.Text;
                kh.diachithanhtoan = diachitttextBox.Text;
                kh.SDT_KH = sdt1textBox.Text;
                kh.MST_KH = msttextBox.Text;
                kh.email = emailtextBox.Text;
                kh.sohopdong = hdtextBox.Text;
                kh.soNK = soNKtextBox.Text != "0" ? Convert.ToInt32(soNKtextBox.Text) : 0;
                string shk = hokhautextBox.Text.Trim();
                if (shk != "")
                {
                    var hk = (from a in db.KHACHHANGs where a.soHK == shk select a).FirstOrDefault();
                    if (hk != null)
                    {
                        MessageBox.Show("Hộ khẩu này đã có trong hệ thống!");
                    }
                    kh.soHK = shk;
                }

                kh.MA_HTTT = htttcomboBox.SelectedValue != null ? Convert.ToInt32(htttcomboBox.SelectedValue) : 0;
                //kh.MA_NN = nganhnghecomboBox.SelectedValue != null ? Convert.ToInt32(nganhnghecomboBox.SelectedValue) : 0;
                kh.NganhNghe = txtNganhNghe.Text;
                kh.ghichu = ghichutextBox.Text;
                kh.bankaccountName = tenTKtextBox.Text;
                kh.nganhang_id = Convert.ToDecimal(BankcomboBox.SelectedValue);
                kh.Banknumber = soTKtextBox.Text;
                kh.contactperson = lienhetextBox.Text;
                kh.RepresentPerson = daidientextBox.Text;
                //Giá nước
                kh.maDT = dtcomboBox.SelectedValue != null ? dtcomboBox.SelectedValue.ToString() : "";
                kh.ma_giabvmt = bvmtcomboBox.SelectedValue != null ? bvmtcomboBox.SelectedValue.ToString() : "";
                //Đồng hồ
                kh.MAKC = kichCocomboBox.SelectedValue != null ? Convert.ToInt32(kichCocomboBox.SelectedValue) : 0;
                kh.soseri_DH = serialtextBox.Text;
                kh.maDH = hieuDHcomboBox.SelectedValue != null ? Convert.ToInt32(hieuDHcomboBox.SelectedValue) : 0;
                kh.nguoilapdat = nguoilapdatcomboBox.SelectedValue != null ? nguoilapdatcomboBox.SelectedValue.ToString() : "";
                kh.ViTri_LD = txtViTriLD.Text;
                if (checkBox1.Checked)
                {
                    kh.ngaylapdat = ngaylapdatdateTimePicker.Value;
                    kh.Ngay_Kiemdinh = ngaylapdatdateTimePicker.Value.AddYears(5);
                }

                kh.trangthai = 0; // 1 ngưng nước, 0 mở, 3 tạo mới
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
                //Cập nhật stt danh bộ
                string lt = ltcomboBox.SelectedValue.ToString();
                var obj = (from a in db.LOTRINHs where a.MaLT == lt select a).FirstOrDefault();
                obj.STT = countKH.Count() + 1;
                db.SaveChanges();
                //Tạo yêu cầu lắp mới
                YEUCAU yc = new YEUCAU();
                yc.ngayYC = DateTime.Now;
                yc.ngaytao = DateTime.Now;
                yc.nguoitao = Common.username;
                yc.maloai_yc = "LAP";
                yc.TTYC_ID = 1;               
                //Lấy IDKH vừa tạo
                var kh_just_add = (from a in db.KHACHHANGs orderby a.ID_KH descending select a).FirstOrDefault();
                yc.ID_KH = kh_just_add.ID_KH;
                db.YEUCAUs.Add(yc);
                db.SaveChanges();
                //Lấy acc, pass của webservice
                var info = (from a in db.TAIKHOAN_SERVICE select a).FirstOrDefault();
                string acc_service = info.acc_service;
                string pass_service = info.pass_service;               
                //Cập nhật HĐĐT
                var id = new SqlParameter("@id_kh", kh_just_add.ID_KH);
                var xml = (db.Database.SqlQuery<string>("exec sp_updateCus @id_kh", id)).ToList();
                string xmlCusData = xml.FirstOrDefault().ToString();
                int result = ws.UpdateCus(xmlCusData, acc_service, pass_service, 0);
                if (result != 1) MessageBox.Show("Đồng bộ hóa đơn điện tử thất bại!");              
                MessageBox.Show("Thêm mới thành công!", "Thông báo");
                addButton.Text = "Thêm";
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
        private bool DataOK()
        {
            if (hotentextBox.Text=="")
            {
                MessageBox.Show("Chưa có họ tên khách hàng!", "Thông báo");
                hotentextBox.Focus();
                return false;
            }
            
            // if (soNKtextBox.Text=="")
            //{
            //    MessageBox.Show("Chưa có số nhân khẩu!", "Thông báo");
            //    soNKtextBox.Focus();
            //    return false;
            //}
          
            if (hokhautextBox.Text == "")
            {
                MessageBox.Show("Chưa có thông tin hộ khẩu của khách hàng!", "Thông báo");
                return false;
            }
            else
            {
                var hokhau = from a in db.KHACHHANGs where a.soHK == hokhautextBox.Text select a;
                if (hokhau.FirstOrDefault() != null)
                {
                    MessageBox.Show("Hộ khẩu của khách hàng đã tồn tại!", "Thông báo");
                    return false;
                }
            }
            if (sdt1textBox.Text != "" && sdt1textBox.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại của khách hàng sai!", "Thông báo");
                return false;
            }
            return true;
        }
        private void Reset()
        {
            hotentextBox.Text = "";
            diachitextBox.Text = "";
            diachitttextBox.Text = "";
            sdt1textBox.Text = "";
            msttextBox.Text = "";
            emailtextBox.Text = "";
            hdtextBox.Text = "";
            soNKtextBox.Text = "0";
            hokhautextBox.Text = "";            
            ghichutextBox.Text = "";
            xdNKcheckBox.Checked = false;
            //Đồng hồ
            serialtextBox.Text = "";
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            addButton.Enabled = true;
            addButton.Text = "Thêm";
            Reset();
        }
       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ngaylapdatdateTimePicker.Enabled = true;
                ngaykiemdinhdateTimePicker.Value = DateTime.Now.AddYears(5);
            }
            else ngaylapdatdateTimePicker.Enabled = false;
        }

        private void sdt1textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void soNKtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void giaThueDHtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLT();
        } 
    }
}
