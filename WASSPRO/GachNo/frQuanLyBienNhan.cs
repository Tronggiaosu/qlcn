using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.BLL;
using QLCongNo.ReportViewer.DataSource;
namespace QLCongNo.FORM
{
    public partial class frChiTietBienNhan : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        ChungTu_BLL ct = new ChungTu_BLL();
        LoTrinh_BLL lt = new LoTrinh_BLL();
        Loaichungtu_BLL lct = new Loaichungtu_BLL();
        Proc_BLL prc = new Proc_BLL();
        Nhanvien_BLL nv = new Nhanvien_BLL();
        TracuuHD_BLL tc = new TracuuHD_BLL();
        public static string ma, ngaylap_dgv, ten_kyghi_dgv;
        public static string soCT_dgv, kyghi_dgv, NV_ID_dgv, ID_CT_dgv, l_ct, nvlap_dgv, nvnop_dgv;
        public static bool click1 = false, click;
        public frChiTietBienNhan()
        {
            InitializeComponent();
            //dgvChitiet.RowEnter += DgvChitiet_RowEnter;
            btnTim.Click += BtnTim_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnRF.Click += BtnRF_Click;
            btnEX.Click += BtnEX_Click;
            btnThoat.Click += BtnThoat_Click;
            btnIn.Click += BtnIn_Click;
            //cbokyghi.SelectedIndexChanged += Cbokyghi_SelectedIndexChanged;
            //cboNV.SelectedIndexChanged += CboNV_SelectedIndexChanged;
            //cboNVlap.SelectedIndexChanged += CboNVlap_SelectedIndexChanged;
            txtSoCT.KeyDown += TxtSoCT_KeyDown;
            btnDB.Click += BtnDB_Click;
            chkKyHD.CheckedChanged += chkKyHD_CheckedChanged;
            chkNgay.CheckedChanged += chkNgay_CheckedChanged;
            chkNVlap.CheckedChanged += chkNVlap_CheckedChanged;
            chkNVnop.CheckedChanged += chkNVnop_CheckedChanged;
        }

        void chkNVnop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNVnop.Checked == true)
                cboNV.Enabled = true;
            else
                cboNV.Enabled = false;
        }

        void chkNVlap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNVlap.Checked == true)
                cboNVlap.Enabled = true;
            else
                cboNVlap.Enabled = false;
        }

        void chkNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgay.Checked == true)
            {
                dtpNgaylap.Enabled = true;
                dtpdenngay.Enabled = true;
            }
            else
            {
                dtpNgaylap.Enabled = false;
                dtpdenngay.Enabled = false;
            }
        }

        void chkKyHD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKyHD.Checked == true)
                cbokyghi.Enabled = true;
            else
                cbokyghi.Enabled = false;
        }

        private void BtnDB_Click(object sender, EventArgs e)
        {
            if (dgvChitiet.RowCount <= 0)
                MessageBox.Show("Vui lòng chọn chứng từ!");
            else
            {
                decimal ID_CT_dgv = decimal.Parse(dgvChitiet.SelectedRows[0].Cells[ID_CT.Name].Value.ToString());
                var sl = db.CHUNGTU_HOADON.Where(x => x.ID_CT == ID_CT_dgv && x.dadongbo == false).Count();
                var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
                if (sl == 0)
                    MessageBox.Show("Chứng từ này đã được đồng bộ, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn đồng bộ hóa đơn điện tử?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        var ListFkey = db.CHUNGTU_HOADON.Where(x => x.ID_CT == ID_CT_dgv).ToList();
                        string fkey = "";
                        foreach (var key in ListFkey)
                        {
                            if (fkey == "")
                                fkey = key.ID_HD.ToString();
                            else
                                fkey = fkey + "_" + key.ID_HD.ToString();
                        }
                        Business.BusinessService ww = new Business.BusinessService();
                        string kq = ww.confirmPaymentFkey(fkey, acc.acc_service, acc.pass_service);
                        if (kq == "OK:" || kq == "ERR:13")
                        {
                            var chungtu_HD = db.CHUNGTU_HOADON.Where(x => x.ID_CT == ID_CT_dgv).ToList();
                            foreach (var id in chungtu_HD)
                            {
                                id.dadongbo = true;
                                db.SaveChanges();
                            }
                            //ct.updateTrangthaiCT_HD(ID_CT_dgv);
                            MessageBox.Show("Đồng bộ thành công!");
                        }
                        else
                            switch (kq)
                            {
                                case "ERR:1":
                                    MessageBox.Show("Tài khoản đăng nhập sai, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                case "ERR:6":
                                    MessageBox.Show("Hóa đơn chưa phát hành, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                case "ERR:7":
                                    MessageBox.Show("Không thể đồng bộ hóa đơn, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                default: break;
                            }
                        var dadongbo = db.CHUNGTU_HOADON.Where(x => x.ID_CT == ID_CT_dgv && x.dadongbo == false).Count();
                        if (dadongbo == 0)
                        {
                            var chungtu = db.CHUNGTUs.Where(x => x.ID_CT == ID_CT_dgv).FirstOrDefault();
                            chungtu.trangthai = true;
                            db.SaveChanges();
                        }
                        btnTim.PerformClick();
                        tss();
                    }
                }
            }
        }
        private void TxtSoCT_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtSoCT.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var data = from a in db.DSBIENNHANs
                               where a.SOCT.Contains(text) || a.ID_kyghi.Contains(text) || a.nvnop.Contains(text) || a.nvlap.Contains(text)
                               select a;
                    dgvChitiet.DataSource = data.OrderByDescending(x => x.ID_CT).ToList();
                }
            }
        }
        private void BtnIn_Click(object sender, EventArgs e)
        {
            if (dgvChitiet.RowCount <= 0)
                MessageBox.Show("Bạn chưa chọn biên nhận, vui vòng kiểm tra lại!");
            else
            {
                decimal ID_CT_dgv = decimal.Parse(dgvChitiet.SelectedRows[0].Cells[ID_CT.Name].Value.ToString());
                int soluong = db.CHUNGTU_HOADON.Where(x => x.ID_CT == ID_CT_dgv).Count();
                if (soluong == 0)
                {
                    MessageBox.Show("Không thể in phiếu thu này, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    PhieuThuKH frm = new PhieuThuKH();
                    frm.ID_CT = dgvChitiet.SelectedRows[0].Cells[ID_CT.Name].Value.ToString();
                    frm.Maloai = ct.getLCT(dgvChitiet.SelectedRows[0].Cells[ID_CT.Name].Value.ToString());
                    frm.ShowDialog();
                }
            }
           
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dgvChitiet);
        }

        private void BtnRF_Click(object sender, EventArgs e)
        {
            click1 = false;
            btnTim.PerformClick();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChitiet.RowCount == 0)
                MessageBox.Show("Không có biên nhận nào trong danh sách!");
            else
            {
                decimal ID_CT_dgv = decimal.Parse(dgvChitiet.SelectedRows[0].Cells[ID_CT.Name].Value.ToString());
                string ID_kyghi_dgv = dgvChitiet.SelectedRows[0].Cells[ID_kyghi.Name].Value.ToString();
                var kyghi = db.DANHMUCKYGHIs.Where(x => x.ID_kyghi == ID_kyghi_dgv).FirstOrDefault();
                if (kyghi.gachno == false)
                {
                    MessageBox.Show("Kỳ ghi này đã đóng gạch nợ, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var chungtu_HD = db.CHUNGTU_HOADON.Where(x => x.ID_CT == ID_CT_dgv).Count();
                    if (chungtu_HD == 0)
                    {
                        DialogResult rs = MessageBox.Show("Bạn có muốn xóa phiếu thu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        db.CHUNGTUs.Remove(db.CHUNGTUs.FirstOrDefault(x => x.ID_CT == ID_CT_dgv));
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        btnTim.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Chứng từ còn hóa đơn, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvChitiet.RowCount == 0)
                MessageBox.Show("Không có chứng từ nào trong danh sách!");
            else
            {
                //frSuaCT f = new frSuaCT();
                //f.ID_CT = dgvChitiet.SelectedRows[0].Cells[ID_CT.Name].Value.ToString();
                //f.maloai = ct.getLCT(dgvChitiet.SelectedRows[0].Cells[ID_CT.Name].Value.ToString());
                //f.nvnop_dgv = dgvChitiet.SelectedRows[0].Cells[NV_nop.Name].Value.ToString();
                //f.MdiParent = this.MdiParent;
                //f.Dock = DockStyle.Fill;
                //f.Show();
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            //string tungay = dtpNgaylap.Value.ToString("yyyy-MM-dd");
            //string denngay = dtpdenngay.Value.ToString("yyyy-MM-dd");
            //string kyghi = cbokyghi.SelectedValue.ToString();
            //dgvChitiet.DataSource = ct.getChitiet_gachno_ngaylap(tungay, denngay, kyghi);
            //toolStripStatusLabel1.Text = "Tổng số: " + dgvChitiet.Rows.Count.ToString();
            //decimal tongthu = 0;
            //decimal tonghd = 0;
            //for (int i = 0; i < dgvChitiet.RowCount; i++)
            //{
            //    tongthu += decimal.Parse(dgvChitiet.Rows[i].Cells[tongtien.Name].Value.ToString());
            //    tonghd += decimal.Parse(dgvChitiet.Rows[i].Cells[soluong.Name].Value.ToString());
            //}
            //lbltonghd.Text = "Tổng số hóa đơn: " + tonghd.ToString();
            //lbltongtien.Text = "Tổng tiền: " + string.Format("{0:n0}", double.Parse(tongthu.ToString()));
            var data = from a in db.DSBIENNHANs select a;
            string kyghi = cbokyghi.SelectedValue.ToString();
            DateTime tungay = dtpNgaylap.Value;
            DateTime denngay = dtpdenngay.Value;
            string nhanvien = cboNV.SelectedValue.ToString();
            string nhanvien_lap = cboNVlap.SelectedValue.ToString();
            string maloai = cboLoai.SelectedValue.ToString();
            if (chkKyHD.Checked == true)
                data = data.Where(x => x.ID_kyghi == kyghi);
            if (chkNgay.Checked == true)
                data = data.Where(x => x.ngaylap >= tungay && x.ngaylap <= denngay);
            if (chkNVnop.Checked == true)
                data = data.Where(x => x.NV_ID_nop.ToString() == nhanvien);
            if (chkNVlap.Checked == true)
                data = data.Where(x => x.NV_ID_lap.ToString() == nhanvien_lap);
            if (chkLoai.Checked == true)
                data = data.Where(x => x.maloai == maloai);
            dgvChitiet.DataSource = data.OrderByDescending(x => x.ID_CT).ToList();
            tss();
        }
        //private void DgvChitiet_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        int index = e.RowIndex;
        //        soCT_dgv = dgvChitiet["soCT", index].Value.ToString();
        //        kyghi_dgv = dgvChitiet["ID_kyghi", index].Value.ToString();
        //        NV_ID_dgv = dgvChitiet["ID_NV", index].Value.ToString();
        //        ten_kyghi_dgv = dgvChitiet["quyenso", index].Value.ToString();
        //        ID_CT_dgv = dgvChitiet["ID_CT", index].Value.ToString();
        //        nvlap_dgv = dgvChitiet["ID_NV_lap", index].Value.ToString();
        //        nvnop_dgv = dgvChitiet["NV_nop", index].Value.ToString();
        //        DateTime ngaylap = Convert.ToDateTime(dgvChitiet["ngaylap", index].Value.ToString());
        //        ngaylap_dgv = ngaylap.ToString("yyyy-MM-dd HH:mm:ss");
        //        l_ct = ct.getLCT(soCT_dgv, kyghi_dgv);
        //    }
        //    catch
        //    {

        //    }
        //}
        //private void dgvSelected()
        //{
        //    if (dgvChitiet.RowCount > 0)
        //    {
        //        soCT_dgv = dgvChitiet.SelectedRows[0].Cells[soCT.Name].Value.ToString();
        //        kyghi_dgv = dgvChitiet.SelectedRows[0].Cells[ID_kyghi.Name].Value.ToString();
        //        NV_ID_dgv = dgvChitiet.SelectedRows[0].Cells[ID_NV.Name].Value.ToString();
        //        ten_kyghi_dgv = dgvChitiet.SelectedRows[0].Cells[quyenso.Name].Value.ToString();
        //        ID_CT_dgv = dgvChitiet.SelectedRows[0].Cells[ID_CT.Name].Value.ToString();
        //        nvlap_dgv = dgvChitiet.SelectedRows[0].Cells[ID_NV_lap.Name].Value.ToString();
        //        nvnop_dgv = dgvChitiet.SelectedRows[0].Cells[NV_nop.Name].Value.ToString();
        //        DateTime ngaylap_date = Convert.ToDateTime(dgvChitiet.SelectedRows[0].Cells[ngaylap.Name].Value.ToString());
        //        ngaylap_dgv = ngaylap_date.ToString("yyyy-MM-dd HH:mm:ss");
        //        l_ct = ct.getLCT(ID_CT_dgv);
        //    }
        //    else
        //        MessageBox.Show("Không có biên nhận nào trong danh sách!");
        //}

        private void frChiTietBienNhan_Load(object sender, EventArgs e)
        {
            dgvChitiet.AutoGenerateColumns = false;
            cbokyghi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbokyghi.DataSource = ct.getData_Kyghi();
            cbokyghi.ValueMember = "ID_kyghi";
            cbokyghi.DisplayMember = "ten_kyghi";
            cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNV.DataSource = nv.get_NVThu();
            cboNV.ValueMember = "NV_ID";
            cboNV.DisplayMember = "hoten";
            string[] ds = { "chưa đồng bộ", "đã đồng bộ" };
            cboNVlap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNVlap.DataSource = prc.dataThuNgan();
            cboNVlap.ValueMember = "NV_ID";
            cboNVlap.DisplayMember = "hoten";
            //this.dgvChitiet.RowsDefaultCellStyle.BackColor = Color.White;
            //this.dgvChitiet.AlternatingRowsDefaultCellStyle.BackColor = Color.MintCream;
            //dgvChitiet.ColumnHeadersDefaultCellStyle.BackColor = Color.Linen;
            //dgvChitiet.EnableHeadersVisualStyles = false;
            cboNV.Enabled = false;
            cboNVlap.Enabled = false;
            dtpdenngay.Enabled = false;
            dtpNgaylap.Enabled = false;
            cbokyghi.Enabled = false;
            dataLoaiCT();
            //var data = from a in db.DSBIENNHANs select a;
            //dgvChitiet.DataSource = data.OrderBy(x => x.ngaylap).ToList();
            tss();
            
        }
        // toolstripstatus
        private void tss()
        {
            toolStripStatusLabel1.Text = "Tổng số: " + dgvChitiet.Rows.Count.ToString();
            decimal tongthu = 0;
            decimal tonghd = 0;
            for (int i = 0; i < dgvChitiet.RowCount; i++)
            {
                tongthu += decimal.Parse(dgvChitiet.Rows[i].Cells[tongtien.Name].Value.ToString());
                tonghd += decimal.Parse(dgvChitiet.Rows[i].Cells[soluong.Name].Value.ToString());
            }
            lbltonghd.Text = "Tổng số hóa đơn: " + tonghd.ToString();
            lbltongtien.Text = "Tổng tiền: " + string.Format("{0:n0}", double.Parse(tongthu.ToString()));
            dtpdenngay.Format = DateTimePickerFormat.Custom;
            dtpdenngay.CustomFormat = "dd/MM/yyyy";
            dtpNgaylap.Format = DateTimePickerFormat.Custom;
            dtpNgaylap.CustomFormat = "dd/MM/yyyy";
        }
        private void dataLoaiCT()
        {
            var data = from a in db.LOAICHUNGTUs select a;
            cboLoai.DataSource = data.ToList();
            cboLoai.DisplayMember = "tenloai";
            cboLoai.ValueMember = "maloai";
        }
    }
}
