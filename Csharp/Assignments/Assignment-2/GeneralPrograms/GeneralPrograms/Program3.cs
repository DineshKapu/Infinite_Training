using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralPrograms
{
    enum Days
    {
        Monday=1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    class Program3
    {
        public static void Main()
        {
            int num;
            Console.WriteLine("Enter a Day Number (1-7):");
            num = Convert.ToInt32(Console.ReadLine());
            if(Enum.IsDefined(typeof(Days),num))
             {
                Days res = (Days)num;
                Console.WriteLine(res);

            }
            else
            {
                Console.WriteLine("Msg:The Range should be 1-7");
            }
            Console.Read();

        }
    }
}
