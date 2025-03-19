using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.HoaDon
{
    public partial class frDSChuyenNo : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        DataTable table;
        public frDSChuyenNo()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            btnTim.Click += btnTim_Click;
            btnExcel.Click += btnExcel_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnXoa.Click += btnXoa_Click;
            btnGachNo.Click += btnGachNo_Click;

        }

        void btnGachNo_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có thanh toán các hóa đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == rs)
            {
                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                int pNVID = int.Parse(Common.NVID.ToString());
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                    var thu = checks.Value;
                    if (Convert.ToBoolean(thu) == true)
                    {
                        decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                        var hoadonkhodoi = db.HOADON_KHODOI.Where(x => x.ID_HD == IDHD && x.TRANGTHAI == false).FirstOrDefault();
                        var publish = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
                        if (hoadonkhodoi != null)
                        {
                            hoadonkhodoi.NGUOITHANHTOAN = txtNVThu.Text;
                            hoadonkhodoi.NGAYTHANHTOAN = dtpNgayTT.Value;
                            db.SaveChanges();
                            publish.GACH_NO = "1";
                            db.SaveChanges();
                            Business.BusinessService bs = new Business.BusinessService();
                            var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
                            string result = bs.confirmPaymentFkey(IDHD.ToString(), acc.acc_service, acc.pass_service).ToString();
                        }
                    }
                }
            }
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa trạng thái của khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == rs)
            {
                string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                int pNVID = int.Parse(Common.NVID.ToString());
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                    var thu = checks.Value;
                    if (Convert.ToBoolean(thu) == true)
                    {
                        decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                        var hoadonkd = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                        string[] dsHoaDon = db.HOADONs.Where(x => x.ID_HD == IDHD).Select(x => x.ID_HD.ToString()).ToArray();
                        object[] reseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashkey, Common.username, hoadonkd.DANHBO, dsHoaDon, "1","").ToArray();
                        string result1 = reseult[0].ToString().ToUpper();
                        if (result1 == "TRUE")
                        {

                            var hoadonkhodoi = db.HOADON_KHODOI.Where(x => x.ID_HD == IDHD && x.TRANGTHAI == false).FirstOrDefault();
                            var publish = db.PublishedInvoices.Where(x => x.IDHD == IDHD).FirstOrDefault();
                            var phoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            if (phoadon.tienuoc_dc < 0)
                            {
                                phoadon.tienphi_dc = phoadon.tienphi_dc * -1;
                                phoadon.tienuoc_dc = phoadon.tienuoc_dc * -1;
                                phoadon.tienthue_dc = phoadon.tienthue_dc * -1;
                            }
                            hoadonkhodoi.TRANGTHAI = true;
                            hoadonkhodoi.NGAYTAO = DateTime.Now;
                            hoadonkhodoi.NGUOICHUYEN = pNVID;
                            phoadon.trangthai_id = 1;
                            db.SaveChanges();
                            publish.STATUS = "0";
                            db.SaveChanges();
                        }
                        else
                            MessageBox.Show("Có lỗi xảy ra, mã lỗi: " + reseult[0].ToString().ToUpper() + "; " + reseult[1].ToString().ToUpper());
                        
                    }
                }
                MessageBox.Show("Cập nhật thành công!");
                btnTim.PerformClick();
            }
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (chkNgaychuyenno.Checked == false)
                MessageBox.Show("Chưa chọn ngày chuyển nợ!");
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn cập nhật ngày chuyển nợ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == rs)
                {
                int pNVID = int.Parse(Common.NVID.ToString());
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                    var thu = checks.Value;
                    if (Convert.ToBoolean(thu) == true)
                    {
                        decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                        var hoadonkhodoi = db.HOADON_KHODOI.Where(x => x.ID_HD == IDHD && x.TRANGTHAI == false).FirstOrDefault();
                        hoadonkhodoi.NGAYCHUYEN = dtpNgaychuyenNo.Value;
                        hoadonkhodoi.NGUOICHUYEN = pNVID;
                        db.SaveChanges();
                    }
                }
                MessageBox.Show("Cập nhật thành công!");
                btnTim.PerformClick();
            }
            }
        }

        void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "maNV", "ngaythanhtoan", "NVthu", "NGAYCHUYEN", "InvToken", "SOPHATHANH", "kyghi", "TONGTIEN", "DANHBO", "hoten", "ghichu", "tongtien0VAT", "tienvat", "tienBVMT", "PhiNT", "TienThueNT" };

                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!");
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            
            string pTungay = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string pDennngay = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            int NVID = 0;
            var data = db.getDSChuyenNoKhoDoi(pTungay, pDennngay, NVID).ToList();
            if (txtTim.Text != "")
                data = data.Where(x => x.DANHBO.Contains(txtTim.Text)).ToList();
            table = ExcelExportHelper.ListToDataTable(data.OrderByDescending(x=>x.ngaytao).ToList());
            dataGridView1.DataSource = table;
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTim.PerformClick();
                }
            }
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frDSChuyenNo_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpNgaychuyenNo.Format = DateTimePickerFormat.Custom;
            dtpNgaychuyenNo.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dataGridView1.AutoGenerateColumns = false;
        }

        
    }
}
