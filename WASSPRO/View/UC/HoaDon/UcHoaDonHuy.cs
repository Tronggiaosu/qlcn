using QLCongNo.View.UC.GachNo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcHoaDonHuy : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        List<HOADON> dataHoaDon = new List<HOADON>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 100;
        public UcHoaDonHuy()
        {
            InitializeComponent();

            btnTim.Click += btnTim_Click;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            btnRF.Click += btnRF_Click;
            btnConfirm.Click += btnConfirm_Click;
            txtSoHD.KeyDown += txtTim_KeyDown;
        }

        void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu hiện tại không có để huỷ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult rs = MessageBox.Show("Bạn chắc chắn hủy hóa đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                try
                {
                    decimal IDHD = decimal.Parse(dataGridView1.SelectedRows[0].Cells[IDHDColumn.Name].Value.ToString());
                    var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD && x.trangthai_id != 0).FirstOrDefault();
                    if (hoadon != null)
                    {
                        var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                        var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                        Business.BusinessService bs = new Business.BusinessService();
                        var result = bs.cancelInv(accWS.acc_admin, accWS.pass_admin, IDHD.ToString(), accWS.acc_service, accWS.pass_service);
                        if (result == "OK:" || result == "ERR:2")
                        {
                            string hashKey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                            ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                            string[] dsHoaDoncu = db.HOADONs.Where(x => x.ID_HD == IDHD).Select(x => x.ID_HD.ToString()).ToArray();
                            object[] preseult = tdc.CapNhatTrangThaiHoaDon("WASS01", hashKey, Common.username, hoadon.DANHBO, dsHoaDoncu, "2", "hoa don huy").ToArray();
                            hoadon.trangthai_id = 2;
                            hoadon.date_update = DateTime.Now;
                            hoadon.user_update = NVLap.nv_id;
                            var published = db.PublishedInvoices.Where(x => x.KEY == hoadon.ID_HD.ToString()).FirstOrDefault();
                            //published.STATUS = "2";
                            published.GACH_NO = "2";
                            db.SaveChanges();
                            var yeucaudieuchinh = db.YEUCAU_DIEUCHINH.Where(x => x.IDHD == hoadon.keys).FirstOrDefault();
                            if (yeucaudieuchinh != null)
                            {
                                yeucaudieuchinh.trangthai = 1;
                                db.SaveChanges();
                            }
                            var hoadondieuchinh = db.HOADONs.Where(x => x.ID_HD == hoadon.keys).FirstOrDefault();
                            if (hoadondieuchinh != null)
                            {
                                hoadondieuchinh.trangthai_id = 1;
                                db.SaveChanges();
                            }
                            MessageBox.Show("Hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            btnTim.PerformClick();
                        }
                        else
                            MessageBox.Show("Có lỗi xáy ra trong quá trình xử lý mã lỗi " + result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Không thể hủy hóa đơn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        void btnRF_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu hiện tại không có để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Common.ExportExcel(dataGridView1);
        }

        void quitButton_Click(object sender, EventArgs e)
        {
         //   this.Close();
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtSoHD.Text;
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
        void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSoHD.Text))
                {
                    if (decimal.TryParse(txtSoHD.Text, out decimal soHDDecimal))
                    {
                        string SOHD = soHDDecimal.ToString("0000000");
                        var hoadon = db.HOADONs.Where(x => x.SO_HD == SOHD &&
                                                      x.MAU_HD == cboMauSo.Text &&
                                                      x.KY_HIEU_HD == cboKyHieu.Text &&
                                                      x.trangthai_id != 0).FirstOrDefault();
                        if (hoadon != null)
                        {
                            var data = db.getDSHoaDon_KH(hoadon.ID_KH)
                                         .Where(x => x.ID_HD == hoadon.ID_HD)
                                         .ToList();
                            if (data.Any())
                            {
                                dataGridView1.DataSource = data;
                            }
                            else
                            {
                                MessageBox.Show("Hóa đơn tìm thấy nhưng không có dữ liệu chi tiết để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dataGridView1.DataSource = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn với thông tin đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dataGridView1.DataSource = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số hóa đơn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoHD.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập số hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frHoaDonHuy_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            cboMauSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboMauSo.DataSource = db.MAU_HD.OrderBy(x => x.ky_hieu_HD).ToList();
            cboMauSo.ValueMember = "mau_HD1";
            // dm ky hieu
            cboKyHieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            string[] kyghieu = { "TD/19E", "TD/20E", "TD/21E" };
            cboKyHieu.DataSource = kyghieu;
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSoHD_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void txtSoHD_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
