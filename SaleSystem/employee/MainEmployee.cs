using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SaleSystem.employee
{
    public partial class MainEmployee : Form
    {
        private bool checkString = false;
        public MainEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string select = checkSelect();
            ArrayList data = Database.employee.SearchUser(select);
            ListViewItem item;
            string []addItem ;
            for (int i = 0; i < data.Count;i++ )
            {
                
                addItem = data[i].ToString().Split(',');
                item = new ListViewItem(addItem[8]);
                for(int j=0;j<addItem.Length-1;j++)
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
            if (str.Equals("Username"))
            {
                ret = "where username ='" + textBox1.Text.ToString() + "' ";
            }
            else if (str.Equals("ID Number"))
            {
                ret = "where idcard ='" + textBox1.Text.ToString() + "'";
            }
            else if (str.Equals("Name"))
            {
                ret = "where name ='" + textBox1.Text.ToString() + "'";
            }
            else if (str.Equals("Tell"))
            {
                ret = "where tell ='" + textBox1.Text.ToString() + "'";
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
                textBox2.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox9.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox5.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
                textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
                textBox7.Text = listView1.SelectedItems[0].SubItems[5].Text;
                textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
                richTextBox1.Text = listView1.SelectedItems[0].SubItems[7].Text;
                textBox8.Text = listView1.SelectedItems[0].SubItems[8].Text;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.ToString().Equals(""))
            {
                checkString = false;
                if (MessageBox.Show("คุณต้องการที่จะแก้ไขข้อมูลพนักงานหรือไม่ ?","comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clear_text(checkString);
                }
            }
            else MessageBox.Show("กรุณาค้นหาเเละเลือกพนักงานที่ต้องการแก้ไขด้านขวามือ","เตือน");
            
        }
        private void clear_text(bool New)
        {
            if (New)
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                richTextBox1.Clear();
                textBox10.Visible = true;
                textBox11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
            }
            richTextBox1.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            button4.Enabled = true;            
        }
        private void success()
        {
            richTextBox1.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการที่จะเพิ่มข้อมูลพนักงานหรือไม่ ?","comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                checkString = true;
                clear_text(checkString);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string s = textBox9.Text+","+textBox5.Text+","+textBox3.Text+","+textBox4.Text+","+textBox7.Text+","+textBox6.Text+","+richTextBox1.Text+","+textBox8.Text;
            if (checkString)
            {
                if (textBox10.Text.ToString().Equals(textBox11.Text.ToString()))
                {
                    textBox10.Visible = false;
                    textBox11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    s += "," + textBox10.Text;
                    Database.employee.insert(s);
                    MessageBox.Show("บันทึกสำเร็จ","เตือน",MessageBoxButtons.OK);
                    success();
                }
                else 
                {
                    MessageBox.Show("กรุณากรอก รหัสผ่านให้ตรงกัน","เตือน",MessageBoxButtons.OK);
                    textBox10.Clear();
                    textBox11.Clear();
                    return;
                }
            }
            else 
            {
                Database.employee.update(s, textBox2.Text);
                MessageBox.Show("แก้ไขสำเร็จ", "เตือน", MessageBoxButtons.OK);
                success();
            }
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.ToString().Equals(""))
            {
                Database.employee.delete(textBox2.Text.ToString());
                MessageBox.Show("ลบสำเร็จ", "เตือน", MessageBoxButtons.OK);
                success();
            }
            else MessageBox.Show("กรุณาค้นหาเเละเลือกพนักงานที่ต้องการลบด้านขวามือ", "เตือน", MessageBoxButtons.OK);
        }
    }
}
