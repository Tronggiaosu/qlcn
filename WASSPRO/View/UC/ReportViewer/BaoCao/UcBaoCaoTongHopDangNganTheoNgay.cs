using Microsoft.Reporting.WinForms;
using System;
using WinFormsReport = Microsoft.Reporting.WinForms;
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
    public partial class UcBaoCaoTongHopDangNganTheoNgay : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcBaoCaoTongHopDangNganTheoNgay()
        {
            InitializeComponent();
            btnThoat.Click += btnThoat_Click;
            btnTim.Click += btnTim_Click;
        }

        void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var tungay = dateTimePicker1.Value;
                var denngay = dateTimePicker2.Value;
                string pKyghi = denngay.ToString("MM/yyyy");
                int TOID = int.Parse(cboTo.SelectedValue.ToString());
                int LoaiHD = int.Parse(cboLoaiHD.SelectedValue.ToString());
                if (chkTo.Checked == false)
                    TOID = 0;
                if (chkLoaiHD.Checked == false)
                    LoaiHD = 0;
                string tenbaocao = "BẢNG TỔNG HỢP ĐĂNG NGÂN HÀNG NGÀY THÁNG " + pKyghi + " (TỪ " + tungay.ToString("dd/MM") + " ĐẾN " + denngay.ToString("dd/MM") + ")" ;

                var root = "ReportViewer\\ReportView\\RPTongHopDangNganTheoNgay.rdlc";
                string basePath = Directory.GetCurrentDirectory();
                var reportPath = $"{basePath}\\{root}";

                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show("File report không tồn tại: " + reportPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.reportViewer1.LocalReport.ReportPath = reportPath;
                List<WinFormsReport.ReportParameter> param = new List<WinFormsReport.ReportParameter>();
                param.Add(new WinFormsReport.ReportParameter("tenbaocao", tenbaocao));
                param.Add(new WinFormsReport.ReportParameter("tento", cboTo.Text));
                this.reportViewer1.LocalReport.SetParameters(param);
                this.getBaoCaoTongHopDangNganTheoNgayBindingSource.DataSource = db.getBaoCaoTongHopDangNganTheoNgay(tungay.ToString("yyyy-MM-dd"),denngay.ToString("yyyy-MM-dd"), "", TOID, LoaiHD, 0).ToList();
                this.reportViewer1.RefreshReport();
                this.Cursor = Cursors.Default;
            }
            catch
            {

            }
        }

        void btnThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frBaoCaoTongHopDangNganTheoNgay_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            cboTo.DropDownStyle = ComboBoxStyle.DropDownList;
            var dsTo = db.DM_TO.OrderBy(x => x.TENTO).ToList();
            cboTo.DataSource = dsTo.ToList();
            cboTo.ValueMember = "TO_ID";
            cboTo.DisplayMember = "TENTO";
            var dataLoaiGD = db.DM_LOAIHOADON.OrderBy(x => x.tenloaiHD).ToList();
            cboLoaiHD.DataSource = dataLoaiGD.ToList();
            cboLoaiHD.ValueMember = "LoaiHD_ID";
            cboLoaiHD.DisplayMember = "TenLoaiHD";
        }
    }
}
