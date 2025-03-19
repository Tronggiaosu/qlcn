using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Quyen_BLL
    {
        public int Insert_Quyen(QUYEN q, QUYEN_MENU qn)
        {
            int rs;
            int result;
            object rs2;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO quyen(tenquyen) VALUES(N'" + q.tenquyen + "')";
            rs = cn.updateData(SQL);
            string SQL1 = "SELECT MAX(quyen_id) FROM quyen";
            rs2 = cn.ExecuteScalar(SQL1);
            int max_id = Int32.Parse(rs2.ToString());
            string SQL2 = "INSERT INTO QUYEN_MENU(quyen_id, ten_menu) VALUES(" + max_id+ ", N'" + qn.ten_menu + "')";
            result = cn.updateData(SQL2);
            return rs;
        }
        public int update_Quyen(QUYEN q)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE quyen SET tenquyen = N'" + q.tenquyen + "' WHERE quyen_id = "+q.quyen_id+"";
            rs = cn.updateData(SQL);
            return rs;
        }
        public DataTable getData_Quyen()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.quyen_id) as STT, a.quyen_id, tenquyen, ten_menu, id " + 
                         " FROM quyen a left join  quyen_menu b on  a.quyen_id = b.quyen_id order by tenquyen";
            dt = cn.getData(SQL);
            return dt;
        }
        public int update_QuyenMenu(QUYEN_MENU qn)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE quyen_menu SET quyen_id = " + qn.quyen_id + ", ten_menu = N'" + qn.ten_menu + "' WHERE id = " + qn.id + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        public string getTenquyen(string ten, string ten_menu)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenquyen FROM quyen a, quyen_menu b WHERE a.quyen_id = b.quyen_id and  tenquyen = N'" + ten + "' and ten_menu = N'"+ten_menu+"'";
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
        public DataTable getQuyen()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM quyen";
            dt = cn.getData(SQL);
            return dt;
        }
    }
}
