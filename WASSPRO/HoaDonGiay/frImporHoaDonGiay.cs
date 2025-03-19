using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.HoaDonGiay
{
    public partial class frImporHoaDonGiay : Form
    {
        public frImporHoaDonGiay()
        {
            InitializeComponent();
            btnPathFile.Click += btnPathFile_Click;
            btnLuu.Click += btnLuu_Click;
        }

        void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable source = GetDataTabletFromCSVFile(txtPath.Text);
            if (txtPath.Text != "")
            {
                if (btnLuu.Text == "Tải dữ liệu")
                {
                    this.Cursor = Cursors.WaitCursor;
                    dataGridView1.DataSource = source;
                    if (dataGridView1.RowCount > 0)
                        btnLuu.Text = "Lưu dữ liệu";
                    this.Cursor = Cursors.Default;

                }
                else if (btnLuu.Text == "Lưu dữ liệu")
                {
                    InsertDataIntoSQLServerUsingSQLBulkCopy(source);
                    MessageBox.Show("Thêm thành công!");
                }
            }
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
                    s.DestinationTableName = "HOADONGIAY";
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);
                }
            }
        }
        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            DataColumn STT = new DataColumn("STT");
            csvData.Columns.Add(STT);

            DataColumn DANHBO = new DataColumn("DANHBO");
            csvData.Columns.Add(DANHBO);

            DataColumn NAM = new DataColumn("NAM");
            csvData.Columns.Add(NAM);

            DataColumn KY = new DataColumn("KY");
            csvData.Columns.Add(KY);

            DataColumn DOITUONG = new DataColumn("DOITUONG");
            csvData.Columns.Add(DOITUONG);

            DataColumn SOPHATHANH = new DataColumn("SOPHATHANH");
            csvData.Columns.Add(SOPHATHANH);

            DataColumn M3TIEUTHU = new DataColumn("M3TIEUTHU");
            csvData.Columns.Add(M3TIEUTHU);

            DataColumn TIENNUOC = new DataColumn("TIENNUOC");
            csvData.Columns.Add(TIENNUOC);

            DataColumn TIENTHUE = new DataColumn("TIENTHUE");
            csvData.Columns.Add(TIENTHUE);

            DataColumn PHIBVMT = new DataColumn("PHIBVMT");
            csvData.Columns.Add(PHIBVMT);

            DataColumn SOSERI = new DataColumn("SOSERI");
            csvData.Columns.Add(SOSERI);

            string[] delimiters = { ";", ",", "-" };
            using (TextFieldParser parser = FileSystem.OpenTextFieldParser(csv_file_path, delimiters))
            {

                // Process the file's lines.
                while (!parser.EndOfData)
                {
                    try
                    {
                        string[] fields = parser.ReadFields();
                        csvData.Rows.Add(fields);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return csvData;
        }

        void btnPathFile_Click(object sender, EventArgs e)
        {
            try
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
                    if (txtPath.Text != "")
                    {
                        btnLuu.Enabled = true;
                        btnLuu.Text = "Tải dữ liệu";
                    }

                }
            }
            catch
            {

            }
        }

        private void frImporHoaDonGiay_Load(object sender, EventArgs e)
        {
            txtPath.Enabled = false;

        }
    }
}
