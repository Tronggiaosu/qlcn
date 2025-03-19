using Microsoft.Reporting.WinForms;
using QLCongNo.View.UC.HoaDon;
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
    public partial class UcBaoCaoTheoDoiHoaDon : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcBaoCaoTheoDoiHoaDon()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            btnThoat.Click += btnThoat_Click;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ////this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //string basePath = AppDomain.CurrentDomain.BaseDirectory;
            //string projectRootPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
            //string reportPath = Path.Combine(projectRootPath, "WASSPRO", "ReportViewer", "ReportView", "RPTheoDoiHoaDon.rdlc");

            var root = "ReportViewer\\ReportView\\RPTheoDoiHoaDon.rdlc";
            string basePath = Directory.GetCurrentDirectory();
            var reportPath = $"{basePath}\\{root}";

            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("File report không tồn tại: " + reportPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.reportViewer1.LocalReport.ReportPath = reportPath;
            string ngay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string pNgay = "Ngày " + dateTimePicker1.Value.ToString("dd") + " tháng " + dateTimePicker1.Value.ToString("MM") + " năm " + dateTimePicker1.Value.ToString("yyyy");
            int TOID = 0;
            if (chkTo.Checked == true)
                TOID = int.Parse(cboTo.SelectedValue.ToString());
            List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
            param.Add(new WinFormsReport.ReportParameter("ngaybaocao", pNgay));
            param.Add(new WinFormsReport.ReportParameter("tento", cboTo.Text));
            this.getBaoCaoTheoDoiHoaDonTheoToBindingSource.DataSource = db.getBaoCaoTheoDoiHoaDonTheoTo(ngay, TOID).ToList();
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
            this.Cursor = Cursors.Default;
        }

        private void frBaoCaoTheoDoiHoaDon_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;
            var dsTo = db.DM_TO.OrderBy(x => x.TENTO).ToList();
            cboTo.DataSource = dsTo.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
        }
    }
}