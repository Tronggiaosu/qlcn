using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class HuyHDForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public HuyHDForm()
        {
            InitializeComponent();
        }
        private void HuyHDForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadLoTrinh();
            LoadKyGhi();
        }
        private void LoadLoTrinh()
        {
            var lt = from a in db.LOTRINHs orderby a.MaLT select new { full = a.MaLT + " - " + a.TenLT, a.MaLT };
            if (lt != null)
            {
                cboLotrinh.DataSource = lt.ToList();
                cboLotrinh.DisplayMember = "full";
                cboLotrinh.ValueMember = "maLT";
            }
        }
        private void LoadKyGhi()
        {
            var kyghi = from k in db.DM_KYGHI orderby k.ID_kyghi descending select k;
            if (kyghi != null)
            {
                cboKyghi.DataSource = kyghi.ToList();
                cboKyghi.DisplayMember = "Ten_Kyghi";
                cboKyghi.ValueMember = "ID_KyGhi";
            }
        }
        private void btnLayDS_Click(object sender, EventArgs e)
        {
            var tthoadon = from k in db.KHACHHANGs
                           join h in db.HOADONs on k.ID_KH equals h.ID_KH
                           join c in db.CHISONUOCs on h.ID_KH equals c.ID_KH
                           where k.maLT == cboLotrinh.SelectedValue.ToString()
                                && c.ID_kyghi == cboKyghi.SelectedValue.ToString()
                                && k.trangthai == 0
                                && h.kyghi == cboKyghi.SelectedValue.ToString()
                                && h.tongtien != 0
                                && h.IsInHD == true
                           select new
                           {
                               k.madanhbo,
                               k.ID_KH,
                               k.maDT,
                               k.hoten_KH,
                               k.diachi,
                               c.luongtieuthu,
                               tiennuoc = h.tongtien0VAT + h.tienvat,
                               h.tongtien,
                               h.ID_HD,
                               k.stt_ghi,
                               h.KY_HIEU_HD,
                               h.MAU_HD,
                               h.SO_HD
                           };
            if (txtMadanhbo.Text != "")
                tthoadon = tthoadon.Where(x => x.ID_KH.ToString() == txtMadanhbo.Text || x.madanhbo.Contains(txtMadanhbo.Text));
            dataGridView1.DataSource = tthoadon.OrderBy(x => x.stt_ghi).ToList();
            (this.MdiParent as MainForm).sltoolStripStatusLabel.Visible = true;
            (this.MdiParent as MainForm).sltoolStripStatusLabel.Text = "Số lượng: " + dataGridView1.RowCount;       
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Xác nhận hủy hóa đơn đã phát hành?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;
                this.Cursor = Cursors.WaitCursor;
                decimal idhoadon = decimal.Parse(dataGridView1.SelectedRows[0].Cells[clmIDHD.Name].Value.ToString());
                //Lấy acc, pass của webservice
                var info = (from a in db.TAIKHOAN_SERVICE select a).FirstOrDefault();
                string acc_service = info.acc_service;
                string pass_service = info.pass_service;
                string acc_admin = info.acc_admin;
                string pass_admin = info.pass_admin;
                //Đồng bộ HDĐT
                QLCongNo.Business.BusinessService ws = new Business.BusinessService();
                string result = ws.cancelInv(acc_admin, pass_admin, idhoadon.ToString(), acc_service, pass_service);
                if (result.Substring(0, 2) == "OK")
                    MessageBox.Show("Hủy hóa đơn thành công!");
                else
                {
                    MessageBox.Show("Có lỗi trong quá trình hủy hóa đơn! - " + result);
                    return;
                }
                //Cập nhật PublishInvoice
                var inv = (from a in db.PublishedInvoices where a.KEY == idhoadon.ToString() select a).FirstOrDefault();
                inv.STATUS = "4";
                db.SaveChanges();

                //Insert HOADON_HUY
                HOADON_HUY hd_huy = new HOADON_HUY();
                hd_huy.id_hd = idhoadon;
                hd_huy.id_kh = decimal.Parse(dataGridView1.SelectedRows[0].Cells[clmIDKH.Name].Value.ToString());
                hd_huy.tienbvmt = decimal.Parse(dataGridView1.SelectedRows[0].Cells[tienBVMT.Name].Value.ToString());
                hd_huy.tongtien = decimal.Parse(dataGridView1.SelectedRows[0].Cells[clmTongTien.Name].Value.ToString());
                hd_huy.ngayhuy = DateTime.Now;
                hd_huy.nguoihuy = Common.username;
                db.HOADON_HUY.Add(hd_huy);

                //Xóa CHITIET_HD
                var cthd = from a in db.CHITIET_HD where a.ID_HD == idhoadon select a;
                foreach (CHITIET_HD ct in cthd.ToList())
                    db.CHITIET_HD.Remove(ct);
                db.SaveChanges();

                //Xóa HOADON
                var hd = (from h in db.HOADONs where h.ID_HD == idhoadon select h).FirstOrDefault();
                db.HOADONs.Remove(hd);
                db.SaveChanges();

                //Cập nhật co_id_hd chỉ số nước
                decimal id_kh = decimal.Parse(dataGridView1.SelectedRows[0].Cells[clmIDKH.Name].Value.ToString());
                var csn = (from a in db.CHISONUOCs where a.ID_KH == id_kh && a.ID_kyghi ==  cboKyghi.SelectedValue.ToString() select a).FirstOrDefault();
                csn.co_id_hd = 0;
                db.SaveChanges();
                btnLayDS.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Cursor = Cursors.Default;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboLotrinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnLayDS.PerformClick();
        }
    }
}
