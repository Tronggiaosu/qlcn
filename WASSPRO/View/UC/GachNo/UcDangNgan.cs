using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcDangNgan : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        public string maloai;

        public UcDangNgan()
        {
            InitializeComponent();
            quitButton.Click += quitButton_Click;
            btnTim.Click += btnTim_Click;
            btnConfirm.Click += btnConfirm_Click;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                int loaiHD = int.Parse(cboloaiHD.SelectedValue.ToString());
                var maDT = cboDTSD.SelectedValue.ToString();
                var hinhthuc = cboHTTT.SelectedValue.ToString();
                decimal NVID = decimal.Parse(cboTNV.SelectedValue.ToString());
                bool isdangngan = false;
                if (maloai == "0")
                    isdangngan = true;
                var dataSource = db.getDangNganTheoNgay(NVID, loaiHD, tungay, denngay, maloai, maDT, isdangngan, 0, 0).ToList();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Dat files (*.dat)|*.dat";
                saveFileDialog.DefaultExt = "dat";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    string fileName = saveFileDialog.FileName;
                    //before your loop
                    var csv = new StringBuilder();
                    //in your loop
                    foreach (var item in dataSource)
                    {
                        var nhanvien = db.NHANVIENs.Where(x => x.NV_ID == item.NV_ID_LAP).FirstOrDefault();
                        var httt = 0;
                        if (item.LoaiHD_ID == 11 || item.LoaiHD_ID == 12)
                            httt = 1;
                        var nam = item.nam;
                        var sophathanh = item.SOPHATHANH;
                        var NVIDNop = nhanvien.somay;
                        var ngayct = item.ngaydangngan.ToString();
                        var nuocdc = item.lechm3;
                        var tiennuoc_dc = item.lechtiennuoc;
                        var thue_dc = item.lechtienvat;
                        var phi_dc = item.lechtienBVMT;
                        var newLine = string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\"", nam, sophathanh, NVIDNop, ngayct, nuocdc, tiennuoc_dc, thue_dc, phi_dc, httt);
                        csv.AppendLine(newLine);
                    }
                    // export file path
                    File.WriteAllText(fileName, csv.ToString());
                    MessageBox.Show("Đăng ngân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "ReportViewer//ReportView//RPDangNgan.rdlc";
            var tungay = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            var denngay = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            int loaiHD = int.Parse(cboloaiHD.SelectedValue.ToString());
            var maDT = cboDTSD.SelectedValue.ToString();
            var hinhthuc = cboHTTT.SelectedValue.ToString();
            decimal NVID = decimal.Parse(cboTNV.SelectedValue.ToString());
            bool isdangngan = false;
            if (maloai == "0")
                isdangngan = true;
            var dataSource = db.getDangNganTheoNgay(NVID, loaiHD, tungay, denngay, maloai, maDT, isdangngan, 0, 0).ToList();
            this.getDangNganTheoNgayBindingSource1.DataSource = dataSource.ToList();
            string tenbaocao = "";
            if (maloai == "KH")
                tenbaocao = "ĐĂNG NGÂN CỦA THU NGÂN TẠI QUẦY";
            if (maloai == "CK")
                tenbaocao = "ĐĂNG NGÂN CỦA THU NGÂN CHUYỂN KHOẢN";
            if (maloai == "TT")
                tenbaocao = "ĐĂNG NGÂN CỦA NHÂN VIÊN THU";
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("tenbaocao", tenbaocao));
            this.reportViewer1.LocalReport.SetParameters(param);
            reportViewer1.RefreshReport();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }

        private void frDangNgan_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            var nguoidung = db.NGUOIDUNGs.ToList();
            if (maloai != "0")
                nguoidung = nguoidung.Where(x => x.ma_nd == Common.username).ToList();
            var NVLap = nguoidung.Select(x => new { hoten = x.NHANVIEN.somay + " - " + x.NHANVIEN.hoten, x.nv_id }).ToList();
            cboTNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTNV.DataSource = NVLap.ToList();
            cboTNV.ValueMember = "nv_id";
            cboTNV.DisplayMember = "hoten";
            // loai hoa don
            cboloaiHD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_LOAIHOADON> dmLoaiHD = new List<DM_LOAIHOADON>();
            dmLoaiHD.Add(new DM_LOAIHOADON() { LoaiHD_ID = 0, tenloaiHD = "Tất cả" });
            var dataLoaiHD = db.DM_LOAIHOADON.OrderBy(x => x.tenloaiHD).ToList();
            dmLoaiHD.AddRange(dataLoaiHD);
            cboloaiHD.DataSource = dmLoaiHD.ToList();
            cboloaiHD.ValueMember = "LoaiHD_ID";
            cboloaiHD.DisplayMember = "tenloaiHD";
            // loai doi tuong su dung
            cboDTSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_DOITUONGSUDUNG> dataDTSD = new List<DM_DOITUONGSUDUNG>();
            dataDTSD.Add(new DM_DOITUONGSUDUNG() { maDT = "0", tenDT = "Tất cả" });
            var dsDT = db.DM_DOITUONGSUDUNG.OrderBy(x => x.tenDT).ToList();
            dataDTSD.AddRange(dsDT);
            cboDTSD.DataSource = dataDTSD.ToList();
            cboDTSD.ValueMember = "maDT";
            cboDTSD.DisplayMember = "tenDT";
            // dm hinh thuc thanh toan
            cboHTTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_LOAICHUNGTU> hinhthuc = new List<DM_LOAICHUNGTU>();
            hinhthuc.Add(new DM_LOAICHUNGTU() { maloai = "0", tenloai = "Tất cả" });
            var dshinhthuc = db.DM_LOAICHUNGTU.OrderBy(x => x.tenloai).ToList();
            hinhthuc.AddRange(dshinhthuc);
            cboHTTT.DataSource = hinhthuc.ToList();
            cboHTTT.DisplayMember = "tenloai";
            cboHTTT.ValueMember = "maloai";
            btnConfirm.Visible = false;
            if (maloai == "0")
                btnConfirm.Visible = true;
        }
    }
}