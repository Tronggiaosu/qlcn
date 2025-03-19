using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcGachNo_Excel : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcGachNo_Excel()
        {
            InitializeComponent();
            btnFile.Click += btnFile_Click;
            btnEX.Click += btnEX_Click;
            quitButton.Click += quitButton_Click;
            btnKiemtra.Click += btnKiemtra_Click;
            btnExcelFail.Click += btnExcelFail_Click;
        }

        private void btnformexcel_Click(object sender, EventArgs e)
        {
        }

        private void btnExcelFail_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Common.ExportExcel(dataGridView2);
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
                    s.DestinationTableName = "GACHNOEXCEL";
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);
                }
            }
        }

        private void btnKiemtra_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (btnKiemtra.Text == "Tải dữ liệu")
            {
                db.Database.ExecuteSqlCommand("delete GACHNOexcel");
                DataTable dt = new DataTable();
                if (string.IsNullOrEmpty(txtPath.Text))
                {
                    MessageBox.Show("Đường dẫn không được để trống hoặc null.", nameof(txtPath.Text), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra file có tồn tại hay không
                if (!File.Exists(txtPath.Text))
                {
                    MessageBox.Show("Không tìm thấy file tại đường dẫn cung cấp.", txtPath.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dt = ReadFromExcelfile(txtPath.Text, "");
                int soluong = dt.Rows.Count;
                InsertDataIntoSQLServerUsingSQLBulkCopy(dt);
                dataGridView1.DataSource = db.getDSImportExcel(1).ToList();
                var result = db.getDSImportExcel(0).ToList();
                if(result.Count > 0)
                {
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }    
                dataGridView2.DataSource = db.getDSImportExcel(0).ToList();
                txtsoHD.Text = dataGridView1.RowCount.ToString();
                //lblsoluongthanhtoan.Text = "Số lượng hóa đơn: " + dataGridView1.RowCount.ToString();
                txttongthanhtoan.Text = string.Format("{0:n0}", db.getDSImportExcel(1).ToList().Sum(x => x.TongTien));
                if (dataGridView1.RowCount > 0)
                    btnKiemtra.Text = "Xác nhận thanh toán";
                //else
                //db.deleteDSImportExcel();
            }
            else if (btnKiemtra.Text == "Xác nhận thanh toán")
            {
                DialogResult rs = MessageBox.Show("Có xác nhận thanh toán hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    var kyghi = db.DM_KYGHI.Where(x => x.hoadon == true).FirstOrDefault();
                    var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                    int NganHangID = int.Parse(cboNH.SelectedValue.ToString());
                    decimal tongtien = decimal.Parse(txttongthanhtoan.Text);
                    // add chung tu
                    CHUNGTU chungtu = new CHUNGTU();
                    chungtu.ID_KYGHI = kyghi.ID_kyghi;
                    chungtu.MALOAI = "CK";
                    chungtu.NGAYLAP = DateTime.Now;
                    chungtu.NV_ID_LAP = NVLap.nv_id;
                    chungtu.NV_ID_NOP = NganHangID;
                    chungtu.GHICHU = txtghichu.Text;
                    chungtu.TRANGTHAI = false;
                    chungtu.SOCT = SO_CT_tutang();
                    chungtu.TONGTIEN = 0;
                    chungtu.NGAYCT = dtpNgaythu.Value.Date;
                    chungtu.TONGTIEN = tongtien;
                    db.CHUNGTUs.Add(chungtu);
                    db.SaveChanges();
                    db.gachno_Thanhtoanchuyenkhoan(chungtu.ID_CT, int.Parse(NVLap.nv_id.ToString()), NganHangID);
                    var chungtuGN = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT).Select(x => x.HOADON.ID_KH).Distinct().ToList();
                    string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                    ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                    if (chungtuGN.Count() == 0)
                        db.CHUNGTUs.Remove(chungtu);
                    else
                    {
                        db.Database.ExecuteSqlCommand("exec DANGNGAN_NV " + Common.NVID.ToString() + ", " + chungtu.ID_CT.ToString());

                        foreach (var item in chungtuGN)
                        {
                            var dshoadon = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT && x.ID_KH == item).ToList();
                            object[] reseult = tdc.ThanhToanHoaDonList("WASS01", hashkey, dshoadon.Select(x => x.ID_HD.ToString()).ToArray(), dshoadon.FirstOrDefault().DANHBO, "", dshoadon.FirstOrDefault().GHICHU, Common.username, "CHUYENKHOAN", cboNH.Text, "").ToArray();
                        }

                        db.Database.ExecuteSqlCommand("update a set a.GACH_NO = '1' from PublishedInvoices a with(nolock) where  (GACH_NO is null or GACH_NO = '0')  and a.IDHD in (select id_hd from CHUNGTU_HOADON b where b.ID_CT = " + chungtu.ID_CT + "  ) ");
                        try
                        {
                            db.XuLyDangNganbyIDCT(chungtu.ID_CT);
                        }
                        catch
                        {
                            db.SaveChanges();
                            btnKiemtra.Text = "Tải dữ liệu";
                            dataGridView1.DataSource = null;
                            txtPath.Text = "";
                            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        db.SaveChanges();
                        btnKiemtra.Text = "Tải dữ liệu";
                        dataGridView1.DataSource = null;
                        txtPath.Text = "";
                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //}
                //catch
                //{
                //}
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //this.Close();
            db.Database.ExecuteSqlCommand("delete GACHNOexcel");
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Common.ExportExcel(dataGridView1);
        }

        public string SO_CT_tutang()
        {
            string kyghi_gn = db.DM_KYGHI.Where(x => x.gachno == true).FirstOrDefault().ID_kyghi;
            string maxid = db.CHUNGTUs.Where(x => x.ID_KYGHI == kyghi_gn).Select(x => x.SOCT).Max();
            if (maxid == null)
                maxid = "0";
            string filtered = System.Text.RegularExpressions.Regex.Replace(maxid, "[A-Za-z]", "");
            long id = Convert.ToInt32(filtered);
            id++;
            string strid = id.ToString("0000") + "CK";
            return strid;
        }

        private DataTable ReadFromExcelfile(string path, string sheetName)
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
                    var row = workSheet.Cells[rowNumber, 1, rowNumber, 6];
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

        private void btnFile_Click(object sender, EventArgs e)
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

        private void frGachNo_Excel_Load(object sender, EventArgs e)
        {
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoGenerateColumns = false;
            // dm ngan hang
            var dmNganhang = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList();
            cboNH.DataSource = dmNganhang.ToList();
            cboNH.ValueMember = "NGANHANG_ID";
            cboNH.DisplayMember = "TENNGANHANG";
            cboNH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            txtPath.Enabled = false;
        }

        public static DataTable Fdt_Excel(string pathExcel, string sheetName)
        {
            DataTable b_dt_kq = null;
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
                using (DbConnection connection = factory.CreateConnection())
                {
                    if (pathExcel.ToUpper().Contains(".XLSX") || pathExcel.ToUpper().Contains(".XLS"))
                        connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathExcel + ";Extended Properties='Excel 12.0;'";
                    else
                        connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathExcel + ";Extended Properties='Excel 8.0;'";
                    using (DbCommand command = connection.CreateCommand())
                    {
                        try
                        {
                            connection.Open();
                            DataTable worksheetTbCollection = (DataTable)connection.GetSchema("Tables");
                            var lists = worksheetTbCollection.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Table_name").ToList());
                            string[,] arr2D = new string[Int16.MaxValue, 1];
                            var aStringList = new List<string>();
                            string[] a;
                            string b;
                            int loopCVar = 0;
                            DbDataReader dr_vi;
                            DataTable b_dt = new DataTable();

                            foreach (var list in lists)
                            {
                                a = list.Select(x => x.ToString()).ToArray();
                                b = string.Join("", a);
                                //arr2D[loopCVar, 0] = b;
                                aStringList.Add(b);
                                loopCVar++;
                            }
                            if (aStringList.Contains(sheetName + "$"))
                            {
                                long lCount = worksheetTbCollection.Rows.Count;
                                command.CommandText = "SELECT * FROM [" + sheetName + "$]";
                                dr_vi = command.ExecuteReader();
                                b_dt.Load(dr_vi);
                                b_dt_kq = b_dt.Copy();
                                b_dt_kq.AcceptChanges();
                            }
                            else
                            {
                                MessageBox.Show("Nhập đúng tên sheet chứa dữ liệu hóa đơn phát hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return null;
                            }
                        }
                        catch (Exception ex) { throw new Exception("loi:Lỗi mở File Excel: " + ex.Message + " :loi"); }
                        finally { connection.Close(); }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File không đúng định dạng" + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return b_dt_kq;
        }
    }
}