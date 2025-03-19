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
    public partial class UcTaoHoaDon : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcTaoHoaDon()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
         //   this.Close();
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            decimal dotid = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            string kyghi = (cboKy.SelectedValue.ToString());
            string result = namid + kyghi;
            this.Cursor = Cursors.WaitCursor;
            var dataHD = db.HOADONs.Where(x => x.trangthai_id == 0 && x.DOT_ID == dotid && x.kyghi == result && x.IsInHD == false && x.ischeck == 0).OrderBy(x => x.MaLT).ToList();
            var chitietHD = (from a in db.CHITIET_HD
                             from x in db.HOADONs
                             where a.ID_HD == x.ID_HD && x.ID_KH == a.ID_KH && a.isImport == 0 && x.DaPhatHanh == null
                             where x.trangthai_id == 0 && x.DOT_ID == dotid && x.kyghi == result && x.IsInHD == false && x.ischeck == 0
                             select a).ToList().Count();

            if (dataHD.Count() == 0)
                MessageBox.Show("Tháng này đã được phát hành hóa đơn hoặc không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (chitietHD == 0)
                MessageBox.Show("Dữ liệu chi tiết hóa đơn không tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                bdButton.Enabled = true;
                if(dataHD.Count() > 0)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }    
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = false;
            // dm mau so, ky hieu hoa don
            var dataMauHD = db.MAU_HD.Where(x => x.Active == true).ToList();
            //cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            ////dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            //var dataKyghi = db.DM_KYGHI.Where(x => x.hoadon == true).OrderBy(x => x.ten_kyghi).ToList();
            //dmKyghi.AddRange(dataKyghi);
            //cboKy.DataSource = dmKyghi.ToList();
            //cboKy.ValueMember = "ID_kyghi";
            //cboKy.DisplayMember = "thang";
            //// dm nam
            //cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //List<DM_NAM> dmNam = new List<DM_NAM>();
            ////dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            //cboNam.DataSource = dataKyghi.ToList();
            //cboNam.ValueMember = "nam";
            //cboNam.DisplayMember = "NAM";

            cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            for (int i = 1; i <= 12; i++)
            {
                dmKyghi.Add(new DM_KYGHI()
                {
                    ID_kyghi = i.ToString("00"),
                    ten_kyghi = $"{i:00}"
                });
            }
            cboKy.DataSource = dmKyghi;
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";

            // dm nam
            cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            //dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "nam";
            cboNam.DisplayMember = "NAM";

            // dm dot
            cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                    int namid = int.Parse(cboNam.SelectedValue.ToString());
                    int kyghi = int.Parse(cboKy.SelectedValue.ToString());
                    int result = namid + kyghi;
                    string pkyghi = cboKy.SelectedValue.ToString();
                    db.TaoHoaDon(dotid, cboKy.SelectedValue.ToString());
                    var published = db.UpdatePublishedINV(dotid, result, namid);
                    var getNVHD = db.NHANVIEN_HOADON.Where(x => x.DOT_ID == dotid).ToList();
                    var nhanvienHD = db.InsertNhanVienHD(int.Parse(namid.ToString()), result, int.Parse(dotid.ToString()));
                    db.setUpdateNhanVienHoaDOn_PublishedInvoices(int.Parse(dotid.ToString()), result, int.Parse(namid.ToString()));
                    bdButton.Enabled = true;
                    excelButton.Enabled = true;
                    quitButton.Enabled = true;
                    seachButton.PerformClick();
                    bdButton.Enabled = false;
                    seachButton.PerformClick();
                    MessageBox.Show(" hóa đơn đã được tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {

            }
        }
    }
}
