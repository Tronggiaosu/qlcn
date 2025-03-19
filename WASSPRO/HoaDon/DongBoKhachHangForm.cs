using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.HoaDon
{
    public partial class DongBoKhachHangForm : Form
    {

        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public DongBoKhachHangForm()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            try 
            {
                string strSearch = txtTim.Text;
                var khachhang = db.getDanhSachKhachHang(2, "", "", "", (strSearch.Replace(" ", String.Empty)).ToUpper()).Distinct().ToList();
                dataGridView1.DataSource = khachhang.ToList();
            }
            catch
            {

            }
        }

        private void DongBoKhachHangForm_Load(object sender, EventArgs e)
        {
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
                MessageBox.Show("Cập nhật thành công");
            }
            catch
            {

            }
        }
    }
}
