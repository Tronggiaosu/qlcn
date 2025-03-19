using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Nganhghe_BLL
    {
        int pageSize = 20;
        int totalpage;
        //Thêm ngành nghề
        public int Insert_NN(NGANHNGHE obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL1 = "SELECT MAX(ma_NN) FROM nganhnghe";
            Object id = cn.ExecuteScalar(SQL1);
            int max_ID = Int32.Parse(id.ToString()) + 1;
            string SQL = "INSERT INTO NGANHNGHE(MA_NN, Ten_NN) VALUES("+max_ID+", N'" + obj.Ten_NN + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_NN()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM NGANHNGHE";
            dt = cn.getData(SQL);
            return dt;
        }
        //Tìm theo tên ngành nghề
        public DataTable getData_NN(int pageNumber, string ten)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT  * FROM nganhnghe WHERE ten_NN like '%"+ten+"%' ";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật ngành nghề
        public int update_NN(NGANHNGHE obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE NGANHNGHE SET ten_NN = N'" + obj.Ten_NN + "' WHERE ma_NN = " + obj.MA_NN + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Tìm tên ngành nghề
        public string getTen_NN(string ten)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ten_NN FROM NGANHNGHE WHERE ten_NN = N'"+ten+"'";
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
