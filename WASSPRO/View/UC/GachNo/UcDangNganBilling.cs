using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcDangNganBilling : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcDangNganBilling()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPTongHopDangNgan.rdlc";
            this.getDangNganBillingBindingSource.DataSource = db.getDangNganBilling("", 0).ToList();
            this.reportViewer1.RefreshReport();
        }

        private void frDangNganBilling_Load(object sender, EventArgs e)
        {
            cboDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboDTSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboKSV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboloaiHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Dat files (*.dat)|*.dat";
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                string fileName = saveFileDialog.FileName;
                //before your loop
                var csv = new StringBuilder();
                //in your loop
                //foreach (var item in dataDangngan)
                //{
                //    var nam = item.nam;
                //    var sophathanh = item.SOPHATHANH;
                //    var NVID = item.NV_ID_LAP;
                //    var ngayct = item.NGAYLAP.ToString("yyyyMMdd");
                //    var httt = 1;
                //    var nuocdc = 0;
                //    var tiennuoc_dc = 0;
                //    var thue_dc = 0;
                //    var phi_dc = 0;
                //    var newLine = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"", nam, sophathanh, NVID, ngayct, nuocdc, tiennuoc_dc, thue_dc, phi_dc, httt);
                //    csv.AppendLine(newLine);
                //}
                // export file path
                File.WriteAllText(fileName, csv.ToString());
                MessageBox.Show("Đăng ngân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}