using Ionic.Zip;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QLCongNo.View.UC.ReportViewer.BaoCao;
using QLCongNo.ReportViewer.DataSource;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcQuanlyQD_DieuChinh : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private decimal QDID;
        private DataTable table;

        public UcQuanlyQD_DieuChinh()
        {
            InitializeComponent();
            seachButton.Click += seachButton_Click;
            btnUpdate.Click += btnUpdate_Click;
            dataGridView1.RowEnter += dataGridView1_RowEnter;
            btnIn.Click += btnIn_Click;
            //btnCapnhat.Click += btnCapnhat_Click;
            btnInDS.Click += btnInDS_Click;
            btnXoa.Click += btnXoa_Click;
            quitButton.Click += quitButton_Click;
            btnConfirm.Click += btnConfirm_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            this.dataGridView1.DataError += dataGridView1_DataError;
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "kyghiColumn")
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
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var QDID = decimal.Parse(dataGridView1.SelectedRows[0].Cells[QDIDColumn.Name].Value.ToString());
            var yeucauDC = db.YEUCAU_DIEUCHINH.Where(x => x.QD_ID == QDID).FirstOrDefault();
            var manv = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
            var nguoidung = db.NGUOIDUNGs.Where(x => x.nv_id == manv.nv_id).FirstOrDefault();
            var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
            if (nguoidung.isLock == false)
            {
                if (yeucauDC.isdaduyet == true)
                    MessageBox.Show("Hóa đơn này đã điều chỉnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (yeucauDC.tongtien_DC == 0)
                    MessageBox.Show("Chưa nhập số tiền điều chỉnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DialogResult rs = MessageBox.Show("Bạn có xác nhận điều chỉnh hóa đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        // tao hoa don dieu chinh
                        int NVID = int.Parse(Common.NVID.ToString());
                        var hoadon = db.HOADONs.Where(x => x.ID_HD == yeucauDC.IDHD).FirstOrDefault();
                        // dieu chinh HDDT
                        if (hoadon != null)
                        {
                            if (int.Parse(hoadon.kyghi) >= 201907)
                            {
                                string fkeycu = "0";
                                int pNVID = int.Parse(NVID.ToString());
                                db.update_taohoadondieuchinh(yeucauDC.IDHD, yeucauDC.QD_ID, NVID);
                                var hoadonmoi = db.HOADONs.Where(x => x.keys == hoadon.ID_HD).FirstOrDefault();
                                var hoadonloi = db.HOADONs.Where(x => x.ID_KH == hoadonmoi.ID_KH && x.trangthai_id == -22).FirstOrDefault();
                                if (hoadonloi != null)
                                    fkeycu = hoadonloi.ID_HD.ToString();
                                else
                                    fkeycu = hoadonmoi.keys.ToString();
                                var hoadon2 = db.HOADONs.Where(x => x.ID_HD == hoadon.keys).FirstOrDefault();
                                if (hoadon2 != null)
                                {
                                    fkeycu = hoadon.keys.ToString();
                                    hoadon.KY_HIEU_HD = hoadon2.KY_HIEU_HD;
                                }
                                // phat hanh hoa don dieu chinh
                                bs78.BusinessService bs = new bs78.BusinessService();
                                int Ptype = 0;
                                if (yeucauDC.loaiDC == 3)
                                    Ptype = 2;
                                if (yeucauDC.loaiDC == 4)
                                    Ptype = 3;
                                string xml = db.sp_xmlAdjustInv(hoadonmoi.ID_HD, hoadon.MAU_HD, Ptype).FirstOrDefault();
                                var mauHD = db.MAU_HD.Where(x => x.Active == true).FirstOrDefault();
                                string mauHD1 = mauHD.mau_HD1;
                                string kyhieu = mauHD.ky_hieu_HD;
                                decimal soHoaDon = decimal.Parse(hoadon.SO_HD);
                                string ngayPhatHanh = hoadon.ArisingDate.Value.ToString("dd/MM/yyyy");
                                string result = "";
                                var hoadonsai = db.HOADONs.Where(x => x.ID_HD == hoadon.ID_HD && x.DOT_ID == 1 && x.kyghi == "202302").FirstOrDefault();
                                if (hoadonsai != null)
                                    fkeycu = hoadonsai.DienGiai;
                                result = bs.AdjustInvoiceAction("capnuocthuducadmin", acc.pass_admin, xml, "capnuocthuducservice", "Einv@oi@vn#pt20", fkeycu, "", 0, mauHD1, kyhieu).ToString();
                                yeucauDC.isdaduyet = true;
                                db.SaveChanges();
                                if (result.Substring(0, 2) == "OK")
                                {
                                    var pyeucauDC = db.YEUCAU_DIEUCHINH.Where(x => x.QD_ID == QDID).FirstOrDefault();
                                    pyeucauDC.isdaduyet = true;
                                    db.SaveChanges();
                                    StringParserToInv(result);
                                    string hashKey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                                    ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                                    string[] dsHoaDoncu = db.HOADONs.Where(x => x.ID_HD == hoadonmoi.keys).Select(x => x.ID_HD.ToString()).ToArray();
                                    object[] preseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashKey, Common.username, hoadon.DANHBO, dsHoaDoncu, "2", "hoa don bi dieu chinh").ToArray();
                                    string result1 = preseult[0].ToString().ToUpper();
                                    if (result1 == "TRUE")
                                    {
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
                                        if (pResult_TH == "TRUE")
                                        {
                                            // update trang thai hd cu
                                            var Publish = db.PublishedInvoices.Where(x => x.IDHD == hoadon.ID_HD).FirstOrDefault();
                                            Publish.FKEY_DC = hoadonmoi.ID_HD;
                                            db.SaveChanges();
                                            // insert hoa don moi
                                            db.update_hoadondieuchinh(yeucauDC.IDHD, hoadonmoi.ID_HD, 0, Publish.IDNhanvienHD, NVID);
                                            //update hoa don
                                            hoadonmoi.trangthai_id = yeucauDC.loaiDC;
                                            db.SaveChanges();
                                            var hoadoncu = db.HOADONs.Where(x => x.ID_HD == hoadonmoi.keys).FirstOrDefault();
                                            hoadoncu.trangthai_id = 2;
                                            db.SaveChanges();
                                            // update yeu cau dieu chinh
                                            yeucauDC.isdaduyet = true;
                                            hoadon.ghichu = "đã điều chỉnh";
                                            yeucauDC.user_update = Common.NVID;
                                            yeucauDC.date_update = DateTime.Now;
                                            db.SaveChanges();
                                            try
                                            {
                                                var tonghopdulieu = db.TongDuLieuDieuChinhs.Where(x => x.KhachHangID == yeucauDC.IDKH && x.KyHoaDon == yeucauDC.kyghi).FirstOrDefault();
                                                if (tonghopdulieu == null)
                                                {
                                                    TongDuLieuDieuChinh dieuchinh = new TongDuLieuDieuChinh();
                                                    dieuchinh.KhachHangID = (decimal)yeucauDC.IDKH;
                                                    dieuchinh.KyHoaDon = yeucauDC.kyghi;
                                                    dieuchinh.TienNuocDC = (decimal)yeucauDC.tiennuoc_DC;
                                                    dieuchinh.TienThueDC = (decimal)yeucauDC.tienthue_DC;
                                                    dieuchinh.TienPhiBVMTDC = (decimal)yeucauDC.tienBVMT_DC;
                                                    dieuchinh.TienPhiNTDC = (decimal)yeucauDC.tienNT_DC;
                                                    dieuchinh.ThuePhiNTDC = (decimal)yeucauDC.thueNT_DC;
                                                    dieuchinh.TongTienDC = (decimal)yeucauDC.tongtien_DC;
                                                    db.TongDuLieuDieuChinhs.Add(dieuchinh);
                                                }
                                                else
                                                {
                                                    tonghopdulieu.TienNuocDC = (decimal)yeucauDC.tiennuoc_DC + tonghopdulieu.TienNuocDC;
                                                    tonghopdulieu.TienThueDC = (decimal)yeucauDC.tienthue_DC + tonghopdulieu.TienThueDC;
                                                    tonghopdulieu.TienPhiBVMTDC = (decimal)yeucauDC.tienBVMT_DC + tonghopdulieu.TienPhiBVMTDC;
                                                    tonghopdulieu.TienPhiNTDC = (decimal)yeucauDC.tienNT_DC + tonghopdulieu.TienPhiNTDC;
                                                    tonghopdulieu.ThuePhiNTDC = (decimal)yeucauDC.thueNT_DC + tonghopdulieu.ThuePhiNTDC;
                                                    tonghopdulieu.TongTienDC = (decimal)yeucauDC.tongtien_DC + tonghopdulieu.TongTienDC;
                                                    db.SaveChanges();
                                                }
                                            }
                                            catch
                                            {
                                            }

                                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                            MessageBox.Show(Arr_result[0].ToString().ToUpper() + Arr_result[1].ToString().ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                        MessageBox.Show(result1[0].ToString().ToUpper() + result1[1].ToString().ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                int pNVID = int.Parse(NVID.ToString());
                                db.update_taohoadondieuchinh_giay(hoadon.ID_HD, QDID, pNVID);
                                var hoadonmoi = db.HOADONs.Where(x => x.keys == hoadon.ID_HD).FirstOrDefault();
                                //var Publish = db.PublishedInvoices.Where(x => x.IDHD == hoadon.ID_HD).FirstOrDefault();
                                //Publish.FKEY_DC = hoadonmoi.ID_HD;
                                //db.SaveChanges();

                                //var result = db.Update_dieuchinhhoadongiay(hoadon.ID_HD);
                                string hashKey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                                string[] dsHoaDon = db.HOADONs.Where(x => x.ID_HD == hoadonmoi.keys).Select(x => x.ID_HD.ToString()).ToArray();
                                object[] preseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashKey, Common.username, hoadon.DANHBO, dsHoaDon, "2", "hoa don bi dieu chinh").ToArray();
                                string result1 = preseult[0].ToString().ToUpper();
                                if (result1 == "TRUE")
                                {
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
                                    if (pResult_TH == "TRUE")
                                    {
                                        // update trang thai hd cu
                                        var Publish = db.PublishedInvoices.Where(x => x.IDHD == hoadon.ID_HD).FirstOrDefault();
                                        Publish.FKEY_DC = hoadonmoi.ID_HD;
                                        db.SaveChanges();
                                        // insert hoa don moi
                                        db.update_hoadondieuchinh(yeucauDC.IDHD, hoadonmoi.ID_HD, 0, Publish.IDNhanvienHD, NVID);
                                        //update hoa don
                                        hoadonmoi.trangthai_id = yeucauDC.loaiDC;
                                        db.SaveChanges();
                                        var hoadoncu = db.HOADONs.Where(x => x.ID_HD == hoadonmoi.keys).FirstOrDefault();
                                        hoadoncu.trangthai_id = 2;
                                        db.SaveChanges();
                                        db.PublishedInvoices.Remove(Publish);
                                        db.SaveChanges();
                                        // update yeu cau dieu chinh
                                        yeucauDC.isdaduyet = true;
                                        hoadon.ghichu = "đã điều chỉnh";
                                        yeucauDC.user_update = Common.NVID;
                                        yeucauDC.date_update = DateTime.Now;
                                        db.SaveChanges();
                                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        seachButton.PerformClick();
                                    }
                                    else
                                        MessageBox.Show(Arr_result[0].ToString().ToUpper() + Arr_result[1].ToString().ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    MessageBox.Show(result1[0].ToString().ToUpper() + result1[1].ToString().ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                            MessageBox.Show("Có lỗi xảy ra trong quá trình xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
                MessageBox.Show("Hệ thống đang phát hành hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void excelButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "nvlap", "date_create", "trangthaihoadon",  "hoten_KH",  "madanhbo", "SO_QD", "kyghi", "SO_HD", "maLT",
                                       "m3tieuthu","m3_DC", "tongtien_BD", "tienthue_DC", "tiennuoc_DC", "tienBVMT_DC","tongtien_DC", "tongtien_PT"};

                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //TODO
            //this.Close();

            //string hashKey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
            //ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
            ////string[] dsHoaDoncu = db.HOADONs.Where(x => x.ID_HD == 13782065).Select(x => x.ID_HD.ToString()).ToArray();
            ////object[] preseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashKey, Common.username, "16062017809", dsHoaDoncu, "2", "hoa don bi dieu chinh").ToArray();
            ////string result1 = preseult[0].ToString().ToUpper();
            //////if (result1 == "TRUE")
            //////{
            //var hoadonmoi = db.HOADONs.Where(x => x.ID_HD == 13809267).FirstOrDefault();
            //var pDMky = db.DM_KYGHI.Where(x => x.ID_kyghi == "202402").FirstOrDefault();
            //string pfilename = "DSHOADON_" + hoadonmoi.nam.ToString() + "_" + pDMky.thang.ToString() + "_"
            //    + hoadonmoi.DOT_ID.ToString() + "_" + hoadonmoi.DANHBO + "_" + hoadonmoi.ID_HD.ToString() + "_DC";

            //string[] pFileInfo = { pDMky.nam.ToString(), pDMky.thang.ToString(), hoadonmoi.DOT_ID.ToString(), pfilename };
            //string pathXml = @"C:\VNPTDATA\" + pfilename + ".xml";
            //string pathZlip = @"C:\VNPTDATA\" + pfilename + ".zip";
            //string xmlData = db.getXMLThuHo_DieuChinh(hoadonmoi.ID_HD).FirstOrDefault().ToString();
            //deleteFile(pathXml);
            //deleteFile(pathZlip);
            //SaveFile(xmlData, pfilename + ".xml", "C:\\VNPTDATA");
            //ZipFile_Inv(pathXml, pathZlip);
            //byte[] pData = getByteData(pathZlip);
            //string[] pDeleteInfo = { "", "" };
            //object[] Arr_result = tdc.UploadInvoice("WASS01", hashKey, pData, pFileInfo.ToArray(), "");
            //string pResult_TH = Arr_result[0].ToString().ToUpper();
            ////}
            ////else
            ////    MessageBox.Show(result1[0].ToString().ToUpper() + result1[1].ToString().ToUpper());
            //var hoadon = db.HOADONs.Where(x => x.kyghi == "202209" && x.soNK == -1).ToList();
            //var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
            //foreach (var item in hoadon)
            //{
            //    bs78.BusinessService bs = new bs78.BusinessService();
            //    bs.UnConfirmPaymentFkey(item.ID_HD.ToString(), acc.acc_service, acc.pass_service);
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var QDID = decimal.Parse(dataGridView1.SelectedRows[0].Cells[QDIDColumn.Name].Value.ToString());
            var yeucauDC = db.YEUCAU_DIEUCHINH.Where(x => x.QD_ID == QDID).FirstOrDefault();
            var publish = db.getDSHoaDon_KH(yeucauDC.IDKH).Where(x => x.ID_HD == yeucauDC.IDHD).FirstOrDefault();
            if (yeucauDC.isdaduyet == true)
                MessageBox.Show("Hóa đơn đã thanh toán hoặc đã điều chỉnh hóa đơn điện tử, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có xác nhận xóa điều chỉnh hóa đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    yeucauDC.trangthai = 1;
                    yeucauDC.user_update = Common.NVID;
                    yeucauDC.date_update = DateTime.Now;
                    db.SaveChanges();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    seachButton.PerformClick();
                }
            }
        }

        private void StringParserToInv(string result)
        {
            string[] patterns;
            string pattern, Serialno;
            //Lấy phần parrten
            patterns = result.Split(';');
            if (patterns.Length > 0)
            {
                //Lấy phần Serialno
                pattern = patterns[0];
                pattern = pattern.Substring(3, pattern.Length - 3);
                //Serialnos = patterns[1].Split('-');

                //Xử lý tách khóa key và số hóa đơn
                //int index = patterns[1].IndexOf(";");
                Serialno = patterns[1];
                string Data = patterns[2];
                ImportInvoices(pattern, Serialno, Data);
            }
            else
            {
                HOADON_LOG HDLog = new HOADON_LOG();
                HDLog.fkey = result;
                db.HOADON_LOG.Add(HDLog);
                db.SaveChanges();
            }
        }

        private void ImportInvoices(string pattern, string Serialno, string Data)
        {
            this.Cursor = Cursors.WaitCursor;
            string[] KeyInv;
            KeyInv = Data.Split(',');
            if (KeyInv.Length > 0)
            {
                for (int IdexArr = 0; IdexArr <= KeyInv.Length - 1; IdexArr++)
                {
                    string[] DataArr = KeyInv[IdexArr].Split('_');
                    if (DataArr.Length > 0)
                    {
                        var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                        string key = DataArr[0];
                        decimal? id = Convert.ToDecimal(key);
                        string so_hd = DataArr[1];
                        // Update HOADON
                        var hoadon = (from a in db.HOADONs where a.ID_HD == id select a).FirstOrDefault();
                        hoadon.IsInHD = true;
                        hoadon.KY_HIEU_HD = Serialno;
                        hoadon.MAU_HD = pattern;
                        hoadon.SO_HD = decimal.Parse(so_hd).ToString("0000000");
                        hoadon.trangthai_id = 2;
                        hoadon.isKhoDoi = false;
                        hoadon.ArisingDate = DateTime.Now;
                        hoadon.gachno = false;
                        db.SaveChanges();
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            int trangthai = 2;
            if (chkTT.Checked == true)
            {
                if (cboTT.Text == "Đã điều chỉnh")
                    trangthai = 1;
                else
                    trangthai = 0;
            }
            var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59"; ;
            var frm = new UcDSDIEUCHINHHOADON
            {
                tungay = tungay,
                denngay = denngay,
                trangthai = trangthai,
                text = txtTim.Text.Replace(" ", String.Empty)
            };
            new FrmDialog().ShowDialog(frm);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;         
            var frm = new UcQuyetDinhDieuChinh
            {
                QDID = QDID
            };
            new FrmDialog().ShowDialog(frm);
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                QDID = decimal.Parse(dataGridView1[QDIDColumn.Name, e.RowIndex].Value.ToString());
            }
            catch
            {
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                new FrmDialog().ShowDialog(new UcCapNhatQĐieuChinh
                {
                    QDID = QDID
                });
            }
            catch (Exception)
            {
            }
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            try
            {
                int trangthai = 2;
                if (chkTT.Checked == true)
                {
                    if (cboTT.Text == "Đã điều chỉnh")
                        trangthai = 1;
                    else
                        trangthai = 0;
                }
                var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59"; ;
                var dataSource = db.getDanhSachQuyetDinhDieuChinh(trangthai, tungay, denngay, txtTim.Text.Replace(" ", String.Empty)).ToList();
                if (Common.NVID != 820 && Common.NVID != 812 && Common.NVID != 813 && Common.NVID != 833)
                    dataSource = dataSource.Where(x => x.user_create == Common.NVID).ToList();
                if(dataSource.Count > 0)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }    
                dataGridView1.DataSource = dataSource.ToList();
                if(dataSource.Count() > 0)
                {
                    btnUpdate.Enabled = true;
                }
                lblsoluong.Text = "Tiền nước điều chỉnh: " + decimal.Parse(dataSource.Sum(x => x.tiennuoc_DC).ToString()).ToString("N0") 
                    + "       Tiền thuế điều chỉnh: " + decimal.Parse(dataSource.Sum(x => x.tienthue_DC).ToString()).ToString("N0") 
                     + "       Phí BVMT điều chỉnh: " + decimal.Parse(dataSource.Sum(x => x.tienBVMT_DC).ToString()).ToString("N0") 
                      + "       Phí NT điều chỉnh: " + decimal.Parse(dataSource.Sum(x => x.tienNT_DC).ToString()).ToString("N0") 
                       + "       Tiền thuế NT điều chỉnh: " + decimal.Parse(dataSource.Sum(x => x.thueNT_DC).ToString()).ToString("N0") + "\n"
                + "Tổng tiền điều chỉnh: " + decimal.Parse(dataSource.Sum(x => x.tongtien_DC).ToString()).ToString("N0");
                table = ExcelExportHelper.ListToDataTable(dataSource.ToList());
            }
            catch
            {
            }
        }

        private void frQuanlyQD_DieuChinh_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoGenerateColumns = false;
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            //var loaiDC = db.DM_TRANGTHAIHOADON.Where(x => x.trangthai_id == 3 || x.trangthai_id == 4 || x.trangthai_id == 5).ToList();
            //cboDC.DataSource = loaiDC;
            //cboDC.DisplayMember = "Trangthai";
            //cboDC.ValueMember = "trangthai_id";
            //cboDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            string[] trangthai = { "Đã điều chỉnh", "Chưa điều chỉnh" };
            cboTT.DataSource = trangthai;
            var firstDayOfMonth = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
            dateTimePicker1.Value = firstDayOfMonth;
            btnUpdate.Enabled = false;
        }

        private void btnExceldangngan_Click(object sender, EventArgs e)
        {
            var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            var data = db.getTongHopDieuChinhDangNgan(1, tungay, denngay, "").ToList();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "Trangthai", "soluong", "m3tieuthu", "tongtien0VAT", "tienvat", "tienBVMT", "PhiNT",
                                       "TienThueNT","tongtien", "m3_DC", "tiennuoc_DC", "tienthue_DC", "tienBVMT_DC","PhiNT15_DC", "PhiNT20_DC", "tienNT_DC","thueNT_DC", "Tongtien_DC",
                                       "m3PT","tiennuoc_PT", "tienthue_PT", "tienBVMT_PT", "PhiNT15_PT", "PhiNT20_PT", "tienNT_PT", "thueNT_PT","tongtien_PT"};
                var result = ExcelExportHelper.ExportExcel(data, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void excelButton_Click_1(object sender, EventArgs e)
        {
            var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59"; ;
            var data = db.getDanhSachDieuChinhDangNgan(1, tungay, denngay, "").ToList();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = {"Trangthai", "ngay_DC", "madanhbo", "hoten_KH", "ten_kyghi",  "hoten_KH",  "m3tieuthu", "tongtien0VAT", "tienvat", "tienBVMT", "PhiNT15","PhiNT20", "PhiNT",
                                       "TienThueNT","tongtien", "m3_DC", "tiennuoc_DC",  "tienthue_DC", "tienBVMT_DC","PhiNT15_DC", "PhiNT20_DC", "tienNT_DC","thueNT_DC", "Tongtien_DC",
                                       "m3PT","tiennuoc_PT", "tienthue_PT", "tienBVMT_PT", "PhiNT15_PT", "PhiNT20_PT", "tienNT_PT", "thueNT_PT","tongtien_PT"};
                var result = ExcelExportHelper.ExportExcel(data, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcelTheoQuan_Click(object sender, EventArgs e)
        {
            var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd") + " 23:59:59"; ;
            var data = db.getTongHopDieuChinhTheoQuan(1, tungay, denngay, "").ToList();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "tenQuan", "Trangthai", "Loai", "soluong", "m3_DC", "tiennuoc_DC", "tienthue_DC", "tienBVMT_DC", "tienNT15_DC", "tienNT20_DC", "tienNT_DC", "thueNT_DC", "Tongtien_DC" };
                var result = ExcelExportHelper.ExportExcel(data, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExThanhToan_Click(object sender, EventArgs e)
        {
            var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            var data = db.getDanhSachDieuChinhDangNganEX(tungay, denngay).ToList();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = {"NGAYDANGNGAN_NV","Trangthai", "ngay_DC", "madanhbo", "hoten_KH", "ten_kyghi",  "hoten_KH",  "m3tieuthu", "tongtien0VAT", "tienvat", "tienBVMT","PhiNT15", "PhiNT20", "PhiNT",
                                       "TienThueNT","tongtien", "m3_DC", "tiennuoc_DC",  "tienthue_DC", "tienBVMT_DC","PhiNT15_DC", "PhiNT20_DC", "tienNT_DC","thueNT_DC", "Tongtien_DC",
                                       "m3PT","tiennuoc_PT", "tienthue_PT", "tienBVMT_PT","PhiNT15_PT",  "PhiNT20_PT","tienNT_PT", "thueNT_PT","tongtien_PT"};
                var result = ExcelExportHelper.ExportExcel(data, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    seachButton.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}