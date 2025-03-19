using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.HoaDon
{
    public partial class frHoaDonHuy : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        List<HOADON> dataHoaDon = new List<HOADON>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 100;
        public frHoaDonHuy()
        {
            InitializeComponent();

            btnTim.Click += btnTim_Click;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            btnRF.Click += btnRF_Click;
            btnConfirm.Click += btnConfirm_Click;
            
        }

        void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn chắc chắn hủy hóa đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                //try
                //{

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
                            published.STATUS = "2";
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
                            MessageBox.Show("Hủy thành công!");
                        }
                        else
                            MessageBox.Show("Có lỗi xáy ra trong quá trình xử lý mã lỗi " + result);
                    }
                    else
                        MessageBox.Show("Không thể hủy hóa đơn này!");
                //}
                //catch
                //{

                //}
            }
        }


        void btnRF_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSoHD.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                    btnTim.PerformClick();
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            if (txtSoHD.Text != "")
            {
                string SOHD = decimal.Parse(txtSoHD.Text).ToString("0000000");
                var hoadon = db.HOADONs.Where(x => x.SO_HD == SOHD && x.MAU_HD == cboMauSo.Text && x.KY_HIEU_HD == cboKyHieu.Text  && x.trangthai_id !=0).FirstOrDefault();
                var data = db.getDSHoaDon_KH(hoadon.ID_KH).Where(x => x.ID_HD == hoadon.ID_HD).ToList();
                dataGridView1.DataSource = data.ToList();
            }
            else
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("Chưa nhập số hóa đơn!");
            }
        }

        private void frHoaDonHuy_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            cboMauSo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMauSo.DataSource = db.MAU_HD.OrderBy(x => x.ky_hieu_HD).ToList();
            cboMauSo.ValueMember = "mau_HD1";
            // dm ky hieu
            cboKyHieu.DropDownStyle = ComboBoxStyle.DropDownList;
            string[] kyghieu = { "TD/19E", "TD/20E", "TD/21E" };
            cboKyHieu.DataSource = kyghieu;
        }
    }
}
