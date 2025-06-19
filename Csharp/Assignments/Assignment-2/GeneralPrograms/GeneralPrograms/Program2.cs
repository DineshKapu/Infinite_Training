using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralPrograms
{
    class Program2
    {
        public static void Main()
        {
            Console.WriteLine("__________Display Number Four Times using {0}__________");
            Console.Write("Enter a Digit:");
            int num1;
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} {0} {0} {0}",num1);
            Console.WriteLine("{0}{0}{0}{0}", num1);
            Console.WriteLine("{0} {0} {0} {0}", num1);
            Console.WriteLine("{0}{0}{0}{0}", num1);
            Console.Read();




        }
    }
}
