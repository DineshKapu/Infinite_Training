using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Student
    {
        int RollNo;
        string Name;
        string Class;
        int Semester;
        string Branch;
        int[] Marks = new int[5];
        public Student(int RollNo,string Name,string Class,int Semester,string Branch)
        {
            this.RollNo = RollNo;
            this.Name = Name;
            this.Class = Class;
            this.Semester = Semester;
            this.Branch = Branch;
        }
        public void GetMarks()
        {
            Console.WriteLine("Enter Student Marks ");
            for(int i=0;i<Marks.Length;i++)
            {
                Console.WriteLine("Enter subject {0} Marks: ", i + 1);
                Marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void DisplayResult()
        {
            int tot=0;
            float avg;
            int check = 0;
            foreach(int i in Marks)
            {
                if (i < 35)
                    check = 1;
                tot += i;
            }
            avg = (tot) / Marks.Length;
            Console.WriteLine("The Average Of All 5 Subjects is : {0}", avg);
            Console.WriteLine("------------Results-------------");
            if (check==1)
            {
                Console.WriteLine("Result:Failed");
            }
            else if (check==0 && avg < 50)
            {
                Console.WriteLine("Result:Failed");
            }
            else
                Console.WriteLine("Result:Passed");
        }
        public void DisplayData()
        {
            Console.WriteLine("-----------The Student Details are:----------");
            Console.WriteLine("Student Roll No:{0}",RollNo);
            Console.WriteLine("Student Name:{0}", Name);
            Console.WriteLine("Class:{0}", Class);
            Console.WriteLine("Semester:{0}", Semester);
            Console.WriteLine("Branch:{0}", Branch);
            Console.WriteLine("-----The 5 Subject Marks are:-----");
            foreach(int i in Marks)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
                DisplayResult();
        }

        static void Main(string[] args)
        {
            int rollno;
            string name;
            string Class;
            int semester;
            string branch;
            Console.WriteLine("Enter Student Roll No: ");
            rollno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Student Class: ");
            Class = Console.ReadLine();
            Console.WriteLine("Enter Semester: ");
            semester = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Branch: ");
            branch=Console.ReadLine();
            Student stu = new Student(rollno,name,Class,semester,branch);
            stu.GetMarks();
            stu.DisplayData();
            Console.Read();
        }
    }
}
