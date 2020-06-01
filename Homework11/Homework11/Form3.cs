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
    public partial class Form3 : Form
    {
        OrderService myservice3;
        public int DelId { get; set; }
        public Form3(OrderService service)
        {
            InitializeComponent();

            this.myservice3 = service;
            textBox1.DataBindings.Add("Text", this, "DelId");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myservice3.DeleteOrder(DelId);
            Close();
        }
    }
}
