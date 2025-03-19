using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class TKLogUserForm : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public TKLogUserForm()
        {
            InitializeComponent();
        }

        private void TKLogUserForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadMaND();
        }

        private void LoadMaND()
        {
            var maND = from a in db.NGUOIDUNGs orderby a.ma_nd select a;
            maNDcomboBox.DataSource = maND.ToList();
            maNDcomboBox.DisplayMember = "ma_nd";
            maNDcomboBox.ValueMember = "nguoidung_id";
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dataGridView1.DataSource = null;
            var log = from a in db.LOG_USER
                     from b in db.NGUOIDUNGs        
                     from c in db.NHANVIENs
                     where System.Data.Entity.DbFunctions.TruncateTime(a.ngay_sd) >= tuNgaydateTimePicker.Value.Date && System.Data.Entity.DbFunctions.TruncateTime(a.ngay_sd) <= denNgaydateTimePicker.Value.Date
                     where a.nguoidung_id == b.nguoidung_id
                     where c.maNV == b.manv
                     select new
                     {
                         a.nguoidung_id,
                         b.ma_nd,
                         c.hoten,                         
                         ngaySD = a.ngay_sd
                     };
            if (maNDcheckBox.Checked)
            {
                decimal? maND = Convert.ToDecimal(maNDcomboBox.SelectedValue);
                log = log.Where(x => x.nguoidung_id == maND);
            }         
            dataGridView1.DataSource = log.ToList();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[sttColumn.Name].Value = i + 1;             
            }
            this.Cursor = Cursors.Default;
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
