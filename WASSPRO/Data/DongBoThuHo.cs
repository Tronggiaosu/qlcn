using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLCongNo.Data
{
    public class DongBoThuHo
    {
        public bool SyncThuHo(TB_ThanhToan data)
        {
            try
            {
                var connStr = ConfigurationManager.ConnectionStrings[$"ServerThuHo"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("THANHTOAN_HOADON_NEW_DONGBO", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SODANHBO", data.SODANHBO);
                        cmd.Parameters.AddWithValue("@ID_HD", data.ID_HD);
                        cmd.Parameters.AddWithValue("@USER_TT", data.USER_TT);
                        cmd.Parameters.AddWithValue("@NGAY_TT", data.NGAY_TT);
                        cmd.Parameters.AddWithValue("@NHANVIEN_TT", data.NHANVIEN_TT);
                        cmd.Parameters.AddWithValue("@HINHTHUC_TT", data.HINHTHUC_TT);
                        cmd.Parameters.AddWithValue("@NGANHANG_TT", data.NGANHANG_TT);
                        cmd.Parameters.AddWithValue("@GHICHU_TT", data.GHICHU_TT);
                        cmd.Parameters.AddWithValue("@TRANSACTION_NO", data.TRANSACTION_NO);

                        conn.Open();
                        var rowsAffected = cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }

        public DataTable GetHoaDonThuHo(string idhd)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[$"ServerThuHo"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var query = "SELECT * " +
                                "FROM TB_THANHTOAN " +
                                $"WHERE ID_HD = '{idhd}' ";
                    connection.Open();

                    DataTable dt = new DataTable();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            conn.Open();
                            adapter.Fill(dt);
                        }
                        catch (Exception ex)
                        {
                            var msg = ex.Message;
                            return null;
                        }
                    }

                    return dt;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return null;
                }
            }
        }

        public DataTable ServerQLCN(int mode, DataTable dt, int nam, string thang, int dot)
        {
            var result = new DataTable();
            switch (mode)
            {
                case 0:
                    result = ConnectByQueries("ServerQLCN", nam, thang, dot);
                    break;
                case 1:
                    result = ConnectByStoredProcedure("ServerQLCN", dt);
                    break;

            }
            return result;
        }

        public DataTable ServerThuHo(int mode, DataTable dt, int nam, int thang, int dot)
        {
            var result = new DataTable();
            switch (mode)
            {
                case 0:
                    result = ConnectByQueries("ServerThuHo", nam, $"{thang}", dot);
                    break;
                case 1:
                    result = ConnectByStoredProcedure("ServerThuHo", dt);
                    break;
            }
            return result;
        }

        private DataTable ConnectByQueries(string server, int nam, string thang, int dot)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[$"{server}"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var query = String.Empty;
                    connection.Open();

                    switch (server)
                    {
                        case "ServerQLCN":
                            query = "SELECT [KEY] AS ID_HD " +
                             "FROM PublishedInvoices " +
                             $"WHERE (GACH_NO = '0' OR GACH_NO IS NULL) AND NAM = {nam} AND KYHD = '{thang}' AND DOT_ID = {dot}";
                            break;
                        case "ServerThuHo":
                            query = "SELECT ID_HD " +
                            "FROM view_HOADON_DONGBO_CONGNO " +
                            $"WHERE TRANGTHAI = '0' AND NAM = {nam} AND KY = '{thang}' AND DOT = {dot}";
                            break;
                    }

                    DataTable dt = new DataTable();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            conn.Open();
                            adapter.Fill(dt);
                        }
                        catch (Exception ex)
                        {
                            var msg = ex.Message;
                            return null;
                        }
                    }

                    return dt;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return null;
                }
            }
        }

        private DataTable ConnectByStoredProcedure(string server, DataTable dt)
        {
            try
            {
                var connStr = ConfigurationManager.ConnectionStrings[$"{server}"].ConnectionString;
                var result = new DataTable();

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("dbo.DONGBO_THUHO_GET_DSHOADON", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@ID_HD", dt);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.DongBoThuHo_ListHoaDon";

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(result);
                }

                return result;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }
    }

    public class TB_ThanhToan
    {
        public string SODANHBO { get; set; }
        public string ID_HD { get; set; }
        public string USER_TT { get; set; }
        public string NGAY_TT { get; set; }
        public string NHANVIEN_TT { get; set; }
        public string DIENTHOAI_TT { get; set; }
        public string HINHTHUC_TT { get; set; }
        public string NGANHANG_TT { get; set; }
        public string GHICHU_TT { get; set; }
        public string TRANSACTION_NO { get; set; }
    }
}
