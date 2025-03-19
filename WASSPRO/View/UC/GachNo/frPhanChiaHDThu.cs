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
    public partial class UcPhanChiaHDThu : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public decimal ID; // idnhavien hoadon
        public UcPhanChiaHDThu()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnEX.Click += btnEX_Click;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            btnXoa.Click += btnXoa_Click;
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa hóa đơn này khỏi danh sách thu?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                string IDHD = dataGridView1.SelectedRows[0].Cells[IDHDColumn.Name].Value.ToString();
                var published = db.PublishedInvoices.Where(x => x.KEY == IDHD).FirstOrDefault();
                published.NVID_THU = null;
                db.SaveChanges();
                var nhanvien_create = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                LOG_USER log = new LOG_USER();
                log.ngay_sd = DateTime.Now;
                log.ghichu = "Xóa hơn đơn khỏi danh sách thu, " + published.SO_HD + " - mã hóa đơn " + published.KEY;
                log.nguoidung_id = nhanvien_create.nguoidung_id;
                db.LOG_USER.Add(log);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTim.PerformClick();
            }
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var nhavienHD = db.NHANVIEN_HOADON.Where(x => x.ID == ID).FirstOrDefault();
                    string thangps = "20" + nhavienHD.Nam.ToString();
                    string quan = cboQuan.SelectedValue.ToString();
                    string phuong = cboPhuong.SelectedValue.ToString();
                    decimal loaiHD = decimal.Parse(cboloaiHD.SelectedValue.ToString());
                    string MGB = cboDTSD.SelectedValue.ToString();
                    var dataSource = db.getDSHoadonchiachoTNV(nhavienHD.CUON_GCS, nhavienHD.DOT_ID, thangps, nhavienHD.TuLT, nhavienHD.DenLT, nhavienHD.NV_ID).ToList();
                    if (quan != "0")
                        dataSource = dataSource.Where(x => x.quan == quan).ToList();
                    if (phuong != "0")
                        dataSource = dataSource.Where(x => x.phuong == phuong).ToList();
                    if (loaiHD != 0)
                        dataSource = dataSource.Where(x => x.LoaiHD_ID == loaiHD).ToList();
                    if (MGB != "0")
                        dataSource = dataSource.Where(x => x.MGB == MGB).ToList();
                    dataSource = dataSource.Where(x => x.timkiem.Contains(txtTim.Text.ToUpper())).ToList();
                    dataGridView1.DataSource = dataSource.OrderBy(x => x.SODB).ToList();
                    lblsoluong.Text = "Số lượng hóa đơn: " + string.Format("{0:n0}", dataGridView1.RowCount);
                }
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            var nhavienHD = db.NHANVIEN_HOADON.Where(x => x.ID == ID).FirstOrDefault();
            string thangps = "20" + nhavienHD.Nam.ToString();
            string quan = cboQuan.SelectedValue.ToString();
            string phuong = cboPhuong.SelectedValue.ToString();
            decimal loaiHD = decimal.Parse(cboloaiHD.SelectedValue.ToString());
            string MGB = cboDTSD.SelectedValue.ToString();
            var dataSource = db.getChitietHoadonTNV(nhavienHD.CUON_GCS, nhavienHD.DOT_ID, thangps, nhavienHD.TuLT, nhavienHD.DenLT, nhavienHD.NV_ID).ToList();
            if (quan != "0")
                dataSource = dataSource.Where(x => x.quan == quan).ToList();
            if (phuong != "0")
                dataSource = dataSource.Where(x => x.phuong == phuong).ToList();
            if (loaiHD != 0)
                dataSource = dataSource.Where(x => x.LoaiHD_ID == loaiHD).ToList();
            if (MGB != "0")
                dataSource = dataSource.Where(x => x.MGB == MGB).ToList();
            dataGridView1.DataSource = dataSource.OrderBy(x=>x.SODB).ToList();
            lblsoluong.Text = "Số lượng hóa đơn: " + string.Format("{0:n0}", dataGridView1.RowCount);
        }

        void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            var maQuan = cboQuan.SelectedValue.ToString();
            if (maQuan != "0")
            {
                // dm phuong
                cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                var dataPhuong = db.DM_PHUONG.Where(x => x.maQuan == maQuan).OrderBy(x => x.tenPhuong).ToList();
                dsPhuong.AddRange(dataPhuong);
                cboPhuong.DataSource = dsPhuong.ToList();
                cboPhuong.ValueMember = "maPhuong";
                cboPhuong.DisplayMember = "tenPhuong";
            }
            else
            {
                cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
                dsPhuong.AddRange(dataPhuong);
                cboPhuong.DataSource = dsPhuong.ToList();
                cboPhuong.ValueMember = "maPhuong";
                cboPhuong.DisplayMember = "tenPhuong";
            }
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
        //    this.Close();
        }

        private void frPhanChiaHDThu_Load(object sender, EventArgs e)
        {
            // dm phuong
            cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
            dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
            var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
            dsPhuong.AddRange(dataPhuong);
            cboPhuong.DataSource = dsPhuong.ToList();
            cboPhuong.ValueMember = "maPhuong";
            cboPhuong.DisplayMember = "tenPhuong";
            // dm quan
            cboQuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_QUAN> dsQuan = new List<DM_QUAN>();
            dsQuan.Add(new DM_QUAN() { maQuan = "0", tenQuan = "Tất cả" });
            var dataQuan = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
            dsQuan.AddRange(dataQuan);
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            // loai hoa don
            cboloaiHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_LOAIHOADON> dmLoaiHD = new List<DM_LOAIHOADON>();
            dmLoaiHD.Add(new DM_LOAIHOADON() { LoaiHD_ID = 0, tenloaiHD = "Tẩt cả" });
            var dataLoaiHD = db.DM_LOAIHOADON.OrderBy(x => x.tenloaiHD).ToList();
            dmLoaiHD.AddRange(dataLoaiHD);
            cboloaiHD.DataSource = dmLoaiHD.ToList();
            cboloaiHD.ValueMember = "LoaiHD_ID";
            cboloaiHD.DisplayMember = "tenloaiHD";
            // loai doi tuong su dung
            cboDTSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_DOITUONGSUDUNG> dataDTSD = new List<DM_DOITUONGSUDUNG>();
            dataDTSD.Add(new DM_DOITUONGSUDUNG() { maDT = "0", tenDT = "Tất cả" });
            var dsDT = db.DM_DOITUONGSUDUNG.OrderBy(x => x.tenDT).ToList();
            dataDTSD.AddRange(dsDT);
            cboDTSD.DataSource = dataDTSD.ToList();
            cboDTSD.ValueMember = "maDT";
            cboDTSD.DisplayMember = "tenDT";
            dataGridView1.AutoGenerateColumns = false;
        }
    }
}
