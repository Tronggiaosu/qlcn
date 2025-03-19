using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Phongban_BLL
    {
        //Thêm phòng ban
        public int Intsert_PB(DM_PHONGBAN obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL1 = "SELECT MAX(maPB) FROM DM_PHONGBAN";
            object id = cn.ExecuteScalar(SQL1);
            int maxid = Int32.Parse(id.ToString()) + 1;
            string SQL = "INSERT INTO DM_PHONGBAN VALUES('" + maxid + "',  N'" + obj.tenPB + "', N'" + obj.mota + "', '" + obj.maCN + "')";
            result = cn.updateData(SQL);
            return result;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_PB()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT a.maPB, a.tenPB, mota FROM DM_PHONGBAN a, CHINHANH b WHERE a.maCN = b.maCN";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật phòng ban
        public int update_PB(DM_PHONGBAN obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE DM_PHONGBAN SET tenPB = N'" + obj.tenPB + "',mota = N'" + obj.mota + "', maCN = '" + obj.maCN + "' WHERE maPB = '" + obj.maPB + "'";
            result = cn.updateData(SQL);
            return result;
        }
        //get ten phong ban
        public string get_tenPB(string ten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenPB FROM DM_PHONGBAN WHERE tenPB = N'" + ten + "'";
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
        public int deletePB(string id)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE DM_PHONGBAN where maPB = " + id + "";
            rs = cn.updateData(SQL);
            return rs;
        }
    }
}
