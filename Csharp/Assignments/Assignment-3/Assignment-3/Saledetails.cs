using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Saledetails
    {
        public static int Salesno;
        public static int ProductNo;
        public static double Price;
        public static DateTime DateOfSale;
        public static int Qty;
        public static double TotalAmount;
        public Saledetails(int Salesno1, int ProductNo1, double Price1, DateTime DateOfSale1, int Qty1)
        {
            Salesno = Salesno1;
            ProductNo = ProductNo1;
            Price = Price1;
            DateOfSale = DateOfSale1;
            Qty = Qty1;
            Sales();
        }
        public void Sales()
        {
            TotalAmount = Price * Qty;
        }
        public static void ShowData()
        {
            Console.WriteLine("-----------The Sale Details are:----------");
            Console.WriteLine("Sales Number:"+ Salesno);
            Console.WriteLine("Product Number:"+ ProductNo);
            Console.WriteLine("Price:"+ Price);
            Console.WriteLine("Date of Sale:"+DateOfSale);
            Console.WriteLine("Quantity:"+ Qty);
            Console.WriteLine("Total Amount:"+TotalAmount);

        }

        static void Main(string[] args)
        {
           int SalesNo;
           int ProductNo;
           double Price;
           DateTime DateOfSale;
           int Qty;
            Console.WriteLine("Enter Sales Number:");
            SalesNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product Number:");
            ProductNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Price:");
            Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Date of Sale:");
            DateOfSale = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Quantity:");
            Qty= Convert.ToInt32(Console.ReadLine());
            Saledetails sd = new Saledetails(SalesNo, ProductNo, Price, DateOfSale, Qty);
            Saledetails.ShowData();
            Console.Read();
        }
    }
}
