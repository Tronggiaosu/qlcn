using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcQLHuyHoaDon : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcQLHuyHoaDon()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            excelButton.Click += excelButton_Click;
            seachButton.Click += seachButton_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            btnDelete.Click += btnDelete_Click;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                decimal IDHD = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[FkeyColumn.Name].Value.ToString());
                Portal.PortalService portal = new Portal.PortalService();
                var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                var result = portal.getInvViewFkeyNoPay(IDHD.ToString(), accWS.acc_service, accWS.pass_service);
                var frm = new UcViewInv
                {
                    html = result
                };
                new FrmDialog().ShowDialog(frm);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            new FrmDialog().ShowDialog<UcHoaDonHuy>();
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string txt = txtTim.Text;
                    var hoadon = db.HOADONs.Where(x => x.trangthai_id == 2 && x.SO_HD.Contains(txt) || x.DANHBO.Contains(txt) || x.MaLT.Contains(txt) || x.KHACHHANG.hoten_KH.Contains(txt) || x.tongtien.ToString().Contains(txt)).ToList();
                    dataGridView1.DataSource = hoadon.OrderByDescending(x => x.date_update).ToList();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            decimal DOTID = decimal.Parse(cboDot.SelectedValue.ToString());
            string mau = cboMauHD.SelectedValue.ToString();
            string kyhieu = cboKH.SelectedValue.ToString();
            string ky = cboKy.SelectedValue.ToString();
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            decimal NVID_ChuanThu = decimal.Parse(cboNV.SelectedValue.ToString());
            var hoadon = db.HOADONs.Where(x => x.trangthai_id == 2 && x.keys != null).ToList();
            if (DOTID != 0)
                hoadon = hoadon.Where(x => x.DOT_ID == DOTID).ToList();
            if (mau != "0")
                hoadon = hoadon.Where(x => x.MAU_HD == mau).ToList();
            if (kyhieu != "0")
                hoadon = hoadon.Where(x => x.KY_HIEU_HD == kyhieu).ToList();
            if (namid != 0)
                hoadon = hoadon.Where(x => x.nam == namid).ToList();
            if (NVID_ChuanThu != 0)
                hoadon = hoadon.Where(x => x.user_update == NVID_ChuanThu).ToList();
            if (checkBox1.Checked == true)
                hoadon = hoadon.Where(x => x.date_update >= dateTimePicker1.Value.Date && x.date_update <= dateTimePicker2.Value.Date).ToList();
            var dataSourceDGV = hoadon.Select(x => new { x.ID_HD, x.kyghi, x.nam, x.DANHBO, x.MaLT, x.KHACHHANG.hoten_KH, x.DM_DOT.TENDOT, x.SO_HD, chitiet = "Chi tiết", x.date_update }).OrderByDescending(x => x.date_update).ToList();
            dataGridView1.DataSource = dataSourceDGV.OrderByDescending(x => x.date_update).ToList();
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }

        private void frQLHuyHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            // dm ky ghi
            cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.OrderBy(x => x.ten_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            cboKy.DataSource = dmKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            // dm nam
            cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dmNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
            // dm dot
            cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            // dm mau so, ky hieu hoa don
            var dataMauHD = db.MAU_HD.Where(x => x.Active == true).ToList();
            cboMauHD.DataSource = dataMauHD.ToList();
            cboMauHD.ValueMember = "mau_HD1";
            cboKH.DataSource = dataMauHD.ToList();
            cboKH.ValueMember = "ky_hieu_HD";
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            // dm nhan vien
            cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<NHANVIEN> nhanvien = new List<NHANVIEN>();
            nhanvien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
            var dsNhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 3).Select(x => x.NHANVIEN).OrderBy(x => x.hoten).ToList();
            nhanvien.AddRange(dsNhanvien);
            cboNV.DataSource = nhanvien.ToList();
            cboNV.ValueMember = "NV_ID";
            cboNV.DisplayMember = "hoten";
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