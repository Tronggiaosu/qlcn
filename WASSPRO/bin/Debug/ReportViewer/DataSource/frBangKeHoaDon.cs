using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.DataSource
{
    
    public partial class frBangKeHoaDon : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frBangKeHoaDon()
        {
            InitializeComponent();
        }

        private void frBangKeHoaDon_Load(object sender, EventArgs e)
        {
            cboKy.DataSource = db.DM_KYGHI.OrderByDescending(x => x.ngaytao).ToList();
            cboKy.ValueMember= "ID_Kyghi";
            cboKy.DisplayMember = "ten_kyghi";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string kyghi = cboKy.SelectedValue.ToString();
                var data = db.GetBangKeHoaDon(kyghi).ToList();
                dataGridView1.DataSource = data;
            }
            catch
            {

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string kyghi = cboKy.SelectedValue.ToString();
                var data = db.GetBangKeHoaDon(kyghi).ToList();
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file|.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {

                    string[] columns = { "DANHBO", "hoten", "DOT_ID", "NgayPhatHanh", "SO_HD", "KY_HIEU_HD", "MAU_HD", "SOPHATHANH", "CSCu", "CSMoi", "m3tieuthu", "tongtien0VAT", "tienvat", "tienBVMT", "PhiBVMTCu", "PhiNT", "TienThueNT" };


                    var result = ExcelExportHelper.ExportExcel(data, false, columns);
                    File.WriteAllBytes(save.FileName, result);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Xuất dữ liệu thành công!");
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
                string kyghi = cboKy.SelectedValue.ToString();
                var data = db.GetBangKeHoaDon215(kyghi).ToList();
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file|.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {

                    string[] columns = { "DANHBO", "hoten", "DOT_ID", "NgayPhatHanh", "SO_HD", "KY_HIEU_HD", "MAU_HD", "SOPHATHANH", "CSCu", "CSMoi", "m3tieuthu", "tongtien0VAT", "tienvat", "tienBVMT", "PhiBVMTCu", "PhiNT", "TienThueNT" };


                    var result = ExcelExportHelper.ExportExcel(ExcelExportHelper.ListToDataTable(data), false, columns);
                    File.WriteAllBytes(save.FileName, result);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Xuất dữ liệu thành công!");
                }
            }
            catch
            {

            }
        }
    }
}
