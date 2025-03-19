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
    public partial class frThongKeDieuChinhThongTin : Form
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public frThongKeDieuChinhThongTin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                var data = db.getDSHoaDonDieuChinhThongTin(tungay, denngay).ToList();
                if (txtTim.Text != "")
                    data = data.Where(x => x.DANHBO.Contains(txtTim.Text)).ToList();
                dataGridView1.DataSource = data.OrderByDescending(x => x.NgayPhatHanh).ToList();
            }
            catch
            {

            }
        }

        private void frThongKeDieuChinhThongTin_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoGenerateColumns = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                var data = db.getDSHoaDonDieuChinhThongTin(tungay, denngay).ToList();
                if (txtTim.Text != "")
                    data = data.Where(x => x.DANHBO.Contains(txtTim.Text)).ToList();
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file|.xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string[] columns = { "malt", "DANHBO", "hoten", "MST", "diachilapdat", "diachihoadon", "ten_kyghi",
                                       "SoHoaDon","KyHieuHD", "MauHD", "NgayPhatHanh"};
                    var result = ExcelExportHelper.ExportExcel(data, false, columns);
                    File.WriteAllBytes(save.FileName, result);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Xuất dữ liệu thành công!");
                }

            }
            catch
            {

            }
        }

        private void btnTaiHD_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDHD = decimal.Parse(dataGridView1.SelectedRows[0].Cells[IDHDColumn.Name].Value.ToString());
                var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
                Portal.PortalService portal = new Portal.PortalService();
                var accWS = db.TAIKHOAN_SERVICE.FirstOrDefault();
                var hoadonloi = db.HOADONs.Where(x => x.ID_KH == hoadon.ID_KH && x.trangthai_id == -22).FirstOrDefault();
                if (hoadonloi != null)
                    IDHD = hoadonloi.ID_HD;
                var base64pdf = portal.downloadInvPDFFkeyNoPay(hoadon.ID_HD.ToString(), accWS.acc_service, "123456aA@");
                portal78.PortalService p78 = new portal78.PortalService();
                if (hoadon.MAU_HD == "1/001")
                    base64pdf = p78.downloadInvPDFFkeyNoPay(hoadon.ID_HD.ToString(), "capnuocthuducservice", "Einv@oi@vn#pt20");
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF file|.PDF";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    byte[] sPDFDecoded = Convert.FromBase64String(base64pdf);
                    //var result = ExcelExportHelper.ExportExcel(table, false, columns);
                    File.WriteAllBytes(save.FileName, sPDFDecoded);
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Lưu thành công!");
                }
            }
            catch
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
