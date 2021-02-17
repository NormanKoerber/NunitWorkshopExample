using System;

namespace NUnitWorkshopExample
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var calculator = new Calculator();
            int sum = calculator.Add(12, 56);
            Console.WriteLine($"12 + 56 = {sum}?");
            Console.ReadLine();
        }
    }
}