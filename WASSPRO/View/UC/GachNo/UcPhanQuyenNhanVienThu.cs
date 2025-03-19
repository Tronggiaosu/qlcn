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
    public partial class UcPhanQuyenNhanVienThu : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcPhanQuyenNhanVienThu()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
            btnEX.Click += btnEX_Click;
            cboTo.SelectedIndexChanged += cboTo_SelectedIndexChanged;
            dgvNhanvien.RowEnter += dgvNhanvien_RowEnter;
            btnEXChitiet.Click += btnEXChitiet_Click;
            btnChitiet.Click += btnChitiet_Click;
        }

        void btnChitiet_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (dgvNhanvien.RowCount > 0)
                {
                    string KYHIEU_HD = dgvNhanvien.SelectedRows[0].Cells[KY_HIEU_HDColumn.Name].Value.ToString();
                    decimal ID = decimal.Parse(dgvNhanvien.SelectedRows[0].Cells[IDColumn.Name].Value.ToString());
                    string hinhthuc = cboHT.SelectedValue.ToString();
                    int hanh = 2;
                    if (chkHT.Checked == true)
                    {
                        if (hinhthuc == "Hóa đơn hành")
                            hanh = 0;
                        else
                            hanh = 1;
                    }

                    var dataChitiet = db.getChiTietDSHoaDonChiaTNV(ID, hanh, KYHIEU_HD).ToList();
                    dgvLT.DataSource = dataChitiet.OrderBy(x => x.ma_tuyen_cuoc).ToList();
                    lblchitiet.Text = "Tộng cộng: " + string.Format("{0:n0}", dataChitiet.Select(x => x.CONGTHANHTIEN).Sum() + 
                        dataChitiet.Select(x => x.TIENVAT).Sum() + dataChitiet.Select(x => x.TIENPBVMT).Sum()) +
                        " ||" + string.Format("{0:n0}", dataChitiet.Select(x => x.CONGTHANHTIEN).Sum()) + "   |    " +
                        string.Format("{0:n0}", dataChitiet.Select(x => x.TIENVAT).Sum()) + "   |    " +
                        string.Format("{0:n0}", dataChitiet.Select(x => x.TIENPBVMT).Sum());
                }

            }
            catch
            {
               
            }
            this.Cursor = Cursors.Default;
        }

        void btnEXChitiet_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dgvLT);
        }

        void dgvNhanvien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (dgvNhanvien.RowCount > 0)
                {
                    decimal ID = decimal.Parse(dgvNhanvien[IDColumn.Name, e.RowIndex].Value.ToString());
                    string KYHIEU_HD = dgvNhanvien[KY_HIEU_HDColumn.Name, e.RowIndex].Value.ToString();
                    string hinhthuc = cboHT.SelectedValue.ToString();
                    int hanh = 2;
                    if(chkHT.Checked == true)
                    {
                        if (hinhthuc == "Hóa đơn hành")
                            hanh = 0;
                        else
                            hanh = 1;
                    }

                    var dataChitiet = db.getChiTietDSHoaDonChiaTNV(ID, hanh, KYHIEU_HD).ToList();
                    dgvLT.DataSource = dataChitiet.OrderBy(x => x.ma_tuyen_cuoc).ToList();
                    lblchitiet.Text = "Tộng cộng: " + string.Format("{0:n0}", dataChitiet.Select(x => x.CONGTHANHTIEN).Sum() +
                        dataChitiet.Select(x => x.TIENVAT).Sum() + dataChitiet.Select(x => x.TIENPBVMT).Sum()) +
                        " ||" + string.Format("{0:n0}", dataChitiet.Select(x => x.CONGTHANHTIEN).Sum()) + "   |    " +
                        string.Format("{0:n0}", dataChitiet.Select(x => x.TIENVAT).Sum()) + "   |    " +
                        string.Format("{0:n0}", dataChitiet.Select(x => x.TIENPBVMT).Sum());
                }
               
            }
            catch
            {
               
            }
            this.Cursor = Cursors.Default;
        }
        void cboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            decimal TOID = decimal.Parse(cboTo.SelectedValue.ToString());
                if (TOID != 0)
                {
                // dm nhan vien
                List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
                var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Where(x=>x.NHANVIEN.TO_ID == TOID).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.maNV , x.NHANVIEN.TO_ID }).OrderBy(x => x.tenNV).ToList();
                dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" , TO_ID = -1});
                foreach (var item in nhanvien)
                {
                    dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.maNV + " - " + item.tenNV, TO_ID = item.TO_ID });
                }
                cboNV.DataSource = dmNhanVien.ToList();
                cboNV.ValueMember = "NV_ID";
                cboNV.DisplayMember = "hoten";
                cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                }
                else
                {
                    List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
                    var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.maNV }).OrderBy(x => x.tenNV).ToList();
                    dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
                    foreach (var item in nhanvien)
                    {
                        dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.maNV + " - " + item.tenNV });
                    }
                    cboNV.DataSource = dmNhanVien.ToList();
                    cboNV.ValueMember = "NV_ID";
                    cboNV.DisplayMember = "hoten";
                    cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                };
            }
            catch
            {
                
            }
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dgvNhanvien);
        }
        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            decimal TOID = decimal.Parse(cboTo.SelectedValue.ToString());
            decimal DOTID = decimal.Parse(cboDot.SelectedValue.ToString());
            decimal NVID = decimal.Parse(cboNV.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            var data = db.getDSKhoangLoTrinhChiaTNV(TOID, DOTID, NVID, kyghi, 0, "").ToList();
            var tonghd = db.getDSKhoangLoTrinhChiaTNV(0, DOTID, 0, "0", 0, "").ToList();
            lbltonghdto.Text = "Tộng cộng HĐ chia: " + string.Format("{0:n0}", data.Select(x => x.sohd).Sum()) + "   |    " + string.Format("{0:n0}", data.Select(x => x.hdkhongdong).Sum()) +
                                "   |    " + string.Format("{0:n0}", data.Select(x => x.tiennuoc).Sum()) + "   |    " + string.Format("{0:n0}", data.Select(x => x.TIENVAT).Sum()) + "   |    " + string.Format("{0:n0}", data.Select(x => x.tienBVMT).Sum())
                                + "   |    " + string.Format("{0:n0}", data.Select(x => x.tongtien).Sum());
            lbltongtheodot.Text = "Tộng cộng HĐ cả đợt: " + string.Format("{0:n0}", tonghd.Select(x => x.sohd).Sum()) + "   |    " + string.Format("{0:n0}", tonghd.Select(x => x.hdkhongdong).Sum()) +
                                  "   |    " + string.Format("{0:n0}", tonghd.Select(x => x.tiennuoc).Sum()) + "   |    " + string.Format("{0:n0}", tonghd.Select(x => x.TIENVAT).Sum()) + "   |    " + string.Format("{0:n0}", tonghd.Select(x => x.tienBVMT).Sum())
                                  + "   |    " + string.Format("{0:n0}", tonghd.Select(x => x.tongtien).Sum());
            dgvNhanvien.DataSource = data.OrderBy(z => z.nhanvien).ToList();
            this.Cursor = Cursors.Default;

        }
        void btnThoat_Click(object sender, EventArgs e)
        {
        //    this.Close();
        }

        private void frPhanQuyenNhanVienThu_Load(object sender, EventArgs e)
        {
            dgvNhanvien.AutoGenerateColumns = false;
            dgvLT.AutoGenerateColumns = false;
            // dm to
            List<DM_TO> dmTO = new List<DM_TO>();
            var to = db.DM_TO.OrderBy(x => x.TENTO).ToList();
            dmTO.Add(new DM_TO() { TO_ID = 0, TENTO = "Tất cả" });
            dmTO.AddRange(to);
            cboTo.DataSource = dmTO.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
            cboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // dm nhan vien
            List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
            var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.maNV }).OrderBy(x => x.tenNV).ToList();
            dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
            foreach (var item in nhanvien)
            {
                dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.maNV + " - " + item.tenNV });
            }
            cboNV.DataSource = dmNhanVien.ToList();
            cboNV.ValueMember = "NV_ID";
            cboNV.DisplayMember = "hoten";
            cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // dm dot
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
            //colbox.DataSource = db.DM_DOT.OrderBy(x=>x.TENDOT).ToList();
            //colbox.ValueMember = "DOT_ID";
            //colbox.DisplayMember = "TENDOT";
            //colbox.HeaderText = "Đợt";
            //colbox.Name = "DOTIDColumn";
            //dataGridView1.Columns.Add(colbox);
            // dm ky ghi
            cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.OrderBy(x => x.ID_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            cboKy.DataSource = dmKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            dgvNhanvien.AutoGenerateColumns = false;
            dgvLT.AutoGenerateColumns = false;
            string[] s = { "Hóa đơn hành", "Hóa đơn tồn" };
            cboHT.DataSource = s;
        }
        // datasource datagridview
        private void DataSourceDGV()
        {
            dgvLT.AutoGenerateColumns = false;
            dgvLT.DataSource = db.VIEW_NHANVIENTHU_HOADON.OrderBy(x => x.hoten).ToList();
        }
    }
}
