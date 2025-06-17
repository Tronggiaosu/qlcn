using Ionic.Zip;
using QLCongNo.Data;
using QLCongNo.View.UC.GachNo;
using QLCongNo.View.UC.ReportViewer.BaoCao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcDongBoGachNo : View.Core.NovUserControl
    {
        CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        DongBoThuHo connect = new DongBoThuHo();

        public UcDongBoGachNo()
        {
            InitializeComponent();
            txtdanhbo.KeyDown += txtdanhbo_KeyDown;
            this.dataGridView1.DataError += dataGridView1_DataError;
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            this.chkList.ItemCheck += ChkList_ItemCheck;
            this.txtdanhbo.TextChanged += Txtdanhbo_TextChanged;
            this.btnDBLechNgay.Click += BtnDBLechNgay_Click;
        }

        private void BtnDBLechNgay_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.CurrentRow != null)
                {
                    var nam = dataGridView1.CurrentRow.Cells["namColumn"].Value.ToString();
                    var thang = dataGridView1.CurrentRow.Cells["KyGhiColumn"].Value.ToString();
                    var ID_HD = dataGridView1.CurrentRow.Cells["IDHDColumn"].Value.ToString();
                    var ngaythanhtoan = dataGridView1.CurrentRow.Cells["NgayThuColumn"].Value.ToString();
                    var ngaybangke = dataGridView1.CurrentRow.Cells["NgayThuHoColumn"].Value.ToString();
                    var ngaythuQLCN = Convert.ToDateTime(ngaythanhtoan);
                    var ngaythuThuHo = Convert.ToDateTime(ngaybangke);

                    var dialog = MessageBox.Show($"Chắc chắn muốn đồng bộ hóa đơn Kỳ {thang}?\nNgày thu Công nợ sẽ thay đổi từ\n{ngaythuQLCN.ToString("dd/MM/yyyy HH:mm:ss")} sang {ngaythuThuHo.ToString("dd/MM/yyyy HH:mm:ss")}?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        var bienso = Decimal.Parse(ID_HD);
                        var hoadon = db.GACHNOes.Where(x => x.ID_HD == bienso).FirstOrDefault();

                        if (hoadon != null)
                        {
                            hoadon.NGAYTHANHTOAN = ngaythuThuHo;
                            db.SaveChanges();
                            MessageBox.Show($"Đồng bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.btnTim.PerformClick();
                        }
                        else MessageBox.Show($"Hóa đơn ko tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                MessageBox.Show($"Đồng bộ ko thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Txtdanhbo_TextChanged(object sender, EventArgs e)
        {
            var text = this.txtdanhbo.Text;
            if (text != String.Empty)
            {
                for (int i = 0; i < chkList.Items.Count; i++)
                {
                    chkList.SetItemChecked(i, false);
                    chkList.SetSelected(i, false);
                }
            }
        }

        private void ChkList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                this.txtdanhbo.Clear();
                for (var i = 0; i < this.chkList.Items.Count; i++)
                {
                    if (i != e.Index)
                        this.chkList.SetItemChecked(i, false);
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "KyGhiColumn")
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "namColumn")
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //  this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                var danhbo = txtdanhbo.Text;
                if (danhbo != "")
                {
                    var khachhang = db.KHACHHANGs.Where(x => x.madanhbo == danhbo).FirstOrDefault();
                    if (khachhang != null)
                    {
                        var dsHoadon = db.getDSHoaDon_KH_Newest(khachhang.ID_KH).ToList().OrderByDescending(X => X.ID_HD).ToList();
                        lbltongno.Text = "Tổng số tiền nợ: " + string.Format("{0:n0}", dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Select(x => x.tongtien).Sum());
                        lbltongsokyno.Text = "Tổng số kỳ nợ: " + dsHoadon.Where(x => x.thanhtoan != "Đã thu" && x.tentrangthai != "Hủy" && x.tentrangthai != "Khiếu nại" && x.tentrangthai != "Khó đòi").Count().ToString();
                        if (dsHoadon.Count > 0)
                        {
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        dataGridView1.DataSource = dsHoadon.OrderByDescending(X => X.ngaytao).ToList();

                        for (int i = 0; i < dsHoadon.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells[STTColumn.Name].Value = i + 1;
                        }

                        if (dsHoadon.Count > 0)
                        {
                            var dt = new DataTable();
                            var dsID_HD = dsHoadon.Select(x => x.ID_HD);
                            dt.Columns.Add("ID_HD", typeof(decimal));

                            foreach (var item in dsID_HD)
                                dt.Rows.Add(item);

                            var dsHoaDon_ThuHo = this.connect.ServerThuHo(1, dt, 0, 0, 0);
                            var ds = dsHoaDon_ThuHo
                                .AsEnumerable()
                                .Select(row => new
                                {
                                    ID_HD = row["ID_HD"].ToString(),
                                    NGAY_THANHTOAN = row["NGAY_THANHTOAN"].ToString()
                                })
                                .ToList();

                            var dict = ds.ToDictionary(x => x.ID_HD, x => x.NGAY_THANHTOAN);
                            foreach (var item in dsHoadon)
                            {
                                if (dict.TryGetValue(item.ID_HD.ToString(), out var ngaythuho))
                                {
                                    var datetime = DateTime.Parse(ngaythuho);
                                    item.NgayBangKe = datetime;
                                }
                            }
                        }
                    }

                    this.dgvHoaDon.Visible = false;
                    this.dataGridView1.Visible = true;

                    this.btnDongBo.Enabled = false;
                    this.btnDBLechNgay.Enabled = true;
                }
                else
                {
                    var mode = 0;
                    for (var i = 0; i < this.chkList.Items.Count; i++)
                    {
                        if (this.chkList.GetItemChecked(i))
                            mode = i + 1;
                    }

                    if (mode == 0)
                    {
                        this.dataGridView1.Visible = true;
                        this.dgvHoaDon.Visible = false;
                        this.dgvHoaDon.DataSource = null;
                        return;
                    }

                    switch (mode)
                    {
                        case 1:
                            ProcessModeThuHo();
                            break;
                        case 2:
                            ProcessModeQLCN();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                this.dataGridView1.Visible = true;
                this.dgvHoaDon.Visible = false;
                this.dgvHoaDon.DataSource = null;

                this.btnDongBo.Enabled = true;
                this.btnDBLechNgay.Enabled = true;
                return;
            }
        }

        private void ProcessModeThuHo()
        {
            try
            {
                var nam = int.Parse(this.cboNam.Text);
                var thang = this.cboThang.Text;
                var dot = int.Parse(this.cboDot.Text);

                var dsHoaDon_QLCN = this.connect.ServerQLCN(0, null, nam, thang, dot);
                var dsHoaDon_ThuHo = this.connect.ServerThuHo(1, dsHoaDon_QLCN, nam, int.Parse(thang), dot);

                var countQLCN = dsHoaDon_QLCN.Rows.Count;
                var countThuHo = dsHoaDon_ThuHo.Rows.Count;

                BindingDataGridview(dsHoaDon_ThuHo, "1");
            }
            catch { }
        }

        private void ProcessModeQLCN()
        {
            try
            {
                var nam = int.Parse(this.cboNam.Text);
                var thang = int.Parse(this.cboThang.Text);
                var dot = int.Parse(this.cboDot.Text);

                var dsHoaDon_ThuHo = this.connect.ServerThuHo(0, null, nam, thang, dot);
                var dsHoaDon_QLCN = this.connect.ServerQLCN(1, dsHoaDon_ThuHo, nam, $"{thang}", dot);

                var countQLCN = dsHoaDon_QLCN.Rows.Count;
                var countThuHo = dsHoaDon_ThuHo.Rows.Count;

                BindingDataGridview(dsHoaDon_QLCN, "0");
            }
            catch { }
        }

        private void BindingDataGridview(DataTable dsHoaDon, string status)
        {
            try
            {
                var field = status == "1" ? "TRANGTHAI_THUHO" : "TRANGTHAI_CONGNO";
                var data = dsHoaDon
                        .AsEnumerable()
                        .Where(row => row.Field<string>(field) == "1")
                        .Select(row => row["ID_HD"].ToString())
                        .ToList();

                var matchedRows = dsHoaDon
                    .AsEnumerable()
                    .Where(row => data.Contains(row.Field<string>("ID_HD")));

                var dt = matchedRows.Any() ? matchedRows.CopyToDataTable() : dsHoaDon.Clone();

                if (dt.Columns.Count == 10)
                    dt.Columns.RemoveAt(9);

                this.dataGridView1.Visible = false;
                this.dgvHoaDon.DataSource = dt;
                this.dgvHoaDon.Visible = true;
                this.dgvHoaDon.Dock = DockStyle.Fill;

                this.dgvHoaDon.Columns[0].HeaderText = "Năm";
                this.dgvHoaDon.Columns[1].HeaderText = "Tháng";
                this.dgvHoaDon.Columns[2].HeaderText = "Đợt";
                this.dgvHoaDon.Columns[3].HeaderText = "IDHD";
                this.dgvHoaDon.Columns[4].HeaderText = "Danh bộ";
                this.dgvHoaDon.Columns[5].HeaderText = "Họ tên";
                this.dgvHoaDon.Columns[6].HeaderText = "Tổng tiền";
                this.dgvHoaDon.Columns[7].HeaderText = "Trạng thái\nThu hộ";
                this.dgvHoaDon.Columns[8].HeaderText = "Trạng thái\nCông nợ";
                this.dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvHoaDon.Columns[6].DefaultCellStyle.Format = "N0";

                foreach (DataRow dr in dt.Rows)
                {
                    var col = status == "1" ? 7 : 8;
                    dr[col] = "Đã thu";
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Ko có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnDongBo.Enabled = true;
                    this.btnDBLechNgay.Enabled = true;
                    return;
                }

                this.btnDongBo.Enabled = true;
                this.btnDBLechNgay.Enabled = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                this.btnDongBo.Enabled = true;
                this.btnDBLechNgay.Enabled = true;
            }
        }

        private void frDongBoDuLieuHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = false;

            var currentTime = DateTime.Now;

            // dm nam
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            cboNam.DataSource = dmNam.ToList();
            cboNam.ValueMember = "NAM_ID";
            cboNam.DisplayMember = "NAM";

            // dm thang
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
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

            // dot
            cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            cboDot.DataSource = dmDot.ToList();
            cboDot.ValueMember = "DOT_ID";
            cboDot.DisplayMember = "TENDOT";

            var exNam = dmNam != null && dmNam.Any(x => x.NAM == currentTime.Year.ToString());
            if (exNam)
            {
                var item = dmNam.Where(x => x.NAM == currentTime.Year.ToString()).FirstOrDefault();
                cboNam.SelectedItem = item;
            }
            else cboNam.SelectedIndex = 0;

            var exThang = dmKyghi != null && dmKyghi.Any(x => x.ten_kyghi == currentTime.ToString("MM"));
            if (exThang)
            {
                var item = dmKyghi.Where(x => x.ten_kyghi == currentTime.ToString("MM")).FirstOrDefault();
                cboThang.SelectedItem = item;
            }
            else cboThang.SelectedIndex = 0;

            cboDot.SelectedIndex = 0;
        }

        private void btnDongBo_Click(object sender, EventArgs e)
        {
            try
            {
                var mode = 0;
                for (var i = 0; i < this.chkList.Items.Count; i++)
                {
                    if (this.chkList.GetItemChecked(i))
                        mode = i + 1;
                }

                if (mode == 0) return;

                var ID_HD = this.dgvHoaDon.CurrentRow.Cells["ID_HD"].Value.ToString();
                var dialog = MessageBox.Show($"Chắc chắn muốn đồng bộ hóa đơn có ID = \"{ID_HD}\"",
                            "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    if (mode == 1)
                    {
                        if (this.dgvHoaDon.CurrentRow != null)
                        {
                            var data = connect.GetHoaDonThuHo(ID_HD);
                            if (data != null)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                var row = data.AsEnumerable().First();
                                var idhd = Decimal.Parse(ID_HD);
                                var mabank = row.Field<string>("USER_TT");
                                var tongthanhtoan = row.Field<decimal>("TONGTIEN");
                                var ngaythanhtoan = row.Field<DateTime>("NGAY_TT");
                                var nganhangid = db.DM_NGANHANG.Where(x => x.MA_NGANHANG == mabank).Select(x => x.NGANHANG_ID).FirstOrDefault();
                                var hoadon = db.HOADONs.Where(x => x.ID_HD == idhd).FirstOrDefault();

                                var dsGachno = new List<GACHNO>();
                                dsGachno.Add(new GACHNO()
                                {
                                    ID_HD = hoadon.ID_HD,
                                    ID_KH = hoadon.ID_KH,
                                    DOT_ID = hoadon.DOT_ID,
                                    ID_KYGHI = hoadon.kyghi,
                                    KYHIEU = hoadon.KY_HIEU_HD,
                                    MALOAI = "Pay Service",
                                    MALT = hoadon.MaLT,
                                    MAUSO = hoadon.MAU_HD,
                                    NGAYTHANHTOAN = ngaythanhtoan,
                                    NV_ID_NOP = nganhangid,
                                    SOHD = hoadon.SO_HD,
                                    TIENTHUE_GTGT = hoadon.tienvat,
                                    TONGTIENBVMT = hoadon.tienBVMT,
                                    TONGTIEN = hoadon.tongtien0VAT,
                                    TONGTHANHTOAN = tongthanhtoan,
                                    NAM_ID = hoadon.nam,
                                    USER_CREATE = null,
                                    DATE_CREATE = ngaythanhtoan,
                                    STATUS = true
                                });
                                db.GACHNOes.AddRange(dsGachno);
                                db.SaveChanges();

                                var pb = db.PublishedInvoices.Where(x => x.IDHD == idhd).FirstOrDefault();
                                pb.GACH_NO = "1";
                                db.SaveChanges();

                                hoadon.ngaythanhtoan = ngaythanhtoan;
                                hoadon.gachno = true;
                                db.SaveChanges();
                                MessageBox.Show("Đồng bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.btnTim.PerformClick();
                                this.Cursor = Cursors.Default;
                            }
                            else MessageBox.Show("Hóa đơn ko tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (mode == 2)
                    {
                        if (this.dgvHoaDon.CurrentRow != null)
                        {
                            var idhd = Decimal.Parse(ID_HD);
                            var danhbo = this.dgvHoaDon.CurrentRow.Cells["SODANHBO"].Value.ToString();
                            var hoten = this.dgvHoaDon.CurrentRow.Cells["HOTEN"].Value.ToString();
                            var hoadon = db.GACHNOes.Where(x => x.ID_HD == idhd).FirstOrDefault();

                            if (hoadon != null)
                            {
                                var id_payservice = hoadon.NV_ID_NOP;
                                var payservice = db.DM_NGANHANG.Where(x => x.NGANHANG_ID == id_payservice).FirstOrDefault();
                                var user_tt = payservice.MA_NGANHANG;
                                var nganhang_tt = payservice.TENNGANHANG;
                                var hinhthuc_tt = hoadon.MALOAI == "CK" ? "CHUYENKHOAN" : hoadon.MALOAI;
                                var ngaythanhtoan = Convert.ToDateTime(hoadon.NGAYTHANHTOAN).ToString("yyyy-MM-dd HH:mm:ss");
                                var nhanvien = Common.username;
                                var sdt = db.KHACHHANGs.Where(x => x.madanhbo == danhbo).FirstOrDefault().SDT_KH;
                                var ghichu = "Đồng bộ gạch từ phần mềm QLCN";
                                var transaction = hoadon.PRODUCTS == null ? "" : hoadon.PRODUCTS;
                                var data = new TB_ThanhToan
                                {
                                    SODANHBO = danhbo,
                                    ID_HD = ID_HD,
                                    USER_TT = user_tt,
                                    NGAY_TT = ngaythanhtoan,
                                    NHANVIEN_TT = nhanvien,
                                    DIENTHOAI_TT = sdt,
                                    HINHTHUC_TT = hinhthuc_tt,
                                    NGANHANG_TT = nganhang_tt,
                                    GHICHU_TT = ghichu,
                                    TRANSACTION_NO = transaction
                                };

                                var result = connect.SyncThuHo(data);
                                if (result)
                                    MessageBox.Show("Đồng bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else MessageBox.Show("Đồng bộ ko thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else MessageBox.Show("Hóa đơn ko tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                MessageBox.Show("Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtdanhbo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
            }
        }

        private void txtdanhbo_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtdanhbo.Text;
            if (text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;
                    btnTim.PerformClick();
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
