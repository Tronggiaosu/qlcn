using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.DanhMuc;

namespace QLCongNo.HoaDon
{
    public partial class frDSHuyThanhToan : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        DataTable table;
        public frDSHuyThanhToan()
        {
            InitializeComponent();
            cboTO.SelectedIndexChanged += cboTO_SelectedIndexChanged;
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            btnThoat.Click += btnThoat_Click;
            btnExcel.Click += btnExcel_Click;
        }

        void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "danhbo", "hoten", "tongtien", "manv", "ngayhuy", "somay", "ngaythu", "kyHD", "lydo"};

                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!");
            }
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                    btnTim.PerformClick();
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            int NVID = int.Parse(cboNV.SelectedValue.ToString());
            int TOID = int.Parse(cboTO.SelectedValue.ToString());
            var data = db.getDSHuyThanhToan(tungay, denngay, TOID, NVID).ToList();
            if (txtTim.Text != "")
                data = data.Where(x => x.danhbo.Contains(txtTim.Text)).ToList();
            table = ExcelExportHelper.ListToDataTable(data.ToList());
            dataGridView1.DataSource = table;
            for(int i = 0; i< data.Count() ; i++)
                dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i+1;
        }

        void cboTO_SelectedIndexChanged(object sender, EventArgs e)
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

        private void frDSHuyThanhToan_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            LoadNhanVien(Common.TOID);
            if (Common.TOID == 0)
                LoadTO(-1);
            else
                LoadTO(Common.TOID);
            dataGridView1.AutoGenerateColumns = false;
        }
        public void LoadTO(decimal? TOID)
        {
            cboTO.DropDownStyle = ComboBoxStyle.DropDownList;
            var data = DataDanhMuc.getDSTo(TOID).ToList();
            cboTO.DataSource = data.ToList();
            cboTO.ValueMember = "TO_ID";
            cboTO.DisplayMember = "TENTO";
        }
        public void LoadNhanVien(decimal? TOID)
        {
            cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
            var data = DataDanhMuc.getDSNhanvien(TOID).Select(x => new { hoten = x.maNV + " - " + x.hoten, x.NV_ID }).ToList();
            cboNV.DataSource = data.ToList();
            cboNV.DisplayMember = "hoten";
            cboNV.ValueMember = "NV_ID";
        }
    }
}
