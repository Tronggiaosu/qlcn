using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLCongNo.View.UC.DanhMuc
{
    public partial class UcDM_KyGhi : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcDM_KyGhi()
        {
            InitializeComponent();
            btnSua.Click += btnSua_Click;
            btnThoat.Click += btnThoat_Click;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //    this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string kyghi = cboKy.SelectedValue.ToString();
            int nam = int.Parse("20" + cboNam.SelectedValue.ToString());
            int day = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            if (int.Parse(kyghi) < day || nam < year)
                MessageBox.Show("Vui lòng chọn tháng, năm lớn hơn bằng tháng, năm hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn cập nhât kỳ hành thu?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    decimal thangps = decimal.Parse(nam.ToString() + kyghi);
                    db.Database.ExecuteSqlCommand("update PublishedInvoices set HD_TON = 1 where thang_ps < " + thangps + "");
                    db.Database.ExecuteSqlCommand("update DM_KYGHI set hoadon = 0 ");
                    var NVLap = db.NGUOIDUNGs.Where(x => x.ma_nd == Common.username).FirstOrDefault();
                    var datakyghi = db.DM_KYGHI.Where(x => x.ID_kyghi == kyghi).FirstOrDefault();
                    LOG_USER log = new LOG_USER();
                    log.nguoidung_id = NVLap.nv_id;
                    log.ghichu = "Cập nhật kỳ hành thu " + datakyghi.ID_kyghi + datakyghi.dot.ToString() + datakyghi.nam.ToString() + " thành "
                                 + kyghi + " - " + nam.ToString();
                    log.ngay_sd = DateTime.Now;
                    db.LOG_USER.Add(log);
                    db.SaveChanges();
                    datakyghi.hoadon = true;
                    datakyghi.nam = int.Parse(cboNam.SelectedValue.ToString());
                    datakyghi.user_create = NVLap.nv_id;
                    datakyghi.ngaytao = DateTime.Now;
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var dataSource = db.DM_KYGHI.Where(x => x.hoadon == true).Select(x => new
                    {
                        x.NHANVIEN.hoten,
                        x.ten_kyghi,
                        x.dot,
                        x.nam,
                        x.ngaytao
                    }).ToList();
                    dataGridView1.DataSource = dataSource.ToList();
                }
            }
        }

        private void frDM_KyGhi_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            // dm ky ghi
            cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            //dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.OrderBy(x => x.ten_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            cboKy.DataSource = dmKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            // dm nam
            cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            //dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
            var dataSource = db.DM_KYGHI.Where(x => x.hoadon == true).Select(x => new
            {
                x.NHANVIEN.hoten,
                x.ten_kyghi,
                x.dot,
                x.nam,
                x.ngaytao
            }).ToList();
            dataGridView1.DataSource = dataSource.ToList();
        }
    }
}