using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class NguoiDung_BLL
    {
        public int insert_nguoidung(NGUOIDUNG user )
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO nguoidung(ma_nd, manv, pass) VALUES('"+user.ma_nd+"', '"+user.manv+"', '"+user.pass+"')";
            MessageBox.Show(SQL);
            rs = cn.updateData(SQL);
            return rs;
        }
        public int insertND_Quyen(NGUOIDUNG_QUYEN nd_q)
        {
            int rs;
            object rs1;
            Connect_DB cn = new Connect_DB();
            string SQL1 = "SELECT MAX(nguoidung_id) FROM nguoidung";
            rs1 = cn.ExecuteScalar(SQL1);
            int max_ID = Int32.Parse(rs1.ToString());
            string SQL = "INSERT INTO NGUOIDUNG_QUYEN(nguoidung_id, quyen_id) VALUES(" + max_ID + ", " + nd_q.quyen_id + ")";
            MessageBox.Show(SQL);
            rs = cn.updateData(SQL);
            return rs;
        }
        public int update_nguoidung(NGUOIDUNG user)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE nguoidung SET ma_nd = '" + user.ma_nd + "', manv = '" + user.manv + "' pass ='" + user.pass + "' WHERE nguoidung_id = "+user.nguoidung_id+")";
            rs = cn.updateData(SQL);
            return rs;
        }
        public DataTable getData_Nguoidung()
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() OVER(ORDER BY a.nguoidung_id) as STT,  a.nguoidung_id, a.manv, hoten, tenquyen, ma_nd, pass " +
                         " FROM NGUOIDUNG a, NHANVIEN b, QUYEN c, NGUOIDUNG_QUYEN d " +
                         "WHERE a.manv = b.maNV and a.nguoidung_id = d.nguoidung_id and d.quyen_id = c.quyen_id";
            dt = cn.getData(SQL);
            return dt;
        }
        public int updateND_Quyen(NGUOIDUNG_QUYEN nd_q)
        {
            int rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "UPDATE NGUOIDUNG_QUYEN SET nguoidung_id = "+nd_q.nguoidung_id+", quyen_id = "+nd_q.quyen_id+" WHERE id = "+nd_q.id+"";
            rs = cn.updateData(SQL);
            return rs;
        }
        public string getmaND(string mand)
        {
            object rs;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ma_nd FROM nguoidung WHERE ma_nd = '" + mand + "'";
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
    }
}
