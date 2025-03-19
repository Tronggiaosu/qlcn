using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLCongNo.BLL
{
    class GachNo_BLL
    {
        public void dongbo_invoice(string ID_CT)
        {
            TracuuHD_BLL tc = new TracuuHD_BLL();
            ChungTu_BLL ct = new ChungTu_BLL();
            SqlDataReader dr = tc.GetAcc_Service();
            int sl = ct.gettrangthai_CT(ID_CT);
            string user = "";
            string pss = "";
            string kq = "";
            while (dr.Read())
            {
                user = dr["acc_service"].ToString();
                pss = dr["pass_service"].ToString();
            }
            dr.Close();
            if (sl == 0)
            {
                MessageBox.Show("Chứng từ này đã được đồng bộ, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn đồng bộ hóa đơn điện tử?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DataTable DSFkey = ct.getFkey(ID_CT);
                    string fkey = null;
                    for (int i = 0; i < DSFkey.Rows.Count; i++)
                    {
                        string ds = DSFkey.Rows[i]["ID_HD"].ToString();
                        if (fkey == null)
                        {
                            fkey = ds;
                        }
                        else
                        {
                            fkey = fkey + "_" + ds;
                        }
                    }
                    Business.BusinessService ww = new Business.BusinessService();
                    kq = ww.confirmPaymentFkey(fkey, user, pss);
                    if (kq == "OK:" || kq == "ERR:13")
                    {
                        ct.updateTrangthaiCT_HD(ID_CT);
                        MessageBox.Show("Đồng bộ thành công!");
                    }
                    else
                    {
                        if (kq == "ERR:1")
                        {
                            MessageBox.Show("Tài khoản đăng nhập sai, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (kq == "ERR:6")
                        {
                            MessageBox.Show("Hóa đơn chưa phát hành, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (kq == "ERR:7")
                        {
                            MessageBox.Show("Không thể đồng bộ hóa đơn, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    int sl_db = ct.gettrangthai_CT(ID_CT);
                    if (sl_db == 0)
                    {
                        ct.updatetrangthai_CT(ID_CT);
                    }
                }
            }
        }
        public DataTable getHoadonGachNo(string maNV, string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select a.ID_KH, hoten_KH, diachi, id_chisonuoc , tienhang_app, a.madanhbo, luongtieuthu, tienbvmt_app, tienthue_app, thanhtien_app " +
                         " from  KHACHHANG a, CHISONUOC b where a.ID_KH = b.ID_KH and thutien_app <> 0 and ID_kyghi = '" + kyghi + "' and NVGhi = '" + maNV + "' and ID_chisonuoc not in (select ID_Chisonuoc from CHUNGTU_CHISONUOC)";
            dt = cn.getData(SQL);
            return dt;
        }
        public string getkyghinuoc()
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ID_Kyghi from DANHMUCKYGHI where ghinuoc = 1";
            obj = cn.ExecuteScalar(SQL);
            return obj.ToString();
        }
        public int InsertCT_HD(string SOCT, string kyghi, string maNV)
        {
            int rs = 0;
            Connect_DB cn = new Connect_DB();
            string SQL = "INSERT INTO CHUNGTU_CHISONUOC (ID_CT, ID_Chisonuoc, tongtien, trangthai)" +
                         "select (select max(ID_CT) ID_CT from CHUNGTU WHERE maloai = 'TT') ID_CT,  id_chisonuoc , thanhtien_app, 0 dathu  " +
                         " from  KHACHHANG a, CHISONUOC b where a.ID_KH = b.ID_KH and thutien_app <> 0 and ID_kyghi = '" + kyghi + "'  and NVGhi = '" + maNV + "' and ID_chisonuoc not in (select ID_Chisonuoc from CHUNGTU_CHISONUOC)";
            rs = cn.updateData(SQL);
            return rs;
        }
        public string getNV_ID(string maNV)
        {
            object obj;
            Connect_DB cn = new Connect_DB();
            string SQL = "select NV_ID from NHANVIEN where maNV = '" + maNV + "'";
            obj = cn.ExecuteScalar(SQL);
            return obj.ToString();
        }
        public int updatetongtien_CT(string SOCT, string kyghi)
        {
            int obj;
            Connect_DB cn = new Connect_DB();
            string SQL = " UPDATE CHUNGTU SET tongtien = (select isnull( SUM(tongtien), 0) " +
                         " FROM CHUNGTU a, CHUNGTU_CHISONUOC b where a.ID_CT = b.ID_CT and SOCT = '" + SOCT + "' and ID_kyghi = '" + kyghi + "')" +
                         " where SOCT = '" + SOCT + "' and ID_kyghi = '" + kyghi + "' ";
            obj = cn.updateData(SQL);
            return obj;
        }
        public DataTable getChitietGN(string ID_CT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select ROW_NUMBER() over(order by a.SOCT) stt,  d.id_chisonuoc,b.tongtien ,d.madanhbo, c.ID_KH,  hoten_KH, diachi " +
                         "from CHUNGTU a, CHUNGTU_CHISONUOC b , KHACHHANG c, CHISONUOC d " +
                         "where a.ID_CT = b.ID_CT and b.ID_Chisonuoc = d.id_chisonuoc and d.ID_KH = c.ID_KH and a.ID_CT = "+ID_CT+" ORDER BY a.SOCT";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getChitietGN_trangthai(string ID_CT, string trangthai)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "select ROW_NUMBER() over(order by a.SOCT) stt,  d.id_chisonuoc,b.tongtien ,d.madanhbo, c.ID_KH,  hoten_KH, diachi " +
                         "from CHUNGTU a, CHUNGTU_CHISONUOC b , KHACHHANG c, CHISONUOC d " +
                         "where a.ID_CT = b.ID_CT and b.ID_Chisonuoc = d.id_chisonuoc and d.ID_KH = c.ID_KH and a.ID_CT = " + ID_CT + " and b.trangthai = "+trangthai+"";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getSOCT_Chitiet(string soct)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() over(order by a.SOCT) stt, SOCT, sum(b.tongtien) tongtien, c.hoten NVNop, ngayct, count(b.ID_Chisonuoc) tonghd, ten_kyghi, e.hoten NVLap , " +
                         " case when b.trangthai = 0 then count(b.ID_Chisonuoc) end sl , case when a.trangthai = 0 then N'Chưa đồng bộ' else N'Đã đồng bộ' end trangthai, a.ID_CT, a.ghichu, a.NV_ID_nop, a.NV_ID_lap  " +
                         "FROM CHUNGTU a, CHUNGTU_CHISONUOC b , NHANVIEN c , DANHMUCKYGHI d, NHANVIEN e " +
                         "where a.ID_CT = b.ID_CT and a.NV_ID_nop = c.NV_ID and a.ID_kyghi = d.ID_kyghi and a.NV_ID_lap = e.NV_ID and a.SOCT like '%"+soct+"%' " +
                         "GROUP BY SOCT, c.hoten, ngayct, ten_kyghi, e.hoten, b.trangthai, a.trangthai, a.ID_CT, a.ghichu , a.NV_ID_nop, a.NV_ID_lap ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getSOCT_Chitiet_Kyghi(string ID_kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() over(order by a.SOCT) stt, SOCT, sum(b.tongtien) tongtien, c.hoten NVNop, ngayct, count(b.ID_Chisonuoc) tonghd, ten_kyghi, e.hoten NVLap , " +
                         " case when b.trangthai = 0 then count(b.ID_Chisonuoc) end sl , case when a.trangthai = 0 then N'Chưa đồng bộ' else N'Đã đồng bộ' end trangthai, a.ID_CT, a.ghichu, a.NV_ID_nop, a.NV_ID_lap  " +
                         "FROM CHUNGTU a, CHUNGTU_CHISONUOC b , NHANVIEN c , DANHMUCKYGHI d, NHANVIEN e " +
                         "where a.ID_CT = b.ID_CT and a.NV_ID_nop = c.NV_ID and a.ID_kyghi = d.ID_kyghi and a.NV_ID_lap = e.NV_ID and a.ID_Kyghi like '%" + ID_kyghi + "%' " +
                         "GROUP BY SOCT, c.hoten, ngayct, ten_kyghi, e.hoten, b.trangthai, a.trangthai, a.ID_CT, a.ghichu, a.NV_ID_nop , a.NV_ID_lap ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getSOCT_Chitiet_NV(string NV)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() over(order by a.SOCT) stt, SOCT, sum(b.tongtien) tongtien, c.hoten NVNop, ngayct, count(b.ID_Chisonuoc) tonghd, ten_kyghi, e.hoten NVLap , " +
                         " case when b.trangthai = 0 then count(b.ID_Chisonuoc) end sl , case when a.trangthai = 0 then N'Chưa đồng bộ' else N'Đã đồng bộ' end trangthai, a.ID_CT, a.ghichu, a.NV_ID_nop, a.NV_ID_lap  " +
                         "FROM CHUNGTU a, CHUNGTU_CHISONUOC b , NHANVIEN c , DANHMUCKYGHI d, NHANVIEN e " +
                         "where a.ID_CT = b.ID_CT and a.NV_ID_nop = c.NV_ID and a.ID_kyghi = d.ID_kyghi and a.NV_ID_lap = e.NV_ID and a.NV_ID_nop = " + NV + " " +
                         "GROUP BY SOCT, c.hoten, ngayct, ten_kyghi, e.hoten, b.trangthai, a.trangthai, a.ID_CT, a.ghichu, a.NV_ID_nop , a.NV_ID_lap ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getSOCT_Chitiet_NV_lap(string NV)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() over(order by a.SOCT) stt, SOCT, sum(b.tongtien) tongtien, c.hoten NVNop, ngayct, count(b.ID_Chisonuoc) tonghd, ten_kyghi, e.hoten NVLap , " +
                         " case when b.trangthai = 0 then count(b.ID_Chisonuoc) end sl , case when a.trangthai = 0 then N'Chưa đồng bộ' else N'Đã đồng bộ' end trangthai, a.ID_CT, a.ghichu, a.NV_ID_nop, a.NV_ID_lap  " +
                         "FROM CHUNGTU a, CHUNGTU_CHISONUOC b , NHANVIEN c , DANHMUCKYGHI d, NHANVIEN e " +
                         "where a.ID_CT = b.ID_CT and a.NV_ID_nop = c.NV_ID and a.ID_kyghi = d.ID_kyghi and a.NV_ID_lap = e.NV_ID and a.NV_ID_lap = " + NV + " " +
                         "GROUP BY SOCT, c.hoten, ngayct, ten_kyghi, e.hoten, b.trangthai, a.trangthai, a.ID_CT, a.ghichu, a.NV_ID_nop , a.NV_ID_lap ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getSOCT_Chitiet_ngaylap(string ngaybd, string ngaykt)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ROW_NUMBER() over(order by a.SOCT) stt, SOCT, sum(b.tongtien) tongtien, c.hoten NVNop, ngayct, count(b.ID_Chisonuoc) tonghd, ten_kyghi, e.hoten NVLap , " +
                         " case when b.trangthai = 0 then count(b.ID_Chisonuoc) end sl , case when a.trangthai = 0 then N'Chưa đồng bộ' else N'Đã đồng bộ' end trangthai, a.ID_CT, a.ghichu, a.NV_ID_nop, a.NV_ID_lap  " +
                         "FROM CHUNGTU a, CHUNGTU_CHISONUOC b , NHANVIEN c , DANHMUCKYGHI d, NHANVIEN e " +
                         "where a.ID_CT = b.ID_CT and a.NV_ID_nop = c.NV_ID and a.ID_kyghi = d.ID_kyghi and a.NV_ID_lap = e.NV_ID and a.ngayct between '"+ngaybd+"' and '"+ngaykt+"' " +
                         "GROUP BY SOCT, c.hoten, ngayct, ten_kyghi, e.hoten, b.trangthai, a.trangthai, a.ID_CT, a.ghichu, a.NV_ID_nop , a.NV_ID_lap ";
            dt = cn.getData(SQL);
            return dt;
        }
        public int updateBienNhan(string ID_CT, string NV_ID, string ngaylap)
        {
            Connect_DB cn = new Connect_DB();
            int rs = 0;
            string SQL = "update chungtu set nv_id_nop = " + NV_ID + ", ngayct = '" + ngaylap + "' where id_ct = " + ID_CT + " ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public int updateBienNhan(string ID_CT,  string ngaylap)
        {
            Connect_DB cn = new Connect_DB();
            int rs = 0;
            string SQL = "update chungtu set  ngayct = '"+ngaylap+"' where id_ct = "+ID_CT+" ";
            rs = cn.updateData(SQL);
            return rs;
        }
        public DataTable gachno(string id_ct)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "execute GACHNO "+id_ct+"";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable DSFKEY(string id_ct)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = "SELECT ID_HD from CHUNGTU_HOADON where id_ct = "+id_ct+" ";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDSPhieuThu(string kyghi)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select ROW_NUMBER() over(order by a.id_ct) stt, c.ID_KH,c.maLT, d.ngayct ngaythu, hoten_KH, diachi, c.madanhbo, a.tongtien, luongtieuthu, ngayct " +
                         " from CHUNGTU_CHISONUOC a, CHISONUOC b , KHACHHANG c, CHUNGTU d " +
                         " where a.ID_Chisonuoc = b.id_chisonuoc and b.ID_KH = c.ID_KH and a.ID_CT = d.ID_CT and b.ID_Kyghi = '"+kyghi+"'";
            dt = cn.getData(SQL);
            return dt;
        }
        public DataTable getDSPhieuThu_NV(string kyghi, string nv_id)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select ROW_NUMBER() over(order by a.id_ct) stt, c.ID_KH,c.maLT, d.ngayct ngaythu, hoten_KH, diachi, c.madanhbo, a.tongtien, luongtieuthu, ngayct " +
                         " from CHUNGTU_CHISONUOC a, CHISONUOC b , KHACHHANG c, CHUNGTU d " +
                         " where a.ID_Chisonuoc = b.id_chisonuoc and b.ID_KH = c.ID_KH and a.ID_CT = d.ID_CT and b.ID_Kyghi = '" + kyghi + "' and d.NV_ID_nop = " + nv_id + "";
            dt = cn.getData(SQL);
            return dt;
        }
            public DataTable getDSPhieuThu_TT(string kyghi, string TT)
        {
            DataTable dt = new DataTable();
            Connect_DB cn = new Connect_DB();
            string SQL = " select ROW_NUMBER() over(order by a.id_ct) stt, c.ID_KH,c.maLT, d.ngayct ngaythu, hoten_KH, diachi, c.madanhbo, a.tongtien, luongtieuthu, ngayct " +
                         " from CHUNGTU_CHISONUOC a, CHISONUOC b , KHACHHANG c, CHUNGTU d " +
                         " where a.ID_Chisonuoc = b.id_chisonuoc and b.ID_KH = c.ID_KH and a.ID_CT = d.ID_CT and b.ID_Kyghi = '" + kyghi + "' and a.trangthai = "+TT+"";
            dt = cn.getData(SQL);
            return dt;
        }
            public int delete_CTCSN(string id)
            {
                int rs = 0;
                Connect_DB cn = new Connect_DB();
                string sql = "delete CHUNGTU_CHISONUOC where id_chisonuoc = " + id + " ";
                rs = cn.updateData(sql);
                return rs;
            }
    }
}
