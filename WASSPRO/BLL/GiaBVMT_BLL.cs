using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class GiaBVMT_BLL
    {
        //Thêm giá BVMT
        public int Insert_GiaBVMT(GiaBVMT obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO GiaBVMT VALUES('" + obj.ma_giaBVMT + "', " + obj.giaphi + ", '" + obj.ngaytao + "', '" + obj.ngaycapnhat + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_GiaBVMT()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY ma_giabvmt) as STT, * FROM GiaBVMT";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật giá BVMT
        public int update_GiaBVMT(GiaBVMT obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE GiaBVMT SET giaphi = " + obj.giaphi + ", ngaycapnhat = '" + obj.ngaycapnhat + "' WHERE ma_giaBVMT = '" + obj.ma_giaBVMT + "'";
            rs = cn.updateData(SQL);
            return rs;
        }
        // get mã BVMT
        public string get_maBVMT(string ma)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ma_giaBVMT FROM giaBVMT WHERE ma_giaBVMT = '"+ma+"'";
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
