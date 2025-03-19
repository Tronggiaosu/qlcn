using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLCongNo.BLL
{
    class DoituongSD_BLL
    {
        //Thêm đối tượng sử dụng
        public int Insert_DT(DOITUONGSUDUNG obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO DOITUONGSUDUNG VALUES ('" + obj.maDT + "', N'" + obj.tenDT + "', '" + obj.ma_giaBVMT+ "', '"+obj.theoNK+" ')";
            rs = cn.updateData(SQL);
            return rs;
        }
        //Lấy dữ liệu dgv
        public DataTable getData_DT()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.maDT) as STT, maDT, tenDT, a.ma_giaBVMT, b.giaphi, case when theoNK = 'true' then N'có' else N'không' end as theoNK" + 
                         " FROM doituongsudung a left join giaBVMT b on a.ma_giaBVMT = b.ma_giaBVMT";
            dt = cn.getData(SQL);
            return dt;
        }
        //Cập nhật đối tượng sử dụng
        public int update_DT(DOITUONGSUDUNG obj)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE DOITUONGSUDUNG SET tenDT = N'" + obj.tenDT + "', ma_giaBVMT = '" + obj.ma_giaBVMT + "', theoNK = '"+obj.theoNK+"'  WHERE maDT = '" + obj.maDT + "'";
            rs = cn.updateData(SQL);
            return rs;
        }
        //get tên đối tượng
        public string getTen_DT(string ten)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT tenDT FROM doituongsudung WHERE tenDT = N'" + ten + "'";
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

        //get mã đối tượng
        public string getma_DT(string ma)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT maDT FROM doituongsudung WHERE maDT = N'" + ma + "'";
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
