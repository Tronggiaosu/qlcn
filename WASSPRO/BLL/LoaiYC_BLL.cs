using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class LoaiYC_BLL
    {
        //Thêm loại yêu cầu
        public int Insert_LYC(LOAIYEUCAU obj)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO loaiyeucau VALUES('" + obj.maloai_yc + "', N'" + obj.tenloai_yc + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        // lấy dữ liệu dgv
        public DataTable getLYC()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY tenloai_yc) as STT,  * FROM loaiyeucau ORDER BY tenloai_yc";
            dt = cn.getData(SQL);
            return dt;
        }
        // update loại yêu cầu
        public int update_LYC(LOAIYEUCAU obj)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE LOAIYEUCAU SET tenloai_yc = N'" + obj.tenloai_yc + "' WHERE maloai_yc = '" + obj.maloai_yc + "'";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Kiểm tra tên loại yêu cầu
        public string getten_LYC(string ten)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenloai_yc FROM loaiyeucau WHERE tenloai_yc = N'" + ten + "'";
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
        //Kiểm tra mã loại yêu cầu
        public string getma_LYC(string ma)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenloai_yc FROM loaiyeucau WHERE maloai_yc = '" + ma + "'";
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
        //Kiểm tra mã loại yêu cầu- yêu cầu
        public string getLYC_YC(string ma)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenloai_yc FROM loaiyeucau a, yeucau b WHERE a.maloai_yc = b.maloai_yc and a.maloai_yc = '" + ma + "'";
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
