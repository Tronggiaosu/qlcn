using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.DanhMuc;

namespace QLCongNo.GachNo
{
    public partial class frDongBoHDDT : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frDongBoHDDT()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            excelButton.Click += excelButton_Click;
            seachButton.Click += seachButton_Click;
            btnDB.Click += btnDB_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            btnAll.Click += btnAll_Click;
        }

        void btnAll_Click(object sender, EventArgs e)
        {
            string text = txtTim.Text;
            string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
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
                var hoadonsai = db.HOADONs.Where(x => x.ID_HD == item.id_hd && x.DOT_ID == 1 && x.kyghi=="202302").FirstOrDefault();
                if(hoadonsai!= null)
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
            MessageBox.Show("Cập nhật thành công!");
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtTim.Text != "")
                {
                    if (e.KeyCode == Keys.Enter)
                        seachButton.PerformClick();
                }
            }
            catch
            {

            }
        }

        void btnDB_Click(object sender, EventArgs e)
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
                           string s =   bs78.confirmPaymentFkey(item.ID_HD.ToString(), acc.acc_service, acc.pass_service);
                            var dieuchinh = db.HOADONs.Where(x => x.ID_HD == item.keys).FirstOrDefault();
                           if(dieuchinh != null)
                                bs78.confirmPaymentFkey(dieuchinh.ID_HD.ToString(), acc.acc_service, acc.pass_service);
                            var dieuchinhgiam = db.HOADONs.Where(x => x.keys == item.ID_HD).FirstOrDefault();
                            if(dieuchinhgiam != null)
                                bs78.confirmPaymentFkey(dieuchinhgiam.ID_HD.ToString(), acc.acc_service, acc.pass_service);
                        }
                    }
                    MessageBox.Show("Cập nhật thành công!");
                    seachButton.PerformClick();
                }
                else
                    MessageBox.Show("Chưa nhập danh bộ!");
            }
            catch
            {

            }
        }

        void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string text = txtTim.Text;
            string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
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
            dataGridView1.DataSource = dataSource.ToList();
            lblsoluong.Text = "Số lượng: " + string.Format("{0:n0}", dataSource.Count());
            this.Cursor = Cursors.Default;
        }

        void excelButton_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frDongBoHDDT_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dtpdenngay.Format = DateTimePickerFormat.Custom;
            dtpdenngay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            string[] trangthai = { "Đã đồng bộ", "Chưa đồng bộ" };
            cboTT.DataSource = trangthai;
            cboDT.DataSource = db.DM_LOAIHOADON.ToList();
            cboDT.ValueMember = "LoaiHD_ID";
            cboDT.DisplayMember = "tenloaiHD";
        }



    }
}
