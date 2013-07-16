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
    public partial class MainGoods : Form
    {
        private string barcode;
        public MainGoods()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!texbarcode.Text.ToString().Equals(""))
            {
                barcode = texbarcode.Text;               
            }
            this.texbarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }
        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!texbarcode.Text.ToString().Equals(""))
                {
                    try
                    {
                        if (name.Text.Equals(barcode))
                        {
                            amout.Text = (Convert.ToInt32(amout.Text) + 1).ToString();
                        }
                        else search();
                    }
                    catch { MessageBox.Show("ไม่พบสินค้า","เตือน",MessageBoxButtons.OK); }
                    texbarcode.Clear();
                }
            }
        }
        private void search()
        {
           
           
                ArrayList data = Database.goods.search("where barcode = '" + texbarcode.Text + "'");
                name.Text = data[0].ToString().Split(',')[1];
                price.Text = data[0].ToString().Split(',')[2];
                amout.Text = "1";
                TextTotal.Text = data[0].ToString().Split(',')[2];
            
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = new ListViewItem(barcode);
                item.SubItems.Add(name.Text);
                item.SubItems.Add(price.Text);
                item.SubItems.Add(amout.Text);
                item.SubItems.Add(TextTotal.Text);
                listView1.Items.Add(item);
                totalprice.Text = (Convert.ToDouble(totalprice.Text) + Convert.ToDouble(TextTotal.Text)).ToString();
                name.Clear();
                price.Clear();
                amout.Clear();
                TextTotal.Clear();
                texbarcode.Focus();
            }
            catch { }
        }

        private void amout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextTotal.Text = (Convert.ToDouble(amout.Text) * Convert.ToDouble(price.Text)).ToString();
            }
            catch
            {
                TextTotal.Text = "0";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("สมาชิก")) textBox2.ReadOnly = false;
            else textBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList sale = new ArrayList();
            string send = "";
            int count = 1;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                count += i;
                send+=listView1.Items[i].SubItems[0].Text+","+listView1.Items[i].SubItems[3].Text+",";
                
                    sale.Add(listView1.Items[i].SubItems[1].Text + "," + listView1.Items[i].SubItems[3].Text + "," + listView1.Items[i].SubItems[0].Text + "," + listView1.Items[i].SubItems[4].Text+","+DateTime.Now.ToShortDateString()+","+DateTime.Now.ToShortTimeString()+","+FirstMain.user+","+TypeCustomer());
            }
            goods.Change op = new goods.Change(totalprice.Text,string2(),send,count,sale);
            listView1.Items.Clear();
            op.ShowDialog();
            
        }

        private string string2()
        {
            string ret = "ชื่อพนักงาน " + FirstMain.user+"\n";
            ret += "วันที่ "+DateTime.Now.ToShortDateString()+" เวลา " + DateTime.Now.ToShortTimeString() + "\n\n";
            ret += "รายการดังนี้\n\n";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ret += (i + 1).ToString() + "    ชื่อ     " + listView1.Items[i].SubItems[1].Text + "     ราคาต่อหน่วย    " + listView1.Items[i].SubItems[2].Text + "   บาท   จำนวน   " + listView1.Items[i].SubItems[3].Text + "     ชิ้น    เป็นเงิน     " + listView1.Items[i].SubItems[4].Text + "    บาท  \n";
            }
            return ret;
        }

        private string TypeCustomer()
        {
            string ret = "";
            if(textBox2.ReadOnly==true)ret="general";
            else ret=textBox2.Text;
            return ret;
        }
    }
}
