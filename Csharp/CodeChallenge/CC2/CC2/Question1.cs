using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Question-1:
    Create an Abstract class Student with  Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.  
    Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method
    For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.
    Test the above by creating appropriate objects
 */
namespace CC2
{
    public abstract class Student
    {
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public abstract bool IsPassed(double grade);
    }
    public class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, double grade)
        {
            StudentName = name;
            StudentId = studentId;
            Grade = grade;
        }

        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    public class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade)
        {
            StudentName = name;
            StudentId = studentId;
            Grade = grade;
        }

        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Question1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------UnderGraduation Details-------");
            Console.WriteLine("Enter Student Name for Undergraduate:");
            string undergradStuName = Console.ReadLine();

            Console.WriteLine("Enter student ID for Undergraduate:");
            int undergradStuId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter grade for Undergraduate:");
            double undergradStuGrade = Convert.ToDouble(Console.ReadLine());

            Undergraduate undergrad = new Undergraduate(undergradStuName, undergradStuId, undergradStuGrade);


            Console.WriteLine("Undergraduate- " +" Student Name: "+ undergrad.StudentName + " with ID " + undergrad.StudentId + " has " +
                              (undergrad.IsPassed(undergrad.Grade) ? "passed." : "not passed."));

            Console.WriteLine("-------Graduation Details-------");
            Console.WriteLine("Enter Student Name for Graduate:");
            string gradStuName = Console.ReadLine();

            Console.WriteLine("Enter student ID for Graduate:");
            int gradStuId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter grade for Graduate:");
            double gradStuGrade = Convert.ToDouble(Console.ReadLine());

            Graduate grad = new Graduate(gradStuName, gradStuId, gradStuGrade);

            Console.WriteLine("Graduate: " + " Student Name: " + grad.StudentName + " with ID " + grad.StudentId + " has " +
                              (grad.IsPassed(grad.Grade) ? "passed." : "not passed."));
            Console.Read();
        }
    }
}
