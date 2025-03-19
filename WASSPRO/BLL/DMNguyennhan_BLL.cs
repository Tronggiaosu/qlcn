using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class DMNguyennhan_BLL
    {
        //Thêm nguyên nhân
        public int Insert_NN(DMNGUYENNHAN obj)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO DMNGUYENNHAN(tennguyennhan) VALUES(N'" + obj.tennguyennhan + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        // Cập nhật nguyên nhân
        public int update_NN(DMNGUYENNHAN obj)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE dmnguyennhan SET tennguyennhan = N'" + obj.tennguyennhan + "' WHERE id_nguyennhan = " + obj.id_nguyennhan + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        // Lấy dữ liệu
        public DataTable getData_NN()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM dmnguyennhan order by tennguyennhan";
            dt = cn.getData(SQL);
            return dt;
        }

        // get ten nguyên nhân
        public string getTen_NN(string ten)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tennguyennhan FROM dmnguyennhan WHERE tennguyennhan = N'" + ten + "'";
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
