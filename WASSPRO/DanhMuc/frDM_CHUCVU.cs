using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.BLL;

namespace QLCongNo.DanhMuc
{
    public partial class frDM_CHUCVU : Form
    {
      
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        string id,tencv;
        public frDM_CHUCVU()
        {
            InitializeComponent();
           
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dataGridView1["IDColumn", e.RowIndex].Value.ToString();
                tencv = dataGridView1["TenCVColumn", e.RowIndex].Value.ToString();
                txtTenChucVu.Text = tencv;
            }
            catch
            {

            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                dataGridView1.Enabled = false;
                btnSua.Visible = false;
                btnThem.Text = "Lưu";
                txtTenChucVu.Text = "";

                btnHuy.Visible = true;
            }
            else
            {
                btnThem.Text = "Lưu";
                string TenChucVu = txtTenChucVu.Text;
                if (TenChucVu != "")
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn thêm chức vụ này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        //thêm mới
                        DM_CHUCVU cv1 = new DM_CHUCVU();
                        var countID = from a in db.DM_CHUCVU select a.ChucvuID;
                        int sttmax = 0;
                        if (countID.Count() > 0)
                            sttmax = countID.Max() + 1;
                        else
                            sttmax = 1;
                        cv1.ChucvuID = sttmax;
                        cv1.Tenchucvu = TenChucVu;
                        db.DM_CHUCVU.Add(cv1);
                        db.SaveChanges();
                        //
                        MessageBox.Show("Thêm thành công!");
                        btnThem.Visible = true;
                        btnSua.Visible = true;
                        dataGridView1.Enabled = true;
                        btnThem.Text = "Thêm";
                        btnSua.Text = "Sửa";
                        btnHuy.Visible = false;
                        txtTenChucVu.Text = "";
                        LoadData();
                    }
                    else
                    {
                      
                        btnThem.Visible = true;
                        btnSua.Visible = true;
                        dataGridView1.Enabled = true;
                        btnThem.Text = "Thêm";
                        btnSua.Text = "Sửa";
                        btnHuy.Visible = false;
                        txtTenChucVu.Text = "";
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnThem.Visible = false;
                btnSua.Text = "Lưu";
                btnHuy.Visible = true;
            }
            else
            {
                btnHuy.Visible = true;
                btnSua.Text = "Lưu";
                string tenchucvu = txtTenChucVu.Text;
                if (tenchucvu != "")
                {
                    DialogResult rs = MessageBox.Show("Bạn có muốn cập nhật chức vụ này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (rs == DialogResult.OK)
                    {
                        // sua

                        int idcv = Convert.ToInt32(id);
                        var cv = (from a in db.DM_CHUCVU where a.ChucvuID == idcv select a).FirstOrDefault();
                        cv.Tenchucvu = tenchucvu;
                        db.SaveChanges();
                        //
                        
                        MessageBox.Show("Cập nhật thành công!");
                        btnThem.Visible = true;
                        btnSua.Visible = true;
                        dataGridView1.Enabled = true;
                        btnThem.Text = "Thêm";
                        btnSua.Text = "Sửa";
                        btnHuy.Visible = false;
                        txtTenChucVu.Text = "";
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frDM_CHUCVU_Load(object sender, EventArgs e)
        {
            btnHuy.Visible = false;
            LoadData();           
        }
        public void LoadData()
        {
            var dataCV = from a in db.DM_CHUCVU select a;
            dataGridView1.DataSource = dataCV.ToList();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Visible = false;
            btnThem.Visible = true;
            btnHuy.Visible = false;
            btnSua.Visible = true;
            dataGridView1.Enabled = true;

            btnThem.Text = "Thêm";
            btnSua.Text = "Sửa";
            txtTenChucVu.Text = "";
            LoadData();
        }
      
    }
}
