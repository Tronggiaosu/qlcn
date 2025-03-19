using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.HoaDon;

namespace QLCongNo.GachNo
{
    public partial class frTraCuuHoaDon : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        List<getDanhSachKhachHang_Result> dataHoaDon = new List<getDanhSachKhachHang_Result>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 50;
        public frTraCuuHoaDon()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            dgvKhachHang.RowEnter += dgvKhachHang_RowEnter;
            dgvHoaDon.CellContentClick += dgvHoaDon_CellContentClick;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
        }

        void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var maQuan = cboQuan.SelectedValue.ToString();
                if (maQuan != "0")
                {
                    // dm phuong
                    cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
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
                    cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
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

        void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.RowCount > 0)
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    decimal IDHD = decimal.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[id_hd_dgv2.Name].Value.ToString());
                    if (e.ColumnIndex == 9)
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
                        frViewInv frm = new frViewInv();
                        frm.html = result;
                        frm.ShowDialog();
                    }
                    if (e.ColumnIndex == 10)
                    {
                        var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        Portal.PortalService portal = new Portal.PortalService();
                        var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                        var hoadonloi = db.HOADONs.Where(x => x.ID_KH == hoadon.ID_KH && x.trangthai_id == -22).FirstOrDefault();
                        if (hoadonloi != null)
                            IDHD = hoadonloi.ID_HD;
                        var base64pdf = portal.downloadInvPDFFkeyNoPay(hoadon.ID_HD.ToString(), accWS.acc_service,"123456aA@");
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
                            MessageBox.Show("Lưu thành công!");
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

        void dgvKhachHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhachHang.RowCount > 0)
                {
                    decimal IDKH = decimal.Parse(dgvKhachHang[ID_KH_dgv1.Name, e.RowIndex].Value.ToString());
                    var dsHoadon = db.getDSHoaDon_KH(IDKH).ToList();
                    
                    if (dsHoadon.Count > 0)
                        dgvHoaDon.DataSource = dsHoadon.OrderByDescending(x => x.ngaytao).ToList();
                    else
                        dgvHoaDon.DataSource = null;
                    lblsoluong.Text = "Tổng số tiền nợ: " + string.Format("{0:n0}", dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Select(x => x.tongtien).Sum());
                    lbltongsokyno.Text = "Tổng số kỳ nợ: " + dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Count().ToString();
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

        void btnRF_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            //Common.ExportExcel(dataGridView1);
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        
        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
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

        void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
                MessageBox.Show("Chưa nhập thông tin tìm kiếm!");
            else
            {

                this.Cursor = Cursors.WaitCursor;
                string kyghi = cboKy.SelectedValue.ToString();
                int nam = int.Parse(cboNam.SelectedValue.ToString());
                decimal dot = decimal.Parse(cboDot.SelectedValue.ToString());
                string maPhuong = cboPhuong.SelectedValue.ToString();
                string maQuan = cboQuan.SelectedValue.ToString();
                string strSearch = txtTim.Text;
                var khachhang = db.getDanhSachKhachHang(2, maPhuong, maQuan, "", (strSearch.Replace(" ", String.Empty)).ToUpper()).Distinct().ToList();
                dgvKhachHang.DataSource = khachhang.ToList();
                if (khachhang.Count == 0)
                    dgvHoaDon.DataSource = null;
                this.Cursor = Cursors.Default;
            }
        }

        private void frTraCuuHoaDon_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvHoaDon.AutoGenerateColumns = false;
            // dm ky ghi
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            //dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.OrderBy(x => x.ten_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            cboKy.DataSource = dmKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            // dm nam
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            //dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
            // loai hoa don
            cboloaiHD.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_LOAIHOADON> dmLoaiHD = new List<DM_LOAIHOADON>();
            dmLoaiHD.Add(new DM_LOAIHOADON() { LoaiHD_ID = 0, tenloaiHD = "Tẩt cả" });
            var dataLoaiHD = db.DM_LOAIHOADON.OrderBy(x => x.tenloaiHD).ToList();
            dmLoaiHD.AddRange(dataLoaiHD);
            cboloaiHD.DataSource = dmLoaiHD.ToList();
            cboloaiHD.ValueMember = "LoaiHD_ID";
            cboloaiHD.DisplayMember = "tenloaiHD";
            // loai doi tuong su dung
            cboDTSD.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_DOITUONGSUDUNG> dataDTSD = new List<DM_DOITUONGSUDUNG>();
            dataDTSD.Add(new DM_DOITUONGSUDUNG() { maDT = "0", tenDT = "Tất cả" });
            var dsDT = db.DM_DOITUONGSUDUNG.OrderBy(x => x.tenDT).ToList();
            dataDTSD.AddRange(dsDT);
            cboDTSD.DataSource = dataDTSD.ToList();
            cboDTSD.ValueMember = "maDT";
            cboDTSD.DisplayMember = "tenDT";
            // dm phuong
            cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
            dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
            var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
            dsPhuong.AddRange(dataPhuong);
            cboPhuong.DataSource = dsPhuong.ToList();
            cboPhuong.ValueMember = "maPhuong";
            cboPhuong.DisplayMember = "tenPhuong";
            // dm quan
            cboQuan.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_QUAN> dsQuan = new List<DM_QUAN>();
            dsQuan.Add(new DM_QUAN() { maQuan = "0", tenQuan = "Tất cả" });
            var dataQuan = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
            dsQuan.AddRange(dataQuan);
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            // dot
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
    }
}
