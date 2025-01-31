using System;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        Console.WriteLine("How many integer numbers do you want to generate?");
        if (!int.TryParse(Console.ReadLine(), out int numberGenerate) || numberGenerate <= 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive integer.");
            return;
        }
        int[] numbers = new int [numberGenerate];
        for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = r.Next(1,101);
                Console.WriteLine($"{numbers[i]}");
            }
        Console.WriteLine($"Addition: {Add(numbers)}");
        Console.WriteLine($"Multiplication: {Multiply(numbers)}");
    }
    static int Add(params int[] numbers)
    {
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        return total;
    }
    static long Multiply (params int[] numbers)
    {
        long total = 1;
        foreach (int number in numbers)
        {
            total *= number;
            if (total > int.MaxValue) // Optional: Overflow warning
            {
                Console.WriteLine("Warning: Multiplication result exceeds integer limit.");
            }
        }
        return total;
    }

}