using System;

namespace csharp.Logic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var stock = new Inventory().GetStock();

            var app = new GildedRose(stock);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (Item item in stock)
                {
                    Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
