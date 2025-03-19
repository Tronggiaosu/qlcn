using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.HoaDon
{
    public partial class frKhachHang : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        DataTable table;
        public frKhachHang()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            excelButton.Click += excelButton_Click;
            seachButton.Click += seachButton_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
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
                    //dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
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
                    //dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
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

        //void btnYeucau_Click(object sender, EventArgs e)
        //{
        //    DialogResult rs = MessageBox.Show("Bạn có muốn tạo yêu cầu cho khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //    if (rs == DialogResult.OK)
        //    {
        //        var loaiYC = yccomboBox.SelectedValue.ToString();
        //        var lydo = lydocomboBox.SelectedValue.ToString();
        //        var khachhang = db.KHACHHANGs.Where(x => x.ID_KH == IDKH).FirstOrDefault();
        //        YEUCAU yc = new YEUCAU();
        //        yc.ngayYC = DateTime.Now;
        //        yc.ngaytao = DateTime.Now;
        //        yc.nguoitao = Common.username;
        //        yc.maloai_yc = yccomboBox.SelectedValue.ToString();
        //        yc.lydo_id = Convert.ToInt32(lydocomboBox.SelectedValue);
        //        yc.ID_KH = IDKH;
        //        yc.TTYC_ID = 1;
        //        //Lấy số phiếu lớn nhất
        //        //var pyc_max = (from a in db.YEUCAUs orderby a.ID_yeucau descending select a.sophieu).FirstOrDefault();
        //        //decimal sophieu = pyc_max != null 
        //        db.YEUCAUs.Add(yc);
        //        db.SaveChanges();
        //        MessageBox.Show("Tạo yêu cầu " + yccomboBox.Text + " thành công!", "Thông báo");
        //    }
        //}


        void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    seachButton.PerformClick();
                }
            }
        }

        void seachButton_Click(object sender, EventArgs e)
        {
            try
            {
                string tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string maQuan = cboQuan.SelectedValue.ToString();
                string maPhuong = cboPhuong.SelectedValue.ToString();
                int trangthaiKH = int.Parse(cboTT.SelectedValue.ToString());
                int iscoSDT = 1;
                if (chkNgay.Checked == false)
                    tungay = "";
                if (chkQuan.Checked == false)
                    maQuan = "0";
                if (chkPhuong.Checked == false)
                    maPhuong = "0";
                if (chkSDT.Checked == false)
                    iscoSDT = 0;
                if (chktrangthai.Checked == false)
                    trangthaiKH = -1;
                var data = db.getKhangHang(tungay, denngay, maQuan, maPhuong, trangthaiKH, iscoSDT, txtTim.Text).ToList();
                
                table = ExcelExportHelper.ListToDataTable(data);
                dataGridView1.DataSource = table;
                lblsoluong.Text = string.Format("{0:n0}", data.Count());
            }
            catch
            {
                
            }

        }

        void excelButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "madanhbo", "maLT", "hoten_KH", "SDT_KH", "sonha", "diachi", "tenPhuong", "tenQuan", "ghichu", "sokyno", "tongtienno", "ghichu2" };
                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!");
            }
        }

        void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frKhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            // dm trang thai
            var trangthai = db.DM_TRANGTHAI_KH.OrderBy(x => x.tenTT).ToList();
            cboTT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTT.DataSource = trangthai.ToList();
            cboTT.DisplayMember = "tenTT";
            cboTT.ValueMember = "maTT";
            // dm quan
            var dsQuan = db.DM_QUAN.ToList();
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            cboQuan.DropDownStyle = ComboBoxStyle.DropDownList;

        }
      
    }
}
