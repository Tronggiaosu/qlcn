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
    public partial class frTaoHoaDon : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frTaoHoaDon()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = (cboKy.SelectedValue.ToString());
            this.Cursor = Cursors.WaitCursor;
            var dataHD = db.HOADONs.Where(x => x.trangthai_id == 0 && x.DOT_ID == dotid && x.kyghi == kyghi && x.IsInHD == false && x.ischeck == 0).OrderBy(x => x.MaLT).ToList();
            var chitietHD = (from a in db.CHITIET_HD
                             from x in db.HOADONs
                             where a.ID_HD == x.ID_HD && x.ID_KH == a.ID_KH && a.isImport == 0 && x.DaPhatHanh == null
                             where x.trangthai_id == 0 && x.DOT_ID == dotid && x.kyghi == kyghi && x.IsInHD == false && x.ischeck == 0
                             select a).ToList().Count();

            if (dataHD.Count() == 0)
                MessageBox.Show("Kỳ này đã được phát hành hóa đơn hoặc không có dữ liệu");
            else if (chitietHD == 0)
                MessageBox.Show("Dữ liệu chi tiết hóa đơn không tồn tại trong hệ thống!");
            else
            {
                bdButton.Enabled = true;
                dataGridView1.DataSource = dataHD.OrderBy(x => x.MaLT).ToList();
                txtsoHD.Text = string.Format("{0:n0}", dataHD.Count());
                txttiennuoc.Text = string.Format("{0:n0}", dataHD.Sum(z => z.tongtien0VAT));
                txtTienBVMT.Text = string.Format("{0:n0}", dataHD.Sum(z => z.PhiBVMTCu));
                txtPhiNT25.Text = string.Format("{0:n0}", dataHD.Sum(z => z.PhiNT));
                txtThueGTGT.Text = string.Format("{0:n0}", dataHD.Sum(z => z.tienvat));
                txtTongTien.Text = string.Format("{0:n0}", dataHD.Sum(z => z.tongtien));
                txtLNTT.Text = string.Format("{0:n0}", dataHD.Sum(z => z.m3tieuthu));
                lblTongtien.Text = "Số lượng: " + string.Format("{0:n0}", dataHD.Count()) + " Tiền nước: " + string.Format("{0:n0}", dataHD.Sum(z => z.tongtien0VAT)) +
                    " Tiền thuế GTGT: " + string.Format("{0:n0}", dataHD.Sum(z => z.tienvat)) + " Tiền BVMT: " + string.Format("{0:n0}", dataHD.Sum(z => z.tienBVMT)) +
                    " Tổng tiền: " + string.Format("{0:n0}", dataHD.Sum(z => z.tongtien));
            }
            this.Cursor = Cursors.Default;  
        }

        private void frTaoHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            // dm mau so, ky hieu hoa don
            var dataMauHD = db.MAU_HD.Where(x => x.Active == true).ToList();
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            //dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.Where(x => x.hoadon == true).OrderBy(x => x.ten_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            cboKy.DataSource = dmKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "thang";
            // dm nam
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            //dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            cboNam.DataSource = dataKyghi.ToList();
            cboNam.ValueMember = "nam";
            cboNam.DisplayMember = "NAM";
            // dm dot
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            //dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            bdButton.Enabled = false;
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        private void bdButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn tạo hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    int dotid = int.Parse(cboDot.SelectedValue.ToString());
                decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
                int kyghi = int.Parse(cboKy.SelectedValue.ToString());
                string pkyghi = cboKy.SelectedValue.ToString();
                db.TaoHoaDon(dotid, cboKy.SelectedValue.ToString());
                var published = db.UpdatePublishedINV(dotid, kyghi, namid);
                var getNVHD = db.NHANVIEN_HOADON.Where(x => x.DOT_ID == dotid).ToList();
                var nhanvienHD = db.InsertNhanVienHD(int.Parse(namid.ToString()), kyghi, int.Parse(dotid.ToString()));
                db.setUpdateNhanVienHoaDOn_PublishedInvoices(int.Parse(dotid.ToString()), kyghi, int.Parse(namid.ToString()));
                bdButton.Enabled = true;
                excelButton.Enabled = true;
                quitButton.Enabled = true;
                seachButton.PerformClick();
                bdButton.Enabled = false;
                seachButton.PerformClick();
                MessageBox.Show(" hóa đơn đã được tạo");
                }
            }
            catch
            {

            }
        }
    }
}
