using System;
namespace immutableID
{
    class Student
    {
        // auto-implemented properties
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // default constructor
        public Student()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
        }
        // parameterized constructor
        public Student(int i, string First, string Last)
        {
            Id = i;
            FirstName = First;
            LastName = Last;
        }

        public Student(int id)
        {
            Id = id;
            FirstName = "";
            LastName = "";
        }
 
    }
    class Program
    {
        public static void Main()
    {
        Student student1 = new(100);
        student1.FirstName = "Dmitry";
        student1.LastName = "Novikov";
        Console.WriteLine($"{student1.Id}, {student1.FirstName}, {student1.LastName}");
        Student student2 = new(200, "Tom", "Holland");
        Console.WriteLine($"{student2.Id}, {student2.FirstName}, {student2.LastName}");
    }
    }
}
