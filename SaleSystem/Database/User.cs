using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace SaleSystem.Database
{
    class User
    {
        public  ArrayList GetUser()
        {


            ArrayList ret = new ArrayList();
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand myCommand = new SqlCommand("select * from employee",sqlcon);
            SqlDataReader read = myCommand.ExecuteReader();
            while (read.Read())
            {
                ret.Add(read["username"].ToString() + "," + read["password"].ToString());
                
            }
            sqlcon.Close();
            return ret;
        }
    }
}
