using System;
namespace recordDemo
{
    class Program
    { 
    public record Bookstore(int ID, string Title, string Author, double Price);

        public static void Main()
        {
            Bookstore bookstore1 = new(100, "Sports", "Mark Manson", 25);
            Console.WriteLine(bookstore1);
            Bookstore bookstore2 = new(200, "Music", "Tom Brady", 50);
            Console.WriteLine(bookstore2);
            Bookstore bookstore3 = new(300, "Nutrition", "Dmitry Novikov", 30);
            Console.WriteLine(bookstore3);
        }
    }
}
