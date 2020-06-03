using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace CreateCVOnline.Code
{
    public class KETNOIDULIEU
    {
        SqlConnection conn;
        public KETNOIDULIEU()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Desktop\CreateCVOnline\CreateCVOnline\CreateCVOnline\CreateCVOnline\App_Data\CreateCVOnline.mdf;Integrated Security=True";
        }

        public void moKetNoi()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        public void dongKetNoi()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }

        public int thucthiNonQuery(string sql)
        {
            moKetNoi();
            SqlCommand comm = new SqlCommand(sql, conn);
            int k = comm.ExecuteNonQuery();
            dongKetNoi();
            return k;
        }
        public object thucthiReader(string sql)
        {
            moKetNoi();
            SqlCommand comm = new SqlCommand(sql, conn);
            object k = comm.ExecuteReader();
            dongKetNoi();
            return k;
        }

        public int thucthiScalar(string sql)
        {
            moKetNoi();
            SqlCommand comm = new SqlCommand(sql, conn);
            int k=(int)comm.ExecuteScalar();
            dongKetNoi();
            return k;
        }
        public DataTable getDuLieu(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}