using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumber();
            // AryOperate();
            //PrimeFilter();
        }
        private static bool JudgePrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private static void AryOperate()
        {
            Console.WriteLine("请输入数组长度：");
            String str = Console.ReadLine();
            int n;
            bool flag_2 = int.TryParse(str, out n);
            if (!flag_2)
            {
                Console.WriteLine("输入的数字有误");
            }
            int[] ary;
            ary = new int[n];
            Console.WriteLine("请依次输入数组的值：");
            for (int i = 0; i < n; i++)
            {
                String str1 = Console.ReadLine();
                int aryElement;
                bool flag_3 = int.TryParse(str1, out aryElement);
                while (!flag_3)
                {
                    Console.WriteLine("输入的数字有误");
                    str1 = Console.ReadLine();
                    flag_3 = int.TryParse(str1, out aryElement);
                }
                ary[i] = aryElement;
            }
            int max = FindMax(ary, n);
            Console.WriteLine($"最大值为{max}");
            int min = FindMax(ary, n);
            Console.WriteLine($"最大值为{min}");
            int sum = 0;
            double average = 0;
            sum = FindSum(ary, n);
            average = sum / n;
            Console.WriteLine($"和为{sum}");
            Console.WriteLine($"平均值为{average}");
        }
        private static int FindMax(int[] ary, int n)
        {
            int max = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (ary[i] > ary[i + 1])
                {
                    max = ary[i];
                }
                else max = ary[i + 1];
            }
            return max;
        }
        private static int FindMin(int[] ary, int n)
        {
            int min = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (ary[i] > ary[i + 1])
                {
                    min = ary[i];
                }
                else min = ary[i + 1];
            }
            return min;
        }
        private static int FindSum(int[] ary, int n)
        {
            int sum = 0;
            for (int i = 0; i < n - 1; i++)
            {
                sum += ary[i];
            }
            return sum;
        }
        private static void PrimeFilter()
        {
            int[] ary;
            ary = new int[99];
            for (int i = 0; i < 99; i++)
            {
                ary[i] = i + 2;
            }
            for (int i = 2; i < 100; i++)
            {
                for (int j = 2; j * i < 101; j++)
                {
                    ary[j * i - 2] = 0;
                }
            }
            for (int i = 0; i < 99; i++)
            {
                if (ary[i] != 0)
                {
                    Console.WriteLine(ary[i]);
                }
            }

        }
        private static void PrimeNumber()
        {
            Console.WriteLine("请输入一个数：");
            string x = Console.ReadLine();
            int num;
            bool have = false;
            bool flag_1 = int.TryParse(x, out num);
            if (!flag_1 && (num < 0))
            {
                Console.WriteLine("输入的数字有误");
            }
            else
            {
                for (int n = 2; n < num; n++)
                {
                    if ((num % n == 0) && JudgePrime(n))
                    {
                        Console.WriteLine(n);
                        have = true;
                    }
                }
                if (!have)
                {
                    Console.WriteLine("这个数为素数");
                }
            }
        }
    }
}
