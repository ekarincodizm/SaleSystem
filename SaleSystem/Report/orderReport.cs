using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SaleSystem.Report
{
    public partial class orderReport : Form
    {
        public orderReport()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ArrayList data= Database.Report.report_addOrder(selection1(),selectdate1());

            ListViewItem item;
            string[] addItem;
            for (int i = 0; i < data.Count; i++)
            {              
                addItem = data[i].ToString().Split(',');
                textBox5.Text = (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(addItem[2])).ToString();
                item = new ListViewItem((i+1).ToString());
                for (int j = 0; j < addItem.Length; j++)
                {
                    item.SubItems.Add(addItem[j]);
                }
                listView1.Items.Add(item);

            }
        }

        private string selection1()
        {
            string ret = "";
            if (textBox2.Text.Equals("")) ret = "select * from addorder";
            else ret = "select * from addorder where name = '" + textBox2.Text + "'";
            return ret;
        }
        private string selectdate1()
        {
            string ret = (Convert.ToInt32(comboBox1.SelectedIndex) + 1).ToString()+","+textBox1.Text;
            return ret;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            ArrayList data = Database.Report.Sale(selection2(), selectdate2());
            ListViewItem item;
            string[] addItem;
            for (int i = 0; i < data.Count; i++)
            {
                addItem = data[i].ToString().Split(',');
                textBox6.Text = (Convert.ToInt32(textBox6.Text) + Convert.ToInt32(addItem[2])).ToString();
                textBox7.Text = (Convert.ToInt32(textBox7.Text) + Convert.ToInt32(addItem[3])).ToString();
                item = new ListViewItem((i+1).ToString());
                for (int j = 0; j < addItem.Length; j++)
                {
                    item.SubItems.Add(addItem[j]);
                }
                listView2.Items.Add(item);

            }
        }
        private string selection2()
        {
            string ret = "";
            if (textBox3.Text.Equals("")) ret = "select * from Sale";
            else ret = "select * from Sale where name = '" + textBox3.Text + "'";            
            return ret;
        }
        private string selectdate2()
        {
            string ret = (Convert.ToInt32(comboBox2.SelectedIndex) + 1).ToString() + "," + textBox4.Text;
            return ret;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!textBox6.Text.Equals("0"))
            {
                goods.pdf.reportPdfSale(string1(), "รายงานการขายสินค้า");
                textBox6.Clear();
                textBox7.Clear();
                listView2.Items.Clear();
            }
        }
        private string string1()
        {
            string ret = "";
            string month=comboBox2.Text;
            if(comboBox2.Text.ToString().Equals("เลือกเดือน"))month="ทุกเดือน";
            ret = "ประจำเดือน " + month + " พศ " + textBox4.Text + "\n\n";
            string name = textBox3.Text;
            if (name.Equals("")) name = "ทั้งหมด";
            ret += "ชื่อสินค้า " + name + "\n";
            ret+="รายการดังนี้\n";
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                ret +=(i+1).ToString()+ "    วันที่     " + listView2.Items[i].SubItems[1].Text + "     ชื่อสินค้า    " + listView2.Items[i].SubItems[2].Text + "      จำนวน     " + listView2.Items[i].SubItems[3].Text + "     ราคา     " + listView2.Items[i].SubItems[4].Text + "     บาท\n";
            }

                ret += "\nรวมจำนวนสินค้า      " + textBox6.Text + "      ชิ้น รวมเป็นเงิน     " + textBox7.Text+"    บาท";            
            return ret;
        }
        private string string2()
        {
            string ret = "";
            string month = comboBox1.Text;
            if (comboBox1.Text.ToString().Equals("เลือกเดือน")) month = "ทุกเดือน";
            ret = "ประจำเดือน " + month + " พศ " + textBox1.Text + "\n\n";
            string name = textBox2.Text;
            if (name.Equals("")) name = "ทั้งหมด";
            ret += "ชื่อสินค้า " + name + "\n";
            ret += "รายการดังนี้\n";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ret += (i + 1).ToString() + "    วันที่     " + listView1.Items[i].SubItems[1].Text + "     ชื่อสินค้า    " + listView1.Items[i].SubItems[2].Text + "      จำนวน     " + listView1.Items[i].SubItems[3].Text + "     ชิ้น    \n";
            }

            ret += "\n"+ "รวมทั้งหมด     " + textBox5.Text + "    ชิ้น";
            return ret;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox5.Text.Equals("0"))
            {
                goods.pdf.reportPdfSale(string2(), "รายงานการรับเข้าสินค้า");
                listView1.Items.Clear();
                textBox5.Clear();
                textBox2.Clear();
            }
        }

    }
}
