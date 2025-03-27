using System;

namespace Assignment8ex2
{   
    // Custom delegate declaration
    public delegate double ProductDelegate(double a, double b);

    public class MathSolutions
    {
        public double GetSum(double x, double y)
        {
            return x + y;
        }
        public double GetProduct(double a, double b)
        {
            return a * b;
        }
        public void GetSmaller(double a, double b)
        {
            if (a < b)
                Console.WriteLine($" {a} is smaller than {b}");
            else if (b < a)
                Console.WriteLine($" {b} is smaller than {a}");
            else
                Console.WriteLine($" {b} is equal to {a}");
        }
        static void Main(string[] args)
        {
            // create a class object
            MathSolutions answer = new MathSolutions();
            Random r= new Random();
            double num1 = Math.Round(r.NextDouble()*100);
            double num2 = Math.Round(r.NextDouble()*100);
            Console.WriteLine($" {num1} + {num2} = {answer.GetSum(num1,num2)}");
            Console.WriteLine($" {num1} * {num2} = {answer.GetProduct(num1, num2)}");
            answer.GetSmaller(num1, num2);
            
            // Create an Action delegat
            Action<double, double> showSmaller = answer.GetSmaller;
            showSmaller(num1, num2);

            // Create a Func delegate
            Func<double, double, double> sumFunc = answer.GetSum;
            double sumResult = sumFunc(num1, num2);
            Console.WriteLine($"Using Func delegate (sum): {num1} + {num2} = {sumResult}");

            // Create an instance of the custom delegate
            ProductDelegate productDel = new ProductDelegate(answer.GetProduct);
            // Invoke the delegate
            double productResult = productDel(num1, num2);
            Console.WriteLine($"Using custom delegate: {num1} * {num2} = {productResult}");
        }
    }
}
