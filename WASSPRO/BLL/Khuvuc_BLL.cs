using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Khuvuc_BLL
    {
        int pageSize = 20;
        int totalPage;
        //Thêm khu vực
        public int Insert_Khuvuc(KHUVUC obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO khuvuc( tenKV, maPhuong) values( N'" + obj.tenKV + "', '" + obj.maPhuong + "')";
            result = cn.updateData(SQL);
            return result;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_Khuvuc()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY tenphuong) STT, tenphuong, tenKV FROM KHUVUC a, PHUONG b WHERE a.maPhuong = b.maphuong ORDER BY tenphuong";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật khu vực
        public int update_Khuvuc(KHUVUC obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE KHUVUC SET tenKV = N'" + obj.tenKV + "' WHERE idKV = " + obj.idKV + "";
            result = cn.updateData(SQL);
            return result;
        }
        //Cập nhật khu vực
        public int update_Khuvuc_P(KHUVUC obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE KHUVUC SET maphuong = '" + obj.maPhuong + "', tenKV = N'" + obj.tenKV + "' WHERE idKV = " + obj.idKV + "";
            result = cn.updateData(SQL);
            return result;
        }
        //Tìm khu vực theo tên khu vực
        public DataTable getData_Khuvuc( string ten)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY tenphuong) STT, tenphuong, tenKV FROM KHUVUC a, PHUONG b WHERE a.maPhuong = b.maphuong and tenKV like N'%"+ten+"%' ORDER BY tenphuong";
            dt = cn.getData(SQL);
            return dt;
        }
        //Tìm khu vực theo phường
        public DataTable getData_KV_Phuong( string maphuong)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY tenphuong) STT, tenphuong, tenKV FROM KHUVUC a, PHUONG b WHERE a.maPhuong = b.maphuong and b.maphuong =  '" + maphuong + "' ORDER BY tenphuong";
            dt = cn.getData(SQL);
            return dt;
        }
        //Tìm tên khu vực
        public string get_TenKV(string tenKV, string maphuong)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  tenKV FROM KHUVUC  WHERE tenKV = N'"+tenKV+"' and maphuong = '"+maphuong+"'";
            rs = cn.ExecuteScalar(SQL);
            if(rs == DBNull.Value)
            {
                return null ;
            }
            else
            {
                return (string)rs;
            }

        }
        //Lấy dữ liệu khu vực
        public int get_totalpage()
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT COUNT(*) FROM khuvuc";
            obj = cn.ExecuteScalar(SQL);
            int tong = Int32.Parse(obj.ToString());
            totalPage = tong / pageSize;
            if (tong % pageSize > 0)
            {
                totalPage += 1;
            }
            return totalPage;
        }
    }
}
