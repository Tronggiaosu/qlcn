using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class LyDo_BLL
    {
        public DataTable getLyDo()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select * from DM_LYDO ";
            dt = cn.getData(SQL);
            return dt;
        }
        public int insertLydo(string ten)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO DM_LYDO(ten_lydo) values(N'" + ten + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int updatelydo(string ten, string id)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "update dm_lydo set ten_lydo = N'"+ten+"' where id_lydo = " + id + "";
            rs = cn.updateData(SQL);
            return rs;
        } 
        public int deletelydo(string id)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE DM_LYDO where id_lydo = " + id + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        public string testlydo(string id)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT distinct ten_lydo FROM YEUCAU a, DM_LYDO b where a.lydo_id = b.id_lydo and b.id_lydo = " + id + "";
            obj = cn.ExecuteScalar(SQL);
            if(obj == DBNull.Value || obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
    }
}
