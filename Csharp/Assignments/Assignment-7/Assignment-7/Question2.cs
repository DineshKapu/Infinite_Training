using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Question-2:
    Write a query that returns words starting with letter 'a' and ending with letter 'm'.
    Expected input and output
    "mum", "amsterdam", "bloom" → "amsterdam"

 */
namespace Assignment_7
{
    class Question2
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter the No.of Words:");
            n = Convert.ToInt32(Console.ReadLine());
            List<string> words = new List<string>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter the Word-{i + 1}:");
                string word= Console.ReadLine();
                words.Add(word);
            }
            Console.WriteLine("The Words that are Starting with letter 'a' and ending with letter 'm' are: ");
            var Result = from word in words
                         where word.StartsWith("a",StringComparison.OrdinalIgnoreCase) && word.EndsWith("m",StringComparison.OrdinalIgnoreCase)
                         select word;
            foreach(var i in Result)
            {
                Console.WriteLine(i);
            }
            Console.Read();
        }
    }
}
