using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class Phuong_BLL
    {

        int pageSize = 20;
        //Thêm phường
        public int Insert_Phuong(PHUONG obj)
        {
            int result;
            Connect_DB cn = new Connect_DB();
            string SQL1 = "SELECT MAX(maPhuong) FROM phuong";
            object id = cn.ExecuteScalar(SQL1);
            int max_id = Int32.Parse(id.ToString()) + 1;
            string SQL = "INSERT INTO PHUONG(maPhuong, tenPhuong, maQuan) VALUES('"+ max_id +"', N'" + obj.tenPhuong + "', '" + obj.maQuan + "' )";
            result = cn.updateData(SQL);
            return result;
        }
        //Lấy dữ liệu
        public DataTable data_Phuong()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM PHUONG";
            dt = cn.getData(SQL);
            return dt;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_Phuong()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT b.tenQuan, a.tenPhuong, maPhuong FROM phuong a, quan b " +
                         " WHERE a.maquan = b.maquan order by a.tenphuong";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật phường
        public int Update_Phuong(PHUONG obj)
        {
            int result;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE PHUONG SET tenPhuong = N'" + obj.tenPhuong + "' WHERE maphuong = '" + obj.maPhuong + "'";
            result = cn.updateData(SQL);
            return result;
        }
        //Cập nhật phường quận
        public int UpdatePhuong_Quan(PHUONG obj)
        {
            int result;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE PHUONG SET tenPhuong = N'" + obj.tenPhuong + "',maQuan = '" + obj.maQuan + "' WHERE maphuong = '" + obj.maPhuong + "'";
            result = cn.updateData(SQL);
            return result;
        }
        //Tìm phường theo quận
        public DataTable getPhuong_Quan(int pageNumber, string maquan)
        {
            int PreviousPageOffSet = (pageNumber - 1) * pageSize;
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT TOP " + pageSize + " ROW_NUMBER() OVER(ORDER BY a.tenPhuong ) as STT ,  b.tenQuan, a.tenPhuong, maPhuong FROM phuong a, quan b " +
                         " WHERE a.maquan = b.maquan and b.maquan = N'"+maquan+"'  order by a.tenphuong";
            string SQL2 = "SELECT TOP " + pageSize + " ROW_NUMBER() OVER(ORDER BY a.tenPhuong ) as STT , b.maQuan, b.tenQuan, a.tenPhuong FROM phuong a, quan b " +
                         " WHERE a.maphuong = b.maphuong  and b.maquan = N'" + maquan + "' AND a.tenPhuong NOT IN " +
                         "(SELECT TOP " + PreviousPageOffSet + " b.maQuan, b.tenQuan, a.tenPhuong FROM phuong a, quan b " +
                         " WHERE a.maquan = b.maquan  and b.maquan = N'" + maquan + "') order by a.tenphuong";
            if (pageNumber == 1)
            {
                dt = cn.getData(SQL);
                return dt;
            }
            else
            {
                dt = cn.getData(SQL2);
                return dt;
            }
        }
        // kiểm tra phường-quận
        public string getPhuong_Quan(string tenP, string maQ)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenPhuong FROM phuong WHERE tenPhuong = N'"+tenP+"' AND  maQuan = '"+ maQ+"'";
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

    }
}
