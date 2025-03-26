using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QLCongNo.View.UC.HoaDon;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcTraCuuHoaDon : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private List<getDanhSachKhachHang_Result> dataHoaDon = new List<getDanhSachKhachHang_Result>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 50;

        public UcTraCuuHoaDon()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            dgvKhachHang.RowEnter += dgvKhachHang_RowEnter;
            dgvHoaDon.CellContentClick += dgvHoaDon_CellContentClick;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            this.dgvHoaDon.DataError += dgvHoaDon_DataError;
            this.dgvHoaDon.CellFormatting += dgvHoaDon_CellFormatting;

        }

        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var maQuan = cboQuan.SelectedValue.ToString();
                if (maQuan != "0")
                {
                    // dm phuong
                    cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                    var dataPhuong = db.DM_PHUONG.Where(x => x.maQuan == maQuan).OrderBy(x => x.tenPhuong).ToList();
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
                else
                {
                    cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                    var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
            }
            catch
            {
            }
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.RowCount > 0)
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    decimal IDHD = decimal.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[id_hd_dgv2.Name].Value.ToString());
                    if (e.ColumnIndex == 10)
                    {
                        Portal.PortalService portal = new Portal.PortalService();
                        var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                        var result = portal.getInvViewFkeyNoPay(IDHD.ToString(), accWS.acc_service, "123456aA@");
                        var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        var hoadonloi = db.HOADONs.Where(x => x.ID_KH == hoadon.ID_KH && x.trangthai_id == -22).FirstOrDefault();
                        if (hoadonloi != null)
                            IDHD = hoadonloi.ID_HD;
                        portal78.PortalService p78 = new portal78.PortalService();
                        var hoadonsai = db.HOADONs.Where(x => x.ID_HD == IDHD && x.DOT_ID == 1 && x.kyghi == "202302" && x.keys == null).FirstOrDefault();
                        if (hoadonsai != null)
                            result = p78.getInvViewFkeyNoPay(hoadonsai.DienGiai, "capnuocthuducservice", "Einv@oi@vn#pt20");
                        else if (hoadon.MAU_HD == "1/001" || hoadon.MAU_HD == "1/002" || hoadon.MAU_HD == "1/003")
                            result = p78.getInvViewFkeyNoPay(IDHD.ToString(), "capnuocthuducservice", "Einv@oi@vn#pt20");
                        var frm = new Form();
                        frm.Size = new Size(1200, 800);
                        WebBrowser webBrowser = new WebBrowser();
                        webBrowser.Dock = DockStyle.Fill;
                        webBrowser.DocumentText = result;
                        frm.Controls.Add(webBrowser);
                        frm.ShowDialog();
                    }
                    if (e.ColumnIndex == 11)
                    {
                        var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        Portal.PortalService portal = new Portal.PortalService();
                        var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                        var hoadonloi = db.HOADONs.Where(x => x.ID_KH == hoadon.ID_KH && x.trangthai_id == -22).FirstOrDefault();
                        if (hoadonloi != null)
                            IDHD = hoadonloi.ID_HD;
                        var base64pdf = portal.downloadInvPDFFkeyNoPay(hoadon.ID_HD.ToString(), accWS.acc_service, "123456aA@");
                        portal78.PortalService p78 = new portal78.PortalService();
                        var hoadonsai = db.HOADONs.Where(x => x.ID_HD == IDHD && x.DOT_ID == 1 && x.kyghi == "202302" && x.keys == null).FirstOrDefault();
                        if (hoadonsai != null)
                            base64pdf = p78.downloadInvPDFFkeyNoPay(hoadon.DienGiai, "capnuocthuducservice", "Einv@oi@vn#pt20");
                        else if (hoadon.MAU_HD == "1/001" || hoadon.MAU_HD == "1/002" || hoadon.MAU_HD == "1/003")
                            base64pdf = p78.downloadInvPDFFkeyNoPay(hoadon.ID_HD.ToString(), "capnuocthuducservice", "Einv@oi@vn#pt20");
                        SaveFileDialog save = new SaveFileDialog();
                        save.Filter = "PDF file|.PDF";
                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            byte[] sPDFDecoded = Convert.FromBase64String(base64pdf);
                            //var result = ExcelExportHelper.ExportExcel(table, false, columns);
                            File.WriteAllBytes(save.FileName, sPDFDecoded);
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //var html = portal.convertForStoreFkey(IDHD.ToString(), accWS.acc_service, accWS.pass_service);
                        //SaveFileDialog saveFileDialog = new SaveFileDialog();
                        //saveFileDialog.Filter = "Html files (*.html)|*.html";
                        //saveFileDialog.DefaultExt = "html";
                        //saveFileDialog.ShowDialog();
                        //if (saveFileDialog.FileName != "")
                        //{
                        //    string fileName = saveFileDialog.FileName;
                        //    string path = Path.GetDirectoryName(fileName);
                        //    string filename_with_ext = Path.GetFileName(fileName);
                        //    string filename_without_ext = Path.GetFileNameWithoutExtension(fileName);
                        //    string ext_only = Path.GetExtension(fileName);
                        //    SaveFile(html, filename_without_ext + ".html", path);
                        //    MessageBox.Show("Chuyển đổi lưu trữ thành công!");
                        //}
                    }
                    this.Cursor = Cursors.Default;
                }
            }
        }
        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "kyhd_dgv2")
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

        private void dgvHoaDon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvKhachHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhachHang.RowCount > 0)
                {
                    string kyghiSelected = cboThang.SelectedValue != null ? cboThang.SelectedValue.ToString() : "";
                    string namSelectedStr = cboNam.SelectedValue != null ? cboNam.SelectedValue.ToString() : "";
                    string dotSelectedStr = cboDot.SelectedValue != null ? cboDot.SelectedValue.ToString() : "";

                    decimal IDKH = decimal.Parse(dgvKhachHang[ID_KH_dgv1.Name, e.RowIndex].Value.ToString());
                    var dsHoadon = db.getDSHoaDon_KH(IDKH).ToList();

                    if (namSelectedStr != "0")
                    {
                        int nam = int.Parse(namSelectedStr) + 2000;
                        dsHoadon = dsHoadon.Where(x => x.nam == nam).ToList();
                    }    

                    if(kyghiSelected != "00")
                    {
                        int nam = int.Parse(namSelectedStr) + 2000;
                        string thang = kyghiSelected + "/" + nam.ToString();
                        dsHoadon = dsHoadon.Where(x => x.kyghi == thang).ToList();
                    }    

                    if(dotSelectedStr != "0")
                    {
                        int dot = int.Parse(dotSelectedStr);
                        dsHoadon = dsHoadon.Where(x => x.DOT_ID == dot).ToList();
                    }

                    if (dsHoadon.Count > 0)
                    {
                        dgvHoaDon.DataSource = dsHoadon.OrderByDescending(x => x.ngaytao).ToList();
                    }
                    else
                        dgvHoaDon.DataSource = null;
                    lblsoluong.Text = "Tổng số tiền nợ: " + string.Format("{0:n0}", dsHoadon.Where(x => x.thanhtoan == "Chưa thu").Select(x => x.tongtien).Sum());
                    lbltongsokyno.Text = "Tổng số kỳ nợ: " + dsHoadon.Where(x => x.thanhtoan == "Chưa thu").Count().ToString();
                }
                else
                    dgvHoaDon.DataSource = null;
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình lấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnRF_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Common.ExportExcel(dgvHoaDon);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
                MessageBox.Show("Chưa nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.Cursor = Cursors.WaitCursor;
                string maPhuong = cboPhuong.SelectedValue.ToString();
                string maQuan = cboQuan.SelectedValue.ToString();
                string maDT = cboDTSD.SelectedValue.ToString();
                string strSearch = txtTim.Text.Trim();
                var khachhang = db.getDanhSachKhachHang(2, maQuan, maPhuong, maDT, (strSearch.Replace(" ", String.Empty)).ToUpper()).Distinct().ToList();
                if (khachhang.Count > 0)
                {
                    dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                dgvKhachHang.DataSource = khachhang.ToList();
                if (khachhang.Count == 0)
                    dgvHoaDon.DataSource = null;
                this.Cursor = Cursors.Default;
            }
        }

        private void frTraCuuHoaDon_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.AutoGenerateColumns = false;
            dgvHoaDon.AutoGenerateColumns = false;
            cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "00", ten_kyghi = "Tất cả" });
            for (int i = 1; i <= 12; i++)
            {
                dmKyghi.Add(new DM_KYGHI()
                {
                    ID_kyghi = i.ToString("00"),
                    ten_kyghi = $"{i:00}"
                });
            }
            cboThang.DataSource = dmKyghi;
            cboThang.ValueMember = "ID_kyghi";
            cboThang.DisplayMember = "ten_kyghi";
            // dm nam
            cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
            // loai doi tuong su dung
            cboDTSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_DOITUONGSUDUNG> dataDTSD = new List<DM_DOITUONGSUDUNG>();
            dataDTSD.Add(new DM_DOITUONGSUDUNG() { maDT = "0", tenDT = "Tất cả" });
            var dsDT = db.DM_DOITUONGSUDUNG.OrderBy(x => x.tenDT).ToList();
            dataDTSD.AddRange(dsDT);
            cboDTSD.DataSource = dataDTSD.ToList();
            cboDTSD.ValueMember = "maDT";
            cboDTSD.DisplayMember = "tenDT";
            // dm phuong
            cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
            dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
            var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
            dsPhuong.AddRange(dataPhuong);
            cboPhuong.DataSource = dsPhuong.ToList();
            cboPhuong.ValueMember = "maPhuong";
            cboPhuong.DisplayMember = "tenPhuong";
            // dm quan
            cboQuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_QUAN> dsQuan = new List<DM_QUAN>();
            dsQuan.Add(new DM_QUAN() { maQuan = "0", tenQuan = "Tất cả" });
            var dataQuan = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
            dsQuan.AddRange(dataQuan);
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            // dot
            cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }
    }
}