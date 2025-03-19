using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class Loaichungtu_BLL
    {
        //Thêm chứng từ
        public int Insert_loaiCT(LOAICHUNGTU obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO LOAICHUNGTU VALUES ('" + obj.maloai + "', N'" + obj.tenloai + "') ";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_loaiCT()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY tenloai) as STT,  * FROM loaichungtu ORDER BY tenloai";
            dt = cn.getData(SQL);
            return dt;
        }
        // Cập nhật loại chứng từ
        public int update_loaiCT(LOAICHUNGTU obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE LOAICHUNGTU SET tenloai = N'" + obj.tenloai + "' WHERE maloai = '" + obj.maloai + "'";
            rs = cn.updateData(SQL);
            return rs;
        }
        // get tên loại chứng từ
        public string getTen_LCT(string ten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenloai FROM loaichungtu WHERE tenloai = N'" + ten + "'";
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
        // get mã loại chứng từ
        public string getma_LCT(string ten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenloai FROM loaichungtu WHERE maloai = '" + ten + "'";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)obj;
            }
        }
        //test loại chứng từ
        public string getLCT_CT(string maloai)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenloai FROM loaichungtu a, chungtu b WHERE a.maloai = b.maloai AND a.maloai = '"+maloai+"' ";
            obj = cn.ExecuteScalar(SQL);
            if (obj == DBNull.Value)
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
