using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
/*
    Question-3:
    Write a program in C# Sharp to count the number of lines in a file.
*/
namespace Assignment_6
{
    class File2
    {
        static void Main()
        {
            string FileName = Path.GetFileName(@"C:\Infinite_Training\Csharp\Assignments\Assignment-6\Assignment-6\File1.txt");
            Console.WriteLine($"Reading Contents from the Existing File: '{FileName}'");
            using (FileStream fs = new FileStream(@"C:\Infinite_Training\Csharp\Assignments\Assignment-6\Assignment-6\File1.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("-------Now,The no.of lines in this File is -------");
            try
            {
                int count = 0;
                using (FileStream fs = new FileStream(@"C:\Infinite_Training\Csharp\Assignments\Assignment-6\Assignment-6\File1.txt", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
         
                        while (reader.ReadLine()!= null)
                        {
                            count++;
                        }
                    }
                  
                    Console.WriteLine($"The Total number of Lines in the Given File-'{FileName}' is : {count}");
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File Not Found");
            }
            catch(Exception)
            {
                Console.WriteLine("!Error..");
            }
            Console.Read();
        }
    }
}
