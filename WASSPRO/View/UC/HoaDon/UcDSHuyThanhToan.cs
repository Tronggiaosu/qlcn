using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QLCongNo.Data;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcDSHuyThanhToan : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DataTable table;

        public UcDSHuyThanhToan()
        {
            InitializeComponent();
            cboTO.SelectedIndexChanged += cboTO_SelectedIndexChanged;
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            btnThoat.Click += btnThoat_Click;
            btnExcel.Click += btnExcel_Click;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "danhbo", "hoten", "tongtien", "manv", "ngayhuy", "somay", "ngaythu", "kyHD", "lydo" };

                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //    this.Close();
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            int NVID = int.Parse(cboNV.SelectedValue.ToString());
            int TOID = int.Parse(cboTO.SelectedValue.ToString());
            var data = db.getDSHuyThanhToan(tungay, denngay, TOID, NVID).ToList();
            if (txtTim.Text != "")
                data = data.Where(x => x.danhbo.Contains(txtTim.Text)).ToList();
            if(data.Count > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }    
            table = ExcelExportHelper.ListToDataTable(data.ToList());
            dataGridView1.DataSource = table;
            for (int i = 0; i < data.Count(); i++)
                dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i + 1;
            this.Cursor = Cursors.Default;
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

        private void frDSHuyThanhToan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }
    }
}