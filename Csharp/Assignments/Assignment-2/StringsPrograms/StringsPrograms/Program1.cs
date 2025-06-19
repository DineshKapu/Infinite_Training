using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsPrograms
{
    class Program1
    {
        static void Main(string[] args)
        {
            string word;
            Console.WriteLine("Enter a Word: ");
            word = Console.ReadLine();
            int len = word.Length;
            Console.WriteLine($"The Length of the {word} is :{len}");
            Console.Read();
        }
    }
}
