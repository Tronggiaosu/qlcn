using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class Tinh_BLL
    {
        //Thêm tỉnh
        public int Insert_Tinh(TINH obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO TINH VALUES('" + obj.maTinh + "',N '" + obj.tenTinh + "')";
            result = cn.updateData(SQL);
            return result;
        }
        //Cập nhật tỉnh 
        public int update_Tinh(TINH obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE TINH SET maTinh = '" + obj.maTinh + "',tenTinh = N '" + obj.tenTinh + "' WHERE maTinh = '" + obj.maTinh + "'";
            result = cn.updateData(SQL);
            return result;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_Tinh()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM TINH";
            dt = cn.getData(SQL);
            return dt;
        }

    }
}
