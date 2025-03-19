 using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.ReportViewer.BaoCao
{
    public partial class frBaoCaoChuanThu : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frBaoCaoChuanThu()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPTongHopHoaDon.rdlc";
            string kyghi = cboKy.Text; ;
            string IDKyghi = cboKy.SelectedValue.ToString();
            int TOID = 0;
            if (checkBox1.Checked == true)
                TOID = int.Parse(cboTo.SelectedValue.ToString());
            var dataSource = db.getBaoCaoChuanThuKy(0, IDKyghi, TOID).ToList();
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("kyghi", kyghi ));
            this.getBaoCaoChuanThuKyBindingSource.DataSource = dataSource.ToList();
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frBaoCaoChuanThu_Load(object sender, EventArgs e)
        {
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            var dataKyghi = db.DM_KYGHI.OrderByDescending(x => x.ID_kyghi).ToList();
            cboKy.DataSource = dataKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            var dsTo = db.DM_TO.OrderBy(x => x.TENTO).ToList();
            cboTo.DataSource = dsTo.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    }
}
