using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcDongBoHDDT : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcDongBoHDDT()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            excelButton.Click += excelButton_Click;
            seachButton.Click += seachButton_Click;
            btnDB.Click += btnDB_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            btnAll.Click += btnAll_Click;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để đồng bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string text = txtTim.Text;
            string tungay = dtptungay.Value.ToString("yyyy-MM-dd");
            string dengay = dtpdenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            int trangthai = 2;
            int loaiHD = 0;
            if (chktrangthai.Checked == true)
            {
                if (cboTT.Text == "Đã đồng bộ")
                    trangthai = 1;
                else
                    trangthai = 0;
            }
            if (chkmaDT.Checked == true)
                loaiHD = int.Parse(cboDT.SelectedValue.ToString());
            var dataSource = db.getDSDongBoHDDT(tungay, dengay, trangthai, loaiHD, text).ToList();
            int soluong = dataSource.Count;
            var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
            int soluongHD = dataSource.Count();
            int soluongPhathanh = dataSource.Count();
            int i = 0;
            int soluongPro = dataSource.Count();
            Business.BusinessService pbs = new Business.BusinessService();
            bs78.BusinessService bs78 = new bs78.BusinessService();
            foreach (var item in dataSource)
            {
                var hoadonloi = db.HOADONs.Where(x => x.ID_KH == item.id_kh && x.trangthai_id == -22).FirstOrDefault();
                var hoadonsai = db.HOADONs.Where(x => x.ID_HD == item.id_hd && x.DOT_ID == 1 && x.kyghi == "202302").FirstOrDefault();
                if (hoadonsai != null)
                    bs78.confirmPaymentFkey(hoadonsai.DienGiai, acc.acc_service, acc.pass_service).ToString();
                if (hoadonloi != null)
                    item.id_hd = hoadonloi.ID_HD;
                if (item.MAU_HD != "1/001")
                    pbs.confirmPaymentFkey(item.id_hd.ToString(), acc.acc_service, "123456aA@");
                if (item.MAU_HD == "1/002")
                    bs78.confirmPaymentFkey(item.id_hd.ToString(), acc.acc_service, acc.pass_service).ToString();
                else
                {
                    string sa = bs78.confirmPaymentFkey(item.id_hd.ToString(), acc.acc_service, acc.pass_service).ToString();
                }
            }
            db.Update_dongboHDDT(tungay, dengay, trangthai, loaiHD, text);
            seachButton.PerformClick();
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtTim.Text != "")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        seachButton.PerformClick();
                        this.Cursor = Cursors.Default;
                    }    
                        
                }
            }
            catch
            {
            }
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text != "")
                {
                    var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
                    Business.BusinessService pbs = new Business.BusinessService();
                    bs78.BusinessService bs78 = new bs78.BusinessService();
                    List<DANGNGAN> dsHoadon = new List<DANGNGAN>();
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColum.Name];
                        var thu = checks.Value;
                        if (Convert.ToBoolean(thu) == true)
                        {
                            decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
                            var item = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                            var hoadonloi = db.HOADONs.Where(x => x.ID_KH == item.ID_KH && x.trangthai_id == -22).FirstOrDefault();
                            if (hoadonloi != null)
                                item.ID_HD = hoadonloi.ID_HD;
                            if (item.MAU_HD != "1/001")
                                pbs.confirmPaymentFkey(item.ID_HD.ToString(), acc.acc_service, "123456aA@");
                            string s = bs78.confirmPaymentFkey(item.ID_HD.ToString(), acc.acc_service, acc.pass_service);
                            var dieuchinh = db.HOADONs.Where(x => x.ID_HD == item.keys).FirstOrDefault();
                            if (dieuchinh != null)
                                bs78.confirmPaymentFkey(dieuchinh.ID_HD.ToString(), acc.acc_service, acc.pass_service);
                            var dieuchinhgiam = db.HOADONs.Where(x => x.keys == item.ID_HD).FirstOrDefault();
                            if (dieuchinhgiam != null)
                                bs78.confirmPaymentFkey(dieuchinhgiam.ID_HD.ToString(), acc.acc_service, acc.pass_service);
                        }
                    }
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    seachButton.PerformClick();
                }
                else
                    MessageBox.Show("Chưa có dữ liệu để đồng bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
            }
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string text = txtTim.Text.Trim();
            string tungay = dtptungay.Value.ToString("yyyy-MM-dd");
            string dengay = dtpdenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            int trangthai = 2;
            int loaiHD = 0;
            if (chktrangthai.Checked == true)
            {
                if (cboTT.Text == "Đã đồng bộ")
                    trangthai = 1;
                else
                    trangthai = 0;
            }
            if (chkmaDT.Checked == true)
                loaiHD = int.Parse(cboDT.SelectedValue.ToString());
            var dataSource = db.getDSDongBoHDDT(tungay, dengay, trangthai, loaiHD, text).ToList();
            var listIdHd = dataSource.Select(x => x.id_hd).ToList();
            var hoadonList = db.HOADONs
                .Where(hd => listIdHd.Contains(hd.ID_HD))
                .Select(hd => new { hd.ID_HD, hd.diachihoadon })
                .ToList();
            var finalResult = from data in dataSource
                              join hd in hoadonList on data.id_hd equals hd.ID_HD into hdJoin
                              from hd in hdJoin.DefaultIfEmpty()
                              select new
                              {
                                  data.tongtien,
                                  data.id_hd,
                                  data.hoten_KH,
                                  data.madanhbo,
                                  data.maLT,
                                  data.kyhd,
                                  data.nam,
                                  data.id_kh,
                                  data.MAU_HD,
                                  data.seri,
                                  data.Trangthai,
                                  data.isdongbo,
                                  DiaChiHoaDon = hd?.diachihoadon
                              };
            if (finalResult.Count() > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            dataGridView1.DataSource = finalResult.ToList();
            lblsoluong.Text = "Số lượng: " + string.Format("{0:n0}", finalResult.Count());
            this.Cursor = Cursors.Default;
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Common.ExportExcel(dataGridView1);
            this.Cursor = Cursors.Default;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }

        private void frDongBoHDDT_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = false;
            dtptungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtptungay.CustomFormat = "dd/MM/yyyy";
            dtpdenngay.Format = DateTimePickerFormat.Custom;
            dtpdenngay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            //dtpdenngay.ShowUpDown = true;  
            string[] trangthai = { "Đã đồng bộ", "Chưa đồng bộ" };
            cboTT.DataSource = trangthai;
            cboDT.DataSource = db.DM_LOAIHOADON.ToList();
            cboDT.ValueMember = "LoaiHD_ID";
            cboDT.DisplayMember = "tenloaiHD";
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