using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework11
{
    public partial class Form4 : Form
    {
        OrderService myservice4;
        public int UpdId { get; set; }
        public string CusName { get; set; }
        public string ItemName { get; set; }
        public int ItemNum { get; set; }
        public double ItemPrice { get; set; }

        private List<Orderitem> orderItem = new List<Orderitem>();
        private int ItemSum;

        public Form4(OrderService service)
        {
            InitializeComponent();

            this.myservice4 = service;
            textBox1.DataBindings.Add("Text", this, "CusName");
            textBox2.DataBindings.Add("Text", this, "ItemName");
            textBox3.DataBindings.Add("Text", this, "ItemNum");
            textBox4.DataBindings.Add("Text", this, "ItemPrice");
            textBox5.DataBindings.Add("Text", this, "UpdId");
            textBox5.Clear();
            ItemSum = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderItem.Add(new Orderitem(ItemSum, ItemName, ItemNum, ItemPrice));
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            ItemSum += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myservice4.ModifyOrder(UpdId, new Order(UpdId, CusName, orderItem));
            Close();
        }
    }
}
