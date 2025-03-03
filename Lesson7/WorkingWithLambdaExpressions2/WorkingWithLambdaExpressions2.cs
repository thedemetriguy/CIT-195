using System;

namespace WorkingWithLambdaExpressions2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter 2 numbers: ");
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            
            // Add 2 numbers
            var sum = (double x, double y) => x + y;
            Console.WriteLine($"Sum: {sum(number1, number2)}");
            
            // Multiply 2 numbers
            var mul = (double x, double y) => x * y;
            Console.WriteLine($"Product: {mul(number1, number2)}");
            
            // Find the smaller number
            var smallerValue = (double a, double b) =>
            {
                if (a > b)
                {
                    Console.WriteLine($"{b} is smaller than {a}");
                    return b;
                }
                else
                {
                    Console.WriteLine($"{a} is smaller than {b}");
                    return a;
                }
            };
            
            Console.WriteLine($"Smaller value: {smallerValue(number1, number2)}");
        }
    }
}
