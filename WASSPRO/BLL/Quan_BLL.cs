using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class Quan_BLL
    {
        //Thêm
        public int Insert_Quan(QUAN obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO QUAN VALUES ('" + obj.maQuan + "', N'" + obj.tenQuan + "', '" + obj.maTinh + "')";
            result = cn.updateData(SQL);
            return result;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_Quan()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY maQuan) as STT, tenQuan, maQuan, tenTinh  FROM quan a, tinh b WHERE a.maTinh = b.maTinh" ;
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật dữ liệu quận
        public int update_Quan(QUAN obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE QUAN SET tenQuan = '" + obj.tenQuan + "', maQuan = '" + obj.maQuan + "' WHERE maQuan = '" + obj.maQuan + "'";
            result = cn.updateData(SQL);
            return result;
        }
        // get mã quận
        public string getmaQuan(string ten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT maQuan FROM quan WHERE tenQuan = N'" + ten + "'";
            obj = cn.ExecuteScalar(SQL);
            if(obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)obj;
            }
        }  // get mã quận
        public string gettenQuan(string ma)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT maQuan FROM quan WHERE maQuan ='" + ma + "'";
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
    }
}
