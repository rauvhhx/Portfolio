using System;

namespace SimpleCalculator
{
    public class Calculation : ICalculation
    {
        public double Calculate(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return num1 + num2;

                case "-":
                    return num1 - num2;

                case "*":
                    return num1 * num2;

                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("❌ 0-a bölmək mümkün deyil!");
                        return double.NaN;
                    }
                    return num1 / num2;
            }

            Console.WriteLine("⚠️ Yanlış əməliyyat daxil etmisiniz!");
            return 0;
        }
    }
}
