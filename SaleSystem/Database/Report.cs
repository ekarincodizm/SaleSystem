using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace SaleSystem.Database
{
    class Report
    {
        public static ArrayList report_addOrder(string select,string where)
        {
            ArrayList ret = new ArrayList();
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand myCommand = new SqlCommand(select, sqlcon);
            SqlDataReader read = myCommand.ExecuteReader();
            while (read.Read())
            {
                if (Convert.ToInt32(where.Split(',')[0]) == Convert.ToInt32(read["date"].ToString().Split('/')[1]) && Convert.ToInt32(where.Split(',')[1]) == Convert.ToInt32(read["date"].ToString().Split('/')[2]))
                {
                    ret.Add(read["date"]+","+read["name"]+","+read["amount"]);
                }
            }
            sqlcon.Close();
            return ret;
        }
        public static ArrayList Sale(string select, string where)
        {
            ArrayList ret = new ArrayList();
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand myCommand = new SqlCommand(select, sqlcon);
            SqlDataReader read = myCommand.ExecuteReader();
            while (read.Read())
            {
                if (Convert.ToInt32(where.Split(',')[0]) == Convert.ToInt32(read["date"].ToString().Split('/')[1]) && Convert.ToInt32(where.Split(',')[1]) == Convert.ToInt32(read["date"].ToString().Split('/')[2]))
                {
                    ret.Add(read["date"] + "," + read["name"] + "," + read["amout"] + "," + read["price"] + "," + read["balance"]);
                }
            }
            sqlcon.Close();
            return ret;
        }
        
    }
}
