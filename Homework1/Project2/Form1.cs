using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool add_flag = false;
        private bool minus_flag = false;
        private bool multi_flag = false;
        private bool div_flag = false;
        private bool result_flag = false;
        private bool can_operate_flag = false;
        private List<int> number_list = new List<int>();
        private List<int> operator_list = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }
        private void write_number(string num)
        {
            if (add_flag || minus_flag || multi_flag || div_flag || result_flag)
            {
                if (result_flag)
                {
                    label1.Text = "";
                }
                textBox1.Clear();
                add_flag = false;
                minus_flag = false;
                multi_flag = false;
                div_flag = false;
                result_flag = false;
            }
            textBox1.Text += num;
            input.Text += num;
            can_operate_flag = true;

        }

        
        
        private void clean_button_Click(object sender, EventArgs e)
        {
            add_flag = false;
            minus_flag = false;
            bool multi_flag = false;
            div_flag = false;
             result_flag = false;
            can_operate_flag = false;
            input.Text = "";
            operator_list.Clear();
            number_list.Clear();
            textBox1.Clear();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            write_number("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            write_number("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            write_number("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            write_number("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            write_number("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            write_number("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            write_number("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            write_number("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            write_number("9");
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            write_number("0");
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (!add_flag)
            {
                result_flag = false;
                number_list.Add(int.Parse(textBox1.Text));
                operator_list.Add(0);
                input.Text += "+";
                add_flag = true;
                can_operate_flag = false;
            }
        }

        private void subtraction_button_Click(object sender, EventArgs e)
        {
            if (!minus_flag)
            {
                result_flag = false;
                number_list.Add(int.Parse(textBox1.Text));
                operator_list.Add(1);
                input.Text += "-";
                minus_flag = true;
                can_operate_flag = false;
            }
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            if (!multi_flag)
            {
                result_flag = false;
                number_list.Add(int.Parse(textBox1.Text));
                operator_list.Add(2);
                input.Text += "×";
                multi_flag = true;
                can_operate_flag = false;
            }
        }

        private void division_button_Click(object sender, EventArgs e)
        {
            if (!div_flag)
            {
                result_flag = false;
                number_list.Add(int.Parse(textBox1.Text));
                operator_list.Add(3);
                input.Text += "÷";
                div_flag = true;
                can_operate_flag = false;
            }
        }

        private void result_button_Click(object sender, EventArgs e)
        {
            if(number_list.Count>0&&operator_list.Count>0&&can_operate_flag)
            {
                number_list.Add(int.Parse(textBox1.Text));
                int total = number_list[0];
                int _operator = operator_list[0];
                switch(_operator)
                {
                    case 0:
                        total += number_list[1];
                        break;
                    case 1:
                        total -= number_list[1];
                        break;
                    case 2:
                        total *= number_list[1];
                        break;
                    case 3:
                        total /= number_list[1];
                        break;

                }
                textBox1.Text = total + "";
                input.Text = total + "";
                operator_list.Clear();
                number_list.Clear();
                result_flag = true;
                
            }   
        }
    }
}
