using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcKhachHang : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DataTable table;

        public UcKhachHang()
        {
            InitializeComponent();
            excelButton.Click += excelButton_Click;
            seachButton.Click += seachButton_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            this.dataGridView1.DataError += dataGridView1_DataError;
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var maQuan = cboQuan.SelectedValue.ToString();
                if (maQuan != "0")
                {
                    cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    var dataPhuong = db.DM_PHUONG.Where(x => x.maQuan == maQuan).OrderBy(x => x.tenPhuong).ToList();
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
                else
                {
                    cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
            }
            catch
            {
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
                    seachButton.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "nguoitaoColumn")
            {
                if (e.Value != null)
                {
                    string somay = e.Value.ToString();
                    var nhanvien = db.NHANVIENs.FirstOrDefault(nv => nv.somay == somay);
                    if (nhanvien != null)
                    {
                        e.Value = nhanvien?.hoten;
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string maQuan = cboQuan.SelectedValue.ToString();
                string maPhuong = cboPhuong.SelectedValue.ToString();
                int trangthaiKH = int.Parse(cboTT.SelectedValue.ToString());
                string madanhbo = txtTim.Text.Trim();
                int iscoSDT = 1;
                if (chkNgay.Checked == false)
                    tungay = "";
                if (chkQuan.Checked == false)
                    maQuan = "0";
                if (chkPhuong.Checked == false)
                    maPhuong = "0";
                if (chkSDT.Checked == false)
                    iscoSDT = 0;
                if (chktrangthai.Checked == false)
                    trangthaiKH = -1;
                var data = db.getKhangHang(tungay, denngay, maQuan, maPhuong, trangthaiKH, iscoSDT, madanhbo).ToList();
                if(data.Count > 0)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }    
                table = ExcelExportHelper.ListToDataTable(data);
                dataGridView1.DataSource = table;
                lblsoluong.Text = string.Format("{0:n0}", data.Count());
                this.Cursor = Cursors.Default;
            }
            catch
            {
            }
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Danh sách hiện tại không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file|.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string[] columns = { "madanhbo", "maLT", "hoten_KH", "SDT_KH", "sonha", "diachi", "tenPhuong", "tenQuan", "ghichu", "sokyno", "tongtienno", "ghichu2" };
                    var result = ExcelExportHelper.ExportExcel(table, false, columns);
                    File.WriteAllBytes(save.FileName, result);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }    
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
        }

        private void frKhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoGenerateColumns = false;

            var trangthai = db.DM_TRANGTHAI_KH.OrderBy(x => x.tenTT).ToList();
            cboTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTT.DataSource = trangthai.ToList();
            cboTT.DisplayMember = "tenTT";
            cboTT.ValueMember = "maTT";

            var dsQuan = db.DM_QUAN.ToList();
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            cboQuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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