using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SaleSystem.Database
{
    class sale
    {
        public static void insert(string s)
        {
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("insert into Sale values ('" + s.Split(',')[0] + "','" + s.Split(',')[1] + "','" + s.Split(',')[2] + "','" + s.Split(',')[3] + "','" + s.Split(',')[4] + "','" + s.Split(',')[5] + "','" + s.Split(',')[6] + "','" + s.Split(',')[7] + "','" + s.Split(',')[8] + "')", sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
