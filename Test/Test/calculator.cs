using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class calculator
    {
        string s;
        string[] spl_s;
        int a;
        int b;
        public calculator()
        {
            Console.WriteLine("생성자 호출");
            a = 0;
            b = 0;
            s = null;
            spl_s = null;
        }

        ~calculator()
        {
            Console.WriteLine("소멸자 호출");
        }

        public void calc_spl()
        {
            s = Console.ReadLine();
            spl_s = s.Split(' ');
            if (spl_s.Length == 3 && int.Parse(spl_s[0]) < int.MaxValue && int.Parse(spl_s[0]) > int.MinValue && int.Parse(spl_s[2]) < int.MaxValue && int.Parse(spl_s[2]) > int.MinValue)
            {
                a = Convert.ToInt32(spl_s[0]);
                b = Convert.ToInt32(spl_s[2]);
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        public void makemethod()
        {
            char method = char.Parse(spl_s[1]);
            switch (method)
            {
                case '+':
                    if (a + b < int.MaxValue || a + b > int.MinValue)
                        Calc(a, b, Add);
                    else
                        Console.WriteLine("overflow Error");
                    break;

                case '-':
                    if (a - b < int.MaxValue || a - b > int.MinValue)
                        Calc(a, b, Subtract);
                    else
                        Console.WriteLine("overflow Error");
                    break;

                case '*':
                    if (a * b < int.MaxValue || a * b > int.MinValue)
                        Calc(a, b, Multiply);
                    else
                        Console.WriteLine("overflow Error");
                    break;

                case '/':
                    if (a * b < int.MaxValue || a * b > int.MinValue)
                        Calc(a, b, Divide);
                    else
                        Console.WriteLine("overflow Error");
                    break;
            }
        }

        private delegate int CalcDelegate(int a, int b);
        private static void Calc(int a, int b, CalcDelegate calc)
        {
            if (calc(a, b) < int.MaxValue || calc(a, b) > int.MinValue)
            {
                int res = calc(a, b);
                Console.WriteLine($"({a} , {b}) = {res}");
            }
        }


        private int Add(int a, int b)
        {
            return a + b;
        }

        private int Subtract(int a, int b)
        {
            return a - b;
        }

        private int Multiply(int a, int b)
        {
            return a * b;
        }

        private int Divide(int a, int b)
        {
            return a / b;
        }
        
    }
}
