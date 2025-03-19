using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Duong_BLL
    {
        int pageSize = 20;
        int totalPage;
        //Thêm đường
        public int Insert_Duong(DUONG obj)
        {
            int result;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO duong(tenduong, maphuong)  VALUES(N'" + obj.tenduong + "', '" + obj.maphuong + "')";
            result = cn.updateData(SQL);
            return result;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_Duong()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenduong, tenPhuong, a.maPhuong, idDuong FROM PHUONG a, DUONG b where a.maPhuong = b.maphuong";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật đường
        public int updateData_Duong(DUONG obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE DUONG SET tenduong = N'" + obj.tenduong + "', maphuong = '" + obj.maphuong + "' WHERE idDuong = " + obj.idDuong + "";
            result = cn.updateData(SQL);
            return result;
        }
        //Thêm đường phường
        public int Insert_DP(DUONG_PHUONG obj)
        {
            int result = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO DUONG_PHUONG( idduong, maPhuong, ghichu) VALUES (" + obj.idDuong + ", '" + obj.maPhuong + "', N'" + obj.ghichu + "')";
            result = cn.updateData(SQL);
            return result;
        }
        //Cập nhật đường-phường
        public int UpdateData_DP(DUONG_PHUONG obj)
        {
            int result;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE DUONG_PHUONG SET maphuong = '" + obj.maPhuong + "',idDuong =  " + obj.idDuong + ", ghichu = N'" + obj.ghichu + "' WHERE id = " + obj.id + "";
            result = cn.updateData(SQL);
            return result;
        }
        //Get id duong
        public int id()
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT MAX(idDuong) FROM DUONG";
            rs = cn.ExecuteScalar(SQL);
            if(rs== DBNull.Value)
            {
                return  0;
            }
            else
            {
                return Int32.Parse(rs.ToString());
            }
        }
        //Tìm theo tên phường
        public DataTable getData_Duong_Phuong( string maphuong)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenduong, tenPhuong, a.maPhuong, idDuong FROM PHUONG a, DUONG b where a.maPhuong = b.maphuong AND A.MAPHUONG = '"+maphuong+"'";
            dt = cn.getData(SQL);
            return dt;
        }
        //Tìm theo tên đường
        public DataTable getTenDuong( string tenduong)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenduong, tenPhuong, a.maPhuong, idDuong FROM PHUONG a, DUONG b where a.maPhuong = b.maphuong AND a.tenduong like N'%" + tenduong + "%'";
            dt = cn.getData(SQL);
            return dt;

        }
        //Get tên đường
        public string timtenDuong(string ten, string maphuong)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenduong FROM duong WHERE  tenduong = N'" + ten + "' AND  maphuong = '"+maphuong+"'";
            rs = cn.ExecuteScalar(SQL);
            if(rs == DBNull.Value)
            {
                return "";
            }
            else
            {
                return (string)rs;
            }
        }
        //get total pgae
        public int getTotalpage()
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT COUNT(*) FROM duong";
            obj = cn.ExecuteScalar(SQL);
            int tong = Int32.Parse(obj.ToString());
            totalPage = tong / pageSize;
            if (tong % pageSize > 0)
            {
                totalPage += 1;
            }
            return totalPage;

        }
        // test xóa đường
        public string getD_KH(string idduong)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT a.idduong FROM duong a, khachhang b WHERE a.idduong = b.idduong and a.idduong = " +idduong+ "";
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
        // test xóa đường bd_khachhang
        public string getD_BDKH(string idduong)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT a.idduong FROM duong a, bd_khachhang b WHERE a.idduong = b.idduong and a.idduong = " + idduong + "";
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
        // Xóa đường-phường
        public int Delete_DP(string id)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE FROM duong_phuong WHERE id = "+ id+" ";
            rs = cn.updateData(SQL);
            return rs;
        }
        // Xóa đường
        public int Delete_Duong(string idDuong)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "DELETE FROM duong WHERE idDuong = " + idDuong + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
    }
}
