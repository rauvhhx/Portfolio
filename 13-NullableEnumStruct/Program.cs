
using System;

namespace CafeOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

         
            DrinkOrder order1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
            DrinkOrder order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            DrinkOrder order3 = new DrinkOrder(103, "Vüqar", DrinkType.Juice, DrinkSize.Small);

            order1.DisplayOrder();
            order1.UpdateStatus(OrderStatus.Preparing);
            order1.UpdateStatus(OrderStatus.Ready);
            order1.UpdateStatus(OrderStatus.Delivered);

            Console.WriteLine();

            
            order2.DisplayOrder();
            order2.UpdateStatus(OrderStatus.Ready);

            Console.WriteLine();

            
            order3.DisplayOrder();

            Console.WriteLine("\n---------------- ENUM ƏMƏLİYYATLARI ----------------");

            
            Console.WriteLine("DrinkType dəyərləri:");
            foreach (var val in Enum.GetValues(typeof(DrinkType)))
                Console.WriteLine($"- {val}");

            Console.WriteLine("\nDrinkSize dəyərləri:");
            foreach (var val in Enum.GetValues(typeof(DrinkSize)))
                Console.WriteLine($"- {val}");

            Console.WriteLine("\nOrderStatus dəyərləri:");
            foreach (var val in Enum.GetValues(typeof(OrderStatus)))
                Console.WriteLine($"- {val}");

            
            Console.WriteLine("\nToString nümunələri:");
            Console.WriteLine(DrinkType.Coffee.ToString());
            Console.WriteLine(DrinkSize.Large.ToString());

           
            Console.WriteLine("\nParse nümunələri:");
            DrinkType parsedDrink = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
            DrinkSize parsedSize = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");
            Console.WriteLine($"Parsed DrinkType: {parsedDrink}");
            Console.WriteLine($"Parsed DrinkSize: {parsedSize}");

            Console.WriteLine("\n---------------- STATİSTİKA ----------------");

            decimal total = order1.Price + order2.Price + order3.Price;
            Console.WriteLine($"Ümumi sifariş sayı: 3");
            Console.WriteLine($"1. sifariş qiyməti: {order1.Price} AZN");
            Console.WriteLine($"2. sifariş qiyməti: {order2.Price} AZN");
            Console.WriteLine($"3. sifariş qiyməti: {order3.Price} AZN");
            Console.WriteLine($"Ümumi məbləğ: {total} AZN");
        }
    }
}
