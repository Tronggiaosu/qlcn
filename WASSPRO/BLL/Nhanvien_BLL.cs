using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Nhanvien_BLL
    {
        //Thêm nhân viên
        public int Insert_NV(NHANVIEN obj)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO nhanvien(maNV, hoten, ngaysinh, gioitinh, quoctich, soCMND, ngaycap, noicap, diachithuongtru, diachitamtru, " +
                         " masothue, SDT_NV, SDT_codinh,ID_loaiNV, maPB )  VALUES("+obj.maNV+", N'"+obj.hoten+"', '"+obj.ngaysinh+"', "+obj.gioitinh+",  N'"+obj.quoctich+"', '"+obj.soCMND+"' " +
                         "'"+obj.ngaycap+"', N'"+obj.noicap+"',N'"+obj.diachithuongtru+"', N'"+obj.diachitamtru+"', '"+obj.masothue+"', '"+obj.SDT_NV+"' "+ 
                         " '"+obj.SDT_codinh+"', "+obj.ID_LoaiNV+", '"+obj.maPB+"')";
            MessageBox.Show(SQL);
            rs = cn.updateData(SQL);
            return rs;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_NV()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.maNV) as STT, NV_ID,  maNV, hoten, ngaysinh, (case when gioitinh = 1 then 'nam' else 'nữ' end) as gioitinh, quoctich, soCMND, ngaycap, noicap, diachithuongtru, diachitamtru , masothue, SDT_NV, " +
                         "SDT_codinh,tenloai,tenPB FROM nhanvien a, loainhanvien b, phongban c WHERE a.ID_loaiNV = b.ID_loaiNV and a.maPB = c.maPB order by maNV  ";
            dt = cn.getData(SQL);
            return dt;
        } 
        //Cập nhật nhân viên
        public int update_NV(NHANVIEN obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE nhanvien SET maNV = '"+obj.maNV+"', hoten = N'"+obj.hoten+"', ngaysinh = '"+obj.ngaysinh+"', gioitinh = "+obj.gioitinh+", " +
                         " quoctich = N'"+obj.quoctich+"',soCMND = '"+obj.soCMND+"', ngaycap = '"+obj.ngaycap+"', noicap = N'"+obj.noicap+"' " +
                         "diachithuongtru = N'"+obj.diachithuongtru+"', diachitamtru = N'"+obj.diachitamtru+"', masothue= '"+obj.masothue+"'" +
                         "SDT_NV = '"+obj.SDT_NV+"', SDT_codinh = '"+obj.SDT_codinh+"', ID_loaiNV = "+obj.ID_LoaiNV+", maPB = '"+obj.maPB+"' WHERE NV_ID = "+obj.NV_ID+"";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Tìm nhân viên theo mã, tên
        //Lấy dữ liệu cbo
        public DataTable getNV()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT * FROM nhanvien";
            dt = cn.getData(SQL);
            return dt;
        }
        //Lấy dữ liệu nhân viên ghi
        public DataTable getNV_ghi()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT a.NV_ID, a.hoten FROM nhanvien a, loainhanvien b , NHANVIEN_LNV c " +
                         " WHERE a.NV_ID = c.NV_ID and b.ID_LoaiNV = c.ID_LoaiNV and b.tenloai IN (N'Ghi chỉ số nước', N'Nhân viên ghi', N'Ghi nước', N'Nhân viên ghi nước') ";
            dt = cn.getData(SQL);
            return dt;
        }
        //Lấy dữ liệu nhân viên thu
        public DataTable get_NVThu()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT NV_ID, hoten FROM NHANVIEN ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable get_NVThu_LT(string malt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select a.NV_ID, maNV + ' - ' + hoten hoten from NHANVIEN a, LOTRINH_THU b where a.NV_ID = b.nv_id and malt = '"+malt+"' ";
            dt = cn.getData(SQL);
            return dt;
        }
        //get soCMND
        public string get_CMND(string CMND)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT soCMND FROM NHANVIEN WHERE soCMND = '"+CMND+"'";
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
        //get maNV
        public string get_maNV(string maNV)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT maNV FROM NHANVIEN WHERE maNV = '" + maNV + "'";
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
        // get SDT
        public string get_SDT(string SDT)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT SDT_NV FROM NHANVIEN WHERE SDT_NV = '" +SDT + "'";
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
        public DataTable get_NVThu_APP()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " SELECT a.maNV, a.maNV + ' - ' +  a.hoten hoten FROM nhanvien a, loainhanvien b , NHANVIEN_LNV c " +
                         " WHERE a.NV_ID = c.NV_ID and b.ID_LoaiNV = c.ID_LoaiNV and b.tenloai IN (N'Thu tiền nước', N'Nhân viên thu', N'Thu tiền') ";
            dt = cn.getData(SQL);
            return dt;
        }
    }
}
