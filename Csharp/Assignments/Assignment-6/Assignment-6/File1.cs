using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
/*
    Question-2:
    Write a program in C# Sharp to create a file and write an array of strings to the file.
 */
namespace Assignment_6
{
    class File1
    {
        public static void Main()
        {

            //Writing Into an File
            //using (FileStream fs = new FileStream(@"C:\Infinite_Training\Csharp\Assignments\Assignment-6\Assignment-6\File1.txt", FileMode.Create, FileAccess.Write))-To create a File 
            using (FileStream fs = new FileStream(@"C:\Infinite_Training\Csharp\Assignments\Assignment-6\Assignment-6\File1.txt", FileMode.Append, FileAccess.Write)) //Appending Data into an File
            {
                Console.Write("Enter the Number of Lines you Want to Write: ");
                int No_Of_Lines = Convert.ToInt32(Console.ReadLine());
                string[] Lines = new string[No_Of_Lines];
                for (int i = 0; i < No_Of_Lines; i++)
                {
                    Console.WriteLine("Enter Line-{0}", i + 1);
                    Lines[i] = Console.ReadLine();
                }
                using (StreamWriter writer=new StreamWriter(fs))
                {
                    foreach(string line in Lines)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Lines are written to File Successfully");
            //reading the Content from the File
            Console.WriteLine("Reading Text from the File: ");
            using (FileStream fs = new FileStream(@"C:\Infinite_Training\Csharp\Assignments\Assignment-6\Assignment-6\File1.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    string line;
                    while((line=reader.ReadLine())!=null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Press any Key To exit...");
            Console.Read();
            
        }
    }
}
