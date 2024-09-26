using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Twolayerproject
{
    public class connectionclass
    {
        SqlConnection con;//object creation
        SqlCommand cmd;
        public connectionclass()//constructor
        {
            con = new SqlConnection(@"server=DESKTOP-1J45CQA\SQLEXPRESS;database = twolayer;INTEGRATED SECURITY=TRUE");
        }
        public int Fn_Nonquery(string sqlquery)//insert,delete,update
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);//read query
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string Fn_Scalar(string sqlquery)//scalar function
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }
        public SqlDataReader Fn_Reader(string sqlquery)//select
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public DataSet Fn_Dataset(string sqlquery)//select
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public DataTable Fn_DataTable(string sqlquery)//select
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }  

}