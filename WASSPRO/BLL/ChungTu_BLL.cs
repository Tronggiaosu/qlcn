using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class ChungTu_BLL
    {
        int pageSize = 30;
        int totalpage;
        // thêm chứng từ
        public int insert_CT(CHUNGTU obj, string ngaylap, string ngaythu)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO chungtu(ngaylap, NV_ID_nop, tongtien,  trangthai, ghichu, maloai, NV_ID_lap, ID_kyghi, SOCT, ngayct)" +
                         " VALUES(Convert(datetime,'" + ngaylap + "'), '" + obj.NV_ID_nop + "',0, 0, N'" + obj.ghichu + "', " +
                         " '" + obj.maloai + "', " + obj.NV_ID_lap + ", '" + obj.ID_kyghi + "', '" + obj.SOCT + "', '" + ngaythu + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        // get_id_ct  nv thu
        public int getID_CT_NVThu(string kyghi, string ngaylap, string ID_NV)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ID_CT FROM CHUNGTU WHERE  NV_ID_nop = " + ID_NV + " and ID_kyghi = '" + kyghi + "' and ngaylap = Convert(Datetime, '" + ngaylap + "')";
            obj = cn.ExecuteScalar(SQL);
            if(obj == null)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(obj.ToString());
            }
        }
        public DataTable getDataDSHD_Thutrung()
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT distinct b.id_hd, ROW_NUMBER() OVER(ORDER BY a.id_kh) stt,  a.maLT + ' - ' + tenLT maLT, b.m3tieuthu luongtieuthu , " +
                         " ten_kyghi, madanhbo,hoten_KH, dia_chi, b.SO_HD, b.KY_HIEU_HD, b.tongtien, a.id_kh,  " +
                         " k.hoten nvthu, SOCT, n.hoten nvthutrung, ngay_thu_tien, ngaythanhtoan " +
                         " FROM KHACHHANG a, HOADON b, CHUNGTU_HOADON c, dm_phieu_thu d, CHUNGTU m, " +
                         " lotrinh h, DANHMUCKYGHI f, NHANVIEN k, NHANVIEN n " +
                         " WHERE a.ID_KH = b.ID_KH and b.ID_HD = c.ID_HD and c.ID_CT = m.ID_CT " +
                         " and b.ID_HD = d.FKEY  and a.maLT = h.maLT " +
                         " and Checks = 2  and m.NV_ID_lap = k.NV_ID and d.nv_thu = n.maNV " +
                         " and b.kyghi = f.ID_kyghi  order by a.id_kh";
            ct = cn.getData(SQL);
            return ct;
        }
        public DataTable getDataDSHD_Thutrung_Kyghi(string kyghi)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "  SELECT distinct b.id_hd, ROW_NUMBER() OVER(ORDER BY a.id_kh) stt,  a.maLT + ' - ' + tenLT maLT, b.m3tieuthu luongtieuthu , " +
                         " ten_kyghi, madanhbo,hoten_KH, dia_chi, b.SO_HD, b.KY_HIEU_HD, b.tongtien, a.id_kh,  " +
                         " k.hoten nvthu, SOCT, n.hoten nvthutrung, ngay_thu_tien, ngaythanhtoan " +
                         " FROM KHACHHANG a, HOADON b, CHUNGTU_HOADON c, dm_phieu_thu d, CHUNGTU m, " +
                         " lotrinh h, DANHMUCKYGHI f, NHANVIEN k, NHANVIEN n " +
                         " WHERE a.ID_KH = b.ID_KH and b.ID_HD = c.ID_HD and c.ID_CT = m.ID_CT " +
                         " and b.ID_HD = d.FKEY  and a.maLT = h.maLT " +
                         " and Checks = 0  and m.NV_ID_lap = k.NV_ID and d.nv_thu = n.maNV " +
                         " and b.kyghi = f.ID_kyghi and kyghi = '" + kyghi + "'  order by a.id_kh";
            ct = cn.getData(SQL);
            return ct;
        }
        public int updateChungTu_KH(string ID_CT, string kyghi, string ngaythu)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU SET ID_Kyghi = '" + kyghi + "', ngayct = '" + ngaythu + "' WHERE ID_CT = " + ID_CT + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int update_ngaythanhtoan(string id_ct, string ngaythu)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE hoadon set ngaythanhtoan = '" + ngaythu + "' " +
                        "from chungtu a, hoadon b, chungtu_hoadon c where b.id_hd = c.id_hd and c.id_ct = a.id_ct and c.id_ct = " + id_ct + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int updateChungTu(string ID_CT, string kyghi, string ngaythu, string ID_NV)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU SET NV_ID_nop = " + ID_NV + " , ID_Kyghi = '" + kyghi + "', ngayct = '" + ngaythu + "' WHERE ID_CT = " + ID_CT + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public DataTable getDataDSHD_Thutrung_NV(string NV_ID)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "  SELECT distinct b.id_hd, ROW_NUMBER() OVER(ORDER BY a.id_kh) stt,  a.maLT + ' - ' + tenLT maLT, b.m3tieuthu luongtieuthu , " +
                         " ten_kyghi, madanhbo,hoten_KH, dia_chi, b.SO_HD, b.KY_HIEU_HD, b.tongtien, a.id_kh,  " +
                         " k.hoten nvthu, SOCT, n.hoten nvthutrung, ngay_thu_tien, ngaythanhtoan " +
                         " FROM KHACHHANG a, HOADON b, CHUNGTU_HOADON c, dm_phieu_thu d, CHUNGTU m, " +
                         " lotrinh h, DANHMUCKYGHI f, NHANVIEN k, NHANVIEN n " +
                         " WHERE a.ID_KH = b.ID_KH and b.ID_HD = c.ID_HD and c.ID_CT = m.ID_CT " +
                         " and b.ID_HD = d.FKEY  and a.maLT = h.maLT " +
                         " and Checks = 0  and m.NV_ID_lap = k.NV_ID and d.nv_thu = n.maNV " +
                         " and b.kyghi = f.ID_kyghi and n.NV_ID = " + NV_ID + "  order by a.id_kh";
            ct = cn.getData(SQL);
            return ct;
        }
        // thêm chứng từ hóa đơn
        public int insertCT_HD(string kyghi, string SOCT, string ID_NV)
        {
            int result;
            Connect_DB cn = new Connect_DB();
            string SQL = " INSERT INTO CHUNGTU_HOADON(ID_CT, ID_HD, sotien, dadongbo) " +
                         " select e.ID_CT, b.ID_HD, b.tongtien, checks from dm_phieu_thu a, HOADON b, LOTRINH_Thu c, CHUNGTU e " +
                         " where a.fkey = b.ID_HD " +
                         " and b.MaLT = c.maLT and c.nv_id = "+ID_NV+"  and b.ID_HD NOT IN (SELECT ID_HD FROM CHUNGTU_HOADON) " +
                         " and checks = 0 and IsInHD = 1 group by b.ID_HD, tong_thu, checks, e.ID_CT, b.tongtien " + 
                         " having e.ID_CT = (SELECT ID_CT FROM CHUNGTU WHERE  ID_kyghi = '"+ kyghi +"' and SOCT = '"+SOCT+"')";
            result = cn.updateData(SQL);
            return result;
        }
        // update dm_phieuthu
        public int update_dmphieuthu(string kyghi, string SOCT)
        {
            int result;
            Connect_DB cn = new Connect_DB();
            string SQL = " UPDATE a SET checks = 1 from dm_phieu_thu a, CHUNGTU_HOADON b " +
                         " where a.FKEY = b.ID_HD  " +
                         " and ID_CT = (SELECT ID_CT FROM CHUNGTU WHERE  ID_kyghi = '"+kyghi+"' and SOCT = '"+SOCT+"' ) and checks = 0 ";
            result = cn.updateData(SQL);
            return result;
        }
        // update hoadon
        public int updatehoadon(string kyghi, string SO_CT, string ngaythu)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = " UPDATE a set sotienthanhtoan = tongtien, sotienno = 0, ngaythanhtoan = '"+ngaythu+"'  FROM HOADON a, dm_phieu_thu c, CHUNGTU_HOADON b " +
                         " WHERE a.ID_HD = c.fkey and a.ID_HD = b.ID_HD and IsInHD = 1 and checks = 1 " +
                         " and ID_CT = (SELECT ID_CT FROM CHUNGTU WHERE  ID_kyghi = '"+kyghi+"' and SOCT = '"+SO_CT+"') ";
            rs = cn.updateData(SQL);
            return rs;

        }
        // lấy danh mục kỳ ghi
        public DataTable getData_Kyghi()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  * FROM danhmuckyghi order by ngaytao desc";
            dt = cn.getData(SQL);
            return dt;
        }
        // lấy tên nhân viên thu
        public string getNV(string malt)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT hoten FROM NHANVIEN a, LOTRINH b WHERE b.ID_NV_thu = a.NV_ID and b.maLT = '" + malt + "'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)obj;
            }
        }
        public DataTable getData_CT_ngayPH(string tungay, string denngay)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select ROW_NUMBER() OVER(order by TONG.maLT) as STT, a.maLT, a.malt + '- ' + tenlt tenlt, isnull(tongthu.soluong, 0) tonghdthu, " +
                         " TONG.ten_kyghi, TONG.tongthanhtoan, TONG.kyghi, ISNULL(tongthu.tongthu, 0) tongthu, ISNULL(TONG.tonghd, 0) tonghd, " +
                         " ISNULL(TONG.tongthanhtoan, 0) - isnull(tongthu.tongthu, 0) tongno, ISNULL(cast(tongthu.tongthu as float) / tong.tongthanhtoan * 100, 0) tyle, " +
                         "  isnull(TONG.tonghd - ISNULL(tongthu.soluong, 0), 0) tonghdchuathu " +
                         " from LOTRINH a inner join (select sum(tongtien) as tongthanhtoan, count(a.ID_HD) tonghd, a.maLT, ten_kyghi, a.kyghi " +
                         " from HOADON a, DANHMUCKYGHI c  where a.kyghi = c.ID_kyghi and isinhd = 1 and a.ngaylap between '" + tungay + " 00:00:00' and '" + denngay + " 23:59:59' " +
                         " group by  a.kyghi, ten_kyghi, a.malt) as TONG on a.maLT = TONG.maLT " +
                         " left join (select COUNT(a.id_hd) soluong, SUM(sotien) tongthu, MaLT, kyghi " +
                         " from HOADON a, CHUNGTU_HOADON b where a.ID_HD = b.ID_HD and a.ngaylap between '" + tungay + " 00:00:00' and '" + denngay + " 23:59:59' group by MaLT, kyghi) tongthu " +
                         " on a.maLT = tongthu.MaLT and TONG.kyghi = tongthu.kyghi " +
                         " order by a.maLT ";
            ct = cn.getData(SQL);
            return ct;
        }
        public DataTable getData_CT_ngayPH_kyHD(string tungay, string denngay, string kyHD)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select ROW_NUMBER() OVER(order by TONG.maLT) as STT, a.maLT, a.malt + '- ' + tenlt tenlt, isnull(tongthu.soluong, 0) tonghdthu, " +
                         " TONG.ten_kyghi, TONG.tongthanhtoan, TONG.kyghi, ISNULL(tongthu.tongthu, 0) tongthu, ISNULL(TONG.tonghd, 0) tonghd, " +
                         " ISNULL(TONG.tongthanhtoan, 0) - isnull(tongthu.tongthu, 0) tongno, ISNULL(cast(tongthu.tongthu as float) / tong.tongthanhtoan * 100, 0) tyle, " +
                         "  isnull(TONG.tonghd - ISNULL(tongthu.soluong, 0), 0) tonghdchuathu " +
                         " from LOTRINH a inner join (select sum(tongtien) as tongthanhtoan, count(a.ID_HD) tonghd, a.maLT, ten_kyghi, a.kyghi " +
                         " from HOADON a, DANHMUCKYGHI c  where a.kyghi = c.ID_kyghi and isinhd = 1 and a.ngaylap between '" + tungay + " 00:00:00' and '" + denngay + " 23:59:59' and a.kyghi = '" + kyHD + "' " +
                         " group by  a.kyghi, ten_kyghi, a.malt) as TONG on a.maLT = TONG.maLT " +
                         " left join (select COUNT(a.id_hd) soluong, SUM(sotien) tongthu, MaLT, kyghi " +
                         " from HOADON a, CHUNGTU_HOADON b where a.ID_HD = b.ID_HD and a.ngaylap between '" + tungay + " 00:00:00' and '" + denngay + " 23:59:59' and a.kyghi = '" + kyHD + "' group by MaLT, kyghi) tongthu " +
                         " on a.maLT = tongthu.MaLT and TONG.kyghi = tongthu.kyghi " +
                         " order by a.maLT ";
            ct = cn.getData(SQL);
            return ct;
        }
        // lấy dữ liệu dgv
        public DataTable getData_CT()
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select ROW_NUMBER() OVER(order by TONG.maLT) as STT, a.maLT, a.malt + '- ' + tenlt tenlt, isnull(tongthu.soluong, 0) tonghdthu, "+
                        " TONG.ten_kyghi, TONG.tongthanhtoan, TONG.kyghi, ISNULL(tongthu.tongthu, 0) tongthu, ISNULL(TONG.tonghd, 0) tonghd, " +
                        " ISNULL(TONG.tongthanhtoan, 0) - isnull(tongthu.tongthu, 0) tongno, ISNULL(cast(tongthu.tongthu as float) / tong.tongthanhtoan * 100, 0) tyle, " +
                        " isnull(TONG.tonghd - tongthu.soluong, 0) tonghdchuathu, huy.sl " +
                        " from LOTRINH a " +
                        " inner join (select sum(tongtien) as tongthanhtoan, count(a.ID_HD) tonghd, a.maLT, ten_kyghi, a.kyghi " +
                        " from HOADON a, DANHMUCKYGHI c  where a.kyghi = c.ID_kyghi and isinhd = 1 " +
                        " group by  a.kyghi, ten_kyghi, a.malt) as TONG on a.maLT = TONG.maLT " +
                        " left join (select COUNT(a.id_hd) soluong, SUM(sotien) tongthu, MaLT, kyghi " +
                        " from HOADON a, CHUNGTU_HOADON b where a.ID_HD = b.ID_HD  group by MaLT, kyghi) tongthu " +
                        " on a.maLT = tongthu.MaLT and TONG.kyghi = tongthu.kyghi " +
                        " left join (select count([key]) sl, ma_tuyen_cuoc, KYHD from PublishedInvoices where STATUS = 4 group by ma_tuyen_cuoc, KYHD) huy " +
                        " on a.maLT = huy.ma_tuyen_cuoc and huy.KYHD = TONG.kyghi " +
                        " order by Tong.ten_kyghi desc ";
            ct = cn.getData(SQL);
            return ct;
        }
        // get chung tu theo ky ghi
        public DataTable getData_CT_kyghi(string kyghi)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select ROW_NUMBER() OVER(order by TONG.maLT) as STT, a.maLT, a.malt + '- ' + tenlt tenlt, isnull(tongthu.soluong, 0) tonghdthu, " +
                         " TONG.ten_kyghi, TONG.tongthanhtoan, TONG.kyghi, ISNULL(tongthu.tongthu, 0) tongthu, ISNULL(TONG.tonghd, 0) tonghd, " +
                         " ISNULL(TONG.tongthanhtoan, 0) - isnull(tongthu.tongthu, 0) tongno, ISNULL(cast(tongthu.tongthu as float) / tong.tongthanhtoan * 100, 0) tyle, " +
                         " isnull(TONG.tonghd - tongthu.soluong, 0) tonghdchuathu " +
                         " from LOTRINH a inner join (select sum(tongtien) as tongthanhtoan, count(a.ID_HD) tonghd, a.maLT, ten_kyghi, a.kyghi " +
                         " from HOADON a, DANHMUCKYGHI c  where a.kyghi = c.ID_kyghi and isinhd = 1 and kyghi = '"+kyghi+"' " +
                         " group by  a.kyghi, ten_kyghi, a.malt) as TONG on a.maLT = TONG.maLT " +
                         " left join (select COUNT(a.id_hd) soluong, SUM(sotien) tongthu, MaLT, kyghi " +
                         " from HOADON a, CHUNGTU_HOADON b where a.ID_HD = b.ID_HD and kyghi =  '"+kyghi+"' group by MaLT, kyghi) tongthu " +
                         " on a.maLT = tongthu.MaLT and TONG.kyghi = tongthu.kyghi " +
                         " order by a.maLT ";
            ct = cn.getData(SQL);
            return ct;
        }
        // get chung tu theo ky ghi
        public DataTable getData_CT_ngayPH(string ngayphathanh)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL =" select ROW_NUMBER() OVER(order by TONG.maLT) as STT, a.maLT, a.malt + '- ' + tenlt tenlt, isnull(tongthu.soluong, 0) tonghdthu, " +
                         " TONG.ten_kyghi, TONG.tongthanhtoan, TONG.kyghi, ISNULL(tongthu.tongthu, 0) tongthu, ISNULL(TONG.tonghd, 0) tonghd, " +
                         " ISNULL(TONG.tongthanhtoan, 0) - isnull(tongthu.tongthu, 0) tongno, ISNULL(cast(tongthu.tongthu as float) / tong.tongthanhtoan * 100, 0) tyle, " +
                         " isnull(TONG.tonghd - tongthu.soluong, 0) tonghdchuathu " +
                         " from LOTRINH a inner join (select sum(tongtien) as tongthanhtoan, count(a.ID_HD) tonghd, a.maLT, ten_kyghi, a.kyghi " +
                         " from HOADON a, DANHMUCKYGHI c  where a.kyghi = c.ID_kyghi and isinhd = 1 and a.ngaylap between '" + ngayphathanh + " 00:00:00' and '" + ngayphathanh + " 23:59:59' " +
                         " group by  a.kyghi, ten_kyghi, a.malt) as TONG on a.maLT = TONG.maLT " +
                         " left join (select COUNT(a.id_hd) soluong, SUM(sotien) tongthu, MaLT, kyghi " +
                         " from HOADON a, CHUNGTU_HOADON b where a.ID_HD = b.ID_HD and a.ngaylap between '" + ngayphathanh + " 00:00:00' and '" + ngayphathanh + " 23:59:59' group by MaLT, kyghi) tongthu " +
                         " on a.maLT = tongthu.MaLT and TONG.kyghi = tongthu.kyghi " +
                         " order by a.maLT ";
            ct = cn.getData(SQL);
            return ct;
        }
        // get chung tu theo lo trinh
        public DataTable getData_CT_lotrinh(string lotrinh)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select ROW_NUMBER() OVER(order by TONG.maLT) as STT, a.maLT, a.malt + '- ' + tenlt tenlt, isnull(tongthu.soluong, 0) tonghdthu, " +
                         " TONG.ten_kyghi, TONG.tongthanhtoan, TONG.kyghi, ISNULL(tongthu.tongthu, 0) tongthu, ISNULL(TONG.tonghd, 0) tonghd, " +
                         " ISNULL(TONG.tongthanhtoan, 0) - isnull(tongthu.tongthu, 0) tongno, ISNULL(cast(tongthu.tongthu as float) / tong.tongthanhtoan * 100, 0) tyle, " +
                         " isnull(TONG.tonghd - tongthu.soluong, 0) tonghdchuathu " +
                         " from LOTRINH a inner join (select sum(tongtien) as tongthanhtoan, count(a.ID_HD) tonghd, a.maLT, ten_kyghi, a.kyghi " +
                         " from HOADON a, DANHMUCKYGHI c  where a.kyghi = c.ID_kyghi and isinhd = 1 and a.malt = '"+lotrinh+"' " +
                         " group by  a.kyghi, ten_kyghi, a.malt) as TONG on a.maLT = TONG.maLT " +
                         " left join (select COUNT(a.id_hd) soluong, SUM(sotien) tongthu, MaLT, kyghi " +
                         " from HOADON a, CHUNGTU_HOADON b where a.ID_HD = b.ID_HD and a.malt = '"+lotrinh+"' group by MaLT, kyghi) tongthu " +
                         " on a.maLT = tongthu.MaLT and TONG.kyghi = tongthu.kyghi " +
                         " order by a.maLT ";
            ct = cn.getData(SQL);
            return ct;
        }
        // get no theo nhan vien
        public DataTable getData_CT_NV(string ID_NV)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select ROW_NUMBER() OVER(order by TONG.maLT) as STT, TONG.malt + '- ' + TONG.tenlt tenlt, isnull(tongthu.soluong, 0) tonghdthu, " +
                         " TONG.ten_kyghi, TONG.tongthanhtoan, TONG.kyghi, ISNULL(tongthu.tongthu, 0) tongthu, ISNULL(TONG.tonghd, 0) tonghd, " +
                         " ISNULL(TONG.tongthanhtoan, 0) - isnull(tongthu.tongthu, 0) tongno, ISNULL(cast(tongthu.tongthu as float) / tong.tongthanhtoan * 100, 0) tyle, " +
                         " isnull(TONG.tonghd - tongthu.soluong, 0) tonghdchuathu " +
                         " from LOTRINH a inner join (select sum(tongtien) as tongthanhtoan, count(a.ID_HD) tonghd, tenLT, a.maLT, ten_kyghi, a.kyghi " +
                         " from HOADON a, DANHMUCKYGHI c, LOTRINH e where a.malt = e.malt  and a.kyghi = c.ID_kyghi and isinhd = 1 " +
                         " group by  a.kyghi, tenLT, e.maLT, ten_kyghi, e.maLT, a.malt) as TONG " +
                         " on a.maLT = TONG.maLT " +
                         " left join (select COUNT(a.id_hd) soluong, SUM(sotien) tongthu, MaLT, kyghi " +
                         " from HOADON a, CHUNGTU_HOADON b where a.ID_HD = b.ID_HD group by MaLT, kyghi) tongthu " +
                         " on a.maLT = tongthu.MaLT and TONG.kyghi = tongthu.kyghi " +
                         "  order by a.maLT ";
            ct = cn.getData(SQL);
            return ct;
        }
        // lấy danh sách hóa đơn 
        public DataTable getID_HD(string maLT, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ID_HD, tongtien, b.malt FROM HOADON a, LOTRINH b, KHACHHANG c " +
                         "WHERE b.malt = c.malt and a.ID_KH = c.ID_KH  and b.malt = '" + maLT + "' and a.kyghi = '" + kyghi + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        // lấy id kỳ ghi
        public string getKyghi()
        {
            object dt;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT top 1 ID_Kyghi FROM danhmuckyghi WHERE gachno = 1 order by ngaytao desc";
            dt = cn.ExecuteScalar(SQL);
            if(dt == DBNull.Value)
            {
                return null;
            }
            else
            {
                return dt.ToString();
            }
        }
        public DataTable getkyhoadon()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select * from danhmuckyghi where gachno = 1";
            dt = cn.getData(SQL);
            return dt;
        }
        // lấy id kỳ ghi
        public string getKyghi_ten(string ID_Kyghi)
        {
            object dt;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ten_Kyghi FROM danhmuckyghi WHERE ID_Kyghi = '" + ID_Kyghi + "' ";
            dt = cn.ExecuteScalar(SQL);
            if (dt == DBNull.Value)
            {
                return null;
            }
            else
            {
                return dt.ToString();
            }
        }
        // kiểm tra trạng thái gạch nợ
        public bool getTrangthai(string kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT gachno FROM danhmuckyghi WHERE id_kyghi = " + kyghi + "";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return false;
            }
            else
            {
                return (bool)obj;
            }

        }
        // lấy ID nhân viên nộp
        public DataTable getNV_nop()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM NHANVIEN   order by hoten";
            dt = cn.getData(SQL);
            return dt;
        }
        // lấy ID nhân viên lập
        public int getIDNV_lap(string manv)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT NV_ID FROM NHANVIEN WHERE maNV = (select maNV from nguoidung where ma_nd = '" + manv + "')";
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
        //kiểm tra hóa đơn
        public int getHD(string malt, string kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ID_HD FROM KHACHHANG a, HOADON b WHERE a.ID_KH = b.ID_KH and a.maLT = '" + malt + "' and b.kyghi = '" + kyghi + "' ";
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
        // update hóa đơn
        public int updateHD(CHUNGTU_HOADON ct_hd, string ngaythu)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE HOADON SET sotienthanhtoan = " + ct_hd.sotien + ", sotienno = tongtien - " + ct_hd.sotien + ", ngaythanhtoan = '"+ngaythu+"' WHERE ID_HD = " + ct_hd.ID_HD + " and IsInHD = 1";
            rs = cn.updateData(SQL);
            return rs;
        }
        // get data gạch nợ
        public DataTable getData_gachno( string ID)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, a.so_HD, a.ky_hieu_hd, ten_kyghi, tongtien,  " +
                         " b.malt, madanhbo, hoten_KH, diachi, " +
                         " case when checks = 0 then 'true' else 'false' end as checks, c.ID_KH " +
                         " FROM HOADON a, LOTRINH_Thu b, KHACHHANG c, dm_phieu_thu e, danhmuckyghi f, NHANVIEN d " +
                         " WHERE a.ID_KH = c.ID_KH   and a.ID_HD = e.FKEY  and a.kyghi = f.ID_Kyghi  and b.malt = a.malt " +
                         " and b.nv_id = d.NV_ID and e.nv_thu = d.maNV and d.NV_ID = "+ID+" and Checks = 0 ";
            ct = cn.getData(SQL);
            return ct;
        }
        // get data gạch nợ
        public DataTable getData_gachno_kh_DATHU(string ID)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT b.ID_HD, a.maLT, tenLT, ten_kyghi, madanhbo,hoten_KH, dia_chi,  case when checks = 0 then 'true' else 'false' end as checks , b.SO_HD, b.KY_HIEU_HD, b.tongtien, tenHTTT, b.ID_KH " +
                         " FROM KHACHHANG a, HOADON b, CHUNGTU_HOADON c, dm_phieu_thu d, LOTRINH_Thu e, lotrinh h,  DANHMUCKYGHI f, HINHTHUCTHANHTOAN g " +
                         " WHERE a.ID_KH = b.ID_KH and b.ID_HD = c.ID_HD and b.keys = d.FKEY and a.MA_HTTT = g.maHTTT " +
                         " and Checks = 0 and a.maLT = e.maLT  and b.kyghi = f.ID_kyghi and e.malt = h.malt and e.nv_id =  "+ID+" ";
            ct = cn.getData(SQL);
            return ct;
        }
        // get data gạch nợ
        public DataTable getkyghi_gachno(string ID)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT DISTINCT ten_kyghi, a.kyghi " +
                         " FROM HOADON a, LOTRINH_Thu b, KHACHHANG c, HINHTHUCTHANHTOAN d , dm_phieu_thu e, danhmuckyghi f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH " +
                         " and d.maHTTT = c.MA_HTTT and a.ID_HD = e.FKEY and a.kyghi = f.ID_Kyghi  and b.nv_id = " + ID + " " +
                         " and Checks = 0 ";
            ct = cn.getData(SQL);
            return ct;
        }
        // get data gạch nợ thoe soHD
        public DataTable getData_gachno_maDB(string kyghi, string ID, string madanhbo, string hoten, string diachi, string sdt, string sotien, string soHD)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, case when checks = 0 then 'true' else 'false' end as checks " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , dm_phieu_thu e " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH " +
                         " and d.maHTTT = c.MA_HTTT and a.ID_HD = e.FKEY  and b.ID_NV_thu = " + ID + "  and a.kyghi = '" + kyghi + "' and Checks = 0   and c.madanhbo like  '%" + madanhbo + "%' or " +
                         "c.hoten_KH like '%" + hoten + "%' or c.diachi like '%" + diachi + "%' or c.SDT_KH LIKE '%" + sdt + "%' or a.so_HD like '%" + soHD + "%' or a.tongtien like " + sotien + " ";
            ct = cn.getData(SQL);
            return ct;
        }
        // get tongtienthanhtoan
        public decimal gettongthu(string kyghi, string ID)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT sum(tong_thu) as tongtien  FROM HOADON a, LOTRINH_Thu b, KHACHHANG c, HINHTHUCTHANHTOAN d , dm_phieu_thu e " +
                        " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH " +
                        " and d.maHTTT = c.MA_HTTT and a.ID_HD = e.FKEY and b.nv_id = " + ID + " " +
                        " and a.kyghi = '" + kyghi + "' and Checks = 0 and a.ID_HD not in (select ID_HD from dstam)";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return (decimal)obj;
            }
        }
        //get total pgae
        public int getTotalpage(string maLT, string kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT count(ID_HD)" +
                         "FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d " +
                         "WHERE b.malt = c.malt and a.ID_KH = c.ID_KH " +
                         "and d.maHTTT = c.MA_HTTT and b.malt = '" + maLT + "' and a.kyghi = '" + kyghi + "'";
            obj = cn.ExecuteScalar(SQL);
            int tong = Int32.Parse(obj.ToString());
            totalpage = tong / pageSize;
            if (tong % pageSize > 0)
            {
                totalpage += 1;
            }
            return totalpage;
        }
        // get khach hang - hóa đơn
        public DataTable getKH_HD(string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi,  tenHTTT, ten_kyghi, a.ID_KH " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON)  and a.malt = '" + malt + "' order by a.id_kh ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_HD()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi,  tenHTTT, ten_kyghi, a.ID_KH " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON) ";
            dt = cn.getData(SQL);
            return dt;
        }
        // get khach hang - hóa đơn
        public DataTable getkyghi_gachno_ck(string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT distinct a.kyghi, ten_kyghi" +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON)  and a.malt = '" + malt + "'";
            dt = cn.getData(SQL);
            return dt;
        }
        //get danh sách gạch nợ
        public DataTable getDGGachno(List<int> obj)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  a.ID_HD, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, STT_thu, tenHTTT " +
                         "FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d " +
                         "WHERE b.malt = c.malt and a.ID_KH = c.ID_KH " +
                         "and d.maHTTT = c.MA_HTTT and b.malt = '010' and a.kyghi = '201608' " +
                         "and ID_HD NOT IN (" + obj + ") order by stt_thu";
            dt = cn.getData(SQL);
            return dt;
        }
        // get DS HD
        public DataTable getDSHD(string kyghi, string ID_NV)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  max(ID_CT) as id,  ID_HD, a.tongtien " +
                        " FROM HOADON a, NHANVIEN b, LOTRINH c , CHUNGTU d " +
                        " WHERE b.NV_ID = c.ID_NV_thu and a.MaLT = c.maLT " +
                        " and b.NV_ID = d.NV_ID_nop and a.kyghi = '" + kyghi + "'  and NV_ID = " + ID_NV + " GROUP BY a.tongtien, id_hd ";
            dt = cn.getData(SQL);
            return dt;
        }
        // get ds lt
        public DataTable getLT_NV(string NV_ID)
        {
            if (NV_ID == "System.Data.DataRowView")
            {
                DataTable dt = new DataTable();
                Connect_DB cn = new Connect_DB();
                string SQL = "SELECT  * from lotrinh";
                dt = cn.getData(SQL);
                return dt;
            }
            else
            {
                DataTable dt = new DataTable();
                Connect_DB cn = new Connect_DB();
                string SQL = "SELECT tenLT, maLT FROM LOTRINH a, NHANVIEN b WHERE a.ID_NV_Thu = b.NV_ID and b.NV_ID = " + NV_ID + "";
                dt = cn.getData(SQL);
                return dt;
            }
        }
        //// get tong no
        public decimal gettongno(string ID_NV, string kyghi)
        {
            if (ID_NV != "System.Data.DataRowView")
            {
                object obj;
                Connect_DB cn = new Connect_DB();
                string SQL = "SELECT  sum(tongtien) as tongno FROM LOTRINH a, HOADON b WHERE a.maLT = b.MaLT and a.ID_NV_thu = " + ID_NV + " and kyghi = '" + kyghi + "'";
                obj = cn.ExecuteScalar(SQL);
                if (obj == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)obj;
                }
            }
            else
            {
                return 0;
            }
        }
        // get tong thanh toán
        public decimal gettongthu(string ID_NV)
        {
            if (ID_NV != "System.Data.DataRowView")
            {
                object obj;
                Connect_DB cn = new Connect_DB();
                string SQL = " select round( sum(a.tong_thu), 2)  from dm_phieu_thu a, HOADON b, LOTRINH c " +
                             " where a.FKEY = b.ID_HD  and b.MaLT = c.maLT  and Checks = 0 and c.ID_NV_thu = " + ID_NV + "";
                obj = cn.ExecuteScalar(SQL);
                if (obj == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (decimal)obj;
                }
            }
            else
            {
                return 0;
            }
        }
        // get data
        public DataTable get(DataTable dt)
        {
            DataTable obj = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM " + dt + "";

            obj = cn.getData(SQL);
            return obj;
        }
        // get khách hàng gạch nợ theo ten
        public DataTable getData_KH_HT(string hoten, string malt)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, ten_kyghi, a.ID_KH " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi and isinhd = 1 " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON ) " +
                         " and a.maLT = '" + malt + "' and c.hoten_KH like lower(N'%" + hoten + "%') order by a.id_kh ";
            ct = cn.getData(SQL);
            return ct;
        }
        public DataTable getData_KH_HT(string hoten)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, ten_kyghi, a.ID_KH " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi and isinhd = 1 " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON ) " +
                         " and c.hoten_KH like lower(N'%" + hoten + "%')  order by a.id_kh ";
            ct = cn.getData(SQL);
            return ct;
        }
        public decimal getTongtien(string malt)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SUM(tongtien) FROM HOADON WHERE ID_HD not in (select ID_HD FROM CHUNGTU_HOADON) and malt = '" + malt + "'";
            obj = cn.ExecuteScalar(SQL);
            if(obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return decimal.Parse(obj.ToString());
            }
        }

        public decimal getTongtien(string malt, string kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SUM(tongtien) FROM HOADON WHERE ID_HD not in (select ID_HD FROM CHUNGTU_HOADON) and malt = '" + malt + "' and kyghi = '"+kyghi+"'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return decimal.Parse(obj.ToString());
            }
        }
        public decimal getTongtien_hoten(string malt, string hoten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SUM(tongtien) FROM HOADON a, KHACHHANG b WHERE a.ID_KH = b.ID_KH and ID_HD not in (select ID_HD FROM CHUNGTU_HOADON) and b.malt = '" + malt + "' and hoten_KH like N'%" + hoten + "%'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return decimal.Parse(obj.ToString());
            }
        }
        public decimal getTongtien_SDT(string malt, string SDT)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SUM(tongtien) FROM HOADON a, KHACHHANG b WHERE a.ID_KH = b.ID_KH and ID_HD not in (select ID_HD FROM CHUNGTU_HOADON) and b.malt = '" + malt + "' and SDT_KH like N'%" + SDT + "%'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return decimal.Parse(obj.ToString());
            }
        }
        public decimal getTongtien_diachi(string malt, string diachi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SUM(tongtien) FROM HOADON a, KHACHHANG b WHERE a.ID_KH = b.ID_KH and ID_HD not in (select ID_HD FROM CHUNGTU_HOADON) and b.malt = '" + malt + "' and diachi like N'%" +diachi + "%'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return decimal.Parse(obj.ToString());
            }
        }
        public decimal getTongtien_madanhbo(string malt, string madanhbo)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SUM(tongtien) FROM HOADON a, KHACHHANG b WHERE a.ID_KH = b.ID_KH and ID_HD not in (select ID_HD FROM CHUNGTU_HOADON) and b.malt = '" + malt + "' and madanhbo like N'%" + madanhbo + "%'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return decimal.Parse(obj.ToString());
            }
        }
        // get đã đồng bộ theo hoa don
        public DataTable getData_KH_HT_DB(string hoten, string malt)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi, keys  " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD  in (select ID_HD from CHUNGTU_HOADON ) " +
                         " and a.maLT = '" + malt + "' and c.hoten_KH like lower(N'%" + hoten + "%')";
            ct = cn.getData(SQL);
            return ct;
        }
        // get khách hàng gạch nợ theo ma danh bo
        public DataTable getData_KH_MA(string ma,string malt)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi,  tenHTTT, ten_kyghi , a.id_kh" +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi  and isinhd = 1 " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON ) " +
                         " and a.malt = '" + malt + "' and  c.madanhbo like  lower(N'%" + ma + "%')";
            ct = cn.getData(SQL);
            return ct;
        }
        public DataTable getData_KH_MA(string ma)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi,  tenHTTT, ten_kyghi , a.id_kh" +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi and isinhd = 1 " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON ) and isinhd = 1 " +
                         " and  c.madanhbo =  lower(N'" + ma + "')";
            ct = cn.getData(SQL);
            return ct;
        }
        // get khách hàng gạch nợ theo ky ghi
        public DataTable getData_KH_Kyghi( string malt)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi,  tenHTTT, ten_kyghi, a.ID_KH " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi and isinhd = 1 " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON ) " +
                         " and a.malt = '" + malt + "'";
            ct = cn.getData(SQL);
            return ct;
        }

        // get khách hàng dong bo theo ma danh bo
        public DataTable getData_KH_MA_DB(string ma, string malt)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi,  tenHTTT, ten_kyghi, keys  " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi and isinhd = 1 " +
                         " and a.ID_HD  in (select ID_HD from CHUNGTU_HOADON ) " +
                         " and a.malt = '" + malt + "' and  c.madanhbo like  lower(N'%" + ma + "%')";
            ct = cn.getData(SQL);
            return ct;
        }
        // get khách hàng gạch nợ theo tendiachi
        public DataTable getData_KH_DC(string diachi, string malt)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi, a.ID_KH  " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi and isinhd = 1 " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON) " +
                         " and a.malt = '" + malt + "' and c.diachi = lower( N'" + diachi + "')";
            ct = cn.getData(SQL);
            return ct;
        }
        public DataTable getData_KH_DC(string diachi)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi, a.ID_KH  " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi  and isinhd = 1 " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON) " +
                         " and c.diachi =  N'" + diachi + "'";
            ct = cn.getData(SQL);
            return ct;
        }

        // get khách hàng DONG BO theo tendiachi
        public DataTable getData_KH_DC_DB(string diachi, string malt)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, SO_HD, ky_hieu_hd, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi, keys, a.ID_KH  " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD in (select ID_HD from CHUNGTU_HOADON) " +
                         " and a.malt = '" + malt + "' and c.diachi like lower( N'%" + diachi + "%')";
            ct = cn.getData(SQL);
            return ct;
        }
        // get khách hàng gạch nợ theo sdt
        public DataTable getData_KH_SDT(string SDT, string malt)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi , a.ID_KH " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi and isinhd = 1 " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON ) " +
                         " and b.malt = '" + malt + "' and c.SDT_KH ='" + SDT + "'";
            ct = cn.getData(SQL);
            return ct;
        }
        public DataTable getData_KH_SDT(string SDT)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi , a.ID_KH " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON ) and isinhd = 1 " +
                         "  and c.SDT_KH =  '" + SDT + "'";
            ct = cn.getData(SQL);
            return ct;
        }
        public DataTable getData_KH_IDKH(string ID_KH)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi , a.ID_KH " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON ) and isinhd = 1 " +
                         "  and c.ID_KH = " + ID_KH + " ";
            ct = cn.getData(SQL);
            return ct;
        }
        public DataTable getData_KH_IDKH(string ID_KH, string maLT)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi , a.ID_KH " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD not in (select ID_HD from CHUNGTU_HOADON ) and isinhd = 1 " +
                         "  and c.ID_KH =  " + ID_KH + " and a.malt = '"+maLT+"'";
            ct = cn.getData(SQL);
            return ct;
        }

        // get khách hàng dong bo theo sdt
        public DataTable getData_KH_SDT_DB(string SDT, string kyghi, string malt)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi, keys  " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD  in (select ID_HD from CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT and b.ID_kyghi = '" + kyghi + "') " +
                         " and a.kyghi = '" + kyghi + "' and b.malt = '" + malt + "' and c.SDT_KH like  N'%" + SDT + "%'";
            ct = cn.getData(SQL);
            return ct;
        }
        // get danh sach theo SOCT
        public DataTable getData_KH_SOCT_DB(string soCT, string kyghi)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi, keys  " +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD  in (select ID_HD from CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT and b.SOCT like  '%" + soCT + "%' and b.ID_kyghi = '" + kyghi + "') " +
                         " and a.kyghi = '" + kyghi + "' ";
            ct = cn.getData(SQL);
            return ct;
        }

        // get danh sach theo SOHD
        public DataTable getData_KH_SOHD_DB(string soHD, string kyghi)
        {
            DataTable ct = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ID_HD, tongtien, b.malt, tenLT, madanhbo, hoten_KH, diachi, tenHTTT, ten_kyghi, keys" +
                         " FROM HOADON a, LOTRINH b, KHACHHANG c, HINHTHUCTHANHTOAN d , DANHMUCKYGHI f " +
                         " WHERE b.malt = c.malt and a.ID_KH = c.ID_KH and d.maHTTT = c.MA_HTTT and a.kyghi = f.ID_kyghi " +
                         " and a.ID_HD  in (select ID_HD from CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT and b.ID_kyghi = '" + kyghi + "') " +
                         " and a.kyghi = '" + kyghi + "' and a.SO_HD like '%" + soHD + "%'";
            ct = cn.getData(SQL);
            return ct;
        }
        // thêm chứng từ hóa đơn
        public int insertCT_HD(CHUNGTU_HOADON obj, string kyghi, string SOCT)
        {
            int result;
            object id;
            Connect_DB cn = new Connect_DB();
            string SQL_ID_CT = "SELECT ID_CT FROM CHUNGTU WHERE  ID_kyghi = '" + kyghi + "' and SOCT = '" + SOCT + "'";
            id = cn.ExecuteScalar(SQL_ID_CT);
            string SQL = "INSERT INTO CHUNGTU_HOADON VALUES(" + id.ToString()+ "," + obj.ID_HD + ", " + obj.sotien + ", 0)";
            result = cn.updateData(SQL);
            return result;
        }
        // update hoadon
        public int updateHD(string sotien, string ID_HD, string kyghi)
        {
            int result;
            object id;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE HOADON set sotienthanhtoan = " + sotien + " , sotienno = 0 WHERE ID_HD = " + ID_HD + " and kyghi = '" + kyghi + "' and IsInHD = 1 ";
            result = cn.updateData(SQL);
            return result;
        }
        //insert ds tam
        public int InsertDSTam(string ID, string NV)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO DSTAM(ID_HD, ID_NV) VALUES(" + ID + ", "+NV+")";
            rs = cn.updateData(SQL);
            return rs;
        }
        // kiem tra ds tam
        public int TestDSTAM(string id)
        {
            object rs1;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ID_HD FROM DSTAM WHERE ID_HD = '" + id + "'";
            rs1 = cn.ExecuteScalar(SQL);
            if (rs1 == null)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(rs1.ToString());
            }
        }
        // delete ds tam
        public int deleteDSTam(string ID)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE DSTAM WHERE ID_HD = " + ID + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        // insert chung tu hoa don
        public int insertCT_HD_NV(string ID_NV, string kyghi, string SO_CT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO CHUNGTU_HOADON(ID_CT, ID_HD, sotien, dadongbo) " +
                         " select id_ct as id, b.ID_HD, a.tong_thu, checks from dm_phieu_thu a, HOADON b, LOTRINH_Thu c, CHUNGTU d " +
                         " where a.FKEY = b.ID_HD " +
                         " and b.MaLT = c.maLT  and Checks = 0  " +
                         " and c.nv_id = d.NV_ID_nop and c.nv_id = " + ID_NV + " and IsInHD = 1 and b.id_hd not in (select id_hd from chungtu_hoadon) " +
                         " and b.ID_HD not in ( SELECT ID_HD from DSTAM)  group by ID_HD, tong_thu, checks ,ID_CT " + 
                         "having ID_CT = (SELECT ID_CT FROM CHUNGTU WHERE  ID_kyghi = '" + kyghi + "' and SOCT = '"+SO_CT+"')";
            rs = cn.updateData(SQL);
            return (rs);

        }
        public int deletedstam(string ID_NV)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE FROM DSTAM WHERE ID_NV = "+ID_NV+" ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public string getIDCT_NVlap(string ngaylap, string ID, string maloai)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT max(ID_CT) FROM CHUNGTU WHERE ngaylap  between convert(datetime, '" + ngaylap +" 00:00:00') and convert(datetime, '" + ngaylap + " 23:59:00')  and NV_ID_lap = " + ID + " and maloai = '"+maloai+"'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value || obj == null || obj == "")
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }
        public string getSOCT_NVlap(string ngaylap, string ID, string maloai)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT max(SOCT) FROM CHUNGTU WHERE ngaylap  between convert(datetime, '" + ngaylap + " 00:00:00') and convert(datetime, '" + ngaylap + " 23:59:00')  and NV_ID_lap = " + ID + " and maloai = '" + maloai + "'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == null )
            {
                return "0";
            }
            else
            {
                return obj.ToString();
            }
        }
        public int insertCT_HD_NVLAP(CHUNGTU_HOADON obj)
        {
            int result;
            object id;
            Connect_DB cn = new Connect_DB(); ;
            string SQL = "INSERT INTO CHUNGTU_HOADON VALUES(" + obj.ID_CT + "," + obj.ID_HD + ", " + obj.sotien + ", 0)";
            result = cn.updateData(SQL);
            return result;
        }
        //public int updatetongtien_CT(string ID_CT)
        //{
        //    int obj;
        //    Connect_DB cn = new Connect_DB();
        //    string SQL = "UPDATE CHUNGTU SET tongtien = isnull((select SUM(sotien) FROM CHUNGTU a, CHUNGTU_HOADON b where a.ID_CT = b.ID_CT and a.ID_CT = "+ID_CT+"), 0) where ID_CT = "+ID_CT+" ";
        //    obj = cn.updateData(SQL);
        //    return obj;
        //}
        public int updatetongtien_CT_NV(string SOCT, string kyghi)
        {
            int obj;
            Connect_DB cn = new Connect_DB();
            string SQL = " UPDATE CHUNGTU SET tongtien = (select isnull( SUM(sotien), 0) " +
                         " FROM CHUNGTU a, CHUNGTU_HOADON b where a.ID_CT = b.ID_CT and SOCT = '" + SOCT + "' and ID_kyghi = '" + kyghi + "')" +
                         " where SOCT = '" + SOCT + "' and ID_kyghi = '" + kyghi + "' ";
            obj = cn.updateData(SQL);
            return obj;
        }

        public int updatetongtien_CT(string ID_CT)
        {
            int obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU SET tongtien = isnull((select ROUND(SUM(sotien), 1) FROM CHUNGTU a, CHUNGTU_HOADON b where a.ID_CT = b.ID_CT and a.ID_CT = "+ID_CT+"), 0) where ID_CT = "+ID_CT+" ";
            obj = cn.updateData(SQL);
            return obj;
        }
        public void get_IDKH(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  a.id_kh  FROM khachhang a, hoadon b WHERE a.ID_KH = b.ID_KH and isinhd = 1 and sotienno != 0 order by a.id_kh";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["id_kh"].ToString());
                }
            }
            obj.Close();
        }
        public void get_hoten(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  hoten_kh as hoten FROM khachhang a, hoadon b WHERE a.ID_KH = b.ID_KH and isinhd = 1 and id_hd not in (select id_hd from chungtu_hoadon)  order by hoten_KH";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["hoten"].ToString());
                }
            }
            obj.Close();
        }

        public void get_soHD(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT so_hd FROM hoadon where sotienno != 0 order by id_hd";
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
        // get data autocomplete

        public void get_maDB(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT substring(madanhbo, 10,5) madanhbo FROM khachhang a, hoadon b WHERE a.ID_KH = b.ID_KH and isinhd = 1 and id_hd not in (select id_hd from chungtu_hoadon)  order by madanhbo";
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
        // get data auto diachi
        public void get_diachi(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT diachi FROM khachhang a, hoadon b where a.ID_KH = b.ID_KH and isinhd = 1 and id_hd not in (select id_hd from chungtu_hoadon) order by diachi";
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
        // get data auto SDT
        public void get_SDT(AutoCompleteStringCollection coll)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SDT_KH FROM khachhang a, hoadon b where a.ID_KH = b.ID_KH and isinhd = 1 and id_hd not in (select id_hd from chungtu_hoadon) order by SDT_KH";
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
        // get data autocomplete
        public void get_hoten_STT(AutoCompleteStringCollection coll, string malt)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT   hoten_kh as hoten FROM khachhang  WHERE malt = '" + malt + "' order by hoten_KH";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["hoten"].ToString());
                }
            }
            obj.Close();
        }
        // get data auto diachi
        public void get_diachi_STT(AutoCompleteStringCollection coll, string malt)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT diachi FROM khachhang  where malt = '" + malt + "' order by diachi";
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
        // get data auto SDT
        public void get_SDT_STT(AutoCompleteStringCollection coll, string malt)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SDT_KH FROM khachhang where malt = '" + malt + "' order by SDT_KH";
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
        // in phiếu thu theo nhân viên thu
        public DataTable Phieuthu_NV(string NV, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT COUNT(a.ID_HD) as tongthu,  tong.tong as tonglt,soluong.SOCT, soluong.tong as soluonglt, soluong.MaLT " +
                         " FROM CHUNGTU_HOADON a full join CHUNGTU c on a.ID_CT = c.ID_CT " +
                         " left join  HOADON b on b.ID_HD = a.ID_HD left join  LOTRINH d on d.maLT = b.MaLT " +
                         " and d.ID_NV_thu = " + NV + " and c.ID_kyghi = '" + kyghi + "' " +
                         " left join(select count(id_hd) as tong, ID_NV_thu from HOADON a, LOTRINH b where a.MaLT = b.maLT and b.ID_NV_thu = 2 " +
                         " and a.kyghi = '" + kyghi + "' group by ID_NV_thu) as tong on D.ID_NV_thu = tong.ID_NV_thu " +
                         " left join (SELECT COUNT(c.ID_HD) as tong, a.MaLT, d.ID_NV_thu, e.SOCT " +
                         " FROM HOADON a, dm_phieu_thu b, CHUNGTU_HOADON c, LOTRINH d, CHUNGTU e " +
                         " WHERE a.ID_HD = b.FKEY " +
                         " and a.ID_HD = c.ID_HD and a.MaLT = d.maLT and e.NV_ID_nop = " + NV + " " +
                         " and e.ID_CT = c.ID_CT group by a.MaLT, e.ID_CT, d.ID_NV_thu, SOCT  having e.ID_CT = max(e.ID_CT)) as soluong " +
                         " on soluong.ID_NV_thu = d.ID_NV_thu group by  d.ID_NV_thu, c.ID_kyghi, tong.tong,soluong.SOCT, soluong.tong, soluong.MaLT ";
            dt = cn.getData(SQL);
            return dt;
        }
        // get max SO CT
        public string getmax_STCT(string kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT MAX(SOCT) FROM CHUNGTU WHERE ID_kyghi = '" + kyghi + "' ";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)obj;
            }
        }
        // detail gach no
        public DataTable getChitiet_gachno()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, isnull(soluong.soluong, 0) soluong, SOCT, ngayct ngaylap, a.NV_ID_nop , " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ten_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,isnull(socghuagach.soluongchuagach, 0) soluongchuagach, " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end nvnop, a.NV_ID_lap, c.hoten nvlap " +
                         " FROM CHUNGTU a left join NHANVIEN b on a.NV_ID_nop = b.NV_ID " +
                         " left join NHANVIEN c on a.NV_ID_lap = c.NV_ID " +
                         " left join KHACHHANG f on a.NV_ID_nop = f.ID_KH " +
                         " left join DANHMUCKYGHI d on a.ID_kyghi = d.ID_kyghi " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluong, a.ID_CT FROM CHUNGTU a, CHUNGTU_HOADON b WHERE a.ID_CT = b.ID_CT GROUP BY  a.ID_CT) as soluong " +
                         " on a.ID_CT = soluong.ID_CT " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0 group by b.ID_CT) as socghuagach " +
                         " on a.ID_CT = socghuagach.ID_CT " +
                         " group by  b.hoten, c.hoten, a.tongtien, d.ten_kyghi, a.trangthai, a.NV_ID_lap, c.hoten,  " +
                         " soluong.soluong, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, b.maNV, " +
                         " a.NV_ID_nop, f.hoten_KH order by ngayct ";

            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getChitiet_gachno_KH()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach,   " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID and a.maloai = 'KH'  " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0 and maloai = 'KH' group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and maloai = 'KH'  " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV,  " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        // get FKey
        public DataTable getFkey(string ID_CT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT keys, hoten_KH FROM HOADON a, CHUNGTU_HOADON b, CHUNGTU c, KHACHHANG d " +
                         "WHERE a.ID_HD = b.ID_HD and b.ID_CT = c.ID_CT and a.ID_KH = d.ID_KH and c.ID_CT = "+ID_CT+" and dadongbo = 0";
            dt = cn.getData(SQL);
            return dt;
        }
        public int gettrangthai_CT(string ID_CT)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT COUNT(ID_HD) as soluong FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT and b.ID_CT = " + ID_CT + " and dadongbo = 0";
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
        // detail payment kyghi
        public DataTable getChitiet_gachno_kyghi(string kyghi, string maloai)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,   " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID and a.maloai = '"+maloai+ "'  and a.id_kyghi = '" + kyghi+"'  " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0 and maloai = '" + maloai + "' group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and maloai = '" + maloai + "' or a.maloai = '' " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV,  c.hoten, " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getChitiet_gachno_kyghi(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,   " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID   and a.id_kyghi = '" + kyghi + "'  " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0  group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV, c.hoten, " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        // detail payment so CT
        public DataTable getChitiet_gachno_CT(string CT, string maloai)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,   " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID and a.maloai = '" + maloai + "' or a.maloai = '' and a.SOCT like '%" + CT+"%' " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0 and maloai = '" + maloai + "' and SOCT like '%" + CT + "%' group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and maloai = '" + maloai + "' or a.maloai = '' and a.SOCT like '%" + CT + "%'  " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV, c.hoten, " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getChitiet_gachno_CT(string CT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach,  c.hoten nvlap,  " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID  and a.SOCT like '%" + CT + "%' " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0  and SOCT like '%" + CT + "%' group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and a.SOCT like '%" + CT + "%'  " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV, c.hoten, " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        // detail payment status
        public DataTable getChitiet_gachno_trangthai(string trangthai, string maloai)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,  " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID and a.maloai = '" + maloai + "' or a.maloai = '' and a.trangthai  = " + trangthai+" " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0 and maloai = '" + maloai + "' and trangthai  = " + trangthai + " group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and maloai = '" + maloai + "' and a.trangthai  = " + trangthai + " " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV, c.hoten,  " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getChitiet_gachno_trangthai(string trangthai)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,  " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID  and a.trangthai  = " + trangthai + " " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0 and trangthai  = " + trangthai + " group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and a.trangthai  = " + trangthai + " " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV,c.hoten,  " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        // detail payment nhanvien
        public DataTable getChitiet_gachno_nhanvien(string nhanvien)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,   " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID  and a.NV_ID_nop  = " + nhanvien + " " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0  and NV_ID_nop  = " + nhanvien + " group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT   and a.NV_ID_nop  = " + nhanvien + " " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV, c.hoten , " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getChitiet_gachno_nhanvien(string nhanvien, string maloai)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap, " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID  and a.NV_ID_nop  = " + nhanvien + " and a.maloai = '" + maloai + "' " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0  and maloai = '" + maloai + "' and NV_ID_nop  = " + nhanvien + " group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT   and a.NV_ID_nop  = " + nhanvien + " and a.maloai = '" + maloai + "' " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV, c.hoten, " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        // detail payment nhan vien lap
        public DataTable getChitiet_gachno_nhanvien_lap(string nhanvien, string maloai)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap , " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID and a.maloai = '" + maloai + "'  and a.NV_ID_lap  = " + nhanvien + " " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0 and maloai = '" + maloai + "' and NV_ID_lap  = " + nhanvien + " group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and maloai = '" + maloai + "'  and a.NV_ID_lap  = " + nhanvien + " " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV, c.hoten,   " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getChitiet_gachno_nhanvien_lap(string nhanvien)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,   " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID  and a.NV_ID_lap  = " + nhanvien + " " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0  and NV_ID_lap  = " + nhanvien + " group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and a.NV_ID_lap  = " + nhanvien + " " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV, c.hoten,  " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        // detail payment datetime  and a.ngaylap between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:00')
        public DataTable getChitiet_gachno_ngaylap(string tungay, string denngay, string kyghi, string maloai)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,  " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID and a.maloai = '" + maloai + "' or a.maloai = '' and a.ngayct between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:00') " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0 and maloai = '" + maloai + "' and ngayct between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:59') group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and maloai = '" + maloai + "' or a.maloai = '' and a.ngayct between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:59') " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV, c.hoten, " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getChitiet_gachno_ngaylap(string tungay, string denngay, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,  " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID  and a.ngayct between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:00') " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0  and ngayct between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:59') group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and a.ngayct between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:59') " +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV,c.hoten,   " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getChitiet_gachno_ngaylap_nv(string tungay, string denngay, string nhanvien_id)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,  " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID  and a.ngayct between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:00') " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0  and ngayct between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:59') group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and a.ngayct between convert(datetime, '" + tungay + " 00:00:00') and convert(datetime, '" + denngay + " 23:59:59') " +
                         " where a.nv_id_nop = " + nhanvien_id + "" +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV,c.hoten,   " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        // detail payment loai
        public DataTable getChitiet_gachno_loai(string ma)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT ROW_NUMBER() OVER(ORDER BY ngayct) as STT, a.tongtien, COUNT(ID_HD)  soluong, SOCT, ngayct ngaylap, a.NV_ID_nop,  " +
                         " case when a.trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end as trangthai , ID_kyghi as quyenso, a.ID_CT, a.ID_kyghi ,  " +
                         " isnull(socghuagach.soluongchuagach, 0) soluongchuagach, c.hoten nvlap,   " +
                         " case when b.hoten is null then CONVERT(varchar, f.ID_KH) +' - ' + f.hoten_KH else b.maNV + ' - ' + b.hoten end  nvnop, a.NV_ID_lap  " +
                         " FROM CHUNGTU a  " +
                         " inner join NHANVIEN c on a.NV_ID_lap = c.NV_ID and a.maloai = '" + ma + "'  " +
                         " left join NHANVIEN b on a.NV_ID_nop = b.NV_ID  " +
                         " left  join KHACHHANG f on a.NV_ID_nop = f.ID_KH  " +
                         " left join CHUNGTU_HOADON d on a.ID_CT = d.ID_CT  " +
                         " left  join(SELECT isnull(COUNT(ID_HD), 0) as soluongchuagach, b.ID_CT  " +
                         " FROM CHUNGTU_HOADON a, CHUNGTU b WHERE a.ID_CT = b.ID_CT AND a.dadongbo = 0 and maloai = '" + ma + "' group by b.ID_CT) as socghuagach  " +
                         " on a.ID_CT = socghuagach.ID_CT  and maloai = '" + ma + "'" +
                         " group by   c.hoten, a.tongtien, ID_kyghi, a.trangthai, a.NV_ID_lap, b.hoten, b.maNV,   c.hoten, " +
                         " a.NV_ID_nop, SOCT, ngayct, a.ID_CT, a.ID_kyghi, socghuagach.soluongchuagach, f.ID_KH, f.hoten_KH  " +
                         " order by ngayct ";
            dt = cn.getData(SQL);
            return dt;
        }
        //  get trang thai chung tu
        public int getsoHD_CT(string ID_CT)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT COUNT(ID_HD) as soluong FROM CHUNGTU a, CHUNGTU_HOADON b WHERE a.ID_CT = b.ID_CT and a.ID_CT = " + ID_CT + "";
            obj = cn.ExecuteScalar(SQL);
            if (Int32.Parse(obj.ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(obj.ToString());
            }
        }
        // update dong bo webservice
        public int updatetrangthai_CT(string ID_CT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU SET trangthai = 1 WHERE ID_CT = " + ID_CT + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        // get fkey
        public DataTable FKEY_CT(string ID_CT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ID_HD FROM CHUNGTU_HOADON WHERE ID_CT = " + ID_CT + " and dadongbo = 0";
            dt = cn.getData(SQL);
            return dt;
        }
        // update trang thai hoa don
        public int updateTrangthaiCT_HD_DB(string ID_CT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU_HOADON SET dadongbo = 0 WHERE ID_HD = " + ID_CT + "";
            rs = cn.updateData(SQL);
            return rs;
        }

        // update trang thai hoa don
        public int updateTrangthaiCT_HD(string ID_CT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU_HOADON SET dadongbo = 1 WHERE ID_CT = "+ID_CT+"";
            rs = cn.updateData(SQL);
            return rs;
        }
        // get chi tiet chung tu
        public SqlDataReader getchitietCT(string ID)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenloai, c.hoten as nvnop, d.hoten as nvlap, ngaylap, ngayct, a.ID_kyghi, tongtien, SOCT,ghichu, ten_kyghi,  " +
                         "case when trangthai = 0 then N'chưa đồng bộ' else N'đã đồng bộ' end trangthai " +
                         "FROM CHUNGTU a left join LOAICHUNGTU b on a.maloai = b.maloai left join NHANVIEN c on a.NV_ID_nop = c.NV_ID " +
                         "left join danhmuckyghi f on a.id_kyghi = f.id_kyghi "+
                         "left join NHANVIEN d on a.NV_ID_lap = d.NV_ID WHERE a.ID_CT = " + ID + " ";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        // get chi tiet ds chung tu _ hoa don
        public DataTable getchitietCT_HD(string ID_CT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  hoten_KH, c.ID_HD, c.so_hd, d.ID_KH, ten_kyghi, e.malt tenLT, diachi, SDT_KH, tenHTTT, c.tongtien, d.maLT, d.madanhbo, " +
                         "case when dadongbo = 1 then 'true' else 'false' end as dadongbo, case when pt.ngay_thu_tien is null then a.ngayct else pt.ngay_thu_tien end ngay_thu_tien    " +
                         "FROM CHUNGTU a "+
                         "inner join CHUNGTU_HOADON b on a.ID_CT = b.ID_CT " +
                         "left join dm_phieu_thu pt on b.id_hd = fkey "+
                         "left join HOADON c on b.ID_HD = c.ID_HD " +
                         "left join KHACHHANG d on c.ID_KH = d.ID_KH " +
                         "left join DANHMUCKYGHI f on f.ID_kyghi = c.kyghi " +
                         "left join LOTRINH e on d.maLT = e.maLT and c.MaLT = e.maLT " +
                         "inner join HINHTHUCTHANHTOAN g on g.maHTTT = d.MA_HTTT where a.ID_CT = " + ID_CT + "  order by pt.ngay_thu_tien";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getchitietCT_HD_CK(string ID_CT, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  hoten_KH, c.ID_HD, c.so_hd, d.ID_KH, ten_kyghi, e.malt tenLT, diachi, SDT_KH, tenHTTT, c.tongtien, d.maLT, d.madanhbo, " +
                         "case when dadongbo = 1 then 'true' else 'false' end as dadongbo, case when pt.ngay_thu_tien is null then a.ngayct else pt.ngay_thu_tien end ngay_thu_tien   " +
                         "FROM CHUNGTU a " +
                         "inner join CHUNGTU_HOADON b on a.ID_CT = b.ID_CT " +
                         "inner join dm_phieu_thu pt on b.id_hd = fkey " +
                         "left join HOADON c on b.ID_HD = c.ID_HD " +
                         "left join KHACHHANG d on c.ID_KH = d.ID_KH " +
                         "left join DANHMUCKYGHI f on f.ID_kyghi = c.kyghi " +
                         "left join LOTRINH e on d.maLT = e.maLT and c.MaLT = e.maLT " +
                         "inner join HINHTHUCTHANHTOAN g on g.maHTTT = d.MA_HTTT where a.ID_CT = " + ID_CT + " and a.ID_kyghi = '" + kyghi + "' order by pt.ngay_thu_tien";
            dt = cn.getData(SQL);
            return dt;
        }
        // get trang thai gach no cua mot hoa don
        public int gettrangthaihoadon(string ID_HD)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT checks FROM dm_phieu_thu WHERE FKEY = " + ID_HD + "";
            obj = cn.ExecuteScalar(SQL);
            return Int32.Parse(obj.ToString());
        }
        // get trang thai dong bo cua mot hoa don
        public int gettrangthaiGN_HD(string ID_HD)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT dadongbo FROM CHUNGTU_HOADON  WHERE ID_HD = " + ID_HD + "";
            obj = cn.ExecuteScalar(SQL);
            if (Convert.ToBoolean(obj) == false)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        // DELETE CHUNGTU_HD
        public int deleteCT_HD(string ID_CT, string ID_HD)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE CHUNGTU_HOADON WHERE ID_CT = " + ID_CT + " and ID_HD = " + ID_HD + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        // update dm_phieuthu
        public int updateDM_PT(string FKEY)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE dm_phieu_thu SET checks = 0 WHERE FKEY = '" + FKEY + "'";
            rs = cn.updateData(SQL);
            return rs;
        }
        // update chung tu
        public int updateCT(string ID_CT, string tongthanhtoan)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU SET tongtien = tongtien + " + tongthanhtoan + " WHERE ID_CT = " + ID_CT + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        // update hoadon
        public int updateHOADON (string ID_HD)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE HOADON SET sotienthanhtoan = 0, sotienno = tongtien, ngaythanhtoan = null WHERE ID_HD = " + ID_HD + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        // get FKey
        public string getFkey_HD( string ID_HD)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT keys FROM HOADON  WHERE ID_HD = " + ID_HD + "";
            obj  = cn.ExecuteScalar(SQL);
            if(obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)obj;
            }
        }
        // get trang thai ky ghi
        public int gettrangthaikyghi(string ID_Kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT gachno FROM DANHMUCKYGHI  WHERE ID_kyghi = " + ID_Kyghi + "";
            obj = cn.ExecuteScalar(SQL);
            if (Convert.ToBoolean(obj) == false)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        // kiểm tra chứng từ
        public int getsoHD_CT(string ID_CT, string kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT COUNT(ID_HD) as soluong FROM CHUNGTU a, CHUNGTU_HOADON b WHERE a.ID_CT = b.ID_CT and a.ID_CT = "+ID_CT+"";
            obj = cn.ExecuteScalar(SQL);
            if(Int32.Parse(obj.ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(obj.ToString());
            }
        }
        public int getsoHD_CT_NV(string ID_CT, string kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT COUNT(ID_HD) as soluong FROM CHUNGTU a, CHUNGTU_HOADON b WHERE a.ID_CT = b.ID_CT and a.SOCT = '" + ID_CT + "' and a.ID_Kyghi = '"+kyghi+"'";
            obj = cn.ExecuteScalar(SQL);
            if (Int32.Parse(obj.ToString()) == 0)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(obj.ToString());
            }
        }
        // delete chung tu
        public int deleteCT(string ID_CT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE CHUNGTU WHERE ID_CT  = " + ID_CT + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        // kiem tra hoadon phiếu thu
        public string Testdm_phieu_thu(string ID_HD)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT checks FROM dm_phieu_thu WHERE FKEY = " + ID_HD + " ";
            rs = cn.ExecuteScalar(SQL);
            if(rs == null)
            {
                return "chuathu";
            }
            else
            {
                return rs.ToString();
            }
        }
        // kiem tra hoa don- chungtu hoadon
        public int Testchungtu_hoadon(string ID_HD)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ID_HD FROM chungtu_hoadon WHERE ID_HD = " + ID_HD + " ";
            rs = cn.ExecuteScalar(SQL);
            if(rs == null)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(rs.ToString());
            }
        }
        // get chi tiet khach hang
        public SqlDataReader getchitetNV(string ID_NV)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT hoten,  tenPB FROM NHANVIEN a, PHONGBAN b WHERE a.maPB = b.maPB and a.NV_ID = " + ID_NV + "";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public string getchitetNVlap(string manv)
        {
            object dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT hoten FROM NHANVIEN WHERE NV_ID = "+manv+"";
            dr = cn.ExecuteScalar(SQL);
            return dr.ToString();
        }
        // kiểm tra gạch nợ
        public int TestGachno(string ID_HD, string ID_NV, string kyghi)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT a.ID_HD FROM CHUNGTU_HOADON a, HOADON b , LOTRINH c WHERE a.ID_HD = b.ID_HD and b.maLT = c.maLT and b.ID_HD = "+ID_HD+" and c.ID_NV_thu = "+ID_NV+" and b.kyghi = '"+kyghi+"'";
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
        public SqlDataReader getChitietPT( string soct)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT SOCT, count(d.ID_HD) tonghdthu, a.ID_kyghi, ten_kyghi, taikhoan_co, taikhoan_no, ngayct, a.ghichu,  dbo.CHITIET_THU(" + soct + ") chitiet, dbo.CHITIETHD_CT(" + soct + ") tonghd,  tongtien  " +
                         " FROM CHUNGTU a, LOAICHUNGTU b, DANHMUCKYGHI c, CHUNGTU_HOADON d WHERE a.maloai = b.maloai and a.id_kyghi = c.id_kyghi  and a.ID_CT = d.ID_CT "+
                         " and a.ID_CT = "+soct+" group by a.SOCT,a.ID_kyghi, ten_kyghi, taikhoan_co, taikhoan_no, ngayct, a.ghichu,tongtien ";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public SqlDataReader getChitietBN(string ID_CT)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT SOCT, count(d.ID_Chisonuoc) tonghdthu, a.ID_kyghi, ten_kyghi, taikhoan_co, " +
                         " taikhoan_no, ngayct, a.ghichu,  dbo.CHITIET_BIENNHAN(" + ID_CT + ") chitiet, "+
                         " sum(d.tongtien) tongtien, dbo.CHITIETHD_CT(" + ID_CT + ") tonghd " +
                         " FROM CHUNGTU a, LOAICHUNGTU b, DANHMUCKYGHI c, CHUNGTU_CHISONUOC d  " +
                         " WHERE a.maloai = b.maloai and a.id_kyghi = c.id_kyghi  and a.ID_CT = d.ID_CT " +
                         " and a.ID_CT = " + ID_CT + " group by a.SOCT,a.ID_kyghi, ten_kyghi, taikhoan_co, taikhoan_no, ngayct, a.ghichu";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public int update_HDThuTrung(string nv_id)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "update dm_phieu_thu set checks = 2 where fkey in ( " +
                         " select fkey from dm_phieu_thu a, CHUNGTU_HOADON b where a.fkey = b.id_hd and checks = 0 )";
            rs = cn.updateData(SQL);
            return rs;
        }
        public SqlDataReader getChitietPT_NV(string kyghi, string soct)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT SOCT,count(d.ID_HD) tonghdthu, a.ID_kyghi, ten_kyghi, taikhoan_co, taikhoan_no, ngayct, a.ghichu,  dbo.CHITIET_THU_NV('" + soct + "', '" + kyghi + "') chitiet, dbo.CHITIETHD_CT_NV('" + soct + "', '" + kyghi + "') tonghd,  tongtien  " +
                         " FROM CHUNGTU a, LOAICHUNGTU b, DANHMUCKYGHI c, CHUNGTU_HOADON d WHERE a.maloai = b.maloai and a.id_kyghi = c.id_kyghi  and a.ID_CT = d.ID_CT " +
                         " and a.SOCT = '" + soct + "' and a.ID_Kyghi = '"+kyghi+"' group by a.SOCT,a.ID_kyghi, ten_kyghi, taikhoan_co, taikhoan_no, ngayct, a.ghichu,tongtien ";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public SqlDataReader getChitietPT_CT(string ID_CT)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT SOCT, ID_kyghi, taikhoan_co, taikhoan_no, tongtien " +
                         " FROM CHUNGTU a, LOAICHUNGTU b WHERE a.maloai = b.maloai and ID_CT = "+ID_CT+"";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public SqlDataReader getchietietPT_KH(string ID_KH)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL =" select hoten_KH, diachi, a.malt from KHACHHANG WHERE ID_KH = "+ID_KH+"";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public string getsoCT(string ID_CT)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SOCT FROM CHUNGTU WHERE ID_CT = " + ID_CT + "";
            obj = cn.ExecuteScalar(SQL);
            if(obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return obj.ToString();
            }
        }

        public string getsotongHD(string ID_KH)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "select count(ID_HD) FROM HOADON WHERE ID_KH = "+ID_KH+"";
            obj = cn.ExecuteScalar(SQL);
            return obj.ToString();
        }
        public string vietbangchu(decimal tongtien)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT dbo.fnvnd2(" + tongtien + ")";
            obj = cn.ExecuteScalar(SQL);
            if(obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return obj.ToString();
            }
        }
        public string getLCT(string SOCT)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT maloai from chungtu where id_ct = "+SOCT+" ";
            rs = cn.ExecuteScalar(SQL);
            return rs.ToString();
        }
        public int updatePublishPublishedInvoices(string soct, string kyghi)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "update PublishedInvoices set GACH_NO = 1, STATUS = 0 where [key] in( " +
                         " SELECT [key] from PublishedInvoices, CHUNGTU_HOADON c , CHUNGTU d where [key] = ID_HD  and c.ID_CT = d.ID_CT and SOCT = '"+soct+"' and ID_kyghi = '"+kyghi+"')";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int updatePublishPublishedInvoices_NV(string soct, string kyghi)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "update PublishedInvoices set GACH_NO = 1, STATUS = 0 where [key] in( " +
                         " SELECT [key] from PublishedInvoices, CHUNGTU_HOADON c , CHUNGTU d where [key] = ID_HD  and c.ID_CT = d.ID_CT and SOCT = '" + soct + "' and ID_kyghi = '" + kyghi + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int updatePublishPublishedInvoices_GN(string ID_HD)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "update PublishedInvoices set GACH_NO = 0, STATUS = 0 where [key]  = "+ID_HD+" ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public SqlDataReader getTongtien_HD(string kyghi)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT isnull( COUNT(ID_HD), 0) tonghd,isnull( sum(tongtien),0) tongtien FROM hoadon WHERE kyghi = '" + kyghi + "' and isinhd = 1 ";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public SqlDataReader getThongTinKH(string soct)
        {
            SqlDataReader dr;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT hoten_KH, diachi FROM CHUNGTU a, KHACHHANG b WHERE a.nv_id_nop = b.id_kh and a.ID_CT = "+soct+" ";
            dr = cn.excuteReader(SQL);
            return dr;
        }
        public int delete_dm_phieuthu(string fkey)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "delete dm_phieu_thu where fkey = '" + fkey + "'";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int updateGhichu_CT(string soct, string kyghi, string ghichu)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "Update CHUNGTU set ghichu = ghichu +  N', "+ghichu+"' where soct = '"+soct+"' and ID_Kyghi = '"+kyghi+"' ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int updatenvnop(string soct, string kyghi, string ID_NV, string kyghi_ct)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU SET NV_ID_nop = " + ID_NV + " , ID_Kyghi = '"+kyghi_ct+"' WHERE ID_CT = "+soct+" ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int update_ngaythu(string soct, string kyghi, string ngaythu, string kyghi_gn)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU set ngayct = '" + ngaythu + "', ID_Kyghi = '"+kyghi_gn+"' where ID_CT = "+soct+" ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int update_ngaythanhtoan(string soct, string kyghi, string ngaythu)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE hoadon set ngaythanhtoan = '"+ngaythu+"' " + 
                        "from chungtu a, hoadon b, chungtu_hoadon c where b.id_hd = c.id_hd and c.id_ct = a.id_ct and a.ID_CT = "+soct+"";
            rs = cn.updateData(SQL);
            return rs;
        }
        public string sobiennhan(string kyghi, string soct)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SOCT FROM CHUNGTU WHERE SOCT = '" + soct + "' and ID_KYGHI = '" + kyghi + "'";
            obj = cn.ExecuteScalar(SQL);
            if(obj == DBNull.Value)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        public int updaet_soct (string soct_new , string id_ct)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU SET SOCT = '" + soct_new + "' where id_ct = "+id_ct+"";
            rs = cn.updateData(SQL);
            return rs;
        }
        public DataTable getHoaDonNo(string id_kh)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ten_kyghi, tongtien FROM hoadon , danhmuckyghi  WHERE kyghi = ID_Kyghi and sotienno <> 0 and ID_KH = " + id_kh + "  order by ten_kyghi";
            dt = cn.getData(SQL);
            return dt;
        }
        public string getchisonuoc(string ID_KH)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "select top 1 ten_kyghi + ': '+ convert (varchar, chisomoi)  from CHISONUOC a, DANHMUCKYGHI b where a.ID_kyghi = b.ID_kyghi and a.ID_KH = " + ID_KH + " order by ngaytao desc ";
            obj = cn.ExecuteScalar(SQL);
            return obj.ToString();
        }
        public int updatetongtien_CTCSN(string ID_CT)
        {
            int obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHUNGTU SET tongtien = isnull((select SUM(b.tongtien) FROM CHUNGTU a, CHUNGTU_CHISONUOC b where a.ID_CT = b.ID_CT and a.ID_CT = " + ID_CT + "), 0) where ID_CT = " + ID_CT + " ";
            obj = cn.updateData(SQL);
            return obj;
        }

    }
}
