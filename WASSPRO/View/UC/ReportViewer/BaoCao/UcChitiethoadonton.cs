using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLCongNo.View.UC.ReportViewer.BaoCao
{
    public partial class UcChitiethoadonton : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public string id_hd;
        public UcChitiethoadonton()
        {
            InitializeComponent();
        }

        private void frmChitiethoadonton_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            this.getChititbaocaoHoadontonTableAdapter.Fill(this.cAPNUOC_TDCDataSet.getChititbaocaoHoadonton, id_hd);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("SO_HD", id_hd));
            this.reportViewer1.RefreshReport();
            //txtSo_HD.Text = id_hd;
        }

        
        
    }
}
