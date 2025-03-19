using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcGachNo_ThuHo : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private List<getDataThuHo_Result> dsDaDongTien = new List<getDataThuHo_Result>();
        private List<getDataThuHo_Result> dsGachNo = new List<getDataThuHo_Result>();

        public UcGachNo_ThuHo()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            btnConfirm.Click += btnConfirm_Click;
            btnThoat.Click += btnThoat_Click;
            //chkAll.CheckedChanged += chkAll_CheckedChanged;
            txtTim.KeyDown += txtTim_KeyDown;
            //dgvDSHD.RowEnter += dgvDSHD_RowEnter;
            btnGachNo.Click += btnGachNo_Click;
            btnXoaGachNo.Click += btnXoaGachNo_Click;
            //checkAll_dgv2.CheckedChanged += checkAll_dgv2_CheckedChanged;
            btnCapnhat.Click += btnCapnhat_Click;
            chkHuyTT.CheckedChanged += chkHuyTT_CheckedChanged;
        }

        private void chkHuyTT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHuyTT.Checked == true)
                txtlydohuy.Enabled = true;
            else
                txtlydohuy.Enabled = false;
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (chkHuyTT.Checked == true)
            {
                string lydo = txtlydohuy.Text;
                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                foreach (DataGridViewRow r in dgvDSHD.Rows)
                {
                    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checkColumn.Name];
                    var thu = checks.Value;
                    if (Convert.ToBoolean(thu) == true)
                    {
                        decimal IDHD = decimal.Parse(dgvDSHD[IDHDColumn.Name, r.Index].Value.ToString());
                        var gachno = db.GACHNOes.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        string madanhbo = "";
                        var dsgachno = db.GACHNOes.Where(x => x.PRODUCTS == gachno.PRODUCTS).ToList();
                        string kyHD = "";
                        foreach (var item in dsgachno)
                        {
                            var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            madanhbo = hoadon.DANHBO;
                            if (kyHD == "")
                                kyHD = hoadon.DM_KYGHI.nam.ToString() + "/" + hoadon.DM_KYGHI.thang.ToString("00");
                            else
                                kyHD = kyHD + ", " + hoadon.DM_KYGHI.nam.ToString() + "/" + hoadon.DM_KYGHI.thang.ToString("00");
                        }
                        int tongtien = int.Parse(dsgachno.Select(x => x.TONGTHANHTOAN).Sum().ToString());
                        string ngaydathu = DateTime.Parse(gachno.DATE_CREATE.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        object[] Arr_result = tdc.ThanhToanHoaDon_HuyGiaoDich("WASS01", hashkey, Common.username, madanhbo, gachno.PRODUCTS.ToString(), kyHD, ngaydathu, tongtien, lydo).ToArray();
                        string result = Arr_result[0].ToString().ToUpper();
                        if (result == "TRUE")
                        {
                            db.Database.ExecuteSqlCommand("exec deteleGachnothuho '" + gachno.PRODUCTS + "'");
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            GIAODICH ct = new GIAODICH();
                            ct.DANHBO = madanhbo;
                            ct.LYDO = txtlydohuy.Text + " " + gachno.PRODUCTS;
                            ct.TONGTIEN = tongtien;
                            db.GIAODICHes.Add(ct);
                            db.SaveChanges();
                        }
                        btnTim.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập lý do hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkAll_dgv2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow r in dgvDSHD.Rows)
                {
                    r.Cells[checkColumn.Name].Value = true;
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow r in dgvDSHD.Rows)
                {
                    r.Cells[checkColumn.Name].Value = false;
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btnXoaGachNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkAll_dgv2.Checked == true)
                {
                    dsDaDongTien.AddRange(dsGachNo);
                    var data = new List<getDataThuHo_Result>();
                    dsGachNo = data;
                }
                else
                {
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checkColumn_dgv2.Name];
                        var thu = checks.Value;
                        if (Convert.ToBoolean(thu) == true)
                        {
                            decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn_dgv2.Name, r.Index].Value.ToString());
                            var isdagachno = dsGachNo.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            if (isdagachno != null)
                            {
                                var hoadon = dsGachNo.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                                dsGachNo.Remove(hoadon);
                                dsDaDongTien.Add(hoadon);
                            }
                        }
                    }
                }
                dataGridView1.DataSource = dsGachNo.ToList();
                dgvDSHD.DataSource = dsDaDongTien.ToList();
                txtsoHD.Text = dsGachNo.Count().ToString();
                txttongthanhtoan.Text = string.Format("{0:n0}", dsGachNo.Sum(z => z.tongtien));
            }
            catch
            {
            }
        }

        private void btnGachNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked == true)
                {
                    dsGachNo.AddRange(dsDaDongTien);
                    var data = new List<getDataThuHo_Result>();
                    dsDaDongTien = data;
                }
                else
                {
                    foreach (DataGridViewRow r in dgvDSHD.Rows)
                    {
                        DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checkColumn.Name];
                        var thu = checks.Value;
                        if (Convert.ToBoolean(thu) == true)
                        {
                            decimal IDHD = decimal.Parse(dgvDSHD[IDHDColumn.Name, r.Index].Value.ToString());
                            var isdagachno = dsGachNo.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            if (isdagachno == null)
                            {
                                var hoadon = dsDaDongTien.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                                dsGachNo.Add(hoadon);
                                dsDaDongTien.Remove(hoadon);
                            }
                        }
                    }
                }
                dataGridView1.DataSource = dsGachNo.ToList();
                dgvDSHD.DataSource = dsDaDongTien.ToList();
                txtsoHD.Text = dsGachNo.Count().ToString();
                txttongthanhtoan.Text = string.Format("{0:n0}", dsGachNo.Sum(z => z.tongtien));
            }
            catch
            {
            }
        }

        //void dgvDSHD_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //}

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow r in dgvDSHD.Rows)
                {
                    r.Cells[checkColumn.Name].Value = true;
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (DataGridViewRow r in dgvDSHD.Rows)
                {
                    r.Cells[checkColumn.Name].Value = false;
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //    this.Close();
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dgvDSHD);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (dataGridView1.RowCount > 0)
            {
                if (chkBK.Checked == true)
                {
                    DialogResult rs = MessageBox.Show("Xác nhận đã đủ số tiền?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                        var kyghi = db.DM_KYGHI.Where(x => x.gachno == true).FirstOrDefault();
                        string NVTHU = cboNV.SelectedValue.ToString();
                        string ghichu = txtghichu.Text;
                        // add chung tu
                        CHUNGTU chungtu = new CHUNGTU();
                        chungtu.ID_KYGHI = kyghi.ten_kyghi;
                        chungtu.MALOAI = "CK";
                        chungtu.NGAYLAP = DateTime.Now;
                        chungtu.NV_ID_LAP = NVLap.nv_id;
                        chungtu.NV_ID_NOP = decimal.Parse(NVTHU);
                        chungtu.TONGTIEN = decimal.Parse(txttongthanhtoan.Text);
                        chungtu.GHICHU = ghichu;
                        chungtu.TRANGTHAI = false;
                        chungtu.NGAYCT = dtpBK.Value;
                        chungtu.SOCT = CreateSO_CT();
                        db.CHUNGTUs.Add(chungtu);
                        db.SaveChanges();
                        // add chung tu hoa don
                        List<CHUNGTU_HOADON> dschungtu_hoadon = new List<CHUNGTU_HOADON>();
                        List<DANGNGAN> dn = new List<DANGNGAN>();
                        foreach (var item in dsGachNo)
                        {
                            var gachno = db.GACHNOes.Where(x => x.ID_HD == item.ID_HD).FirstOrDefault();
                            gachno.STATUS = true;
                            db.SaveChanges();
                            dschungtu_hoadon.Add(new CHUNGTU_HOADON()
                            {
                                ID_CT = chungtu.ID_CT,
                                ID_HD = item.ID_HD,
                                TONGTIEN = gachno.TONGTHANHTOAN,
                                DOT_ID = gachno.DOT_ID,
                                NVID_THU = gachno.NV_ID_NOP,
                                NVID_CREATE = NVLap.nv_id,
                                NGAYTHU = gachno.NGAYTHANHTOAN,
                                NGAYTAO = DateTime.Now,
                                DADONGBO = false,
                                ID_Kyghi = gachno.ID_KYGHI,
                                ID_KH = gachno.ID_KH,
                                GHICHU = gachno.PRODUCTS
                            });
                        }

                        //db.SetChungTu_HoaDon(IDCT_Nhanvien, int.Parse(NVLap.nv_id.ToString()),decimal.Parse(NVTHU));
                        db.CHUNGTU_HOADON.AddRange(dschungtu_hoadon);
                        db.SaveChanges();
                        db.Database.ExecuteSqlCommand("exec DANGNGAN_NV " + Common.NVID.ToString() + ", " + chungtu.ID_CT.ToString());
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnTim.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Chưa chọn ngày bảng kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //}
            //catch
            //{
            //}
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dsDaDongTien = new List<getDataThuHo_Result>();
            int NVID = int.Parse(cboNV.SelectedValue.ToString());
            string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string text = txtTim.Text;
            string kyghi = "0";
            if (chkKy.Checked == true)
                kyghi = cboKy.SelectedValue.ToString();
            var dataSource = db.getDataThuHo(NVID, tungay, denngay, kyghi, text.Replace(" ", String.Empty)).OrderBy(x => x.NGAYTHANHTOAN).ToList();
            dsDaDongTien.AddRange(dataSource);
            dgvDSHD.DataSource = dataSource.ToList();
            txtsoHD.Text = dataSource.Count().ToString();
            txttongthanhtoan.Text = string.Format("{0:n0}", dataSource.Sum(z => z.tongtien));
            this.Cursor = Cursors.Default;
        }

        private void frGachNo_ThuHo_Load(object sender, EventArgs e)
        {
            dgvDSHD.AutoGenerateColumns = false;
            cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            var dmNganhang = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList();
            cboNV.DataSource = dmNganhang.ToList();
            cboNV.ValueMember = "NGANHANG_ID";
            cboNV.DisplayMember = "TENNGANHANG";
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            var dataKyHD = db.DM_KYGHI.OrderByDescending(x => x.ID_kyghi).ToList();
            cboKy.DataSource = dataKyHD.ToList();
            cboKy.ValueMember = "Id_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            btnCapnhat.Visible = Common.isxoa;
            dtpBK.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpBK.CustomFormat = "dd/MM/yyyy";

            btnConfirm.Enabled = false;
        }

        public string CreateSO_CT()
        {
            string kyghi_gn = db.DM_KYGHI.Where(x => x.gachno == true).FirstOrDefault().ID_kyghi;
            string maxid = db.CHUNGTUs.Where(x => x.ID_KYGHI == kyghi_gn).Select(x => x.SOCT).Max();
            if (maxid == null)
                maxid = "0";
            string filtered = Regex.Replace(maxid, "[A-Za-z]", "");
            long id = Convert.ToInt32(filtered);
            id++;
            string strid = id.ToString("0000") + "TH";
            return strid;
        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void btnCapnhat_Click_1(object sender, EventArgs e)
        {

        }
    }
}