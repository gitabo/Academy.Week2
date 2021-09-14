using System;
using AcademyG.Week2.Lib;

namespace Academy.Weeek2.EsercitazioneProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            Product prod = new Product("A1B2C3", "Descrizione", 100);
            Console.WriteLine("Prezzo scontato : " + prod.DiscountedPrice(10)+ " Age: " + prod.ProductAge());
            prod.SaveProduct();
        }
    }
}
