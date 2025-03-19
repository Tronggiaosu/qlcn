using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.DanhMuc;

namespace QLCongNo.GachNo
{
    public partial class frGachNoHDKhongDong : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frGachNoHDKhongDong()
        {
            InitializeComponent();
            cboTo.SelectedIndexChanged += cboTo_SelectedIndexChanged;
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            btnThoat.Click += btnThoat_Click;
            btnEX.Click += btnEX_Click;
            btnConfirm.Click += btnConfirm_Click;
        }

        void btnConfirm_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (dataGridView1.RowCount > 0)
                {

                    DialogResult rs = MessageBox.Show("Bạn có đồng ý thanh toán?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        var pkyghi = db.DM_KYGHI.Where(x => x.gachno == true).FirstOrDefault();
                        int DOTID = int.Parse(cboDot.SelectedValue.ToString());
                        int TOID = int.Parse(cboTo.SelectedValue.ToString());
                        string kyghi = cboKyHD.SelectedValue.ToString();
                        int NVID = int.Parse(cboNV.SelectedValue.ToString());
                        int NVLap = int.Parse(Common.NVID.ToString());
                        if (chkKy.Checked == false)
                            kyghi = "0";
                        if (chkNV.Checked == false)
                            NVID = 0;
                        if (chkTo.Checked == false)
                            TOID = 0;
                        CHUNGTU chungtu = new CHUNGTU();
                        chungtu.ID_KYGHI = pkyghi.ID_kyghi;
                        chungtu.MALOAI = "KH";
                        chungtu.NGAYLAP = DateTime.Now;
                        chungtu.NV_ID_LAP = Common.NVID;
                        chungtu.NV_ID_NOP = Common.NVID;
                        chungtu.TRANGTHAI = false;
                        chungtu.TONGTIEN = 0;
                        chungtu.NGAYCT = DateTime.Now;
                        db.CHUNGTUs.Add(chungtu);
                        db.SaveChanges();
                        db.gachno_thanhtoanhoadonkhongdong(DOTID, kyghi, TOID, NVID, NVLap, chungtu.ID_CT);
                        var chungtuGN = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT).Select(x => x.HOADON.ID_KH).Distinct().ToList();
                        string hashkey = "zBA5hONxY9W0Xz1oiUqKdH0xUExp0eXtpSaiBoFYwpqaR1frxyIlDZdfFx7xb8UCb//HyKdBx8QSBrDGOmhhHmikJhnYAILslxIsXS/E4C4zfJFOcE0AFU4rAUL4NPlv";
                        if (chungtuGN.Count() == 0)
                            db.CHUNGTUs.Remove(chungtu);
                        else
                        {
                            ServiceTDC.ThuHo tdc = new ServiceTDC.ThuHo();
                            foreach (var item in chungtuGN)
                            {
                                var dshoadon = db.CHUNGTU_HOADON.Where(x => x.ID_CT == chungtu.ID_CT && x.ID_KH == item).ToList();
                                object[] reseult = tdc.ThanhToanHoaDonList("WASS01", hashkey, dshoadon.Select(x => x.ID_HD.ToString()).ToArray(), dshoadon.FirstOrDefault().DANHBO, "", dshoadon.FirstOrDefault().GHICHU, Common.username, "TAIQUAY", "", "").ToArray();
                                dshoadon.FirstOrDefault().LOG_THUHO = reseult[0].ToString().ToUpper() + reseult[1].ToString().ToUpper();
                                db.SaveChanges();
                            }
                            db.Database.ExecuteSqlCommand("update a set a.GACH_NO = 1 from PublishedInvoices  a  where  (GACH_NO is null or GACH_NO = '0') and a.IDHD in (select id_hd from CHUNGTU_HOADON where id_ct = " + chungtu.ID_CT + " )");
                            db.Database.ExecuteSqlCommand("exec DANGNGAN_NV " + Common.NVID.ToString() + ", " + chungtu.ID_CT);
                            db.SaveChanges();
                            MessageBox.Show("Thanh toán thành công!");
                            btnTim.PerformClick();
                        }
                        
                    }
                }
                else
                    MessageBox.Show("Không có hóa đơn nào trong danh sách!");
            //}
            //catch
            //{

            //}
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                    btnTim.PerformClick();
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            int DOTID = int.Parse(cboDot.SelectedValue.ToString());
            int TOID = int.Parse(cboTo.SelectedValue.ToString());
            string kyghi = cboKyHD.SelectedValue.ToString();
            int NVID = int.Parse(cboNV.SelectedValue.ToString());
            if (chkKy.Checked == false)
                kyghi = "0";
            if (chkNV.Checked == false)
                NVID = 0;
            if (chkTo.Checked == false)
                TOID = 0;
            var data = db.getDSHoaDonKhongDong(DOTID, kyghi, TOID, NVID).OrderBy(x => x.DANHBO).ToList();
            if (txtTim.Text != "")
                data = data.Where(x => x.DANHBO.Contains(txtTim.Text)).OrderBy(x => x.DANHBO).ToList();
            dataGridView1.DataSource = data.ToList();
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i + 1;
            lblsoluong.Text = "Số lượng: " + string.Format("{0:n0}", data.Count());
        }

        void cboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
            {
                int TOID = int.Parse(cboTo.SelectedValue.ToString());
                LoadNhanVien(TOID);
            }
            catch
            {

            }
        }

        private void frGachNoHDKhongDong_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            loadDot();
            LoadKyghi();
            LoadNhanVien(Common.TOID);
            if (Common.TOID == 0)
                LoadTO(-1);
            else
                LoadTO(Common.TOID);
        }
        private void loadDot()
        {
            var dataDot = db.DM_DOT.OrderBy(x => x.DOT_ID).ToList();
            cboDot.DataSource = dataDot;
            cboDot.ValueMember = "dot_id";
            cboDot.DisplayMember = "dot_id";
        }
        public void LoadTO(decimal? TOID)
        {
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;
            var data = DataDanhMuc.getDSTo(TOID).ToList();
            cboTo.DataSource = data.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
        }
        private void LoadKyghi()
        {
            var dataKy = db.DM_KYGHI.OrderByDescending(x => x.ID_kyghi).ToList();
            cboKyHD.DataSource = dataKy;
            cboKyHD.ValueMember = "ID_Kyghi";
            cboKyHD.DisplayMember = "ten_kyghi";
        }
        public void LoadNhanVien(decimal? TOID)
        {
            cboNV.DropDownStyle = ComboBoxStyle.DropDownList;
            var data = DataDanhMuc.getDSNhanvien(TOID).Select(x => new { hoten = x.maNV + " - " + x.hoten, x.NV_ID }).ToList();
            cboNV.DataSource = data.ToList();
            cboNV.DisplayMember = "hoten";
            cboNV.ValueMember = "NV_ID";
        }
       
    }
}
