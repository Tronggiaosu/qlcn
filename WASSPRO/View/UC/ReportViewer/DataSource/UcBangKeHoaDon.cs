using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.ReportViewer.DataSource
{
    public partial class UcBangKeHoaDon : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcBangKeHoaDon()
        {
            InitializeComponent();
        }

        private void frBangKeHoaDon_Load(object sender, EventArgs e)
        {
            cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            for (int i = 1; i <= 12; i++)
            {
                dmKyghi.Add(new DM_KYGHI()
                {
                    ID_kyghi = i.ToString("00"),
                    ten_kyghi = $"{i:00}"
                });
            }
            cboThang.DataSource = dmKyghi;
            cboThang.ValueMember = "ID_kyghi";
            cboThang.DisplayMember = "ten_kyghi";

            cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string kyghi = cboThang.SelectedValue.ToString();
                string nam = cboNam.SelectedValue.ToString();
                string result = nam + kyghi;
                var data = db.GetBangKeHoaDon(result).ToList();
                dataGridView1.DataSource = data;
                this.Cursor = Cursors.Default;
            }
            catch
            {
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string thang = cboThang.SelectedValue.ToString();
                string nam = cboNam.SelectedValue.ToString();
                string kyghi = nam + thang;
                var data = db.GetBangKeHoaDon(kyghi).ToList();
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file|.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string[] columns = { "DANHBO", "hoten", "DOT_ID", "NgayPhatHanh", "SO_HD", "KY_HIEU_HD", "MAU_HD", "SOPHATHANH", "CSCu", "CSMoi", "m3tieuthu", "tongtien0VAT", "tienvat", "tienBVMT", "PhiBVMTCu", "PhiNT", "TienThueNT" };

                    var result = ExcelExportHelper.ExportExcel(data, false, columns);
                    File.WriteAllBytes(save.FileName, result);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void btn215_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string kyghi = cboNam.SelectedValue.ToString();
                var data = db.GetBangKeHoaDon215(kyghi).ToList();
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file|.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string[] columns = { "DANHBO", "hoten", "DOT_ID", "NgayPhatHanh", "SO_HD", "KY_HIEU_HD", "MAU_HD", "SOPHATHANH", "CSCu", "CSMoi", "m3tieuthu", "tongtien0VAT", "tienvat", "tienBVMT", "PhiBVMTCu", "PhiNT", "TienThueNT" };

                    var result = ExcelExportHelper.ExportExcel(ExcelExportHelper.ListToDataTable(data), false, columns);
                    File.WriteAllBytes(save.FileName, result);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }
    }
}