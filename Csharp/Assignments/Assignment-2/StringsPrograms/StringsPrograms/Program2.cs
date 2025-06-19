using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsPrograms
{
    class Program2
    {
        static void Main(string[] args)
        {
            string word;
            Console.WriteLine("Enter a Word: ");
            word = Console.ReadLine();
            int len = word.Length;
            string reverse = "";
            for(int i=len-1;i>=0;i--)
            {
                reverse+= word[i];
            }
            Console.WriteLine($"The Reverse of a {word} is : {reverse}");
            Console.Read();
        }
    }
}
