using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class DMTrangThai_BLL
    {
        //Thêm nguyên nhân
        public int Insert_DMTT(DMTRANGTHAI_YC obj)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO DMTRANGTHAI_YC(trangthai_yc) VALUES(N'" + obj.trangthai_yc + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        // Cập nhật nguyên nhân
        public int update_DMTT(DMTRANGTHAI_YC obj)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE DMTRANGTHAI_YC SET trangthai_yc  = N'" + obj.trangthai_yc + "' WHERE TTYC_ID = " + obj.TTYC_ID + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        // Lấy dữ liệu
        public DataTable getData_TT()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM dmtrangthai_yc";
            dt = cn.getData(SQL);
            return dt;
        }
        // get ten trạng thái yêu cầu
        public string getTen_TT(string ten)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT trangthai_yc FROM dmtrangthai_yc WHERE trangthai_yc = N'" + ten + "'";
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
