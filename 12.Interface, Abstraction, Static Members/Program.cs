using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculation calc = new Calculation();

            Console.Write("Birinci ədədi daxil edin: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Əməliyyatı daxil edin (+, -, *, /): ");
            string operation = Console.ReadLine();

            Console.Write("İkinci ədədi daxil edin: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = calc.Calculate(num1, num2, operation);

            Console.WriteLine($"Nəticə: {result}");
        }
    }
}
