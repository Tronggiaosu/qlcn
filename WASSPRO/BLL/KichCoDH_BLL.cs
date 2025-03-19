using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class KichCoDH_BLL
    {
        // Thêm kích cỡ đồng hồ
        public int Insert_Kichco(KICHCODH obj)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL1 = "SELECT MAX(maKC) FROM kichcoDH";
            object id = cn.ExecuteScalar(SQL1);
            int max_id = Int32.Parse(id.ToString()) + 1;
            string SQL = "INSERT INTO kichcoDH(maKC, kichco, chisotoida) VALUES("+max_id+", N'"+obj.KichCo+"', "+obj.ChiSoToiDa+")";
            rs = cn.updateData(SQL);
            return rs;
        }
        //get dữ liệu dgv
        public DataTable getData_Kichco()
        {
            DataTable dt = new DataTable();
            Connect_DB CN = new Connect_DB();
            string SQL = "SELECT * FROM kichcoDH";
            dt = CN.getData(SQL);
            return dt;
        }
        // get kích cỡ
        public string getKichco(string kichco)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT kichco FROM kichcoDH WHERE kichco = N'" + kichco + "'";
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
        // update kích cỡ
        public int updateKichco(KICHCODH obj)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE kichcoDH SET kichco = '" + obj.KichCo + "', chisotoida = " + obj.ChiSoToiDa + " WHERE maKC = " + obj.MaKC + "";
            rs = cn.updateData(SQL);
            return rs;
        }
    }
}
