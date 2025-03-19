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
    public partial class frBienNhan : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        ChungTu_BLL ct = new ChungTu_BLL();
        LoTrinh_BLL lt = new LoTrinh_BLL();
        Loaichungtu_BLL lct = new Loaichungtu_BLL();
        Proc_BLL prc = new Proc_BLL();
        Nhanvien_BLL nv = new Nhanvien_BLL();
        TracuuHD_BLL tc = new TracuuHD_BLL();
        public string maloai;
        public frBienNhan()
        {
            InitializeComponent();
            btnTim.Click += BtnTim_Click;
            btnRF.Click += BtnRF_Click;
            btnEX.Click += BtnEX_Click;
            btnThoat.Click += BtnThoat_Click;
            btnIn.Click += BtnIn_Click;
            btnThem.Click += btnThem_Click;
            txtSoCT.KeyDown += TxtSoCT_KeyDown;
            btnDB.Click += BtnDB_Click;
            chkKyHD.CheckedChanged += chkKyHD_CheckedChanged;
            chkNgay.CheckedChanged += chkNgay_CheckedChanged;
            chkNVlap.CheckedChanged += chkNVlap_CheckedChanged;
            chkNVnop.CheckedChanged += chkNVnop_CheckedChanged;
            btnCT.Click += btnCT_Click;
        }

        void btnCT_Click(object sender, EventArgs e)
        {
            if (dgvChitiet.RowCount > 0)
            {
                frSuaCT f = new frSuaCT();
                f.ID_CT = dgvChitiet.SelectedRows[0].Cells[ID_CTColumn.Name].Value.ToString();
                f.maloai = ct.getLCT(dgvChitiet.SelectedRows[0].Cells[ID_CTColumn.Name].Value.ToString());
                f.nvnop_dgv = dgvChitiet.SelectedRows[0].Cells[NV_nop.Name].Value.ToString();
                f.enbale = false;
                f.MdiParent = this.MdiParent;
                f.Dock = DockStyle.Fill;
                f.Show();
            }
            else
                MessageBox.Show("Không có biên nhận nào trong danh sách!");
            
        }
        void btnThem_Click(object sender, EventArgs e)
        {
            switch (maloai)
            {
                case "KH":
                    frGachNo_TaiQuay frm = new frGachNo_TaiQuay();
                    frm.MdiParent = this.MdiParent;
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                    break;
                case "CK":
                    frGachNo_CK_KH f = new frGachNo_CK_KH();
                    f.MdiParent = this.MdiParent;
                    f.Dock = DockStyle.Fill;
                    f.Show();
                    break;
                case "TT":
                    frGacho_NV tq = new frGacho_NV();
                    tq.MdiParent = this.MdiParent;
                    tq.Dock = DockStyle.Fill;
                    tq.Show();
                    break;
                default: 
                    break;
            }
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
        // dong bo hoa don đt
        private void BtnDB_Click(object sender, EventArgs e)
        {
            if (dgvChitiet.RowCount <= 0)
                MessageBox.Show("Vui lòng chọn chứng từ!");
            else {
                decimal ID_CT_dgv = decimal.Parse( dgvChitiet.SelectedRows[0].Cells[ID_CTColumn.Name].Value.ToString());
                var sl = db.CHUNGTU_HOADON.Where(x=>x.ID_CT == ID_CT_dgv && x.dadongbo == false).Count();
                var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
                if (sl == 0)
                    MessageBox.Show("Chứng từ này đã được đồng bộ, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn đồng bộ hóa đơn điện tử?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        var ListFkey = db.CHUNGTU_HOADON.Where(x => x.ID_CT == ID_CT_dgv && x.dadongbo == false).ToList();
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
                            var dadongbo = db.CHUNGTU_HOADON.Where(x => x.ID_CT == ID_CT_dgv && x.dadongbo == false).Count();
                            if (dadongbo == 0)
                            {
                                var chungtu = db.CHUNGTUs.Where(x => x.ID_CT == ID_CT_dgv).FirstOrDefault();
                                chungtu.trangthai = true;
                                db.SaveChanges();
                            }
                            btnTim.PerformClick();
                            tss();
                            MessageBox.Show("Đồng bộ thành công!");
                        }
                        else
                        {
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
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            
        }
        // tim so chung tu
        private void TxtSoCT_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtSoCT.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var data = db.DSBIENNHANs.Where(a => a.maloai == maloai && a.SOCT.Contains(text) || a.ID_kyghi.Contains(text) || a.nvnop.Contains(text) || a.nvlap.Contains(text));
                    dgvChitiet.DataSource = data.OrderBy(x => x.ngaylap).OrderByDescending(x => x.ID_CT).ToList();
                }
            }
        }
        // in bien nhan
        private void BtnIn_Click(object sender, EventArgs e)
        {
            if (dgvChitiet.RowCount <= 0)
                MessageBox.Show("Không có chứng từ nào trong danh sách!");
            else
            {
                decimal ID_CT_dgv = decimal.Parse(dgvChitiet.SelectedRows[0].Cells[ID_CTColumn.Name].Value.ToString());
                int soluong = db.CHUNGTU_HOADON.Where(x => x.ID_CT == ID_CT_dgv).Count();
                if (soluong == 0)
                    MessageBox.Show("Chứng từ không có hóa đơn nào, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    PhieuThuKH frm = new PhieuThuKH();
                    frm.ID_CT = dgvChitiet.SelectedRows[0].Cells[ID_CTColumn.Name].Value.ToString();
                    frm.Maloai = ct.getLCT(dgvChitiet.SelectedRows[0].Cells[ID_CTColumn.Name].Value.ToString());
                    frm.ShowDialog();
                    this.Cursor = Cursors.Default;
                    //frm.Hide();
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
            btnTim.PerformClick();
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            try
            {
                var data = from a in db.DSBIENNHANs where a.maloai == maloai select a;
                string kyghi = cbokyghi.SelectedValue.ToString();
                DateTime tungay = dtpNgaylap.Value;
                DateTime denngay = dtpdenngay.Value;
                string nhanvien = cboNV.SelectedValue.ToString() == "" ? "0" : cboNV.SelectedValue.ToString();
                string nhanvien_lap = cboNVlap.SelectedValue.ToString() == "" ? "0" : cboNVlap.SelectedValue.ToString();
                if (chkKyHD.Checked == true)
                    data = data.Where(x => x.ID_kyghi == kyghi);
                if (chkNgay.Checked == true)
                    data = data.Where(x => x.ngaylap >= tungay && x.ngaylap <= denngay);
                if (chkNVnop.Checked == true)
                    data = data.Where(x => x.NV_ID_nop.ToString() == nhanvien);
                if (chkNVlap.Checked == true)
                    data = data.Where(x => x.NV_ID_lap.ToString() == nhanvien_lap);
                dgvChitiet.DataSource = data.OrderByDescending(x => x.ID_CT).ToList();
                for (int i = 0; i < dgvChitiet.RowCount; i++)
                    dgvChitiet.Rows[i].Cells[STT.Name].Value = i + 1;
                tss();
            }
             catch
            {
                MessageBox.Show("Chưa nhập tên lộ trình");
            }
        }
        // toolstrip
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

        private void frBienNhan_Load(object sender, EventArgs e)
        {
            dgvChitiet.AutoGenerateColumns = false;
            // cbo ky ghi
            cbokyghi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbokyghi.DataSource = db.DANHMUCKYGHIs.OrderByDescending(x=>x.ID_kyghi).ToList();
            cbokyghi.ValueMember = "ID_Kyghi";
            cbokyghi.DisplayMember = "Ten_kyghi";
            // cbo nhan vien thu tien nuoc
            cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNV.DataSource = (from a in db.NHANVIENs
                                from b in db.LOAINHANVIENs
                                from c in db.NHANVIEN_LNV
                                where a.NV_ID == c.NV_ID && b.ID_LoaiNV == c.ID_LoaiNV
                                && c.ID_LoaiNV == 7
                                select new
                                {
                                    full = a.maNV + " - " + a.hoten,
                                    a.NV_ID
                                }).OrderBy(x => x.full).ToList();
            cboNV.ValueMember = "NV_ID";
            cboNV.DisplayMember = "full";
            string[] ds = { "chưa đồng bộ", "đã đồng bộ" };
            //cbo nhan viên thu ngan
            cboNVlap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNVlap.DataSource = (from a in db.NHANVIENs
                                   from b in db.LOAINHANVIENs
                                   from c in db.NHANVIEN_LNV
                                   where a.NV_ID == c.NV_ID && b.ID_LoaiNV == c.ID_LoaiNV
                                   && c.ID_LoaiNV == 5
                                   select new
                                   {
                                       full = a.hoten,
                                       a.NV_ID
                                   }).OrderBy(x => x.full).ToList();
            cboNVlap.ValueMember = "NV_ID";
            cboNVlap.DisplayMember = "full";
            // color row dgv
            cboNV.Enabled = false;
            cboNVlap.Enabled = false;
            dtpdenngay.Enabled = false;
            dtpNgaylap.Enabled = false;
            cbokyghi.Enabled = false;
            // tool strip
            tss();
        }
    }
}
