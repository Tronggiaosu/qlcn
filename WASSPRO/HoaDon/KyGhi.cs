using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class KyGhi : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        int addnew = 0;
        public KyGhi()
        {
            InitializeComponent();
        }

        private void KyGhi_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            var kyghi = from k in db.DM_KYGHI orderby k.ID_kyghi descending select k;
            dataGridView1.DataSource = kyghi.ToList();
            SetSelectRow(0);
            EnableControl(false);
        }

        private void DisplayText(DataGridViewRow row)
        {
            ClearText();
            txtIDKyghi.Text = row.Cells[0].Value.ToString();
            txtTenkyghi.Text = row.Cells[1].Value.ToString();
            txtThang.Text = row.Cells[2].Value.ToString();
            txtNam.Text = row.Cells[3].Value.ToString();

            DtNgaytao.Value = Convert.ToDateTime(row.Cells[4].Value.ToString());
          
            //if (row.Cells[6].Value.ToString() == "true")
            //{
            //    chkChuyenno.Checked = true;
            //}
            //else
            //{
            //    chkChuyenno.Checked = false;
            //}

            //chkChuyenno.Checked = Int32.Parse(row.Cells[5].Value.ToString());

        }
        private void SetSelectRow(int i)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.CurrentCell = null;

                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                DisplayText(row);
            }
        }

        private void ClearText()
        {
            txtIDKyghi.Text = "";
            txtTenkyghi.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
        }
        private void EnableControl(bool p)
        {
            txtIDKyghi.Enabled = p;
            txtTenkyghi.Enabled = p;
            txtThang.Enabled = p;
            txtNam.Enabled = p;
            DtNgaytao.Enabled = p;
            dataGridView1.Enabled = !p;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (addButton.Text == "Thêm")
            {
                EnableControl(true);
                ClearText();
                txtIDKyghi.Text = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("00");
                txtTenkyghi.Text = DateTime.Today.Month.ToString("00") + "/" + DateTime.Today.Year.ToString();
                txtThang.Text = DateTime.Today.Month.ToString();
                txtNam.Text = DateTime.Today.Year.ToString();
                DtNgaytao.Value = DateTime.Today;
                addButton.Text = "Cập nhật";
                editButton.Text = "Hủy";
                addnew = 1;
            }
            else if (addButton.Text == "Cập nhật" && addnew == 1)
            {
                if (!IsDataOK()) return;
                var kycu = (from a in db.DM_KYGHI orderby a.ID_kyghi descending select a).FirstOrDefault();
                var kyghicu = new SqlParameter("@ID_KYGHI", kycu.ID_kyghi);
                var t = new DM_KYGHI
                {
                    ID_kyghi = txtIDKyghi.Text,
                    ten_kyghi = txtTenkyghi.Text,
                    thang = Int32.Parse(txtThang.Text),
                    nam = Int32.Parse(txtNam.Text),
                    ngaytao = DtNgaytao.Value,
                    ngaycapnhat = DtNgaytao.Value,                   
                    gachno = false,
                    thuno = true,
                    ghinuoc = true,
                    hoadon = true
                };
                db.DM_KYGHI.Add(t);
                var other = from u in db.DM_KYGHI where u.ID_kyghi != txtIDKyghi.Text select u;
                foreach (DM_KYGHI kg in other)
                    kg.hoadon = false;
                db.SaveChanges();
               
                //var kyghimoi = new SqlParameter("@ID_KYGHI_MOI", txtIDKyghi.Text);
                //var chiso = db.Database.ExecuteSqlCommand("exec KYGHI @ID_KYGHI,@ID_KYGHI_MOI", kyghicu, kyghimoi);
                var kyghi = from k in db.DM_KYGHI orderby k.ID_kyghi descending select k;
                dataGridView1.DataSource = kyghi.ToList();
                SetSelectRow(0);
                EnableControl(false);
                addButton.Text = "Thêm";
                editButton.Text = "Sửa";
                addnew = 0;

            } 
            

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (editButton.Text == "Sửa")
            {
                EnableControl(true);
                txtIDKyghi.Enabled = false;
                addButton.Text = "Cập nhật";
                editButton.Text = "Hủy";
                addnew = 2;
            }
            else if (editButton.Text == "Hủy")
            {
                addButton.Text = "Thêm";
                editButton.Text = "Sửa";
                EnableControl(false);
                var kyghi = from k in db.DM_KYGHI orderby k.ID_kyghi descending select k;
                dataGridView1.DataSource = kyghi.ToList();
                SetSelectRow(0);
            }
            
        }
        private bool IsDataOK()
        {
            if (txtIDKyghi.Text.Trim() == "" || txtTenkyghi.Text.Trim() == "" )
            {
                MessageBox.Show("Thông tin chưa đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                if (addnew ==1)
                {
                    var kyghi = (from a in db.DM_KYGHI where a.ID_kyghi == txtIDKyghi.Text.Trim() select a.ID_kyghi).ToList();
                    if (kyghi.Count > 0)
                    {
                        MessageBox.Show("Kỳ Ghi đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            return true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
