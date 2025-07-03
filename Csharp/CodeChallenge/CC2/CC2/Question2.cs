using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Question-2: 
    Create a Class called Products with Productid, Product Name, Price. Accept 10 Products, sort them based on the price, and display the sorted Products
 */
namespace CC2
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Product(int ProductId, string ProductName, double Price)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Price = Price;
        }
        public override string ToString()
        {
            return ($"ProductId: {ProductId}, ProuctName: {ProductName}, Price: {Price}");
        }
    }
    class Question2
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter details for product {0}:", i + 1);
                Console.Write("Enter Product Id:");
                int productId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Product Name:");
                string productName = Console.ReadLine();
                Console.Write("Enter Product Price:");
                double price = Convert.ToDouble(Console.ReadLine());
                products.Add(new Product(productId, productName, price));
            }
            //Sorting based on Price
            List<Product> SortedProducts = new List<Product>(products);
            for (int i = 0; i < SortedProducts.Count - 1; i++)
            {
                for (int j = 0; j < SortedProducts.Count - i - 1; j++)
                {
                    if (SortedProducts[j].Price > SortedProducts[j + 1].Price)
                    {
                        var temp = SortedProducts[j];
                        SortedProducts[j] = SortedProducts[j + 1];
                        SortedProducts[j + 1] = temp;
                    }
                }
            }
            //Ascending Order
            Console.WriteLine("\nProducts are Sorted by Price:");
            foreach (var product in SortedProducts)
            {
                Console.WriteLine(product);
            }
            Console.Read();
        }
    }
}
