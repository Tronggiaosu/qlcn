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
    public partial class frBaoCaoChuanThu0Dong : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frBaoCaoChuanThu0Dong()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPBaoCaoChuanThuHD0Dong.rdlc";
            string kyghi = cboKy.Text; ;
            int nam = int.Parse(cbopNam.SelectedValue.ToString());
            string IDKyghi = cboKy.SelectedValue.ToString();
            int TOID = 0;
            if (checkBox1.Checked == true)
                TOID = int.Parse(cboTo.SelectedValue.ToString());
            var dataSource = db.getBaoCaoChuanThuKhongDong(nam, IDKyghi, TOID).ToList();
            this.getBaoCaoChuanThuKhongDongBindingSource.DataSource = dataSource.ToList();
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("kyghi", kyghi + "/"+ (nam + 2000).ToString()));
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frBaoCaoChuanThu0Dong_Load(object sender, EventArgs e)
        {
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            var dataKyghi = db.DM_KYGHI.OrderBy(x => x.ten_kyghi).ToList();
            cboKy.DataSource = dataKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            var dsTo = db.DM_TO.OrderBy(x => x.TENTO).ToList();
            cboTo.DataSource = dsTo.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbopNam.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            //dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cbopNam.DataSource = dmNam.ToList();
            cbopNam.ValueMember = "NAM_ID";
            cbopNam.DisplayMember = "NAM";
        }
    }
}
