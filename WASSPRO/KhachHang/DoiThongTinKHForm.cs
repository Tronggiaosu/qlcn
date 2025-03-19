using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class DoiThongTinKHForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public decimal id_kh = 0;
        KHACHHANG kh;
        QLCongNo.Publish.PublishService ws = new QLCongNo.Publish.PublishService();
        public DoiThongTinKHForm()
        {
            InitializeComponent();
        }
        private void DoiThongTinKHForm_Load(object sender, EventArgs e)
        {
            LoadHTTT();
            LoadNN();
                  
            //LoadCTy();
            //LoadCN();
            LoadLT();
            LoadPhiBVMT();
            LoadKichCo();
            LoadNV();
            LoadTrangThai();
            LoadHieuDH();
            LoadBank();
            if (id_kh > 0) LoadKhachHangByID(id_kh);
        }

        private void LoadBank()
        {
            var bank = from a in db.DM_NGANHANG orderby a.TENNGANHANG select a;
            BankcomboBox.DataSource = bank.ToList();
            BankcomboBox.DisplayMember = "tennganhang";
            BankcomboBox.ValueMember = "idnganhang";
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
        private void LoadKichCo()
        {
            var kc = from a in db.DM_KICHCODH orderby a.MaKC select a;
            kichCocomboBox.DataSource = kc.ToList();
            kichCocomboBox.DisplayMember = "KichCo";
            kichCocomboBox.ValueMember = "maKC";
        }
        private void LoadNV()
        {
            var nv = from a in db.NHANVIEN_LNV where a.ID_LoaiNV == 3 orderby a.NHANVIEN.hoten select a.NHANVIEN;
            nguoilapdatcomboBox.DataSource = nv.ToList();
            nguoilapdatcomboBox.DisplayMember = "hoten";
            nguoilapdatcomboBox.ValueMember = "manv";
        }       
        private void LoadLT()
        {
            var lt = from a in db.LOTRINHs orderby a.MaLT select new { full = a.MaLT + " - " + a.TenLT, a.TenLT };           
            lt2comboBox.DataSource = lt.ToList();
            lt2comboBox.DisplayMember = "full";
            lt2comboBox.ValueMember = "maLT";
        }
        //private void LoadCN()
        //{
        //    var cn = from a in db.CHINHANHs select a;
        //    cncomboBox.DataSource = cn.ToList();
        //    cncomboBox.DisplayMember = "tenCN";
        //    cncomboBox.ValueMember = "maCN";
        //}
        //private void LoadCTy()
        //{
        //    var cty = from a in db.CONGTies select a;
        //    ctycomboBox.DataSource = cty.ToList();
        //    ctycomboBox.DisplayMember = "tenCTY";
        //    ctycomboBox.ValueMember = "maCTY";
        //}
        private void LoadPhiBVMT()
        {
            var bvmt = from a in db.DM_GiaBVMT orderby a.giaphi select new { giaphi = a.ma_giaBVMT + "-" + a.giaphi, a.ma_giaBVMT }; 
            bvmt2comboBox.DataSource = bvmt.ToList();
            bvmt2comboBox.DisplayMember = "giaphi";
            bvmt2comboBox.ValueMember = "ma_giaBVMT";
        }       
    
        private void LoadKhachHangByID(decimal id_kh)
        {
            kh = (from a in db.KHACHHANGs where a.ID_KH == id_kh select a).FirstOrDefault();
            if (kh != null)
            {
                id_kh = kh.ID_KH;
                hotentextBox.Text = kh.hoten_KH;               
                maDBtextBox.Text = kh.ID_KH.ToString();               
                // Thông tin cần đổi
                lt2comboBox.SelectedValue = kh.maLT;
                hoten2textBox.Text = kh.hoten_KH;
                diachi2textBox.Text = kh.diachi;
                diachitt2textBox.Text = kh.diachithanhtoan;
                sdt2textBox.Text = kh.SDT_KH;
                email2textBox.Text = kh.email;
                mst2textBox.Text = kh.MST_KH;
                hd2textBox.Text = kh.sohopdong;
                soNK2textBox.Text = kh.soNK.ToString();
                hokhau2textBox.Text = kh.soHK;
                httt2comboBox.SelectedValue = kh.MA_HTTT;
                doituong2comboBox.SelectedValue = kh.maDT;                
                ghichu2textBox.Text = kh.ghichu;
                soTK2textBox.Text = kh.Banknumber;
                tenTK2textBox.Text = kh.bankaccountName;
                BankcomboBox.SelectedValue = kh.nganhang_id != null ? kh.nganhang_id : 0;
                daidien2textBox.Text = kh.RepresentPerson;
                lienhe2textBox.Text = kh.contactperson;
                bvmt2comboBox.SelectedValue = kh.ma_giabvmt != null ? kh.ma_giabvmt : "";
                //Đồng hồ
                kichCocomboBox.SelectedValue = kh.MAKC;
                serialtextBox.Text = kh.soseri_DH;
                hieuDHcomboBox.SelectedValue = kh.maDH;
                ngaylapdatdateTimePicker.Value = kh.ngaylapdat!= null? (DateTime)kh.ngaylapdat:DateTime.Now;
                if (kh.ngaylapdat == null) ngaylapdatdateTimePicker.Visible = false;
                trangthaicomboBox.SelectedValue = kh.trangthai;
                ngaydoiDHdateTimePicker.Value = kh.ngaydoi_DH != null? (DateTime)kh.ngaydoi_DH:DateTime.Now;
                if (kh.ngaydoi_DH == null) ngaydoiDHdateTimePicker.Visible = false;
                ngaykiemdinhdateTimePicker.Value = kh.Ngay_Kiemdinh!= null?(DateTime)kh.Ngay_Kiemdinh:DateTime.Now;
                if (kh.Ngay_Kiemdinh == null) ngaykiemdinhdateTimePicker.Visible = false;
                txtViTriLD.Text = kh.ViTri_LD;
            }
        }
        private void LoadNN()
        {
            var nn = from a in db.DM_DOITUONGSUDUNG orderby a.tenDT select a;           
            doituong2comboBox.DataSource = nn.ToList();
            doituong2comboBox.DisplayMember = "tenDT";
            doituong2comboBox.ValueMember = "maDT";
        }
        private void LoadHTTT()
        {
            var httt = from a in db.DM_HINHTHUCTHANHTOAN orderby a.tenHTTT select a;           
            httt2comboBox.DataSource = httt.ToList();
            httt2comboBox.DisplayMember = "tenHTTT";
            httt2comboBox.ValueMember = "maHTTT";
        }       
        private void maDBtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadKhachHangByID(Convert.ToDecimal(maDBtextBox.Text));
            }
        }
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (editButton.Text == "Đổi thông tin")
                {
                    editButton.Text = "Lưu lại";
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;                 
                    chkEdit.Checked = false;
                    groupBox1.Enabled = false;
                }
                else
                {
                    editButton.Text = "Đổi thông tin";
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    //Tạo YEUCAU, cập nhật KHACHHANG
                    YEUCAU yc = new YEUCAU();
                    yc.ngayYC = DateTime.Now;
                    yc.ngayHT = DateTime.Now;
                    yc.ngaytao = DateTime.Now;
                    yc.nguoitao = Common.username;
                    yc.nguoilapdat = Common.username;
                    yc.maloai_yc = "DTT";
                    yc.TTYC_ID = 4;
                    yc.ID_KH = id_kh;
                    db.YEUCAUs.Add(yc);   
                    db.SaveChanges();
                    //Cập nhật BD_KHACHHANG
                    yc = (from a in db.YEUCAUs where a.ID_KH == id_kh orderby a.ID_yeucau descending select a).FirstOrDefault();
                    decimal id_yc = yc.ID_yeucau;
                    BD_KHACHHANG bd_kh = new BD_KHACHHANG();
                    //bd_kh.ID_yeucau = id_yc;
                    bd_kh.ID_KH = id_kh;
                    //Đổi lộ trình
                    if (lt2comboBox.SelectedValue.ToString() != kh.maLT)
                    {                       
                        string malt = lt2comboBox.SelectedValue.ToString();
                        yc.maLT = malt;
                        bd_kh.maLT = kh.maLT;
                        kh.maLT = malt;                       
                        var countKH = from a in db.KHACHHANGs where a.maLT == malt select a;
                        kh.stt_thu = countKH.Count() + 1;
                        kh.stt_ghi = countKH.Count() + 1;
                     
                        //Cập nhật bảng PublishedInvoices, HOADON và CHISONUOC
                        db.Database.ExecuteSqlCommand("UPDATE PublishedInvoices SET ma_tuyen_cuoc='" + malt + "' WHERE IDKH="+id_kh);
                        db.Database.ExecuteSqlCommand("UPDATE HOADON SET MaLT='" + malt + "' WHERE ID_KH=" + id_kh);
                    }                   
                    if (hoten2textBox.Text != hotentextBox.Text)
                    {
                        yc.hoten_KH = hoten2textBox.Text;
                        bd_kh.hoten_KH = kh.hoten_KH;
                        kh.hoten_KH = hoten2textBox.Text;
                    }
                    if (doituong2comboBox.SelectedValue.ToString() != kh.maDT)
                    {
                        yc.maDT = doituong2comboBox.SelectedValue.ToString();
                        kh.maDT = doituong2comboBox.SelectedValue.ToString();
                    }
                    //yc.MA_NN = Convert.ToInt32(cboNganhNghe.SelectedValue);
                    //kh.MA_NN = Convert.ToInt32(cboNganhNghe.SelectedValue);
                    kh.NganhNghe = txtNganhNghe.Text;
                    if (bvmt2comboBox.SelectedValue.ToString() != kh.ma_giabvmt)
                    {
                        yc.ma_giabvmt = bvmt2comboBox.SelectedValue.ToString();
                        kh.ma_giabvmt = bvmt2comboBox.SelectedValue.ToString();
                    }
                    if (mst2textBox.Text != kh.MST_KH)
                    {
                        yc.MST_KH = mst2textBox.Text;
                        kh.MST_KH = mst2textBox.Text;
                    }
                    if (hd2textBox.Text != kh.sohopdong)
                    {
                        yc.sohopdong = hd2textBox.Text;
                        bd_kh.sohopdong = kh.sohopdong;
                        kh.sohopdong = hd2textBox.Text;
                    }
                    if (sdt2textBox.Text != kh.SDT_KH)
                    {
                        yc.SDT_KH = sdt2textBox.Text;
                        bd_kh.SDT_KH = kh.SDT_KH;
                        kh.SDT_KH = sdt2textBox.Text;
                    }
                    if (diachi2textBox.Text != kh.diachi)
                    {
                        yc.diachi = diachi2textBox.Text;
                        bd_kh.diachi = kh.diachi;
                        kh.diachi = diachi2textBox.Text;
                    }
                    if (diachitt2textBox.Text != kh.diachithanhtoan)
                    {
                        yc.diachithanhtoan = diachitt2textBox.Text;
                        bd_kh.diachithanhtoan = kh.diachithanhtoan;
                        kh.diachithanhtoan = diachitt2textBox.Text;
                    }
                    if (Convert.ToDecimal(httt2comboBox.SelectedValue) != kh.MA_HTTT)
                    {
                        yc.MA_HTTT = Convert.ToInt32(httt2comboBox.SelectedValue);
                        bd_kh.MA_HTTT = kh.MA_HTTT;
                        kh.MA_HTTT = Convert.ToInt32(httt2comboBox.SelectedValue);
                    }
                    int soNK = Convert.ToInt32(soNK2textBox.Text);
                    if (soNK != kh.soNK)
                    {
                        yc.soNK = soNK;
                        bd_kh.soNK = kh.soNK;
                        kh.soNK = soNK;
                    }
                    if (hokhau2textBox.Text != kh.soHK)
                    {
                        yc.soHK = hokhau2textBox.Text;
                        bd_kh.soHK = kh.soHK;
                        kh.soHK = hokhau2textBox.Text;
                    }
                    if (email2textBox.Text != kh.email)
                    {
                        bd_kh.email = kh.email;
                        kh.email = email2textBox.Text;
                    }
                    if (soTK2textBox.Text != kh.Banknumber)
                    {                        
                        kh.Banknumber = soTK2textBox.Text;
                    }
                    if (Convert.ToDecimal(BankcomboBox.SelectedValue) != kh.nganhang_id)
                    {
                        kh.nganhang_id = Convert.ToDecimal(BankcomboBox.SelectedValue);
                    }
                    if (tenTK2textBox.Text != kh.bankaccountName)
                    {
                        kh.bankaccountName = tenTK2textBox.Text;
                    }
                    if (ghichu2textBox.Text != kh.ghichu)
                    {
                        yc.ghichu = ghichu2textBox.Text;
                        kh.ghichu = ghichu2textBox.Text;
                    }
                    if (daidien2textBox.Text != kh.RepresentPerson)
                    {
                        kh.RepresentPerson = daidien2textBox.Text;
                    }
                    if (lienhe2textBox.Text != kh.contactperson)
                    {
                        kh.contactperson = lienhe2textBox.Text;
                    }
                    decimal thueDH = Convert.ToDecimal(giaThueDHtextBox.Text);         
                    //Đồng hồ
                    kh.MAKC = kichCocomboBox.SelectedValue != null ? Convert.ToInt32(kichCocomboBox.SelectedValue) : 0;
                    kh.soseri_DH = serialtextBox.Text;
                    kh.maDH = hieuDHcomboBox.SelectedValue != null ? Convert.ToInt32(hieuDHcomboBox.SelectedValue) : 0;
                    //kh.nguoilapdat = nguoilapdatcomboBox.SelectedValue != null ? nguoilapdatcomboBox.SelectedValue.ToString() : "";
                    kh.ViTri_LD = txtViTriLD.Text;
                    kh.trangthai = Convert.ToInt32(trangthaicomboBox.SelectedValue);
                    if (chkEdit.Checked)
                    {
                        kh.ngaydoi_DH = ngaydoiDHdateTimePicker.Value;
                        kh.Ngay_Kiemdinh = ngaydoiDHdateTimePicker.Value.AddYears(5);
                    }
                    if (chkEditNgayLD.Checked)
                    {
                        kh.ngaylapdat = ngaylapdatdateTimePicker.Value;
                        kh.Ngay_Kiemdinh = ngaylapdatdateTimePicker.Value.AddYears(5);
                    }                                                    
                    db.BD_KHACHHANG.Add(bd_kh);
                    db.SaveChanges();
                    //Cập nhật HĐĐT
                    var id = new SqlParameter("@id_kh", id_kh);
                    var xml = (db.Database.SqlQuery<string>("exec sp_updateCus @id_kh", id)).ToList();                   
                    string xmlCusData = xml.FirstOrDefault().ToString();
                    //Lấy acc, pass của webservice
                    var info = (from a in db.TAIKHOAN_SERVICE select a).FirstOrDefault();
                    string acc = info.acc_service;
                    string pass = info.pass_service;
                    int result = ws.UpdateCus(xmlCusData, acc, pass, 0);
                    if (result < 1)
                    {
                        MessageBox.Show("Đồng bộ lên hệ thống hóa đơn điện tử thất bại!");
                        return;
                    }
                    MessageBox.Show("Cập nhật biến động thành công!", "Thông báo");
                    LoadKhachHangByID(id_kh); 
                }
            //}
            //catch { }
        }
        private void seachButton_Click(object sender, EventArgs e)
        {
            LoadKhachHangByID(Convert.ToDecimal(maDBtextBox.Text));
        }
        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEdit.Checked) ngaydoiDHdateTimePicker.Visible = true;
            else ngaydoiDHdateTimePicker.Visible = false;
        }

        private void chkEditNgayLD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditNgayLD.Checked) ngaylapdatdateTimePicker.Visible = true;
            else ngaylapdatdateTimePicker.Visible = false;
        }

        private void soNK2textBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sdt2textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
