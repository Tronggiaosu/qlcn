using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcCapNhatLT : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public string hotenNV;
        public decimal ID;
        public bool addNew = false;
        public UcCapNhatLT()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnSave.Click += btnSave_Click;
            txtTuLT.KeyDown += txtTuLT_KeyDown;
            txtDenLT.KeyDown += txtDenLT_KeyDown;
            txtTuLT.KeyPress += txtTuLT_KeyPress;
            txtDenLT.KeyPress += txtDenLT_KeyPress;
            cboTo.SelectedIndexChanged += cboTo_SelectedIndexChanged;
        }

        void cboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addNew == true)
            {
                try
                {
                    var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => new { tenNV = x.NHANVIEN.maNV + " - " + x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.maNV, x.NHANVIEN.TO_ID }).OrderBy(x => x.tenNV).ToList();
                    decimal TOID = decimal.Parse(cboTo.SelectedValue.ToString());
                    if (TOID != 0)
                        nhanvien = nhanvien.Where(x => x.TO_ID == TOID).ToList();
                    cboTNV.DataSource = nhanvien.ToList();
                    cboTNV.DisplayMember = "tenNV";
                    cboTNV.ValueMember = "NVID";
                }
                catch
                {

                }
            }
        }

        void txtDenLT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void txtTuLT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        void txtDenLT_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtDenLT.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    autoCompleteDenLT();
                }
            }
        }

        void txtTuLT_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTuLT.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    autoCompleteTuLT();
                }
            }
        }
        public void autoCompleteTuLT()
        {
            AutoCompleteStringCollection test = new AutoCompleteStringCollection();
            var data = db.HOADONs.Select(x => x.MaLT).ToList();
            foreach (var item in data)
            {
                test.Add(item);
            }
            txtTuLT.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTuLT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTuLT.AutoCompleteCustomSource = test;
        }
        public void autoCompleteDenLT()
        {
            AutoCompleteStringCollection test = new AutoCompleteStringCollection();
            var data = db.HOADONs.Where(x => x.trangthai_id != 0).Select(x => x.MaLT).ToList();
            foreach (var item in data)
            {
                test.Add(item);
            }
            txtDenLT.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDenLT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDenLT.AutoCompleteCustomSource = test;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal DOTID = decimal.Parse(cboDot.SelectedValue.ToString());
                bool thut7 = chkT7.Checked == true ? true : false;
                bool thucn = chkCN.Checked == true ? true : false;
                bool active = chkActive.Checked == true ? true : false;
                int tuso = int.Parse(txtTuLT.Text == "" ? "0" : txtTuLT.Text);
                int denso = int.Parse(txtDenLT.Text == "" ? "0" : txtDenLT.Text);
                var nhanvien_create = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                var HD_CuonGCS = db.HOADONs.Where(x => x.cuonGCS == txtCuonGCS.Text).FirstOrDefault();
                decimal NVID = decimal.Parse(cboTNV.SelectedValue.ToString());
                var nhanvien = db.NHANVIENs.Where(x=>x.NV_ID == NVID).FirstOrDefault();
                //if (txtCuonGCS.Text == "")
                //    MessageBox.Show("Chưa nhập cuốn GCS");
                //else if (HD_CuonGCS == null)
                //    MessageBox.Show("Cuốn GCS không tồn tại trong hệ thống!");
                if (tuso > denso)
                    MessageBox.Show("Khoảng lộ trình không hợp lệ, nhập từ số nhỏ hơn đến số!");
                else if (tuso == 0 || denso == 0)
                    MessageBox.Show("Chưa nhập khoảng lộ trình thu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DialogResult rs = MessageBox.Show("Bạn có cập nhật lộ trình cho nhân viên thu?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        if (addNew == false)
                        {
                            var nhanvienHD = db.NHANVIEN_HOADON.Where(x => x.ID == ID).FirstOrDefault();
                            string thangps = "20" + nhanvienHD.Nam.ToString() + nhanvienHD.Kyghi;
                            if (nhanvienHD != null)
                            {
                                nhanvienHD.TuLT = tuso;
                                nhanvienHD.DenLT = denso;
                                nhanvienHD.T7 = thut7;
                                nhanvienHD.CN = thucn;
                                nhanvienHD.GIOBD = dtpGioBD.Value.ToString("HH:mm");
                                nhanvienHD.GIOKT = dtpGioKT.Value.ToString("HH:mm");
                                nhanvienHD.TRANGTHAI = true;
                                nhanvienHD.USER_UPDATE = nhanvien_create.nv_id;
                                nhanvienHD.DATE_UPDATE = DateTime.Now;
                                nhanvienHD.CUON_GCS = txtCuonGCS.Text;
                                nhanvienHD.DOT_ID = nhanvienHD.DOT_ID;
                                nhanvienHD.TRANGTHAI = active;
                                db.SaveChanges();
                                db.UpdateLoTrinhThu(txtCuonGCS.Text, tuso, denso, nhanvienHD.NV_ID, nhanvienHD.DOT_ID, thangps);
                                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            var kyghi = cboKy.SelectedValue.ToString();
                            var nam = decimal.Parse(cboNam.SelectedValue.ToString());
                            int thangps =  int.Parse("20" + nam.ToString() + kyghi);
                            var publish = db.PublishedInvoices.Where(x => x.DOT_ID == DOTID && x.thang_ps == thangps && x.CUON_STT >= tuso && x.CUON_STT <= denso).ToList();
                            if (publish.Count == 0)
                            {
                                if (DOTID != 0)
                                {
                                    NHANVIEN_HOADON lotrinhthu = new NHANVIEN_HOADON();
                                    lotrinhthu.Kyghi = cboKy.SelectedValue.ToString();
                                    lotrinhthu.MAND = nhanvien.maNV;
                                    lotrinhthu.Nam = int.Parse(cboNam.SelectedValue.ToString());
                                    lotrinhthu.NV_ID = nhanvien.NV_ID;
                                    lotrinhthu.T7 = thut7;
                                    lotrinhthu.CN = thucn;
                                    lotrinhthu.TRANGTHAI = active;
                                    lotrinhthu.GIOBD = dtpGioBD.Value.ToString("HH:mm");
                                    lotrinhthu.GIOKT = dtpGioKT.Value.ToString("HH:mm");
                                    lotrinhthu.CUON_GCS = txtCuonGCS.Text;
                                    lotrinhthu.TuLT = tuso;
                                    lotrinhthu.DenLT = denso;
                                    lotrinhthu.DOT_ID = DOTID;
                                    lotrinhthu.Kyghi = cboKy.SelectedValue.ToString();
                                    lotrinhthu.USER_CREATE = nhanvien_create.nv_id;
                                    lotrinhthu.DATE_CREATE = DateTime.Now;
                                    db.NHANVIEN_HOADON.Add(lotrinhthu);
                                    db.SaveChanges();
                                    db.UpdateLoTrinhThu(txtCuonGCS.Text, tuso, denso, nhanvien.NV_ID, DOTID, thangps.ToString());
                                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                                MessageBox.Show("Khoảng lộ trình đã được chia cho nhân viên trước đó, vui lòng kiểm tra lại");
                            }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình lấy dữ liệu!");
            }

        }

        void btnThoat_Click(object sender, EventArgs e)
        {
        //    this.Close();
        }

        private void frCapNhatLT_Load(object sender, EventArgs e)
        {
            dtpGioBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpGioBD.CustomFormat = "HH:mm";
            dtpGioBD.ShowUpDown = true;
            dtpGioKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpGioKT.CustomFormat = "HH:mm";
            dtpGioKT.ShowUpDown = true;
            cboTNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            if (addNew == false)
            {
                var data = db.NHANVIEN_HOADON.Where(x => x.ID == ID).FirstOrDefault();
                cboTNV.DataSource = db.NHANVIENs.Where(x => x.NV_ID == data.NV_ID).Select(x => new { x.NV_ID, hoten = x.maNV + " - " + x.hoten}).ToList();
                cboTNV.ValueMember = "NV_ID";
                cboTNV.DisplayMember = "hoten";
                dtpGioBD.Text = data.GIOBD;
                dtpGioKT.Text = data.GIOKT;
                // dm dot
                var dot = db.DM_DOT.Where(x => x.DOT_ID == data.DOT_ID).OrderBy(x => x.TENDOT).ToList();
                cboDot.DataSource = dot.ToList();
                cboDot.ValueMember = "DOT_ID";
                cboDot.DisplayMember = "TENDOT";
                cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                // dm to
                var dmTo = db.DM_TO.Where(x => x.TO_ID == data.NHANVIEN.TO_ID).ToList();
                cboTo.DataSource = dmTo.ToList();
                cboTo.ValueMember = "TO_ID";
                cboTo.DisplayMember = "TENTO";
                cboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                // dm nam
                cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                var dataNam = db.DM_NAM.Where(x => x.NAM_ID == data.Nam).OrderBy(x => x.NAM).ToList();
                cboNam.DataSource = dataNam.ToList();
                cboNam.ValueMember = "NAM_ID";
                cboNam.DisplayMember = "NAM";
                // dm ky ghi
                cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                var dataKyghi = db.DM_KYGHI.Where(x => x.ID_kyghi == data.Kyghi).OrderBy(x => x.ten_kyghi).ToList();
                cboKy.DataSource = dataKyghi.ToList();
                cboKy.ValueMember = "ID_kyghi";
                cboKy.DisplayMember = "ten_kyghi";
                if (data.T7 == true)
                    chkT7.Checked = true;
                else
                    chkT7.Checked = false;
                if (data.CN == true)
                    chkCN.Checked = true;
                else
                    chkCN.Checked = false;
                if (data.TRANGTHAI == true)
                    chkActive.Checked = true;
                else
                    chkActive.Checked = false;
                txtCuonGCS.Text = data.CUON_GCS;
                txtDenLT.Text = data.DenLT.ToString();
                txtTuLT.Text = data.TuLT.ToString();
            }
            else
            {
                // dm dot
                List<DM_DOT> dmDot = new List<DM_DOT>();
                //dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
                var dot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
                dmDot.AddRange(dot);
                cboDot.DataSource = dmDot.ToList();
                cboDot.ValueMember = "DOT_ID";
                cboDot.DisplayMember = "TENDOT";
                cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                // dm to
                List<DM_TO> dmTo = new List<DM_TO>();
                dmTo.Add(new DM_TO() { TO_ID = 0, TENTO = "Tất cả" });
                var dataTo = db.DM_TO.OrderBy(x => x.TENTO).ToList();
                dmTo.AddRange(dataTo);
                cboTo.DataSource = dmTo.ToList();
                cboTo.ValueMember = "TO_ID";
                cboTo.DisplayMember = "TENTO";
                cboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                // dm nam
                cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                List<DM_NAM> dmNam = new List<DM_NAM>();
                var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
                dmNam.AddRange(dataNam);
                cboNam.DataSource = dmNam.ToList();
                cboNam.ValueMember = "NAM_ID";
                cboNam.DisplayMember = "NAM";
                // dm ky ghi
                cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
                var dataKyghi = db.DM_KYGHI.OrderBy(x => x.ten_kyghi).ToList();
                dmKyghi.AddRange(dataKyghi);
                cboKy.DataSource = dmKyghi.ToList();
                cboKy.ValueMember = "ID_kyghi";
                cboKy.DisplayMember = "ten_kyghi";
                // dm nhan vien
                List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
                var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.maNV }).OrderBy(x => x.tenNV).ToList();
                foreach (var item in nhanvien)
                {
                    dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.maNV + " - " + item.tenNV });
                }
                cboTNV.DataSource = dmNhanVien.ToList();
                cboTNV.ValueMember = "NV_ID";
                cboTNV.DisplayMember = "hoten";
                cboTNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
        }
    }
}
