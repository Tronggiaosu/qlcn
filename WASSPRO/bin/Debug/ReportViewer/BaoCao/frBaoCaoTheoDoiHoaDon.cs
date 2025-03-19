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
    public partial class frBaoCaoTheoDoiHoaDon : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frBaoCaoTheoDoiHoaDon()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            btnThoat.Click += btnThoat_Click;
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            //try
            //{
                this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPTheoDoiHoaDon.rdlc";
                string ngay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string pNgay = "Ngày " + dateTimePicker1.Value.ToString("dd") + " tháng " + dateTimePicker1.Value.ToString("MM") + " năm " + dateTimePicker1.Value.ToString("yyyy");
                int TOID = 0;
                if (chkTo.Checked == true)
                    TOID = int.Parse(cboTo.SelectedValue.ToString());
                List<ReportParameter> param = new List<ReportParameter>();
                param.Add(new ReportParameter("ngaybaocao", pNgay));
                this.getBaoCaoTheoDoiHoaDonTheoToBindingSource.DataSource = db.getBaoCaoTheoDoiHoaDonTheoTo(ngay, TOID).ToList();
                this.reportViewer1.LocalReport.SetParameters(param);
                this.reportViewer1.RefreshReport();
            //}
            //catch
            //{

            //}
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
