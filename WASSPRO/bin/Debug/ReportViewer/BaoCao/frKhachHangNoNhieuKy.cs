using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.BaoCao
{
    public partial class frKhachHangNoNhieuKy : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        decimal IDKH = 0;
        DataTable table;
        public frKhachHangNoNhieuKy()
        {
            InitializeComponent();
            dgvDSKhachHangNo.RowEnter += dgvDSKhachHangNo_RowEnter;
            btnExcel.Click += btnExcel_Click;
            txtsoky.KeyPress += txtsoky_KeyPress;
        }

        void txtsoky_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {

                this.Cursor = Cursors.WaitCursor;
                int tuky = 0;
                int denky = 0;
                string denngay = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                if (chkTuKy.Checked == true)
                {
                    tuky = int.Parse(CboTuKy.SelectedValue.ToString());
                    denky = int.Parse(cboDenKy.SelectedValue.ToString());
                }
                string maquan = "0";
                if (chkQuan.Checked == true)
                    maquan = cboQuan.SelectedValue.ToString();
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
                MessageBox.Show("Xuất dữ liệu thành công!");
            }
        }

        void dgvDSKhachHangNo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            IDKH = decimal.Parse(dgvDSKhachHangNo[IDKHColumn.Name, e.RowIndex].Value.ToString());
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
            var dky = db.DM_KYGHI.OrderByDescending(x=>x.ID_kyghi).ToList();
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
            if (chkTuKy.Checked == true)
            {
                tuky = int.Parse(CboTuKy.SelectedValue.ToString());
                denky = int.Parse(cboDenKy.SelectedValue.ToString());
            }
            string maquan = "0";
            if (chkQuan.Checked == true)
                maquan = cboQuan.SelectedValue.ToString();
            string maphuong = cboPhuong.SelectedValue.ToString();
            var datasource = db.getDSKhachHangNoNhieuKy(maquan, maphuong, txtTimKiem.Text.Replace(" ", String.Empty), tuky, denky, denngay).ToList();
            int soky = int.Parse(txtsoky.Text == ""? "0" : txtsoky.Text);
            decimal tongtien = decimal.Parse( txttongtienno.Text ==""? "0": txttongtienno.Text);
            if (chksoky.Checked == true)
                datasource = datasource.Where(x => x.soluong >= soky).ToList();
            if(chktienno.Checked)
                datasource = datasource.Where(x => x.tongtien >= tongtien).ToList();
            dgvDSKhachHangNo.DataSource = datasource;
            for (int i = 0; i < dgvDSKhachHangNo.RowCount; i++)
                dgvDSKhachHangNo.Rows[i].Cells[STTColumn.Name].Value = i + 1;
            lblsoluong.Text = "Số lượng khách hàng: " + string.Format("{0:n0}", datasource.Count()) + " | Số lượng hóa đơn: " + string.Format("{0:n0}", datasource.Select(x=>x.soluong).Sum()) + "  |  Tổng tiền: " + string.Format("{0:n0}", datasource.Select(x => x.tongtien).Sum());
            
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
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcelCongNo_Click(object sender, EventArgs e)
        {
            frmCongNoTheoThang frm = new frmCongNoTheoThang();
            frm.TuKy = CboTuKy.SelectedValue.ToString();
            frm.DenKy = cboDenKy.SelectedValue.ToString();
            frm.DenNgay = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            frm.ShowDialog();
        }

    }
}
