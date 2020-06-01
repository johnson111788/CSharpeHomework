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
    public partial class Form1 : Form
    {
        OrderService myservice = new OrderService();
        public string KeyWord { get; set; }

        public Form1()
        {
            InitializeComponent();
            List<Orderitem> orderItem1 = new List<Orderitem>
            {
                new Orderitem(1, "可乐", 2, 2.5),
                new Orderitem(2, "雪碧", 1, 2.5),
                new Orderitem(3, "乐事", 10, 3),
            };

            List<Orderitem> orderItem2 = new List<Orderitem>
            {
                new Orderitem(1, "乐事", 1, 3)
            };

            List<Orderitem> orderItem3 = new List<Orderitem>
            {
                new Orderitem(1,"可乐",10,2.5)
            };
            myservice.AddOrder(new Order(1, "Joe", orderItem1));
            myservice.AddOrder(new Order(2, "Jerry", orderItem2));
            myservice.AddOrder(new Order(3, "Joe", orderItem3));
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include("Orderitem");
                foreach (var o in order)
                    myservice.Orders.Add(o);
            }
            orderBindingSource.DataSource = myservice.Orders;
            textBox1.DataBindings.Add("Text", this, "KeyWord");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KeyWord == null || KeyWord == "")
                orderBindingSource.DataSource = myservice.Orders;
            else if (!radioButton1.Checked && !radioButton2.Checked) 
                orderBindingSource.DataSource = myservice.Orders;
            else
            {
                if(radioButton1.Checked)
                {
                    orderBindingSource.DataSource =
                        myservice.Orders.Where(s => s.OrderId.ToString() == KeyWord);
                }
                else if (radioButton2.Checked)
                {
                    orderBindingSource.DataSource =
                        myservice.Orders.Where(s => s.CusName == KeyWord);
                }    
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2(myservice).ShowDialog();
            orderBindingSource.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3(myservice).ShowDialog();
            orderBindingSource.ResetBindings(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form4(myservice).ShowDialog();
            orderBindingSource.ResetBindings(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myservice.Import("./orders.xml");
            orderBindingSource.ResetBindings(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myservice.Export("orders.xml");
        }
    }
}
