using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.HoaDon
{
    public partial class frCapNhatQĐieuChinh : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public decimal QDID;
        decimal tienVATPT = 0;
        decimal tiennuocPT = 0;
        decimal tongtienPT = 0;
        decimal tienBVMTPT = 0;
        decimal phiNTPT = 0;
        decimal thuePhiNTPT = 0;
        int m3PT = 0;
        public frCapNhatQĐieuChinh()
        {
            InitializeComponent();
            txtm3DC.KeyDown += txtm3DC_KeyDown;
            txttiennuocDC.KeyDown += txttiennuocDC_KeyDown;
            txtvatDC.KeyDown += txtvatDC_KeyDown;
            txtBVMT_DC.KeyDown += txtBVMT_DC_KeyDown;
            txtPhiNT_DC.KeyDown += txtPhiNT_DC_KeyDown;
            txtThueNT_DC.KeyDown += txtThueNT_DC_KeyDown;
            txttongcong_DC.KeyDown += txttongcong_DC_KeyDown;
            btnUpdate.Click += btnUpdate_Click;
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
        }

        void txtThueNT_DC_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtThueNT_DC.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    getSumInvoice();
                }
            }
        }

        void txtPhiNT_DC_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPhiNT_DC.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    getSumInvoice();
                }
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {

            var yeucauDC = db.YEUCAU_DIEUCHINH.Where(x => x.QD_ID == QDID).FirstOrDefault();
            var khachhang = db.KHACHHANGs.Where(x => x.ID_KH == yeucauDC.IDKH).FirstOrDefault();
            var data = db.getBaoCaoPhieuDieuChinhHoaDon(QDID).FirstOrDefault();
            txtBangchu.Text = data.bangchu;
            txtmaLT.Text = khachhang.maLT;
            txtDanhBo.Text = khachhang.madanhbo;
            txthoten.Text = khachhang.hoten_KH;
            txtSOHD.Text = data.so_hd;
            txtSOQD.Text = data.so_QD;
            if (yeucauDC.isBOT == true)
                chkBOT.Checked = true;
            if (yeucauDC.isCTY == true)
                chkCTY.Checked = true;
            if (yeucauDC.isDG == true)
                chkDCGia.Checked = true;
            if (yeucauDC.isDH == true)
                chkDHSai.Checked = true;
            if (yeucauDC.isDS == true)
                chkDSSai.Checked = true;
            if (yeucauDC.isIn == true)
                chkInSai.Checked = true;
            if (yeucauDC.iskhac == true)
                chkKhac.Checked = true;
            if (yeucauDC.isMH == true)
                chkMHSai.Checked = true;
            if (yeucauDC.isTB == true)
                chkTBSai.Checked = true;
            if (yeucauDC.isTCT == true)
                chkTCT.Checked = true;

            // 
            txtm3BD.Text = string.Format("{0:n0}", data.m3tieuthu);
            txtm3DC.Text = string.Format("{0:n0}", data.m3_DC);
            txtm3PT.Text = string.Format("{0:n0}", data.m3PT);
            //
            txttiennuocBD.Text = string.Format("{0:n0}", data.tongtien0VAT);
            txttiennuocDC.Text = string.Format("{0:n0}", data.tiennuoc_DC);
            txttiennuocPT.Text = string.Format("{0:n0}", data.tiennuoc_PT);
            //
            txttienvatBD.Text = string.Format("{0:n0}", data.tienvat);
            txtvatDC.Text = string.Format("{0:n0}", data.tienthue_DC);
            txttienvatPT.Text = string.Format("{0:n0}", data.tienthue_PT);
            //
            txtBVMT_BD.Text = string.Format("{0:n0}", data.tienBVMT);
            txtBVMT_DC.Text = string.Format("{0:n0}", data.tienBVMT_DC);
            txtBVMT_PT.Text = string.Format("{0:n0}", data.tienBVMT_PT);
            //
            txtPhiNT.Text = string.Format("{0:n0}", data.PhiNT);
            txtPhiNT_DC.Text = string.Format("{0:n0}", data.tienNT_DC);
            txtPhiNT_PT.Text = string.Format("{0:n0}", data.tienNT_PT);
            //
            txtThueNT.Text = string.Format("{0:n0}", data.TienThueNT);
            txtThueNT_DC.Text = string.Format("{0:n0}", data.thueNT_DC);
            txtThueNT_PT.Text = string.Format("{0:n0}", data.thueNT_PT);
            //
            txttongcong_BD.Text = string.Format("{0:n0}", data.tongtien);
            txttongcong_DC.Text = string.Format("{0:n0}", data.tongtien_DC);
            txttongcongPT.Text = string.Format("{0:n0}", data.tongtien_PT);
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
                getSumInvoice();
                var yeucauDC = db.YEUCAU_DIEUCHINH.Where(x => x.QD_ID == QDID).FirstOrDefault();
                var hoadon = db.HOADONs.Where(x => x.ID_HD == yeucauDC.IDHD).FirstOrDefault();
                int m3DC = int.Parse(txtm3DC.Text.Replace(",", "").Replace(".", "") == "" ? "0" : txtm3DC.Text.Replace(",", "").Replace(".", ""));
                decimal tiennuocDC = decimal.Parse(txttiennuocDC.Text.Replace(",", "").Replace(".", "") == "" ? "0" : txttiennuocDC.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal tienVATDC = decimal.Parse(txtvatDC.Text.Replace(",", "").Replace(".", "") == "" ? "0" : txtvatDC.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal tienBVMTDC = decimal.Parse(txtBVMT_DC.Text.Replace(",", "").Replace(".", "") == "" ? "0" : txtBVMT_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal phiNTDC = decimal.Parse(txtPhiNT_DC.Text.Replace(",", "").Replace(".", "") == "" ? "0" : txtPhiNT_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal thueNTDC = decimal.Parse(txtThueNT_DC.Text.Replace(",", "").Replace(".", "") == "" ? "0" : txtThueNT_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal tongtienDC = decimal.Parse(txttongcong_DC.Text.Replace(",", "").Replace(".", "") == "" ? "0" : txttongcong_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                yeucauDC.IDHD = hoadon.ID_HD;
                yeucauDC.tiennuoc_DC = tiennuocDC;
                yeucauDC.tienthue_DC = tienVATDC;
                yeucauDC.tienBVMT_DC = tienBVMTDC;
                yeucauDC.m3_DC = m3DC;
                yeucauDC.tienNT_DC = phiNTDC;
                yeucauDC.thueNT_DC = thueNTDC;
                yeucauDC.tongtien_DC = tiennuocDC + tienVATDC + tienBVMTDC + phiNTDC + thueNTDC;
                if(chkNgayDC.Checked == true)
                    yeucauDC.ngay_DC = dtpNgayDC.Value;
                if (chkBOT.Checked == true)
                    yeucauDC.isBOT = true;
                else
                    yeucauDC.isBOT = false; 

                if (chkDCGia.Checked == true)
                    yeucauDC.isDG = true;
                else
                    yeucauDC.isDG = false; 

                if (chkDHSai.Checked == true)
                    yeucauDC.isDH = true;
                else
                    yeucauDC.isDH = false; 
                if (chkDSSai.Checked == true)
                    yeucauDC.isDS = true;
                else
                    yeucauDC.isDS = false; 
                if (chkInSai.Checked == true)
                    yeucauDC.isIn = true;
                else
                    yeucauDC.isIn = false; 
                if (chkKhac.Checked == true)
                    yeucauDC.iskhac = true;
                else
                    yeucauDC.iskhac = false; 
                if (chkMHSai.Checked == true)
                    yeucauDC.isMH = true;
                else
                    yeucauDC.isMH = false; 
                if (chkTBSai.Checked == true)
                    yeucauDC.isTB = true;
                else
                    yeucauDC.isTB = false; 
                if (chkCTY.Checked == true)
                    yeucauDC.isCTY = true;
                else
                    yeucauDC.isCTY = false; 
                if (chkTCT.Checked == true)
                    yeucauDC.isTCT = true;
                else
                    yeucauDC.isTCT = false; 
                yeucauDC.ngayin = DateTime.Now;
                if(chkNgay.Checked == true)
                    yeucauDC.ngayPH = dtpQD.Value;
                decimal ptienBVMT = decimal.Parse(txtBVMT_PT.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal ptiennuoc = decimal.Parse(txttiennuocPT.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal ptienthue = decimal.Parse(txttienvatPT.Text.Replace(",", "").Replace(".", ""));
                decimal ptiennuocthai = decimal.Parse(txtPhiNT_PT.Text.Replace(",", "").Replace(".", ""));
                decimal ptienthuenuocthai = decimal.Parse(txtThueNT_PT.Text.Replace(",", "").Replace(".", ""));
                int m3 = int.Parse(txtm3PT.Text == "" ? "0" : txtm3PT.Text.Trim().Replace(",", "").Replace(",", "").Replace(".", ""));
                yeucauDC.bangchu = txtBangchu.Text;
                yeucauDC.date_update = DateTime.Now;
                yeucauDC.SO_QD = txtSOQD.Text;
                yeucauDC.tienBVMT_PT = ptienBVMT;
                yeucauDC.tiennuoc_PT = ptiennuoc;
                yeucauDC.tienthue_PT = ptienthue;
                yeucauDC.thueNT_PT = ptienthuenuocthai;
                yeucauDC.tienNT_PT = ptiennuocthai;
                yeucauDC.tongtien_PT = ptienBVMT + ptiennuoc + ptienthue + ptienthuenuocthai + ptiennuocthai;
                yeucauDC.m3PT = m3;
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công!");
            //}
            //catch
            //{

            //}
        }

        void txttongcong_DC_KeyDown(object sender, KeyEventArgs e)
        {
            if (txttongcong_DC.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    getSumInvoice();
                }
            }
        }

        void txtBVMT_DC_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBVMT_DC.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    getSumInvoice();
                }
            }
        }

        void txtvatDC_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtvatDC.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    getSumInvoice();
                }
            }
        }

        void txttiennuocDC_KeyDown(object sender, KeyEventArgs e)
        {
            if (txttiennuocDC.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    getSumInvoice();
                }
            }
        }

        void txtm3DC_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtm3DC.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    getSumInvoice();
                }
            }
        }
        public void getSumInvoice()
        {
            if (cboDC.Text == "Điều chỉnh giảm")
            {
                // m3
                int m3BD = int.Parse(txtm3BD.Text.Trim().Replace(",", "").Replace(".", ""));
                int m3DC = int.Parse(txtm3DC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtm3DC.Text.Replace(",", "").Replace(".", ""));
                m3PT = m3BD - m3DC;
                // tien nuoc
                decimal tiennuocBD = decimal.Parse(txttiennuocBD.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal tiennuocDC = decimal.Parse(txttiennuocDC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txttiennuocDC.Text.Trim().Replace(",", "").Replace(".", ""));
                tiennuocPT = tiennuocBD - tiennuocDC;
                // tien thue
                decimal tienVATBD = decimal.Parse(txttienvatBD.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal tienVATDC = decimal.Parse(txtvatDC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtvatDC.Text.Replace(",", "").Replace(".", ""));
                tienVATPT = tienVATBD - tienVATDC ;
                // phi BVMT
                decimal tienBVMTDB = decimal.Parse(txtBVMT_BD.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal tienBVMTDC = decimal.Parse(txtBVMT_DC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtBVMT_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                tienBVMTPT = tienBVMTDB - tienBVMTDC;
                // phi xu ly nuoc thai 20%
                decimal phiNT = decimal.Parse(txtPhiNT.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal phiNTTDC = decimal.Parse(txtPhiNT_DC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtPhiNT_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                phiNTPT = phiNT - phiNTTDC;
                // thue 10% phi xu ly nuoc thai
                decimal thueNT = decimal.Parse(txtThueNT.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal thueNTDC = decimal.Parse(txtThueNT_DC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtThueNT_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                thuePhiNTPT = thueNT - thueNTDC;
                // tong tien
                decimal tongtienBD = decimal.Parse(txttongcong_BD.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal tongtienDC = tienBVMTDC + tiennuocDC + tienVATDC + phiNTTDC + thueNTDC;
                tongtienPT = tongtienBD - tongtienDC;
                // show text
                txtm3PT.Text = string.Format("{0:n0}", m3PT);
                txttiennuocPT.Text = string.Format("{0:n0}", tiennuocPT);
                txttienvatPT.Text = string.Format("{0:n0}", tienVATPT);
                txtBVMT_PT.Text = string.Format("{0:n0}", tienBVMTPT);
                txtPhiNT_PT.Text = string.Format("{0:n0}", phiNTPT);
                txtThueNT_PT.Text = string.Format("{0:n0}", thuePhiNTPT);
                txttongcongPT.Text = string.Format("{0:n0}", tongtienPT);
                txttongcong_DC.Text = string.Format("{0:n0}", tongtienDC);
                txtBangchu.Text = db.getSotienbangchu(tongtienPT).FirstOrDefault().ToString();
            }
            else
            {
                // m3
                int m3BD = int.Parse(txtm3BD.Text.Trim().Replace(",", "").Replace(",", "").Replace(".", ""));
                int m3DC = int.Parse(txtm3DC.Text.Trim().Replace(",", "").Replace(".", ""));
                m3PT = m3BD + m3DC ;
                // tien nuoc
                decimal tiennuocBD = decimal.Parse(txttiennuocBD.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal tiennuocDC = decimal.Parse(txttiennuocDC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txttiennuocDC.Text.Trim().Replace(",", "").Replace(".", ""));
                tiennuocPT = tiennuocBD + tiennuocDC ;
                // tien thue
                decimal tienVATBD = decimal.Parse(txttienvatBD.Text.Trim().Replace(",", "").Replace(".", ""));
                decimal tienVATDC = decimal.Parse(txtvatDC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtvatDC.Text.Trim().Replace(",", "").Replace(".", ""));
                 tienVATPT = tienVATBD + tienVATDC ;
                // tien bvmt cu
                 decimal tienBVMTDB = decimal.Parse(txtBVMT_BD.Text.Trim().Replace(",", "").Replace(".", ""));
                 decimal tienBVMTDC = decimal.Parse(txtBVMT_DC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtBVMT_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                 tienBVMTPT = tienBVMTDB + tienBVMTDC ;
                 // phi xu ly nuoc thai
                 decimal phiNT = decimal.Parse(txtPhiNT.Text.Trim().Replace(",", "").Replace(".", ""));
                 decimal phiNTTDC = decimal.Parse(txtPhiNT_DC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtPhiNT_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                 phiNTPT = phiNT+ phiNTTDC;
                 // thue 15% phi xu ly nuoc thai
                 decimal thueNT = decimal.Parse(txtThueNT.Text.Trim().Replace(",", "").Replace(".", ""));
                 decimal thueNTDC = decimal.Parse(txtThueNT_DC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtThueNT_DC.Text.Trim().Replace(",", "").Replace(".", ""));
                 thuePhiNTPT = thueNT + thueNTDC;
                // tong tien
                 decimal tongtienBD = decimal.Parse(txttongcong_BD.Text.Trim().Replace(",", "").Replace(".", ""));
                 decimal tongtienDC = tienBVMTDC + tiennuocDC + tienVATDC + phiNTTDC + thueNTDC; ;
                 tongtienPT = tongtienBD + tongtienDC ;
                // show text
                txtm3PT.Text = string.Format("{0:n0}", m3PT);
                txttiennuocPT.Text = string.Format("{0:n0}", tiennuocPT);
                txttienvatPT.Text = string.Format("{0:n0}", tienVATPT);
                txtBVMT_PT.Text = string.Format("{0:n0}", tienBVMTPT);
                txtPhiNT_PT.Text = string.Format("{0:n0}", phiNTPT);
                txtThueNT_PT.Text = string.Format("{0:n0}", thuePhiNTPT);
                txttongcongPT.Text = string.Format("{0:n0}", tongtienPT);
                txttongcong_DC.Text = string.Format("{0:n0}", tongtienDC);
                txtBangchu.Text = db.getSotienbangchu(tongtienPT).FirstOrDefault().ToString();
            }

        }

        private void frCapNhatQĐieuChinh_Load(object sender, EventArgs e)
        {
            //
            var loaiDC = db.DM_TRANGTHAIHOADON.Where(x => x.trangthai_id == 3 || x.trangthai_id == 4 || x.trangthai_id == 5).ToList();
            cboDC.DataSource = loaiDC;
            cboDC.ValueMember = "trangthai_id";
            cboDC.DisplayMember = "Trangthai";
            cboDC.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDC.Enabled = false;
            LoadData();
        }
        public void LoadData()
        {
            var yeucauDC = db.YEUCAU_DIEUCHINH.Where(x => x.QD_ID == QDID).FirstOrDefault();
            if (yeucauDC.isdaduyet == true)
                btnUpdate.Enabled = false;
            var hoadon = db.HOADONs.Where(x => x.ID_HD == yeucauDC.IDHD).FirstOrDefault();
            var loaihoadon = db.getLoaiHoaDon(hoadon.ID_HD, 201501, 202212).FirstOrDefault();
            txtThueNT.Enabled = false;
            txtThueNT_DC.Enabled = false;
            txtThueNT_PT.Enabled = false;
            txtPhiNT.Enabled = false;
            txtPhiNT_DC.Enabled = false;
            txtPhiNT_PT.Enabled = false;
            txtThueNT.Text = "0";
            txtThueNT_DC.Text = "0";
            txtThueNT_PT.Text = "0";
            txtPhiNT.Text = "0";
            txtPhiNT_DC.Text = "0";
            txtPhiNT_PT.Text = "0";
            if (loaihoadon != null)
            {
                txtThueNT.Enabled = true;
                txtThueNT_DC.Enabled = true;
                txtThueNT_PT.Enabled = true;
                txtPhiNT.Enabled = true;
                txtPhiNT_DC.Enabled = true;
                txtPhiNT_PT.Enabled = true;
                //thuế 10% phí xử lý nước thải 
                txtThueNT.Text = string.Format("{0:n0}", hoadon.TienThueNT);
                txtThueNT_DC.Text = string.Format("{0:n0}", yeucauDC.thueNT_DC);
                txtThueNT_PT.Text = string.Format("{0:n0}", yeucauDC.thueNT_PT);
                //phí xử lý nước thải 15%
                txtPhiNT.Text = string.Format("{0:n0}", hoadon.PhiNT);
                txtPhiNT_DC.Text = string.Format("{0:n0}", yeucauDC.tienNT_DC);
                txtPhiNT_PT.Text = string.Format("{0:n0}", yeucauDC.tienNT_PT);
                //phí BVMT
                txtBVMT_BD.Text = string.Format("{0:n0}", hoadon.tienBVMT);
                txtBVMT_PT.Text = string.Format("{0:n0}", yeucauDC.tienBVMT_PT);
                txtBVMT_DC.Text = string.Format("{0:n0}", yeucauDC.tienBVMT_DC);
            }
            if (loaihoadon == null)
            {
                var loaihoadon23 = db.getLoaiHoaDon(hoadon.ID_HD, 202301, 202312).FirstOrDefault();
                if (loaihoadon23 != null)
                {
                    lblphinuocthai.Text = "Phí thoát nước (20%)";
                    lbltienphiBVMT.Text = "Phí thoát nước (15%)";
                }
                else
                {
                    lblphinuocthai.Text = "Phí thoát nước (25%)";
                    lbltienphiBVMT.Text = "Phí thoát nước (20%)";
                }
                txtThueNT.Enabled = true;
                txtThueNT_DC.Enabled = true;
                txtThueNT_PT.Enabled = true;
                txtPhiNT.Enabled = true;
                txtPhiNT_DC.Enabled = true;
                txtPhiNT_PT.Enabled = true;
                // thuế 10%  của phí nước thải 
                txtThueNT.Text = string.Format("{0:n0}", hoadon.TienThueNT);
                txtThueNT_DC.Text = string.Format("{0:n0}", yeucauDC.thueNT_DC);
                txtThueNT_PT.Text = string.Format("{0:n0}", yeucauDC.thueNT_PT);
                // phí nước thải 20% bắt đầu từ kỳ 1/2023
                txtPhiNT.Text = string.Format("{0:n0}", hoadon.PhiNT);
                txtPhiNT_DC.Text = string.Format("{0:n0}", yeucauDC.tienNT_DC);
                txtPhiNT_PT.Text = string.Format("{0:n0}", yeucauDC.tienNT_PT);
                // phí nước thải 15% kỳ 1/2023
                txtBVMT_BD.Text = string.Format("{0:n0}", hoadon.PhiBVMTCu);
                txtBVMT_PT.Text = string.Format("{0:n0}", yeucauDC.tienBVMT_PT);
                txtBVMT_DC.Text = string.Format("{0:n0}", yeucauDC.tienBVMT_DC);
            }
            txtSOHD.Text = hoadon.SO_HD;
            txtmaLT.Text = hoadon.MaLT;
            txtDanhBo.Text = hoadon.DANHBO;
            txthoten.Text = hoadon.hoten;
            txtm3BD.Text = string.Format("{0:n0}", hoadon.m3tieuthu);
            txttiennuocBD.Text = string.Format("{0:n0}", hoadon.tongtien0VAT);
            txttienvatBD.Text = string.Format("{0:n0}", hoadon.tienvat);
            txttongcong_BD.Text = string.Format("{0:n0}", hoadon.tongtien);
            txttiennuocDC.Text = string.Format("{0:n0}", yeucauDC.tiennuoc_DC);
            txttongcong_DC.Text = string.Format("{0:n0}", yeucauDC.tongtien_DC);
            txtvatDC.Text = string.Format("{0:n0}", yeucauDC.tienthue_DC);
            txtm3DC.Text = string.Format("{0:n0}", yeucauDC.m3_DC);
            txttiennuocPT.Text = string.Format("{0:n0}", yeucauDC.tiennuoc_PT);
            txttongcongPT.Text = string.Format("{0:n0}", yeucauDC.tongtien_PT);
            txttienvatPT.Text = string.Format("{0:n0}", yeucauDC.tienthue_PT);
            txtm3PT.Text = string.Format("{0:n0}", yeucauDC.m3PT);
            txtBangchu.Text = yeucauDC.bangchu;
            txtSOQD.Text = yeucauDC.SO_QD == null ? "" : yeucauDC.SO_QD;
            dtpQD.Value = yeucauDC.ngayPH == null ? DateTime.Now : (DateTime)yeucauDC.ngayPH;
            dtpNgayDC.Value = yeucauDC.ngay_DC == null ? DateTime.Now : (DateTime)yeucauDC.ngay_DC;
            cboDC.SelectedValue = decimal.Parse( yeucauDC.loaiDC.ToString());
            chkBOT.Checked  = (bool) yeucauDC.isBOT;
            chkCTY.Checked = (bool)yeucauDC.isCTY;
            chkDCGia.Checked = (bool)yeucauDC.isDG;
            chkDHSai.Checked = (bool)yeucauDC.isDH;
            chkDSSai.Checked = (bool)yeucauDC.isDS;
            chkInSai.Checked = (bool)yeucauDC.isIn;
            chkKhac.Checked = (bool)yeucauDC.iskhac;
            chkMHSai.Checked = (bool)yeucauDC.isMH;
            chkTBSai.Checked = (bool)yeucauDC.isTB;
            chkTCT.Checked = (bool)yeucauDC.isTCT;
        }

        private void txttiennuocDC_TextChanged(object sender, EventArgs e)
        {
            decimal tiennuocDC = decimal.Parse(txttiennuocDC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txttiennuocDC.Text.Trim().Replace(",", "").Replace(".", ""));
            decimal tienVATDC = decimal.Parse(txtvatDC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtvatDC.Text.Replace(",", "").Replace(".", ""));
            decimal tienBVMTDC = decimal.Parse(txtBVMT_DC.Text.Trim().Replace(",", "").Replace(".", "") == "" ? "0" : txtBVMT_DC.Text.Trim().Replace(",", "").Replace(".", ""));

        }
    }
}
