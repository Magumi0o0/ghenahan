using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;



namespace ghenahan.DAL
{
    public class DataAccessLayer
    {
        string con;
        SqlConnection sqlcon;
        public DataAccessLayer()
        {
            con = ConfigurationManager.ConnectionStrings["ghan"].ConnectionString;
            sqlcon = new SqlConnection(con);
        }

        public void Open()
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
        }

        public void Close()
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Dispose();
                sqlcon.Close();
            }
        }

        public DataTable SelectData(string Query)
        {
            SqlCommand sqlcmd = new SqlCommand(Query, sqlcon);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            return dt;
        }

        public int ExecuteCommand(string Query)
        {
            SqlCommand sqlcmd = new SqlCommand(Query, sqlcon);
            return sqlcmd.ExecuteNonQuery();
        }
    }
}
   