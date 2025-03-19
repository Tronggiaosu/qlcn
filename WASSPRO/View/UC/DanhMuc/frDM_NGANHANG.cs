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
    public partial class UcDM_NGANHANG : View.Core.NovUserControl
    {
       
        string manh, tennh,loainh;
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        decimal id=0;
        public UcDM_NGANHANG()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                btnSua.Text = "Lưu";
                string ten = txtTenNH.Text;
                string ma = txtMaNH.Text;
                btnHuy.Visible = true;
                string loai = txtLoai.Text;
                if (ten == "")
                {
                    MessageBox.Show("Vui lòng nhập tên phòng ban!");
                }
                else
                {
                            DialogResult rs = MessageBox.Show("Bạn có muốn cập nhật ngân hàng này?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (rs == DialogResult.OK)
                            {
                               //
                               
                                var nh = (from a in db.DM_NGANHANG where a.NGANHANG_ID == id select a).FirstOrDefault();
                                nh.TENNGANHANG = ten;
                                nh.MA_NGANHANG=ma;
                                nh.LOAI=loai;
                                db.SaveChanges();
                                //

                                MessageBox.Show("Cập nhật thành công!");
                                btnHuy.Visible = false;
                                btnThem.Visible = true;
                                
                                btnSua.Visible = true;
                                btnSua.Text = "Sửa";
                                txtMaNH.Text = "";
                                txtTenNH.Text = "";
                                txtLoai.Text = "";
                                dataGridView1.Enabled = true;
                                Loaddata();
                            }
                            else
                            {
                                MessageBox.Show("Vui lòng nhập thông tin ngân hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
                            }
                        
                    
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                id = Convert.ToDecimal(dataGridView1["DotITColumn", index].Value.ToString());
                manh = dataGridView1["Ma_Nganhang", index].Value.ToString();
                txtMaNH.Text = manh;
                tennh = dataGridView1["TenNHColumn", index].Value.ToString();
                txtTenNH.Text = tennh;
                loainh = dataGridView1["loai11", index].Value.ToString();
                txtLoai.Text = loainh;
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
                txtTenNH.Text = "";
                txtMaNH.Text = "";
                txtLoai.Text = "";
                btnHuy.Visible = true;
                btnThem.Text = "Lưu";
            }
            else
            {
                btnThem.Text = "Lưu";
                string ten = txtTenNH.Text;
                string ma = txtMaNH.Text;
                string loai = txtLoai.Text;
                if (ten != "")
                {
                        DialogResult rs = MessageBox.Show("Bạn có muốn thêm mới ngân hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (rs == DialogResult.OK)
                        {
                            //
                            DM_NGANHANG nh=new DM_NGANHANG();
                            var count_id = from a in db.DM_NGANHANG select a.NGANHANG_ID;
                            decimal sttmax = 0;
                            if (count_id.Count() > 0)
                                sttmax = count_id.Max() + 1;
                            else
                                sttmax = 1;
                            nh.NGANHANG_ID = sttmax;
                            nh.TENNGANHANG = ten;
                            nh.MA_NGANHANG = ma;
                            nh.LOAI = loai;
                            var cound_dv = from b in db.DM_NGANHANG select b.MADV;
                            int dvMax = 0;
                            if (cound_dv.Count() > 0)
                                dvMax = Convert.ToInt32(cound_dv.Max()) + 1;
                            else
                                dvMax = 1;
                            nh.MADV = dvMax.ToString();
                            db.DM_NGANHANG.Add(nh);
                            db.SaveChanges();
                            //
                            MessageBox.Show("Thêm thành công!");
                            btnHuy.Visible = false;
                            btnThem.Visible = true;
                            btnSua.Visible = true;
                            txtMaNH.Text = "";
                            txtTenNH.Text = "";
                            txtLoai.Text = "";
                            btnThem.Text = "Thêm";
                            dataGridView1.Enabled = true;
                            Loaddata();
                        }
                        else
                        {
                            btnThem.Visible = true;
                            btnSua.Visible = true;
                            btnThem.Text = "Thêm";
                            txtMaNH.Text = "";
                            txtTenNH.Text = "";
                            txtLoai.Text = "";
                            dataGridView1.Enabled = true;
                            Loaddata();
                        }
                    }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin ngân hàng!");
                }
            }
        }

        private void frDM_NGANHANG_Load(object sender, EventArgs e)
        {
            txtLoai.Text = "";
            txtMaNH.Text = "";
            txtTenNH.Text = "";
            btnHuy.Visible = false;
            Loaddata();  
        }
        public void Loaddata()
        {
            var dataNH = from a in db.DM_NGANHANG select a;
            dataGridView1.DataSource = dataNH.ToList();
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
            txtLoai.Text = "";
            txtMaNH.Text = "";
            txtTenNH.Text = "";
            Loaddata();
        }
    }
}
