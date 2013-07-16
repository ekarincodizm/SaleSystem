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
    public partial class AllGoods : Form
    {
        private bool checkString=false;
        public AllGoods()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            listView1.Items.Clear();
            string select = checkSelect();
            ArrayList data = Database.goods.search(select);
            ListViewItem item;
            string[] addItem;
            for (int i = 0; i < data.Count; i++)
            {

                addItem = data[i].ToString().Split(',');
                item = new ListViewItem(addItem[0]);
                for (int j = 1; j < addItem.Length; j++)
                {
                    item.SubItems.Add(addItem[j]);
                }
                listView1.Items.Add(item);

            }
        }

        private string checkSelect()
        {
            string ret = "";
            string str = comboBox1.Text.ToString();
            if (str.Equals("ID"))
            {
                ret = "where ID ='" + textBox1.Text.ToString() + "' ";
            }
            else if (str.Equals("Name"))
            {
                ret = "where name ='" + textBox1.Text.ToString() + "'";
            }
            else if (str.Equals("Barcode"))
            {
                ret = "where barcode ='" + textBox1.Text.ToString() + "'";
            }
            else
            {
                ret = "";
            }
            return ret;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textID.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textname.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textprice.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textbarcode.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการที่จะเพิ่มข้อมูลสินค้าหรือไม่ ?", "comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                checkString = true;
                clear_text(checkString);
            }
            button4.Enabled = true;
        }
        private void clear_text(bool check)
        {
            if (check)
            {
                textID.Clear();
                textname.Clear();
                textprice.Clear();
                textbarcode.Clear();
            }
            textID.ReadOnly = false;
            textname.ReadOnly = false;
            textprice.ReadOnly = false;
            textbarcode.ReadOnly = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            if (!textID.Text.ToString().Equals(""))
            {
                if (MessageBox.Show("คุณต้องการที่จะแก้ไขข้อมูลสินค้าหรือไม่ ?", "comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    checkString = false;
                    clear_text(checkString);
                }
            }
            else MessageBox.Show("กรุณาค้นหาเเละเลือกสินค้าที่ต้องการแก้ไขด้านขวามือ", "เตือน");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string s = textname.Text+","+textprice.Text+","+textbarcode.Text;
            button4.Enabled = false;
            if (checkString)
            {
                Database.goods.insert(s);
                
            }
            else Database.goods.update(textID.Text,s);
            MessageBox.Show("บันทึกสำเร็จ", "แจ้งเตือน",MessageBoxButtons.OK);
            closeText();
            
        }
        private void closeText()
        {
            textID.Clear();
            textname.Clear();
            textprice.Clear();
            textbarcode.Clear();
            textID.ReadOnly = true;
            textname.ReadOnly = true;
            textprice.ReadOnly = true;
            textbarcode.ReadOnly = true;
            
         }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (!textID.Text.ToString().Equals(""))
            {
                if (MessageBox.Show("คุณต้องการที่จะลบข้อมูลสินค้าหรือไม่ ?", "comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Database.goods.delete(textID.Text);
                }
            }
            else MessageBox.Show("กรุณาค้นหาเเละเลือกสินค้าที่ต้องการแก้ไขด้านขวามือ", "เตือน");
            MessageBox.Show("ลบสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK);
            closeText();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.ToString().Equals(""))
            {
                string s = textBox2.Text + "," + textBox4.Text + "," + textBox3.Text + "," + DateTime.Now.ToShortDateString() + "," + DateTime.Now.ToShortTimeString();
                Database.addgoods.addgoodstodb(s);
                Database.addgoods.addorder(s);
                MessageBox.Show("Complete");
                textBox2.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";

            }
            else
            {
                MessageBox.Show("กรุณากรอกสินค้า");
            }
        }
        private void CheckaddOrder(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!textBox4.Text.ToString().Equals(""))
                {
                    ArrayList s = Database.goods.search("where barcode = " + textBox4.Text.ToString());
                    try
                    {
                        textBox2.Text = s[0].ToString().Split(',')[1];
                    }
                    catch { MessageBox.Show("กรุณาเพิ่มสินค้าในรายการสินค้าก่อนรับเข้าด้วยครับ"); textBox4.Text = ""; textBox2.Text = ""; }

                }
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckaddOrder);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
