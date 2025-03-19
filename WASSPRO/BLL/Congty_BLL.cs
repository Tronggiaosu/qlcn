using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class Congty_BLL
    {

        //Thêm công ty
        public int Insert_CTY(CONGTY obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO CONGTY VALUES('" + obj.maCTY + "', N'" + obj.tenCTY + "',N'" + obj.DC_CTY + "', '" + obj.SDT_CTY + "', '" + obj.MST_CTY + "', '" + obj.soFAX_CTY + "')";
            result = cn.updateData(SQL);
            return result;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_CTY()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM CONGTY";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật công ty
        public int update_CTY(CONGTY obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CONGTY SET tenCTY = N'" + obj.tenCTY + "', DC_CTY = N'" + obj.DC_CTY + "',SDT_CTY ='" + obj.SDT_CTY + "' " +
                         "MST_CTY = '" + obj.MST_CTY + "', soFAX_CTY = '" + obj.soFAX_CTY + "' WHERE maCTY = '" + obj.maCTY + "'";
            result = cn.updateData(SQL);
            return result;
        }
    }
}
