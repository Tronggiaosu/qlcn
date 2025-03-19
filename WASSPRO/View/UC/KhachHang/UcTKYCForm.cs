using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class UcTKYCForm : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        DataTable table;
        public UcTKYCForm()
        {
            InitializeComponent();
        }

       
        private void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dataGridView1.DataSource = null;
            var yc = from a in db.YEUCAUs
                     //from b in db.NHANVIENs
                     //where a.nguoilapdat == b.maNV
                     where System.Data.Entity.DbFunctions.TruncateTime(a.ngayYC) >= tuNgaydateTimePicker.Value.Date && System.Data.Entity.DbFunctions.TruncateTime(a.ngayYC) <= denNgaydateTimePicker.Value.Date
                     select new
                     {                         
                         a.ID_yeucau,
                         id_kh = a.KHACHHANG.ID_KH,
                         hoten_KH = a.KHACHHANG.hoten_KH,
                         diachi = a.KHACHHANG.diachi,                        
                         sdt_kh = a.KHACHHANG.SDT_KH,                         
                         ngayYC = a.ngayYC,
                         ngayHT = a.ngayHT,                         
                         //nguoilapdat = b.hoten,
                         maYC = a.maloai_yc,
                         tenloai_YC = a.DM_LOAIYEUCAU.tenloai_yc,
                         ttyc_id = a.TTYC_ID,
                         tenTTYC = a.DM_TRANGTHAI_YC.trangthai_yc,
                         sophieu = a.sophieu,
                         a.ghichu
                     };
            if (loaiYCcheckBox.Checked)
            {
                string ma_yc = yccomboBox.SelectedValue.ToString();
                yc = yc.Where(x => x.maYC == ma_yc);
            }
            if (ttcheckBox.Checked)
            {
                int ttyc_id = Convert.ToInt32(ttcomboBox.SelectedValue);
                yc = yc.Where(x => x.ttyc_id == ttyc_id);
            }
            dataGridView1.DataSource = yc.OrderByDescending(x=>x.ngayYC).ToList();
            table = ExcelExportHelper.ListToDataTable(yc.OrderByDescending(x => x.ngayYC).ToList());
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[sttColumn.Name].Value = i + 1;
                string list = (db.Database.SqlQuery<string>("exec GetNVByYC @yc", new SqlParameter("@yc", Convert.ToDecimal(dataGridView1.Rows[i].Cells[idYCColumn.Name].Value))).FirstOrDefault());
                dataGridView1.Rows[i].Cells[nguoiTHColumn.Name].Value = list;
            }
            this.Cursor = Cursors.Default;
        }

        private void TKYCForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadLoaiYC();
            LoadTrangThai();
        }

        private void LoadTrangThai()
        {
            var tt = from a in db.DM_TRANGTHAI_YC select a;
            ttcomboBox.DataSource = tt.ToList();
            ttcomboBox.DisplayMember = "trangthai_yc";
            ttcomboBox.ValueMember = "TTYC_ID";
        }
        private void LoadLoaiYC()
        {
            var yc = from a in db.DM_LOAIYEUCAU select a;
            yccomboBox.DataSource = yc.ToList();
            yccomboBox.DisplayMember = "tenloai_yc";
            yccomboBox.ValueMember = "maloai_yc";
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
         //   this.Close();
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "id_kh", "hoten_KH", "diachi", "sdt_KH", "ngayYC", "ngayHT", "tenloai_YC", "tenTTYC", "ghichu" };
                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!");
            }
        }
       
    }
}
