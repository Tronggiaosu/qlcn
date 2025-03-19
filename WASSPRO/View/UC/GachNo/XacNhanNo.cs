using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace QLCongNo.View.UC.GachNo
{
    public partial class UcXacNhanNo : View.Core.NovUserControl
    {
        private CAPNUOC_TNCEntities db = new CAPNUOC_TNCEntities();
        private List<getDanhSachKhachHang_Result> dataHoaDon = new List<getDanhSachKhachHang_Result>();
        private int TotalPage = 0;
        private int CurrentPageIndex = 1;
        private int PgSize = 50;
        public static string hoTen;
        public static string diaChi;
        public static string danhBo;
        public UcXacNhanNo()
        {
            InitializeComponent();
            btnTim.Click += btnTim_Click;
            txtTim.KeyDown += txtTim_KeyDown;
            quitButton.Click += quitButton_Click;
            btnEX.Click += btnEX_Click;
            dgvKhachHang.RowEnter += dgvKhachHang_RowEnter;
            //dgvHoaDon.CellContentClick += dgvHoaDon_CellContentClick;
            cboQuan.SelectedIndexChanged += cboQuan_SelectedIndexChanged;
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




        private void dgvKhachHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhachHang.RowCount > 0)
                {
                    decimal IDKH = decimal.Parse(dgvKhachHang[ID_KH_dgv1.Name, e.RowIndex].Value.ToString());
                    //var dsHoadon = db.getDSHoaDon_KH(IDKH).ToList();
                    var danhSachHoaDon = (from h in db.HOADONs
                                          join ht in db.HoaDonTons on h.ID_HD equals ht.IDHD
                                          join k in db.DM_KYGHI on h.kyghi equals k.ID_kyghi
                                          where h.ID_KH == IDKH
                                          select new
                                          {
                                              //h.ID_HD,
                                              h.hoten,
                                              h.diachihoadon,
                                              h.DANHBO,
                                              h.SO_HD,
                                              kyghi = k.ten_kyghi,
                                              h.m3tieuthu,
                                              h.tongtien,
                                              h.ghichu
                                          })
                                          .AsEnumerable() // Chuyển sang danh sách trong bộ nhớ
                                          .Select((hoaDon, index) => new
                                          {
                                              STT = index + 1, // Thêm số thứ tự (bắt đầu từ 1)
                                              //hoaDon.ID_HD,
                                              hoaDon.hoten,
                                              hoaDon.diachihoadon,
                                              hoaDon.DANHBO,
                                              hoaDon.SO_HD,
                                              hoaDon.kyghi,
                                              hoaDon.m3tieuthu,
                                              hoaDon.tongtien,
                                              hoaDon.ghichu
                                          })
                                          .ToList();
                    if (danhSachHoaDon.Count > 0)
                    {
                        // Sắp xếp danh sách theo cột 'kyghi' và cập nhật lại STT
                        var danhSachHoaDonSapXep = danhSachHoaDon
                            .OrderByDescending(x => DateTime.ParseExact(x.kyghi, "MM/yyyy", null))
                            .Select((hoaDon, index) => new
                            {
                                STT = index + 1, // Cập nhật lại STT
                                hoaDon.hoten,
                                hoaDon.diachihoadon,
                                hoaDon.DANHBO,
                                hoaDon.SO_HD,
                                hoaDon.kyghi,
                                hoaDon.m3tieuthu,
                                hoaDon.tongtien,
                                hoaDon.ghichu
                            })
                            .ToList();

                        dgvHoaDon.DataSource = danhSachHoaDonSapXep;
                        if (danhSachHoaDonSapXep[0].hoten != null && danhSachHoaDonSapXep[0].diachihoadon != null && danhSachHoaDonSapXep[0].DANHBO != null)
                        {
                            hoTen = danhSachHoaDonSapXep[0].hoten;
                            diaChi = danhSachHoaDonSapXep[0].diachihoadon;
                            danhBo = danhSachHoaDonSapXep[0].DANHBO;
                        }
                    }
                    else
                        dgvHoaDon.DataSource = null;
                }
                else
                    dgvHoaDon.DataSource = null;
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình lấy dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static string SaveFile(string content, string fileNme = "", string path = null)
        {
            if (String.IsNullOrEmpty(path))
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string ex = "." + fileNme.Substring(fileNme.LastIndexOf(".") + 1);

            /// path += "\\" + fileNme;
            int i = 1;
            string tem = fileNme;

            string newFullPath = path + "\\" + fileNme;

            while (File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}-{1}", fileNme, i++);
                newFullPath = Path.Combine(path, tempFileName + ex);
            }
            path = newFullPath;

            if (fileNme.Substring(fileNme.LastIndexOf(".") + 1) == "pdf")
            {
                byte[] bytes = Convert.FromBase64String(content);
                System.IO.FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

                System.IO.BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();
                return (File.Exists(path)) ? path : "False";
            }
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path);
                file.Write(content);
                file.Close();
            }
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }

            return (File.Exists(path)) ? path : "False";
        }

        private void btnRF_Click(object sender, EventArgs e)
        {
            btnTim.PerformClick();
        }

        private void btnEX_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Size = new Size(1200, 800);
            string htmlTable = ConvertDataGridViewToHtmlTable(dgvHoaDon);
            string htmlContentWithTable = htmlContent.Replace("</body>", $"{htmlTable}</body>");
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            //Lấy ngày tháng năm hiện tại
            DateTime currentDate = DateTime.Now;
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;
            htmlContentWithTable = htmlContentWithTable.Replace("{hoten}", hoTen)
                         .Replace("{diachi}", diaChi)
                         .Replace("{danhbo}", danhBo)
                         .Replace("{ngay}", day.ToString())
                         .Replace("{thang}", month.ToString())
                         .Replace("{nam}", year.ToString());
            webBrowser.DocumentText = htmlContentWithTable;
            frm.Controls.Add(webBrowser);

            // Hiển thị form mới
            frm.ShowDialog();
        }

        string htmlContent = @"
                <!DOCTYPE html>
                <html lang=""vi"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Bảng kê hóa đơn</title>
                    <style>
                        body {
                            font-family: 'Times New Roman', serif;
                            margin: 20px;
                            text-align: center;
                        }
                        h1 {
                            font-size: 20px;
                            font-weight: bold;
                            margin: 10px 0;
                        }
                        h2 {
                            font-size: 18px;
                            font-weight: bold;
                            margin: 10px 0;
                        }
                        p {
                            margin: 5px 0;
                        }
                        .right-align {
                            text-align: right;
                            font-style: italic;
                        }
                        table {
                            width: 100%;
                            border: none;
                            text-align: center;
                            margin-bottom: 20px;
                        }
                        td {
                            padding: 5px;
                        }
                        .underline {
                            display: inline-block;
                            text-decoration: underline;
                            margin-bottom: 10px;
                        }
                        .big-text {
                            font-size: 16px; 
                        }
                        .info-customer {
                            text-align: left; 
                            padding-left: 100px;
                        }
                    </style>
                </head>
                <body>
                    <table>
                        <tr>
                            <td><span class=""big-text"">CÔNG TY CỔ PHẦN CẤP NƯỚC THỦ ĐỨC</span></td>
                            <td><span class=""big-text"">CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</span></td>
                        </tr>
                        <tr>
                            <td><div class=""underline""><strong>PHÒNG GHI THU</strong></div></td>
                            <td><div class=""underline""><strong> Độc lập - Tự do - Hạnh phúc</strong></div></td>
                        </tr>
                    </table>

                    <p class=""right-align"">TP.Hồ Chí Minh, ngày {ngay} tháng {thang} năm {nam}</p>
                    <h1>BẢNG KÊ CÁC HÓA ĐƠN NỢ TỒN</h1>

                    <p class=""info-customer"">Tên khách hàng: {hoten}</p>
                    <p class=""info-customer"">Địa chỉ: {diachi}</p>
                    <p class=""info-customer"">Danh bộ: {danhbo}</p>
                </body>
                </html>";


        private string ConvertDataGridViewToHtmlTable(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0) return "<p>Không có dữ liệu để hiển thị.</p>";

            // Khởi tạo bảng HTML
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Append("<table border='1' style='width: 85%; border-collapse: collapse; text-align: center;margin-top:20px;'>");

            // Tạo tiêu đề bảng
            htmlTable.Append("<thead><tr>");
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                htmlTable.AppendFormat("<th style='padding: 5px; background-color: #f2f2f2;'>{0}</th>", column.HeaderText);
            }
            htmlTable.Append("</tr></thead>");

            // Thêm dữ liệu từ các hàng
            htmlTable.Append("<tbody>");

            // Tổng m3 và tổng tiền
            decimal totalM3 = 0;
            decimal totalMoney = 0;

            // Xác định chỉ số cột m3 và tổng tiền
            int m3ColumnIndex = dataGridView.Columns["som3Column"]?.Index ?? -1;
            int totalMoneyColumnIndex = dataGridView.Columns["soTienColumn"]?.Index ?? -1;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    htmlTable.Append("<tr>");
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string cellValue = cell.Value?.ToString() ?? "";

                        if (cell.ColumnIndex == totalMoneyColumnIndex && decimal.TryParse(cellValue, out decimal moneyValue))
                        {
                            cellValue = moneyValue.ToString("#,0");
                            totalMoney += moneyValue;
                        }

                        htmlTable.AppendFormat("<td style='padding: 5px;'>{0}</td>", cellValue);

                        if (cell.ColumnIndex == m3ColumnIndex && decimal.TryParse(cellValue, out decimal m3Value))
                        {
                            totalM3 += m3Value;
                        }
                    }
                    htmlTable.Append("</tr>");
                }
            }
            htmlTable.Append("</tbody>");
            // Thêm hàng tổng vào cuối bảng
            htmlTable.Append("<tfoot>");
            htmlTable.Append("<tr>");

            // Ô tổng cộng
            htmlTable.AppendFormat("<td colspan='{0}' style='padding: 5px; font-weight: bold; text-align: center;'>TỔNG CỘNG:</td>", Math.Max(1, Math.Min(m3ColumnIndex, totalMoneyColumnIndex)));

            // Ô tổng m3
            htmlTable.AppendFormat("<td style='padding: 5px; font-weight: bold;'>{0}</td>", totalM3);

            // Ô tổng tiền
            htmlTable.AppendFormat("<td style='padding: 5px; font-weight: bold;'>{0}</td>", totalMoney.ToString("#,0"));

            // Thêm các ô trống nếu còn cột phía sau
            int remainingColumns = dataGridView.Columns.Count - Math.Max(m3ColumnIndex, totalMoneyColumnIndex) - 1;
            if (remainingColumns > 0)
            {
                htmlTable.AppendFormat("<td colspan='{0}'></td>", remainingColumns);
            }

            htmlTable.Append("</tr>");
            htmlTable.Append("</tfoot>");
            htmlTable.Append("</table>");
            //
            htmlTable.Append("<div style='margin-top: 20px;'>");
            htmlTable.Append("<table style='width: 100%;'>");
            //
            htmlTable.Append("<tr>");

            // Nơi nhận
            htmlTable.Append("<td style='width: 50%; text-align: left; padding-left: 60px; vertical-align: top;'>");
            htmlTable.Append("* Nơi nhận:<br>");
            htmlTable.Append("- Phòng KDDVKH;<br>");
            htmlTable.Append("- Phòng Kiểm Tra;<br>");
            htmlTable.Append("- Lưu vt, (Hằng).");
            htmlTable.Append("</td>");

            // PHÒNG GHI THU
            htmlTable.Append("<td style='width: 50%; text-align: right; padding-right: 100px; vertical-align: top;'>");
            htmlTable.Append("<span style='font-weight: bold;'>PHÒNG GHI THU</span><br>");
            htmlTable.Append("<span style='font-weight: bold; display: inline-block; margin-top: 50px;'>Nguyễn Hữu Kiệt</span>");
            htmlTable.Append("</td>");

            htmlTable.Append("</tr>");
            htmlTable.Append("</table>");
            htmlTable.Append("</div>");


            return htmlTable.ToString();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            //   this.Close();
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtTim.Text;
            if (txtTim.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
                MessageBox.Show("Chưa nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.Cursor = Cursors.WaitCursor;
                //string kyghi = cboKy.SelectedValue.ToString();
                //int nam = int.Parse(cboNam.SelectedValue.ToString());
                //decimal dot = decimal.Parse(cboDot.SelectedValue.ToString());
                string maPhuong = cboPhuong.SelectedValue.ToString();
                string maQuan = cboQuan.SelectedValue.ToString();
                string strSearch = txtTim.Text;
                var khachhang = db.getDanhSachKhachHang(2, maPhuong, maQuan, "", (strSearch.Replace(" ", String.Empty)).ToUpper()).Distinct().ToList();
                dgvKhachHang.DataSource = khachhang.ToList();
                if (khachhang.Count == 0)
                    dgvHoaDon.DataSource = null;
                this.Cursor = Cursors.Default;
            }
        }

        private void frXacNhanNo_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvHoaDon.AutoGenerateColumns = false;
            // dm ky ghi
            //cboKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_KYGHI> dmKyghi = new List<DM_KYGHI>();
            //dmKyghi.Add(new DM_KYGHI() { ID_kyghi = "0", ten_kyghi = "Tất cả" });
            var dataKyghi = db.DM_KYGHI.OrderBy(x => x.ten_kyghi).ToList();
            dmKyghi.AddRange(dataKyghi);
            //cboKy.DataSource = dmKyghi.ToList();
            //cboKy.ValueMember = "ID_kyghi";
            //cboKy.DisplayMember = "ten_kyghi";
            // dm nam
            //cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_NAM> dmNam = new List<DM_NAM>();
            //dmNam.Add(new DM_NAM() { NAM_ID = 0, NAM = "Tất cả" });
            var dataNam = db.DM_NAM.OrderBy(x => x.NAM).ToList();
            dmNam.AddRange(dataNam);
            //cboNam.DataSource = dmNam.ToList();
            //cboNam.ValueMember = "NAM_ID";
            //cboNam.DisplayMember = "NAM";
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
            // dm phuong
            cboPhuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_PHUONG> dsPhuong = new List<DM_PHUONG>();
            dsPhuong.Add(new DM_PHUONG() { maPhuong = "0", tenPhuong = "Tất cả" });
            var dataPhuong = db.DM_PHUONG.OrderBy(x => x.tenPhuong).ToList();
            dsPhuong.AddRange(dataPhuong);
            cboPhuong.DataSource = dsPhuong.ToList();
            cboPhuong.ValueMember = "maPhuong";
            cboPhuong.DisplayMember = "tenPhuong";
            // dm quan
            cboQuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_QUAN> dsQuan = new List<DM_QUAN>();
            dsQuan.Add(new DM_QUAN() { maQuan = "0", tenQuan = "Tất cả" });
            var dataQuan = db.DM_QUAN.OrderBy(x => x.tenQuan).ToList();
            dsQuan.AddRange(dataQuan);
            cboQuan.DataSource = dsQuan.ToList();
            cboQuan.ValueMember = "maQuan";
            cboQuan.DisplayMember = "tenQuan";
            // dot
            //cboDot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            List<DM_DOT> dmDot = new List<DM_DOT>();
            dmDot.Add(new DM_DOT() { DOT_ID = 0, TENDOT = "Tất cả" });
            var dataDot = db.DM_DOT.OrderBy(x => x.TENDOT).ToList();
            dmDot.AddRange(dataDot);
            //cboDot.DataSource = dmDot.ToList();
            //cboDot.ValueMember = "DOT_ID";
            //cboDot.DisplayMember = "TENDOT";
            //dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
    }
}
//public class InfoCustomer
//{
//    public string SO_HD { get; set; }
//    public int STT { get; set; }
//    //public string soDanhBo { get; set; }
//    public string diachihoadon { get; set; }
//    public string kyghi { get; set; }
//    public string m3tieuthu { get; set; }
//    public string tongtien { get; set; }
//    public string ghichu { get; set; }
//    public string hoten { get; set; }
//}