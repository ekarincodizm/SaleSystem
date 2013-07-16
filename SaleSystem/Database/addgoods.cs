using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SaleSystem.Database
{
    class addgoods
    {
        public static void addgoodstodb(string s)
        {
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            string check=searchBalance(s.Split(',')[1]);
            SqlCommand cmd0 = new SqlCommand("insert into addorder values ('" + s.Split(',')[0] + "','" + s.Split(',')[1] + "','" + s.Split(',')[2] + "','" + s.Split(',')[3] + "','" + s.Split(',')[4] + "')", sqlcon);
            cmd0.ExecuteNonQuery();
            if (check.Equals("nohave"))
            {
                SqlCommand cmd = new SqlCommand("insert into addgoods values ('" + s.Split(',')[0] + "','" + s.Split(',')[1] + "','" + s.Split(',')[2] + "','" + s.Split(',')[3] + "','" + s.Split(',')[4] + "')", sqlcon);
                cmd.ExecuteNonQuery();
            }
            else 
            {
                SqlCommand cmd = new SqlCommand("UPDATE addgoods SET amount='" +(Convert.ToInt32(s.Split(',')[2]) + Convert.ToInt32(check.Split(',')[1])).ToString() + "'  WHERE ID='" + check.Split(',')[0] + "'", sqlcon);
                cmd.ExecuteNonQuery();
            }
            
            sqlcon.Close();
        }
        public static void addorder(string s)
        {
           
        }

        public static void deletegoodstodb(string s,string ss)
        {
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            string check = searchBalance(s.Split(',')[0]);
            Database.sale.insert(ss+","+(Convert.ToInt32(check.Split(',')[1]) - Convert.ToInt32(s.Split(',')[1])).ToString());
            SqlCommand cmd = new SqlCommand("UPDATE addgoods SET amount='" + (Convert.ToInt32(check.Split(',')[1]) - Convert.ToInt32(s.Split(',')[1])).ToString() + "'  WHERE ID='" + check.Split(',')[0] + "'", sqlcon);
                cmd.ExecuteNonQuery();           

            sqlcon.Close();
        }

        public static string searchBalance(string barcode)
        {
            string ret = "nohave";
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand myCommand = new SqlCommand("select * from addgoods ", sqlcon);
            SqlDataReader read = myCommand.ExecuteReader();
            while (read.Read())
            {
                if (read["barcode"].ToString().Equals(barcode))
                {
                    ret = read["ID"].ToString();
                    ret += "," + read["amount"].ToString();
                }
            }
            sqlcon.Close();
            return ret;
        }

        public static void insertSale(string s)
        {
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("insert into Sale values ( '" + s.Split(',')[0] + "','" + s.Split(',')[1] + "','" + s.Split(',')[2] + "','" + s.Split(',')[3] + "','" + s.Split(',')[4] + "','" + s.Split(',')[5] + "')", sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
