using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcQLHoaDonKhoDoi : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public int trangthai;

        public UcQLHoaDonKhoDoi()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            btnThoat.Click += btnThoat_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            dataGridView1.CellContentClick += dgvHoadon_CellContentClick;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            btnConfirm.Click += btnConfirm_Click;
            this.dataGridView1.DataError += dataGridView1_DataError;
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "thangColumn")
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
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn chuyển trạng thái của khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == rs)
            {
                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Cells[trangthaithanhtoanColumn.Name].Value.ToString() != "Đã thu" || r.Cells[trangthaiHDColumn.Name].Value.ToString() != "Hủy")
                    {
                        DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[checksColumn.Name];
                        var thu = checks.Value;
                        if (Convert.ToBoolean(thu) == true)
                        {
                            var IDHD = decimal.Parse(dataGridView1[ID_HDColumn2.Name, r.Index].Value.ToString());
                            var hoadonKD = db.HOADON_KHODOI.Where(x => x.ID_HD == IDHD && x.TRANGTHAI == false).FirstOrDefault();
                            if (hoadonKD == null)
                            {
                                var hoadonkd = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                                string[] dsHoaDon = db.HOADONs.Where(x => x.ID_HD == IDHD).Select(x => x.ID_HD.ToString()).ToArray();
                                var hoadon = db.HOADON_KHODOI.Where(x => x.ID_HD == IDHD && x.TRANGTHAI == false).FirstOrDefault();
                                object[] reseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashkey, Common.username, hoadonkd.DANHBO, dsHoaDon, "13", txtghichu.Text).ToArray();
                                string result1 = reseult[0].ToString().ToUpper();
                                if (hoadon == null && result1 == "TRUE")
                                {
                                    if (hoadonkd.trangthai_id == 3)
                                    {
                                        hoadonkd.tienphi_dc = hoadonkd.tienphi_dc * -1;
                                        hoadonkd.tienuoc_dc = hoadonkd.tienuoc_dc * -1;
                                        hoadonkd.tienthue_dc = hoadonkd.tienthue_dc * -1;
                                    }
                                    int pNVID = int.Parse(Common.NVID.ToString());
                                    HOADON_KHODOI nkd = new HOADON_KHODOI();
                                    nkd.ID_HD = hoadonkd.ID_HD;
                                    nkd.ID_KH = hoadonkd.ID_KH;
                                    nkd.NGAYCHUYEN = dateTimePicker1.Value;
                                    nkd.NGUOICHUYEN = pNVID;
                                    nkd.TONGTIEN = hoadonkd.tongtien;
                                    nkd.TRANGTHAI = false;
                                    nkd.NGAYTAO = DateTime.Now;
                                    nkd.GHICHU = txtghichu.Text;
                                    db.HOADON_KHODOI.Add(nkd);
                                    db.SaveChanges();
                                    var publish = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
                                    publish.STATUS = "2";
                                    hoadonkd.trangthai_id = 13;
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTim.PerformClick();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                CheckedDatagrid();
            }
            else
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Cells[trangthaithanhtoanColumn.Name].Value.ToString() == "Đã thu" || r.Cells[trangthaiHDColumn.Name].Value.ToString() == "Hủy")
                        r.Cells[checksColumn.Name].Value = false;
                }
            }
        }

        private void dgvHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    var senderGrid = (DataGridView)sender;
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        decimal IDHD = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[ID_HDColumn2.Name].Value.ToString());
                        if (e.ColumnIndex == 12)
                        {
                            Portal.PortalService portal = new Portal.PortalService();
                            var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                            var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            var hoadonloi = db.HOADONs.Where(x => x.ID_KH == hoadon.ID_KH && x.trangthai_id == -22).FirstOrDefault();
                            var hoadonsai = db.HOADONs.Where(x => x.ID_HD == IDHD && x.DOT_ID == 1 && x.kyghi == "202302" && x.keys == null).FirstOrDefault();
                            if (hoadonloi != null)
                                IDHD = hoadonloi.ID_HD;
                            var result = portal.getInvViewFkeyNoPay(IDHD.ToString(), accWS.acc_service, "123456aA@");
                            portal78.PortalService p78 = new portal78.PortalService();
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
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch
            {
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
                    btnTim.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //    this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable table;
            string pmadanhbo = txtTim.Text;
            if (string.IsNullOrEmpty(pmadanhbo))
            {
                MessageBox.Show("Chưa nhập mã danh bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (pmadanhbo.Length != 11)
            {
                MessageBox.Show("Mã danh bộ chưa chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == pmadanhbo).FirstOrDefault();
                if (khachhang != null)
                {
                    var data = db.getDSHoaDon_KH(khachhang.ID_KH).ToList();
                    if (data.Count != 0)
                    {
                        if (data.Count > 0) 
                        {
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        }
                        table = ExcelExportHelper.ListToDataTable(data);
                        dataGridView1.DataSource = table;
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[trangthaithanhtoanColumn.Name].Value.ToString() == "Đã thu" || dataGridView1.Rows[i].Cells[trangthaithanhtoanColumn.Name].Value.ToString() == "Hủy" ||
                                dataGridView1.Rows[i].Cells[trangthaithanhtoanColumn.Name].Value.ToString() == "Khó đòi")
                            {
                                dataGridView1.Rows[i].ReadOnly = true;
                                dataGridView1.Rows[i].Cells[checksColumn.Name].Value = false;
                            }
                        }
                        chkAll.Checked = true;
                        CheckedDatagrid();
                        lbltongno.Text = "Số lượng: " + data.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy").Count().ToString()
                            + "          Tổng số tiền nợ: " + string.Format("{0:n0}", data.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy").Select(x => x.tongtien).Sum());
                    }
                    else
                        dataGridView1.DataSource = null;
                }
                else
                    dataGridView1.DataSource = null;
                this.Cursor = Cursors.Default;
            }
        }

        private void CheckedDatagrid()
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                r.Cells[checksColumn.Name].Value = true;
                if (r.Cells[trangthaithanhtoanColumn.Name].Value.ToString() == "Đã thu" || r.Cells[trangthaiHDColumn.Name].Value.ToString() == "Hủy")
                    r.Cells[checksColumn.Name].Value = false;
            }
        }

        private void frQLHoaDonKhoDoi_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoGenerateColumns = false;
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void lbltongno_Click(object sender, EventArgs e)
        {

        }
    }
}