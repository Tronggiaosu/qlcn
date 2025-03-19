using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.BLL;

namespace QLCongNo.View.UC.DanhMuc
{
    public partial class UcDM_PHONGBAN : View.Core.NovUserControl
    {
        Chinhanh_BLL cn = new Chinhanh_BLL();
        Phongban_BLL pb = new Phongban_BLL();
        DM_PHONGBAN PB_EN = new DM_PHONGBAN();
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        string mapb, tenPB_dgv, ghichu_dgv;
        public UcDM_PHONGBAN()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                dataGridView1.Enabled = false;
                btnSua.Visible = false;
                txtGhichu.Text = "";
                txtmaPB.Text = "";
                btnHuy.Visible = true;
                btnThem.Text = "Lưu";
                txtmaPB.Text = "";
            }
            else
            {
                btnThem.Text = "Lưu";
                string ten = txtTenPB.Text;
                string ghichu = txtGhichu.Text;
                string maCN = cboCN.SelectedValue.ToString();
                if (ten != "")
                {
                    string ten_db = pb.get_tenPB(ten);
                    if (ten_db == null)
                    {
                        DialogResult rs = MessageBox.Show("Bạn có muốn thêm mới phòng ban này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (rs == DialogResult.OK)
                        {
                          //
                            DM_PHONGBAN pb1 = new DM_PHONGBAN();
                            var countID = from a in db.DM_PHONGBAN select a.maPB;
                            int sttmax = 0;
                            if (countID.Count() > 0)
                                sttmax = Convert.ToInt32(countID.Max()) + 1;
                            else
                                sttmax = 1;
                            pb1.maPB = sttmax.ToString() ;
                            pb1.tenPB = txtTenPB.Text;
                            pb1.mota = txtGhichu.Text;
                            pb1.maCN = cboCN.SelectedValue.ToString();
                            db.DM_PHONGBAN.Add(pb1);
                            db.SaveChanges();
                             //

                            MessageBox.Show("Thêm thành công!");
                           // btnHuy.Visible = false;
                            btnThem.Visible = true;
                           // btnHuy.Visible = false;
                            btnSua.Visible = true;
                            txtmaPB.Text = "";
                            txtTenPB.Text = "";
                            txtGhichu.Text = "";
                            btnThem.Text = "Thêm";
                            btnHuy.Visible = false;
                            dataGridView1.Enabled = true;
                            LoadData();
                        }
                        else
                        {
                            //btnHuy.Visible = false;
                            btnThem.Visible = true;
                            //btnHuy.Visible = false;
                            btnSua.Visible = true;
                            btnThem.Text = "Thêm";
                            txtmaPB.Text = "";
                            txtTenPB.Text = "";
                            txtGhichu.Text = "";
                            btnHuy.Visible = false;
                            dataGridView1.Enabled = true;
                            LoadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên phòng ban đã tồn tại, vui lòng nhập tên khác!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên phòng ban!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnThem.Visible = false;
                btnHuy.Visible = true;
                btnSua.Text = "Lưu";
            }
            else
            {
                btnSua.Text = "Lưu";
                string ten = txtTenPB.Text;
                string ghichu = txtGhichu.Text;
                string maCN = cboCN.SelectedValue.ToString();
                string maPB = txtmaPB.Text;
                if (ten == "")
                {
                    MessageBox.Show("Vui lòng nhập tên phòng ban!");
                }
                else
                {
                    if (ten != tenPB_dgv)
                    {
                        string ten_db = pb.get_tenPB(ten);
                        if (ten_db == null)
                        {
                            DialogResult rs = MessageBox.Show("Bạn có muốn cập nhật phòng ban này?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (rs == DialogResult.OK)
                            {
                                //int idcv = Convert.ToInt32(id);
                                var pb1 = (from a in db.DM_PHONGBAN where a.maPB == maPB select a).FirstOrDefault();
                                pb1.tenPB = ten;
                                pb1.mota = ghichu;
                                pb1.maCN = maCN;
                                db.SaveChanges();
                                //
                                MessageBox.Show("Cập nhật thành công!");
                                //btnHuy.Visible = false;
                                btnThem.Visible = true;
                                //btnHuy.Visible = false;
                                btnSua.Visible = true;
                                btnSua.Text = "Sửa";
                                txtmaPB.Text = "";
                                txtTenPB.Text = "";
                                txtGhichu.Text = "";
                                btnHuy.Visible = false;
                                dataGridView1.Enabled = true;
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Tên phòng ban đã tồn tại, vui lòng nhập tên khác!");
                            }
                        }
                        else if (ten == tenPB_dgv && ghichu != ghichu_dgv)
                        {
                            DialogResult rs = MessageBox.Show("Bạn có muốn cập nhật phòng ban này?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (rs == DialogResult.OK)
                            {
                                //int idcv = Convert.ToInt32(id);
                                var pb1 = (from a in db.DM_PHONGBAN where a.maPB == maPB select a).FirstOrDefault();
                                pb1.tenPB = ten;
                                pb1.mota = ghichu;
                                pb1.maCN = maCN;
                                db.SaveChanges();
                                //
                                MessageBox.Show("Cập nhật thành công!");
                               // btnHuy.Visible = false;
                                btnThem.Visible = true;
                                btnSua.Text = "Sửa";
                                //btnHuy.Visible = false;
                                btnSua.Visible = true;
                                txtmaPB.Text = "";
                                txtTenPB.Text = "";
                                txtGhichu.Text = "";
                                btnHuy.Visible = false;
                                dataGridView1.Enabled = true;
                                LoadData();
                            }
                        }
                    }
                }
            }
        }

       
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                 mapb = dataGridView1["MaPhongColumn", index].Value.ToString();
                 txtmaPB.Text = mapb;
                tenPB_dgv = dataGridView1["TenPhongColumn", index].Value.ToString();
                txtTenPB.Text = tenPB_dgv;
                ghichu_dgv = dataGridView1["mota", index].Value.ToString();
                txtGhichu.Text = ghichu_dgv;
            }
            catch
            {

            }
        }

        private void frDM_PHONGBAN_Load(object sender, EventArgs e)
        {
            txtmaPB.Text = "";
            txtTenPB.Text = "";
            txtmaPB.Enabled = false;
            btnHuy.Visible = false;
            var chinhanh = from a in db.CHINHANHs select a;
            cboCN.DataSource = chinhanh.ToList();
            cboCN.ValueMember = "maCN";
            cboCN.DisplayMember = "tenCN";
            LoadData();
        }
        
        public void LoadData()
        {
            string cn = cboCN.SelectedValue.ToString();            
            var dataPB = from a in db.DM_PHONGBAN where a.maCN== cn select a;
            dataGridView1.DataSource = dataPB.ToList();
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
            txtmaPB.Text = "";
            txtTenPB.Text = "";
            txtGhichu.Text = "";
            LoadData();
        }
    }
}
