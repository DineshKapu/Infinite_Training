using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2; //double num1,num2;
            char c;
            Console.WriteLine("Input first number:");
            num1 = Convert.ToInt32(Console.ReadLine()); //num1=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input Operation:");
            c = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Input second number:");
            num2 = Convert.ToInt32(Console.ReadLine()); //num2=Convert.ToDouble(Console.ReadLine());
            switch (c)
            {
                case '+':
                    double res1 = num1 + num2;
                    Console.WriteLine($"{num1}{c}{num2}={res1}");
                    break;
                case '-':
                    double res2;
                    if (num1 >= num2)
                    {
                        res2 = num1 - num2;
                        Console.WriteLine($"{num1}{c}{num2}={res2}");
                    }

                    else
                    {
                        res2 = num2 - num1;
                        Console.WriteLine($"{num2}{c}{num1}={res2}");
                    }
                    break;
                case '*':
                    double res3 = num1 * num2;
                    Console.WriteLine($"{num1}{c}{num2}={res3}");
                    break;
                case '/':
                    double res4;
                    if (num2 != 0)
                    {
                        res4 = num1 / num2;
                        Console.WriteLine($"{num1}{c}{num2}={res4}");
                    }
                    else
                        Console.WriteLine("Division is not possible");
                    break;
                default:
                    Console.WriteLine("Invalid Operation");
                    break;

            }
            Console.Read();


        }
    }
}
