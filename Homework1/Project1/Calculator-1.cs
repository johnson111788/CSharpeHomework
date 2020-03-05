using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class program
    {
        static void Main(string[] args)
        {
            bool flag1 = true;
            bool flag2 = true;
            int num1 = commom.num1;
            int num2 = commom.num2;
            while (flag1)
            {
                Console.WriteLine("请输入第一个数：");
            string s1 = Console.ReadLine();
            bool a = int.TryParse(s1, out num1);
                if (!a)
                {
                    Console.WriteLine("请输入正确数字");
                    flag1 = true;
                }
                else
                {
                    flag1 = false;
                }
            }
            while (flag2)
            {
                Console.WriteLine("请输入第二个数");
                string s2 = Console.ReadLine();
                bool b = int.TryParse(s2, out num2);
                if (!b)
                {
                    Console.WriteLine("请输入正确数字");
                    flag2 = true;
                }
                else
                {
                    flag2 = false;
                }
            }
            cal(num1, num2);
        }
        public   static void cal(int num1,int num2)
        {
            try
            {
                Console.WriteLine(" 请输入运算符：");
                string s3 = Console.ReadLine();
                bool c = int.TryParse(s3, out int num3);
                switch (s3)
                {
                    case "+":
                        Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                        break;
                    case "-":
                        Console.WriteLine($"Your result: {num1} - {num2}=" + (num1 - num2));
                        break;
                    case "*":
                        Console.WriteLine($"Your result: {num1} × {num2}=" + (num1 * num2));
                        break;
                    case "/":
                        Console.WriteLine($"Your result: {num1} / {num2}=" + (num1 / num2));
                        break;
                }
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
        public class commom
        {
            public static int num1;
            public static int num2;
        }


    }
}
