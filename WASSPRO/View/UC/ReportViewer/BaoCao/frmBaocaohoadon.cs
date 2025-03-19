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

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcBaocaohoadon : View.Core.NovUserControl
    {
        SqlConnection cnn;
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcBaocaohoadon()
        {
            InitializeComponent();
        }

        private void frmBaocaohoadon_Load(object sender, EventArgs e)
        {
            string strconn = ConfigurationManager.ConnectionStrings["QLCongNo.Properties.Settings.CAPNUOC_TNCConnectionString"].ConnectionString.ToString();
            cnn = new SqlConnection(strconn);
            cnn.Open();
            Loadtuky();
            Loaddenky();
            cbochonloaibaocao.SelectedIndex = 0;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
        }
        public void Loadtuky()
        {
            var dataKyghi = db.DM_KYGHI.ToList();
            cboTuky.DataSource = dataKyghi.ToList();
            cboTuky.DisplayMember = "ten_kyghi";
            cboTuky.ValueMember = "id_kyghi";
        }
        public void Loaddenky()
        {
            var dataKyghi = db.DM_KYGHI.ToList();
            cboDenky.DataSource = dataKyghi.ToList();
            cboDenky.DisplayMember = "ten_kyghi";
            cboDenky.ValueMember = "id_kyghi";
        }

        private void cbochonloaibaocao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbochonloaibaocao.SelectedIndex == 1)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            else
            {
                if (cbochonloaibaocao.SelectedIndex == 2)
                {

                    groupBox2.Visible = true;
                    groupBox1.Visible = false;
                }
                else
                {
                    groupBox2.Visible = false;
                    groupBox1.Visible = false;
                }
            }
        }

        private void btnXembaocao_Click(object sender, EventArgs e)
        {
            if (cbochonloaibaocao.SelectedIndex == 1)
            {
                frmBaocaoHoadontontheoky frm = new frmBaocaoHoadontontheoky();
                frm.MdiParent = this.MdiParent;
                frm.Dock = DockStyle.Fill;
                frm.tuky = cboTuky.SelectedValue.ToString();
                frm.denky = cboDenky.SelectedValue.ToString();
                frm.Show();
            }
            else
            {
                if (cbochonloaibaocao.SelectedIndex == 2)
                {
                    frmBaocaoHDtontheongay frm = new frmBaocaoHDtontheongay();
                    frm.MdiParent = this.MdiParent;
                    frm.Dock = DockStyle.Fill;
                    frm.tungay = cboTuky.SelectedValue.ToString();
                    frm.denngay = cboDenky.SelectedValue.ToString();
                    frm.Show();
                }
            }
        }

        private void frmBaocaohoadon_FormClosing(object sender, FormClosingEventArgs e)
        {
            cnn.Close();
        }   
    }
}
