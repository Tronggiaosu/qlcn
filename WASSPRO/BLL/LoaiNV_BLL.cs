using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class LoaiNV_BLL
    {
        //Thêm loại nhân viên
        public int Insert_LNV(LOAINHANVIEN obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO loainhanvien(tenloai) VALUES(N'" +obj.Tenloai+"')";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_LNV()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM loainhanvien";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật loại nhân viên
        public int update_LNV(LOAINHANVIEN obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE loainhanvien SET tenloai = N'"+ obj.Tenloai+"' WHERE ID_loaiNV = "+obj.ID_LoaiNV+"";
            rs = cn.updateData(SQL);
            return rs;
        }
        // get tên loại nhân viên
        public string getTen_LNV(string ten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenloai FROM loainhanvien WHERE tenloai = N'" + ten + "'";
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
        // Nhân viên
        public DataTable getData_NV()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM nhanvien";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getLNV_Thughi()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM loainhanvien WHERE ID_LoaiNV = 7 or ID_LoaiNV = 4";
            dt = cn.getData(SQL);
            return dt;
        }
    }
}
