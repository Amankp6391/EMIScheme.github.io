using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using sapmletask.Controllers;
using System.Drawing;

namespace sapmletask.Models
{
    public class DBLayer
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-UQ4GR57\\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True");

        public bool InsertUpdateDelete(string Command)
        {
            SqlCommand cmd = new SqlCommand(Command, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable GetAllRecord(string Command)
        {
            SqlDataAdapter da = new SqlDataAdapter(Command, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}