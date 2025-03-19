using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLCongNo.Data;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcGachNoNV : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        //decimal pIDHD = 0;
        public UcGachNoNV()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnEX.Click += btnEX_Click;
            btnTim.Click += btnTim_Click;
            btnConfirm.Click += btnConfirm_Click;
            cboTO.SelectedIndexChanged += cboTO_SelectedIndexChanged;
            btnXoaGachNo.Click += btnXoaGachNo_Click;
            //dgvDSHD.RowEnter += dgvDSHD_RowEnter;
            txtTim.KeyDown += txtTim_KeyDown;
        }

        //void dgvDSHD_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dgvDSHD.RowCount > 0)
        //    {
        //        pIDHD = decimal.Parse(dgvDSHD[IDHDColumn.Name, e.RowIndex].Value.ToString());
        //    }
        //}

        private void btnXoaGachNo_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (dgvDSHD.RowCount > 0)
            {
                if (chkLydo.Checked == false)
                    MessageBox.Show("Chưa nhập lý do hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DialogResult rs = MessageBox.Show("Xác nhận hủy thanh toán?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        decimal pIDHD = decimal.Parse(dgvDSHD.SelectedRows[0].Cells[IDHDColumn.Name].Value.ToString());
                        DataTable dt = new DataTable() { TableName = "MyTableName" }; ;
                        DataColumn column;
                        DataRow row;
                        column = new DataColumn();
                        column.DataType = Type.GetType("System.String");
                        column.ColumnName = "nam";
                        dt.Columns.Add(column);
                        column = new DataColumn();
                        column.DataType = Type.GetType("System.String");
                        column.ColumnName = "ky";
                        dt.Columns.Add(column);
                        column = new DataColumn();
                        column.DataType = Type.GetType("System.String");
                        column.ColumnName = "ID_HD";
                        dt.Columns.Add(column);
                        var Phieuthu = db.dm_phieu_thu.Where(x => x.FKEY == pIDHD.ToString()).FirstOrDefault();
                        var dsphieuthu = db.dm_phieu_thu.Where(x => x.ma_kh == Phieuthu.ma_kh && x.Checks == 0).ToList();
                        int nvid = int.Parse(Phieuthu.nv_id.ToString());
                        foreach (var item in dsphieuthu)
                        {
                            decimal IDHD = decimal.Parse(item.FKEY);
                            row = dt.NewRow();
                            row["nam"] = item.thang_ps.ToString().Substring(0, 4);
                            row["ky"] = int.Parse(item.thang_ps.ToString().Substring(4, 2));
                            row["ID_HD"] = item.FKEY;
                            dt.Rows.Add(row);
                            ChungTuLog log = new ChungTuLog();
                            log.id_ct = 0;
                            log.id_hd = IDHD;
                            log.manv = Common.username;
                            log.ngaylap = DateTime.Now;
                            log.lydo = txtlydo.Text;
                            log.nvid = nvid;
                            log.ngaythu = Phieuthu.ngay_thuc_hien;
                            db.ChungTuLogs.Add(log);
                            db.SaveChanges();
                        }
                        int l = dt.Rows.Count;
                        int tongtien = int.Parse(dsphieuthu.Select(x => x.tong_thu).Sum().ToString());
                        string ngaythu = DateTime.Parse(Phieuthu.ngay_thuc_hien.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                        ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                        object[] Arr_result = tdc.ThanhToanHoaDon_HuyGiaoDich_AppThu("WASS01", hashkey, Common.username, Phieuthu.so_bo, dt, ngaythu, tongtien, txtlydo.Text);
                        string result = Arr_result[0].ToString().ToUpper();
                        db.Database.ExecuteSqlCommand("exec resetThuNoApp " + Phieuthu.ma_kh.ToString() + ", " + Phieuthu.nv_id.ToString());
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (result == "TRUE")
                        //{
                        //    db.Database.ExecuteSqlCommand("exec resetThuNoApp " + Phieuthu.ma_kh + ", " + Phieuthu.nv_id.ToString());
                        //    MessageBox.Show("Cập nhật thành công!");
                        //}
                        //else
                        //    MessageBox.Show("Có lỗi xảy ra trong quá trình xử lý, mã lỗi: " + Arr_result[0].ToString() + "-" + Arr_result[1].ToString() + "-" + Arr_result[2].ToString());
                        btnTim.PerformClick();
                    }
                }
            }

            //    }
            //    catch
            //    {
            //        MessageBox.Show("Có lỗi trong quá trình xử lý");
            //    }
        }

        private void cboTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int TOID = int.Parse(cboTO.SelectedValue.ToString());
                LoadNhanVien(TOID);
            }
            catch
            {
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvDSHD.RowCount > 0)
            {
                DialogResult rs = MessageBox.Show("Xác nhận nhân viên đã nộp đủ số tiền?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                    var kyghi = db.DM_KYGHI.Where(x => x.gachno == true).FirstOrDefault();
                    string NVTHU = cboNV.SelectedValue.ToString();
                    string ghichu = txtghichu.Text;
                    decimal tongtien = decimal.Parse(txttongthanhtoan.Text);
                    // add chung tu
                    CHUNGTU chungtu = new CHUNGTU();
                    chungtu.ID_KYGHI = kyghi.ID_kyghi;
                    chungtu.MALOAI = "TT";
                    chungtu.NGAYLAP = DateTime.Now;
                    chungtu.NV_ID_LAP = NVLap.nv_id;
                    chungtu.NV_ID_NOP = decimal.Parse(NVTHU);
                    chungtu.TONGTIEN = 0;
                    chungtu.GHICHU = ghichu;
                    chungtu.TRANGTHAI = false;
                    chungtu.NGAYCT = DateTime.Now;
                    chungtu.TONGTIEN = tongtien;
                    db.CHUNGTUs.Add(chungtu);
                    db.SaveChanges();
                    // add chung tu hoa don
                    var IDCT_Nhanvien = db.CHUNGTUs.Where(x => x.NV_ID_LAP == NVLap.nv_id).Max(x => x.ID_CT);
                    SqlParameter NVID_THU = new SqlParameter("NV_THU", NVTHU);
                    SqlParameter NVID_LAP = new SqlParameter("NV_LAP", NVLap.nv_id);
                    SqlParameter IDCT = new SqlParameter("ID_CT", IDCT_Nhanvien);
                    SqlParameter NGAYTAO = new SqlParameter("NGAYTAO", DateTime.Now);
                    var confirm = db.Database.ExecuteSqlCommand("EXEC GACHNONHANVIEN @ID_CT, @NV_THU, @NV_LAP, @NGAYTAO", IDCT, NVID_THU, NVID_LAP, NGAYTAO);
                    MessageBox.Show("Xác nhận thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTim.PerformClick();
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //try
            //{
            this.Cursor = Cursors.WaitCursor;
            decimal NVID = decimal.Parse(cboNV.SelectedValue.ToString());
            int nam = int.Parse(cboNam.SelectedValue.ToString());
            int dot = int.Parse(cboDot.SelectedValue.ToString());
            string kyghi = cboKyHD.SelectedValue.ToString();
            string denky = cbodenky.SelectedValue.ToString();
            string tungay = dtpNgaythu.Value.ToString("yyyy-MM-dd");
            string denngay = dtpdenngay.Value.ToString("yyyy-MM-dd");
            string text = txtTim.Text;
            if (chkNam.Checked == false)
                nam = 0;
            if (chkDot.Checked == false)
                dot = 0;
            if (chkKy.Checked == false)
                kyghi = "0";
            if (chkNgay.Checked == false)
                tungay = "";
            var dataSource = db.getDataAppMobile(NVID, tungay, denngay, nam, dot, kyghi, denky, text).ToList();
            if(dataSource.Count > 0)
            {
                dgvDSHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }    
            dgvDSHD.DataSource = dataSource.ToList();
            txtsoHD.Text = dataSource.Count().ToString();
            txttongthanhtoan.Text = string.Format("{0:n0}", dataSource.Sum(z => z.tongtien));
            this.Cursor = Cursors.Default;
            //}
            //catch
            //{
            //}
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dgvDSHD);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //    this.Close();
        }

        private void frGachNoNV_Load(object sender, EventArgs e)
        {
            dgvDSHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSHD.AutoGenerateColumns = false;
            dtpdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpdenngay.CustomFormat = "dd/MM/yyyy";
            dtpNgaythu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgaythu.CustomFormat = "dd/MM/yyyy";
            cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboKyHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            var dataDot = db.DM_DOT.ToList();
            cboDot.DataSource = dataDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            var dataNam = db.DM_NAM.ToList();
            cboNam.DataSource = dataNam;
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
            var dataKyHD = db.DM_KYGHI.ToList();
            cboKyHD.DataSource = dataKyHD.ToList();
            cboKyHD.ValueMember = "Id_kyghi";
            cboKyHD.DisplayMember = "ten_kyghi";
            cbodenky.DataSource = dataKyHD.ToList();
            cbodenky.ValueMember = "Id_kyghi";
            cbodenky.DisplayMember = "ten_kyghi";
            LoadNhanVien(Common.TOID);
            if (Common.TOID == 0)
                LoadTO(-1);
            else
                LoadTO(Common.TOID);
            btnXoaGachNo.Visible = Common.isxoa;
        }

        public void LoadTO(decimal? TOID)
        {
            cboTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            var data = DataDanhMuc.getDSTo(TOID).ToList();
            cboTO.DataSource = data.ToList();
            cboTO.ValueMember = "TO_ID";
            cboTO.DisplayMember = "TENTO";
        }

        public void LoadNhanVien(decimal? TOID)
        {
            cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            var data = DataDanhMuc.getDSNhanvien(TOID).Select(x => new { hoten = x.maNV + " - " + x.hoten, x.NV_ID }).ToList();
            cboNV.DataSource = data.ToList();
            cboNV.DisplayMember = "hoten";
            cboNV.ValueMember = "NV_ID";
        }

        private void chkKy_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

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
    }
}