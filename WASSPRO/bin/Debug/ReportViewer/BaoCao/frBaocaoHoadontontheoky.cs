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
    public partial class frBaocaoHoadontontheoky : Form
    {
        SqlConnection cnn;
        public string so_hd, tuky, denky, timkiem;
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frBaocaoHoadontontheoky()
        {
            InitializeComponent();

        }

        private void frBaocaoHoadonton_Load(object sender, EventArgs e)
        {
            string strconn = ConfigurationManager.ConnectionStrings["QLCongNo.Properties.Settings.CAPNUOC_TNCConnectionString"].ConnectionString.ToString();
            cnn = new SqlConnection(strconn);
            cnn.Open();
           
            txtTuky.Text = tuky;
            txtDenky.Text = denky;
            txtseri.Enabled = false;
            sumTong();
            CountSophathanh();
            HienthiDL();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDShoadonton_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtseri.Text = dgvDShoadonton[1, dgvDShoadonton.CurrentRow.Index].Value.ToString();
            txtSohoadon.Text = dgvDShoadonton[2, dgvDShoadonton.CurrentRow.Index].Value.ToString();
            txtDanhbo.Text = dgvDShoadonton[6, dgvDShoadonton.CurrentRow.Index].Value.ToString();
        }
      
        public void CountSophathanh()
        {
            if (dgvDShoadonton.RowCount > 1)
            {
                int sc = dgvDShoadonton.Rows.Count;
                int sph = 0;
                for (int i = 0; i < sc - 1; i++)
                    sph = sc - 1;
                txtTongSPH.Text = sph.ToString();
            }
            else
            {
                txtTongSPH.Text = "";
            }
        }
        
        public void sumTong()
        {
            int sc = dgvDShoadonton.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dgvDShoadonton.Rows[i].Cells[13].Value.ToString());
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

            string strTimkiem = "select ROW_NUMBER() OVER(ORDER BY HOADON.SO_HD ASC) TT, CONCAT(HOADON.KY_HIEU_HD, HOADON.SO_HD)seri,HOADON.SO_HD,CONCAT(DM_KYGHI.ID_kyghi,'/',DM_KYGHI.nam)kyHD,HOADON.SOPHATHANH," +
        "HOADON.hoten,HOADON.diachihoadon,HOADON.tongtien from HOADON,DM_KYGHI WHERE HOADON.kyghi=DM_KYGHI.ID_kyghi and HOADON.IsInHD=1 and HOADON.tongtien!=0 and SO_HD=@id";
            SqlCommand cmd = new SqlCommand(strTimkiem, cnn);
            cmd.Parameters.AddWithValue("id", txtSearch.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvDShoadonton.DataSource = dt;
        }
        public void HienthiDL()
        {
            string strSlect = "select ROW_NUMBER() OVER(ORDER BY HOADON.SO_HD ASC) TT, CONCAT(HOADON.KY_HIEU_HD, HOADON.SO_HD)seri,HOADON.SO_HD,CONCAT(DM_KYGHI.ID_kyghi,'/',DM_KYGHI.nam)kyHD,HOADON.SOPHATHANH,HOADON.DANHBO" +
        "HOADON.hoten,HOADON.diachihoadon,HOADON.tongtien from HOADON,DM_KYGHI where HOADON.kyghi=DM_KYGHI.ID_kyghi and HOADON.IsInHD=1 and HOADON.tongtien!=0 and HOADON.kyghi between @tuky and @denky";
            SqlCommand cmd = new SqlCommand(strSlect, cnn);
            cmd.Parameters.AddWithValue("tuky", tuky);
            cmd.Parameters.AddWithValue("denky", denky);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvDShoadonton.DataSource = dt;
        }
       
        private void frBaocaoHoadontontheoky_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnn.Close();
         }

        
    
        }
}
