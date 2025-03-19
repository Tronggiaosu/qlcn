using Microsoft.VisualBasic.FileIO;
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

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcChitietHD : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DataTable table;

        public UcChitietHD()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            btnHuy.Click += btnHuy_Click;
            btnLuu.Click += btnLuu_Click;
            btnEX.Click += btnEX_Click;
            btnTim.Click += btnTim_Click;
            cboDot.SelectedIndexChanged += cboDot_SelectedIndexChanged;
            cboKy.SelectedIndexChanged += cboKy_SelectedIndexChanged;
            cboNam.SelectedIndexChanged += cboNam_SelectedIndexChanged;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            var chitiethoadon = db.CHITIET_HD.Where(x => x.HOADON.DOT_ID == dotid && x.HOADON.nam == namid && x.HOADON.kyghi == kyghi && x.HOADON.trangthai_id != 0 && x.isImport == 1).ToList();
            if (chitiethoadon.Count > 0)
                MessageBox.Show("Hóa đơn của kỳ này đã được phát hành, không thể xóa dữ liệu chi tiết hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa dữ liệu chi tiết hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    db.deleteChiTietHD(namid, kyghi, dotid);
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTim.PerformClick();
                }
            }
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLuu.Text = "Tải dữ liệu";
        }

        private void cboKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLuu.Text = "Tải dữ liệu";
        }

        private void cboDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLuu.Text = "Tải dữ liệu";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            string result = namid + kyghi;
            var dsChitiet = db.CHITIET_HD.Where(x => x.HOADON.kyghi == result && x.HOADON.DOT_ID == dotid).Select(x => x.TDC_CHITIETHD).ToList();  
            dataGridView1.DataSource = dsChitiet.ToList();
            lblsoluong.Text = "Số lượng: " + string.Format("{0:n0}", dataGridView1.RowCount);
            if (dataGridView1.RowCount > 0)
                btnDelete.Visible = true;
            this.Cursor = Cursors.Default;
        }

        private void btnEX_Click(object sender, EventArgs e)
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
                decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
                decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
                string kyghi = cboKy.SelectedValue.ToString();
                var dsChitiet = db.CHITIET_HD.Where(x => x.HOADON.kyghi == kyghi && x.HOADON.DOT_ID == dotid).Select(x => x.TDC_CHITIETHD).ToList();
                table = ExcelExportHelper.ListToDataTable(dsChitiet.ToList());

                string[] columns = { "CUST_ID", "STT", "maDT", "m3tieuthu", "gianuoc", "m3BVMT", "phiBVMT", "nam", "kyghi", "dot_id" };

                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            string result = namid + kyghi;
            dataGridView1.Visible = true;
            if (txtPath.Text != "")
            {
                if (btnLuu.Text == "Tải dữ liệu")
                {
                    btnLuu.Text = "Lưu dữ liệu";
                    dataGridView1.DataSource = GetDataTabletFromCSVFile(@"" + txtPath.Text + "", namid, result, dotid);
                    lblsoluong.Text = "Số lượng: " + string.Format("{0:n0}", dataGridView1.RowCount) + " dòng";
                }
                else if (btnLuu.Text == "Lưu dữ liệu")
                {
                    var hoadon = db.HOADONs.Where(x => x.DOT_ID == dotid && x.kyghi == result).Select(x => x.ID_HD.ToString()).ToList();
                    var isImport = db.HOADON_CHITIETHD(namid, result, dotid).FirstOrDefault();
                    if (hoadon.Count == 0)
                        MessageBox.Show("Hóa đơn kỳ này không tồn tại trong hệ thống, vui lòng import dữ liệu hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (isImport > 0)
                        MessageBox.Show("Chi tiết hóa đơn kỳ này đã cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        DialogResult rs = MessageBox.Show("Bạn có muốn lưu dữ liệu?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (rs == DialogResult.OK)
                        {
                            var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                            DataTable source = GetDataTabletFromCSVFile(@"" + txtPath.Text + "", namid, result, dotid);
                            InsertDataIntoSQLServerUsingSQLBulkCopy(source);
                            SqlParameter prNVID = new SqlParameter("@user_create", NVLap.nv_id);
                            SqlParameter prkyghi = new SqlParameter("@ky", result);
                            SqlParameter prdotid = new SqlParameter("@dot_id", dotid);
                            SqlParameter prnam = new SqlParameter("@nam", namid);
                            SqlParameter prdate = new SqlParameter("@date_create", DateTime.Now);

                            db.Database.ExecuteSqlCommand("exec ImportChiTietHD @user_create, @date_create, @ky, @dot_id, @nam", prNVID, prdate, prkyghi, prdotid, prnam);
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPath.Text = "";
                            btnLuu.Text = "Tải dữ liệu";
                            btnTim.PerformClick();
                        }
                    }
                }
            }
        }

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path, decimal nam_id, string id_kyghi, decimal dot_id)
        {
            DataTable csvData = new DataTable();
            DataColumn CUST_ID = new DataColumn("CUST_ID");
            CUST_ID.AllowDBNull = true;
            csvData.Columns.Add(CUST_ID);

            DataColumn STT = new DataColumn("STT");
            STT.AllowDBNull = true;
            csvData.Columns.Add(STT);

            DataColumn maDT = new DataColumn("maDT");
            maDT.AllowDBNull = true;
            csvData.Columns.Add(maDT);

            DataColumn m3tieuthu = new DataColumn("m3tieuthu");
            m3tieuthu.AllowDBNull = true;
            csvData.Columns.Add(m3tieuthu);

            DataColumn gianuoc = new DataColumn("gianuoc");
            gianuoc.AllowDBNull = true;
            csvData.Columns.Add(gianuoc);

            DataColumn m3BVMT = new DataColumn("m3BVMT");
            m3BVMT.AllowDBNull = true;
            csvData.Columns.Add(m3BVMT);

            DataColumn phiBVMT = new DataColumn("phiBVMT");
            phiBVMT.AllowDBNull = true;
            csvData.Columns.Add(phiBVMT);
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

            DataColumn nam = new DataColumn("nam");
            nam.AllowDBNull = true;
            csvData.Columns.Add(nam);

            DataColumn kyghi = new DataColumn("kyghi");
            kyghi.AllowDBNull = true;
            csvData.Columns.Add(kyghi);

            DataColumn dot = new DataColumn("dot_id");
            dot.AllowDBNull = true;
            csvData.Columns.Add(dot);

            foreach (DataRow row in csvData.Rows)
            {
                row["nam"] = nam_id;
                row["kyghi"] = id_kyghi;
                row["dot_id"] = dot_id;
            }

            return csvData;
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
                    s.DestinationTableName = "TDC_CHITIETHD";
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show the Dialog.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // show only file .xml
            openFileDialog1.Filter = "Excel Worksheets|*.dat";
            openFileDialog1.Title = "Select a File";
            // If the user clicked OK in the dialog and
            // a .xml file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                // link file name
                txtPath.Text = openFileDialog1.FileName;
                if (txtPath.Text != "")
                    btnLuu.Enabled = true;
            }
        }

        private void frChitietHD_Load(object sender, EventArgs e)
        {
            txtPath.Enabled = false;
            var dataMauHD = db.MAU_HD.Where(x => x.Active == true).ToList();
            cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            for (int i = 1; i <= 12; i++)
            {
                dmKyghi.Add(new DM_KYGHI()
                {
                    ID_kyghi = i.ToString("00"),
                    ten_kyghi = $"{i:00}"
                });
            }
            cboKy.DataSource = dmKyghi;
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";

            // dm nam
            cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "nam";
            cboNam.DisplayMember = "NAM";

            // dm dot
            cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            btnLuu.Enabled = false;
            dataGridView1.Visible = true;
            btnDelete.Visible = false;
        }
    }
}