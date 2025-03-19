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
    public partial class UcXuLyHoaDon : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcXuLyHoaDon()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            btnUpdate.Click += btnUpdate_Click;
            btnThoat.Click += btnThoat_Click;
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
        //    this.Close();
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Hiện tại không có dữ liệu để tạo quyết định điều chỉnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult rs = MessageBox.Show("Bạn có tạo quyết định điều chỉnh " + cboDC.Text + " cho hóa đơn này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    decimal IDHD = decimal.Parse(dataGridView1.SelectedRows[i].Cells[IDHDColumn.Name].Value.ToString());
                    var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                    var pb = db.PublishedInvoices.Where(x => x.IDHD == IDHD && (x.GACH_NO == null || x.GACH_NO == "0")).FirstOrDefault();
                    int trangthai = int.Parse(cboDC.SelectedValue.ToString());
                    var isyeucau = db.YEUCAU_DIEUCHINH.Where(x => x.IDHD == IDHD && x.trangthai == 0).FirstOrDefault();
                    if (isyeucau == null && pb != null)
                    {
                        YEUCAU_DIEUCHINH yeucau = new YEUCAU_DIEUCHINH();
                        yeucau.IDKH = hoadon.ID_KH;
                        yeucau.user_create = Common.NVID;
                        yeucau.date_create = DateTime.Now;
                        yeucau.IDHD = IDHD;
                        yeucau.IDKH = hoadon.ID_KH;
                        yeucau.loaiDC = trangthai;
                        yeucau.trangthai = 0;
                        yeucau.kyghi = hoadon.kyghi;
                        yeucau.isBOT = false;
                        yeucau.isCTY = false;
                        yeucau.isDG = false;
                        yeucau.isDH = false;
                        yeucau.isDS = false;
                        yeucau.isIn = false;
                        yeucau.iskhac = false;
                        yeucau.isMH = false;
                        yeucau.isTB = false;
                        yeucau.isTCT = false;
                        db.YEUCAU_DIEUCHINH.Add(yeucau);
                        db.SaveChanges();
                    }
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnTim.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            if(txtTim.Text != "")
            {
                dataGridView1.AutoGenerateColumns = false;
                var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == (txtTim.Text.Replace(" ", String.Empty))).FirstOrDefault();
                if (khachhang == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng với mã danh bộ đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var dsHoadon = db.getDSHoaDon_KH(khachhang.ID_KH).ToList();
                if (dsHoadon == null || dsHoadon.Count == 0)
                {
                    MessageBox.Show("Không có hóa đơn nào cho khách hàng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dsHoadon.Count > 0)
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                dataGridView1.DataSource = dsHoadon.ToList();
                lblsl.Text = "Số lượng: " + string.Format("{0:n0}", dsHoadon.Count());
                for (int i = 0; i < dsHoadon.Count(); i++)
                    dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i + 1;
            }
            else
                MessageBox.Show("Chưa nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void frXuLyHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var loaiDC = db.DM_TRANGTHAIHOADON.Where(x =>x.trangthai_id == 3 ||x.trangthai_id== 4 || x.trangthai_id == 5).ToList();
            cboDC.DataSource = loaiDC;
            cboDC.DisplayMember = "Trangthai";
            cboDC.ValueMember = "trangthai_id";
            cboDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
