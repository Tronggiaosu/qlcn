using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcDongBoKhachHangForm : View.Core.NovUserControl
    {

        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public UcDongBoKhachHangForm()
        {
            InitializeComponent();
            txtTim.KeyDown += txtTim_KeyDown;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
         //   this.Close();
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            try 
            {
                Cursor.Current = Cursors.WaitCursor;
                string strSearch = txtTim.Text;
                var khachhang = db.getDanhSachKhachHang(2, "", "", "", (strSearch.Replace(" ", String.Empty)).ToUpper()).Distinct().ToList();
                if(khachhang.Count > 0 )
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }    
                dataGridView1.DataSource = khachhang.ToList();
                Cursor.Current = Cursors.Default;
            }
            catch
            {

            }
        }

        private void DongBoKhachHangForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDKH = decimal.Parse(dataGridView1.SelectedRows[0].Cells[IDKHColumn.Name].Value.ToString());
                var xml = db.sp_xmlUpdateCusByIDKH(IDKH).FirstOrDefault().ToString();
                pb78.PublishService pb78 = new pb78.PublishService();
                var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
                pb78.UpdateCus(xml, acc.acc_service, acc.pass_service,0);
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    seachButton.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
