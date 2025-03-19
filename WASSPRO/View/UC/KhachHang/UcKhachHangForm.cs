using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo
{
    public partial class UcKhachHangForm : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();

        public UcKhachHangForm()
        {
            InitializeComponent();
        }

        private void KhachHangForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadLT();
            LoadDT();
            LoadHTTT();
            LoadTrangThai();
            LoadLoaiYC();
            LoadLyDo();
            infocomboBox.SelectedIndex = 0;
            if (Common.username == "Vnptcto") hoadontoolStripButton.Visible = true;
        }

        private void LoadLyDo()
        {
            var lydo = from a in db.DM_LYDO orderby a.ten_lydo select a;
            lydocomboBox.DataSource = lydo.ToList();
            lydocomboBox.DisplayMember = "ten_lydo";
            lydocomboBox.ValueMember = "id_lydo";
        }

        private void LoadTrangThai()
        {
            var tt = from a in db.DM_TRANGTHAI_KH select a;
            trangthaicomboBox.DataSource = tt.ToList();
            trangthaicomboBox.DisplayMember = "tenTT";
            trangthaicomboBox.ValueMember = "maTT";
        }

        private void LoadHTTT()
        {
            var httt = from a in db.DM_HINHTHUCTHANHTOAN select a;
            htttcomboBox.DataSource = httt.ToList();
            htttcomboBox.DisplayMember = "tenHTTT";
            htttcomboBox.ValueMember = "maHTTT";
        }

        private void LoadDT()
        {
            var dt = from a in db.DM_DOITUONGSUDUNG select a;
            dtcomboBox.DataSource = dt.ToList();
            dtcomboBox.DisplayMember = "tenDT";
            dtcomboBox.ValueMember = "maDT";
        }

        private void LoadLT()
        {
            var lt = from a in db.LOTRINHs orderby a.TenLT select new { full = a.TenLT, a.MaLT }; //a.maLT + " - " +
            ltcomboBox.DataSource = lt.ToList();
            ltcomboBox.DisplayMember = "full";
            ltcomboBox.ValueMember = "maLT";
        }

        private void LoadLoaiYC()
        {
            var yc = from a in db.DM_LOAIYEUCAU select a;
            yccomboBox.DataSource = yc.ToList();
            yccomboBox.DisplayMember = "tenloai_yc";
            yccomboBox.ValueMember = "maloai_yc";
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            db.Configuration.ProxyCreationEnabled = false;
            var kh = from a in db.Customers
                         //where a.isDongBo == false
                     select new
                     {
                         a.stt_ghi,
                         a.ID_KH,
                         a.madanhbo,
                         a.hoten_KH,
                         a.SDT_KH,
                         a.email,
                         a.diachi,
                         a.soNK,
                         a.maDT,
                         a.tenDT,
                         a.KichCo,
                         a.tenhieu,
                         maLT = a.maLT,
                         a.tenLT,
                         a.MA_HTTT,
                         a.tenHTTT,
                         a.trangthai,
                         sdt = a.SDT_KH,
                         a.ngaylapdat,
                         a.Ngay_Kiemdinh,
                         a.ngaydoi_DH,
                         //chiso = b.chisomoi,
                         a.giaphi,
                         a.isDongBo
                     };
            if (ltcheckBox.Checked)
            {
                string maLT = ltcomboBox.SelectedValue.ToString();
                kh = kh.Where(x => x.maLT == maLT);
            }
            if (dtcheckBox.Checked)
            {
                string maDT = dtcomboBox.SelectedValue.ToString();
                kh = kh.Where(x => x.maDT == maDT);
            }
            if (htttcheckBox.Checked)
            {
                int maHTTT = Convert.ToInt32(htttcomboBox.SelectedValue);
                kh = kh.Where(x => x.MA_HTTT == maHTTT);
            }
            if (trangthaicheckBox.Checked)
            {
                int ma_tt = Convert.ToInt32(trangthaicomboBox.SelectedValue);
                kh = kh.Where(x => x.trangthai == ma_tt);
            }
            if (chkDongBo.Checked)
            {
                kh = kh.Where(x => x.isDongBo == false);
            }
            string input = infotextBox.Text;
            if (infocheckBox.Checked)
            {
                kh = kh.Where(x => x.ID_KH.ToString() == input || x.madanhbo.Contains(input) || x.sdt == input || x.hoten_KH.Contains(input) || x.diachi.Contains(input));
            }
            dataGridView1.DataSource = kh.OrderBy(x => x.maLT).ThenBy(x => x.stt_ghi).ToList();
            if (dataGridView1.RowCount > 0)
            {
                //for (int i = 0; i < dataGridView1.RowCount; i++)
                //    dataGridView1.Rows[i].Cells[sttColumn.Name].Value = i + 1;
                //TODO
                //(this.MdiParent as MainForm).sltoolStripStatusLabel.Visible = true;
                //(this.MdiParent as MainForm).sltoolStripStatusLabel.Text = "Số lượng: " + dataGridView1.RowCount;
            }
            this.Cursor = Cursors.Default;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //TODO
            //(this.MdiParent as MainForm).sltoolStripStatusLabel.Visible = false;
            //this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //KhachHangChiTietForm frm = new KhachHangChiTietForm();
            //frm.MdiParent = this.MdiParent;
            ////foreach (Form otherForm in this.MdiChildren)
            ////    if (otherForm != frm)
            ////        otherForm.Close();
            //frm.Dock = DockStyle.Fill;
            //frm.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                //DoiThongTinKHForm frm = new DoiThongTinKHForm();
                //frm.MdiParent = this.MdiParent;
                ////foreach (Form otherForm in this.MdiChildren)
                ////    if (otherForm != frm)
                ////        otherForm.Close();
                //frm.Dock = DockStyle.Fill;
                //frm.id_kh = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idColumn.Name].Value);
                //frm.Show();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            Common.ExportExcel(dataGridView1);
        }

        private void ltcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ltcheckBox.Checked)
                ltcomboBox.Enabled = true;
            else ltcomboBox.Enabled = false;
        }

        private void dtcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dtcheckBox.Checked)
                dtcomboBox.Enabled = true;
            else
                dtcomboBox.Enabled = false;
        }

        private void htttcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDongBo.Checked)
                dataGridView1.SelectAll();
            else
                dataGridView1.ClearSelection();
        }

        private void trangthaicheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (trangthaicheckBox.Checked)
                trangthaicomboBox.Enabled = true;
            else
                trangthaicomboBox.Enabled = false;
        }

        private void infocheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (infocheckBox.Checked)
            {
                infocomboBox.Enabled = true;
                infotextBox.Enabled = true;
                infotextBox.Focus();
            }
            else
            {
                infocomboBox.Enabled = false;
                infotextBox.Enabled = false;
            }
        }

        private void infotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                seachButton.PerformClick();
        }

        private void bdButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                switch (yccomboBox.SelectedValue.ToString())
                {
                    case "DTT":
                        //DoiThongTinKHForm frmDTT = new DoiThongTinKHForm();
                        //frmDTT.MdiParent = this.MdiParent;
                        //frmDTT.Dock = DockStyle.Fill;
                        //frmDTT.id_kh = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idColumn.Name].Value);
                        //frmDTT.Show();
                        break;

                    default:
                        YEUCAU yc = new YEUCAU();
                        yc.ngayYC = DateTime.Now;
                        yc.ngaytao = DateTime.Now;
                        yc.nguoitao = Common.username;
                        yc.maloai_yc = yccomboBox.SelectedValue.ToString();
                        yc.lydo_id = Convert.ToInt32(lydocomboBox.SelectedValue);
                        yc.ID_KH = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idColumn.Name].Value);
                        yc.TTYC_ID = 1;
                        //Lấy số phiếu lớn nhất
                        //var pyc_max = (from a in db.YEUCAUs orderby a.ID_yeucau descending select a.sophieu).FirstOrDefault();
                        //decimal sophieu = pyc_max != null ? (decimal)pyc_max : 0;
                        yc.sophieu = txtSophieu.Text;
                        db.YEUCAUs.Add(yc);
                        db.SaveChanges();
                        MessageBox.Show("Tạo yêu cầu " + yccomboBox.Text + " thành công!", "Thông báo");
                        break;
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            editButton.PerformClick();
        }

        private void hoadontoolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận đồng bộ khách hàng lên Hệ thống Hóa đơn điện tử?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;
            this.Cursor = Cursors.WaitCursor;
            //Đồng bộ Portal HĐĐT
            QLCongNo.Publish.PublishService ws = new QLCongNo.Publish.PublishService();
            //Lấy acc, pass của webservice
            var info = (from a in db.TAIKHOAN_SERVICE select a).FirstOrDefault();
            string acc_service = info.acc_service;
            string pass_service = info.pass_service;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decimal id_kh = Convert.ToDecimal(row.Cells[idColumn.Name].Value);
                string sql = "SELECT (select 1 as Tag, null as parent, hoten_kh as [Name!1!!CDATA] from KHACHHANG kh2 where kh2.ID_KH=kh.id_kh for xml explicit, type), ID_KH Code, MST_KH TaxCode, ";
                sql += " (select 1 as Tag, null as parent, diachithanhtoan as [Address!1!!CDATA] from KHACHHANG kh2 where kh2.ID_KH=kh.id_kh for xml explicit, type), '' BankAccountName, ";
                sql += "'' BankName, '' BankNumber, '' Email, null fax, '' Phone,'' ContactPerson, '' RepresentPerson, ";
                sql += "CASE MADT WHEN 'D' THEN 0 WHEN 'N' THEN 0 ELSE 1 END as CusType";
                sql += " from KHACHHANG kh where id_kh='" + id_kh + "' FOR XML PATH('Customer'), root ('Customers')"; //
                var xml = db.Database.SqlQuery<string>(sql);
                string xmlCusData = xml.FirstOrDefault().ToString();

                int result = ws.UpdateCus(xmlCusData, acc_service, pass_service, 0);
                if (result != 1)
                {
                    MessageBox.Show("Đồng bộ hóa đơn điện tử thất bại!");
                    this.Cursor = Cursors.Default;
                    return;
                }
                var kh = (from a in db.KHACHHANGs where a.ID_KH == id_kh select a).FirstOrDefault();
                kh.isDongBo = true;
                db.SaveChanges();
            }
            this.Cursor = Cursors.Default;
        }

        private void btnTaoCSN_Click(object sender, EventArgs e)
        {
            var kyghi_moi = (from a in db.DM_KYGHI orderby a.ID_kyghi descending select a).FirstOrDefault();
            if (MessageBox.Show("Xác nhận tạo chỉ số nước kỳ ghi " + kyghi_moi.ten_kyghi + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;
            decimal id_kh = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[idColumn.Name].Value);
            var kh = (from a in db.KHACHHANGs where a.ID_KH == id_kh select a).FirstOrDefault();
            if (kh.trangthai == 1)
            {
                MessageBox.Show("Khách hàng đang ngưng không thể tạo chỉ số nước!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            var kh_csn = (from a in db.CHISONUOCs where a.ID_kyghi == kyghi_moi.ID_kyghi && a.ID_KH == id_kh select a).FirstOrDefault();
            if (kh_csn != null)
            {
                MessageBox.Show("Khách hàng đã có chỉ số nước trong kỳ ghi " + kyghi_moi.ten_kyghi, "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                //var kyghi_cu = (from a in db.DANHMUCKYGHIs
                //                where a.ID_kyghi != kyghi_moi.ID_kyghi orderby a.ID_kyghi descending select a).FirstOrDefault();
                var kyghi_cu = (from a in db.CHISONUOCs where a.ID_KH == id_kh orderby a.ID_kyghi descending select a).FirstOrDefault();
                string kgc = "KH_MOI";
                if (kyghi_cu != null)
                    kgc = kyghi_cu.ID_kyghi;
                var ky_cu = new SqlParameter("@ID_KYGHI", kgc);
                var ky_moi = new SqlParameter("@ID_KYGHI_MOI", kyghi_moi.ID_kyghi);
                var idkh = new SqlParameter("@ID_KH", id_kh);
                var chiso = db.Database.ExecuteSqlCommand("exec InsertCSN @ID_KYGHI,@ID_KYGHI_MOI,@id_kh", ky_cu, ky_moi, idkh);
                MessageBox.Show("Tạo chỉ số nước thành công!");
            }
        }
    }
}