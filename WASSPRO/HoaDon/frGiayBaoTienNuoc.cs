using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.ReportViewer.DataSource;

namespace QLCongNo.HoaDon
{
    public partial class frGiayBaoTienNuoc : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frGiayBaoTienNuoc()
        {
            InitializeComponent();
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            seachButton.Click += seachButton_Click;
            btnIn.Click += btnIn_Click;
            excelButton.Click += excelButton_Click;
            quitButton.Click += quitButton_Click;
            txtTim.KeyDown += txtTim_KeyDown;
        }

        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                    seachButton.PerformClick();
            }
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void excelButton_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                int nam = int.Parse(cboNam.SelectedValue.ToString());
                string kyghi = cboKy.SelectedValue.ToString();
                int trangthai = 2;
                if (chktrangthai.Checked == true)
                {
                    if (cboTT.Text == "Chưa in")
                        trangthai = 0;
                    else
                        trangthai = 1;
                }
                string maquan = cboQuan.SelectedValue.ToString();
                string maphuong = cboPhuong.SelectedValue.ToString();
                if (dataGridView1.RowCount > 0)
                {
                    GiayBaoTienNuoc frm = new GiayBaoTienNuoc();
                    frm.nam = nam;
                    frm.kyghi = kyghi;
                    frm.trangthai = trangthai;
                    frm.maquan = maquan;
                    frm.maphuong = maphuong;
                    frm.search = txtTim.Text;
                    frm.MdiParent = this.MdiParent;
                    foreach (Form otherForm in this.MdiChildren)
                        if (otherForm != frm)
                            otherForm.Close();
                    frm.Dock = DockStyle.Fill;
                    frm.Show();
                }
                else
                    MessageBox.Show("Không có hóa đơn nào trong danh sách!");

            }
            catch
            {

            }
        }

        void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int nam = int.Parse(cboNam.SelectedValue.ToString());
            string kyghi = cboKy.SelectedValue.ToString();
            int trangthai = 2;
            if (chktrangthai.Checked == true)
            {
                if (cboTT.Text == "Chưa in")
                    trangthai = 0;
                else
                    trangthai = 1;
            }
            string maquan = cboQuan.SelectedValue.ToString();
            string maphuong = cboPhuong.SelectedValue.ToString();
            var data = db.getDSInGiayBaoTienNuoc(nam, kyghi, trangthai, maquan, maphuong, txtTim.Text.Replace(" ", String.Empty)).ToList();
            dataGridView1.DataSource = data.ToList();
            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i+1;
            this.Cursor = Cursors.Default;
        }

        void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var maQuan = cboQuan.SelectedValue.ToString();
                if (maQuan != "0")
                {
                    // dm phuong
                    cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                    var dataPhuong = db.DM_PHUONG.Where(x => x.maQuan == maQuan).OrderBy(x => x.tenPhuong).ToList();
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
                else
                {
                    cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
                    List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
                    dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
                    var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
                    dsPhuong.AddRange(dataPhuong);
                    cboPhuong.DataSource = dsPhuong.ToList();
                    cboPhuong.ValueMember = "maPhuong";
                    cboPhuong.DisplayMember = "tenPhuong";
                }
            }
            catch
            {

            }
        }

        private void frGiayBaoTienNuoc_Load(object sender, EventArgs e)
        {
            cboKy.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            var dataKyghi = db.DM_KYGHI.OrderByDescending(x => x.ID_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            cboKy.DataSource = dmKyghi.ToList();
            cboKy.ValueMember = "ID_kyghi";
            cboKy.DisplayMember = "ten_kyghi";
            // dm nam
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            var dataNam = db.DM_NAM.OrderByDescending(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
            dataGridView1.AutoGenerateColumns = false;
            // dm quan
            cboQuan.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_QUAN> dsQuan = new List<DM_QUAN>();
            dsQuan.Add(new DM_QUAN() { maQuan = "0", tenQuan = "Tất cả" });
            var dataQuan = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
            dsQuan.AddRange(dataQuan);
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            // dm phuong
            cboPhuong.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
            dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
            var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
            dsPhuong.AddRange(dataPhuong);
            cboPhuong.DataSource = dsPhuong.ToList();
            cboPhuong.ValueMember = "maPhuong";
            cboPhuong.DisplayMember = "tenPhuong";
            // trangthai
            cboTT.DropDownStyle = ComboBoxStyle.DropDownList;
            string[] trangthai = { "Chưa in", "Đã in" };
            cboTT.DataSource = trangthai;
        }
    }
}
