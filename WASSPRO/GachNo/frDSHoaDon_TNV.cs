using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.GachNo
{
    public partial class frDSHoaDon_TNV : Form
    {
        public string tungay, denngay;
        public   int NVID;
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frDSHoaDon_TNV()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            btnTim.Click += btnTim_Click;
            btnDelete.Click += btnDelete_Click;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
        }

        void btnDangNgan_Click(object sender, EventArgs e)
        {
            try
            {
                 DialogResult rs = MessageBox.Show("Xác nhận nhân viên đã nộp đủ số tiền?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                 if (rs == DialogResult.OK)
                 {

                 }
            }
            catch
            {

            }
        }

        void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Cells[chkColumn.Name].Value = true;
                }
            }
            else
            {

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Cells[chkColumn.Name].Value = false;
                }
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult rs = MessageBox.Show("Bạn có xóa thanh toán hóa đơn này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                if (chkReset.Checked == true)
                {
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                        var thu = checks.Value;
                        if (Convert.ToBoolean(thu) == true)
                        {
                            decimal IDHD = decimal.Parse(dataGridView1.SelectedRows[0].Cells[IDHDColumn.Name].Value.ToString());
                            var chungtuHD = db.CHUNGTU_HOADON.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            var dsChungtu = db.CHUNGTU_HOADON.Where(x => x.GIAODICHID == chungtuHD.GIAODICHID).ToList();
                            List<ChungTuLog> dslog = new List<ChungTuLog>();
                            string kyhd = "";
                            foreach (var item in dsChungtu)
                            {
                                if (kyhd == "")
                                    kyhd = (item.HOADON.DM_KYGHI.nam ).ToString() + "/" + item.HOADON.DM_KYGHI.thang;
                                else
                                    kyhd = kyhd + ", " + (item.HOADON.DM_KYGHI.nam ).ToString() + "/" + item.HOADON.DM_KYGHI.thang;
                                var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                                Business.BusinessService bs = new Business.BusinessService();
                                string result = bs.UnConfirmPaymentFkey(item.ID_HD.ToString(), accWS.acc_service, accWS.pass_service);
                                dslog.Add(new ChungTuLog(){id_ct = item.ID_CT, id_hd = item.ID_HD, manv = Common.username, ngaylap = DateTime.Now});
                            }

                            var giaodich = db.GIAODICHes.Where(x => x.GIAODICH_ID == chungtuHD.GIAODICHID).FirstOrDefault();
                            string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                            ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                            string ngaythu = DateTime.Parse(giaodich.DATE_CREATE.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            int tongtien = int.Parse(giaodich.TONGTIEN.ToString());
                            object[] reseult = tdc.ThanhToanHoaDon_HuyGiaoDich("WASS01", hashkey, Common.username, giaodich.DANHBO, chungtuHD.GIAODICHID.ToString(), kyhd, ngaythu, tongtien, "test");
                            db.Database.ExecuteSqlCommand("resetTrangThaiHoaDOn " + giaodich.ID_KH + "," + chungtuHD.ID_CT.ToString());
                            var ds = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtuHD.ID_CT).ToList().Count();
                            if(ds == 0)
                                db.CHUNGTUs.Remove(db.CHUNGTUs.Where(x => x.ID_CT == chungtuHD.ID_CT).FirstOrDefault());
                            giaodich.TRANHTHAI = 1;
                            db.ChungTuLogs.AddRange(dslog);
                            db.SaveChanges();

                        }
                    }
                    MessageBox.Show("Cập nhật thành công!");
                }
                else if (chkNgay.Checked == true)
                {
                    //foreach (DataGridViewRow r in dataGridView1.Rows)
                    //{
                    //    DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
                    //    var check = checks.Value;
                    //    if (Convert.ToBoolean(check) == true)
                    //    {
                    //        decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                    //        var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                    //        hoadon.ngaythanhtoan = dtpBK.Value;
                    //        db.SaveChanges();
                    //    }
                    //}
                    MessageBox.Show("Cập nhật thành công!");
                }
                btnTim.PerformClick();
               
            }
        }

        void btnHuy_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            var dataSource = db.getChiTietQLBiennhan(tungay, denngay, NVID).ToList();
            dataGridView1.DataSource = dataSource.OrderBy(x => x.ngaythanhtoan).ToList();
            txtSLHD.Text = string.Format("{0:n0}", dataSource.Count);
            txtTongtien.Text = string.Format("{0:n0}", dataSource.Sum(x => x.tongtien));
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
