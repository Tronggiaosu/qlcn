using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class LoTrinh_BLL
    {
        //Thêm lộ trình
        //public int Insert_LT(LOTRINH obj,  lt_stt, string ngaybd)
        //{
        //    int result = 0;
        //    int rs2;
        //    Connect_DB cn = new Connect_DB();
        //    object rs, rs1;
        //    string SQL1 = "SELECT MAX(maLT) FROM lotrinh";
        //    rs = cn.ExecuteScalar(SQL1);
        //    int max_maLT = Int32.Parse(rs.ToString()) + 10;
        //    string SQL3 = "SELECT MAX(STT_danhbo) FROM lotrinh";
        //    rs1 = cn.ExecuteScalar(SQL1);
        //    int max_STT = Int32.Parse(rs1.ToString()) + 10;
        //    string SQL = "INSERT INTO lotrinh(maLT, tenLT, ghichu, maCN, ID_NV_ghi, ID_NV_thu, STT, ngay_BD, STT_danhbo ) values(" +max_maLT + ", N'" + obj.tenLT + "'," +
        //                 " N'" + obj.ghichu + "', '" + obj.maCN + "', " + obj.ID_NV_ghi + ", " + obj.ID_NV_thu + ", '"+obj.STT+"', '"+ngaybd+"', "+max_STT+")";
        //    string SQL2 = "INSERT INTO lotrinh_stt VALUES('" + max_maLT + "', " + max_STT + ")";
        //    result = cn.updateData(SQL);
        //    rs2 = cn.updateData(SQL2);
        //    return result;
        //}
        //Lấy dữ liệu dgv
        public DataTable getData()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT   a.maLT, a.tenLT, b.hoten as NVGhi, d.hoten as NVThu , ID_NV_Thu, ID_NV_Ghi, STT as STT_in " + 
                         " , a.ghichu " +   "FROM LOTRINH a LEFT JOIN NHANVIEN b on a.ID_NV_Ghi = b.NV_ID  LEFT JOIN NHANVIEN d on a.ID_NV_thu = d.NV_ID order by a.maLT";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getPhanquyenLT()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT   a.maLT, a.tenLT" +
                         " , a.ghichu " + "FROM LOTRINH a LEFT JOIN NHANVIEN b on a.ID_NV_Ghi = b.NV_ID  LEFT JOIN NHANVIEN d on a.ID_NV_thu = d.NV_ID order by a.tenLT";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật lộ trình
        public int update_LT(LOTRINH obj)
        {
            int result = 0;
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE LOTRINH  SET tenLT = N'" + obj.tenLT + "', ghichu = N'" + obj.ghichu + "', "+
                         " ID_NV_ghi = " + obj.ID_NV_ghi + ", ID_NV_Thu = "+obj.ID_NV_thu+ ", STT = '" + obj.STT + "' WHERE maLT = '" + obj.maLT + "'";
            rs = cn.updateData(SQL);
            return result;
        }
        public DataTable getLT()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT maLT, tenLT FROM LOTRINH order by maLT";
            dt = cn.getData(SQL);
            return dt;
        }
        //Tìm tên lộ trình
        public string getTenLT(string ten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenLT FROM lotrinh WHERE tenLT = N'" + ten + "' ";
            obj = cn.ExecuteScalar(SQL);
            if(obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)obj;
            }
        }
        //Tìm stt danh bộ
        public int getSTT_DB(string STT)
        {
            object obj;
            Connect_DB cn= new Connect_DB();
            string SQL = "SELECT STT FROM lotrinh WHERE STT = "+STT+"";
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
        // get lo trinh theo nv ghi
        public DataTable getNV_LT(string  nv_id)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            if (nv_id == "System.Data.DataRowView")
            {
                string SQL = "SELECT   a.maLT, a.tenLT, b.hoten as NVGhi, d.hoten as NVThu, STT as STT_in  " +
                         " , a.ghichu " + "FROM LOTRINH a LEFT JOIN NHANVIEN b on a.ID_NV_Ghi = b.NV_ID  LEFT JOIN NHANVIEN d on a.ID_NV_thu = d.NV_ID";
                dt = cn.getData(SQL);
                return dt;
            }
            else
            {
                string SQL = "SELECT  a.maLT, a.tenLT, b.hoten as NVGhi, d.hoten as NVThu , a.ghichu , STT as STT_in " +
                             "FROM LOTRINH a LEFT JOIN NHANVIEN b on a.ID_NV_Ghi = b.NV_ID  LEFT JOIN NHANVIEN d on a.ID_NV_thu = d.NV_ID " +
                             "WHERE b.NV_ID= " + nv_id + " or d.NV_ID = "+nv_id+"";
                dt = cn.getData(SQL);
                return dt;

            }
        }
        public DataTable getKH_STT(string malt, string sx)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  madanhbo, ID_KH, hoten_KH , stt_ghi, stt_thu, malt, diachi, stt_ghi_old, stt_thu_old " + 
                          " FROM khachhang WHERE malt = '"+malt+"' order by '"+sx+"'";
            dt = cn.getData(SQL);
            return dt;
        }
        
        public void get_hoten(AutoCompleteStringCollection coll, string malt)
        {
            SqlDataReader obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  hoten_KH FROM khachhang WHERE malt = '" + malt + "' order by hoten_KH";
            obj = cn.excuteReader(SQL);
            if (obj.HasRows == true)
            {
                while (obj.Read())
                {
                    coll.Add(obj["hoten_KH"].ToString());
                }
            }
            obj.Close();
        }
        public DataTable getKH(string malt, string hoten)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  madanhbo, ID_KH, hoten_KH , malt , diachi, stt_ghi_old, stt_thu_old,  " +
                          " stt_ghi, stt_thu FROM khachhang WHERE malt = '" + malt + "' and hoten_KH like N'%"+hoten+"%'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_diachi(string malt, string diachi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  madanhbo, ID_KH, hoten_KH , malt , diachi, stt_ghi_old, stt_thu_old," +
                          " stt_ghi, stt_thu FROM khachhang WHERE malt = '" + malt + "' and diachi like N'%" + diachi + "%'";
            dt = cn.getData(SQL);
            return dt;
        }

        public DataTable getKH_SDT(string malt, string SDT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  madanhbo, ID_KH, hoten_KH , malt , diachi,stt_ghi_old, stt_thu_old, " +
                          " stt_ghi, stt_thu FROM khachhang WHERE malt = '" + malt + "' and SDT_KH like N'%" + SDT + "%'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_madanhbo(string malt, string madanhbo)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  madanhbo, ID_KH, hoten_KH , malt , diachi, stt_ghi_old, stt_thu_old," +
                          " stt_ghi, stt_thu FROM khachhang WHERE malt = '" + malt + "' and madanhbo like N'%" + madanhbo + "%'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_STTghi(string malt, string STT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  madanhbo, ID_KH, hoten_KH , malt , diachi, stt_ghi_old, stt_thu_old," +
                          " stt_ghi, stt_thu FROM khachhang WHERE malt = '" + malt + "' and STT_ghi like " + STT + " ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getKH_STTthu(string malt, string STT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  madanhbo, ID_KH, hoten_KH , malt , diachi, stt_ghi_old, stt_thu_old," +
                          " stt_ghi, stt_thu FROM khachhang WHERE malt = '" + malt + "' and STT_thu like " + STT + " ";
            dt = cn.getData(SQL);
            return dt;
        }
        // update stt ghi ++
        public int updateSTTghi_tang(string stt_old, string stt_new, string ID_KH, string malt)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE KHACHHANG SET stt_ghi = stt_ghi - 1 WHERE stt_ghi > "+stt_old+" and stt_ghi <= " +stt_new+ " and maLT = '"+malt+"'";
            string SQL1 = "UPDATE KHACHHANG SET stt_ghi = " + stt_new + ", stt_ghi_old = " + stt_old + " WHERE ID_KH = " + ID_KH + "";
            rs = cn.updateData(SQL);
            rs = cn.updateData(SQL1);
            return rs;
        }
        // update stt thu ++

        public int updateSTTthu_tang(string stt_old, string stt_new, string ID_KH, string malt)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE KHACHHANG SET stt_thu = stt_thu - 1 WHERE stt_thu > " + stt_old + " and stt_thu <= " + stt_new + " and maLT = '" + malt + "' ";
            string SQL1 = "UPDATE KHACHHANG SET stt_thu = " + stt_new + " , stt_thu_old = " + stt_old + " WHERE ID_KH = " + ID_KH + "";
            
            rs = cn.updateData(SQL);
            rs = cn.updateData(SQL1);
            return rs;
        }
        // update stt ghi --
        public int updateSTTghi_giam(string stt_old, string stt_new, string ID_KH, string maLT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE KHACHHANG SET stt_ghi = stt_ghi + 1 WHERE stt_ghi >= " + stt_new + " and stt_ghi < " + stt_old + " and maLT = '" + maLT + "'";
            string SQL1 = "UPDATE KHACHHANG SET stt_ghi = " + stt_new + ", stt_ghi_old = " + stt_old + " WHERE ID_KH = " + ID_KH + "";
            
            rs = cn.updateData(SQL);
            rs = cn.updateData(SQL1);
            return rs;
        }

        // update stt thu --
        public int updateSTTthu_giam(string stt_old, string stt_new, string ID_KH, string maLT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE KHACHHANG SET stt_thu = stt_thu + 1  WHERE stt_thu >= " + stt_new + " and stt_thu < " + stt_old + " and maLT = '" + maLT + "'";
            string SQL1 = "UPDATE KHACHHANG SET stt_thu = " + stt_new + ", stt_thu_old = " + stt_old + " WHERE ID_KH = " + ID_KH + "";
            
            rs = cn.updateData(SQL);
            rs = cn.updateData(SQL1);
            return rs;
        }
        // test xóa lộ trình
        public string Test_LT(string malt)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT a.maLT FROM LOTRINH a, KHACHHANG b WHERE a.maLT = b.maLT and a.maLT = '"+malt+"'";
            obj = cn.ExecuteScalar(SQL);
            if(obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)obj;
            }
        }
        // delete lotrinh
        public int Delete_LT(string maLT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE FROM LOTRINH WHERE maLT = '" + maLT + "'";
            rs = cn.updateData(SQL);
            return rs;
        }
        public DataTable getLT_Quyen()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT malt, tenLT FROM LOTRINH order by tenLT";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getNV_LNV(string ID_LNV)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT a.NV_ID, a.maNV + ' - ' + hoten hoten FROM NHANVIEN a, LOAINHANVIEN b, NHANVIEN_LNV c " +
                         " WHERE a.NV_ID = c.NV_ID and b.ID_LoaiNV = c.ID_LoaiNV and c.ID_LoaiNV = "+ID_LNV+" ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getNVGhi_LT(string ID_NV)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT maLT FROM LOTRINH_Ghi WHERE NV_ID = "+ID_NV+" order by malt";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getNVThu_LT(string ID_NV)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT maLT FROM LOTRINH_Thu WHERE NV_ID = " + ID_NV + " order by malt";
            dt = cn.getData(SQL);
            return dt;
        }
        public int insert_nvghi_lt(string NVGhi, string maLT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "insert into lotrinh_ghi(nv_id, malt) values(" + NVGhi + ", '" + maLT + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int insert_nvthu_lt(string NVThu, string maLT)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "insert into lotrinh_thu(nv_id, malt) values(" + NVThu + ", '" + maLT + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        public DataTable getDSLT_NV_ghi(string id_nv)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select malt from LOTRINH_GHI where nv_id = " + id_nv + "";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDSLT_NV_thu(string id_nv)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select malt from LOTRINH_Thu where nv_id = " + id_nv + "";
            dt = cn.getData(SQL);
            return dt;
        }
        public int deleteNVGhi_Lotrinh(string ID_NV, string maLT)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE LOTRINH_GHI WHERE nv_id = " + ID_NV + " and maLT = '" + maLT + "'";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int testmaLT_NVGhi(string malt, string nv)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT nv_id FROM LOTRINH_Ghi WHERE nv_id = " + nv + " and maLT = '" + malt + "'";
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
        public int testmaLT_NVThu(string malt, string nv)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT nv_id FROM LOTRINH_Thu WHERE nv_id = " + nv + " and maLT = '" + malt + "'";
            rs = cn.ExecuteScalar(SQL);
            if (rs == null)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(rs.ToString());
            }
        }
        public DataTable getdataPhanQuyenLT(string NV_ID)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT a.maLT, tenLT, b.nv_id as nvghi, c.nv_id as nvthu " +
                          "FROM LOTRINH a left  JOIN LOTRINH_GHI b on a.maLT = b.malt and b.nv_id = "+NV_ID+" " +
                          "left JOIN LOTRINH_THU c on a.maLT = c.malt and c.nv_id = "+NV_ID+" ";
            dt = cn.getData(SQL);
            return dt;
        }
        public int deleteLT_NVGhi(string malt, string nvghi)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE FROM LOTRINH_GHI WHERE maLT = '" + malt + "' and nv_id = " + nvghi + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int deleteLT_NVThu(string malt, string nvthu)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE FROM LOTRINH_Thu WHERE maLT = '" + malt + "' and nv_id = " + nvthu + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public DataTable getDSTHUGHI(string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select distinct manv + ' - -' +  a.hoten hotenghi ,   lotrinhthu.hoten " +
                         " from NHANVIEN a inner join LOTRINH_GHI b on a.nv_id = b.nv_id and b.malt = '"+malt+"' " +
                         "full join (select distinct  a.nv_id, manv + ' - ' + hoten hoten from nhanvien a, lotrinh_thu b where a.NV_ID = b.nv_id and b.malt = '"+malt+"') lotrinhthu "+
                         "on a.NV_ID = lotrinhthu.nv_id ";
            dt = cn.getData(SQL);
            return dt;
        }
    }
}
