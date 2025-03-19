using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcDieuChinhHoaDon : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        int type = 0;
        public UcDieuChinhHoaDon()
        {
            InitializeComponent();
            btnDieuchinh.Click += btnDieuchinh_Click;
            btnThoat.Click += btnThoat_Click;
            txtSoHD.KeyPress += txtSoHD_KeyPress;
            txtSoHD.KeyDown += txtSoHD_KeyDown;
            btnTim.Click += btnTim_Click;
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            getHoaDon();
        }

  
        private void tongtienHD()
        {
            string SOHD = decimal.Parse(txtSoHD.Text).ToString("0000000");
            var hoadon = db.HOADONs.Where(x => x.SO_HD == SOHD && x.trangthai_id == 1).FirstOrDefault();
        }

        void txttienthue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void txttienBVMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void txttiennuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void txtSoHD_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string kieuDC = cboDieuchinh.Text;
                if (txtSoHD.Text != "")
                {
                    if (e.KeyCode == Keys.Enter)
                        btnTim.PerformClick();
                }
            }
            catch
            {

            }
        }
        private void getHoaDon()
        {
            if (txtSoHD.Text != "")
            {
                string SOHD = decimal.Parse(txtSoHD.Text).ToString("0000000");
                string kyhieu = cboKyHieu.Text;
                string mauso = cboMauSo.Text;
                var hoadon = db.HOADONs.Where(x => x.SO_HD == SOHD && x.trangthai_id != 9 && x.trangthai_id != 2 
                    && x.trangthai_id != 0 && x.KY_HIEU_HD == kyhieu && x.MAU_HD == mauso && x.IsInHD == true).FirstOrDefault();
                cleanTextbox();
                if (hoadon != null)
                {
                    btnDieuchinh.Enabled = true;
                    txtdiachi.Text = hoadon.diachihoadon;
                    txtdcld.Text = hoadon.diachilapdat == null? "" : hoadon.diachilapdat;
                    txtdmkh.Text = hoadon.DMKH.ToString();
                    txtcsmoi.Text = hoadon.CSMoi.ToString();
                    txtcscu.Text = hoadon.CSCu.ToString();
                    txtdanhbo.Text = hoadon.DANHBO;
                    txtMGB.Text = hoadon.MADT;
                    txtmlt.Text = hoadon.MaLT;
                    txtmst.Text = hoadon.MST;
                    txtMTT.Text = hoadon.MTT;
                    txthoten.Text = hoadon.hoten;
                    txtsohopdong.Text = hoadon.sohopdong;
                    txtm3.Text = hoadon.m3tieuthu.ToString();
                    dateTimePicker1.Value = hoadon.tungay.Value.Date;
                    dateTimePicker2.Value = hoadon.denngay.Value.Date;

                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cleanTextbox();
                }
            }
           
        }
        private void cleanTextbox()
        {
            txthoten.Text = "";
            txtdiachi.Text = "";
            txtdmkh.Text = "";
            txtcsmoi.Text = "";
            txtcscu.Text = "";
            txtdanhbo.Text = "";
            txtMGB.Text = "";
            txtmlt.Text = "";
            txtmst.Text = "";
            txtMTT.Text = "";
            txtsohopdong.Text = "";
        }
        void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
        //    this.Close();
        }

        void btnDieuchinh_Click(object sender, EventArgs e)
        {
            if (txtSoHD.Text == "")
            {
                MessageBox.Show("Chưa nhập số hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn điều chỉnh hóa đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    string SOHD = decimal.Parse(txtSoHD.Text).ToString("0000000");
                    string kieuDC = cboDieuchinh.Text;
                    var dsdieuchinh = db.DieuChinhTTs.ToList();
                    var hoadon = db.HOADONs.Where(x => x.SO_HD == SOHD && x.trangthai_id == 1 && x.KY_HIEU_HD == cboKyHieu.Text).FirstOrDefault();
                        //string ghichu = "";
                        //int trangthaihd = 0;
                        //DateTime tungay = DateTime.Parse(txttungay.Text.ToString());
                        //DateTime denngay = DateTime.Parse(txtdenngay.Text);
                        if (hoadon != null && hoadon.ghichu != "Đã điều chỉnh thông tin")
                        {
                            var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                            HOADON hoadonDC = new HOADON();
                            hoadonDC.diachihoadon =txtdiachi.Text;
                            hoadonDC.diachilapdat =  txtdcld.Text == ""?null :txtdcld.Text;
                            hoadonDC.STT_thu = hoadon.STT_thu;
                            hoadonDC.ngaylap = DateTime.Now;
                            hoadonDC.MTT = txtmlt.Text;
                            hoadonDC.hoten = txthoten.Text;
                            hoadonDC.CSCu = int.Parse(txtcscu.Text);
                            hoadonDC.CSMoi = int.Parse(txtcsmoi.Text);
                            hoadonDC.DANHBO = hoadon.DANHBO;
                            hoadonDC.MADT = txtMGB.Text;
                            hoadonDC.MaLT = txtmlt.Text;
                            hoadonDC.MST = txtmst.Text;
                            hoadonDC.sohopdong = txtsohopdong.Text;
                            hoadonDC.kyghi = hoadon.kyghi;
                            hoadonDC.ID_KH = hoadon.ID_KH;
                            hoadonDC.DOT_ID = hoadon.DOT_ID;
                            hoadonDC.nam = hoadon.nam;
                            hoadonDC.keys = hoadon.ID_HD;
                            hoadonDC.isKhoDoi = false;
                            hoadonDC.user_create = NVLap.nv_id;
                            hoadonDC.m3tieuthu = int.Parse(txtm3.Text == "" ? "0" : txtm3.Text);
                            hoadonDC.DMKH = int.Parse(txtdmkh.Text == "" ? "0" : txtdmkh.Text);
                            hoadonDC.MGB = txtMGB.Text;
                            hoadonDC.MTT = txtMTT.Text;
                            hoadonDC.date_create = DateTime.Now;
                            if (chkNgay.Checked)
                                hoadonDC.tungay = dateTimePicker1.Value.Date;
                            else
                                hoadonDC.tungay = hoadon.tungay;
                            if (chkdenngay.Checked)
                                hoadonDC.denngay = dateTimePicker2.Value.Date;
                            else
                                hoadonDC.denngay = hoadon.denngay;
                            hoadonDC.cuonGCS = hoadon.cuonGCS;
                            hoadonDC.STT_thu = hoadonDC.STT_thu;
                            hoadonDC.gachno = false;
                            hoadonDC.nam = hoadon.nam;
                            hoadonDC.tienBVMT = 0;
                            hoadonDC.tongtien0VAT = 0;
                            hoadonDC.tongtien = 0;
                            hoadonDC.tienvat = 0;
                            hoadonDC.LoaiHD_ID = hoadonDC.LoaiHD_ID;
                            hoadonDC.ischeck = 1;
                            hoadonDC.trangthai_id = -1;
                            db.HOADONs.Add(hoadonDC);
                            db.SaveChanges();
                            var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                            bs78.BusinessService bs = new bs78.BusinessService();
                            var acc = db.TAIKHOAN_SERVICE.FirstOrDefault(); decimal soHoaDon = decimal.Parse(hoadon.SO_HD);
                            string ngayPhatHanh = hoadon.ArisingDate.Value.ToString("dd/MM/yyyy");
                            var xml = db.sp_xmlAdjustInv(hoadonDC.ID_HD, hoadon.MAU_HD, 4).FirstOrDefault().ToString();
                            var mauHD = db.MAU_HD.Where(x => x.Active == true).FirstOrDefault();
                            string mauHD1 = mauHD.mau_HD1;
                            string kyhieu = mauHD.ky_hieu_HD;
                            string result = "";
                            string fkeycu = "0";
                            var hoadonloi = db.HOADONs.Where(x => x.ID_KH == hoadonDC.ID_KH && x.trangthai_id == -22).FirstOrDefault();
                            if (hoadonloi != null)
                                fkeycu = hoadonloi.ID_HD.ToString();
                            else
                                fkeycu = hoadonDC.keys.ToString();
                            result = bs.AdjustInvoiceAction("capnuocthuducadmin", acc.pass_admin, xml, "capnuocthuducservice", "Einv@oi@vn#pt20", fkeycu, "", 0, mauHD1, kyhieu).ToString();
                            MessageBox.Show(result);
                            //var result = "OK:01GTKT3/001;AA/12E;12121_2";
                            if (result.Substring(0, 2) == "OK")
                            {
                                StringParserToInv(result, type);
                                hoadon.user_update = NVLap.nv_id;
                                hoadon.date_update = DateTime.Now;
                                hoadon.ghichu = "Đã điều chỉnh thông tin";
                                db.SaveChanges();
                                MessageBox.Show("Điều chỉnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtSoHD.Text = "";
                                btnDieuchinh.Enabled = false;
                                cleanTextbox();
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi trong quá trình xử lý! Mã lỗi: " + result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                HOADON_LOG HDLog = new HOADON_LOG();
                                HDLog.fkey = result;
                                db.HOADON_LOG.Add(HDLog);
                                db.SaveChanges();
                                return;
                            }
                    }
                }
            }
        }
        private void StringParserToInv(string result, int type)
        {
            string[] patterns;
            string pattern, Serialno;
            //Lấy phần parrten
            patterns = result.Split(';');
            if (patterns.Length > 0)
            {
                //Lấy phần Serialno
                pattern = patterns[0];
                pattern = pattern.Substring(3, pattern.Length - 3);
                //Serialnos = patterns[1].Split('-');

                //Xử lý tách khóa key và số hóa đơn
                //int index = patterns[1].IndexOf(";");
                Serialno = patterns[1];
                string Data = patterns[2];
                ImportInvoices(pattern, Serialno, Data, type);
               
            }
            else
            {
                HOADON_LOG HDLog = new HOADON_LOG();
                HDLog.fkey = result;
                db.HOADON_LOG.Add(HDLog);
                db.SaveChanges();
            }
        }
        private void ImportInvoices(string pattern, string Serialno, string Data, int type)
        {
            this.Cursor = Cursors.WaitCursor;
            string[] KeyInv;
            KeyInv = Data.Split(',');
            if (KeyInv.Length > 0)
            {
                for (int IdexArr = 0; IdexArr <= KeyInv.Length - 1; IdexArr++)
                {
                    string[] DataArr = KeyInv[IdexArr].Split('_');
                    if (DataArr.Length > 0)
                    {
                        var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                        string key = DataArr[0];
                        decimal? id = Convert.ToDecimal(key);
                        string so_hd = DataArr[1];
                        // Update HOADON 
                        var hoadon = (from a in db.HOADONs where a.ID_HD == id select a).FirstOrDefault();
                        hoadon.IsInHD = true;
                        hoadon.KY_HIEU_HD = Serialno;
                        hoadon.MAU_HD = pattern;
                        hoadon.SO_HD = decimal.Parse(so_hd).ToString("0000000");
                        hoadon.trangthai_id = 5;
                        hoadon.isKhoDoi = false;
                        hoadon.ArisingDate = DateTime.Now;
                        hoadon.user_create = NVLap.nv_id;
                        hoadon.date_create = DateTime.Now;
                        hoadon.gachno = false;
                        db.SaveChanges();
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }
        private void frDieuChinhHoaDon_Load(object sender, EventArgs e)
        {
            cboDieuchinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            string[] s = { "Điều chỉnh thông tin"};
            cboDieuchinh.DataSource = s;
            // dm mau HD
            List<MAU_HD> dsMau = new List<MAU_HD>();
            dsMau.Add(new MAU_HD { mau_HD1 = "1/003", ky_hieu_HD = "K24TTD" });
            dsMau.Add(new MAU_HD { mau_HD1 = "1/003", ky_hieu_HD = "K23TTD" });
            dsMau.Add(new MAU_HD { mau_HD1 = "1/002", ky_hieu_HD = "K23TTD" });
            dsMau.Add(new MAU_HD { mau_HD1 = "1/001", ky_hieu_HD = "K22TTD" });
            dsMau.Add(new MAU_HD { mau_HD1 = "01GTKT0/003", ky_hieu_HD = "TD/22E" });
            dsMau.Add(new MAU_HD { mau_HD1 = "01GTKT0/002", ky_hieu_HD = "TD/21E" });
            cboMauSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboMauSo.DataSource = dsMau;
            cboMauSo.ValueMember = "mau_HD1";
            // dm ky hieu
            cboKyHieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboKyHieu.DataSource = dsMau;
            cboKyHieu.ValueMember = "ky_hieu_HD";
            cboKyHieu.DisplayMember = "ky_hieu_HD";
            btnDieuchinh.Enabled = false;
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
