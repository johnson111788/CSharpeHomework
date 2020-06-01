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
    public partial class Form2 : Form
    {
        public string CusName { get; set; }
        public string ItemName { get; set; }
        public int ItemNum { get; set; }
        public double ItemPrice { get; set; }

        private List<Orderitem> orderItem = new List<Orderitem>();
        private int ItemSum;

        OrderService myservice2;

        public Form2(OrderService service)
        {
            InitializeComponent();

            this.myservice2 = service;

            ItemSum = 1;
            textBox1.DataBindings.Add("Text", this, "CusName");
            textBox2.DataBindings.Add("Text", this, "ItemName");
            textBox3.DataBindings.Add("Text", this, "ItemNum");
            textBox4.DataBindings.Add("Text", this, "ItemPrice"); 
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
            int max = -1;
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include("Orderitem");
                foreach (var o in order)
                {
                    if (o.OrderId >= max)
                        max = o.OrderId + 1;
                }
            }
            myservice2.AddOrder(new Order(max, CusName, orderItem));
            Close();
        }
    }
}
