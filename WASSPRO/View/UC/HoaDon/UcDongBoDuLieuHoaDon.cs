using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcDongBoDuLieuHoaDon : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcDongBoDuLieuHoaDon()
        {
            InitializeComponent();
            txtdanhbo.KeyDown += txtdanhbo_KeyDown;
            this.dataGridView1.DataError += dataGridView1_DataError;
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "KyGhiColumn")
            {
                if (e.Value != null)
                {
                    string kyghiFull = e.Value.ToString();
                    if (kyghiFull.Length >= 2)
                    {
                        e.Value = kyghiFull.Substring(0, 2);
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "namColumn")
            {
                if (e.Value != null)
                {
                    string kyghiFull = e.Value.ToString();
                    if (kyghiFull.Length >= 2)
                    {
                        e.Value = kyghiFull.Substring(3, 4);
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
          //  this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string danhbo = txtdanhbo.Text;
                if (danhbo != "")
                {
                    var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == danhbo).FirstOrDefault();
                    if (khachhang != null)
                    {
                        var dsHoadon = db.getDSHoaDon_KH(khachhang.ID_KH).ToList().OrderByDescending(X => X.ID_HD).ToList();
                        lbltongno.Text = "Tổng số tiền nợ: " + string.Format("{0:n0}", dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Select(x => x.tongtien).Sum());
                        lbltongsokyno.Text = "Tổng số kỳ nợ: " + dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Count().ToString();
                        if (dsHoadon.Count > 0)
                        {
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }      
                        dataGridView1.DataSource = dsHoadon.OrderByDescending(X => X.ngaytao).ToList();

                        for (int i = 0; i < dsHoadon.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i + 1;
                        }

                    }
                }
            }
            catch
            {

            }
        }

        private void frDongBoDuLieuHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnDongBo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime ngay = DateTime.Parse("2024-02-02 16:00:00");
            //    var thuho = db.THU_HO.Where(x => x.ngay_thanh_toan >= ngay).ToList();
            //    string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
            //    ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
            //    foreach (var item in thuho)
            //    {
            //        decimal IDHD = decimal.Parse(item.ma_kh.ToString());
            //        var chungtu = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).FirstOrDefault();
            //        if (chungtu != null)
            //        {
            //            var pb = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
            //            pb.GACH_NO = null;
            //            db.SaveChanges();
            //            var loaichungtu = db.CHUNGTUs.Where(x => x.ID_CT == chungtu.ID_CT).FirstOrDefault();
            //            var dshoadon = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).ToList();
            //            object[] reseult = tdc.ThanhToanHoaDonList("WASS01", hashkey, dshoadon.Select(x => x.ID_HD.ToString()).ToArray(), dshoadon.FirstOrDefault().DANHBO, "", dshoadon.FirstOrDefault().GHICHU, Common.username, loaichungtu.MALOAI, "", "").ToArray();
            //            var chuyendathu = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
            //            chuyendathu.GACH_NO = "1";
            //            db.SaveChanges();
            //        }
            //    }
            //    MessageBox.Show("Đồng bộ thành công!");

            //}
            //catch
            //{

            //}
            
            try
            {
                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                for (int i = 0; i <= dataGridView1.RowCount; i++)
                {
                    decimal IDHD = decimal.Parse(dataGridView1.SelectedRows[i].Cells[IDHDColumn.Name].Value.ToString());
                    var chungtu = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                    if (chungtu != null)
                    {
                        var pb = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
                        pb.GACH_NO = null;
                        db.SaveChanges();
                        var loaichungtu = db.CHUNGTUs.Where(x => x.ID_CT == chungtu.ID_CT).FirstOrDefault();
                        var dshoadon = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).ToList();
                        object[] reseult = tdc.ThanhToanHoaDonList("WASS01", hashkey, dshoadon.Select(x => x.ID_HD.ToString()).ToArray(), dshoadon.FirstOrDefault().DANHBO, "", dshoadon.FirstOrDefault().GHICHU, Common.username, loaichungtu.MALOAI, "", "").ToArray();
                        var chuyendathu = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
                        chuyendathu.GACH_NO = "1";
                        db.SaveChanges();
                    }
                }
                MessageBox.Show("Đồng bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {

            }
            
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            decimal IDHD = decimal.Parse(dataGridView1.SelectedRows[0].Cells[IDHDColumn.Name].Value.ToString());
             string hashKey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
            ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
            var hoadonmoi = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
            var pDMky = db.DM_KYGHI.Where(x => x.ID_kyghi == hoadonmoi.kyghi).FirstOrDefault();
            string pfilename = "DSHOADON_" + hoadonmoi.nam.ToString() + "_" + pDMky.thang.ToString() + "_"
                + hoadonmoi.DOT_ID.ToString() + "_" + hoadonmoi.DANHBO + "_" + hoadonmoi.ID_HD.ToString() + "_DC";

            string[] pFileInfo = { pDMky.nam.ToString(), pDMky.thang.ToString(), hoadonmoi.DOT_ID.ToString(), pfilename };
            string pathXml = @"C:\VNPTDATA\" + pfilename + ".xml";
            string pathZlip = @"C:\VNPTDATA\" + pfilename + ".zip";
            string xmlData = db.getXMLThuHo_DieuChinh(hoadonmoi.ID_HD).FirstOrDefault().ToString();
            deleteFile(pathXml);
            deleteFile(pathZlip);
            SaveFile(xmlData, pfilename + ".xml", "C:\\VNPTDATA");
            ZipFile_Inv(pathXml, pathZlip);
            byte[] pData = getByteData(pathZlip);
            string[] pDeleteInfo = { "", "" };
            object[] Arr_result = tdc.UploadInvoice("WASS01", hashKey, pData, pFileInfo.ToArray(), "");
            string pResult_TH = Arr_result[0].ToString().ToUpper();
        }
              public void ZipFile_Inv(string pathXml, string pathFileZip)
        {
            string sXMLFile = @pathXml;
            string sZIPFile = pathFileZip;
            ZipFile zip = new ZipFile();
            zip.AddFile(sXMLFile, "");
            zip.Save(sZIPFile);
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
        public void deleteFile(string fileName)
        {
            if ((System.IO.File.Exists(fileName)))
            {
                System.IO.File.Delete(fileName);
            }
        }

        private void txtdanhbo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void txtdanhbo_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtdanhbo.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnTim.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
