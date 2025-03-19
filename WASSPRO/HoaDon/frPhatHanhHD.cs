
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLCongNo.HoaDon
{
    public partial class frPhatHanhHD : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DateTime dt = DateTime.Now;
        CancellationTokenSource source = new CancellationTokenSource();
        public frPhatHanhHD()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            seachButton.Click += seachButton_Click;
            bdButton.Click += bdButton_Click;
            excelButton.Click += excelButton_Click;
            //btnTH.Click+=btnTH_Click;
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
            Common.ExportExcel(dataGridView1);
        }

         void bdButton_Click(object sender, EventArgs e)
          {
              if (dataGridView1.RowCount > 0)
              {
                  DialogResult rs = MessageBox.Show("Bạn có muốn phát hành hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                  if (rs == DialogResult.OK)
                  {
                      decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
                      decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
                      int kyghi = int.Parse( cboKy.SelectedValue.ToString());
                      string pkyghi = cboKy.SelectedValue.ToString();
                      //var NVLap = db.NGUOIDUNGs.Where(x => x.nv_id == Common.NVID).FirstOrDefault();
                      var soluongPH = db.HOADONs.Where(x => x.DOT_ID == dotid && x.kyghi == pkyghi && x.trangthai_id == 1  && x.DaPhatHanh == false ).ToList().Count();
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
                          pb78.PublishService pb = new pb78.PublishService();
                          string xml = db.sp_xmlPublishInv(kyghi,2019, dotid).FirstOrDefault().ToString();
                          var thongbao = db.MAU_HD.FirstOrDefault();
                          pb.Timeout = 180000;
                          var result = pb.ImportAndPublishInv("capnuocthuducadmin", acc.pass_admin, xml, "capnuocthuducservice", "Einv@oi@vn#pt20", thongbao.mau_HD1, thongbao.ky_hieu_HD, 0);
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
                                      MessageBox.Show("Tài khoản đăng nhập sai hoặc không có quyền");
                                      break;

                                  case "ERR:2":
                                      MessageBox.Show("Hóa đơn cần điều chỉnh không tồn tại!");
                                      break;
                                  case "ERR:3":
                                      MessageBox.Show("Xml đầu vào không đúng quy định");
                                      break;
                                  case "ERR:5":
                                      MessageBox.Show("Không phát hành được hóa đơn");
                                      break;
                                  case "ERR:13":
                                      var hoadon = db.HOADONs.Where(x => x.DOT_ID == dotid && x.kyghi == pkyghi && x.trangthai_id == 1 && x.DaPhatHanh == false).OrderBy(x=>x.SOPHATHANH).Take(400).ToList();
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
                                      MessageBox.Show("Dãy hóa đơn cũ đã hết");
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
                      MessageBox.Show("Phát hành thành công!");
                      seachButton.PerformClick();
                    
                  }
              }
        }
        //private void WriteProcess(int i)
        //{
        //    if (!source.Token.IsCancellationRequested)
        //    {
        //        Thread.Sleep(10);
        //        this.Invoke(new Action(() => this.progressBar1.Value = i));
        //    }
        //}
        private void StringParserToInv(string result)
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
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi =( cboKy.SelectedValue.ToString());
            this.Cursor = Cursors.WaitCursor;
            var dataHD = db.HOADONs.Where(x => x.trangthai_id == 1 && x.DOT_ID == dotid && x.kyghi == kyghi && x.DaPhatHanh == false ).ToList();
            var chitietHD = (from a in db.CHITIET_HD
                             from x in db.HOADONs
                             where a.ID_HD == x.ID_HD && x.ID_KH == a.ID_KH 
                             where x.trangthai_id == 1 && x.DOT_ID == dotid  && x.kyghi == kyghi && x.DaPhatHanh == false 
                             select a).ToList().Count();
          
            if (dataHD.Count() == 0)
                MessageBox.Show("Kỳ này đã được phát hành hóa đơn hoặc không có dữ liệu");
            else if (chitietHD == 0)
                MessageBox.Show("Dữ liệu chi tiết hóa đơn không tồn tại trong hệ thống!");
            else
            {
                bdButton.Enabled = true;
                dataGridView1.DataSource = dataHD.OrderBy(x => x.MaLT).ToList();
                txtsoHD.Text = string.Format("{0:n0}", dataHD.Count());
                txttiennuoc.Text = string.Format("{0:n0}", dataHD.Sum(z => z.tongtien0VAT));
                txtTienBVMT.Text = string.Format("{0:n0}", dataHD.Sum(z => z.PhiBVMTCu));
                txtPhiNT25.Text = string.Format("{0:n0}", dataHD.Sum(z => z.PhiNT));
                txtThueGTGT.Text = string.Format("{0:n0}", dataHD.Sum(z => z.tienvat));
                txtTongTien.Text = string.Format("{0:n0}", dataHD.Sum(z => z.tongtien));
                txtLNTT.Text = string.Format("{0:n0}", dataHD.Sum(z => z.m3tieuthu));
                lblTongtien.Text = "Số lượng: " + string.Format("{0:n0}", dataHD.Count()) + " Tiền nước: " + string.Format("{0:n0}", dataHD.Sum(z => z.tongtien0VAT)) +
                    " Tiền thuế GTGT: " + string.Format("{0:n0}", dataHD.Sum(z => z.tienvat)) + " Tiền BVMT: " + string.Format("{0:n0}", dataHD.Sum(z => z.tienBVMT)) +
                    " Tổng tiền: " + string.Format("{0:n0}", dataHD.Sum(z => z.tongtien));
            }
            this.Cursor = Cursors.Default;  
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frPhatHanhHD_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            // dm mau so, ky hieu hoa don
            var dataMauHD = db.MAU_HD.Where(x => x.Active == true).ToList();
            cboMauHD.DataSource = dataMauHD.ToList();
            cboMauHD.ValueMember = "mau_HD1";
            cboKH.DataSource = dataMauHD.ToList();
            cboKH.ValueMember = "ky_hieu_HD";
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
            bdButton.Enabled = false;
        }

        private void btnDC_Click(object sender, EventArgs e)
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
    }
}
