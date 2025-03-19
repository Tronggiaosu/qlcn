using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.GachNo
{
    public partial class frQLBienNhan : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        List<getQLBiennhan_Result> dsBienNhan = new List<getQLBiennhan_Result>();

        public frQLBienNhan()
        {
            InitializeComponent();
            btnEX.Click += btnEX_Click;
            quitButton.Click += quitButton_Click;
            btnTim.Click += btnTim_Click;
        }

        //void btnDangngan_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.RowCount > 0)
        //    {
        //        try
        //        {
        //            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
        //            {
        //                decimal IDCT = decimal.Parse(dataGridView1.SelectedRows[i].Cells[IDCTColumn.Name].Value.ToString());
        //                var chungtu = db.CHUNGTUs.Where(x => x.ID_CT == IDCT).FirstOrDefault();
        //                if (chungtu.TRANGTHAI == true)
        //                    MessageBox.Show("Mã thanh toán đã đăng ngân, không thể đồng bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                else
        //                {
        //                    DialogResult rs = MessageBox.Show("Bạn có xác nhận đăng ngân?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //                    if (rs == DialogResult.OK)
        //                    {
        //                        db.DANGNGAN_NV(chungtu.NV_ID_LAP, IDCT);
        //                        chungtu.TRANGTHAI = true;
        //                        db.SaveChanges();
        //                    }
        //                }

        //            }
        //            MessageBox.Show("Đăng ngân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            btnTim.PerformClick();
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

   
        //void btnDetail_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.RowCount > 0)
        //    {
        //        string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        //        string denngay = dtpdenngay.Value.ToString("yyyy-MM-dd");
        //        var NVID = int.Parse(dataGridView1.SelectedRows[0].Cells[NV_ID_LAPColumn.Name].Value.ToString());
        //        frDSHoaDon_TNV frm = new frDSHoaDon_TNV();
        //        frm.tungay = tungay;
        //        frm.denngay = denngay;
        //        frm.NVID = NVID;
        //        frm.MdiParent = this.MdiParent;
        //        foreach (Form otherForm in this.MdiChildren)
        //            if (otherForm != frm)
        //                otherForm.Close();
        //        frm.Dock = DockStyle.Fill;
        //        frm.Show();
        //    }
        //}

        void btnTim_Click(object sender, EventArgs e)
        {
            string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string denngay = dtpdenngay.Value.ToString("yyyy-MM-dd");
            string gio = dtpdenngay.Value.ToString(" HH:mm:ss");
            int hinhthuc = 0;
            if (chkHinhthuc.Checked == true)
            {
                if (cboHT.Text == "Chuyển khoản, thu hộ")
                    hinhthuc = 1;
                else if (cboHT.Text == "Tại quầy")
                    hinhthuc = 2;
                else if (cboHT.Text == "Mobile App")
                    hinhthuc = 3;
            }
            var dataSource = db.getDSTongThanhToan(tungay, denngay + gio, 0, hinhthuc).ToList();
            dataGridView1.DataSource = dataSource.ToList();
            lbl.Text = "Số lượng: " + string.Format("{0:n0}", dataSource.Select(x => x.soluong).Sum()) + " Tổng tiền: " + string.Format("{0:n0}", dataSource.Select(x => x.tongtien).Sum());
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnRF_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
        }

        void btnEX_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        private void frQLBienNhan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dtpdenngay.Format = DateTimePickerFormat.Custom;
            dtpdenngay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            string[] hinhthuc = { "Chuyển khoản, thu hộ", "Tại quầy", "Mobile App" };
            cboHT.DataSource = hinhthuc;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
