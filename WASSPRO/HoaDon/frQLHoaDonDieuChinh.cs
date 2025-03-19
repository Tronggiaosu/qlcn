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
    public partial class frQLHoaDonDieuChinh : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public int trangthai_id = 0;
        public frQLHoaDonDieuChinh()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            seachButton.Click += seachButton_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            excelButton.Click += excelButton_Click;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridViewDC.CellContentClick += dataGridViewDC_CellContentClick;
        }

        void dataGridViewDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                decimal IDHD = decimal.Parse(dataGridViewDC.Rows[e.RowIndex].Cells[FkeyDCColumn.Name].Value.ToString());
                Portal.PortalService portal = new Portal.PortalService();
                var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                var result = portal.getInvViewFkeyNoPay(IDHD.ToString(), accWS.acc_service, accWS.pass_service);
                frViewInv frm = new frViewInv();
                frm.html = result;
                frm.ShowDialog();
            }
        }

        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                decimal IDHD = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[FkeyColumn.Name].Value.ToString());
                Portal.PortalService portal = new Portal.PortalService();
                var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                var result = portal.getInvViewFkeyNoPay(IDHD.ToString(), accWS.acc_service, accWS.pass_service);
                frViewInv frm = new frViewInv();
                frm.html = result;
                frm.ShowDialog();
            }
        }

        void excelButton_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string txt = txtTim.Text;
                    var hoadon = db.HOADONs.Where(x=>x.trangthai_id == trangthai_id).OrderByDescending(x => x.ID_HD).ToList();
                    var hoadonDC = (from hd in db.HOADONs
                                    from dc in db.HOADONs
                                    where hd.ID_HD == dc.keys && hd.trangthai_id == trangthai_id
                                    select dc
                                 ).OrderByDescending(x => x.keys).ToList();
                    hoadon = hoadon.Where(x =>x.SO_HD.Contains(txt) || x.DANHBO.Contains(txt) || x.KHACHHANG.hoten_KH.Contains(txt) || x.MaLT.Contains(txt)).ToList();
                    hoadonDC = hoadonDC.Where(x => x.SO_HD.Contains(txt) || x.DANHBO.Contains(txt) || x.KHACHHANG.hoten_KH.Contains(txt) || x.MaLT.Contains(txt)).ToList();
                    var dataSourceDGV1 = hoadon.Select(x => new { x.ID_HD, x.KHACHHANG.hoten_KH, x.DANHBO, x.MaLT, x.SO_HD, chitiet = "Chi tiết" });
                    var dataSourceDGV2 = hoadonDC.Select(x => new { x.ID_HD, x.KHACHHANG.hoten_KH, x.DANHBO, x.MaLT, x.SO_HD, chitiet = "Chi tiết" });
                    dataGridView1.DataSource = dataSourceDGV1.OrderByDescending(x => x.ID_HD).ToList();
                    dataGridViewDC.DataSource = dataSourceDGV2.OrderByDescending(x => x.ID_HD).ToList();
                }
            }
        }

        void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            decimal DOTID = decimal.Parse(cboDot.SelectedValue.ToString());
            string mau = cboMauHD.SelectedValue.ToString();
            string kyhieu = cboKH.SelectedValue.ToString();
            string ky = cboKy.SelectedValue.ToString();
            decimal namid = decimal.Parse(cboNam.SelectedValue.ToString());
            decimal NVID_ChuanThu = decimal.Parse(cboNV.SelectedValue.ToString());

            var hoadon = db.HOADONs.Where(x => x.trangthai_id == trangthai_id).OrderByDescending(x => x.ID_HD).ToList();
            var hoadonDC = (from hd in db.HOADONs
                            from dc in db.HOADONs
                            where hd.ID_HD == dc.keys 
                            where hd.trangthai_id == trangthai_id
                            select dc
                         ).OrderByDescending(x=>x.keys).ToList();
            if (DOTID != 0)
            {
                hoadon = hoadon.Where(x => x.DOT_ID == DOTID).ToList();
                hoadonDC = hoadonDC.Where(x => x.DOT_ID == DOTID).ToList();
            }
            if (mau != "Tất cả")
            {
                hoadon = hoadon.Where(x => x.MAU_HD == mau).ToList();
                hoadonDC = hoadonDC.Where(x => x.MAU_HD == mau).ToList();
            }

            if (kyhieu != "Tất cả")
            {
                hoadon = hoadon.Where(x => x.KY_HIEU_HD == kyhieu).ToList();
                hoadonDC = hoadonDC.Where(x => x.KY_HIEU_HD == kyhieu).ToList();
            }

            if (namid != 0)
            {
                hoadon = hoadon.Where(x => x.nam == namid).ToList();
                hoadonDC = hoadonDC.Where(x => x.nam == namid).ToList();
            }

            if (NVID_ChuanThu != 0)
            {
                hoadon = hoadon.Where(x => x.user_update == NVID_ChuanThu).ToList();
                hoadonDC = hoadonDC.Where(x => x.user_update == NVID_ChuanThu).ToList();
            }
            if (checkBox1.Checked == true)
            {
                hoadon = hoadon.Where(x => x.date_update >= dateTimePicker1.Value.Date && x.date_update <= dateTimePicker2.Value.Date).ToList();
                hoadonDC = hoadonDC.Where(x => x.date_create >= dateTimePicker1.Value.Date && x.date_create <= dateTimePicker2.Value.Date).ToList();
            }
            if (ky != "0")
            {
                hoadon = hoadon.Where(x => x.kyghi == ky).ToList();
                hoadonDC = hoadonDC.Where(x => x.kyghi == ky).ToList();
            }
            var dataSourceDGV1 = hoadon.Select(x => new { x.ID_HD, x.KHACHHANG.hoten_KH, x.DANHBO, x.MaLT, x.SO_HD, chitiet = "Chi tiết" }).ToList();
            var dataSourceDGV2 = hoadonDC.Select(x => new { x.ID_HD, x.KHACHHANG.hoten_KH, x.DANHBO, x.MaLT, x.SO_HD, chitiet = "Chi tiết", x.keys }).ToList();
            dataGridView1.DataSource = dataSourceDGV1.OrderByDescending(x => x.ID_HD).ToList();
            dataGridViewDC.DataSource = dataSourceDGV2.OrderByDescending(x => x.keys).ToList();
            this.Cursor = Cursors.Default;
        }

        void btnAdjust_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (trangthai_id == 8)
            {
                frDieuChinhHoaDon frm = new frDieuChinhHoaDon();
                frm.MdiParent = this.MdiParent;
                foreach (Form otherForm in this.MdiChildren)
                    if (otherForm != frm)
                        otherForm.Close();
                frm.Dock = DockStyle.Fill;
                frm.Show();
               
            }
            else
            {
                frThayTheHoaDon frm = new frThayTheHoaDon();
                frm.MdiParent = this.MdiParent;
                foreach (Form otherForm in this.MdiChildren)
                    if (otherForm != frm)
                        otherForm.Close();
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
            this.Cursor = Cursors.Default;
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frQLHoaDonDieuChinh_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridViewDC.AutoGenerateColumns = false;
            // dm ky ghi
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.OrderBy(x => x.ten_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            cboKy.DataSource = dmKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            // dm nam
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
            // dm dot
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            // dm mau so, ky hieu hoa don
            cboMauHD.DropDownStyle = ComboBoxStyle.DropDownList;
            List<MAU_HD> dsMau = new List<MAU_HD>();
            dsMau.Add(new MAU_HD { mau_HD1 = "Tất cả", ky_hieu_HD = "Tất cả"});
            var dataMauHD = db.MAU_HD.ToList();
            dsMau.AddRange(dataMauHD);
            cboMauHD.DataSource = dsMau.ToList();
            cboMauHD.ValueMember = "mau_HD1";
            cboKH.DataSource = dsMau.ToList();
            cboKH.ValueMember = "ky_hieu_HD";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            // dm nhan vien
            cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
            List<NHANVIEN> nhanvien = new List<NHANVIEN>();
            nhanvien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
            var dsNhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 3).Select(x => x.NHANVIEN).OrderBy(x => x.hoten).ToList();
            nhanvien.AddRange(dsNhanvien);
            cboNV.DataSource = nhanvien.ToList();
            cboNV.ValueMember = "NV_ID";
            cboNV.DisplayMember = "hoten";
        }

    }
}
