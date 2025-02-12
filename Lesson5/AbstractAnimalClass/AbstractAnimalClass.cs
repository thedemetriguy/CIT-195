using System;
using System.Xml.Linq;

namespace Animals
{
    abstract class Animal
    {
        // Property
        public abstract string Name { get; set; }
        // Methods
        public abstract string Describe();
        public string whatAmI()
        {
            return "I am an animal";
        }
    }
    class Dog : Animal
        {
            // override the abstract property
            public override string Name { get; set; }
            public string Type { get; set; }
            public int Age { get; set; }

            public Dog()
            {
                Name = string.Empty;
                Type = string.Empty;
                Age = 0;
            }
            public Dog(string name, string type, int age)
            {
                Name = name;
                Type = type;
                Age = age;
            }
            // override the abstract method
            public override string Describe()
            {
                return "I am a " + Type + "\nMy name is " + Name + "\nI am " + Age;
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
            // Create Dog object 
            Dog doggy = new Dog();
            doggy.Name = "Maggy";
            doggy.Type = "Golden Retriever";
            doggy.Age = 9;
            Console.WriteLine(doggy.whatAmI());
            Console.WriteLine(doggy.Describe());

            Dog dog = new Dog("Ranger", "Bulldog", 12);
            Console.WriteLine(dog.whatAmI());
            Console.WriteLine(dog.Describe());
        }
    }
}