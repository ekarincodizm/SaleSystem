using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace SaleSystem.Database
{
    class employee
    {

        //standard data query
        //username idcard name lname age sex address tell lname password\


        public static ArrayList SearchUser(string select)
        {

            ArrayList ret = new ArrayList();
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand myCommand = new SqlCommand("select * from employee "+select, sqlcon);
            SqlDataReader read = myCommand.ExecuteReader();
            while (read.Read())
            {
                
                    ret.Add(read["username"].ToString() + "," + read["idcard"].ToString() + "," + read["name"].ToString() + "," + read["lname"].ToString() + "," + read["age"].ToString() + "," + read["sex"].ToString() + "," + read["address"].ToString() + "," + read["tell"].ToString() + "," + read["ID"].ToString());
              
            }
            sqlcon.Close();
            return ret;

        }


        public static void update(string s,string id)
        {
            ArrayList str = new ArrayList();
            for (int i = 0; i < 8; i++)
            {
                str.Add(s.Split(',')[i]);
            }
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("UPDATE employee SET username='" + str[0] + "', idcard='" + str[1] + "', name='" + str[2] + "', lname='" + str[3] + "', age='" + str[4] + "', sex='" + str[5] + "', address='" + str[6] + "', tell='" + str[7] + "'" + " WHERE Id='" + id + "'", sqlcon);
            cmd.ExecuteReader();
            sqlcon.Close();
        }
        public static void delete(string s)
        {
            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM employee where ID='"+s+"' ", sqlcon);
            cmd.ExecuteReader();
            sqlcon.Close();
        }
        public static void insert(string s)
        {
            ArrayList str = new ArrayList();
            for (int i = 0; i < 9; i++)
            {
                str.Add(s.Split(',')[i]);
            }

            connect constring = new connect();
            string strcon = constring.Stringconnect;
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("insert into employee(username,idcard,name,lname,age,sex,address,tell,password) values ('" + str[0] + "','" + str[1] + "','" + str[2] + "','" + str[3] + "','" + str[4] + "','" + str[5] + "','" + str[6] + "','" + str[7] + "','" + str[8] + "')",sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }


    }
}
