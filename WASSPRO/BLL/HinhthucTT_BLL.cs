using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class HinhthucTT_BLL
    {
        //Thêm hình thức thanh toán
        public int Insert_HT(HINHTHUCTHANHTOAN obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO HINHTHUCTHANHTOAN VALUES(" + obj.maHTTT + ", N'" + obj.tenHTTT + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_HT()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM HINHTHUCTHANHTOAN";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật HTTT
        public int update_HTT(HINHTHUCTHANHTOAN obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE HINHTHUCTHANHTOAN SET tenHTTT = N'" + obj.tenHTTT + "' WHERE maHTTT = " + obj.maHTTT + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Tìm tên hình thức
        public string getTen(string ten)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenHTTT FROM hinhthucthanhtoan WHERE tenHTTT = N'"+ten+"'";
            rs = cn.ExecuteScalar(SQL);
            if (rs == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)rs;
            }
            
        }
    }
}
