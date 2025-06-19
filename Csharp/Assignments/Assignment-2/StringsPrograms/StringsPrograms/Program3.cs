using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsPrograms
{
    class Program3
    {
        static void Main(string[] args)
        {
            string word1,word2;
            Console.WriteLine("Enter a Word1: ");
            word1 = Console.ReadLine();
            Console.WriteLine("Enter a Word2: ");
            word2 = Console.ReadLine();
            int len1, len2;
            len1 = word1.Length;
            len2 = word2.Length;
            if(len1==len2)
            {
                if(word1.Equals(word2))
                {
                    Console.WriteLine("The Words Are Same");
                }
                else
                    Console.WriteLine("The Words Are Not Same");
            }

            else
                Console.WriteLine("The Words Are Not Same");
            Console.Read();

        }
    }
}
