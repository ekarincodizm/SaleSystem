using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaleSystem
{
    public partial class FirstMain : Form
    {
        employee.MainEmployee op1;
        goods.MainGoods op2;
        goods.AllGoods op3;
        Report.orderReport op4;
        info.About op5;
  

        public static string user;
        public FirstMain(string s)
        {
            
            InitializeComponent();
            user = s;
            this.Text = "ระบบขายสินค้า - - -  ชื่อผู้ใช้งาน " + s;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (op1 == null || op1.IsDisposed)
                op1 = new employee.MainEmployee();
                op1.MdiParent = this;
                op1.Show();
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (op2 == null || op2.IsDisposed)
            op2 = new goods.MainGoods();
            op2.MdiParent = this;
            op2.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (op3 == null || op3.IsDisposed)
            op3 = new goods.AllGoods();
            op3.MdiParent = this;
            op3.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("PBARCODE.EXE");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (op4 == null || op4.IsDisposed)
            op4 = new Report.orderReport();
            op4.MdiParent = this;
            op4.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (op5 == null || op5.IsDisposed)
            op5 = new info.About();
            op5.MdiParent = this;
            op5.Show();
        }

        private void FirstMain_Load(object sender, EventArgs e)
        {

        }
    }
}
