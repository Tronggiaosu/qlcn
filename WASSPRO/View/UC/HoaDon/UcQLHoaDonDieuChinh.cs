using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcQLHoaDonDieuChinh : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public int trangthai_id = 0;

        public UcQLHoaDonDieuChinh()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            seachButton.Click += seachButton_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            excelButton.Click += excelButton_Click;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridViewDC.CellContentClick += dataGridViewDC_CellContentClick;
        }

        private void dataGridViewDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                decimal IDHD = decimal.Parse(dataGridViewDC.Rows[e.RowIndex].Cells[FkeyDCColumn.Name].Value.ToString());
                Portal.PortalService portal = new Portal.PortalService();
                var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                var result = portal.getInvViewFkeyNoPay(IDHD.ToString(), accWS.acc_service, accWS.pass_service);
                var frm = new Form();
                frm.Size = new Size(1200, 800);
                WebBrowser webBrowser = new WebBrowser();
                webBrowser.Dock = DockStyle.Fill;

                if (result.Trim() == "ERR:1")
                {
                    webBrowser.DocumentText = "<h2>Hóa đơn này bạn không thể xem</h2>";
                }
                else
                {
                    webBrowser.DocumentText = result;
                }

                frm.Controls.Add(webBrowser);
                frm.ShowDialog();
            }
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
                var frm = new Form();
                frm.Size = new Size(1200, 800);
                WebBrowser webBrowser = new WebBrowser();
                webBrowser.Dock = DockStyle.Fill;

                if (result.Trim() == "ERR:1")
                {
                    webBrowser.DocumentText = "<h2>Hóa đơn này bạn không thể xem</h2>";
                }
                else
                {
                    webBrowser.DocumentText = result;
                }

                frm.Controls.Add(webBrowser);
                frm.ShowDialog();
            }
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu hiện tại không có để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Common.ExportExcel(dataGridView1);
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string search = txtTim.Text;
            if (search != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    seachButton.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            decimal DOTID = cboDot.SelectedValue != null ? decimal.Parse(cboDot.SelectedValue.ToString()) : 0;
            string mau = cboMauHD.SelectedValue != null ? cboMauHD.SelectedValue.ToString() : "Tất cả";
            string kyhieu = cboKH.SelectedValue != null ? cboKH.SelectedValue.ToString() : "Tất cả";
            string ky = cboThang.SelectedValue != null ? cboThang.SelectedValue.ToString() : "0";
            decimal namid = cboNam.SelectedValue != null ? decimal.Parse(cboNam.SelectedValue.ToString()) : 0;
            decimal NVID_ChuanThu = cboNV.SelectedValue != null ? decimal.Parse(cboNV.SelectedValue.ToString()) : 0;
            string search = txtTim.Text.Trim();

            var hoadon = db.HOADONs.Where(x => x.trangthai_id == trangthai_id).AsQueryable();
            var hoadonDC = (from hd in db.HOADONs
                            from dc in db.HOADONs
                            where hd.ID_HD == dc.keys && hd.trangthai_id == trangthai_id
                            select dc).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                hoadon = hoadon.Where(x => x.SO_HD.Contains(search) || x.DANHBO.Contains(search));
                hoadonDC = hoadonDC.Where(x => x.SO_HD.Contains(search) || x.DANHBO.Contains(search));
            }

            if (DOTID != 0)
            {
                hoadon = hoadon.Where(x => x.DOT_ID == DOTID);
                hoadonDC = hoadonDC.Where(x => x.DOT_ID == DOTID);
            }

            if (mau != "Tất cả")
            {
                hoadon = hoadon.Where(x => x.MAU_HD == mau);
                hoadonDC = hoadonDC.Where(x => x.MAU_HD == mau);
            }

            if (kyhieu != "Tất cả")
            {
                hoadon = hoadon.Where(x => x.KY_HIEU_HD == kyhieu);
                hoadonDC = hoadonDC.Where(x => x.KY_HIEU_HD == kyhieu);
            }

            if (namid != 0)
            {
                namid = 2000 + decimal.Parse(cboNam.SelectedValue.ToString());
                hoadon = hoadon.Where(x => x.nam == namid);
                hoadonDC = hoadonDC.Where(x => x.nam == namid);
            }

            if (NVID_ChuanThu != 0)
            {
                hoadon = hoadon.Where(x => x.user_update == NVID_ChuanThu);
                hoadonDC = hoadonDC.Where(x => x.user_update == NVID_ChuanThu);
            }

            if (checkBox1.Checked == true)
            {
                hoadon = hoadon.Where(x => x.date_update >= dateTimePicker1.Value.Date && x.date_update <= dateTimePicker2.Value.Date);
                hoadonDC = hoadonDC.Where(x => x.date_create >= dateTimePicker1.Value.Date && x.date_create <= dateTimePicker2.Value.Date);
            }

            if (ky != "0")
            {
                hoadon = hoadon.Where(x => x.kyghi.Substring(x.kyghi.Length - 2) == ky);
                hoadonDC = hoadonDC.Where(x => x.kyghi.Substring(x.kyghi.Length - 2) == ky);
            }

            var dataSourceDGV1 = hoadon
                .Select(x => new {
                    x.ID_HD,
                    x.hoten,
                    x.DANHBO,
                    x.SO_HD,
                    x.MaLT,
                    chitiet = "Chi tiết"
                }).ToList();

            var dataSourceDGV2 = hoadonDC
                .Select(x => new { 
                    x.ID_HD,
                    x.hoten, 
                    x.DANHBO, 
                    x.MaLT, 
                    x.SO_HD, 
                    chitiet = "Chi tiết", 
                    x.keys 
                }).ToList();
            if(dataSourceDGV1.Count > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            if (dataSourceDGV2.Count > 0)
            {
                dataGridViewDC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            dataGridView1.DataSource = dataSourceDGV1.OrderByDescending(x => x.ID_HD).ToList();
            dataGridViewDC.DataSource = dataSourceDGV2.OrderByDescending(x => x.keys).ToList();
            this.Cursor = Cursors.Default;
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (trangthai_id == 8)
            {
                new FrmDialog().ShowDialog<UcDieuChinhHoaDon>();
            }
            else
            {
                new FrmDialog().ShowDialog<UcThayTheHoaDon>();
            }
            this.Cursor = Cursors.Default;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //this.Parent.Close();
        }

        private void frQLHoaDonDieuChinh_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.Columns["soHDColumn"].Width = 130;
            //dataGridView1.Columns["DanhBoColumn"].Width = 150;
            //dataGridView1.Columns["MaLT"].Width = 150;
            //dataGridView1.Columns["chitietColumn"].Width = 90;
            //dataGridView1.Columns["HotenColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewDC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridViewDC.Columns["soHDColumn1"].Width = 130;
            //dataGridViewDC.Columns["DanhBoColumn1"].Width = 150;
            //dataGridViewDC.Columns["MaLT1"].Width = 150;
            //dataGridViewDC.Columns["chitietColumn1"].Width = 90;
            //dataGridViewDC.Columns["HotenColumn1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.AutoGenerateColumns = false;
            dataGridViewDC.AutoGenerateColumns = false;
            // dm ky ghi
            cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            for(int i = 1; i <= 12; i++)
            {
                dmKyghi.Add(new DM_KYGHI()
                {
                    ID_kyghi = i.ToString("00"),
                    ten_kyghi = $"{i:00}"
                });
            }
            cboThang.DataSource = dmKyghi;
            cboThang.ValueMember = "ID_kyghi";
            cboThang.DisplayMember = "ten_kyghi";
            // dm nam
            cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
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
            cboMauHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<MAU_HD> dsMau = new List<MAU_HD>();
            dsMau.Add(new MAU_HD { mau_HD1 = "Tất cả", ky_hieu_HD = "Tất cả" });
            var dataMauHD = db.MAU_HD.ToList();
            dsMau.AddRange(dataMauHD);
            cboMauHD.DataSource = dsMau.ToList();
            cboMauHD.ValueMember = "mau_HD1";
            cboKH.DataSource = dsMau.ToList();
            cboKH.ValueMember = "ky_hieu_HD";
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            // dm nhan vien
            cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<NHANVIEN> nhanvien = new List<NHANVIEN>();
            nhanvien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
            var dsNhanvien = db.NHANVIEN_LNV
                .Where(x => x.ID_LoaiNV == 3)
                .Select(x => x.NHANVIEN)
                .GroupBy(nv => nv.hoten)  
                .Select(g => g.FirstOrDefault())  
                .OrderBy(nv => nv.hoten) 
                .ToList();
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

        private void dataGridViewDC_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}