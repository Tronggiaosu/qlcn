using Ionic.Zip;
using Microsoft.VisualBasic;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using QLCongNo.View.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcPhatHanhHD : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DateTime dt = DateTime.Now;
        private List<HOADON> danhsach = new List<HOADON>();
        CancellationTokenSource source = new CancellationTokenSource();
        public UcPhatHanhHD()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            seachButton.Click += seachButton_Click;
            bdButton.Click += bdButton_Click;
            excelButton.Click += excelButton_Click;
            this.btnDC.FlatStyle = FlatStyle.Standard;
            this.ptbSendSMS.Click += (sender, e) => SendSMS();
        }

        private void SendSMS()
        {
            try
            {
                var countRow = this.danhsach.Count;
                var currentRow = this.dataGridView1.CurrentRow;

                if (countRow == 0) return;
                if (currentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn số danh bộ muốn gửi tin nhắn SMS", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var currentIndex = currentRow.Index;
                var currentDanhBo = this.dataGridView1.Rows[currentIndex].Cells[0].Value;
                var currentInfo = this.danhsach.FirstOrDefault(x => x.DANHBO  == currentDanhBo as string);

                if (currentInfo != null)
                {
                    var nam = this.cboNam.Text;
                    var thang = this.cboKy.Text;
                    var danhbo = currentInfo.DANHBO;
                    var soHD = currentInfo.sohopdong;
                    var loaiHD = currentInfo.LoaiHD_ID;
                    var hoten = currentInfo.KHACHHANG.hoten_KH;
                    var sdt = currentInfo.KHACHHANG.SDT_KH;
                    var tongtien = string.Format("{0:n0}", currentInfo.tongtien);
                    var thongtin = $"{thang}/{nam}; Tong tien {tongtien}";

                    var type = "SMS_HOADON_MOI";
                    var title = "Hóa đơn mới";
                    var frm = new FrmSMS();
                    frm.Type = type;
                    frm.Title = title;
                    frm.LoaiHD = loaiHD.ToString();
                    frm.DanhBo = danhbo;
                    frm.HoTen = hoten;
                    frm.SDT = sdt;
                    frm.ThongTin = thongtin;
                    frm.DanhSach = null;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        void btnTH_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:\\VNPTDATA"))
            { }
            else
            {
                Directory.CreateDirectory("C:\\VNPTDATA");
            } 
            ZipFile_Inv();
            MessageBox.Show("ok");
                //ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                //string hashKey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                //string nam = int.Parse(cboNam.SelectedValue.ToString() + 2000).ToString();
                //string kyghi = cboKy.SelectedValue.ToString();
                //string dot = cboDot.SelectedValue.ToString();
                //string filename = "DS_HOA_DON_" + nam + kyghi + dot;
                //string[] s = { nam, kyghi, dot, filename };
          
        }
        public void setFileZip()
        {
            string sZipFile = @"C:\DSHOADON_2018_2_3.zip";
            FileInfo fInfo = new FileInfo(sZipFile);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream("", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            byte[] pFileData = br.ReadBytes(System.Convert.ToInt32(numBytes));
            br.Close();
            fStream.Close();
        }
        public void ZipFile_Inv()
        {
            string sXMLFile = @"C:\\VNPTDATA\thuho.xml";
            string sZIPFile = @"C:\\VNPTDATA\thuhoTDC.zip";
            ZipFile zip = new ZipFile();
            zip.AddFile(sXMLFile, "");
            zip.Save(sZIPFile);
        }

        void excelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Common.ExportExcel(dataGridView1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

         void bdButton_Click(object sender, EventArgs e)
          {
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.EndEdit();
                    var countChecked = dataGridView1.Rows.Cast<DataGridViewRow>()
                                       .Count(r => !r.IsNewRow && r.Cells[chkColumn.Name].Value != null && (bool)r.Cells[chkColumn.Name].Value);
                    var content = countChecked == 0 ? "tất cả" : $"{countChecked}";
                    decimal A = decimal.Parse(cboDot.SelectedValue.ToString());
                    decimal B = decimal.Parse(cboNam.SelectedValue.ToString());
                    int C = int.Parse(cboKy.SelectedValue.ToString());

                    DialogResult rs = MessageBox.Show($"Bạn có muốn phát hành {content} hóa đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        var listHD = new List<decimal>();
                        foreach (DataGridViewRow r in dataGridView1.Rows)
                        {
                            var checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                            var isTicked = checks.Value;
                            if (Convert.ToBoolean(isTicked) == true)
                            {
                                var IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                                listHD.Add(IDHD);
                            }
                        }

                        var dsIDHD = string.Join(",", listHD);
                        decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
                        decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
                        int kyghi = int.Parse(cboKy.SelectedValue.ToString());
                        string pkyghi = cboKy.SelectedValue.ToString();
                        //var NVLap = db.NGUOIDUNGs.Where(x => x.nv_id == Common.NVID).FirstOrDefault();
                        var soluongPH = db.HOADONs.Where(x => x.DOT_ID == dotid
                                          && x.kyghi == pkyghi
                                          && x.trangthai_id == 1
                                          && x.DaPhatHanh == false
                                          && (listHD.Count() == 0 ? 1 == 1 : listHD.Contains(x.ID_HD))).ToList().Count();
                        
                        bdButton.Enabled = false;
                        excelButton.Enabled = false;
                        quitButton.Enabled = false;
                        int soluongHD = soluongPH;
                        int soluongPhathanh = soluongPH;
                        int i = 0;
                        int soluongPro = soluongPH;
                        var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
                        try
                        {
                            var xml = db.sp_xmlUpdateCus(cboKy.SelectedValue.ToString(), dotid).FirstOrDefault().ToString();
                            pb78.PublishService pb = new pb78.PublishService();
                            pb.UpdateCus(xml, "capnuocthuducservice", "Einv@oi@vn#pt20", 0);
                        }
                        catch
                        {

                        }
                        while (soluongHD > 0)
                        {
                            MessageBox.Show("1");
                            pb78.PublishService pb = new pb78.PublishService();
                            string xml = db.sp_xmlPublishInv(kyghi, 2019, dotid).FirstOrDefault().ToString();
                            var thongbao = db.MAU_HD.FirstOrDefault();
                            pb.Timeout = 180000;
                            var result = pb.ImportAndPublishInv("capnuocthuducadmin", acc.pass_admin, xml, "capnuocthuducservice", "Einv@oi@vn#pt20", thongbao.mau_HD1, thongbao.ky_hieu_HD, 0);
                            MessageBox.Show(result);
                            if (result.Substring(0, 2) == "OK")
                            {
                                this.Cursor = Cursors.WaitCursor;
                                if (soluongHD < 300)
                                    i = i + soluongHD;
                                else
                                    i = i + 300;
                                StringParserToInv(result);
                                soluongHD = soluongHD - 300;
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                switch (result)
                                {
                                    case "ERR:1":
                                        MessageBox.Show("Tài khoản đăng nhập sai hoặc không có quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;

                                    case "ERR:2":
                                        MessageBox.Show("Hóa đơn cần điều chỉnh không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    case "ERR:3":
                                        MessageBox.Show("Xml đầu vào không đúng quy định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    case "ERR:5":
                                        MessageBox.Show("Không phát hành được hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    case "ERR:13":
                                        var hoadon = db.HOADONs.Where(x => x.DOT_ID == dotid
                                                          && x.kyghi == pkyghi
                                                          && x.trangthai_id == 1
                                                          && x.DaPhatHanh == false).OrderBy(x => x.SOPHATHANH).Take(400).ToList();
                                        foreach (var item in hoadon)
                                        {
                                            portal78.PortalService pt = new portal78.PortalService();
                                            var xmlInvocie = pt.listInvByCusFkey(item.ID_HD.ToString(), DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), acc.acc_service, "Einv@oi@vn#pt20").ToString();
                                            if (xmlInvocie != "<Data></Data>")
                                            {
                                                var rootElement = XElement.Parse(xmlInvocie.Replace("<Data>", "").Replace("</Data>", ""));
                                                var soHD = rootElement.Element("invNum").Value;
                                                if (soHD != null)
                                                {
                                                    var objHoadon = db.HOADONs.Where(x => x.ID_HD == item.ID_HD && x.DaPhatHanh == false).FirstOrDefault();
                                                    if (objHoadon != null)
                                                    {
                                                        objHoadon.DaPhatHanh = true;
                                                        objHoadon.ArisingDate = DateTime.Now;
                                                        objHoadon.SO_HD = int.Parse(soHD).ToString();
                                                        db.SaveChanges();
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "ERR:6":
                                        MessageBox.Show("Dãy hóa đơn cũ đã hết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    default:
                                        break;
                                }
                                HOADON_LOG HDLog = new HOADON_LOG();
                                HDLog.fkey = result + "_" + DateTime.Now.ToString() + "_" + xml + "_" + Common.NVID.ToString();
                                db.HOADON_LOG.Add(HDLog);
                                db.SaveChanges();
                                seachButton.PerformClick();
                                bdButton.Enabled = true;
                                excelButton.Enabled = true;
                                quitButton.Enabled = true;
                                seachButton.PerformClick();
                                dataGridView1.Visible = true; ;
                                bdButton.Enabled = false;
                                break;
                            }
                        }
                        MessageBox.Show("Phát hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        seachButton.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StringParserToInv(string result)
        {
            try
            {
                string[] patterns;
                string pattern, Serialno;
                var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                //Lấy phần parrten
                patterns = result.Split(';');
                if (patterns.Length > 0)
                {
                    //Lấy phần Serialno
                    pattern = patterns[0];
                    pattern = pattern.Substring(3, pattern.Length - 3);
                    //Serialnos = patterns[1].Split('-');

                    //Xử lý tách khóa key và số hóa đơn
                    int index = patterns[1].IndexOf("-");
                    Serialno = patterns[1].Substring(0, index);
                    string Data = patterns[1].Substring(index + 1);
                    HOADON_LOG HDLog = new HOADON_LOG();
                    HDLog.patterns = pattern;
                    HDLog.Serialno = Serialno;
                    HDLog.fkey = Data;
                    db.HOADON_LOG.Add(HDLog);
                    db.SaveChanges();
                    decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
                    decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
                    string kyghi = cboKy.SelectedValue.ToString();
                    db.sp_updateHoaDon(Data, Serialno, pattern, NVLap.nv_id, kyghi, dotid, namid);
                    //ImportInvoices(pattern, Serialno, Data);
                }
                else
                {
                    HOADON_LOG HDLog = new HOADON_LOG();
                    HDLog.fkey = result;
                    db.SaveChanges();
                }
            }
            catch { }
        }
        private void ImportInvoices(string pattern, string Serialno, string Data)
        {
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
                        hoadon.trangthai_id = 1;
                        hoadon.isKhoDoi = false;
                        hoadon.ArisingDate = DateTime.Now;
                        hoadon.user_create = NVLap.nv_id;
                        hoadon.date_create = DateTime.Now;
                        hoadon.gachno = false;
                        db.SaveChanges();

                    }
                }
            }
        }

        void seachButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
                int nam = int.Parse(cboNam.Text);
                string thang = cboKy.Text;
                string result = nam.ToString() + thang;
                var danhbo = this.txtDanhBo.Text;
                var listDB = new List<string>();
                var containsInvalidChars = Regex.IsMatch(danhbo, @"[^0-9,\s]");

                if (containsInvalidChars)
                {
                    MessageBox.Show("Nội dung Số danh bộ chưa chuẩn. Hãy nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetData();
                    this.Cursor = Cursors.Default;
                    return;
                }

                if (danhbo.Contains(","))
                {
                    var item = danhbo.Split(',');
                    foreach (var db in item)
                        listDB.Add(db.Trim());
                }
                else listDB.Add(danhbo);

                var dataHD = db.HOADONs.Where(x => x.trangthai_id == 1
                                                && x.DOT_ID == dotid
                                                && x.nam == nam
                                                && x.kyghi == result
                                                && x.DaPhatHanh == true
                                                && (listDB.Count() == 0 ? 1 == 1 : listDB.Contains(x.DANHBO))).ToList();

                var chitietHD = (from a in db.CHITIET_HD
                                 from x in db.HOADONs
                                 where a.ID_HD == x.ID_HD && x.ID_KH == a.ID_KH
                                 where x.trangthai_id == 1
                                    && x.DOT_ID == dotid
                                    && x.nam == nam
                                    && x.kyghi == result
                                    && x.DaPhatHanh == true
                                    && (listDB.Count() == 0 ? 1 == 1 : listDB.Contains(x.DANHBO))
                                 select a).ToList().Count();

                if (dataHD.Count() == 0)
                {
                    ResetData();
                    MessageBox.Show("Tháng này đã được phát hành hóa đơn hoặc không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
                    
                else if (chitietHD == 0)
                {
                    ResetData();
                    MessageBox.Show("Dữ liệu chi tiết hóa đơn không tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
                else
                {
                    bdButton.Enabled = true;
                    if (dataHD.Count > 0)
                    {
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    dataGridView1.DataSource = dataHD.OrderBy(x => x.MaLT).ToList();
                    txtsoHD.Text = string.Format("{0:n0}", dataHD.Count());
                    txttiennuoc.Text = string.Format("{0:n0}", dataHD.Sum(z => z.tongtien0VAT));
                    txtTienBVMT.Text = string.Format("{0:n0}", dataHD.Sum(z => z.PhiBVMTCu));
                    txtPhiNT25.Text = string.Format("{0:n0}", dataHD.Sum(z => z.PhiNT));
                    txtThueGTGT.Text = string.Format("{0:n0}", dataHD.Sum(z => z.tienvat));
                    txtTongTien.Text = string.Format("{0:n0}", dataHD.Sum(z => z.tongtien));
                    txtLNTT.Text = string.Format("{0:n0}", dataHD.Sum(z => z.m3tieuthu));
                    lblTongtien.Text = "Số lượng: " + string.Format("{0:n0}", dataHD.Count()) + "  |  Tiền nước: " + string.Format("{0:n0}", dataHD.Sum(z => z.tongtien0VAT)) +
                        "  |  Tiền thuế GTGT: " + string.Format("{0:n0}", dataHD.Sum(z => z.tienvat)) + "  |  Tiền BVMT: " + string.Format("{0:n0}", dataHD.Sum(z => z.tienBVMT)) +
                        "  |  Tổng tiền: " + string.Format("{0:n0}", dataHD.Sum(z => z.tongtien));
                    this.danhsach = dataHD;
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                ResetData();
                MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ResetData()
        {
            dataGridView1.DataSource = null;
            lblTongtien.Text = "Tổng số:";
            txtsoHD.Text = null;
            txtLNTT.Text = null;
            txttiennuoc.Text = null;
            txtThueGTGT.Text = null;
            txtPhiNT25.Text = null;
            txtTienBVMT.Text = null;
            txtTongTien.Text = null;
        }

        void quitButton_Click(object sender, EventArgs e)
        {
         //   this.Close();
        }

        private void frPhatHanhHD_Load(object sender, EventArgs e)
        {
            try
            {
                var year = DateTime.Now.ToString("YYYY");
                var month = DateTime.Now.ToString("MM");

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoGenerateColumns = false;
                // dm mau so, ky hieu hoa don
                var dataMauHD = db.MAU_HD.Where(x => x.Active == true).ToList();
                cboMauHD.DataSource = dataMauHD.ToList();
                cboMauHD.ValueMember = "mau_HD1";
                cboKH.DataSource = dataMauHD.ToList();
                cboKH.ValueMember = "ky_hieu_HD";

                //// dm mau HD
                //List<MAU_HD> dsMau = new List<MAU_HD>();
                //dsMau.Add(new MAU_HD { mau_HD1 = "1/003", ky_hieu_HD = "K24TTD" });
                //dsMau.Add(new MAU_HD { mau_HD1 = "1/003", ky_hieu_HD = "K23TTD" });
                //dsMau.Add(new MAU_HD { mau_HD1 = "1/002", ky_hieu_HD = "K23TTD" });
                //dsMau.Add(new MAU_HD { mau_HD1 = "1/001", ky_hieu_HD = "K22TTD" });
                //dsMau.Add(new MAU_HD { mau_HD1 = "01GTKT0/003", ky_hieu_HD = "TD/22E" });
                //dsMau.Add(new MAU_HD { mau_HD1 = "01GTKT0/002", ky_hieu_HD = "TD/21E" });
                //cboMauHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                //cboMauHD.DataSource = dsMau;
                //cboMauHD.ValueMember = "mau_HD1";
                //// dm ky hieu
                //cboKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                //cboKH.DataSource = dsMau;
                //cboKH.ValueMember = "ky_hieu_HD";
                //cboKH.DisplayMember = "ky_hieu_HD";

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

                cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                List<DM_NAM> dmNam = new List<DM_NAM>();
                var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
                dmNam.AddRange(dataNam);
                cboNam.DataSource = dmNam.OrderByDescending(x => x.NAM).ToList();
                cboNam.ValueMember = "NAM_ID";
                cboNam.DisplayMember = "NAM";
                // dm dot
                cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                List<DM_DOT> dmDot = new List<DM_DOT>();
                //dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
                var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
                dmDot.AddRange(dataDot);
                cboDot.DataSource = dmDot.ToList();
                cboDot.ValueMember = "DOT_ID";
                cboDot.DisplayMember = "TENDOT";
                bdButton.Enabled = false;

                if (dataNam.Count > 0)
                {
                    foreach (var item in dataNam)
                    {
                        if (item.NAM == year)
                        {
                            cboNam.SelectedItem = item;
                            break;
                        }
                    }
                }

                if (dmKyghi.Count > 0)
                {
                    foreach (var item in dmKyghi)
                    {
                        if (item.ten_kyghi == month)
                        {
                            cboKy.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        private void btnDC_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnDC.Text == "Khóa điều chỉnh hóa đơn")
                {
                    var nguoidung = db.NGUOIDUNGs.Where(x => x.nv_id == 819).FirstOrDefault();
                    nguoidung.isLock = true;
                    db.SaveChanges();
                    btnDC.Text = "Mở điều chỉnh hóa đơn";
                }
                if (btnDC.Text == "Mở điều chỉnh hóa đơn")
                {
                    var nguoidung = db.NGUOIDUNGs.Where(x => x.nv_id == 819).FirstOrDefault();
                    nguoidung.isLock = false;
                    db.SaveChanges();
                    btnDC.Text = "Khóa điều chỉnh hóa đơn";

                }
            }
            catch { }
        }
    }
}
