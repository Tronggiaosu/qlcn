using Microsoft.Reporting.WinForms;
using WinFormsReport = Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcBaoCaoChuanThu0Dong : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcBaoCaoChuanThu0Dong()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var root = "ReportViewer\\ReportView\\RPBaoCaoChuanThuHD0Dong.rdlc";
            string basePath = Directory.GetCurrentDirectory();
            var reportPath = $"{basePath}\\{root}";

            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("File report không tồn tại: " + reportPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.reportViewer1.LocalReport.ReportPath = reportPath;
            string nam = cbopNam.Text;
            string thang = cboThang.Text;
            string result = nam + thang;
            int namid = int.Parse(cbopNam.SelectedValue.ToString());
            int TOID = 0;
            if (checkBox1.Checked == true)
                TOID = int.Parse(cboTo.SelectedValue.ToString());
            var dataSource = db.getBaoCaoChuanThuKhongDong(namid, result, TOID).ToList();
            this.getBaoCaoChuanThuKhongDongBindingSource.DataSource = dataSource.ToList();
            List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
            param.Add(new WinFormsReport.ReportParameter("thang", thang));
            param.Add(new WinFormsReport.ReportParameter("nam", nam));
            param.Add(new WinFormsReport.ReportParameter("tento", cboTo.Text));
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
            this.Cursor = Cursors.Default;
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frBaoCaoChuanThu0Dong_Load(object sender, EventArgs e)
        {
            cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            for (int i = 1; i <= 12; i++)
            {
                dmKyghi.Add(new DM_KYGHI()
                {
                    ID_kyghi = i.ToString("00"),
                    ten_kyghi = $"{i:00}"
                });
            }
            cboThang.DataSource = dmKyghi;
            cboThang.ValueMember = "ID_kyghi";
            cboThang.DisplayMember = "ten_kyghi";

            var dsTo = db.DM_TO.OrderBy(x => x.TENTO).ToList();
            cboTo.DataSource = dsTo.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;

            cbopNam.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cbopNam.DataSource = dmNam.ToList();
            cbopNam.ValueMember = "NAM_ID";
            cbopNam.DisplayMember = "NAM";
        }
    }
}
