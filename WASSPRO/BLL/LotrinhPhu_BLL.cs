using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class LotrinhPhu_BLL
    {
        //Thêm lộ trình phụ
        public int Insert_LT(LTPhu obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO LTPhu VALUES('" + obj.maLTPhu + "', N'" + obj.tenLTPhu + "', '" + obj.maLT + "', N'"+obj.ghichu+"',  " + obj.STT_LTPhu + ") ";
            MessageBox.Show(SQL);
            result = cn.updateData(SQL);
            return result;
        }
        //Cập nhật lộ trình
        public int update_LTP(LTPhu obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE LTPhu SET tenLTPhu = N'" + obj.tenLTPhu + "', maLT = '" + obj.maLT + "', STT_LTPhu = " + obj.STT_LTPhu + " WHERE maLTPhu = '" + obj.maLTPhu + "'";
            result = cn.updateData(SQL);
            return result;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_LTP()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY tenLTPhu) as STT, tenLT, a.maLT, tenLTPhu , STT_LTPhu, maLTPhu, b.ghichu  FROM LOTRINH a, LTPhu b WHERE a.maLT = b.maLT";
            dt = cn.getData(SQL);
            return dt;
        }
        //get Lotrinh phụ theo tên lộ trình
        public DataTable getLT_LTP(string ma)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY tenLTPhu) as STT, tenLT, a.maLT, tenLTPhu , STT_LTPhu, maLTPhu, b.ghichu " + 
                         " FROM LOTRINH a, LTPhu b WHERE a.maLT = b.maLT AND a.maLT = N'"+ma+"'";
            dt = cn.getData(SQL);
            return dt;
        }
        //get tên LTP
        public string get_tenLTP(string ten, string ma)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenLTPhu FROM ltphu WHERE tenLTPhu = N'"+ ten+"' and maLT = '"+ma+"' ";
            rs = cn.ExecuteScalar(SQL);
            if(rs == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)rs;
            }
        }
        // get STT lộ trình phụ
        public int get_STT(int stt)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT STT_LTPhu FROM ltphu WHERE STT_LTPhu = " +stt + "";
            rs = cn.ExecuteScalar(SQL);
            if (rs == null)
            {
                return 0;
            }
            else
            {
                int obj =  Int32.Parse(rs.ToString());
                return obj;
            }
        }
        // get mã LTP
        public string get_maLTP(string ma)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT maLTPhu FROM ltphu WHERE maLTPhu = N'" + ma + "'";
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
