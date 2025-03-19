using Ionic.Zip;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QLCongNo.Data;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcDongBoHDThuHo : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DataDanhMuc danhmuc = new DataDanhMuc();

        public UcDongBoHDThuHo()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            seachButton.Click += seachButton_Click;
            excelButton.Click += excelButton_Click;
            btnDB.Click += btnDB_Click;
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult rs = MessageBox.Show("Bạn có muốn đồng bộ dữ liệu đợt này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                var dataKyghi = db.DM_KYGHI.Where(x => x.hoadon == true).FirstOrDefault();
                var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                string IDKyghi = dataGridView1.SelectedRows[0].Cells[kyColumn.Name].Value.ToString();
                int nam = int.Parse(dataGridView1.SelectedRows[0].Cells[namColumn.Name].Value.ToString());
                int dotid = int.Parse(dataGridView1.SelectedRows[0].Cells[dotColumn.Name].Value.ToString());
                var xmlData = db.getXMLDataThuHo(nam, IDKyghi, dotid).FirstOrDefault().ToString();
                if (dotid == 0)
                {
                    MessageBox.Show("Đã đồng bộ dữ liệu, không để đồng bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string hashKey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                string pKyghi = dataKyghi.thang.ToString("00");
                string pfilename = "DSHOADON_" + nam.ToString() + "_" + pKyghi + "_" + dotid.ToString();
                string[] pFileInfo = { nam.ToString(), pKyghi, dotid.ToString(), pfilename };
                string pathXml = @"C:\VNPTDATA\" + "DSHOADON_" + nam.ToString() + "_" + pKyghi + "_" + dotid.ToString() + ".xml";
                string pathZlip = @"C:\VNPTDATA\" + "DSHOADON_" + nam.ToString() + "_" + pKyghi + "_" + dotid.ToString() + ".zip";
                deleteFile(pathXml);
                deleteFile(pathZlip);
                SaveFile(xmlData, "DSHOADON_" + nam.ToString() + "_" + pKyghi + "_" + dotid.ToString() + ".xml", "C:\\VNPTDATA");
                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                ZipFile_Inv(pathXml, pathZlip);
                byte[] pData = getByteData(pathZlip);
                string[] pDeleteInfo = { "", "" };
                object[] Arr_result = tdc.UploadInvoice("WASS01", hashKey, pData, pFileInfo.ToArray(), "");
                string result = Arr_result[0].ToString().ToUpper();
                if (result == "TRUE")
                {
                    THUHO_Log thuho = new THUHO_Log();
                    thuho.dot_id = dotid;
                    thuho.nam = nam - 2000;
                    thuho.ngaythuchien = DateTime.Now;
                    thuho.id_kyghi = IDKyghi;
                    thuho.nv_id = NVLap.nv_id;
                    db.THUHO_Log.Add(thuho);
                    db.SaveChanges();
                    MessageBox.Show("Đồng bộ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    seachButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Cõ lỗi trong quá trình xử lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            //}
            //catch
            //{
            //}
        }

        // delete file with file name
        public void deleteFile(string fileName)
        {
            if ((System.IO.File.Exists(fileName)))
            {
                System.IO.File.Delete(fileName);
            }
        }

        // delete all file
        public void deleteFolder(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public byte[] getByteData(string pathZlip)
        {
            string sZipFile = pathZlip;
            FileInfo fInfo = new FileInfo(sZipFile);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(pathZlip, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            byte[] pFileData = br.ReadBytes(System.Convert.ToInt32(numBytes));
            br.Close();
            fStream.Close();
            return pFileData;
        }

        public void ZipFile_Inv(string pathXml, string pathFileZip)
        {
            string sXMLFile = @pathXml;
            string sZIPFile = pathFileZip;
            ZipFile zip = new ZipFile();
            zip.AddFile(sXMLFile, "");
            zip.Save(sZIPFile);
        }

        public static string SaveFile(string content, string fileNme = "", string path = null)
        {
            if (String.IsNullOrEmpty(path))
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string ex = "." + fileNme.Substring(fileNme.LastIndexOf(".") + 1);

            /// path += "\\" + fileNme;
            int i = 1;
            string tem = fileNme;

            string newFullPath = path + "\\" + fileNme;

            while (File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}-{1}", fileNme, i++);
                newFullPath = Path.Combine(path, tempFileName + ex);
            }
            path = newFullPath;

            if (fileNme.Substring(fileNme.LastIndexOf(".") + 1) == "pdf")
            {
                byte[] bytes = Convert.FromBase64String(content);
                System.IO.FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

                System.IO.BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
                return (File.Exists(path)) ? path : "False";
            }
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path);
                file.Write(content);
                file.Close();
            }
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }

            return (File.Exists(path)) ? path : "False";
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dataKyghi = db.DM_KYGHI.Where(x => x.hoadon == true).FirstOrDefault();
                int DOTID = int.Parse(cboDot.SelectedValue.ToString());
                var dataSource = db.getDSDongBoDuLieuThuHo(dataKyghi.nam, dataKyghi.ID_kyghi, DOTID, 0).ToList();
                if(dataSource.Count > 0)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }    
                dataGridView1.DataSource = dataSource.ToList();
            }
            catch
            {
            }
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Common.ExportExcel(dataGridView1);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }

        private void frDongBoHDThuHo_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = false;

            // dm ky ghi
            cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            var dataKyghi = db.DM_KYGHI.Where(x => x.hoadon == true).OrderByDescending(x => x.ID_kyghi).ToList();
            cboKy.DataSource = dataKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            // dot
            cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            cboDot.DataSource = dataDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            // trang thai
            cboTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            string[] trangthai = { "Chưa đồng bộ", "Đã đồng bộ" };
            cboTT.DataSource = trangthai;
        }
    }
}