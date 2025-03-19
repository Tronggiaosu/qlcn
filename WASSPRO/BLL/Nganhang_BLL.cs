using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Nganhang_BLL
    {
        //Thêm 
        public int Intsert_NH(DM_NGANHANG obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL1 = "SELECT MAX(NGANHANG_ID) FROM DM_NGANHANG";
            object id = cn.ExecuteScalar(SQL1);
            int maxid = Int32.Parse(id.ToString()) + 1;
            string SQL2 = "SELECT MAX(MADV) FROM DM_NGANHANG";
            object id1 = cn.ExecuteScalar(SQL2);
            int maxiddv = Int32.Parse(id1.ToString()) + 1;
            string SQL = "INSERT INTO DM_NGANHANG VALUES('" + obj.MA_NGANHANG + "', N'" + obj.TENNGANHANG + "', N'" + obj.LOAI + "', '" + maxiddv + "')";
            result = cn.updateData(SQL);
            return result;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_NH()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select * from DM_NGANHANG";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật 
        public int update_NH(DM_NGANHANG obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE DM_NGANHANG SET MA_NGANHANG = '" + obj.MA_NGANHANG + "', TENNGANHANG = N'" + obj.TENNGANHANG + "',LOAI = N'" + obj.LOAI + "', MADV = '" + obj.MADV + "' WHERE NGANHANG_ID = '" + obj.NGANHANG_ID + "'";
            result = cn.updateData(SQL);
            return result;
        }
        //get ten
        public string get_tenNH(string ten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT TENNGANHANG FROM DM_NGANHANG WHERE TENNGANHANG = N'" + ten + "'";
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
        public int deleteNH(string id)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE DM_NGANHANG where NGANHANG_ID = " + id + "";
            rs = cn.updateData(SQL);
            return rs;
        }
    }
}
