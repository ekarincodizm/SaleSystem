using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SaleSystem.goods
{
    public partial class Change : Form
    {
        string data = "";
        string res = "";
        int cou = 0;
        ArrayList ss = new ArrayList();
        public Change(string price,string dt,string recive,int count,ArrayList sale)
        {
            
            InitializeComponent();
            textBox2.Focus();
            data = dt;
            textBox1.Text = price;
            res = recive;
            cou = count;
            ss = sale;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            data += "\n";
            data += "  เป็นเงินทั้งหมด   " + textBox1.Text;
            data += "     ลูกค้าจ่ายมา   " + textBox2.Text;
            data += "   ทอนเงิน " + textBox3.Text;

            for (int i = 0; i < cou; i++)
            {
                //Database.sale.insert
               Database.addgoods.deletegoodstodb(res.Split(',')[((i + 1) * 2) - 2] + "," + res.Split(',')[((i + 1) * 2)-1],ss[i].ToString());
            }
            pdf.reportPdfSale(data, "ใบเสร็จ");

                closeNow();
        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            double ton = (Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox1.Text));
            if (ton < 0) ton = 0;
            textBox3.Text = ton.ToString();
        }
        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                data += "\n";
                data += "  เป็นเงินทั้งหมด   " + textBox1.Text;
                data += "     ลูกค้าจ่ายมา   " + textBox2.Text;
                data += "   ทอนเงิน " + textBox3.Text;
                pdf.reportPdfSale(data, "ใบเสร็จ");
                closeNow();
            }
        }


        private void closeNow()
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text +4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 7;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 8;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 9;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 0;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + ".";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Change_Load(object sender, EventArgs e)
        {

        }

    }
}
