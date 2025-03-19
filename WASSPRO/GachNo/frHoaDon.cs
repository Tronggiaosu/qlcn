using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.IO;
namespace QLCongNo.GachNo
{
    public partial class frHoaDon : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        
        public frHoaDon()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            btnEX.Click += btnEX_Click;
            cboDot.SelectedIndexChanged += cboDot_SelectedIndexChanged;
            cboKy.SelectedIndexChanged += cboKy_SelectedIndexChanged;
            cboNam.SelectedIndexChanged += cboNam_SelectedIndexChanged;
            btnDelete.Click += btnDelete_Click;
            btnTim.Click += btnTim_Click;
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string dotid = cboDot.Text;
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            string thang = int.Parse(cboKy.Text).ToString("00");
            dataGridView1.DataSource = db.TDC_HOADON.Where(x => x.DOT == dotid.ToString() && x.NAM == (namid - 2000).ToString() && x.KY == thang).OrderBy(x=>x.DANHBO).ToList();
            lbltongso.Text = "Số lượng hóa đơn " + string.Format("{0:n0}", dataGridView1.RowCount);
            if(dataGridView1.RowCount>0)
                btnDelete.Visible = true;
            this.Cursor = Cursors.Default;
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            dataGridView1.Visible = true;
            var hoadon = db.HOADONs.Where(x => x.DOT_ID == dotid && x.nam == namid && x.kyghi == kyghi && x.ischeck == 1).ToList();
            var chitietHD = (from a in db.CHITIET_HD
                             from x in db.HOADONs
                             where x.ID_HD == a.ID_HD
                             where x.DOT_ID == dotid && x.nam == namid && x.kyghi == kyghi && x.ischeck == 0
                             select a).ToList();
            if (hoadon.Count != 0)
                MessageBox.Show("Hóa đơn đợt này đã được phát hành, không thể xóa!");
            else if (chitietHD.Count > 0)
                MessageBox.Show("Vui lòng xóa dữ liệu chi tiết hóa đơn trước khi xóa dữ liệu hóa đơn!");
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn xóa dữ liệu hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    db.deleteHoaDon(namid, kyghi, dotid);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Xóa dữ liệu thành công!");
                    btnDelete.Visible = false;
                    dataGridView1.DataSource = null;
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

        void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }


        void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtPath.Text != "")
            {
                decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
                decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
                string kyghi = cboKy.SelectedValue.ToString();
                var hoadon = db.HOADONs.Where(x => x.DOT_ID == dotid && x.nam == namid && x.kyghi == kyghi).ToList();
                if (btnLuu.Text == "Tải dữ liệu")
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (hoadon.Count != 0 )
                        MessageBox.Show("Hóa đơn kỳ này đã được import vào hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        dataGridView1.DataSource = GetDataTabletFromCSVFile(@"" + txtPath.Text + "");
                        var nam = dataGridView1.SelectedRows[0].Cells[NAMColumn.Name].Value.ToString();
                        var ky = dataGridView1.SelectedRows[0].Cells[KyColumn.Name].Value.ToString();
                        var dot = dataGridView1.SelectedRows[0].Cells[dotcolumn.Name].Value.ToString();
                        string kybilling = (int.Parse(nam) + 2000).ToString() + ky;
                        if (kybilling != kyghi || dot != dot.ToString())
                            MessageBox.Show("Dữ liệu trong file không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            btnLuu.Text = "Lưu dữ liệu";

                        lbltongso.Text = "Số lượng hóa đơn " + string.Format("{0:n0}", dataGridView1.RowCount);
                    }
                    this.Cursor = Cursors.Default;
                }

                else if (btnLuu.Text == "Lưu dữ liệu")
                {
                    if (hoadon.Count == 0)
                    {
                        DialogResult rs = MessageBox.Show("Bạn có muốn lưu dữ liệu?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (rs == DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            DataTable source = GetDataTabletFromCSVFile(@"" + txtPath.Text + "");
                            // insert TDC_HOADON
                            InsertDataIntoSQLServerUsingSQLBulkCopy(source);
                            // insert hoadon
                            var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                            SqlParameter prkyghi = new SqlParameter("@kyghi", kyghi);
                            SqlParameter prdotid = new SqlParameter("@dotid", dotid);
                            SqlParameter prnam = new SqlParameter("@nam", namid);
                            SqlParameter prNVID = new SqlParameter("@user_create", NVLap.nv_id);
                            db.Database.ExecuteSqlCommand("exec ImportHoaDon @user_create, @kyghi, @dotid, @nam", prNVID,  prkyghi, prdotid, prnam);
                            btnLuu.Enabled = false;
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPath.Text = "";
                            btnLuu.Text = "Lưu dữ liệu";
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                        MessageBox.Show("Hóa đơn kỳ này đã được import vào hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            DataColumn KHU = new DataColumn("KHU");
            csvData.Columns.Add(KHU);

            DataColumn DOT = new DataColumn("DOT");
            csvData.Columns.Add(DOT);

            DataColumn DANHBO = new DataColumn("DANHBO");
            csvData.Columns.Add(DANHBO);

            DataColumn CD = new DataColumn("CD");
            csvData.Columns.Add(CD);

            DataColumn KICHCODH = new DataColumn("KICHCODH");
            csvData.Columns.Add(KICHCODH);

            DataColumn HIEUDH = new DataColumn("HIEUDH");
            csvData.Columns.Add(HIEUDH);

            DataColumn SOHOPDONG = new DataColumn("SOHOPDONG");
            csvData.Columns.Add(SOHOPDONG);

            DataColumn HOTEN = new DataColumn("HOTEN");
            csvData.Columns.Add(HOTEN);

            DataColumn SONHA = new DataColumn("SONHA");
            csvData.Columns.Add(SONHA);

            DataColumn DIACHI = new DataColumn("DIACHI");
            csvData.Columns.Add(DIACHI);

            DataColumn MSKH = new DataColumn("MSKH");
            csvData.Columns.Add(MSKH);

            DataColumn MSCQ = new DataColumn("MSCQ");
            csvData.Columns.Add(MSCQ);

            DataColumn GIABIEU = new DataColumn("GIABIEU");
            csvData.Columns.Add(GIABIEU);

            DataColumn SH = new DataColumn("SH");
            csvData.Columns.Add(SH);

            DataColumn HCSN = new DataColumn("HCSN");
            csvData.Columns.Add(HCSN);

            DataColumn SX = new DataColumn("SX");
            csvData.Columns.Add(SX);

            DataColumn DV = new DataColumn("DV");
            csvData.Columns.Add(DV);

            DataColumn DMKD = new DataColumn("DMKD");
            csvData.Columns.Add(DMKD);

            DataColumn KY = new DataColumn("KY");
            csvData.Columns.Add(KY);

            DataColumn NAM = new DataColumn("NAM");
            csvData.Columns.Add(NAM);

            DataColumn CODE = new DataColumn("CODE");
            csvData.Columns.Add(CODE);

            DataColumn CODEFU = new DataColumn("CODEFU");
            csvData.Columns.Add(CODEFU);

            DataColumn CSCU = new DataColumn("CSCU");
            csvData.Columns.Add(CSCU);

            DataColumn CSMOI = new DataColumn("CSMOI");
            csvData.Columns.Add(CSMOI);

            DataColumn RETOUR = new DataColumn("RETOUR");
            csvData.Columns.Add(RETOUR);

            DataColumn TUNGAY = new DataColumn("TUNGAY");
            TUNGAY.AllowDBNull = true;
            csvData.Columns.Add(TUNGAY);

            DataColumn DENNGAY = new DataColumn("DENNGAY");
            csvData.Columns.Add(DENNGAY);

            DataColumn CHUKY_DS = new DataColumn("CHUKY_DS");
            csvData.Columns.Add(CHUKY_DS);

            DataColumn LNCC = new DataColumn("LNCC");
            csvData.Columns.Add(LNCC);

            DataColumn LNCT = new DataColumn("LNCT");
            csvData.Columns.Add(LNCT);

            DataColumn LN_BU_TOITHIEU = new DataColumn("LN_BU_TOITHIEU");
            csvData.Columns.Add(LN_BU_TOITHIEU);

            DataColumn LN_SH = new DataColumn("LN_SH");
            csvData.Columns.Add(LN_SH);

            DataColumn LN_HCSN = new DataColumn("LN_HCSN");
            csvData.Columns.Add(LN_HCSN);

            DataColumn LN_SX = new DataColumn("LN_SX");
            csvData.Columns.Add(LN_SX);

            DataColumn LN_DV = new DataColumn("LN_DV");
            csvData.Columns.Add(LN_DV);

            DataColumn CUON_GCS = new DataColumn("CUON_GCS");
            csvData.Columns.Add(CUON_GCS);

            DataColumn CUON_STT = new DataColumn("CUON_STT");
            csvData.Columns.Add(CUON_STT);

            DataColumn GIABAN = new DataColumn("GIABAN");
            csvData.Columns.Add(GIABAN);

            DataColumn THUEGTGT = new DataColumn("THUEGTGT");
            csvData.Columns.Add(THUEGTGT);

            DataColumn PHIBVMT = new DataColumn("PHIBVMT");
            csvData.Columns.Add(PHIBVMT);

            DataColumn TONGCONG = new DataColumn("TONGCONG");
            csvData.Columns.Add(TONGCONG);

            DataColumn GIABAN_BU_TOITHIEU = new DataColumn("GIABAN_BU_TOITHIEU");
            csvData.Columns.Add(GIABAN_BU_TOITHIEU);

            DataColumn THUEGTGT_BU_TOITHIEU = new DataColumn("THUEGTGT_BU_TOITHIEU");
            csvData.Columns.Add(THUEGTGT_BU_TOITHIEU);

            DataColumn PHIBVMT_BU_TOITHIEU = new DataColumn("PHIBVMT_BU_TOITHIEU");
            csvData.Columns.Add(PHIBVMT_BU_TOITHIEU);

            DataColumn TONGCONG_BU_TOITHIEU = new DataColumn("TONGCONG_BU_TOITHIEU");
            csvData.Columns.Add(TONGCONG_BU_TOITHIEU);

            DataColumn SO_PHATHANH = new DataColumn("SO_PHATHANH");
            csvData.Columns.Add(SO_PHATHANH);

            DataColumn SO_HOADON = new DataColumn("SO_HOADON");
            csvData.Columns.Add(SO_HOADON);

            DataColumn NGAY_PHATHANH = new DataColumn("NGAY_PHATHANH");
            csvData.Columns.Add(NGAY_PHATHANH);

            DataColumn QUAN = new DataColumn("QUAN");
            csvData.Columns.Add(QUAN);

            DataColumn PHUONG = new DataColumn("PHUONG");
            csvData.Columns.Add(PHUONG);

            DataColumn SODHN = new DataColumn("SODHN");
            csvData.Columns.Add(SODHN);

            DataColumn MST = new DataColumn("MST");
            csvData.Columns.Add(MST);

            DataColumn TILE_TIEUTHU = new DataColumn("TILE_TIEUTHU");
            csvData.Columns.Add(TILE_TIEUTHU);

            DataColumn NGAY_GANDH = new DataColumn("NGAY_GANDH");
            csvData.Columns.Add(NGAY_GANDH);

            DataColumn VUNG_DMA = new DataColumn("VUNG_DMA");
            csvData.Columns.Add(VUNG_DMA);

            DataColumn TIEUVUNG_DMA = new DataColumn("TIEUVUNG_DMA");
            csvData.Columns.Add(TIEUVUNG_DMA);

            DataColumn FAX = new DataColumn("FAX");
            csvData.Columns.Add(FAX);

            DataColumn MAIL = new DataColumn("MAIL");
            csvData.Columns.Add(MAIL);

            DataColumn CUST_ID = new DataColumn("CUST_ID");
            csvData.Columns.Add(CUST_ID);

            DataColumn STT = new DataColumn("STT");
            csvData.Columns.Add(STT);

            DataColumn DIACHITRUSO = new DataColumn("DIACHITRUSO");
            csvData.Columns.Add(DIACHITRUSO);

            DataColumn DINHMUCHONGHEO = new DataColumn("DINHMUCHONGHEO");
            csvData.Columns.Add(DINHMUCHONGHEO);

            DataColumn STGCOV = new DataColumn("STGCOV");
            csvData.Columns.Add(STGCOV);

            DataColumn TienThueNT = new DataColumn("TienThueNT");
            csvData.Columns.Add(TienThueNT);

            DataColumn M3GiaCu = new DataColumn("M3GiaCu");
            csvData.Columns.Add(M3GiaCu);

            DataColumn M3GiaMoi = new DataColumn("M3GiaMoi");
            csvData.Columns.Add(M3GiaMoi);

            DataColumn PhiBVMTCu = new DataColumn("PhiBVMTCu");
            csvData.Columns.Add(PhiBVMTCu);

            DataColumn PhiNT = new DataColumn("PhiNT");
            csvData.Columns.Add(PhiNT);

            DataColumn LNSUCXA = new DataColumn("LNSUCXA");
            csvData.Columns.Add(LNSUCXA);

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
        static void AddHeading(string csv_file_path)
        {
            string csvLine = "\"HIEUDH\",\"SOHOPDONG\",\"HOTEN\",\"SONHA\",\"DIACHI\",\"MSKH\",\"MSCQ\",\"GIABIEU\",\"SH\",\"HCSN\",\"SX\",\"DV\",\"DMKD\",\"KY\",\"NAM\",\"CODE\",\"CODEFU\",\"CSCU\",\"CSMOI\",\"RETOUR\",\"TUNGAY\",\"DENNGAY\",\"CHUKY_DS\",\"LNCC\",\"LNCT\",\"LN_BU_TOITHIEU\",\"LN_SH\",\"LN_HCSN\",\"LN_SX\",\"LN_DV\",\"CUON_GCS\",\"CUON_STT\",\"GIABAN\",\"THUEGTGT\",\"PHIBVMT\",\"TONGCONG\",\"GIABAN_BU_TOITHIEU\",\"THUEGTGT_BU_TOITHIEU\",\"PHIBVMT_BU_TOITHIEU\",\"TONGCONG_BU_TOITHIEU\",\"SO_PHATHANH\",\"SO_HOADON\",\"NGAY_PHATHANH\",\"QUAN\",\"PHUONG\",\"SODHN\",\"MST\",\"TILE_TIEUTHU\",\"NGAY_GANDH\",\"VUNG_DMA\",\"TIEUVUNG_DMA\",\"FAX\""+
              ",\"MAIL\",\"CUST_ID\",\"STT\",\"DIACHITRUSO\",\"STGCOV\",\"TienThueNT\",\"M3GiaCu\",\"M3GiaMoi\",\"PhiBVMTCu\",\"PhiNT\",\"LNSUCXA\"" + Environment.NewLine;
            byte[] csvLineBytes = Encoding.Default.GetBytes(csvLine);
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(csvLineBytes, 0, csvLineBytes.Length);
                using (FileStream file = new FileStream(csv_file_path, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms.Write(bytes, 0, (int)file.Length);
                }

                using (FileStream file = new FileStream(csv_file_path, FileMode.Open, FileAccess.Write))
                {
                    ms.WriteTo(file);
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
                    s.DestinationTableName = "TDC_HOADON";
                    foreach (var column in csvFileData.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(csvFileData);
                }
            }
        }
        //private void setData(string path)
        //{
        //    System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder entityBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(Common.strConn);
        //    string strconnect = entityBuilder.ProviderConnectionString;
        //    var lines = System.IO.File.ReadAllLines(@"" + path + "");
        //    if (lines.Count() == 0) return;
        //    var columns = lines[0].Split(',');
        //    var table = new DataTable();
        //    foreach (var c in columns)
        //        table.Columns.Add(c);

        //    for (int i = 1; i < lines.Count() - 1; i++)
        //        table.Rows.Add(lines[i].Split(','));


        //    var sqlBulk = new SqlBulkCopy(strconnect);
        //    sqlBulk.DestinationTableName = "TDC_HOADON";
        //    sqlBulk.WriteToServer(table);
        //}

        void button1_Click(object sender, EventArgs e)
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

        private void frHoaDon_Load(object sender, EventArgs e)
        {
            txtPath.Enabled = false;
            // dm ky ghi
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            //dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.Where(x=>x.hoadon == true).OrderBy(x => x.ten_kyghi).ToList();
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
            btnDelete.Visible = false;
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
            var hoadon = db.HOADONs.Where(x =>x.kyghi == kyghi && x.DOT_ID == dotid).Count();
            if (hoadon != 0)
                MessageBox.Show("Hóa đơn kỳ này đã được import vào hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                SqlParameter prkyghi = new SqlParameter("@kyghi", kyghi);
                SqlParameter prdotid = new SqlParameter("@dotid", dotid);
                SqlParameter prnam = new SqlParameter("@nam", namid);
                SqlParameter prNVID = new SqlParameter("@user_create", NVLap.nv_id);
                db.Database.ExecuteSqlCommand("exec ImportHoaDon @user_create, @kyghi, @dotid, @nam", prNVID, prkyghi, prdotid, prnam);
                btnLuu.Enabled = false;
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkChonFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
