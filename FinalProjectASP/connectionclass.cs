using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FinalProjectASP
{
    public class connectionclass
    {
        SqlCommand cmd;
        SqlConnection con;

        public connectionclass()
        {
            con = new SqlConnection(@"server=LAPTOP-FS085SDF\SQLEXPRESS02;database=Project;Integrated security=true");
        }
        public int Fn_Nonquery(string sqlquery)//insert,delete,update
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string Fn_Scalar(string sqlquery)//scalar functions
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
        public SqlDataReader Fn_DataReader(string sqlquery)//select
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();                                //In Reader function there is no con.Close();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        //disconnected mode
        public DataSet Fn_DataSet(string sqlquery)//select
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
    
