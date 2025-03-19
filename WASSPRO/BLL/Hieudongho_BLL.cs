using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Hieudongho_BLL
    {
        //Thêm hiệu đồng hồ
        public int Insert_HDH(HIEUDONGHO obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL1 = "SELECT MAX(mahieu) FROM HIEUDONGHO";
            Object id = cn.ExecuteScalar(SQL1);
            int max_ID = Int32.Parse(id.ToString()) + 1;
            string SQL = "INSERT INTO HIEUDONGHO VALUES( "+max_ID +", N'" + obj.tenhieu + "', " + obj.hankiemdinh + ")";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_HDH()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM HIEUDONGHO";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật hiệu đồng hồ
        public int update_HDH(HIEUDONGHO obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE HIEUDONGHO SET tenhieu = N'" + obj.tenhieu + "', hankiemdinh = " + obj.hankiemdinh + " WHERE mahieu = " + obj.mahieu + "";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Tìm tên hiệu đồng hồ
        public string getTen_HDH(string ten, string hankiemdinh)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenhieu FROM hieudongho WHERE tenhieu = N'" + ten + "' and hankiemdinh = "+hankiemdinh+"";
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
        // Kiểm tra hiệu đồng hồ, khách hàng
        public string getDH_KH(string mahieu)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenhieu FROM khachhang a, hieudongho b WHERE a.maDH = b.mahieu AND b.mahieu = "+mahieu+"";
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
        // Kiểm tra hiệu đồng hồ, khách hàng bd
        public string getDH_KHBD(string mahieu)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenhieu FROM bd_khachhang a, hieudongho b WHERE a.maDH = b.mahieu AND b.mahieu = " + mahieu + "";
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
        // Xóa hiệu đồng hồ
        public int deleteHDH(string mahieu)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE FROM hieudongho WHERE mahieu = " + mahieu + "";
            rs = cn.updateData(SQL);
            return rs;

        }
    }
}
