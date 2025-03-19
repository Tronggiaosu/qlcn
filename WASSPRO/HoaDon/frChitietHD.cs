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

namespace QLCongNo.HoaDon
{
    public partial class frChitietHD : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        DataTable table;
        public frChitietHD()
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

        void btnDelete_Click(object sender, EventArgs e)
        {
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            var chitiethoadon = db.CHITIET_HD.Where(x => x.HOADON.DOT_ID == dotid && x.HOADON.nam == namid && x.HOADON.kyghi == kyghi && x.HOADON.trangthai_id != 0 && x.isImport == 1).ToList();
            if (chitiethoadon.Count > 0)
                MessageBox.Show("Hóa đơn của kỳ này đã được phát hành, không thể xóa dữ liệu chi tiết hóa đơn!");
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa dữ liệu chi tiết hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    db.deleteChiTietHD(namid, kyghi, dotid);
                    MessageBox.Show("Xóa dữ liệu thành công!");
                    btnTim.PerformClick();
                }
            }
        }
        void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLuu.Text = "Tải dữ liệu";
        }

        void cboKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLuu.Text = "Tải dữ liệu";
        }

        void cboDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLuu.Text = "Tải dữ liệu";
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            decimal dotid = decimal.Parse( cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            var dsChitiet = db.CHITIET_HD.Where(x => x.HOADON.kyghi == kyghi && x.HOADON.DOT_ID == dotid).Select(x => x.TDC_CHITIETHD).ToList();
            dataGridView1.DataSource = dsChitiet.ToList();
            lblsoluong.Text = "Số lượng: " + string.Format("{0:n0}", dataGridView1.RowCount);
            if (dataGridView1.RowCount > 0)
                btnDelete.Visible = true;
            this.Cursor = Cursors.Default;
        }

        void btnEX_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Xuất dữ liệu thành công!");
            }
        }

        void btnLuu_Click(object sender, EventArgs e)
        {
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            dataGridView1.Visible = true;
            if (txtPath.Text != "")
            {
                if (btnLuu.Text == "Tải dữ liệu")
                {
                    btnLuu.Text = "Lưu dữ liệu";
                    dataGridView1.DataSource = GetDataTabletFromCSVFile(@"" + txtPath.Text + "", namid, kyghi, dotid);
                    lblsoluong.Text = "Số lượng: " +  string.Format("{0:n0}", dataGridView1.RowCount) + " dòng";
                }
                else if (btnLuu.Text == "Lưu dữ liệu")
                {
                    var hoadon = db.HOADONs.Where(x => x.DOT_ID == dotid && x.kyghi == kyghi).Select(x=>x.ID_HD.ToString()).ToList();
                    var isImport = db.HOADON_CHITIETHD(namid, kyghi, dotid).FirstOrDefault();
                    if (hoadon.Count == 0)
                        MessageBox.Show("Hóa đơn kỳ này không tồn tại trong hệ thống, vui lòng import dữ liệu hóa đơn!");
                    else if (isImport > 0)
                        MessageBox.Show("Chi tiết hóa đơn kỳ này đã cập nhật !");
                    else
                    {
                        DialogResult rs = MessageBox.Show("Bạn có muốn lưu dữ liệu?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (rs == DialogResult.OK)
                        {
                            var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                            DataTable source = GetDataTabletFromCSVFile(@"" + txtPath.Text + "", namid, kyghi, dotid);
                            InsertDataIntoSQLServerUsingSQLBulkCopy(source);
                            SqlParameter prNVID = new SqlParameter("@user_create", NVLap.nv_id);
                            SqlParameter prkyghi = new SqlParameter("@ky", kyghi);
                            SqlParameter prdotid = new SqlParameter("@dot_id", dotid);
                            SqlParameter prnam = new SqlParameter("@nam", namid);
                            SqlParameter prdate = new SqlParameter("@date_create", DateTime.Now);
                            
                            db.Database.ExecuteSqlCommand("exec ImportChiTietHD @user_create, @date_create, @ky, @dot_id, @nam", prNVID, prdate, prkyghi, prdotid, prnam);
                            MessageBox.Show("Lưu dữ liệu thành công!");
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
        static void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable csvFileData)
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
        void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void button1_Click(object sender, EventArgs e)
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
            // dm ky ghi
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            //dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.Where(x => x.hoadon == true).OrderBy(x => x.ten_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            cboKy.DataSource = dmKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "thang";
            // dm nam
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            //dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            cboNam.DataSource = dataKyghi.ToList();
            cboNam.ValueMember = "nam";
            cboNam.DisplayMember = "NAM";
            // dm dot
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            //dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
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
