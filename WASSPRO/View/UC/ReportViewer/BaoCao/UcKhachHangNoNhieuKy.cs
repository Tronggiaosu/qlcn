using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcKhachHangNoNhieuKy : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private decimal IDKH = 0;
        private DataTable table;

        public UcKhachHangNoNhieuKy()
        {
            InitializeComponent();
            dgvDSKhachHangNo.RowEnter += dgvDSKhachHangNo_RowEnter;
            btnExcel.Click += btnExcel_Click;
            txtsoky.KeyPress += txtsoky_KeyPress;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
        }

        private void txtsoky_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string denngay = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                int tuky = int.Parse(CboTuKy.SelectedValue.ToString());
                int denky = int.Parse(cboDenKy.SelectedValue.ToString());
                string maquan = cboQuan.SelectedValue.ToString();
                string maphuong = cboPhuong.SelectedValue.ToString();
                int soky = 0;
                if (chksoky.Checked == true)
                    soky = int.Parse(txtsoky.Text);
                var data = db.getDSChitietKhachhangnonhieuky(maquan, maphuong, txtTimKiem.Text.Replace(" ", String.Empty), tuky, denky, denngay, soky).ToList();
                table = ExcelExportHelper.ListToDataTable(data.ToList());
                string[] columns = { "tenTT", "danhbo", "hoten", "diachihoadon", "malt", "nvthu", "NAM", "KYHD", "doituong", "SOPHATHANH", "tieuthu", "tn", "thue", "phi", "PhiNT", "thueNT", "tc", "m3_DC",
                                   "tienuoc_dc", "tienthue_dc", "tienphi_dc", "tienphiNT_dc",  "TienThueNT_dc","tongdc", "seri", "trangthaiHD"};

                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDSKhachHangNo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            IDKH = decimal.Parse(dgvDSKhachHangNo[IDKHColumn.Name, e.RowIndex].Value.ToString());
        }

        private void dgvDSKhachHangNo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvDSKhachHangNo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void LoadTuKy()
        {
            CboTuKy.DropDownStyle = ComboBoxStyle.DropDownList;
            var tky = db.DM_KYGHI.ToList();
            CboTuKy.DataSource = tky.ToList();
            CboTuKy.DisplayMember = "ten_kyghi";
            CboTuKy.ValueMember = "id_kyghi";
        }

        public void LoadDenKy()
        {
            cboDenKy.DropDownStyle = ComboBoxStyle.DropDownList;
            var dky = db.DM_KYGHI.OrderByDescending(x => x.ID_kyghi).ToList();
            cboDenKy.DataSource = dky.ToList();
            cboDenKy.DisplayMember = "ten_kyghi";
            cboDenKy.ValueMember = "id_kyghi";
        }

        public void LoadQuan()
        {
            cboQuan.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_QUAN> dsquan = new List<DM_QUAN>();
            dsquan.Add(new DM_QUAN() { maQuan = "0", tenQuan = "Tất cả" });
            var quan = db.DM_QUAN.ToList();
            dsquan.AddRange(quan);
            cboQuan.DataSource = quan.ToList();
            cboQuan.DisplayMember = "tenQuan";
            cboQuan.ValueMember = "maQuan";
        }

        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            var maQuan = cboQuan.SelectedValue.ToString();
            if (maQuan != "0")
            {
                cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
                List<DM_PHUONG> phuong = new List<DM_PHUONG>();
                phuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                var data = db.DM_PHUONG.Where(x => x.maQuan == maQuan).OrderBy(x => x.tenPhuong).ToList();
                phuong.AddRange(data);
                cboPhuong.DataSource = phuong.ToList();
                cboPhuong.ValueMember = "maPhuong";
                cboPhuong.DisplayMember = "tenPhuong";
            }
        }

        private void frKhachHangNoNhieuKy_Load(object sender, EventArgs e)
        {
            dgvDSKhachHangNo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSKhachHangNo.AutoGenerateColumns = false;
            LoadTuKy();
            LoadDenKy();
            LoadQuan();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int tuky = 0;
            int denky = 0;
            string denngay = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            tuky = int.Parse(CboTuKy.SelectedValue.ToString());
            denky = int.Parse(cboDenKy.SelectedValue.ToString());

            string maquan = "0";
            maquan = cboQuan.SelectedValue.ToString();

            string maphuong = cboPhuong.SelectedValue.ToString();
            var datasource = db.getDSKhachHangNoNhieuKy(maquan, maphuong, txtTimKiem.Text.Replace(" ", String.Empty), tuky, denky, denngay).AsQueryable();
            int soky = int.Parse(txtsoky.Text == "" ? "0" : txtsoky.Text);
            decimal tongtien = decimal.Parse(txttongtienno.Text == "" ? "0" : txttongtienno.Text);
            if (chksoky.Checked == true)
                datasource = datasource.Where(x => x.soluong >= soky);
            if (chktienno.Checked)
                datasource = datasource.Where(x => x.tongtien >= tongtien);
            var dataList = datasource.ToList();
            if(dataList.Count > 0)
            {
                dgvDSKhachHangNo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }    
            dgvDSKhachHangNo.DataSource = dataList;
            for (int i = 0; i < dgvDSKhachHangNo.RowCount; i++)
                dgvDSKhachHangNo.Rows[i].Cells[STTColumn.Name].Value = i + 1;
            lblsoluong.Text = "Số lượng khách hàng: "
                + string.Format("{0:n0}", dataList.Count)
                + " | Số lượng hóa đơn: " + string.Format("{0:n0}", dataList.Sum(x => x.soluong))
                + "  |  Tổng tiền: " + string.Format("{0:n0}", dataList.Sum(x => x.tongtien));

            this.Cursor = Cursors.Default;
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            //frDSHoaDon_KH frDShoadon = new frDSHoaDon_KH();
            ////frDShoadon.MdiParent = this.MdiParent;
            //////foreach (Form otherForm in this.MdiChildren)
            //////    if (otherForm != frm)
            //////        otherForm.Close();
            ////frDShoadon.Dock = DockStyle.Fill;
            //frDShoadon.idkh = IDKH;
            //frDShoadon.ShowDialog();

            //try
            //{
            //    if (dgvDSKhachHangNo.RowCount > 0)
            //    {
            //        var senderGrid = dgvDSKhachHangNo; 
            //        int rowIndex = dgvDSKhachHangNo.CurrentCell.RowIndex; 
            //        //int columnIndex = dgvDSKhachHangNo.CurrentCell.ColumnIndex; 

            //        //if (senderGrid.Columns[columnIndex] is DataGridViewButtonColumn && rowIndex >= 0)
            //        //{
            //            this.Cursor = Cursors.WaitCursor;

            //            decimal IDHD = decimal.Parse(dgvDSKhachHangNo.Rows[rowIndex].Cells[IDKHColumn.Name].Value.ToString());
            //            //if (columnIndex == 11)
            //            //{
            //                Portal.PortalService portal = new Portal.PortalService();
            //                var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
            //                var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
            //                var hoadonloi = db.HOADONs.Where(x => x.ID_KH == hoadon.ID_KH && x.trangthai_id == -22).FirstOrDefault();
            //                var hoadonsai = db.HOADONs.Where(x => x.ID_HD == IDHD && x.DOT_ID == 1 && x.kyghi == "202302" && x.keys == null).FirstOrDefault();

            //                if (hoadonloi != null)
            //                    IDHD = hoadonloi.ID_HD;

            //                var result = portal.getInvViewFkeyNoPay(IDHD.ToString(), accWS.acc_service, "123456aA@");
            //                portal78.PortalService p78 = new portal78.PortalService();

            //                if (hoadonsai != null)
            //                    result = p78.getInvViewFkeyNoPay(hoadonsai.DienGiai, "capnuocthuducservice", "Einv@oi@vn#pt20");
            //                else if (hoadon.MAU_HD == "1/001" || hoadon.MAU_HD == "1/002" || hoadon.MAU_HD == "1/003")
            //                    result = p78.getInvViewFkeyNoPay(IDHD.ToString(), "capnuocthuducservice", "Einv@oi@vn#pt20");

            //                var frm = new Form();
            //                frm.Size = new System.Drawing.Size(1200, 800);
            //                WebBrowser webBrowser = new WebBrowser();
            //                webBrowser.Dock = DockStyle.Fill;
            //                webBrowser.DocumentText = result;
            //                frm.Controls.Add(webBrowser);
            //                frm.ShowDialog();
            //            //}

            //            this.Cursor = Cursors.Default;
            //        //}
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            //}
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btnExcelCongNo_Click(object sender, EventArgs e)
        {
            var frm = new UcCongNoTheoThang
            {
                TuKy = CboTuKy.SelectedValue.ToString(),
                DenKy = cboDenKy.SelectedValue.ToString(),
                DenNgay = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")
            };
            new FrmDialog().ShowDialog(frm);
        }

        private void txtTimKiem_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtsoky.Text;
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