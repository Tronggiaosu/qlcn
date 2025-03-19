using OfficeOpenXml;
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

namespace QLCongNo.GachNo
{
    public partial class frDongBoThanhToanEx : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frDongBoThanhToanEx()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the Dialog.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // show only file .xml
            openFileDialog1.Filter = "*.dat|";
            openFileDialog1.Title = "Select a File";
            // If the user clicked OK in the dialog and  
            // a .xml file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                // link file name
                txtPath.Text = openFileDialog1.FileName;

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
               DataTable  objTable = ReadFromExcelfile(txtPath.Text);
               InsertDataIntoSQLServerUsingSQLBulkCopy(objTable);
               db.Database.ExecuteSqlCommand("exec DoiSoatEx ");
               dataGridView1.DataSource = db.THU_HO.ToList();
            }
            catch
            {

            }
        }
        private DataTable ReadFromExcelfile(string path)
        {
            // Khởi tạo data table
            DataTable dt = new DataTable();
            // Load file excel và các setting ban đầu
            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                //if (package.Workbook.Worksheets.Count <  1)
                //{
                //}
                ExcelWorksheet workSheet = package.Workbook.Worksheets.FirstOrDefault();
                foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
                {
                    dt.Columns.Add(firstRowCell.Text);
                }
                for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                {
                    var row = workSheet.Cells[rowNumber, 1, rowNumber, 5];
                    var newRow = dt.NewRow();
                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text;

                    }
                    dt.Rows.Add(newRow);
                }

            }
            return dt;
        }
        static void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData)
        {
            System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder entityBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(Common.strConn);
            string strconnect = entityBuilder.ProviderConnectionString;
            using (SqlConnection dbConnection = new SqlConnection(strconnect))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.DestinationTableName = "DoiSoatTon";
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);
                }
            }
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            try
            {
                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                var dsdongbo = db.THU_HO.ToList();
                foreach (var item in dsdongbo)
                {
                    var chungtu = db.CHUNGTU_HOADON.Where(x => x.ID_HD == item.ma_kh).FirstOrDefault();
                    if (chungtu != null)
                    {
                        var pb = db.PublishedInvoices.Where(x => x.IDHD == item.ma_kh).FirstOrDefault();
                        pb.GACH_NO = null;
                        db.SaveChanges();
                        var loaichungtu = db.CHUNGTUs.Where(x => x.ID_CT == chungtu.ID_CT).FirstOrDefault();
                        var dshoadon = db.CHUNGTU_HOADON.Where(x => x.ID_HD == item.ma_kh).ToList();
                        object[] reseult = tdc.ThanhToanHoaDonList("WASS01", hashkey, dshoadon.Select(x => x.ID_HD.ToString()).ToArray(), dshoadon.FirstOrDefault().DANHBO, "", dshoadon.FirstOrDefault().GHICHU, Common.username, loaichungtu.MALOAI, "", "").ToArray();
                        var chuyendathu = db.PublishedInvoices.Where(x => x.IDHD == item.ma_kh).FirstOrDefault();
                        chuyendathu.GACH_NO = "1";
                        db.SaveChanges();
                    }
                }
                db.Database.ExecuteSqlCommand("  truncate table THU_HO ");
                MessageBox.Show("Đồng bộ thành công!");

            }
            catch
            {

            }
        }
    }
}
