using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class BanggiaDM_BLL
    {
        //Thêm bảng giá định mức
        public int Insert_giaDM(BANGGIA_DM obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO BANGGIA_DM(dinhmuc_id, dongia, dongia0VAT,tum3, denm3, diengiai )" +
                         "VALUES(" + obj.dongia + ", " + obj.dongia0V + ", " + obj.tum3 + ", " + obj.denm3 + ", N'" + obj.diengiai + "')";
            rs = cn.updateData(SQL);
            return rs;
        }
        //get data dgv
        public DataTable get_DataBG()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY dinhmuc_id) as STT,dinhmuc_id, a.maDT, tenDT, dongia, dongia0V , " +
                         "tum3, denm3, giaphi, diengiai FROM BANGGIA_DM a, DOITUONGSUDUNG b , GiaBVMT c " +
                         "WHERE a.maDT = b.maDT and b.ma_giaBVMT = c.ma_giaBVMT";
            dt = cn.getData(SQL);
            return dt;
        }
    }
}
