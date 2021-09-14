using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week2.Lib
{
    public class Product
    {
        string Code { get; set; }
        string Description { get; set; }
        double Price { get; set; }
        DateTime Created { get;}

        public Product()
        {
            Created = DateTime.Now;
        }

        public Product(string code, double price)
        {
            Code = code;
            Price = price;
            Created = DateTime.Now;
        }

        public Product(string code, string descr, double price)
        {
            Code = code;
            Price = price;
            Description = descr;
            Created = DateTime.Now;
        }

        public double DiscountedPrice(double discount)
        {
            if (discount > 20)
                discount = 20;
            return Price - (Price * discount) / 100;
        }

        public int ProductAge()
        {
            int dateDiff = DateTime.Now.DayOfYear - Created.DayOfYear ;
            return dateDiff;
        }

        public void SaveProduct()
        {
            string path = @"C:\Users\mauro.abozzi\source\repos\Academy.Week2\AcademyG.Week2.Lib\product.txt";

            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine($"{Code}:");
                    writer.WriteLine($"\t- {Description}");
                    writer.WriteLine($"\t- {Price}");
                    writer.WriteLine($"\t- {Created}");

                    writer.Flush();
                    writer.Close();
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
