using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.View.UC.GachNo;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcThayTheHoaDon : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcThayTheHoaDon()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            txtSoHD.KeyDown += txtSoHD_KeyDown;
            txtSoHD.KeyPress += txtSoHD_KeyPress;
            txtcscu.KeyPress += txtcscu_KeyPress;
            txtcsmoi.KeyPress += txtcsmoi_KeyPress;
            txtdmkh.KeyPress += txtdmkh_KeyPress;
            txtmst.KeyPress += txtmst_KeyPress;
            txtm3.KeyPress += txtm3_KeyPress;
            btnThaythe.Click += btnThaythe_Click;
            //dgvTienNuoc.RowEnter += dgvTienNuoc_RowEnter;
            txttienBVMT.KeyDown += txttienBVMT_KeyDown;
            txttiennuoc.KeyDown += txttiennuoc_KeyDown;
            txttienthue.KeyDown += txttienthue_KeyDown;
            btnTim.Click += btnTim_Click;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            cleanText();
            getHoaDon();
        }

        private void btnLNTT_Click(object sender, EventArgs e)
        {
            try
            {
                var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                var IDHD_ThayThe = db.HOADONs.Where(x => x.user_create == NVLap.nv_id).Select(x => x.ID_HD).Max();
                var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD_ThayThe).FirstOrDefault();
                var STT = db.CHITIET_HD.Where(x => x.ID_HD == IDHD_ThayThe).ToList().Select(x => x.STT).Max();
                CHITIET_HD chitietHD_Thaythe = new CHITIET_HD();
                chitietHD_Thaythe.ID_HD = IDHD_ThayThe;
                chitietHD_Thaythe.ID_KH = hoadon.ID_KH;
                chitietHD_Thaythe.SOLUONG = 0;
                chitietHD_Thaythe.STT = STT + 1;
                chitietHD_Thaythe.DONGIA = 0;
                chitietHD_Thaythe.M3BVMT = 0;
                chitietHD_Thaythe.GIABVMT = 0;
                chitietHD_Thaythe.USER_CREATE = NVLap.nv_id;
                chitietHD_Thaythe.DATE_CREATE = DateTime.Now;
                db.CHITIET_HD.Add(chitietHD_Thaythe);
                db.SaveChanges();
                getDataSource_DGV();
            }
            catch
            {
            }
        }

        private void txttienthue_KeyDown(object sender, KeyEventArgs e)
        {
            if (txttienthue.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tongtienHD();
                }
            }
        }

        private void txttiennuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (txttiennuoc.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tongtienHD();
                }
            }
        }

        private void txttienBVMT_KeyDown(object sender, KeyEventArgs e)
        {
            if (txttienBVMT.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tongtienHD();
                }
            }
        }

        private void tongtienHD()
        {
            var tiennuoc = decimal.Parse(txttiennuoc.Text == "" ? "0" : txttiennuoc.Text);
            var tienthue = decimal.Parse(txttienthue.Text == "" ? "0" : txttienthue.Text);
            var tienBVMT = decimal.Parse(txttienBVMT.Text == "" ? "0" : txttienBVMT.Text);
            var tongtien = tiennuoc + tienthue + tienBVMT;
            txttongcong.Text = string.Format("{0:n0}", tongtien);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var IDChitiet = decimal.Parse(dgvTienNuoc.SelectedRows[0].Cells[IDChiTietColumn.Name].Value.ToString());
            var chitietHD = db.CHITIET_HD.Where(x => x.ID_chitiet_HD == IDChitiet).FirstOrDefault();
            db.CHITIET_HD.Remove(chitietHD);
            db.SaveChanges();
            getDataSource_DGV();
        }

        private void getDataSource_DGV()
        {
            var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
            var IDHD_ThayThe = db.HOADONs.Where(x => x.user_create == NVLap.nv_id).Select(x => x.ID_HD).Max();
            var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD_ThayThe).FirstOrDefault();
            var dataLNTT = db.CHITIET_HD.Where(x => x.ID_HD == hoadon.ID_HD).Select(x => new { x.ID_chitiet_HD, x.SOLUONG, x.DONGIA, x.GIABVMT, x.M3BVMT, delete = "Xóa" }).OrderBy(x => x.DONGIA).ToList();
            dgvTienNuoc.DataSource = dataLNTT.ToList();
            dgvBVMT.DataSource = dataLNTT.ToList();
        }

        //void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (txtLNTT.Text != "" && txtdongia.Text != "")
        //    {
        //        var IDChitiet = decimal.Parse(dgvTienNuoc.SelectedRows[0].Cells[IDChitietColumn.Name].Value.ToString());
        //        var chitietHD = db.CHITIET_HD.Where(x => x.ID_chitiet_HD == IDChitiet).FirstOrDefault();
        //        decimal lntt = decimal.Parse(txtLNTT.Text);
        //        decimal dongia = decimal.Parse(txtdongia.Text);
        //        chitietHD.SOLUONG = lntt;
        //        chitietHD.DONGIA = dongia;
        //        chitietHD.M3BVMT = lntt;
        //        chitietHD.GIABVMT = dongia / 10;
        //        db.SaveChanges();
        //        getDataSource_DGV();
        //    }
        //}

        //void dgvTienNuoc_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        var m3tieuthu = decimal.Parse(dgvTienNuoc.SelectedRows[0].Cells[LNTTColumn.Name].Value.ToString());
        //        var dongia = decimal.Parse(dgvTienNuoc.SelectedRows[0].Cells[dongiaColumn.Name].Value.ToString());
        //        txtLNTT.Text = string.Format("{0:n0}", m3tieuthu);
        //        txtdongia.Text = string.Format("{0:n0}", dongia);
        //    }
        //    catch
        //    {
        //    }
        //}

        private void btnThaythe_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn phát hành hóa đơn thay thế?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
            }
        }

        private void StringParserToInv(string result)
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
                ImportInvoices(pattern, Serialno, Data);
                HOADON_LOG HDLog = new HOADON_LOG();
                HDLog.patterns = pattern;
                HDLog.Serialno = Serialno;
                HDLog.fkey = Data;
                db.HOADON_LOG.Add(HDLog);
                db.SaveChanges();
            }
            else
            {
                HOADON_LOG HDLog = new HOADON_LOG();
                HDLog.fkey = result;
                db.HOADON_LOG.Add(HDLog);
                db.SaveChanges();
            }
        }

        private void ImportInvoices(string pattern, string Serialno, string Data)
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
                        hoadon.trangthai_id = 6;
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

        //void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (txtLNTT.Text != "" && txtdongia.Text != "")
        //    {
        //        var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
        //        var IDHD_ThayThe = db.HOADONs.Where(x => x.user_create == NVLap.nv_id).Select(x => x.ID_HD).Max();
        //        var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD_ThayThe).FirstOrDefault();
        //        var STT = db.CHITIET_HD.Where(x => x.ID_HD == IDHD_ThayThe).ToList().Select(x => x.STT).Max();
        //        decimal m3 = decimal.Parse(txtLNTT.Text);
        //        decimal dongia = decimal.Parse(txtdongia.Text);
        //        CHITIET_HD chitietHD_Thaythe = new CHITIET_HD();
        //        chitietHD_Thaythe.ID_HD = IDHD_ThayThe;
        //        chitietHD_Thaythe.ID_KH = hoadon.ID_KH;
        //        chitietHD_Thaythe.SOLUONG = m3;
        //        chitietHD_Thaythe.STT = STT + 1;
        //        chitietHD_Thaythe.DONGIA = dongia;
        //        chitietHD_Thaythe.M3BVMT = m3;
        //        chitietHD_Thaythe.GIABVMT = (dongia / 10);
        //        chitietHD_Thaythe.USER_CREATE = NVLap.nv_id;
        //        chitietHD_Thaythe.DATE_CREATE = DateTime.Now;
        //        db.CHITIET_HD.Add(chitietHD_Thaythe);
        //        db.SaveChanges();
        //        getDataSource_DGV();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Chưa nhập LNTT hoặc đơn giá");
        //    }
        //}

        private void txtm3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtmst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtdmkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLNTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtcsmoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtcscu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void getHoaDon()
        {
            if (txtSoHD.Text == null || txtSoHD.Text == "")
            {
                MessageBox.Show("Chưa nhập số hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string SOHD = decimal.Parse(txtSoHD.Text).ToString("0000000");
            var hoadon = db.HOADONs.Where(x => x.SO_HD == SOHD && x.trangthai_id == 1).FirstOrDefault();
            if (hoadon != null)
            {
                this.Cursor = Cursors.WaitCursor;
                txthoten.Text = hoadon.KHACHHANG.hoten_KH;
                txtdiachi.Text = hoadon.diachihoadon;
                txtdmkh.Text = hoadon.DMKH.ToString();
                txtcsmoi.Text = hoadon.CSMoi.ToString();
                txtcscu.Text = hoadon.CSCu.ToString();
                txtdanhbo.Text = hoadon.DANHBO;
                txtMGB.Text = hoadon.MADT;
                txtmlt.Text = hoadon.MaLT;
                txtmst.Text = hoadon.MST;
                txtMTT.Text = hoadon.MTT;
                txtsohopdong.Text = hoadon.sohopdong;
                txttienBVMT.Text = string.Format("{0:n0}", hoadon.tienBVMT);
                txttiennuoc.Text = string.Format("{0:n0}", hoadon.tongtien0VAT);
                txttienthue.Text = string.Format("{0:n0}", hoadon.tienvat);
                txttongcong.Text = string.Format("{0:n0}", hoadon.tongtien);
                var chitietHD = db.CHITIET_HD.Where(x => x.ID_HD == hoadon.ID_HD).ToList();
                dgvBVMT.AutoGenerateColumns = false;
                dgvTienNuoc.AutoGenerateColumns = false;
                var dataLNTT = db.CHITIET_HD.Where(x => x.ID_HD == hoadon.ID_HD).Select(x => new { x.ID_chitiet_HD, x.SOLUONG, x.DONGIA, x.GIABVMT, x.M3BVMT, delete = "Xóa" }).OrderBy(x => x.DONGIA).ToList();
                dgvTienNuoc.DataSource = dataLNTT.ToList();
                dgvBVMT.DataSource = dataLNTT.ToList();
                btnThaythe.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            else
            {
                cleanText();
            }
        }

        private void cleanText()
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
            txttienBVMT.Text = string.Format("{0:n0}", 0);
            txttiennuoc.Text = string.Format("{0:n0}", 0);
            txttienthue.Text = string.Format("{0:n0}", 0);
            txttongcong.Text = string.Format("{0:n0}", 0);
        }

        private void txtSoHD_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtSoHD.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnTim.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (btnThoat.Text == "Hủy")
            {
                var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                var IDHD_ThayThe = db.HOADONs.Where(x => x.user_create == NVLap.nv_id).Select(x => x.ID_HD).Max();
                var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD_ThayThe).FirstOrDefault();
                var chitietHD = db.CHITIET_HD.Where(x => x.ID_HD == IDHD_ThayThe).ToList();
                db.CHITIET_HD.RemoveRange(chitietHD);
                db.SaveChanges();
                db.HOADONs.Remove(hoadon);
                db.SaveChanges();
                btnThoat.Text = "Thoát";
                btnThaythe.Text = "Tạo hóa đơn thay thế";
                btnTim.PerformClick();
            }
            //TODO
            //else
            //this.Close();
        }

        private void frThayTheHoaDon_Load(object sender, EventArgs e)
        {
            // dm mau HD
            cboMauSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboMauSo.DataSource = db.MAU_HD.OrderBy(x => x.ky_hieu_HD).ToList();
            cboMauSo.ValueMember = "mau_HD1";
            // dm ky hieu
            cboKyHieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboKyHieu.DataSource = db.MAU_HD.OrderBy(x => x.ky_hieu_HD).ToList();
            cboKyHieu.ValueMember = "ky_hieu_HD";
            cboKyHieu.DisplayMember = "ky_hieu_HD";
            btnThaythe.Enabled = false;
        }

        private void txtSoHD_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }
    }
}