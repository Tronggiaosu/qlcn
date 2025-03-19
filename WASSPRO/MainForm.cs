using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.DangNgan;
using QLCongNo.DanhMuc;
using QLCongNo.FORM;
using QLCongNo.GachNo;
using QLCongNo.HoaDon;
//using QLCongNo.HoaDonGiay;
using QLCongNo.LoTrinhThu;
using QLCongNo.ReportViewer.BaoCao;
using QLCongNo.ReportViewer.DataSource;

namespace QLCongNo
{
    public partial class MainForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.IsMdiContainer = true;
            UserRight();
            usernametoolStripStatusLabel.Text = Common.username;
            datetimetoolStripStatusLabel.Text = DateTime.Now.ToString();
            //Lấy tên công ty
            var tenCTY = (from a in db.CONGTies select a).FirstOrDefault();
            this.Text += tenCTY.tenCTY;
            //Version
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = " " + fvi.FileVersion;
            this.Text += version;
            this.Text = "Cấp nước Thủ Đức - Ứng dụng Quản Lý Công Nợ";
        }
        public void EnabaleMenu( bool checks){
            menuStrip.Enabled = checks;
        }

        private void UserRight()
        {
            if (Common.username != "vnptcto")
            {
                var quyen = from a in db.NGUOIDUNGs 
                            from b in db.NGUOIDUNG_QUYEN
                            where a.ma_nd == Common.username 
                            where a.nguoidung_id==b.nguoidung_id
                            select b.quyen_id;
                if (quyen.Count() == 0) return;
                foreach (decimal nd_q in quyen.ToList())
                {
                    var menuList = from m in db.QUYEN_MENU where m.quyen_id == nd_q select m.ten_menu;
                    foreach (string name in menuList.ToList())
                        foreach (ToolStripMenuItem menuItem in menuStrip.Items)
                        {
                            if (menuItem.Text == name)
                            {
                                menuItem.Visible = false;
                                break;
                            }
                            if (menuItem.HasDropDownItems)
                                SetToolStripMenuItem(menuItem, name);
                        }
                }
            }
        }

        private void SetToolStripMenuItem(ToolStripMenuItem menuItem, string name)
        {
            foreach (ToolStripItem tsi in menuItem.DropDownItems)
            {
                if (tsi is ToolStripDropDownItem)
                {
                    if (tsi.Text == name)
                    {
                        tsi.Visible = false;
                        break;
                    }
                    if ((tsi as ToolStripDropDownItem).HasDropDownItems)
                        SetDropDownToolStripMenuItem(tsi, name);
                }
            }
        }

        private void SetDropDownToolStripMenuItem(ToolStripItem menuToolStrip, string name)
        {
            foreach (ToolStripItem menuDropDown in (menuToolStrip as ToolStripDropDownItem).DropDownItems)
            {
                if (menuDropDown is ToolStripDropDownItem)
                {
                    if (menuDropDown.Text == name)
                    {
                        menuDropDown.Visible = false;
                        break;
                    }
                    if ((menuDropDown as ToolStripDropDownItem).HasDropDownItems)
                        SetDropDownToolStripMenuItem(menuDropDown, name);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thayĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassForm frm = new ChangePassForm();
            frm.MdiParent = this;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void mnuNhom_Click(object sender, EventArgs e)
        {
            GroupForm frm = new GroupForm();
            frm.MdiParent = this;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVienForm frm = new NhanVienForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void mnuNguoiDung_Click(object sender, EventArgs e)
        {
            UserForm frm = new UserForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void mnuPhanQuyen_Click(object sender, EventArgs e)
        {
            PhanQuyenForm frm = new PhanQuyenForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frCapNhatThongTinKH frm = new frCapNhatThongTinKH();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đổiĐồngHồToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiDHForm frm = new DoiDHForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đổiĐịaChỉThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DoiThongTinKHForm frm = new DoiThongTinKHForm();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }      

        private void theoDõiGhiChúToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //GhiChuForm frm = new GhiChuForm();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void kiểmTraĐồngHồToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KiemTraForm frm = new KiemTraForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void quảnLýYêuCầuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frKhachHang frm = new frKhachHang();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void ngưngMởChủĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NgungMoForm frm = new NgungMoForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }


        private void sửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuaChuaForm frm = new SuaChuaForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void thanhLýHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThanhLyForm frm = new ThanhLyForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void bảngGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frBanggia frm = new frBanggia();
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.Manual;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }






    

        private void đốiTượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frDoituongSD frm = new frDoituongSD();
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.Manual;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

       

        private void thốngKêYêuCầuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TKYCForm frm = new TKYCForm();
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.Manual;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void kỳGhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KyGhi frm = new KyGhi();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void chỉSốNướcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //GhiChiSo frm = new GhiChiSo();
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.Manual;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void tínhCướcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TinhCuoc frm = new TinhCuoc();
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.Manual;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void theoDõiNgưngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TKNoForm frm = new TKNoForm();
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.Manual;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void quittoolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     

        private void gạchNợTạiQuầyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGachNoNV frm = new frGachNoNV();
            frm.Text = "DANH SÁCH BIÊN NHẬN NHÂN VIÊN THU TRỰC TIẾP";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

       

        private void gạchNợQuaNgânHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frBienNhan frm = new frBienNhan();
            //frm.maloai = "CK";
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void thốngKêĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TKLogUserForm frm = new TKLogUserForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void doanhThuTheoLộTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frThongkeDT_LT frm = new frThongkeDT_LT();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void theoDõiGhiChúTừMobileAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GhiChuForm frm = new GhiChuForm();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void ghiChúMobileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DMGhiChuForm frm = new DMGhiChuForm();
            frm.MdiParent = this;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void phátHànhHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frPhatHanhHD frm = new frPhatHanhHD();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

     
        private void doanhThuTheoLộTrìnhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frThongkeDT_LT frm = new frThongkeDT_LT();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frQLHoaDonDieuChinh frm = new frQLHoaDonDieuChinh();
            frm.MdiParent = this;
            frm.trangthai_id = 8;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void điềuChỉnhHóaĐơnĐãPHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frDieuChinhHoaDon frm = new frDieuChinhHoaDon();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void hủyHóaĐơnĐãPHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HuyHDForm frm = new HuyHDForm();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void gạchNợTạiQuầyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frGachNoKH frm = new frGachNoKH();
            frm.maloai = "KH";
            frm.trangthai = 0;
            frm.Text = "KHÁCH HÀNG THU TẠI QUẦY";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void gạchNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGachNoKH frm = new frGachNoKH();
            frm.maloai = "CK";
            frm.Text = "DANH SÁCH BIÊN NHẬN KHÁCH HÀNG CHUYỂN KHOẢN, NHỜ THU";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

     

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frQLPhieuThu_App frm = new frQLPhieuThu_App();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show(); 
        }



        private void bảngTổngHợpĐăngNgânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BangTongHopDangNgan frm = new BangTongHopDangNgan();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();

        }

        private void phânQuyềnLộTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frCapNhatLT frm = new frCapNhatLT();

            //frCapNhatLT frm = new frCapNhatLT();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void dữLiệuHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frHoaDon frm = new frHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đemHóaĐơnVềPhânChiaChoTNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frPhanQuyenNhanVienThu frm = new frPhanQuyenNhanVienThu();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void quảnLýBiênNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQLBienNhan frm = new frQLBienNhan();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void gạchNợChuyểnKhoảnBằngFileExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGachNo_Excel frm = new frGachNo_Excel();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void traCứuHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frTraCuuHoaDon frm = new frTraCuuHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void thayThếHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQLHoaDonDieuChinh frm = new frQLHoaDonDieuChinh();
            frm.MdiParent = this;
            frm.trangthai_id = 9;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }
        private void nhậpLiệuĐăngNgânCủaThuNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NhapLieuDangNganCuaThuNhanVien frm = new NhapLieuDangNganCuaThuNhanVien();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        //private void báoCáoTổngHợpHóaĐơnChiaTheoĐợtToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    BangTongHopHoaDonChiaTheoDot frm = new BangTongHopHoaDonChiaTheoDot();
        //    frm.MdiParent = this;
        //    frm.Dock = DockStyle.Fill;
        //    foreach (Form otherForm in this.MdiChildren)
        //        if (otherForm != frm)
        //            otherForm.Close();
        //    frm.Show();
        //}

        //private void báoCáoTổngHợpHóaĐơnBằng0ChiaTheoĐợtToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    BangTongHopHoaDonBang0ChiaTheoDot frm = new BangTongHopHoaDonBang0ChiaTheoDot();
        //    frm.MdiParent = this;
        //    frm.Dock = DockStyle.Fill;
        //    foreach (Form otherFrom in this.MdiChildren)
        //        if (otherFrom != frm)
        //            otherFrom.Close();
        //    frm.Show();

        //}

        private void hủyHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frHoaDonHuy frm = new frHoaDonHuy();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void báoCáoTổngHợpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BangTongHopDangNgan frm = new BangTongHopDangNgan();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }


        private void bảngTổngHợpĐăngNgânToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //BangTongHopDangNgan frm = new BangTongHopDangNgan();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }


        private void importDữLiệuChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frChitietHD frm = new frChitietHD();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void gạchNợKhóĐòiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGachNoKhoDoi frm = new frGachNoKhoDoi();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void kỳHóaĐơnHànhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDM_KyGhi frm = new frDM_KyGhi();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tổngHợpĐăngNgânTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDangNganChuyenKhoan frm = new frDangNganChuyenKhoan();
            frm.maloai = "KH";
            frm.Text = "TỔNG HỢP ĐĂNG NGÂN TẠI QUẦY";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchHóaĐơnKhóĐòiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQLHoaDonKhoDoi frm = new frQLHoaDonKhoDoi();
            frm.MdiParent = this;
            frm.trangthai = 7;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void gạchNợKhóĐòiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frGachNoKH frm = new frGachNoKH();
            frm.maloai = "KD";
            frm.trangthai = 7;
            frm.Text = "THANH TOÁN KHÁCH HÀNG KHÓ ĐÒI";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void điềuChỉnhHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDieuChinhHoaDon frm = new frDieuChinhHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void thayThếHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frThayTheHoaDon frm = new frThayTheHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQLHuyHoaDon frm = new frQLHuyHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tổngHợpĐăngNgânChuyểnKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDangNganChuyenKhoan frm = new frDangNganChuyenKhoan();
            frm.maloai = "CK";
            frm.Text = "TỔNG HỢP ĐĂNG NGÂN CHUYÊN KHOẢN";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tổngHợpĐăngNgânNhânViênThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDangNganChuyenKhoan frm = new frDangNganChuyenKhoan();
            frm.maloai = "TT";
            frm.Text = "TỔNG HỢp ĐĂNG NGÂN NHÂN VIÊN THU";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tổngHợpĐăngNgânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoTongHop frm = new frmBaoCaoTongHop();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void gạchNợHóaĐơnGiảiTỏaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGachNoKH frm = new frGachNoKH();
            frm.maloai = "GT";
            frm.Text = "THANH TOÁN KHÁCH HÀNG GIẢI TỎA";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void dSHóaĐơnChưaChiaChoTNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDSHoaDonChuaChiaChoTNV frm = new frDSHoaDonChuaChiaChoTNV();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đẩyDữLiệuSangBiilingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frTongHopBilling frm = new frTongHopBilling();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void gạchNợĐốiTácThuHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGachNo_ThuHo frm = new frGachNo_ThuHo();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchKháchHàngTrảChậmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQLHoaDonKhoDoi frm = new frQLHoaDonKhoDoi();
            frm.MdiParent = this;
            frm.trangthai = 5;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchKháchHàngGiảiTỏaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQLHoaDonKhoDoi frm = new frQLHoaDonKhoDoi();
            frm.MdiParent = this;
            frm.trangthai = 6;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đồngBộDữLiệuThuHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDongBoHDThuHo frm = new frDongBoHDThuHo();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frBaoCaoChuanThu frm = new frBaoCaoChuanThu();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void phiếuTheoDõiHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frBaoCaoTheoDoiHoaDon frm = new frBaoCaoTheoDoiHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void dSQuyếtĐịnhĐiềuChỉnhHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQuanlyQD_DieuChinh frm = new frQuanlyQD_DieuChinh();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void bảngTổngHợpĐăngNgânHàngNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frBaoCaoTongHopDangNganTheoNgay frm = new frBaoCaoTongHopDangNganTheoNgay();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void thốngKêKháchHàngNợNhiềuKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frKhachHangNoNhieuKy frm = new frKhachHangNoNhieuKy();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void importDữLiệuHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frImporHoaDonGiay frm = new frImporHoaDonGiay();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();
        }

        private void đồngBộDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDongBoDuLieuHoaDon frm = new frDongBoDuLieuHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void xácNhậnNộpTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGachNoKeToan frm = new frGachNoKeToan();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void báoCáoTổngHợpHóaĐơnChiaTheoĐợtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frBaoCaoChuanThu_Dot frm = new frBaoCaoChuanThu_Dot();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void báoCáoTổngHợpHóaĐơnBằng0ChiaTheoĐợtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frBaoCaoChuanThu0Dong frm = new frBaoCaoChuanThu0Dong();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchKháchHàngTrảChậmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frQLHoaDonKhoDoi frm = new frQLHoaDonKhoDoi();
            frm.MdiParent = this;
            frm.trangthai = 11;
            frm.Text = "DANH SÁCH KHÁCH HÀNG TRẢ CHẬM";
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();

        }

        private void gạchNợKháchHàngTrảChậmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGachNoKH frm = new frGachNoKH();
            frm.maloai = "TC";
            frm.trangthai = 6;
            frm.Text = "THANH TOÁN HOÁ ĐƠN TRẢ CHẬM";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void cậpNhậtĐịaChỉKháchHàngBằngFileExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frCapNhatDiaChiKH frm = new frCapNhatDiaChiKH();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void quyếtĐịnhĐiềuChỉnhHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQuanlyQD_DieuChinh frm = new frQuanlyQD_DieuChinh();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void lậpHóaĐơnThayThếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frThayTheHoaDon frm = new frThayTheHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void hủyHóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frHoaDonHuy frm = new frHoaDonHuy();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchHóaĐơnĐiềuChỉnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQLHoaDonDieuChinh frm = new frQLHoaDonDieuChinh();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchHóaĐơnThayThếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQLHoaDonThayThe frm = new frQLHoaDonThayThe();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchHóaĐơnHủyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frQLHuyHoaDon frm = new frQLHuyHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void inGiấyBáoTiềnNướcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGiayBaoTienNuoc frm = new frGiayBaoTienNuoc();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đồngBộThanhToánHDDTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDongBoHDDT frm = new frDongBoHDDT();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tạoQuyếtĐịnhĐiềuChỉnhHĐToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frXuLyHoaDon frm = new frXuLyHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void thanhToánHóaĐơn0đToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frGachNoHDKhongDong frm = new frGachNoHDKhongDong();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDongBoDuLieuHoaDon frm = new frDongBoDuLieuHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void lậpHóaĐơnĐiềuChỉnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDieuChinhHoaDon frm = new frDieuChinhHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tổngHợpĐăngNgânTheoĐốiTượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frBaoCaoTongHopTheoLoai frm = new frBaoCaoTongHopTheoLoai();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void phiếuĐăngNgânChuyểnKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frTongHopChuyenKhoan frm = new frTongHopChuyenKhoan();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tổngHợpĐăngNgânTrảChậmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDangNganChuyenKhoan frm = new frDangNganChuyenKhoan();
            frm.maloai = "TC";
            frm.Text = "TỔNG HỢP ĐĂNG NGÂN TRẢ CHẬM";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tổngHợpĐăngNgânGiảiTỏaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDangNganChuyenKhoan frm = new frDangNganChuyenKhoan();
            frm.maloai = "GT";
            frm.Text = "TỔNG HỢP ĐĂNG NGÂN GIẢI TỎA";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tổngHợpĐăngNgânTrảChậmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frDangNganChuyenKhoan frm = new frDangNganChuyenKhoan();
            frm.maloai = "TC";
            frm.Text = "TỔNG HỢP ĐĂNG NGÂN TRẢ CHẬM";
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tổngHợpDanhSáchChuyểnNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDSChuyenNo frm = new frDSChuyenNo();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchHủyThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDSHuyThanhToan frm = new frDSHuyThanhToan();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void dToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frDongBoDuLieuHoaDon frm = new frDongBoDuLieuHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đồngBộDữLiệuThuHộToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frDongBoDuLieuHoaDon frm = new frDongBoDuLieuHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
                //frDongBoThuHoApp frm = new frDongBoThuHoApp();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            //frm.Show();

        }

        private void kỳHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KyGhi frm = new KyGhi();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchKháchHàngGửiSmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frDSNoNhieuKySMS frm = new frDSNoNhieuKySMS();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchKháchHàngĐãThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frThongKeHDDaThu frm = new frThongKeHDDaThu();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void tạoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frTaoHoaDon frm = new frTaoHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void danhSáchHóaĐơnĐiềuChỉnhThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frThongKeDieuChinhThongTin frm = new frThongKeDieuChinhThongTin();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void bảngKêHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frBangKeHoaDon frm = new frBangKeHoaDon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đồngBộKháchHàngXemHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DongBoKhachHangForm frm = new DongBoKhachHangForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            foreach (Form otherForm in this.MdiChildren)
                if (otherForm != frm)
                    otherForm.Close();
            frm.Show();
        }

        private void đồngBộThanhToánLỗiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frDongBoThanhToanThuHo frm = new frDongBoThanhToanThuHo();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                foreach (Form otherForm in this.MdiChildren)
                    if (otherForm != frm)
                        otherForm.Close();
                frm.Show();
            }
            catch
            {

            }
        }

        private void đồngBộDữLiệuThanhToànFileExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frDongBoThanhToanEx frm = new frDongBoThanhToanEx();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                foreach (Form otherForm in this.MdiChildren)
                    if (otherForm != frm)
                        otherForm.Close();
                frm.Show();
            }
            catch
            {

            }
        }

        private void mnuTichHop_Click(object sender, EventArgs e)
        {
           HoaDon.HeThong.FrmLienKet frm = new HoaDon.HeThong.FrmLienKet();
            frm.ShowDialog();
        }

        //private void thốngKêNợToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frBaocaoHoadonton frm = new frBaocaoHoadonton();
        //    frm.MdiParent = this;
        //    frm.Dock = DockStyle.Fill;
        //    foreach (Form otherForm in this.MdiChildren)
        //        if (otherForm != frm)
        //            otherForm.Close();
        //    frm.Show();
        //}


    }
}
