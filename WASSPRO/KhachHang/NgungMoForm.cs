using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class NgungMoForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public decimal id_kh = 0;
        public NgungMoForm()
        {
            InitializeComponent();
        }

        private void NgungMoForm_Load(object sender, EventArgs e)
        {
            LoadHTTT();
            LoadLT();
            LoadNN();
            LoadNV();
            LoadHieuDH();
            LoadKichCo();
            LoadTrangThai();
            if (id_kh > 0) LoadKhachHangByID(id_kh);
        }

        private void LoadKhachHangByID(decimal id_kh)
        {
            var kh = (from a in db.KHACHHANGs where a.ID_KH == id_kh select a).FirstOrDefault();
            if (kh != null)
            {
                hotentextBox.Text = kh.hoten_KH;
                diachitextBox.Text = kh.diachi;
                diachitttextBox.Text = kh.diachithanhtoan;
                sdt1textBox.Text = kh.SDT_KH;
                msttextBox.Text = kh.MST_KH;
                maDBtextBox.Text = kh.madanhbo;
                hdtextBox.Text = kh.sohopdong;
                soNKtextBox.Text = kh.soNK.ToString();
                hokhautextBox.Text = kh.soHK;
                htttcomboBox.SelectedValue = kh.MA_HTTT;
                nganhnghecomboBox.SelectedValue = kh.MA_NN != null ? kh.MA_NN : 0;
                ltcomboBox.SelectedValue = kh.maLT;
                ghichutextBox.Text = kh.ghichu;
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
            var nv = from a in db.NHANVIENs orderby a.hoten select a;
            nguoilapdatcomboBox.DataSource = nv.ToList();
            nguoilapdatcomboBox.DisplayMember = "hoten";
            nguoilapdatcomboBox.ValueMember = "manv";
        }
        private void LoadNN()
        {
            var nn = from a in db.DM_NGANHNGHE orderby a.Ten_NN select a;
            nganhnghecomboBox.DataSource = nn.ToList();
            nganhnghecomboBox.DisplayMember = "ten_NN";
            nganhnghecomboBox.ValueMember = "ma_NN";
        }
        private void LoadHTTT()
        {
            var httt = from a in db.DM_HINHTHUCTHANHTOAN orderby a.tenHTTT select a;
            htttcomboBox.DataSource = httt.ToList();
            htttcomboBox.DisplayMember = "tenHTTT";
            htttcomboBox.ValueMember = "maHTTT";
        }
        private void LoadLT()
        {
            var lt = from a in db.LOTRINHs orderby a.TenLT select a;
            ltcomboBox.DataSource = lt.ToList();
            ltcomboBox.DisplayMember = "tenLT";
            ltcomboBox.ValueMember = "maLT";
        }
        private void LoadHieuDH()
        {
            var hieu = from a in db.DM_HIEUDONGHO orderby a.tenhieu select a;
            hieuDHcomboBox.DataSource = hieu.ToList();
            hieuDHcomboBox.DisplayMember = "tenhieu";
            hieuDHcomboBox.ValueMember = "mahieu";
        }
        private void LoadTrangThai()
        {
            var tt = from a in db.DM_TRANGTHAI_KH select a;
            trangthaicomboBox.DataSource = tt.ToList();
            trangthaicomboBox.DisplayMember = "tenTT";
            trangthaicomboBox.ValueMember = "maTT";
        }
        private void LoadKhachHang(string mdb)
        {
            var kh = (from a in db.KHACHHANGs where a.madanhbo == mdb select a).FirstOrDefault();
            if (kh != null)
            {
                id_kh = kh.ID_KH;
                hotentextBox.Text = kh.hoten_KH;
                diachitextBox.Text = kh.diachi;
                diachitttextBox.Text = kh.diachithanhtoan;
                sdt1textBox.Text = kh.SDT_KH;
                msttextBox.Text = kh.MST_KH;
                maDBtextBox.Text = kh.madanhbo;
                hdtextBox.Text = kh.sohopdong;
                soNKtextBox.Text = kh.soNK.ToString();
                hokhautextBox.Text = kh.soHK;
                htttcomboBox.SelectedValue = kh.MA_HTTT;
                nganhnghecomboBox.SelectedValue = kh.MA_NN != null ? kh.MA_NN : 0;
                ltcomboBox.SelectedValue = kh.maLT;
                ghichutextBox.Text = kh.ghichu;
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
            else MessageBox.Show("Không tìm thấy thông tin!", "Thông báo");
        }
        private void maDBtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadKhachHang(maDBtextBox.Text);
            }
        }
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void seachButton_Click(object sender, EventArgs e)
        {
            LoadKhachHang(maDBtextBox.Text);
        }

        private void ngungButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Tạo yêu cầu
                YEUCAU yc = new YEUCAU();
                yc.ngayYC = DateTime.Now;
                yc.ngaytao = DateTime.Now;
                yc.nguoitao = Common.username;
                yc.maloai_yc = "NGUNG";
                yc.ID_KH = id_kh;
                yc.TTYC_ID = 1;
                db.YEUCAUs.Add(yc);
                db.SaveChanges();
                MessageBox.Show("Tạo yêu cầu ngưng nước thành công!", "Thông báo");
            }
            catch { }
        }

        private void moButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Tạo yêu cầu
                YEUCAU yc = new YEUCAU();
                yc.ngayYC = DateTime.Now;
                yc.ngaytao = DateTime.Now;
                yc.nguoitao = Common.username;
                yc.maloai_yc = "MO";
                yc.TTYC_ID = 1;
                yc.ID_KH = id_kh;
                db.YEUCAUs.Add(yc);
                db.SaveChanges();
                MessageBox.Show("Tạo yêu cầu mở nước thành công!", "Thông báo");
            }
            catch { }
        }
    }
}
