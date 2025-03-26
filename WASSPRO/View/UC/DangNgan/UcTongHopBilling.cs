using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.DangNgan
{
    public partial class UcTongHopBilling : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private DataTable table;

        public UcTongHopBilling()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            btnTim.Click += btnTim_Click;
            //btnUpdate.Click += btnUpdate_Click;
            btnExport.Click += btnExport_Click;
            btnTT.Click += btnTT_Click;
            btnCN.Click += btnCN_Click;
            //chkAll.CheckedChanged += chkAll_CheckedChanged;
            //chkKD.CheckedChanged += chkKD_CheckedChanged;
            this.dataGridView1.DataError += dataGridView1_DataError;
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            this.dataGridView2.DataError += dataGridView2_DataError;
            this.dataGridView2.CellFormatting += dataGridView2_CellFormatting;
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "thangColumn1")
            {
                if (e.Value != null)
                {
                    string kyghiFull = e.Value.ToString();
                    if (kyghiFull.Length >= 2)
                    {
                        e.Value = kyghiFull.Substring(0, 2);
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "namColumn1")
            {
                if (e.Value != null)
                {
                    string kyghiFull = e.Value.ToString();
                    if (kyghiFull.Length >= 2)
                    {
                        e.Value = kyghiFull.Substring(3, 4);
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "thangColumn2")
            {
                if (e.Value != null)
                {
                    string kyghiFull = e.Value.ToString();
                    if (kyghiFull.Length >= 2)
                    {
                        e.Value = kyghiFull.Substring(0, 2);
                        e.FormattingApplied = true;
                    }
                }
            }
            if (dataGridView2.Columns[e.ColumnIndex].Name == "namColumn2")
            {
                if (e.Value != null)
                {
                    string kyghiFull = e.Value.ToString();
                    if (kyghiFull.Length >= 2)
                    {
                        e.Value = kyghiFull.Substring(3, 4);
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Common.ExportExcel(dataGridView2);
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|.xlsx";
            if (save.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string[] columns = { "ngaythanhtoan", "somay", "sophathanh", "kyHD", "tongtien0VAT", "tienvat", "tienBVMT", "PhiNT", "TienThueNT", "tongtien", "madanhbo", };

                var result = ExcelExportHelper.ExportExcel(table, false, columns);
                File.WriteAllBytes(save.FileName, result);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //void chkKD_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chkAll.Checked == true)
        //        {
        //            this.Cursor = Cursors.WaitCursor;
        //            foreach (DataGridViewRow r in dataGridView2.Rows)
        //            {
        //                r.Cells[chkChuyenno.Name].Value = true;
        //            }
        //            this.Cursor = Cursors.Default;
        //        }
        //        else
        //        {
        //            this.Cursor = Cursors.WaitCursor;
        //            foreach (DataGridViewRow r in dataGridView2.Rows)
        //            {
        //                r.Cells[chkChuyenno.Name].Value = false;
        //            }
        //            this.Cursor = Cursors.Default;
        //        }

        //    }
        //    catch
        //    {
        //    }
        //}

        //void chkAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chkAll.Checked == true)
        //        {
        //            this.Cursor = Cursors.WaitCursor;
        //            foreach (DataGridViewRow r in dataGridView1.Rows)
        //            {
        //                r.Cells[chkColumn.Name].Value = true;
        //            }
        //            this.Cursor = Cursors.Default;
        //        }
        //        else
        //        {
        //            this.Cursor = Cursors.WaitCursor;
        //            foreach (DataGridViewRow r in dataGridView1.Rows)
        //            {
        //                r.Cells[chkColumn.Name].Value = false;
        //            }
        //            this.Cursor = Cursors.Default;
        //        }

        //    }
        //    catch
        //    {
        //    }
        //}

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa tải dữ liệu lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //try
            //{
            //decimal NVId = decimal.Parse(cboNganhang.SelectedValue.ToString());
            //int loaiHD = int.Parse(cboloaiHD.SelectedValue.ToString());
            var tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
            var denngay = dtpDenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //var maDT = cboDTSD.SelectedValue.ToString();
            var dataSource = db.getFiledataBilling(0, 0, tungay, denngay, "", "", false, 0).ToList();
            var dataChuyenNo = db.getDataChuyenNoKhoDoi(0, 0, tungay, denngay, "", "", false, 0).ToList();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Dat files (*.dat)|*.dat";
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                this.Cursor = Cursors.WaitCursor;
                string fileName = saveFileDialog.FileName;
                //before your loop
                var csv = new StringBuilder();
                //in your loop
                foreach (var item in dataSource)
                {
                    //var nhanvien = db.NHANVIENs.Where(x => x.NV_ID == item.nv_id).FirstOrDefault();
                    //var dangngan = db.DANGNGANs.Where(x => x.ID_HD == item.ID_HD).FirstOrDefault();
                    //dangngan.IsDangNgan = true;
                    //db.SaveChanges();
                    var httt = 1;
                    if (item.loaiHD_id == 13)
                        httt = 2;
                    var nam = item.nam;
                    var sophathanh = item.sophathanh;
                    var NVIDNop = item.somay;
                    string ngayct = DateTime.Parse(item.ngaythanhtoan.ToString()).ToString("yyyyMMdd");
                    var nuocdc = item.lechm3;
                    var tiennuoc_dc = item.lechtiennuoc;
                    var thue_dc = item.lechtienvat;
                    var phi_dc = item.lechtienBVMT;
                    var phiNT_dc = item.lechthueNT;
                    var newLine = string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\"", nam, sophathanh, NVIDNop, ngayct, nuocdc, tiennuoc_dc, thue_dc, phi_dc, phiNT_dc, httt);
                    csv.AppendLine(newLine);
                }
                foreach (var hoadon in dataChuyenNo)
                {
                    var item = db.HOADONs.Where(x => x.ID_HD == hoadon.ID_HD).FirstOrDefault();
                    // var dangngan = db.DANGNGANs.Where(x => x.ID_HD == hoadon.ID_HD).FirstOrDefault();
                    // if (dangngan == null)
                    // {
                    //     var hoadonKD = db.HOADON_KHODOI.Where(x => x.ID_HD == hoadon.ID_HD).FirstOrDefault();
                    //     hoadonKD.ISDANGNGAN = true;
                    //     hoadonKD.NGAYDANGNGAN = DateTime.Now;
                    //     db.SaveChanges();
                    // }
                    //else
                    // {
                    //     dangngan.IsDangNgan = true;
                    //     dangngan.NGAY_BILLING = DateTime.Now;
                    //     db.SaveChanges();
                    // }

                    var httt = 2;
                    var nam = item.nam;
                    var sophathanh = item.SOPHATHANH;
                    var NVIDNop = hoadon.somay;
                    string ngayct = DateTime.Parse(hoadon.NGAYCHUYEN.ToString()).ToString("yyyyMMdd");
                    var nuocdc = hoadon.m3dc;
                    var tiennuoc_dc = hoadon.tienuoc_dc;
                    var thue_dc = hoadon.tienthue_dc;
                    var phi_dc = hoadon.tienphi_dc;
                    var phiNT_dc = hoadon.lechthueNT;
                    var newLine = string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\",\"{9}\"", nam, sophathanh, NVIDNop, ngayct, nuocdc, tiennuoc_dc, thue_dc, phi_dc, phiNT_dc, httt);
                    csv.AppendLine(newLine);
                }
                this.Cursor = Cursors.Default;
                // export file path
                File.WriteAllText(fileName, csv.ToString());
                MessageBox.Show("Đăng ngân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //}
            //catch
            //{
            //}
        }

        //void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chkNgay.Checked == true)
        //        {
        //            this.Cursor = Cursors.WaitCursor;
        //            foreach (DataGridViewRow r in dataGridView1.Rows)
        //            {
        //                DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkColumn.Name];
        //                var check = checks.Value;
        //                if (Convert.ToBoolean(check) == true)
        //                {
        //                    decimal IDHD = decimal.Parse(dataGridView1[IDHDColumn.Name, r.Index].Value.ToString());
        //                    var hoadon = db.HOADONs.Where(x => x.ID_HD == IDHD).FirstOrDefault();
        //                    hoadon.ngaythanhtoan = dtpBK.Value;
        //                    db.SaveChanges();
        //                }
        //            }
        //            foreach (DataGridViewRow r in dataGridView2.Rows)
        //            {
        //                DataGridViewCheckBoxCell checks = (DataGridViewCheckBoxCell)r.Cells[chkChuyenno.Name];
        //                var check = checks.Value;
        //                if (Convert.ToBoolean(check) == true)
        //                {
        //                    decimal IDHD = decimal.Parse(dataGridView2[IDHD2Column.Name, r.Index].Value.ToString());
        //                    var hoadon = db.HOADON_KHODOI.Where(x => x.ID_HD == IDHD).FirstOrDefault();
        //                    hoadon.NGAYCHUYEN = dtpBK.Value;
        //                    db.SaveChanges();
        //                }
        //            }
        //            this.Cursor = Cursors.Default;
        //            MessageBox.Show("Cập nhật thành công!");
        //            btnTim.PerformClick();
        //            chkNgay.Checked = false;
        //        }
        //    }
        //    catch
        //    {
        //    }

        //}

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; ;
                var tungay = dtpTungay.Value.ToString("yyyy-MM-dd");
                var denngay = dtpDenngay.Value.ToString("yyyy-MM-dd HH:mm:ss");
                var dataSource = db.getFiledataBilling(0, 0, tungay, denngay, "", "", false, 0).ToList();
                dataGridView1.DataSource = dataSource.ToList();
                lbltong.Text = "Số lượng hóa đơn: " + string.Format("{0:n0}", dataSource.Count())
                    + " | Tổng tiền: " + string.Format("{0:n0}", dataSource.Sum(x => x.tongtien));
                var dataChuyenNo = db.getDataChuyenNoKhoDoi(0, 0, tungay, denngay, "", "", false, 0).ToList();
                table = ExcelExportHelper.ListToDataTable(dataSource.OrderBy(x => x.somay).ThenBy(x => x.somay).ToList());
                dataGridView2.DataSource = dataChuyenNo.ToList();
                lblCN.Text = "Số lượng hóa đơn: " + string.Format("{0:n0}",
                    dataChuyenNo.Count()) + " | Tổng tiền: " + string.Format("{0:n0}", dataChuyenNo.Sum(x => x.tongtien));
                this.Cursor = Cursors.Default;
            }
            catch
            {
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //TODO
            //this.Close();

            //var hoadon = db.KHACHHANGs.Where(x => x.dotid == 3).ToList();
            //pb78.PublishService bs = new pb78.PublishService();
            //var acc = db.TAIKHOAN_SERVICE.FirstOrDefault();
            //foreach (var item in hoadon)
            //{
            //    var xml = db.sp_xmlUpdateCus(item.ID_KH).FirstOrDefault().ToString();
            //    var rs = bs.UpdateCus(xml, acc.acc_service, "Einv@oi@vn#pt20", 0);
            //}
        }

        private void frTongHopBilling_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDenngay.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpTungay.CustomFormat = "dd/MM/yyyy";
        }
    }
}