using WinFormsReport = Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcBaoCaoChuanThu : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcBaoCaoChuanThu()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var root = "ReportViewer\\ReportView\\RPTongHopHoaDon.rdlc";
            string basePath = Directory.GetCurrentDirectory();
            var reportPath = $"{basePath}\\{root}";

            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("File report không tồn tại: " + reportPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.reportViewer1.LocalReport.ReportPath = reportPath;
            string nam = comboBoxNam.Text;
            string thang = cboThang.SelectedValue.ToString();
            string result = nam + thang;
            string title = "";

            int TOID = int.Parse(cboTo.SelectedValue.ToString());
            if (thang == "00")
                title = $"CHUẨN THU NĂM {nam}";
            else
                title = $"CHUẨN THU THÁNG {thang}/{nam}";

            db.Database.CommandTimeout = 600;

            var dataSource = db.getBaoCaoChuanThuKy_Newest(0, result, TOID).ToList();
            WinFormsReport.ReportDataSource reportDataSource = new WinFormsReport.ReportDataSource("DataSource", dataSource);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>
            {
                new WinFormsReport.ReportParameter("nam", title),
                new WinFormsReport.ReportParameter("tento", cboTo.Text)
            };
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
            this.Cursor = Cursors.Default;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ////this.Close();
        }

        private void frBaoCaoChuanThu_Load(object sender, EventArgs e)
        {
            cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "00", ten_kyghi = "Tất cả" });
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

            comboBoxNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            comboBoxNam.DataSource = dmNam.OrderByDescending(item => item.NAM).ToList();
            comboBoxNam.ValueMember = "NAM_ID";
            comboBoxNam.DisplayMember = "NAM";
            

            var dsTo = db.DM_TO.OrderBy(x => x.TENTO).ToList();

            dsTo.Insert(0, new DM_TO
            {
                TO_ID = -1,       
                TENTO = "Tất cả" 
            });

            cboTo.DataSource = dsTo;
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;

        }
    }
}