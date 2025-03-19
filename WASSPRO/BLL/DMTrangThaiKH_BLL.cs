using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class DMTrangThaiKH_BLL
    {
        //Thêm  trạng thái
        public int Insert_TT(DANHMUCTRANGTHAI tt)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO DANHMUCTRANGTHAI(tenTT) VALUES(N'" + tt.tenTT + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        //update trạng thái
        public int update_TT(DANHMUCTRANGTHAI tt)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE DANHMUCTRANGTHAI SET tenTT = N'" + tt.tenTT + "' WHERE maTT = " + tt.maTT + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        // get dgv danh mục trạng thái  
        public DataTable getDataDM_TT()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM DANHMUCTRANGTHAI order by maTT";
            dt = cn.getData(SQL);
            return dt;
        }
        // kiểm tra tên trạng thái
        public string getTen_TT(string ten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenTT from DANHMUCTRANGTHAI where tenTT = N'" + ten + " '";
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
