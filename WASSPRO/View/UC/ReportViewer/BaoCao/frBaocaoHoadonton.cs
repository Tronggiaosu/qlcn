using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcBaocaoHoadonton : View.Core.NovUserControl
    {
        CAPNUOC_TDCDataSet db = new CAPNUOC_TDCDataSet();
        public UcBaocaoHoadonton()
        {
            InitializeComponent();

        }

        private void frBaocaoHoadonton_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cAPNUOC_TDCDataSet.getBaocaoHoadonton1' table. You can move, or remove it, as needed.
            this.getBaocaoHoadonton1TableAdapter.Fill(this.cAPNUOC_TDCDataSet.getBaocaoHoadonton);
            // TODO: This line of code loads data into the 'cAPNUOC_TDCDataSet.getBaocaoHoadonton1' table. You can move, or remove it, as needed.
            this.getBaocaoHoadonton1TableAdapter.Fill(this.cAPNUOC_TDCDataSet.getBaocaoHoadonton1);
            // TODO: This line of code loads data into the 'cAPNUOC_TDCDataSet.getBaocaoHoadonton1' table. You can move, or remove it, as needed.
            this.getBaocaoHoadonton1TableAdapter.Fill(this.cAPNUOC_TDCDataSet.getBaocaoHoadonton1);

           //this.reportViewer1.RefreshReport();
            txtseri.Enabled = false;
            sumTong();
            SumLNTT();
            SUmtiennuoc();
            SumVAT();
            SumTienPhi();
            CountSophathanh();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            

        }

       
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            frmChitiethoadonton frm = new frmChitiethoadonton();
            frm.MdiParent = this.MdiParent;
            //foreach (Form otherForm in this.MdiChildren)
            //    if (otherForm != frm)
            //        otherForm.Close();
            frm.Dock = DockStyle.Fill;
            frm.id_hd = dgvDShoadonton[0, dgvDShoadonton.CurrentRow.Index].Value.ToString();
            frm.Show();
        }

        private void dgvDShoadonton_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtseri.Text = dgvDShoadonton[1, dgvDShoadonton.CurrentRow.Index].Value.ToString();
            
        }
        public void SumVAT()
        {
            int sc = dgvDShoadonton.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dgvDShoadonton.Rows[i].Cells[7].Value.ToString());
            txtTongVAT.Text = string.Format("{0:#,##0.###}", float.Parse(thanhtien.ToString()));
        }
        public void SUmtiennuoc()
        {
            int sc = dgvDShoadonton.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dgvDShoadonton.Rows[i].Cells[6].Value.ToString());
            txtTongTiennuoc.Text = string.Format("{0:#,##0.###}", float.Parse(thanhtien.ToString()));
        }
        public void SumLNTT()
        {
            int sc = dgvDShoadonton.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dgvDShoadonton.Rows[i].Cells[5].Value.ToString());
            txtTongLNTT.Text = string.Format("{0:#,##0.###}", float.Parse(thanhtien.ToString()));
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
        public void SumTienPhi()
        {
            int sc = dgvDShoadonton.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dgvDShoadonton.Rows[i].Cells[8].Value.ToString());
            txtTongPhi.Text = string.Format("{0:#,##0.###}", float.Parse(thanhtien.ToString()));
        }
        public void sumTong()
        {
            int sc = dgvDShoadonton.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < sc - 1; i++)
                thanhtien += float.Parse(dgvDShoadonton.Rows[i].Cells[9].Value.ToString());
            txtTong.Text = string.Format("{0:#,##0.###}", float.Parse(thanhtien.ToString()));

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        }
}
