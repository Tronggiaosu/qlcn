using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.GachNo
{
    public partial class frQLPhieuThu_App : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 100;
        List<VIEW_LOGTHUTIENNUOC> logThuTienNuoc = new List<VIEW_LOGTHUTIENNUOC>();
        DataTable table;
        public frQLPhieuThu_App()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            btnRF.Click += btnRF_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            cboTo.SelectedIndexChanged += cboTo_SelectedIndexChanged;
        }

        void cboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var data = db.NHANVIENs.ToList();
                decimal TOID = decimal.Parse(cboTo.SelectedValue.ToString());
                if (TOID != 0)
                    data = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7 && x.NHANVIEN.TO_ID == TOID).Select(x => x.NHANVIEN).OrderBy(x => x.hoten).ToList();
                // dm nhan vien thu ngan
                List<NHANVIEN> thunganvien = new List<NHANVIEN>();
                thunganvien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
                thunganvien.AddRange(data);
                cboTNV.DataSource = thunganvien.Select(x => new { hoten = x.maNV + " - " + x.hoten, x.NV_ID }).OrderBy(x => x.hoten).ToList();
                cboTNV.ValueMember = "NV_ID";
                cboTNV.DisplayMember = "hoten";
            }
            catch
            {

            }
        }

       
        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTim.PerformClick();
                }
            }
        }

        void btnRF_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string[] columns = { "TO_ID", "nhanvien", "maLT", "madanhbo", "hoten_KH", "ten_kyghi", "diachi", "loaigiay", "nhanvien", "NGAYIN", "seri", "tongtien" };

                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                MessageBox.Show("Xuất dữ liệu thành công!");
            }
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int NVIDThu = int.Parse(cboTNV.SelectedValue.ToString());
            string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            int tuky = int.Parse(cbotuky.SelectedValue.ToString());
            int denky = int.Parse(cbotuky.SelectedValue.ToString());
            int TOID = int.Parse(cboTo.SelectedValue.ToString());
            int giaybao = 2;
            string loaigiayin = cboLoai.SelectedValue.ToString();
            if (chkloaigiay.Checked)
            {
                if (cboLoai.Text == "Giấy báo tiền nước")
                    giaybao = 1;
                else
                    giaybao = 0;
            }
            if (chkky.Checked == false)
                tuky = 0;
            var datasource = db.getDSPhieuMobileApp(tungay, denngay, TOID, NVIDThu, giaybao, tuky, denky).ToList();
            if (txtTim.Text != "")
                datasource = datasource.Where(x => x.timkiem.Contains((txtTim.Text.Replace(" ", String.Empty)).ToUpper())).ToList();
            dataGridView1.DataSource = datasource.ToList();
            lblsoluong.Text = "  | Số lượng giấy báo: " + datasource.Where(x => x.GIAYBAO == 1).ToList().Count().ToString() + "    | Số lượng biên nhận: " + datasource.Where(x => x.GIAYBAO == 0).ToList().Count().ToString();
            table = ExcelExportHelper.ListToDataTable(datasource.ToList());
            this.Cursor = Cursors.Default;
        }

        private void frQLPhieuThu_App_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            //dm loai giay in
            cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            string[] loaigiay = { "Biên nhận", "Giấy báo tiền nước" };
            cboLoai.DataSource = loaigiay.ToList();
            // dm nhan vien thu ngan
            cboTNV.DropDownStyle = ComboBoxStyle.DropDownList;
            List<NHANVIEN> thunganvien = new List<NHANVIEN>();
            thunganvien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
            var dsthunganvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => x.NHANVIEN).OrderBy(x => x.hoten).ToList();
            thunganvien.AddRange(dsthunganvien);
            cboTNV.DataSource = thunganvien.Select(x => new { hoten = x.maNV + " - " + x.hoten, x.NV_ID }).OrderBy(x => x.hoten).ToList();
            cboTNV.ValueMember = "NV_ID";
            cboTNV.DisplayMember = "hoten";
            // dm to
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_TO> dsTo = new List<DM_TO>();
            dsTo.Add(new DM_TO() { TO_ID = 0, TENTO = "Tất cả" });
            var data = db.DM_TO.OrderBy(X => X.TENTO).ToList();
            dsTo.AddRange(data);
            cboTo.DataSource = dsTo.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            var dataKyHD = db.DM_KYGHI.ToList();
            cbotuky.DataSource = dataKyHD.ToList();
            cbotuky.ValueMember = "Id_kyghi";
            cbotuky.DisplayMember = "ten_kyghi";
            cbodenky.DataSource = dataKyHD.ToList();
            cbodenky.ValueMember = "Id_kyghi";
            cbodenky.DisplayMember = "ten_kyghi";
        }
    }
}
