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
    public partial class frQLHoaDonKhoDoi : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public int trangthai;
        public frQLHoaDonKhoDoi()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            btnThoat.Click += btnThoat_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            dataGridView1.CellContentClick += dgvHoadon_CellContentClick;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            btnConfirm.Click += btnConfirm_Click;
        }

        void btnConfirm_Click(object sender, EventArgs e)
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
                MessageBox.Show("Cập nhật thành công!");
                btnTim.PerformClick();
            }
        }
        void chkAll_CheckedChanged(object sender, EventArgs e)
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

        void dgvHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        if (e.ColumnIndex == 11)
                        {
                            Portal.PortalService portal = new Portal.PortalService();
                            var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                            var result = portal.getInvViewFkeyNoPay(IDHD.ToString(), accWS.acc_service, accWS.pass_service);
                            frViewInv frm = new frViewInv();
                            frm.html = result;
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
        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTim.PerformClick();
                }
            }
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable table;
            string pmadanhbo = txtTim.Text;
            if (pmadanhbo != "")
            {
                var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == pmadanhbo).FirstOrDefault();
                if (khachhang != null)
                {
                    var data = db.getDSHoaDon_KH(khachhang.ID_KH).ToList();
                    if (data.Count != 0)
                    {
                        table = ExcelExportHelper.ListToDataTable(data);
                        dataGridView1.DataSource = table;
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[trangthaithanhtoanColumn.Name].Value.ToString() == "Đã thu" || dataGridView1.Rows[i].Cells[trangthaithanhtoanColumn.Name].Value.ToString() == "Hủy"||
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
            }

            this.Cursor = Cursors.Default;
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
            dataGridView1.AutoGenerateColumns = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
        }
    }
}
