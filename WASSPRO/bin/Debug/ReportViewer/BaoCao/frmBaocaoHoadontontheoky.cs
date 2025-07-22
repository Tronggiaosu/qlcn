using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.BaoCao
{
    public partial class frmBaocaoHoadontontheoky : Form
    {
       
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frmBaocaoHoadontontheoky()
        {
            InitializeComponent();

        }

        private void frBaocaoHoadonton_Load(object sender, EventArgs e)
        {
            Loaddenky();
            Loadtuky(); 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Loadtuky()
        {
            var tuky1 = db.DM_KYGHI.ToList();
            cboTuky.DataSource = tuky1.ToList();
            cboTuky.DisplayMember = "ten_kyghi";
            cboTuky.ValueMember = "id_kyghi";
        }
        public void Loaddenky()
        {
            var denky1 = db.DM_KYGHI.ToList();
            cboDenKy.DataSource = denky1.ToList();
            cboDenKy.DisplayMember = "ten_kyghi";
            cboDenKy.ValueMember = "id_kyghi";
        }

        public void CountSophathanh()
        {
            if (dgvDShoadonton.RowCount > 1)
            {
                int sp = dgvDShoadonton.Rows.Count;
                txtTongSPH.Text = sp.ToString("###,##0.###");

            }
            else
            {
                txtTongSPH.Text = "0";
            }
           
        }
        
        public void sumTong()
        {
              int sc = dgvDShoadonton.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dgvDShoadonton.Rows[i].Cells[10].Value.ToString());
            
            txtTong.Text = string.Format("{0:#,##0.###}", float.Parse(thanhtien.ToString()));
         }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            frmChitiethoadonton frm = new frmChitiethoadonton();
            frm.MdiParent = this.MdiParent;
            frm.Dock = DockStyle.Fill;
            frm.id_hd = dgvDShoadonton[2, dgvDShoadonton.CurrentRow.Index].Value.ToString();
            frm.Show();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            var sl = from a in db.HOADONs
                     join b in db.DM_KYGHI
                     on a.kyghi equals b.ID_kyghi

                     select new
                     {
                         kyhoadon = b.ID_kyghi + "/" + b.nam,
                         seri = a.KY_HIEU_HD + "" + a.SO_HD,
                         a.SO_HD,
                         a.SOPHATHANH,
                         a.hoten,
                         a.diachi,
                         a.tongtien

                     };

            string input = txtSearch.Text;

            sl = sl.Where(x => x.SO_HD.ToString() == input || x.diachi.Contains(input) || x.SOPHATHANH == input || x.hoten.Contains(input));

            dgvDShoadonton.DataSource = sl.OrderBy(x => x.SO_HD).ThenBy(x => x.SO_HD).ToList();
            
        }
       
        private void btnXembaocao_Click(object sender, EventArgs e)
        {
            string tk = cboTuky.SelectedValue.ToString();
            string dk = cboDenKy.SelectedValue.ToString();
            var data = db.getBaocaoHoadonton(tk, dk, txtNam.Text).ToList();
            dgvDShoadonton.DataSource = data.ToList();

            CountSophathanh();
            sumTong();
        }
      
    
        }
}
