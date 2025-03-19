using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCongNo.BLL
{
    class Connect_DB
    {
        public Connect_DB()
        {
            Connect();
        }
        private SqlConnection conn;
        static System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder entityBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(Common.strConn);
        string strconnect = entityBuilder.ProviderConnectionString;
        //public string strconnect = @"Server = 113.161.206.49; Database=CAPNUOC_TNC;Network Library=DBMSSOCN; User ID = wasspro; Password = wasspro@123";
        private void Connect()
        {
            try
            {
                conn = new SqlConnection(strconnect);
                conn.Open();
                if (conn.State == ConnectionState.Open) 
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết Nối Không Thành Công ! " + ex.Message.ToString());
            }
        }
        //get datatable
        public DataTable getData(string sql)
        {
            DataTable data = new DataTable();
            SqlDataAdapter dp = new SqlDataAdapter(sql, conn);
            dp.Fill(data);
            return data;
        }
        //update database
        public int updateData(string sql)
        {
            int result;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cm = new SqlCommand();
            cm.Connection = conn;
            cm.CommandType = CommandType.Text;
            cm.CommandText = sql;
            result = cm.ExecuteNonQuery();
            return result;
        }
        //Return 1 object
        public object ExecuteScalar(string sql)
        {
            object obj;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cm = new SqlCommand();
            cm.Connection = conn;
            cm.CommandType = CommandType.Text;
            cm.CommandText = sql;
            obj = cm.ExecuteScalar();
            return obj;
        }
        //return  datareader
        public SqlDataReader excuteReader(string strSql)
        {
            SqlDataReader obj;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            obj = cmd.ExecuteReader();
            return obj;
        }


        // return result procedure
        public SqlCommand  executeProc(string nameProc)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(nameProc, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
    }
}
