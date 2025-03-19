using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.LoTrinhThu
{
    public partial class frDSHoaDonChuaChiaChoTNV : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frDSHoaDonChuaChiaChoTNV()
        {
            InitializeComponent();
            cboTo.SelectedIndexChanged += cboTo_SelectedIndexChanged;
            btnTim.Click += btnTim_Click;
            btnThoat.Click += btnThoat_Click;
            btnEX.Click += btnEX_Click;
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int TOID = int.Parse(cboTo.SelectedValue.ToString());
            int DOTID = int.Parse(cboDot.SelectedValue.ToString());
            decimal NVID = decimal.Parse(cboNV.SelectedValue.ToString());
            string pkyghi = cboKy.SelectedValue.ToString();
            int nam = int.Parse(cboNam.SelectedValue.ToString());
            dataGridView1.DataSource = db.getDSHoaDonChuaChiaTNV(nam, pkyghi, DOTID, TOID, NVID).ToList();
            lbl_soluong.Text = "Số lượng HĐ: " + string.Format("{0:n0}", dataGridView1.RowCount);
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
                    var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Where(x => x.NHANVIEN.TO_ID == TOID).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.somay, x.NHANVIEN.TO_ID }).OrderBy(x => x.somay).ToList();
                    dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả", TO_ID = -1 });
                    foreach (var item in nhanvien)
                    {
                        dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.somay + " - " + item.tenNV, TO_ID = item.TO_ID });
                    }
                    cboNV.DataSource = dmNhanVien.ToList();
                    cboNV.ValueMember = "NV_ID";
                    cboNV.DisplayMember = "hoten";
                    cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else
                {
                    List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
                    var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.somay }).OrderBy(x => x.somay).ToList();
                    dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
                    foreach (var item in nhanvien)
                    {
                        dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.somay + " - " + item.tenNV });
                    }
                    cboNV.DataSource = dmNhanVien.ToList();
                    cboNV.ValueMember = "NV_ID";
                    cboNV.DisplayMember = "hoten";
                    cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
                };
            }
            catch
            {

            }
        }

        private void frDSHoaDonChuaChiaChoTNV_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            // dm to
            List<DM_TO> dmTO = new List<DM_TO>();
            var to = db.DM_TO.OrderBy(x => x.TENTO).ToList();
            dmTO.Add(new DM_TO() { TO_ID = 0, TENTO = "Tất cả" });
            dmTO.AddRange(to);
            cboTo.DataSource = dmTO.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;
            // dm nhan vien
            List<NHANVIEN> dmNhanVien = new List<NHANVIEN>();
            var nhanvien = db.NHANVIEN_LNV.Where(x => x.ID_LoaiNV == 7).Select(x => new { tenNV = x.NHANVIEN.hoten, NVID = x.NV_ID, x.NHANVIEN.somay }).OrderBy(x => x.somay).ToList();
            dmNhanVien.Add(new NHANVIEN() { NV_ID = 0, hoten = "Tất cả" });
            foreach (var item in nhanvien)
            {
                dmNhanVien.Add(new NHANVIEN() { NV_ID = item.NVID, hoten = item.somay + " - " + item.tenNV });
            }
            cboNV.DataSource = dmNhanVien.ToList();
            cboNV.ValueMember = "NV_ID";
            cboNV.DisplayMember = "hoten";
            cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
            // dm dot
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";
            cboDot.DropDownStyle = ComboBoxStyle.DropDownList;
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
        }
    }
}
