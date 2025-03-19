using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcCapNhatDiaChiKH : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcCapNhatDiaChiKH()
        {
            InitializeComponent();
            btnImport.Click += btnImport_Click;
            button1.Click += button1_Click;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string pathFile = txtPath.Text;
            DataTable objTable = new DataTable();
            if (pathFile != "")
            {
                if (btnImport.Text == "Tải dữ liệu")
                {
                    this.Cursor = Cursors.WaitCursor;
                    objTable = ReadFromExcelfile(txtPath.Text);
                    dataGridView1.DataSource = objTable;
                    lblsoluong.Text = "Số lượng: " + objTable.Rows.Count.ToString();
                    if (objTable.Rows.Count > 0)
                        btnImport.Text = "Cập nhật";
                    this.Cursor = Cursors.Default;
                }
                else if (btnImport.Text == "Cập nhật")
                {
                    DialogResult rs = MessageBox.Show("Bạn có cập nhật địa chỉ khách hàng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        objTable = ReadFromExcelfile(txtPath.Text);
                        this.Cursor = Cursors.WaitCursor;
                        //InsertDataIntoSQLServerUsingSQLBulkCopy(objTable);
                        var result = db.UpdateDiaChi_KH().ToString();
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnImport.Text = "Tải dữ liệu";
                        objTable = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData)
        {
            System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder entityBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(Common.strConn);
            string strconnect = entityBuilder.ProviderConnectionString;
            using (SqlConnection dbConnection = new SqlConnection(strconnect))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.DestinationTableName = "CAPNHATDIACHI_KH";
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the Dialog.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // show only file .xml
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx";
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
    }
}