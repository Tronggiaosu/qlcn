using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcGachNo_Excel : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private string _mSCTKey = "";

        public UcGachNo_Excel()
        {
            InitializeComponent();
            btnFile.Click += btnFile_Click;
            btnEX.Click += btnEX_Click;
            btnKiemtra.Click += btnKiemtra_Click;
            btnExcelFail.Click += btnExcelFail_Click;
            this.dataGridView1.KeyDown += DataGridView1_KeyDown;
            this.dataGridView2.KeyDown += DataGridView2_KeyDown;
            this.dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
            this.dataGridView2.ColumnHeaderMouseClick += DataGridView2_ColumnHeaderMouseClick;
            btnConfirm.Visible = false;
        }

        private void DataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.dataGridView2.SelectAll();
            }
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.dataGridView1.SelectAll();
            }
        }

        private void DataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                Copy(this.dataGridView2);
                e.Handled = true;
            };
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                Copy(this.dataGridView1);
                e.Handled = true;
            };
        }

        private void Copy(DataGridView dgv)
        {
            var count = dgv.SelectedCells.Count;
            if (count == dgv.RowCount * dgv.ColumnCount && count != 8)
            {
                //Copy all of datagridview
                DataObject dataObj = dgv.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
            }
            else
            {
                //Copy 1 cell
                var currentCell = dgv.CurrentCell;
                if (currentCell != null && currentCell.Value != null)
                {
                    Clipboard.SetText(currentCell.Value.ToString());
                }
            }
        }

        public class ExcelRowModel
        {
            public string Ngay { get; set; }
            public string DanhBo { get; set; }
            public decimal TongTien { get; set; }
            public string Thang { get; set; }
            public string Nam { get; set; }
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

        private static string ImportData2Table(DataTable dtData, string pTableName)
        {
            string sRet = "OK";
            try
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder entityBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(Common.strConn);
                string strconnect = entityBuilder.ProviderConnectionString;
                using (SqlConnection dbConnection = new SqlConnection(strconnect))
                {
                    dbConnection.Open();
                    using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                    {
                        s.DestinationTableName = pTableName;
                        foreach (var column in dtData.Columns)
                            s.ColumnMappings.Add(column.ToString(), column.ToString());
                        s.WriteToServer(dtData);
                    }
                }
            }
            catch (Exception ex)
            {
                sRet = ex.Message;
            }

            return sRet;
        }

        private string loadDataExcel(string pExcelFile)
        {
            string sRet = "";
            try
            {
                _mSCTKey = Common.NVID.ToString() + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");

                DataTable dt = new DataTable();
                dt = ReadFromExcelfile_ByNhanVien(pExcelFile, "", _mSCTKey);
                if (dt.Rows.Count == 0)
                {
                    sRet = "EXCEL_NODATA";
                    return sRet;
                }

                string sImport = ImportData2Table(dt, "GACHNOEXCEL_NV");
                if (sImport != "OK")
                {
                    sRet = "Lỗi Import file Excel!";
                    return sRet;
                }

                var dataDung = db.getDSImportExcel_ByNhanVien(1, Convert.ToInt16(Common.NVID.ToString()), _mSCTKey).ToList();
                if (dataDung.Count() == 0)
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                else
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DataSource = dataDung;
                dataGridView1.Columns[0].HeaderText = "Key";
                dataGridView1.Columns[1].HeaderText = "Tháng";
                dataGridView1.Columns[2].HeaderText = "Năm";
                dataGridView1.Columns[3].HeaderText = "Danh bộ";
                dataGridView1.Columns[4].HeaderText = "Tổng tiền";
                dataGridView1.Columns[5].HeaderText = "Họ tên";
                dataGridView1.Columns[6].HeaderText = "UserID";
                dataGridView1.Columns[7].HeaderText = "Ngày";
                novLabel4.Text = $"Danh sách thanh toán ({dataGridView1.Rows.Count})";

                var allExcelRows = dt.AsEnumerable()
                    .Where(row =>
                        row["DanhBo"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["DanhBo"].ToString()) &&
                        row["TongTien"] != DBNull.Value && Convert.ToDecimal(row["TongTien"]) > 0
                    )
                    .Select(row => new ExcelRowModel
                    {
                        Ngay = row["Ngay"].ToString().Trim(),
                        DanhBo = row["DanhBo"].ToString().Trim(),
                        TongTien = Convert.ToDecimal(row["TongTien"]),
                        Thang = row["Thang"].ToString().Trim(),
                        Nam = row["Nam"].ToString().Trim()
                    }).ToList();

                var dungKeys = dataDung.Select(d =>
                    $"{d.DanhBo.Trim()}_{d.TongTien}"
                    ).ToHashSet();

                var dataSai = allExcelRows
                    .Where(row => !dungKeys.Contains($"{row.DanhBo.Trim()}_{row.TongTien}"))
                    .ToList();

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.DataSource = dataSai;
                novLabel3.Text = $"Danh sách không đúng ({dataGridView2.Rows.Count})";
                dataGridView1.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                txtsoHD.Text = dataGridView1.RowCount.ToString();
                txttongthanhtoan.Text = string.Format("{0:n0}", dataDung.Sum(x => x.TongTien));
                sRet = "OK";
            }
            catch (Exception ex)
            {
                sRet = ex.Message;
            }

            return sRet;
        }

        private string xacNhanThanhToan()
        {
            string sRet = "";
            try
            {
                var kyghi = db.DM_KYGHI.Where(x => x.hoadon == true).FirstOrDefault();
                int NganHangID = int.Parse(cboNH.SelectedValue.ToString());
                decimal tongtien = decimal.Parse(txttongthanhtoan.Text);
                // add chung tu
                CHUNGTU chungtu = new CHUNGTU();
                chungtu.ID_KYGHI = kyghi.ID_kyghi;
                chungtu.MALOAI = "CK";
                chungtu.NGAYLAP = DateTime.Now;
                chungtu.NV_ID_LAP = Common.NVID;
                chungtu.NV_ID_NOP = NganHangID;
                chungtu.GHICHU = txtghichu.Text;
                chungtu.TRANGTHAI = false;
                chungtu.SOCT = SO_CT_tutang();
                chungtu.NGAYCT = dtpNgaythu.Value.Date;
                chungtu.TONGTIEN = 0;
                chungtu.TONGTIEN = tongtien;
                db.CHUNGTUs.Add(chungtu);
                db.SaveChanges();

                var result = new ObjectParameter("result", typeof(int));
                db.gachno_Thanhtoanchuyenkhoan_ByNhanVien(chungtu.ID_CT, int.Parse(Common.NVID.ToString()), NganHangID, _mSCTKey, result);
                var rs = Convert.ToInt32(result.Value);
                if (rs == 1)
                {
                    var chungtuGN = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT).Select(x => x.HOADON.ID_KH).Distinct().ToList();
                    var hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                    var tdc = new ServiceTDC.ThuHo();
                    if (chungtuGN.Count() == 0)
                        db.CHUNGTUs.Remove(chungtu);
                    else
                    {
                        var id_ct = chungtu.ID_CT;
                        var nvid = Common.NVID;
                        var username = Common.username;
                        var bank = cboNH.Text;
                        var type = "CHUYENKHOAN";
                        var dsSuccess = new List<string>();
                        var cmd = $"exec DANGNGAN_NV {nvid}, {id_ct}";

                        db.Database.ExecuteSqlCommand(cmd);

                        foreach (var item in chungtuGN)
                        {
                            var dshoadon = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT && x.ID_KH == item).ToList();
                            var danhbo = dshoadon.FirstOrDefault().DANHBO;
                            var note = dshoadon.FirstOrDefault().GHICHU;
                            var dsID_HD = dshoadon.Select(x => x.ID_HD.ToString()).ToArray();

                            object[] kq = tdc.ThanhToanHoaDonList("WASS01", hashkey, dsID_HD, danhbo, "", note, username, type, bank, "").ToArray();

                            if (kq[1].ToString() == "SUCCESS" && kq[2].ToString() == "TRANSACTION_SUCCESS")
                            {
                                dsSuccess.Add(string.Join(",", dsID_HD));
                            }
                        }

                        var dsTotal = string.Join(",", dsSuccess);

                        //var tam = $"select id_hd from CHUNGTU_HOADON b where b.id_hd in ({dsTotal})";
                        //var query = $"update a set a.GACH_NO = '1' from PublishedInvoices a with(nolock) where (GACH_NO is null or GACH_NO = '0')  and a.IDHD in ({dsTotal}) ";
                        var command = $"update a set a.GACH_NO = '1' from PublishedInvoices a with(nolock) where (GACH_NO is null or GACH_NO = '0')  and a.IDHD in (select id_hd from CHUNGTU_HOADON b where b.ID_CT = {chungtu.ID_CT}) ";
                        var ketqua = db.Database.ExecuteSqlCommand(command);
                        db.SaveChanges();

                        sRet = "OK";
                        //try
                        //{
                        //    db.XuLyDangNganbyIDCT(chungtu.ID_CT);
                        //}
                        //catch
                        //{
                        //    db.SaveChanges();
                        //    dataGridView1.DataSource = null;
                        //    txtPath.Text = "";
                        //    MessageBox.Show("Gạch nợ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                        //dataGridView1.DataSource = null;
                        //txtPath.Text = "";
                        //MessageBox.Show("Gạch nợ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                sRet = ex.Message;
            }

            return sRet;
        }

        private void backupSource_btnKiemtra_Click()
        {
            try
            {
                if (btnKiemtra.Text == "Tải dữ liệu")
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    if (string.IsNullOrEmpty(txtPath.Text))
                    {
                        MessageBox.Show("Đường dẫn không được để trống hoặc null.", nameof(txtPath.Text), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    if (!File.Exists(txtPath.Text))
                    {
                        MessageBox.Show("Không tìm thấy file tại đường dẫn cung cấp.", txtPath.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                    db.Database.ExecuteSqlCommand("delete GACHNOexcel");
                    dt = ReadFromExcelfile(txtPath.Text, "");
                    //int soluong = dt.Rows.Count;
                    InsertDataIntoSQLServerUsingSQLBulkCopy(dt);


                    var dataDung = db.getDSImportExcel(1).ToList();
                    if (dataDung.Count() == 0)
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    else
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView1.DataSource = dataDung;
                    dataGridView1.Columns[0].HeaderText = "Key";
                    dataGridView1.Columns[1].HeaderText = "Tháng";
                    dataGridView1.Columns[2].HeaderText = "Năm";
                    dataGridView1.Columns[3].HeaderText = "Danh bộ";
                    dataGridView1.Columns[4].HeaderText = "Tổng tiền";
                    dataGridView1.Columns[5].HeaderText = "Họ tên";
                    dataGridView1.Columns[6].HeaderText = "UserID";
                    dataGridView1.Columns[7].HeaderText = "Ngày";
                    novLabel4.Text = $"Danh sách thanh toán ({dataGridView1.Rows.Count})";

                    var allExcelRows = dt.AsEnumerable()
                        .Where(row =>
                            row["DanhBo"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["DanhBo"].ToString()) &&
                            row["TongTien"] != DBNull.Value && Convert.ToDecimal(row["TongTien"]) > 0
                        )
                        .Select(row => new ExcelRowModel
                        {
                            Ngay = row["Ngay"].ToString().Trim(),
                            DanhBo = row["DanhBo"].ToString().Trim(),
                            TongTien = Convert.ToDecimal(row["TongTien"]),
                            Thang = row["Thang"].ToString().Trim(),
                            Nam = row["Nam"].ToString().Trim()
                        }).ToList();

                    var dataSai = allExcelRows
                        .Where(row => !dataDung.Any(d => d.DanhBo.Trim() == row.DanhBo.Trim()))
                        .ToList();

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView2.DataSource = dataSai;
                    novLabel3.Text = $"Danh sách không đúng ({dataGridView2.Rows.Count})";

                    txtsoHD.Text = dataGridView1.RowCount.ToString();
                    txttongthanhtoan.Text = string.Format("{0:n0}", db.getDSImportExcel(1).ToList().Sum(x => x.TongTien));
                    if (dataGridView1.RowCount > 0)
                        btnKiemtra.Text = "Xác nhận thanh toán";
                    //else
                    //db.deleteDSImportExcel();
                    this.Cursor = Cursors.Default;
                }
                else if (btnKiemtra.Text == "Xác nhận thanh toán")
                {
                    this.Cursor = Cursors.WaitCursor;
                    DialogResult rs = MessageBox.Show("Có xác nhận thanh toán hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        var kyghi = db.DM_KYGHI.Where(x => x.hoadon == true).FirstOrDefault();
                        //var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                        int NganHangID = int.Parse(cboNH.SelectedValue.ToString());
                        decimal tongtien = decimal.Parse(txttongthanhtoan.Text);
                        // add chung tu
                        CHUNGTU chungtu = new CHUNGTU();
                        chungtu.ID_KYGHI = kyghi.ID_kyghi;
                        chungtu.MALOAI = "CK";
                        chungtu.NGAYLAP = DateTime.Now;
                        chungtu.NV_ID_LAP = Common.NVID;
                        chungtu.NV_ID_NOP = NganHangID;
                        chungtu.GHICHU = txtghichu.Text;
                        chungtu.TRANGTHAI = false;
                        chungtu.SOCT = SO_CT_tutang();
                        chungtu.TONGTIEN = 0;
                        chungtu.NGAYCT = dtpNgaythu.Value.Date;
                        chungtu.TONGTIEN = tongtien;
                        db.CHUNGTUs.Add(chungtu);
                        db.SaveChanges();
                        db.gachno_Thanhtoanchuyenkhoan(chungtu.ID_CT, int.Parse(Common.NVID.ToString()), NganHangID);
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
                    this.Cursor = Cursors.Default;
                }
            }
            catch
            {
            }
        }

        private void btnKiemtra_Click(object sender, EventArgs e)
        {
            btnKiemtra.Enabled = false;
            try
            {
                _mSCTKey = "";
                txtsoHD.Text = "";
                txttongthanhtoan.Text = "";
                string sExcelFile = txtPath.Text;
                if (string.IsNullOrEmpty(sExcelFile))
                {
                    MessageBox.Show("Vui lòng chọn file Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnKiemtra.Enabled = true;
                    btnConfirm.Visible = false;
                    return;
                }

                if (!File.Exists(sExcelFile))
                {
                    MessageBox.Show("File Excel không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnKiemtra.Enabled = true;
                    btnConfirm.Visible = false;
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                string sKetQua = loadDataExcel(sExcelFile);

                if (sKetQua == "EXCEL_NODATA")
                {
                    MessageBox.Show("File Excel không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnKiemtra.Enabled = true;
                    btnConfirm.Visible = false;
                    this.Cursor = Cursors.Default;
                    return;
                }

                if (sKetQua == "OK" && dataGridView1.RowCount > 0)
                {
                    btnConfirm.Visible = true;
                }
                else if (sKetQua == "OK" && dataGridView1.RowCount == 0)
                {
                    btnConfirm.Visible = false;
                }
                else
                {
                    btnConfirm.Visible = false;
                    MessageBox.Show($"{sKetQua}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
            finally
            {
                btnKiemtra.Enabled = true;
                this.Cursor = Cursors.Default;
            }
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
            DataTable dt = new DataTable();
            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
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

        private DataTable ReadFromExcelfile_ByNhanVien(string path, string sheetName, string sKey)
        {
            DataTable dt = new DataTable();
            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets.FirstOrDefault();
                foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
                {
                    dt.Columns.Add(firstRowCell.Text);
                }
                dt.Columns.Add("NVID");
                dt.Columns.Add("SCT");

                for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                {
                    var row = workSheet.Cells[rowNumber, 1, rowNumber, 6];
                    bool isEmptyRow = true;
                    foreach (var cell in row)
                    {
                        if (!string.IsNullOrWhiteSpace(cell.Text))
                        {
                            isEmptyRow = false;
                            break;
                        }
                    }

                    if (isEmptyRow)
                        continue;

                    var newRow = dt.NewRow();
                    foreach (var cell in row)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text;
                    }

                    newRow["NVID"] = Common.NVID.ToString();
                    newRow["SCT"] = sKey;
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
                txtPath.Text = openFileDialog1.FileName;
                ResetUI();
            }
        }

        private void ResetUI()
        {
            txtsoHD.Text = String.Empty;
            txttongthanhtoan.Text = String.Empty;
            txtghichu.Text = String.Empty;
            novLabel3.Text = "Danh sách không đúng";
            novLabel4.Text = "Danh sách thanh toán";
            btnConfirm.Visible = false;
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            cboNH.SelectedIndex = 0;
        }

        private void frGachNo_Excel_Load(object sender, EventArgs e)
        {
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoGenerateColumns = false;
            // dm ngan hang
            var dmNganhang = db.DM_NGANHANG.OrderBy(x => x.TENNGANHANG).ToList();
            dmNganhang.Insert(0, new DM_NGANHANG
            {
                NGANHANG_ID = 0,
                TENNGANHANG = ""
            });

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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount == 0) return;
                if (txttongthanhtoan.Text == "" || txttongthanhtoan.Text == "0") return;

                if (cboNH.SelectedIndex == 0)
                {
                    MessageBox.Show("Chưa chọn Ngân hàng/Đơn vị thu hộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult rs = MessageBox.Show("Xác nhận thanh toán hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs != DialogResult.OK) return;

                this.Cursor = Cursors.WaitCursor;

                string sKetQua = xacNhanThanhToan();
                if (sKetQua == "OK")
                {
                    btnConfirm.Visible = false;
                    btnKiemtra.Visible = true;
                    dataGridView1.DataSource = null;
                    txtPath.Text = "";
                    txtsoHD.Text = "";
                    txttongthanhtoan.Text = "";
                    cboNH.SelectedIndex = 0;
                    novLabel4.Text = "Danh sách thanh toán";
                    MessageBox.Show("Gạch nợ Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}