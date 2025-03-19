using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLCongNo.BLL;
using QLCongNo.ReportViewer.DataSource;
namespace QLCongNo.FORM
{
    public partial class frGacho_NV : Form
    {
        ChungTu_BLL ct = new ChungTu_BLL();
        DataTable dt1 = new DataTable();
        CHUNGTU_HOADON CT_HD = new CHUNGTU_HOADON();
        CHUNGTU CT_EN = new CHUNGTU();
        DSTAM ds = new DSTAM();
        Nhanvien_BLL nv = new Nhanvien_BLL();
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public static bool click = true;
        public static string ID_NV_nop, NV_ID, ID_NV_lap;
        public static string kyghi, tenkyghi;
        public static string bangchu, date;
        public static string SO_CT;
        public frGacho_NV()
        {
            InitializeComponent();
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
            cboNV.SelectedIndexChanged += CboNV_SelectedIndexChanged;
            cbokyghi.SelectedIndexChanged += Cbokyghi_SelectedIndexChanged;
            btnEX.Click += BtnEX_Click;
            btnRF.Click += BtnRF_Click;
        }

        private void BtnRF_Click(object sender, EventArgs e)
        {
            //ct.update_HDThuTrung(NV_ID);
            dgvDSHD.AutoGenerateColumns = false;
            this.Cursor = Cursors.WaitCursor;
            var data = (from a in db.HOADONs
                        from b in db.LOTRINH_THU
                        from c in db.KHACHHANGs
                        from g in db.DANHMUCKYGHIs
                        from f in db.NHANVIENs
                        from d in db.dm_phieu_thu.Where(dm => dm.FKEY == a.ID_HD.ToString())
                        where a.ID_KH == c.ID_KH
                        where a.kyghi == g.ID_kyghi
                        where a.MaLT == b.malt
                        where f.NV_ID == b.nv_id
                        where d.nv_thu == f.maNV
                        where d.Checks == 0
                        where b.nv_id.ToString() == NV_ID
                        select new
                        {
                            ID_HD = a.ID_HD,
                            so_HD = a.SO_HD,
                            ky_hieu_hd = a.KY_HIEU_HD,
                            ten_kyghi = g.ten_kyghi,
                            tongtien = a.tongtien,
                            malt = b.malt,
                            madanhbo = c.madanhbo,
                            hoten_KH = c.hoten_KH,
                            diachi = c.diachi,
                            checks = d.Checks == 0 ? "true" : "false",
                            ID_KH = a.ID_KH
                        });
            dgvDSHD.DataSource = data.ToList();
            if (txttongthanhtoan.Text != "")
                txttongthanhtoan.Text = string.Format("{0:n0}", double.Parse(txttongthanhtoan.Text));
            txtsoHD.Text = dgvDSHD.Rows.Count.ToString();
            toolStripStatusLabel1.Text = "Tổng sô " + dgvDSHD.Rows.Count.ToString();
            cbokyghi.DataSource = ct.getkyhoadon();
            cbokyghi.ValueMember = "ID_kyghi";
            cbokyghi.DisplayMember = "ten_kyghi";
            this.Cursor = Cursors.Default;
        }

        private void BtnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dgvDSHD);
        }
        private void Cbokyghi_SelectedIndexChanged(object sender, EventArgs e)
        {
            kyghi = cbokyghi.SelectedValue.ToString();
            tenkyghi = cbokyghi.Text;
        }
        private void CboNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            NV_ID = cboNV.SelectedValue.ToString();
            if (NV_ID != "System.Data.DataRowView")
            {
                dgvDSHD.AutoGenerateColumns = false;
                this.Cursor = Cursors.WaitCursor;
                var data = (from a in db.HOADONs
                            from b in db.LOTRINH_THU
                            from c in db.KHACHHANGs
                            from g in db.DANHMUCKYGHIs
                            from f in db.NHANVIENs
                            from d in db.dm_phieu_thu.Where(dm => dm.FKEY == a.ID_HD.ToString())
                            where a.ID_KH == c.ID_KH
                            where a.kyghi == g.ID_kyghi
                            where a.MaLT == b.malt
                            where f.NV_ID == b.nv_id
                            where d.nv_thu == f.maNV
                            where d.Checks == 0
                            where b.nv_id.ToString() == NV_ID
                            select new
                            {
                                ID_HD = a.ID_HD,
                                so_HD = a.SO_HD,
                                ky_hieu_hd = a.KY_HIEU_HD,
                                ten_kyghi = g.ten_kyghi,
                                tongtien = a.tongtien == null ? 0 : a.tongtien,
                                malt = b.malt,
                                madanhbo = c.madanhbo,
                                hoten_KH = c.hoten_KH,
                                diachi = c.diachi,
                                checks = d.Checks == 0 ? "true" : "false",
                                ID_KH = a.ID_KH
                            }).ToList();
                dgvDSHD.DataSource = data.ToList();
                foreach (DataGridViewRow dr in dgvDSHD.Rows)
                {
                    var hoadon = (from a in db.CHUNGTU_HOADON
                                 from b in db.dm_phieu_thu
                                 where a.ID_HD.ToString() == b.FKEY
                                 select a).ToList();
                    foreach(var fkey in hoadon){
                        
                    if (Convert.ToDecimal(dr.Cells[ID_HD.Name].Value.ToString()) == fkey.ID_HD)
                        dr.DefaultCellStyle.ForeColor = Color.Red;
                    else
                        dr.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                decimal tongtienthu = 0;
                if(data != null)
                    tongtienthu = data.Select(x => x.tongtien).Sum();
                if (txttongthanhtoan.Text != "")
                    txttongthanhtoan.Text = string.Format("{0:n0}", tongtienthu);
                txtsoHD.Text = dgvDSHD.Rows.Count.ToString();
                toolStripStatusLabel1.Text = "Tổng sô " + dgvDSHD.Rows.Count.ToString();
                cbokyghi.DataSource = ct.getkyhoadon();
                cbokyghi.ValueMember = "ID_kyghi";
                cbokyghi.DisplayMember = "ten_kyghi";
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            var nhanvien = (from a in db.NHANVIENs
                            from c in db.NGUOIDUNGs
                            where a.maNV == c.manv && c.ma_nd == Common.username
                            select a).FirstOrDefault();
            ID_NV_nop = cboNV.SelectedValue.ToString();
            string ngaylap = DateTime.Now.ToString("yyyy-MM-dd");
            string ngaythu = dtpngaythu.Value.ToString("yyyy-MM-dd");
            int kt_ngaythu = DateTime.Compare(Convert.ToDateTime(ngaythu), Convert.ToDateTime(ngaylap));
            string ghichu = txtghichu.Text;
            SO_CT = SO_CT_tutang();
            if (dgvDSHD.Rows.Count > 0)
            {
                if (kt_ngaythu > 0)
                    MessageBox.Show("Ngày thu không đúng, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txttongthanhtoan.Text == "0")
                    MessageBox.Show("Vui lòng chọn hóa đơn đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn thêm mới phiếu thu?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        string kyghi = db.DANHMUCKYGHIs.Where(x => x.gachno == true).FirstOrDefault().ID_kyghi;
                        CT_EN.ID_kyghi = kyghi;
                        CT_EN.ghichu = ghichu;
                        CT_EN.NV_ID_nop = Int32.Parse(ID_NV_nop);
                        CT_EN.NV_ID_lap = nhanvien.NV_ID;
                        CT_EN.SOCT = SO_CT;
                        CT_EN.maloai = "TT";
                        CT_EN.tongtien = 0;
                        CT_EN.ngaylap = DateTime.Now;
                        CT_EN.ngayct = dtpngaythu.Value;
                        db.CHUNGTUs.Add(CT_EN);
                        db.SaveChanges();
                        var IDCT_Nhanvien = db.CHUNGTUs.Where(x => x.NV_ID_lap == nhanvien.NV_ID).Max(x => x.ID_CT);
                        var SOCT_max = new SqlParameter("@soct", IDCT_Nhanvien);
                        var kyghi_gn = new SqlParameter("@kyghi", kyghi);
                        var nv_id_nop = new SqlParameter("@nv_id", ID_NV_nop);
                        var ngaythu_ct = new SqlParameter("@ngaythu", dtpngaythu.Value.ToString("yyyy/MM/dd"));
                        var gachno = db.Database.SqlQuery<DataTable>("GACHNO_NVTHU  @kyghi, @soct, @nv_id, @ngaythu", SOCT_max, kyghi_gn, nv_id_nop, ngaythu_ct).ToList();
                        btnRF.PerformClick();
                        PhieuThuKH frm = new PhieuThuKH();
                        frm.ID_CT = IDCT_Nhanvien.ToString();
                        frm.Maloai = "TT";
                        frm.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có hóa đơn nào trong danh sách, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frGacho_NV_Load(object sender, EventArgs e)
        {
            dgvDSHD.AutoGenerateColumns = false;
            txttongthanhtoan.Enabled = false;
            txttongthanhtoan.Text = "0";
            this.dgvDSHD.RowsDefaultCellStyle.BackColor = Color.White;
            this.dgvDSHD.AlternatingRowsDefaultCellStyle.BackColor = Color.MintCream;
            cbokyghi.DropDownStyle = ComboBoxStyle.DropDownList;
            lbltongtien.Visible = false;
            dtpngaythu.Format = DateTimePickerFormat.Custom;
            dtpngaythu.CustomFormat = "dd/MM/yyyy";
            txtsoHD.Enabled = false;
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
            cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
            // color row dgv
            //this.dgvDSHD.RowsDefaultCellStyle.BackColor = Color.White;
            //this.dgvDSHD.AlternatingRowsDefaultCellStyle.BackColor = Color.MintCream;
            //dgvDSHD.ColumnHeadersDefaultCellStyle.BackColor = Color.NavajoWhite;
            //dgvDSHD.EnableHeadersVisualStyles = false;
        }

        public string SO_CT_tutang()
        {
            string kyghi_gn = db.DANHMUCKYGHIs.Where(x => x.gachno == true).FirstOrDefault().ID_kyghi;
            string maxid = db.CHUNGTUs.Where(x => x.ID_kyghi == kyghi_gn).Select(x => x.SOCT).Max();
            if (maxid == null)
                maxid = "0";
            string filtered = Regex.Replace(maxid, "[A-Za-z]", "");
            long id = Convert.ToInt32(filtered);
            id++;
            string strid = id.ToString("0000") + "TM";
            return strid;
        }
    }
}
