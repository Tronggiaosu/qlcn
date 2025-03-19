using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class TracuuHD_BLL
    {
        // get data gridview
        public DataTable getDSHD(string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.madanhbo) as STT, so_hd, ky_hieu_hd, chisomoi, chisocu, luongtieuthu, ten_kyghi, id_hd , " +
                         "tongtien0VAT, tongtien - tongtien0VAT as VAT, tongtien, tieuthukytruoc, " +
                         "case when tieuthukytruoc > luongtieuthu then tieuthukytruoc -luongtieuthu  end as giam, " +
                         "case when tieuthukytruoc < luongtieuthu then luongtieuthu -tieuthukytruoc end as tang, " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai "+
                         "FROM KHACHHANG a, CHISONUOC b, HOADON c, DANHMUCKYGHI d " +
                         "WHERE b.ID_kyghi = c.kyghi " +
                         "and a.ID_KH = b.ID_KH " +
                         "and c.ID_KH = a.ID_KH and c.kyghi = d.ID_Kyghi  " +
                         "and a.maLT = '"+malt+"' and isinHD = 1 order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }
        // hóa đơn theo họ tên khách hàng
        public DataTable getDSHD_chuathanhtoan(string ID_KH)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.madanhbo) as STT,so_hd, ky_hieu_hd, chisomoi, chisocu, luongtieuthu, ten_kyghi , ID_HD, " +
                         "tongtien0VAT, tongtien - tongtien0VAT as VAT, tongtien, tieuthukytruoc, " +
                         "case when tieuthukytruoc > luongtieuthu then tieuthukytruoc -luongtieuthu  end as giam, " +
                         "case when tieuthukytruoc < luongtieuthu then luongtieuthu -tieuthukytruoc end as tang, " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai , phieuthu.SOCT " +
                         "FROM KHACHHANG a inner join CHISONUOC b on a.ID_KH = b.ID_KH  and a.ID_KH = " + ID_KH + " " +
                         "inner join HOADON c on b.ID_kyghi = c.kyghi  and sotienno != 0 " +
                         "inner join DANHMUCKYGHI d on c.ID_KH = a.ID_KH and c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         "left join(select soct, id_kh from CHUNGTU_HOADON a, HOADON b, CHUNGTU c where a.ID_HD = b.ID_HD and a.ID_CT = c.ID_CT and ID_KH = " + ID_KH + "  ) phieuthu " +
                         "on a.ID_KH = phieuthu.ID_KH order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }
        // hóa đơn theo mã danh bộ
        public DataTable getDSHD_dathanhtoan(string ID_KH)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.madanhbo) as STT,so_hd, ky_hieu_hd, chisomoi, chisocu, luongtieuthu, ten_kyghi , ID_HD, " +
                         "tongtien0VAT, tongtien - tongtien0VAT as VAT, tongtien, tieuthukytruoc, " +
                         "case when tieuthukytruoc > luongtieuthu then tieuthukytruoc -luongtieuthu  end as giam, " +
                         "case when tieuthukytruoc < luongtieuthu then luongtieuthu -tieuthukytruoc end as tang, " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai , phieuthu.SOCT " +
                         "FROM KHACHHANG a inner join CHISONUOC b on a.ID_KH = b.ID_KH  and a.ID_KH = " + ID_KH + " " +
                         "inner join HOADON c on b.ID_kyghi = c.kyghi  and sotienno = 0 " +
                         "inner join DANHMUCKYGHI d on c.ID_KH = a.ID_KH and c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         "left join(select soct, id_kh from CHUNGTU_HOADON a, HOADON b, CHUNGTU c where a.ID_HD = b.ID_HD and a.ID_CT = c.ID_CT and ID_KH = " + ID_KH + "  ) phieuthu " +
                         "on a.ID_KH = phieuthu.ID_KH order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }
        // hóa đơn theo địa chỉ
        public DataTable getDSHD_kyghi(string ID_KH, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.madanhbo) as STT,so_hd, ky_hieu_hd, chisomoi, chisocu, luongtieuthu, ten_kyghi , ID_HD, " +
                         "tongtien0VAT, tongtien - tongtien0VAT as VAT, tongtien, tieuthukytruoc, " +
                         "case when tieuthukytruoc > luongtieuthu then tieuthukytruoc -luongtieuthu  end as giam, " +
                         "case when tieuthukytruoc < luongtieuthu then luongtieuthu -tieuthukytruoc end as tang, " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai , phieuthu.SOCT " +
                         "FROM KHACHHANG a inner join CHISONUOC b on a.ID_KH = b.ID_KH  and a.ID_KH = " + ID_KH + " " +
                         "inner join HOADON c on b.ID_kyghi = c.kyghi and c.kyghi = '"+kyghi+"' " +
                         "inner join DANHMUCKYGHI d on c.ID_KH = a.ID_KH and c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         "left join(select soct, id_kh from CHUNGTU_HOADON a, HOADON b, CHUNGTU c where a.ID_HD = b.ID_HD and a.ID_CT = c.ID_CT and ID_KH = " + ID_KH + " and c.id_kyghi = '"+kyghi+"' ) phieuthu " +
                         "on a.ID_KH = phieuthu.ID_KH order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }
        // hóa đơn theo địa chỉ
        public DataTable getDSHD_KH_Chi_tiet(string ID_KH)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY a.madanhbo) as STT,so_hd, ky_hieu_hd, chisomoi, chisocu, luongtieuthu, ten_kyghi , c.ID_HD,   "+
                         " tongtien0VAT, c.tongtien - tongtien0VAT as VAT, c.tongtien, tieuthukytruoc, " +
                         " case when tieuthukytruoc > luongtieuthu then tieuthukytruoc -luongtieuthu  end as giam,  " +
                         " case when tieuthukytruoc < luongtieuthu then luongtieuthu -tieuthukytruoc end as tang,  " +
                         " case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai , SOCT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH  and a.ID_KH = "+ID_KH+" " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         " left join CHUNGTU_HOADON e on c.ID_HD = e.ID_HD " +
                         " left join CHUNGTU g on e.ID_CT = g.ID_CT  order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }
        // hóa đơn theo số điện thoại khách hàng
        public DataTable getDSHD_SDT(string malt, string SDT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.madanhbo) as STT, hoten_KH, diachi, a.madanhbo, so_hd, chisomoi, chisocu, luongtieuthu,  ten_kyghi ," +
                         "tongtien0VAT, tongtien - tongtien0VAT as VAT, tongtien, tieuthukytruoc, " +
                         "case when tieuthukytruoc > luongtieuthu then tieuthukytruoc -luongtieuthu  end as giam, " +
                         "case when tieuthukytruoc < luongtieuthu then luongtieuthu -tieuthukytruoc end as tang, " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai " +
                         "FROM KHACHHANG a, CHISONUOC b, HOADON c, DANHMUCKYGHI d " +
                         "WHERE b.ID_kyghi = c.kyghi " +
                         "and a.ID_KH = b.ID_KH " +
                         "and c.ID_KH = a.ID_KH and c.kyghi = d.id_Kyghi and isinHD = 1 " +
                         "and a.maLT = '" + malt + "' and SDT_KH like '%" + SDT + "%' order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }
        // hóa đơn theo trạng thái
        public DataTable getDSHD_TT(string malt, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY  stt_ghi) as STT, c.KY_HIEU_HD, hoten_KH, ngaylap, diachi, a.madanhbo, so_hd, tongtien, c.ID_KH, ten_kyghi , ngaythanhtoan,  " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai " +
                         "FROM KHACHHANG a, CHISONUOC b, HOADON c, DANHMUCKYGHI d " +
                         "WHERE b.ID_kyghi = c.kyghi " +
                         "and a.ID_KH = b.ID_KH " +
                         "and c.ID_KH = a.ID_KH and  c.kyghi = d.id_Kyghi and isinHD = 1 " +
                         "and c.maLT = '" + malt + "' and c.kyghi = '"+kyghi+ "' and c.sotienno = 0 order by stt_ghi";
            dt = cn.getData(SQL);
            return dt;
        }
        // hóa đơn theo trạng thái chưa thanh toán
        public DataTable getDSHD_TT_chuaTT(string malt, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY stt_ghi) as STT,ngaylap, hoten_KH, diachi, a.madanhbo, so_hd, tongtien, c.ID_KH, ten_kyghi, ngaythanhtoan,  " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai " +
                         "FROM KHACHHANG a, CHISONUOC b, HOADON c, DANHMUCKYGHI d " +
                         "WHERE b.ID_kyghi = c.kyghi " +
                         "and a.ID_KH = b.ID_KH " +
                         "and c.ID_KH = a.ID_KH and c.kyghi = d.id_Kyghi and isinHD = 1 " +
                         "and c.maLT = '"+malt+"' and c.kyghi = '"+kyghi+ "' and ID_HD NOT IN (SELECT ID_HD FROM HOADON WHERE sotienno = 0) order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }
        // hóa đơn khách hàng theo kỳ ghi
        public DataTable getDSHD_TT_kyghi(string malt, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY  stt_ghi) as STT, c.KY_HIEU_HD, hoten_KH, ngaylap, diachi, a.madanhbo, so_hd,  c.ID_KH, ten_kyghi, ngaythanhtoan , " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai, tongtien " +
                         "FROM KHACHHANG a, CHISONUOC b, HOADON c, DANHMUCKYGHI d " +
                         "WHERE b.ID_kyghi = c.kyghi " +
                         "and a.ID_KH = b.ID_KH " +
                         "and c.ID_KH = a.ID_KH and c.kyghi = d.ID_Kyghi and isinHD = 1 " +
                         "and c.maLT = '" + malt + "' and c.kyghi = '"+kyghi+ "' order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDSHD_TT_ngaythu(string malt, string kyghi, string ngaythu)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY  stt_ghi) as STT, c.KY_HIEU_HD, hoten_KH, diachi, ngaylap, a.madanhbo, so_hd, c.ID_KH, ten_kyghi, ngaythanhtoan , c.tongtien,  " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai " +
                         "FROM KHACHHANG a, CHISONUOC b, HOADON c, DANHMUCKYGHI d " +
                         "WHERE b.ID_kyghi = c.kyghi " +
                         "and a.ID_KH = b.ID_KH " +
                         "and c.ID_KH = a.ID_KH and c.kyghi = d.ID_Kyghi and isinHD = 1 " +
                         "and a.maLT = '" + malt + "' and c.ngaythanhtoan = '" + ngaythu + "' order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDSHD_NVThu(string malt, string kyghi, string NV_ID)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY  stt_ghi) as STT, c.KY_HIEU_HD, hoten_KH, c.ngaylap, diachi, a.madanhbo, so_hd,  c.ID_KH, ten_kyghi, ngaythanhtoan , " +
                         " case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai, c.tongtien " +
                         " FROM KHACHHANG a, HOADON c, DANHMUCKYGHI d, LOTRINH_THU e, CHUNGTU_HOADON f, CHUNGTU g " +
                         " WHERE  c.ID_KH = a.ID_KH and c.kyghi = d.ID_Kyghi and c.ID_HD = f.ID_HD " +
                         " and f.ID_CT = g.ID_CT and e.malt = c.MaLT and e.nv_id = g.NV_ID_nop " +
                         " and isinHD = 1 and c.maLT = '"+malt+"' and c.kyghi = '"+kyghi+"' and g.NV_ID_nop = "+NV_ID+"  order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }

        public DataTable getDSHD_SOHD(string malt, string kyghi, string sohd)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY  stt_ghi) as STT, hoten_KH, ngaylap, diachi, a.madanhbo, so_hd,  c.ID_KH, ten_kyghi, ngaythanhtoan , " +
                         "case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai, tongtien " +
                         "FROM KHACHHANG a, CHISONUOC b, HOADON c, DANHMUCKYGHI d " +
                         "WHERE b.ID_kyghi = c.kyghi " +
                         "and a.ID_KH = b.ID_KH " +
                         "and c.ID_KH = a.ID_KH and c.kyghi = d.ID_Kyghi and isinHD = 1 " +
                         "and a.maLT = '" + malt + "' and c.kyghi = '" + kyghi + "' and c.so_hd like '%"+sohd+"%' order by stt_ghi ";
            dt = cn.getData(SQL);
            return dt;
        }

        public DataTable getDataHoaDon()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM DSHOADON ORDER BY ID_KH";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_GN()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_kh) as STT, so_hd, ky_hieu_hd, c.ID_HD, c.so_HD, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, convert(varchar,a.id_kh) +' - ' + a.hoten_KH hoten_KH, diachi, a.id_kh, a.madanhbo, "+
                         " case when sotienno != 0 then 0 else 1 end thu, a.maLT "+
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH and isinHD = 1 and sotienno != 0  " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi  order by c.id_kh ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_GN_LT(string maLT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_kh) as STT, so_hd, ky_hieu_hd, c.ID_HD, c.so_HD, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, convert(varchar,a.id_kh) +' - ' + a.hoten_KH hoten_KH, diachi, a.id_kh, a.madanhbo, " +
                         " case when sotienno != 0 then 0 else 1 end thu, a.maLT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.malt = '"+maLT+"' " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH and isinHD = 1 and sotienno != 0  " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi  order by c.id_kh ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_GN_IDKH(string id_kh)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_kh) as STT, so_hd, ky_hieu_hd, c.ID_HD, c.so_HD, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, convert(varchar,a.id_kh) +' - ' + a.hoten_KH hoten_KH, diachi, a.id_kh, a.madanhbo, " +
                         " case when sotienno != 0 then 0 else 1 end thu, a.maLT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.ID_KH = "+id_kh+" " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH and isinHD = 1 and sotienno != 0  " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi  order by c.id_kh ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_GN_DB(string madanhbo)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_kh) as STT, so_hd, ky_hieu_hd, c.ID_HD, c.so_HD, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, convert(varchar,a.id_kh) +' - ' + a.hoten_KH hoten_KH, diachi, a.id_kh, a.madanhbo, " +
                         " case when sotienno != 0 then 0 else 1 end thu, a.maLT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.madanhbo like '%" + madanhbo + "%' " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH and isinHD = 1 and sotienno != 0  " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi  order by c.id_kh ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_GN_hoten(string hoten)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_kh) as STT, so_hd, ky_hieu_hd, c.ID_HD, c.so_HD, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, convert(varchar,a.id_kh) +' - ' + a.hoten_KH hoten_KH, diachi, a.id_kh, a.madanhbo, " +
                         " case when sotienno != 0 then 0 else 1 end thu, a.maLT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.hoten_KH = N'" + hoten + "' " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH and isinHD = 1 and sotienno != 0  " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi  order by c.id_kh ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_GN_DC(string diachi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_kh) as STT, so_hd, ky_hieu_hd, c.ID_HD, c.so_HD, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, convert(varchar,a.id_kh) +' - ' + a.hoten_KH hoten_KH, diachi, a.id_kh, a.madanhbo, " +
                         " case when sotienno != 0 then 0 else 1 end thu, a.maLT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.diachi = N'" + diachi + "' " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH and isinHD = 1 and sotienno != 0  " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi  order by c.id_kh ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_GN_SOHD(string sohd)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_kh) as STT, so_hd, ky_hieu_hd, c.ID_HD, c.so_HD, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, convert(varchar,a.id_kh) +' - ' + a.hoten_KH hoten_KH, diachi, a.id_kh, a.madanhbo, " +
                         " case when sotienno != 0 then 0 else 1 end thu, a.maLT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH  " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH and isinHD = 1 and sotienno != 0  and c.so_hd = '" + sohd + "' " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi  order by c.id_kh ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_GN_CT(string cachthu)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_kh) as STT, so_hd, ky_hieu_hd, c.ID_HD, c.so_HD, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, convert(varchar,a.id_kh) +' - ' + a.hoten_KH hoten_KH, diachi, a.id_kh, a.madanhbo, " +
                         " case when sotienno != 0 then 0 else 1 end thu, a.maLT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH  " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH and isinHD = 1 and sotienno != 0  and a.MA_HTTT = " + cachthu + " " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi  order by c.id_kh ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_id_kh(string id_kh)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_hd) as STT, so_hd, ky_hieu_hd, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, a.hoten_KH, diachi, a.id_kh, a.madanhbo, diachi, a.maLT,  " +
                         " case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai, SOCT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.id_kh = "+id_kh+" " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         " left join CHUNGTU_HOADON e on c.ID_HD = e.ID_HD " +
                         " left join CHUNGTU g on e.ID_CT = g.ID_CT order by c.id_hd ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_madanhbo(string madanhbo)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_hd) as STT, so_hd, ky_hieu_hd, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, a.hoten_KH, diachi, a.id_kh, a.madanhbo, diachi,a.maLT,  " +
                         " case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai, SOCT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.madanhbo like '%" + madanhbo + "%' " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         " left join CHUNGTU_HOADON e on c.ID_HD = e.ID_HD " +
                         " left join CHUNGTU g on e.ID_CT = g.ID_CT order by c.id_hd ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_hoten(string hoten)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_hd) as STT, so_hd, ky_hieu_hd, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, a.hoten_KH, diachi, a.id_kh, a.madanhbo, diachi,a.maLT, " +
                         " case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai, SOCT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.hoten_KH = N'" + hoten + "' " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         " left join CHUNGTU_HOADON e on c.ID_HD = e.ID_HD " +
                         " left join CHUNGTU g on e.ID_CT = g.ID_CT order by c.id_hd ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_diachi(string diachi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_hd) as STT, so_hd, ky_hieu_hd, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, a.hoten_KH, diachi, a.id_kh, a.madanhbo, diachi, a.maLT, " +
                         " case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai, SOCT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.diachi = N'" + diachi + "' " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         " left join CHUNGTU_HOADON e on c.ID_HD = e.ID_HD " +
                         " left join CHUNGTU g on e.ID_CT = g.ID_CT order by c.id_hd ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_soHD(string soHD)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_hd) as STT, so_hd, ky_hieu_hd, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, a.hoten_KH, diachi, a.id_kh, a.madanhbo, diachi, a.maLT, " +
                         " case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai, SOCT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH and c.so_hd = '"+soHD+"' " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         " left join CHUNGTU_HOADON e on c.ID_HD = e.ID_HD " +
                         " left join CHUNGTU g on e.ID_CT = g.ID_CT order by c.id_hd ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDataHoaDon_LT(string maLT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY c.id_hd) as STT, so_hd, ky_hieu_hd, " +
                         " luongtieuthu, ten_kyghi, c.tongtien, a.hoten_KH, diachi, a.id_kh, a.madanhbo, diachi,a.malT,  " +
                         " case when sotienno = 0 then N'Đã thanh toán' else N'Chưa thanh toán' end as trangthai, SOCT " +
                         " FROM KHACHHANG a " +
                         " inner join CHISONUOC b on a.ID_KH = b.ID_KH and a.malt = '" + maLT + "' " +
                         " inner join HOADON c on b.ID_kyghi = c.kyghi  and a.ID_KH = c.ID_KH " +
                         " inner join DANHMUCKYGHI d on c.kyghi = d.ID_kyghi and isinHD = 1 " +
                         " left join CHUNGTU_HOADON e on c.ID_HD = e.ID_HD " +
                         " left join CHUNGTU g on e.ID_CT = g.ID_CT order by c.id_hd ";
            dt = cn.getData(SQL);
            return dt;
        }
        public SqlDataReader GetAcc_Service()
        {
            Connect_DB cn = new Connect_DB();
            SqlDataReader dr;
            string SQL = "SELECT * from TAIKHOAN_SERVICE";
            dr = cn.excuteReader(SQL);
            return dr;
        }
    }
}
