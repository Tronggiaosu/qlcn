using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class BienDong_BLL
    {
        // get data khachhang
        //public DataTable getdata_KH()
        //{
        //    DataTable dt = new DataTable();
        //    Connect_DB cn = new Connect_DB();
        //    string SQL = "SELECT * FROM khachhang";
        //    dt = cn.getData(SQL);
        //    return dt;
        //}
        // get data yêu cầu
        //public DataTable getdata_KH(string tenKH)
        //{
        //    DataTable dt = new DataTable();
        //    Connect_DB cn = new Connect_DB();
        //    string SQL = "SELECT  b.madanhbo,  b.hoten_KH as hoten_n, tenDT , giaphi, tenHTTT, "+
        //                 "b.diachi,b.diachithanhtoan, b.sohopdong, case when b.trangthai = 1 then N'Cúp nước' else N'Mở nước' end as ngungmo, b.soNK , "+
        //                 "case when b.ischuaxacdinh_NK = 1 then N'xác định' else N'chưa xác định' end as xacdinh_nk,  b.ghichu,  " +
        //                 "LOTRINH.tenLT, case when b.thanhtoankhaclapdat = 1 then N'Khác' else N'Giống'end as thanhtoan " +
        //                 "FROM KHACHHANG b  " +
        //                 "left join HINHTHUCTHANHTOAN c on c.maHTTT = b.MA_HTTT  " +
        //                 "left join DOITUONGSUDUNG on b.maDT = DOITUONGSUDUNG.maDT  " +
        //                 "left join GiaBVMT on b.ma_giabvmt = GiaBVMT.ma_giaBVMT  " +
        //                 "left join NHANVIEN on b.nguoilapdat = NHANVIEN.maNV  " +
        //                 "left join LOTRINH on b.maLT = LOTRINH.maLT  " +
        //                 "left join DUONG on b.idduong = DUONG.idDuong " +
        //                 "left Join KHACHHANG on b.ID_KH = KHACHHANG.ID_KH " +
        //                 " WHERE b.hoten_KH = N'"+tenKH+"' " +
        //                 "order by b.hoten_KH "; 
        //    dt = cn.getData(SQL);
        //    return dt;
        //}
        // get data biến động khách hàng
        public DataTable getdata_BDKH()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM BD_KHACHHANG";
            dt = cn.getData(SQL);
            return dt;
        }
        // get data dgv
        public DataTable getdata_BD(string tenKH, string maLT, string maloai_yc, string d1, string d2, string idnn, string idtt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            if(maLT == "System.Data.DataRowView" || maloai_yc == "System.Data.DataRowView" || idnn == "System.Data.DataRowView" || idtt == "System.Data.DataRowView")
            {
                string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.ngaytao) as STT, a.ngaytao, tenloai_yc, trangthai_yc, tennguyennhan, a.madanhbo as madanhbocu, " +
                             "tenHTTT,a.diachithanhtoan, a.sohopdong, KHACHHANG.madanhbo , a.hoten_KH, tenDT , KHACHHANG.hoten_KH as hoten ,  " +
                             "case when a.trangthai = 1 then N'Cúp nước' else N'Mở nước' end as ngungmo, a.soNK , " +
                             "case when a.ischuaxacdinh_NK = 1 then N'xác định' else N'chưa xác định' end as xacdinh_nk, a.maDH, a.ghichu, " +
                             "case when a.thanhtoankhaclapdat = 1 then N'Khác' else N'Giống'end as thanhtoan, " +
                             "a.ngaydoi_DH,kichCo, a.nguoitao " +
                             "FROM yeucau a inner join loaiyeucau on a.maloai_yc = LOAIYEUCAU.maloai_yc " +
                             "left join HINHTHUCTHANHTOAN c on c.maHTTT = a.MA_HTTT " +
                             "left join DOITUONGSUDUNG on a.maDT = DOITUONGSUDUNG.maDT " +
                             "left join KICHCODH on a.MAKC = KICHCODH.MaKC " +
                             "left join NHANVIEN on a.nguoilapdat = NHANVIEN.maNV " +
                             "left join KHACHHANG on a.ID_KH = KHACHHANG.ID_KH " +
                             "left join DMNGUYENNHAN on a.idnguyennhan = DMNGUYENNHAN.id_nguyennhan " +
                             "left join DMTRANGTHAI_YC on a.TTYC_ID = DMTRANGTHAI_YC.TTYC_ID order by a.ngaytao";

                dt = cn.getData(SQL);
                return dt;
            }
            else
            {

                string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.ngaytao) as STT, a.ngaytao, tenloai_yc, trangthai_yc, tennguyennhan, a.madanhbo as madanhbocu, " +
                             "tenHTTT,a.diachithanhtoan, a.sohopdong, KHACHHANG.madanhbo , a.hoten_KH, KHACHHANG.hoten_KH as hoten, tenDT , " +
                             "case when a.trangthai = 1 then N'Cúp nước' else N'Mở nước' end as ngungmo, a.soNK , " +
                             "case when a.ischuaxacdinh_NK = 1 then N'xác định' else N'chưa xác định' end as xacdinh_nk, a.maDH, a.ghichu, " +
                             "case when a.thanhtoankhaclapdat = 1 then N'Khác' else N'Giống'end as thanhtoan, " +
                             "a.ngaydoi_DH,  kichCo, a.nguoitao " +
                             "FROM yeucau a inner join loaiyeucau on a.maloai_yc = LOAIYEUCAU.maloai_yc " +
                             "left join HINHTHUCTHANHTOAN c on c.maHTTT = a.MA_HTTT " +
                             "left join DOITUONGSUDUNG on a.maDT = DOITUONGSUDUNG.maDT " +
                             "left join KICHCODH on a.MAKC = KICHCODH.MaKC " +
                             "left join NHANVIEN on a.nguoilapdat = NHANVIEN.maNV " +
                             "left join KHACHHANG on a.ID_KH = KHACHHANG.ID_KH " +
                             "left join DMNGUYENNHAN on a.idnguyennhan = DMNGUYENNHAN.id_nguyennhan " +
                             "left join DMTRANGTHAI_YC on a.TTYC_ID = DMTRANGTHAI_YC.TTYC_ID " +
                             "WHERE KHACHHANG.hoten_KH = N'" + tenKH + "' or KHACHHANG.maLT = '" + maLT + "' or a.maloai_yc = '" + maloai_yc + "' " +
                             "or a.idnguyennhan = " + idnn + " or a.TTYC_ID = " + idtt + "  " +
                             "or a.ngaytao between convert(datetime, '" + d1 + "') and convert(datetime, '" + d2 + "') " +
                             "order by a.ngaytao";
                dt = cn.getData(SQL);
                return dt;
            }
        }
        // get data autocomplete
        public void get_hoten(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT   hoten_kh as hoten FROM khachhang order by hoten_KH";
            obj = cn.excuteReader(SQL);
            if(obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["hoten"].ToString());
                }
            }
            obj.Close();
        }
        // get data autocomplete

        public void get_maDB(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT substring(madanhbo, 10,5) madanhbo FROM khachhang order by madanhbo";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["madanhbo"].ToString());
                }
            }
            obj.Close();
        }
        public void get_IDKH(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ID_KH FROM khachhang order by ID_KH";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["ID_KH"].ToString());
                }
            }
            obj.Close();
        }
        // get data auto diachi
        public void get_diachi(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT diachi FROM khachhang order by diachi";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["diachi"].ToString());
                }
            }
            obj.Close();
        }
        public void get_soHD(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT so_hd FROM hoadon order by id_hd";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["so_hd"].ToString());
                }
            }
            obj.Close();
        }
        // get data auto SDT
        public void get_SDT(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SDT_KH FROM khachhang order by SDT_KH";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["SDT_KH"].ToString());
                }
            }
            obj.Close();
        }
        //Biến động theo ngày và loại yêu cầu
        public DataTable getBD_LYC(string d1, string d2, string lyc)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.ngaytao) as STT, a.ngaytao, tenloai_yc, trangthai_yc, tennguyennhan, a.madanhbo as madanhbocu, " +
                             "tenHTTT,a.diachithanhtoan, a.sohopdong, KHACHHANG.madanhbo , a.hoten_KH, KHACHHANG.hoten_KH as hoten, tenDT , " +
                             "case when a.trangthai = 1 then N'Cúp nước' else N'Mở nước' end as ngungmo, a.soNK , " +
                             "case when a.ischuaxacdinh_NK = 1 then N'xác định' else N'chưa xác định' end as xacdinh_nk, a.maDH, a.ghichu, " +
                             "case when a.thanhtoankhaclapdat = 1 then N'Khác' else N'Giống'end as thanhtoan, " +
                             "a.ngaydoi_DH,  kichCo, a.nguoitao " +
                             "FROM yeucau a inner join loaiyeucau on a.maloai_yc = LOAIYEUCAU.maloai_yc " +
                             "left join HINHTHUCTHANHTOAN c on c.maHTTT = a.MA_HTTT " +
                             "left join DOITUONGSUDUNG on a.maDT = DOITUONGSUDUNG.maDT " +
                             "left join KICHCODH on a.MAKC = KICHCODH.MaKC " +
                             "left join NHANVIEN on a.nguoilapdat = NHANVIEN.maNV " +
                             "left join KHACHHANG on a.ID_KH = KHACHHANG.ID_KH " +
                             "left join DMNGUYENNHAN on a.idnguyennhan = DMNGUYENNHAN.id_nguyennhan " +
                             "left join DMTRANGTHAI_YC on a.TTYC_ID = DMTRANGTHAI_YC.TTYC_ID " +
                             "WHERE a.maloai_yc= '" + lyc + "' and a.ngaytao between convert(datetime, '" + d1 + "') and convert(datetime, '" + d2 + "') " +
                             "order by a.ngaytao";
            dt = cn.getData(SQL);
            return dt;
        }
        // biến động theo ngày và loại nguyên nhân
        public DataTable getBD(string ID_KH)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.ngaytao) as STT, a.ngaytao, tenloai_yc, trangthai_yc, tennguyennhan, a.madanhbo , " +
                             "tenHTTT,a.diachithanhtoan, a.sohopdong, BD_KHACHHANG.madanhbo as madanhbocu , a.hoten_KH, BD_KHACHHANG.hoten_KH as hoten, tenDT , " +
                             "case when a.trangthai = 1 then N'Cúp nước' else N'Mở nước' end as ngungmo, a.soNK , " +
                             "case when a.ischuaxacdinh_NK = 1 then N'xác định' else N'chưa xác định' end as xacdinh_nk, a.maDH, a.ghichu, " +
                             "case when a.thanhtoankhaclapdat = 1 then N'Khác' else N'Giống'end as thanhtoan, " +
                             "a.ngaydoi_DH,  kichCo, a.nguoitao " +
                             "FROM yeucau a inner join loaiyeucau on a.maloai_yc = LOAIYEUCAU.maloai_yc " +
                             "left join HINHTHUCTHANHTOAN c on c.maHTTT = a.MA_HTTT " +
                             "left join DOITUONGSUDUNG on a.maDT = DOITUONGSUDUNG.maDT " +
                             "left join KICHCODH on a.MAKC = KICHCODH.MaKC " +
                             "left join NHANVIEN on a.nguoilapdat = NHANVIEN.maNV " +
                             "left join BD_KHACHHANG on a.ID_KH = BD_KHACHHANG.ID_KH " +
                             "left join DMNGUYENNHAN on a.idnguyennhan = DMNGUYENNHAN.id_nguyennhan " +
                             "left join DMTRANGTHAI_YC on a.TTYC_ID = DMTRANGTHAI_YC.TTYC_ID " +
                             "WHERE a.ID_KH = "+ID_KH+" " +
                             "order by a.ngaytao";
            dt = cn.getData(SQL);
            return dt;
        }
        // biến động theo ngày và trạng thái yêu cầu
        public DataTable getBD_TTYC(string d1, string d2, string tt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.ngaytao) as STT, a.ngaytao, tenloai_yc, trangthai_yc, tennguyennhan, a.madanhbo , " +
                             "tenHTTT,a.diachithanhtoan, a.sohopdong, BD_KHACHHANG.madanhbo  as madanhbocu , a.hoten_KH, BD_KHACHHANG.hoten_KH as hoten, tenDT , " +
                             "case when a.trangthai = 1 then N'Cúp nước' else N'Mở nước' end as ngungmo, a.soNK , " +
                             "case when a.ischuaxacdinh_NK = 1 then N'xác định' else N'chưa xác định' end as xacdinh_nk, a.maDH, a.ghichu, " +
                             "case when a.thanhtoankhaclapdat = 1 then N'Khác' else N'Giống'end as thanhtoan, " +
                             "a.ngaydoi_DH,  kichCo, a.nguoitao " +
                             "FROM yeucau a inner join loaiyeucau on a.maloai_yc = LOAIYEUCAU.maloai_yc " +
                             "left join HINHTHUCTHANHTOAN c on c.maHTTT = a.MA_HTTT " +
                             "left join DOITUONGSUDUNG on a.maDT = DOITUONGSUDUNG.maDT " +
                             "left join KICHCODH on a.MAKC = KICHCODH.MaKC " +
                             "left join NHANVIEN on a.nguoilapdat = NHANVIEN.maNV " +
                             "left join BD_KHACHHANG on a.ID_KH = BD_KHACHHANG.ID_KH " +
                             "left join DMNGUYENNHAN on a.idnguyennhan = DMNGUYENNHAN.id_nguyennhan " +
                             "left join DMTRANGTHAI_YC on a.TTYC_ID = DMTRANGTHAI_YC.TTYC_ID " +
                             "WHERE a.TTYC_ID = " + tt + " and a.ngaytao between convert(datetime, '" + d1 + "') and convert(datetime, '" + d2 + "') " +
                             "order by a.ngaytao";
            dt = cn.getData(SQL);
            return dt;
        }
        // tìm khách hàng theo lộ trình
        public DataTable getKH_LT(string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select distinct kh.ID_KH, kh.madanhbo, "+
                         " kh.hoten_KH, kh.diachi, kh.maDT, kh.soNK, "+
                         " tt.tenTT, kh.soseri_DH, tenhieu, kh.ghichu "+
                         " from KHACHHANG kh "+
                         " left join HIEUDONGHO hdh on kh.maDH = hdh.mahieu " +
                         " inner join DANHMUCTRANGTHAI tt on tt.maTT = kh.trangthai" +
                         " where kh.maLT = '" + malt + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        // tìm khách hàng theo tên
        public DataTable getKH_hoten(string hoten, string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "  select kh.ID_KH, kh.madanhbo, " +
                         "  kh.hoten_KH, kh.diachi, kh.maDT, kh.soNK, tt.tenTT, kh.soseri_DH, tenhieu, kh.ghichu, tenloai_yc " +
                         " from KHACHHANG kh  " +
                         " left join HIEUDONGHO hdh on kh.maDH = hdh.mahieu " +
                         " left join YEUCAU yc on kh.ID_KH = yc.ID_KH " +
                         " left join LOAIYEUCAU lyc on yc.maloai_yc = lyc.maloai_yc " +
                         " left join DANHMUCTRANGTHAI tt on tt.maTT = kh.trangthai" +
                         " where kh.maLT = '" + malt + "' and kh.hoten_KH like N'% "+hoten+"%'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_hoten(string hoten)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT madanhbo, hoten_KH, tenLT, tenTT, tenHTTT, tenDT, diachi, SDT_KH , ID_KH" +
                         " FROM KHACHHANG a, LOTRINH b, DOITUONGSUDUNG c, HINHTHUCTHANHTOAN d, DANHMUCTRANGTHAI e " +
                         " WHERE a.maLT = b.maLT and a.maDT = c.maDT and a.MA_HTTT = d.maHTTT and e.maTT = a.trangthai and hoten_KH =  N'" + hoten + "' order by hoten_KH";
            dt = cn.getData(SQL);
            return dt;
        }
        // tìm khách hàng theo mã danh bộ
        public DataTable getKH_madanhbo(string madanhbo, string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "  select kh.ID_KH, kh.madanhbo, " +
                         "  kh.hoten_KH, kh.diachi, kh.maDT, kh.soNK, tt.tenTT, kh.soseri_DH, tenhieu, kh.ghichu, tenloai_yc " +
                         " from KHACHHANG kh  " +
                         " left join HIEUDONGHO hdh on kh.maDH = hdh.mahieu " +
                         " left join YEUCAU yc on kh.ID_KH = yc.ID_KH " +
                         " left join LOAIYEUCAU lyc on yc.maloai_yc = lyc.maloai_yc " +
                         " left join DANHMUCTRANGTHAI tt on tt.maTT = kh.trangthai" +
                         " where kh.maLT = '" + malt + "' and kh.madanhbo like '%"+madanhbo+"%'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_madanhbo(string madanhbo)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT madanhbo, hoten_KH, tenLT, tenTT, tenHTTT, tenDT, diachi, SDT_KH , ID_KH" +
                         " FROM KHACHHANG a, LOTRINH b, DOITUONGSUDUNG c, HINHTHUCTHANHTOAN d, DANHMUCTRANGTHAI e " +
                         " WHERE a.maLT = b.maLT and a.maDT = c.maDT and a.MA_HTTT = d.maHTTT and e.maTT = a.trangthai  and madanhbo like '%" + madanhbo + "%' order by hoten_KH";
            dt = cn.getData(SQL);
            return dt;
        }
        // tìm khách hàng theo địa chỉ
        public DataTable getKH_diachi(string diachi, string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "  select kh.ID_KH, kh.madanhbo, " +
                         "  kh.hoten_KH, kh.diachi, kh.maDT, kh.soNK, tt.tenTT, kh.soseri_DH, tenhieu, kh.ghichu, tenloai_yc " +
                         " from KHACHHANG kh  " +
                         " left join HIEUDONGHO hdh on kh.maDH = hdh.mahieu " +
                         " left join YEUCAU yc on kh.ID_KH = yc.ID_KH " +
                         " left join LOAIYEUCAU lyc on yc.maloai_yc = lyc.maloai_yc " +
                         " left join DANHMUCTRANGTHAI tt on tt.maTT = kh.trangthai" +
                         " where kh.maLT = '" + malt + "' and kh.diachi like N'%" + diachi + "%'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_diachi(string diachi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT madanhbo, hoten_KH, tenLT, tenTT, tenHTTT, tenDT, diachi, SDT_KH , ID_KH" +
                         " FROM KHACHHANG a, LOTRINH b, DOITUONGSUDUNG c, HINHTHUCTHANHTOAN d, DANHMUCTRANGTHAI e " +
                         " WHERE a.maLT = b.maLT and a.maDT = c.maDT and a.MA_HTTT = d.maHTTT and e.maTT = a.trangthai  and diachi = N'" + diachi + "' order by hoten_KH";
            dt = cn.getData(SQL);
            return dt;
        }
        // tìm khách hàng theo số điện thoại
        public DataTable getKH_sodienthoai(string SDT, string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "  select kh.ID_KH, kh.madanhbo, " +
                         "  kh.hoten_KH, kh.diachi, kh.maDT, kh.soNK, tt.tenTT, kh.soseri_DH, tenhieu, kh.ghichu, tenloai_yc " +
                         " from KHACHHANG kh  " +
                         " left join HIEUDONGHO hdh on kh.maDH = hdh.mahieu " +
                         " left join YEUCAU yc on kh.ID_KH = yc.ID_KH " +
                         " left join LOAIYEUCAU lyc on yc.maloai_yc = lyc.maloai_yc " +
                         " left join DANHMUCTRANGTHAI tt on tt.maTT = kh.trangthai" +
                         " where kh.maLT = '" + malt + "' and kh.SDT_KH like '%" + SDT + "%'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_YC(string yeucau, string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "  select kh.ID_KH, kh.madanhbo, " +
                         "  kh.hoten_KH, kh.diachi, kh.maDT, kh.soNK, tt.tenTT, kh.soseri_DH, tenhieu, kh.ghichu, tenloai_yc " +
                         " from KHACHHANG kh  " +
                         " left join HIEUDONGHO hdh on kh.maDH = hdh.mahieu " +
                         " left join YEUCAU yc on kh.ID_KH = yc.ID_KH " +
                         " left join LOAIYEUCAU lyc on yc.maloai_yc = lyc.maloai_yc " +
                         " left join DANHMUCTRANGTHAI tt on tt.maTT = kh.trangthai" +
                         " where kh.maLT = '" + malt + "' and lyc.maloai_yc  = '"+yeucau+"'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_YC_Null(string yeucau, string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "  select kh.ID_KH, kh.madanhbo, " +
                         "  kh.hoten_KH, kh.diachi, kh.maDT, kh.soNK, tt.tenTT, kh.soseri_DH, tenhieu, kh.ghichu, tenloai_yc " +
                         " from KHACHHANG kh  " +
                         " left join HIEUDONGHO hdh on kh.maDH = hdh.mahieu " +
                         " left join YEUCAU yc on kh.ID_KH = yc.ID_KH " +
                         " left join LOAIYEUCAU lyc on yc.maloai_yc = lyc.maloai_yc " +
                         " left join DANHMUCTRANGTHAI tt on tt.maTT = kh.trangthai" +
                         " where kh.maLT = '" + malt + "' and kh.ID_KH not in (select id_kh from yeucau where maloai_yc = '"+yeucau+"')";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_YC_Null(string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "  select kh.ID_KH, kh.madanhbo, " +
                         "  kh.hoten_KH, kh.diachi, kh.maDT, kh.soNK, tt.tenTT, kh.soseri_DH, tenhieu, kh.ghichu, tenloai_yc " +
                         " from KHACHHANG kh  " +
                         " left join HIEUDONGHO hdh on kh.maDH = hdh.mahieu " +
                         " left join YEUCAU yc on kh.ID_KH = yc.ID_KH " +
                         " left join LOAIYEUCAU lyc on yc.maloai_yc = lyc.maloai_yc " +
                         " left join DANHMUCTRANGTHAI tt on tt.maTT = kh.trangthai" +
                         " where kh.maLT = '" + malt + "' and kh.ID_KH not in (select id_kh from yeucau)";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_sodienthoai(string SDT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT madanhbo, hoten_KH, tenLT, tenTT, tenHTTT, tenDT, diachi, SDT_KH , ID_KH" +
                         " FROM KHACHHANG a, LOTRINH b, DOITUONGSUDUNG c, HINHTHUCTHANHTOAN d, DANHMUCTRANGTHAI e " +
                         " WHERE a.maLT = b.maLT and a.maDT = c.maDT and a.MA_HTTT = d.maHTTT and e.maTT = a.trangthai  and SDT_KH = '" + SDT + "' order by hoten_KH";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_ID_KH(string ID_KH, string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT madanhbo, hoten_KH, tenLT, tenTT, tenHTTT, tenDT, diachi, SDT_KH , ID_KH" +
                         " FROM KHACHHANG a, LOTRINH b, DOITUONGSUDUNG c, HINHTHUCTHANHTOAN d, DANHMUCTRANGTHAI e " +
                         " WHERE a.maLT = b.maLT and a.maDT = c.maDT and a.MA_HTTT = d.maHTTT and e.maTT = a.trangthai  and a.malt = '" + malt + "' and ID_KH like '" +ID_KH + "' order by hoten_KH";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_ID_KH(string ID_KH)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT madanhbo, hoten_KH, tenLT, tenTT, tenHTTT, tenDT, diachi, SDT_KH , ID_KH" +
                         " FROM KHACHHANG a, LOTRINH b, DOITUONGSUDUNG c, HINHTHUCTHANHTOAN d, DANHMUCTRANGTHAI e " +
                         " WHERE a.maLT = b.maLT and a.maDT = c.maDT and a.MA_HTTT = d.maHTTT and e.maTT = a.trangthai and ID_KH like '" + ID_KH + "' order by hoten_KH";
            dt = cn.getData(SQL);
            return dt;
        }
        // get khach hang bien dong
        public SqlDataReader getDataBD(string ID_KH, string  malt)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT madanhbo, hoten_KH, diachi, SDT_KH, email, tenDT, soseri_DH, ngaylapdat, tenHTTT, tenLT, tenTT " +
                         "FROM KHACHHANG a, DOITUONGSUDUNG b, HINHTHUCTHANHTOAN c, LOTRINH d, DANHMUCTRANGTHAI e " +
                         "WHERE a.maDT = b.maDT and a.MA_HTTT = C.maHTTT and d.maLT = a.maLT and a.trangthai = e.maTT and a.malt = '"+malt+ "'and ID_KH like " + ID_KH + " ";
            obj = cn.excuteReader(SQL);
            return obj;
        }
        public DataTable getYeucau()
        {
            Connect_DB cn = new Connect_DB();
            DataTable dt = new DataTable();
            string SQL = "select * from LOAIYEUCAU";
            dt = cn.getData(SQL);
            return dt;
        }
        
    }
}
