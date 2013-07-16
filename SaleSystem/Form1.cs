using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SaleSystem
{
    public partial class Login : Form 
    {
        private Database.User getUser = new Database.User();
        private ArrayList user = new ArrayList();
        private ArrayList pass = new ArrayList();
        public Login()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check=true;
            dbUser();
            for (int i = 0; i < user.Count; i++)
            {
                if (textUser.Text.ToString().Equals(user[i]))
                {
                    if (textPass.Text.ToString().Equals(pass[i]))
                    {
                        check = false;
                        FirstMain op = new FirstMain(textUser.Text);
                        this.Hide();
                        op.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่ Password ให้ถูกต้อง");
                        check = false;
                        textPass.Text = "";
                        break;
                    }
                }                
            }
            if (check)
            {
                MessageBox.Show("ไม่พบชื่อผู้ใช้ที่ระบุ");
                textPass.Text = "";
                textUser.Text = "";
            }

        }

        private void dbUser()
        {
            ArrayList UserPass = getUser.GetUser();          
            for (int i = 0; i < UserPass.Count; i++)
            {
                user.Add(UserPass[i].ToString().Split(',')[0]);
                pass.Add(UserPass[i].ToString().Split(',')[1]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
