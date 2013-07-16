using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace SaleSystem.Database
{
    class goods
    {
        public static void insert(string s)
        {
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("insert into goods(name,price,barcode) values ('" + s.Split(',')[0] + "','" + s.Split(',')[1] + "','" + s.Split(',')[2] + "')", sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        public static ArrayList search(string s)
        {
            ArrayList ret = new ArrayList();
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand myCommand = new SqlCommand("select * from goods " + s , sqlcon);
            SqlDataReader read = myCommand.ExecuteReader();
            while (read.Read())
            {
                ret.Add(read["ID"].ToString() + "," + read["name"].ToString() + "," + read["price"].ToString() + "," + read["barcode"].ToString());
            }
            sqlcon.Close();
            return ret; 
        }

        public static void update(string s1,string s2)
        {
           
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("UPDATE goods SET name='" + s2.Split(',')[0] + "', price='" + s2.Split(',')[1] + "', barcode='" + s2.Split(',')[2] + "' WHERE ID='" + s1 + "'", sqlcon);
            cmd.ExecuteReader();
            sqlcon.Close();
        }
        public static void delete(string s)
        {
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM goods where ID='" + s + "' ", sqlcon);
            cmd.ExecuteReader();
            sqlcon.Close();
        }
    }
}
