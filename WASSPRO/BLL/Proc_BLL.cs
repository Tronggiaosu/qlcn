using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Proc_BLL
    {
        //execute pro thong ke thong tin
        public SqlDataReader Pro_Thongtin(string kyghi, string hinhthuc, string maCN)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            SqlCommand cmd = cn.executeProc("RPThongtin");
            cmd.Parameters.AddWithValue("kyghi", kyghi);
            cmd.Parameters.AddWithValue("chinhanh", maCN);
            cmd.Parameters.AddWithValue("hinhthuc", hinhthuc);
            dr = cmd.ExecuteReader();
            return dr;
        }
        public DataTable dataHDTonTheoKy(string kyghi)
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string SQL = "execute RPBaoCaoHDTonTheoKy '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        //TEST
        public DataTable dataRPThongtin(string kyghi, int nam, string maCN)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPThongKeThongtin '" + kyghi + "', "+nam+", '" + maCN + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        // phiếu thu nhân viên
        public SqlDataReader phiethuNV(string kyghi, string ID_NV, string ngaylap)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT dbo.chitiet_thu('" + kyghi + "', " + ID_NV + ", '" + ngaylap + "') as tong";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        // bảng kê hóa đơn
        public DataTable dataBangkeHD(string malt, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPBangKeHoaDon '" + malt + "', '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataDoanhThuTheoCN(string cachthu, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPThongKeSanLuongTheoCN '" + cachthu + "', '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        // doanh thu tiền nước
        public DataTable dataDoanhthu(string kyghi,int nam, string maCN)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPDoanhThuTienNuoc '" + maCN + "', "+nam+", '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
             public DataTable dataSDHD(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPTinhHinhSuDungHoaDon '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        // tong hoadon
        public int getTongHD(string kyghi, string macn)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT COUNT(ID_HD) FROM HOADON a, LOTRINH b, KHACHHANG c WHERE a.ID_KH = c.ID_KH and c.maLT = a.MaLT and a.MaLT = b.maLT and isinhd = 1 and kyghi = '" + kyghi + "' and maCN = '" + macn + "'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(obj.ToString());
            }
        }
        // thống kê sử dụng nước
        public DataTable dataSuDungNuoc(string kyghi, int nam, string maCN)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPThongKeSuDungNuoc '" + kyghi + "', "+nam+", '" + maCN + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataSuDungNuoc_Nam(string nam, string maCN)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPThongKeSuDungNuoc_Nam '" + nam + "', '" + maCN + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        // Sản lượng chuẩn thu
        public DataTable dataSanLuongChuanThu(string kyghi, int nam, string maCN)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPSanLuongChuanThu '" + kyghi + "', "+nam +", '"+maCN+"'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataLuuBo(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPLuuBoTheoNhomGia '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        // Thu tồn hóa đơn
        public DataTable dataThuTonHoaDon(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPThuTon_HoaDon '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        // GET Nhân viên thu ngân
        public DataTable dataThuNgan()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "Select a.NV_ID , manv + ' - ' + hoten hoten from NHANVIEN a, LoaiNhanVien b, NHANVIEN_LNV c " +
                         " where a.NV_ID = c.NV_ID and b.ID_LoaiNV = c.ID_LoaiNV  and tenloai like N'%kế toán%' ";
            dt = cn.getData(SQL);
            return dt;
        }
        // Quyết toán hóa đơn
        public DataTable dataQuyetToanHD(string kyghi, string maLT, string ID_NV)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPQuyetToanHoaDon '" + kyghi + "', '" + maLT + "', " + ID_NV + "";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable datatest(string maLT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPNgungNuoc '" + maLT + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataHDTonTheoCachThu(string kyghi, string ngaybd, string ngaykt, string maCN)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPThongKeHDTheoCachThu'" + kyghi + "', '"+ngaybd+"', '"+ngaykt +"', '"+ maCN+"' ";
            dt = cn.getData(SQL);
            return dt;
        }
        // Khách hàng tồn hóa đơn nhiều kỳ
        public DataTable dataTonHoaDon(string kyghi, string tukyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPTonHoaDon_KH '" + kyghi + "', '" + tukyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        // phiếu thu nhân viên
        public SqlDataReader TONHD(string kyghi, string malt)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT count(ID_HD) as soluong, sum(tongtien) as tongtien " +
                         " FROM HOADON WHERE ID_HD not in (select id_hd from CHUNGTU_HOADON) and kyghi = '" + kyghi + "' and MaLT = '" + malt + "'";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public DataTable dataChiTietThuLoTrinh(string kyghi, string chinhanh, string CK, string TT, string KH, string UN, string NT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execure RPChiTietThuLoTrinh '" + kyghi + "', '" + chinhanh + "', '" + CK + "', '" + KH + "', '" + UN + "', '" + NT + "'   ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataHoaDonTonNam(string nam)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPThongKeTonHDTheoNam " + nam + " ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataPhieuThuNV(string kyghi, string SOCT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPPhieuThuNV '" + kyghi + "', '" + SOCT + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataRPNgungNuoc(string ID_KH)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPNgungNuoc " + ID_KH + "";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataPhieuKiemTra(string id_kh)
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string SQL = "execute RPPhieuKiemTra " + id_kh + "";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataTyLeThuTheoKy(string kyghi, string maHTTT, string ngaybd, string ngaykt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPTyLeThuTheoKy '" + kyghi + "', '"+maHTTT+"', '"+ngaybd+"', '"+ngaykt+"'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataTyLeThuTheoNgay(string kyghi, string tungay)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPTyLeThuTheoNgay '" + kyghi + "', '" + tungay+"' " ;
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataChiTietThu(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPChiTietThuLoTrinh '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataBangkeHuyHD(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPBangKeHuyHD '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataChiTietThuTungBo(string kyghi, string tungay, string denngay, string kyghi_gn)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " execute RPChiTietThuLTTheoNgay '" + kyghi + "' , '" + tungay + " 00:00:00', '" + denngay + " 23:59:59', '" + kyghi_gn + "' ";
            dt = cn.getData(SQL);
            return dt;
        }
        public SqlDataReader getTongthanhtoan(string kyghi, string kygh_gn)
        {
            SqlDataReader dr;
            Connect_DB CN = new Connect_DB();
            string SQL = " select count(id_hd) + kytruoc.sl tonghd, sum(tongtien) + kytruoc.sotien tongthanhtoan " +
                         " from HOADON e  left join( " +
                         " select count(a.id_hd) sl, kyghi, sum(sotien) sotien " +
                         " from CHUNGTU_HOADON a, CHUNGTU b, DANHMUCKYGHI c, HOADON d " +
                         " where a.ID_CT = b.ID_CT and b.ID_kyghi = c.ID_kyghi and d.ID_HD = a.ID_HD " +
                         " and ngaytao >= (select ngaytao from DANHMUCKYGHI where ID_kyghi = '" + kygh_gn + "') group by kyghi) kytruoc " +
                         " on e.kyghi = kytruoc.kyghi " +
                         " where sotienno != 0 and IsInHD = 1  and e.kyghi = '" + kyghi + "'  group by kytruoc.sl,  kytruoc.sotien ";
            dr = CN.excuteReader(SQL);
            return dr;
        }
        public DataTable dataChitieuThuTrucTiep(string kyghi, string maloai)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPChiTietThuTrucTiep '" + kyghi + "', '" + maloai + "'";
            dt = cn.getData(SQL);
            return dt;

        }
        public DataTable dataBangKeBienNhan(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPBangKeBienNhan '" + kyghi + "' ";
            dt = cn.getData(SQL);
            return dt;
        }
        public string kyghi_cu(string kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "select top 1 ten_kyghi from DANHMUCKYGHI where ngaytao < (select ngaytao from DANHMUCKYGHI where ID_kyghi = '" + kyghi + "') order by ngaytao desc ";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        public DataTable dataBaoCaoTongHop(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPBaoCaoTongHop '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public SqlDataReader congty()
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM CONGTY";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public DataTable dataHDTon(string kyghi)
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string SQL = "execute RPHoaDonTon '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataHDTon_LT(string kyghi)
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string SQL = "execute RPBaoCaoHDTon_LT '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public SqlDataReader tongthu_LT(string kyghi)
        {
            Connect_DB cn = new Connect_DB();
            SqlDataReader dr;
            string SQL = "select isnull(count(id_hd), 0) hd, isnull(sum(tongtien), 0) tongtien from hoadon where kyghi = '" + kyghi + "'";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public DataTable dataTyLeThuCT(string tungay, string denngay, string cachthu)
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string SQL = "execute RPTyLeThuTheoLoai '" + tungay + "', '" + denngay + "', '" + cachthu + "' ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataGiayBaoTienNuoc(string ID_HD)
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string SQL = "execute RPGiayBaoTienNuoc '" + ID_HD + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        public SqlDataReader dataChiTietHD(string ID_HD)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "execute RPChiTietHD '" + ID_HD + "'";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public SqlDataReader tenkyghi(string id_kyghi)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "select ten_kyghi from DANHMUCKYGHI where ID_Kyghi = '"+id_kyghi+"'";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public SqlDataReader tenHTTT(string maHTTT)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "select tenHTTT from HINHTHUCTHANHTOAN where maHTTT = '" + maHTTT + "'";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public string getUser()
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT hoten FROM NHANVIEN a, NGUOIDUNG b where a.manv = b.manv and b.ma_nd = '" + Common.username + "'";
            obj = cn.ExecuteScalar(SQL);
            return obj.ToString();
        }
        public DataTable dataHDTonDoNo(string kyghi, string maHTTT, string maCN, string tungay, string denngay)
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string SQL = "execute RPHDTonNgungNuoc '" + kyghi + "', '"+maHTTT+"', '"+maCN+"', '"+tungay+"', '"+denngay+"'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable dataDoiDH(string malt, string ngaybd, string ngaykt)
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string SQL = "execute RPThongKeDoiDH '" + ngaybd + "', '"+ngaykt+"', '"+malt+"'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getSOHDHuy(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select right('0000000' + SO_HD, 7) SO_HD from PublishedInvoices where KYHD = '" + kyghi + "' and status = 4";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getdataKHPhatSinh(string tungay, string denngay)
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string sql = "exec RPKhachHangPhatSinh '"+tungay+"', '"+denngay+"'";
            dt = cn.getData(sql);
            return dt;
        }
        public void autoLoTrinh(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenLT tenLT FROM Lotrinh order by tenLT";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["tenLT"].ToString());
                }
            }
            obj.Close();
        }
    }
}
