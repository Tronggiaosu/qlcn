using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class Chinhanh_BLL
    {
        //Thêm chi nhánh
        //public int Insert_CN(CHINHANH obj)
        //{
        //    int rs = 0;
        //    Connect_DB cn = new Connect_DB();
        //    string SQL = "INSERT INTO CHINHANH VALUES('" + obj.maCN + "', N'" + obj.tenCN + "', '" + obj.SDT_CN + "', N'" + obj.DC_CN + "' " +
        //                 "'" + obj.MST + "', '" + obj.soFAX_CN + "', " + obj.tuychonin + ", '" + obj.maCTY + "')";
        //    rs = cn.updateData(SQL);
        //    return rs;
        //}
        //Lấy dữ liệu dgv
        public DataTable getData_CN()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT maCN, tenCN FROM CHINHANH";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật chi nhánh
        public int update_CN(CHINHANH obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE CHINHANH VALUES ( tenCN = '" + obj.tenCN + "', SDT_CN = '" + obj.SDT_CN + "', MST = '" + obj.MST + "', soFAX = '" + obj.soFAX_CN + "' " +
                         "maCTY = '" + obj.maCTY + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
    }
}
