using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CC3
{
    /*
        Question-3:
        Write a program in C# Sharp to append some text to an existing file. If file is not available, then create one in the same workspace.
        Hint: (Use the appropriate mode of operation.Use stream writer class)
    */
    class Question3
    {
        public static void WriteStream()
        {
            //FileMode.Append: Is used to append the Data into an file and if File Not Exists ,it first create an file and then append Data into an file 
            FileStream fs = new FileStream(@"C:\Infinite_Training\Csharp\CodeChallenge\CC3\CC3\NewFile.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Enter the string :");
            string str = Console.ReadLine();
            sw.Write(str);
            sw.Flush();
            sw.Close();
            Console.WriteLine("Data Has Been Appended to the File Successfully...");
        }

        public static void ReadStream()
        {
            FileStream fs = new FileStream(@"C:\Infinite_Training\Csharp\CodeChallenge\CC3\CC3\NewFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine("The Contents in this File:");
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine($"{str}"+" ");
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public static void Main()
        {
            WriteStream();
            ReadStream();

            Console.Read();
        }
    }
}
