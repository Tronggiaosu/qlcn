using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLCongNo.ReportViewer.DataSource;

namespace QLCongNo.View.UC.HoaDon
{
    public partial class UcGiayBaoTienNuoc : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcGiayBaoTienNuoc()
        {
            InitializeComponent();
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
            seachButton.Click += seachButton_Click;
            btnIn.Click += btnIn_Click;
            excelButton.Click += excelButton_Click;
            txtTim.KeyDown += txtTim_KeyDown;
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

        private void excelButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Không có hóa đơn nào trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else
            {
                Common.ExportExcel(dataGridView1);
            }             
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                int nam = int.Parse(cboNam.SelectedValue.ToString());
                string kyghi = cboThang.SelectedValue.ToString();
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
                    var frm = new QLCongNo.ReportViewer.DataSource.UcGiayBaoTienNuoc
                    {
                        nam = nam,
                        kyghi = kyghi,
                        trangthai = trangthai,
                        maquan = maquan,
                        maphuong = maphuong,
                        search = txtTim.Text
                    };
                    new FrmDialog().ShowDialog(frm);
                }
                else
                    MessageBox.Show("Không có hóa đơn nào trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
            }
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string maDanhBo = txtTim.Text.Trim();
            int nam = int.Parse(cboNam.SelectedValue.ToString());
            string thang = cboThang.SelectedValue.ToString();
            string ky = (nam + 2000).ToString() + thang;
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
            var data = db.getDSInGiayBaoTienNuoc(nam, ky, trangthai, maquan, maphuong, maDanhBo).ToList();
            if (data.Count > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }    
            dataGridView1.DataSource = data.ToList();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i + 1;
            }                   
            this.Cursor = Cursors.Default;
        }

        private void cboQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var maQuan = cboQuan.SelectedValue.ToString();
                if (maQuan != "0")
                {
                    // dm phuong
                    cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
                    cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            for (int i = 1; i <= 12; i++)
            {
                dmKyghi.Add(new DM_KYGHI()
                {
                    ID_kyghi = i.ToString("00"),
                    ten_kyghi = $"{i:00}"
                });
            }
            cboThang.DataSource = dmKyghi;
            cboThang.ValueMember = "ID_kyghi";
            cboThang.DisplayMember = "ten_kyghi";
            // dm nam
            cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            var dataNam = db.DM_NAM.OrderByDescending(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";
            dataGridView1.AutoGenerateColumns = false;
            // dm quan
            cboQuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_QUAN> dsQuan = new List<DM_QUAN>();
            dsQuan.Add(new DM_QUAN() { maQuan = "0", tenQuan = "Tất cả" });
            var dataQuan = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
            dsQuan.AddRange(dataQuan);
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            // dm phuong
            cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
            dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
            var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
            dsPhuong.AddRange(dataPhuong);
            cboPhuong.DataSource = dsPhuong.ToList();
            cboPhuong.ValueMember = "maPhuong";
            cboPhuong.DisplayMember = "tenPhuong";
            // trangthai
            cboTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            string[] trangthai = { "Chưa in", "Đã in" };
            cboTT.DataSource = trangthai;
        }

        private void txtTim_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void excelButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}